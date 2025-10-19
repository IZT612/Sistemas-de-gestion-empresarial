using Microsoft.AspNetCore.Mvc;

namespace Aplicacion_1.Controllers
{
    public class HoraController : Controller
    {

        // Método privado para obtener la hora actual
        private DateTime obtenerHora()
        {

            return DateTime.Now;

        }

        // Método privado para determinar si es pasado mediodía
        private string pasadoMediodia()
        {

            return obtenerHora().Hour >= 12 ? "Es pasado mediodía" : "No es pasado mediodía";

        }

        public IActionResult Hora()
        {
            // Obtenemos la hora actual y lo pasamos a la vista mediante ViewBag
            ViewBag.HoraActual = obtenerHora();

            // Obtenemos el mensaje de si es pasado mediodía y lo pasamos a la vista mediante ViewBag
            ViewBag.MensajeMediodia = pasadoMediodia();
            return View();
        }
    }
}
