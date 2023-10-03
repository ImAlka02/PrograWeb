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

        [Route("Peliculas/{Id}")]
        public IActionResult Detalles(string Id)
        {
            Id = Id.Replace("-", " ");

            
            PixarContext context = new();
            var datos = context.Pelicula.Include(x => x.Apariciones)
                .ThenInclude(x=>x.IdPersonajeNavigation)
                .FirstOrDefault(x => x.Nombre == Id);
            if(datos == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                DetallesPeliculaViewModel vm = new()
                {
                    Id = datos.Id,
                    Nombre = datos.Nombre ?? "Sin nombre",
                    NombreOriginal = datos.NombreOriginal ?? "Sin nombre",
                    Fecha = datos.FechaEstreno != null ?
                            datos.FechaEstreno.Value.ToDateTime(TimeOnly.MinValue)
                            : DateTime.MinValue,
                    Descripcion = datos.Descripción ?? "No disponible",
                    Personajes = datos.Apariciones.Select(x => new PersonajeModel()
                    {
                        Id = x.IdPersonaje,
                        Nombre = x.IdPersonajeNavigation.Nombre ?? "Sin Nombre",
                    })
                };
                return View(vm);

            }
            //var datos = context.Pelicula.OrderBy(x => x.Nombre).Where(x => x.Nombre.ToLower() == Id.ToLower()).FirstOrDefault();
            //if (datos == null)
            //{
            //    return RedirectToAction("Index");
            //}
            //else
            //{
            //    //DetallesPeliculaViewModel vm = new()
            //    //{
            //    //    Id = datos.Id,
            //    //    Nombre = datos.Nombre ?? "",
            //    //    NombreOriginal = datos.NombreOriginal ?? "",
            //    //    Fecha = datos.FechaEstreno.Value,
            //    //    Descripcion = datos.Descripción ?? "",
            //    //    Personajes = context.Pelicula.Select(x => new PersonajeModel
            //    //    {
            //    //        Id = x.Id,
            //    //        Nombre = x.Nombre ?? ""
            //    //    })
            //    //};
            //    var vm = context.Pelicula.Where(x => x.Nombre == Id).Select(x => new DetallesPeliculaViewModel()
            //    {
            //        Id = datos.Id,
            //        Nombre = datos.Nombre ?? "",
            //        NombreOriginal = datos.NombreOriginal ?? "",
            //        Fecha = datos.FechaEstreno.Value,
            //        Descripcion = datos.Descripción ?? "",
            //        Personajes = x.Apariciones.Select(x=> new PersonajeModel()
            //        {
            //            Id = x.Id,
            //            Nombre = x.IdPersonajeNavigation.Nombre
            //        })
            //    }).FirstOrDefault();
            //    return View(vm);

            //};



        }
    }
}
