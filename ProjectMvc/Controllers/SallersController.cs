using Microsoft.AspNetCore.Mvc;

namespace ProjectMvc.Controllers
{
    public class SallersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
