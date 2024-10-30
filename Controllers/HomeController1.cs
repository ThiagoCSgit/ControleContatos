using Microsoft.AspNetCore.Mvc;

namespace ControleContatos.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
