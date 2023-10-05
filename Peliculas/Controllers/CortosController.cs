using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Peliculas.Models.Entities;
using Peliculas.Models.ViewModel;

namespace Peliculas.Controllers
{
    public class CortosController : Controller
    {
        public IActionResult Index()
        {
            PixarContext context = new();

            var datos = context.Categoria.Include(x => x.Cortometraje).OrderBy(x => x.Nombre).Select(x => new IndexCortosViewModel()
            {
                Categoria = x.Nombre ?? "Sin nombre",
                Cortos = x.Cortometraje.Select(c => new CortoModel()
                {
                    Id = c.Id,
                    Nombre = c.Nombre ?? "Sin nombre"
                })
            });
            return View(datos);
        }

        [Route("/Cortos/{nombre}")]
        public IActionResult Detalles(string nombre)
        {
            nombre = nombre.Replace("_", " ");
            PixarContext context = new();
            var datos = context.Cortometraje.Where(x => x.Nombre == nombre).Select(y => new DatallesCortoViewModel()
            {
                Id = y.Id,
                Nombre = y.Nombre ?? "Sin nombre",
                Descripcion = y.Descripcion ?? "Sin descripcion"
            }).FirstOrDefault();

            if(datos == null)
            {
                return RedirectToAction("Index");
            }
            return View(datos);
        }
    }
}
