using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Proyecto1.Models;
using Proyecto1.Models.Entities;

namespace Proyecto1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var persona = new Persona(1, "Iván Zamora Torres", 18);
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
    }
}
