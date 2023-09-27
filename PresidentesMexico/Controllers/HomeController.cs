using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PresidentesMexico.Models.Entitis;
using PresidentesMexico.Models.ViewModels;

namespace PresidentesMexico.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            PresidentesContext context = new PresidentesContext();
            IndexViewModel vm = new();

            var datos = context.Presidente.OrderBy(x => x.InicioGobierno);
            vm.Presidentes = datos.Select(x => new PresidenteModel
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Periodo = x.InicioGobierno.Year + "-" 
                + (x.TerminoGobierno != null ? x.TerminoGobierno.Value.Year.ToString():"")
            });
            return View(vm);
        }

        public IActionResult Biografia(string Id)
        {
            PresidentesContext context = new();

            Id = Id.Replace("-", " ");
            var presidente = context.Presidente.Include(x=> x.IdEstadoRepublicaNavigation)
                .Include(x => x.IdPartidoPoliticoNavigation)
                .Where(x => x.Nombre.ToLower() == Id.ToLower()).FirstOrDefault();

            if (presidente == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                BiografiaViewModel vm = new BiografiaViewModel()
                {
                    Id = presidente.Id,
                    Nombre = presidente.Nombre,
                    Biografia = presidente.Biografia,
                    CiudadNacimiento = presidente.CiudadNacimiento??"No c", //Null-cpalescence operator
                    EstadoNacimiento = presidente.IdEstadoRepublicaNavigation == null ? "": presidente.IdEstadoRepublicaNavigation.Nombre,
                    NombrePartido = presidente.IdPartidoPoliticoNavigation.Nombre,
                    FechaDefuncionNacimiento = presidente.FechaFallecimiento != null ? presidente.FechaFallecimiento.Value.ToLongDateString() : "No ha morido",
                    FechaNacimiento = presidente.FechaNacimiento != null ? presidente.FechaNacimiento.Value.ToLongDateString() : "Desconocido",
                    InicioGobierno = presidente.InicioGobierno.ToLongDateString(),
                    FinGobierno = presidente.TerminoGobierno != null ? presidente.TerminoGobierno.Value.ToLongDateString() : "Desconocido",
                    IdPartido = presidente.IdPartidoPolitico,
                    Ocupacion = presidente.Ocupacion??"Desconocido"
                };
                return View(vm);
            }

            
        }
    }
}
