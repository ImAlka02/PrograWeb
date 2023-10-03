using Microsoft.AspNetCore.Mvc;

namespace Peliculas.Controllers
{
    public class CortosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
