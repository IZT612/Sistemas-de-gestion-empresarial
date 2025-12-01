using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace UI.Controllers
{
    public class PersonaController : Controller
    {
        private readonly IPersonaUC _personaUC;

        public PersonaController(IPersonaUC personaUC)
        {
            _personaUC = personaUC;
        }

        // GET: Persona
        [HttpGet]
        public ActionResult Index()
        {
            var model = _personaUC.getListaPersonasConDepartamentos();
            return View(model);
        }

        // GET: Persona/Details/{id}
        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = _personaUC.getDetallesPersona(id);
            if (model == null) return NotFound();
            return View(model);
        }

        // GET: Persona/Create
        [HttpGet]
        public ActionResult Create()
        {
            var model = _personaUC.getPersonaFormulario();
            return View(model);
        }

        // POST: Persona/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Persona persona)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var dto = _personaUC.getPersonaFormulario(); // necesario para recargar lista de departamentos
                    return View(dto);
                }

                _personaUC.crearPersona(persona);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                var dto = _personaUC.getPersonaFormulario();
                return View(dto);
            }
        }

        // GET: Persona/Edit/{id}
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _personaUC.getPersonaFormulario(id);
            if (model == null) return NotFound();
            return View(model);
        }

        // POST: Persona/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Persona persona)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var dto = _personaUC.getPersonaFormulario(id);
                    return View(dto);
                }

                _personaUC.actualizarPersona(id, persona);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                var dto = _personaUC.getPersonaFormulario(id);
                return View(dto);
            }
        }

        // GET: Persona/Delete/{id}
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = _personaUC.getDetallesPersona(id);
            if (model == null) return NotFound();
            return View(model);
        }

        // POST: Persona/Delete/{id}
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _personaUC.eliminarPersona(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                var model = _personaUC.getDetallesPersona(id);
                return View("Delete", model);
            }
        }
    }
}
