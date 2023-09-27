using MexicoEstados.Models.Entities;
using MexicoEstados.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MexicoEstados.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //orm ef = mapeo de objetos relacionales
            MexicoContext context = new();
            var edos = context.Estados.OrderBy(x => x.Nombre).Select(x => new IndexViewModel
            {
                Nombre = x.Nombre
            }); //proyeccion, cuando yo la use ocurrira mientras no
           


            return View(edos);
        }
    }
}
