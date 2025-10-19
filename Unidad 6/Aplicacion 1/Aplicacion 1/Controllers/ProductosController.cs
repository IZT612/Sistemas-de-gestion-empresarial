using Microsoft.AspNetCore.Mvc;

namespace Aplicacion_1.Controllers
{
    public class ProductosController : Controller
    {
        public IActionResult ListadoProductos()
        {
            return View();
        }
    }
}
