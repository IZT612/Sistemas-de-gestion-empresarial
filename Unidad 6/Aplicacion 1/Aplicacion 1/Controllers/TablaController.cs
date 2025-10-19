using Microsoft.AspNetCore.Mvc;

namespace Aplicacion_1.Controllers
{
    public class TablaController : Controller
    {

        private string[][] GetTablaMultiplicacion(int ultimoNumero1, int ultimoNumero2)
        {
            string[][] tabla = new string[ultimoNumero1][];

            for (int i = 1; i <= ultimoNumero1; i++)
            {
                tabla[i - 1] = new string[ultimoNumero2];

                for (int j = 1; j <= ultimoNumero2; j++)
                {
                    tabla[i - 1][j - 1] = $"{i} * {j} = {i * j}";
                }
            }

            return tabla;
        }

        public IActionResult TablaMultiplicar()
        {
            ViewBag.Tabla = GetTablaMultiplicacion(12, 10);
            return View();
        }
    }
}
