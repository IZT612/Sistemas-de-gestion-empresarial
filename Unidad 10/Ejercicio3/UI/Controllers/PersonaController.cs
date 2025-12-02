using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Domain.DTO;
using System;

namespace UI.Controllers
{
    public class PersonaController : Controller
    {
        private readonly IPersonaUC _personaUC;
        private readonly IDepartamentoUC _departamentoUC;

        public PersonaController(IPersonaUC personaUC, IDepartamentoUC departamentoUC)
        {
            _personaUC = personaUC;
            _departamentoUC = departamentoUC;
        }

        // GET: Persona
        [HttpGet]
        public ActionResult Index()
        {
            List<PersonaWithNombreDepartamentoDTO> personas = _personaUC.getListaPersonasConDepartamentos();
            return View(personas);
        }

        // GET: Persona/Details/{id}
        [HttpGet]
        public ActionResult Details(int id)
        {
            PersonaWithNombreDepartamentoDTO persona = _personaUC.getDetallesPersona(id);
            if (persona == null) return NotFound();
            return View(persona);
        }

        // GET: Persona/Create
        [HttpGet]
        public ActionResult Create()
        {
            PersonaWithListaDepartamentosDTO dto = new PersonaWithListaDepartamentosDTO(_departamentoUC.getDepartamentos().ToArray());
            return View(dto);
        }

        // POST: Persona/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("id, nombre, apellido, direccion, telefono, foto, departamento")] PersonaWithListaDepartamentosDTO dto)
        {

            dto.fechaNac ??= DateTime.Now;

            try
            {

                if (!ModelState.IsValid)
                {
                    return View(dto);
                }

                _personaUC.crearPersona(_personaUC.PersonaWithListDepartamentoDTOPasarAPersona(dto));
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(_personaUC.PersonaWithListDepartamentoDTOPasarAPersona(dto));
            }
        }

        // GET: Persona/Edit/{id}
        [HttpGet]
        public ActionResult Edit(int id)
        {
            PersonaWithListaDepartamentosDTO personaYLista = _personaUC.getPersonaFormulario(id);
            if (personaYLista == null) return NotFound();
            return View(personaYLista);
        }

        // POST: Persona/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("id, nombre, apellido, direccion, telefono, foto, departamento")] PersonaWithListaDepartamentosDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    PersonaWithListaDepartamentosDTO personaYLista = _personaUC.getPersonaFormulario(dto.id);
                    return View(personaYLista);
                }

                _personaUC.actualizarPersona(dto.id, _personaUC.PersonaWithListDepartamentoDTOPasarAPersona(dto));
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                PersonaWithListaDepartamentosDTO personaYLista = _personaUC.getPersonaFormulario(dto.id);
                return View(personaYLista);
            }
        }

        // GET: Persona/Delete/{id}
        [HttpGet]
        public ActionResult Delete(int id)
        {
            PersonaWithNombreDepartamentoDTO persona = _personaUC.getDetallesPersona(id);
            if (persona == null) return NotFound();
            return View(persona);
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
                PersonaWithNombreDepartamentoDTO persona = _personaUC.getDetallesPersona(id);
                return View("Delete", persona);
            }
        }
    }
}
