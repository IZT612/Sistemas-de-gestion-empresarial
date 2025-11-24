using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;

namespace UI.Controllers
{
    public class PersonaController : Controller
    {

        private readonly IGetPersonasWithDepartamentoUC _useCase;

        public PersonaController(IGetPersonasWithDepartamentoUC useCase)
        {
            _useCase = useCase;
        }

        // GET: PersonaController
        public ActionResult Index()
        {
            return View(_useCase.getPersonasWithNombreDepartamento());

        }

    }
}
