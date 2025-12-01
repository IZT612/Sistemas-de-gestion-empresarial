using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace UI.Controllers
{
    public class DepartamentoController : Controller
    {
        private readonly IDepartamentoUC _depUC;

        public DepartamentoController(IDepartamentoUC depUC)
        {
            _depUC = depUC;
        }

        // GET: Departamento
        [HttpGet]
        public ActionResult Index()
        {
            var model = _depUC.getDepartamentos();
            return View(model);
        }

        // GET: Departamento/Details/{id}
        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = _depUC.getDetalleDepartamento(id);
            if (model == null) return NotFound();
            return View(model);
        }

        // GET: Departamento/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Departamento/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Departamento departamento)
        {
            try
            {
                if (!ModelState.IsValid) return View(departamento);
                _depUC.crearDepartamento(departamento);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(departamento);
            }
        }

        // GET: Departamento/Edit/{id}
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _depUC.getDetalleDepartamento(id);
            if (model == null) return NotFound();
            return View(model);
        }

        // POST: Departamento/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Departamento departamento)
        {
            try
            {
                if (!ModelState.IsValid) return View(departamento);
                _depUC.actualizarDepartamento(id, departamento);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(departamento);
            }
        }

        // GET: Departamento/Delete/{id}
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = _depUC.getDetalleDepartamento(id);
            if (model == null) return NotFound();
            return View(model);
        }

        // POST: Departamento/Delete/{id}
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _depUC.eliminarDepartamento(id);
                return RedirectToAction("Index");
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError("", ex.Message);
                var model = _depUC.getDetalleDepartamento(id);
                return View("Delete", model);
            }
        }

    }
}
