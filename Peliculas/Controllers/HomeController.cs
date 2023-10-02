using Microsoft.AspNetCore.Mvc;

namespace Peliculas.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
