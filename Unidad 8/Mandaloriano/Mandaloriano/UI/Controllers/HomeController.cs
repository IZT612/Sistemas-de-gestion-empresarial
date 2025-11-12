using Domain.Interfaces;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UI.Models;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        IGetMisionesUseCase _getMisionesUseCase;
        IMisionesRepository _misionesRepository;

        public HomeController(IGetMisionesUseCase getMisionesUseCase, IMisionesRepository misionesRepository)
        {
            _getMisionesUseCase = getMisionesUseCase;
            _misionesRepository = misionesRepository;
        }

        public IActionResult Index()
        {
            // Llamamos al UseCase
            var misiones = _getMisionesUseCase.getMisionesUseCase(_misionesRepository);

            // Mapeamos entidades a ViewModel
            List<IndexViewModel> viewModel = misiones.Select(m => new IndexViewModel
            {
                Id = m.Id,
                Titulo = m.Titulo,
                Descripcion = m.Descripcion,
                Recompensa = m.Recompensa
            }).ToList();

            return View(viewModel);

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
