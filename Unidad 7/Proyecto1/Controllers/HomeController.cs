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

        static DepartamentosDAL listaDepartamentos = new DepartamentosDAL();

        // Guardamos aquí la lista de personas porque la usaremos en dos vistas.
        static PersonasDAL listaPersonas = new PersonasDAL(listaDepartamentos.lista);

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var persona = new Persona(1, "Iván", "Zamora Torres", 18, listaDepartamentos.lista[4]);
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

        public IActionResult crearFormulario(int id)
        {
            Persona personaEditar = listaPersonas.lista[1];

            foreach (Persona persona in listaPersonas.lista)
            {
                if (persona.id == id)
                {
                    personaEditar = persona;

                }
            }

            ViewBag.ListaDepartamentos = listaDepartamentos.lista;

            return View("formulario", personaEditar);

        }

        public IActionResult guardarCambios()
        {
            return View("Index");
        }

    }
}
