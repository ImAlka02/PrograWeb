using Microsoft.AspNetCore.Mvc;
using Peliculas.Models.Entities;
using Peliculas.Models.ViewModel;

namespace Peliculas.Controllers
{
    public class PeliculasController : Controller
    {
        public IActionResult Index()
        {
            PixarContext context = new();
            var datos = context.Pelicula.OrderBy(x => x.Nombre).Select(x => new IndexPeliculaViewModel
            {
                Id = x.Id,
                Nombre = x.Nombre ?? ""
            });
            
            return View(datos);
        }
    }
}
