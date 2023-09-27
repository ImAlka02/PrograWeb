using Controladores.Models;
using Microsoft.AspNetCore.Mvc;

namespace Controladores.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Saludo()
        {
            return View();
        }
        public IActionResult Perfil()
        {
            PerfilViewModel perfil = new();
            perfil.Nombre = "Eduardo uwu";
            perfil.Carrera = "Sistemas owo";
            perfil.Correo = "owo@gmail.com";
            perfil.Semestre = 7;

            return View(perfil);
        }

        public IActionResult Suma(SumaViewModel vm)
        {
            return View(vm);
        }

        public IActionResult Resultado(SumaViewModel vm)
        {
            vm.Resultado = vm.Numero1 + vm.Numero2;
            return View(vm);
        }

        //Actions
        //public string Index()
        //{
        //    return "Hola a todes";
        //}

        public string Saludame(string nombre)
        {
            return $"Hola {nombre}";
        }

        public int Sumar (int x, int y)
        {
            return x + y;
        }
    }
}
