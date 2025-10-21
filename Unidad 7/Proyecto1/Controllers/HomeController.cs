using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Proyecto1.Models;
using Proyecto1.Models.Entities;
using Proyecto1.Models.DAL;

namespace Proyecto1.Controllers
{
    public class HomeController : Controller
    {
        Random rnd = new Random();


        // Guardamos aquí la lista de personas porque la usaremos en dos vistas.
        PersonasDAL listaPersonas = new PersonasDAL(new List<Persona>
            {
                new Persona(1, "Iván",  "Zamora Torres", 18),
                new Persona(2, "María", "García López", 25),
                new Persona(3, "Carlos", "Sánchez Pérez", 30),
                new Persona(4, "Ana", "Fernández Gómez", 22),
                new Persona(5, "Luis", "Rodríguez Díaz", 28)
            });

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var persona = new Persona(1, "Iván", "Zamora Torres", 18);
            int horaActual = DateTime.Now.Hour;
            string mensaje;

            if (horaActual >= 6 && horaActual < 12)
            {

                mensaje = "Buenos días";

            }
            else if (horaActual >= 12 && horaActual < 20)
            {

                mensaje = "Buenas tardes";

            }
            else
            {

                mensaje = "Buenas noches";

            }

            ViewData["Mensaje"] = mensaje;
            ViewBag.HoraActual = DateTime.Now.ToString("HH:mm:ss");
            return View(persona);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult listadoPersonas()
        {

            return View(listaPersonas);

        }

        public IActionResult terceraPersona()
        {

            return View(listaPersonas.lista[2]);

        }

        public IActionResult editarPersona()
        {

            return View(listaPersonas.lista[rnd.Next(0, 5)]);

        }

    }
}
