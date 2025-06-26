using Microsoft.AspNetCore.Mvc;
using ProjectMvc.Models;
using ProjectMvc.Services;
using System.Linq;
using System.Collections.Generic;
using ProjectMvc.Models.ViewModels;
using ProjectMvc.Services.Exception;
using System.Diagnostics;

namespace ProjectMvc.Controllers
{
    public class SallersController : Controller
    {
        private readonly SalllerService _sallerService;
        private readonly DepartamentService _departamentService;

        public SallersController(SalllerService sallerService, DepartamentService departamentService)
        {
            _sallerService = sallerService;
            _departamentService = departamentService;
        }

        public IActionResult Index()
        {
            var list = _sallerService.FindAll();
            return View(list);
        }
        public IActionResult Create()
        {
            var departaments = _departamentService.findAll();
            var viewModel = new SallesFormViewModel { Departments = (ICollection<Departament>)departaments };

            return View(viewModel);
        }



        //isso indica que a função é um post e não um get
        [HttpPost]
        //previne contra ataques
        [ValidateAntiForgeryToken]
        //criando o método post e insere ele no banco de dados
        public IActionResult Create(Saller saller, Departament departament)

        {
            var departamnets = _departamentService.findAll();
            var viewModel = new SallesFormViewModel { Saller = saller, Departments = departamnets };
            return View(viewModel);
            _sallerService.Insert(saller);
            

            //redireciona para ação index(a que mostra na tela principal)
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return RedirectToAction(nameof(Error), new {message = "Id não foi fornecido "});
            }
            var obj = _sallerService.FindById(id.Value);
            if (obj == null) 
            {
                return RedirectToAction(nameof(Error), new { message = "Id não existe " });
            }

            return View(obj);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _sallerService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não foi fornecido" });
            }
            var obj = _sallerService.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não existe " });
            }

            return View(obj);
        }
        public IActionResult Edit(int? id) 
        {
            if (id == null) {

                return RedirectToAction(nameof(Error), new { message = "Id não fornecido " });
            }
            var obj = _sallerService.FindById(id.Value);
            if(obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não existe " });
            }
            List<Departament> departament = _departamentService.findAll();
            SallesFormViewModel viewModel = new SallesFormViewModel { Saller = obj, Departments = departament};
            return View(viewModel);
        
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Saller saller)
        {
            if (!ModelState.IsValid)

            {
                var departamnets = _departamentService.findAll();
                var viewModel = new SallesFormViewModel { Saller = saller, Departments = departamnets };
                return View(viewModel);
            }
            if(id != saller.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não correspondem  " });
            }
            try
            {
                _sallerService.Upadete(saller);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException e ) 
            {
                return RedirectToAction(nameof(Error), new { message = e.Message});
            }
            catch (DbConcurrencyException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
           
        }
        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                //Macete para pega o id intern da requesição
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}
