using Microsoft.AspNetCore.Mvc;
using ProjectMvc.Models;
using ProjectMvc.Services;
using System.Linq;
using System.Collections.Generic;
using ProjectMvc.Models.ViewModels;

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
            _sallerService.Insert(saller);
            

            //redireciona para ação index(a que mostra na tela principal)
            return RedirectToAction(nameof(Index));
        }
    }
}
