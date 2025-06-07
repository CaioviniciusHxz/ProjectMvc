using Microsoft.AspNetCore.Mvc;
using ProjectMvc.Models;
using ProjectMvc.Services;

namespace ProjectMvc.Controllers
{
    public class SallersController : Controller
    {
        private readonly SalllerService _sallerService;

        public SallersController(SalllerService sallerService)
        {
            _sallerService = sallerService;
        }

        public IActionResult Index()
        {
            var list = _sallerService.FindAll();
            return View(list);
        }
        public IActionResult Create()
        {
            return View();
        }



        //isso indica que a função é um post e não um get
        [HttpPost]
        //previne contra ataquea clrf
        [ValidateAntiForgeryToken]
        //criando o método post e insere ele no banco de dados
        public IActionResult Create(Saller saller)
        {
            _sallerService.Insert(saller);

            //redireciona para ação index(a que mostra na tela principal)
            return RedirectToAction(nameof(Index));
        }
    }
}
