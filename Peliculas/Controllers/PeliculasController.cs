using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public IActionResult Detalles(string Id)
        {
            Id = Id.Replace("-", " ");

            
            PixarContext context = new();
            var datos = context.Pelicula.OrderBy(x => x.Nombre).Where(x => x.Nombre.ToLower() == Id.ToLower()).FirstOrDefault();
            if (datos == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                //DetallesPeliculaViewModel vm = new()
                //{
                //    Id = datos.Id,
                //    Nombre = datos.Nombre ?? "",
                //    NombreOriginal = datos.NombreOriginal ?? "",
                //    Fecha = datos.FechaEstreno.Value,
                //    Descripcion = datos.Descripción ?? "",
                //    Personajes = context.Pelicula.Select(x => new PersonajeModel
                //    {
                //        Id = x.Id,
                //        Nombre = x.Nombre ?? ""
                //    })
                //};
                var vm = context.Pelicula.Where(x => x.Nombre == Id).Select(x => new DetallesPeliculaViewModel()
                {
                    Id = datos.Id,
                    Nombre = datos.Nombre ?? "",
                    NombreOriginal = datos.NombreOriginal ?? "",
                    Fecha = datos.FechaEstreno.Value,
                    Descripcion = datos.Descripción ?? "",
                    Personajes = x.Apariciones.Select(x=> new PersonajeModel()
                    {
                        Id = x.Id,
                        Nombre = x.IdPersonajeNavigation.Nombre
                    })
                }).FirstOrDefault();
                return View(vm);

            };
                
            
            
        }
    }
}
