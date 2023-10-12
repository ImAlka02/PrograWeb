using Microsoft.AspNetCore.Mvc;
using Reticulas.Models.Entities;
using Reticulas.Models.ViewModels;

namespace Reticulas.Controllers
{
	public class HomeController : Controller
	{

		public IActionResult Index()
		{
			MapaCurricularContext context = new();
			var datos = context.Carreras.Select(x => new IndexViewModel()
			{
				Nombre = x.Nombre,
				Plan = x.Plan
			}).OrderBy(x=> x.Nombre);
			return View(datos);
		}

		[Route ("/{id}/Informacion")]
		public IActionResult Informacion(string id)
		{
            MapaCurricularContext context = new();
			id = id.Replace("-", " ");
			var datos = context.Carreras.Select(x => new InfoViewModel()
			{
				Id = x.Id,
				Nombre = x.Nombre,
				Especialidad = x.Especialidad ?? "No disponible",
				Descripcion = x.Descripcion ?? "No disponible",
				Plan = x.Plan
			}).Where(y=> y.Nombre == id).FirstOrDefault();

            if (datos == null)
            {
                return RedirectToAction("Index");
            }
            return View(datos);
		}

        [Route("/{carrera}/Reticula")]
        public IActionResult Mapa(string carrera)
        {
            MapaCurricularContext context = new();
            var datos = context.Carreras.Where(x => x.Nombre == carrera.Replace("-"," "))
				.Select(x=> new MapaViewModel
				{
					NombreCarrera = x.Nombre,
					Plan = x.Plan,
					Creditos = x.Materias.Sum(m=>m.Creditos),
					Semestre = x.Materias.GroupBy(y => y.Semestre ).Select( z => new SemestreModel
					{
						NumSemestre = z.Key,
						Materias = z.Select( o => new MateriaModel
						{
							Clave = o.Clave,
							Nombre = o.Nombre,
							Creditos = o.HorasTeoricas + "-" + o.HorasPracticas + "-" + o.Creditos
						})
					})
				})
				.First();

			if(datos == null)
			{
				return RedirectToAction("Index");
			}
            return View(datos);
        }
    }
}
