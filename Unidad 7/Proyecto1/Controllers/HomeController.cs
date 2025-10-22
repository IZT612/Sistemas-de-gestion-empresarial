using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Proyecto1.Models;
using Proyecto1.Models.Entities;
using Proyecto1.Models.DAL;
using Proyecto1.Models.ViewModels;

namespace Proyecto1.Controllers
{
    public class HomeController : Controller
    {

        // Guardamos aquí la lista de personas porque la usaremos en dos vistas.


        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            DepartamentosDAL listaDepartamentos = new DepartamentosDAL();

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
            DepartamentosDAL listaDepartamentos = new DepartamentosDAL();
            PersonasDAL listaPersonas = new PersonasDAL(listaDepartamentos.lista);
            return View(listaPersonas);

        }

        public IActionResult terceraPersona()
        {
            DepartamentosDAL listaDepartamentos = new DepartamentosDAL();
            PersonasDAL listaPersonas = new PersonasDAL(listaDepartamentos.lista);
            return View(listaPersonas.lista[2]);

        }

        public IActionResult editarPersona()
        {
            Random rnd = new Random();
            DepartamentosDAL listaDepartamentos = new DepartamentosDAL();
            PersonasDAL listaPersonas = new PersonasDAL(listaDepartamentos.lista);
            return View(listaPersonas.lista[rnd.Next(0, 5)]);

        }

        public IActionResult crearFormulario(int id)
        {
            DepartamentosDAL listaDepartamentos = new DepartamentosDAL();

            PersonasDAL listaPersonas = new PersonasDAL(listaDepartamentos.lista);
            Persona personaEditar = listaPersonas.lista[1];

            foreach (Persona persona in listaPersonas.lista)
            {
                if (persona.id == id)
                {
                    personaEditar = persona;

                }
            }

            FormularioVM formularioVM = new FormularioVM(personaEditar, listaDepartamentos);

            return View("formulario", formularioVM);

        }

        public IActionResult guardarCambios()
        {
            return View("Index");
        }

    }
}
