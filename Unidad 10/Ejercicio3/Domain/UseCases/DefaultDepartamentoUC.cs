using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Repositories;

namespace Domain.UseCases
{
    public class DefaultDepartamentoUC : IDepartamentoUC
    {
        private readonly IDepartamentoRepository _depRepo;
        private readonly IPeopleRepository _peopleRepo;

        public DefaultDepartamentoUC(IDepartamentoRepository depRepo, IPeopleRepository peopleRepo)
        {
            _depRepo = depRepo ?? throw new ArgumentNullException(nameof(depRepo));
            _peopleRepo = peopleRepo ?? throw new ArgumentNullException(nameof(peopleRepo));
        }

        public List<Departamento> getDepartamentos()
        {
            return _depRepo.getDepartamentos() ?? new List<Departamento>();
        }

        public Departamento getDetalleDepartamento(int id)
        {
            return _depRepo.getDepartamentoById(id);
        }

        public List<Persona> getPersonasEnDepartamento(int id)
        {
            List<Persona> personas = _peopleRepo.getPersonas() ?? new List<Persona>();
            return personas.Where(p => p.departamento == id).ToList();
        }

        public int crearDepartamento(Departamento departamento)
        {
            if (departamento == null) throw new ArgumentNullException(nameof(departamento));
            if (string.IsNullOrWhiteSpace(departamento.nombre)) throw new ArgumentException("Nombre requerido");
            return _depRepo.crearDepartamento(departamento);
        }

        public int actualizarDepartamento(int id, Departamento departamento)
        {
            if (departamento == null) throw new ArgumentNullException(nameof(departamento));
            Departamento existing = _depRepo.getDepartamentoById(id);
            if (existing == null) return 0;
            return _depRepo.actualizarDepartamento(id, departamento);
        }

        public int eliminarDepartamento(int id)
        {
            Departamento existing = _depRepo.getDepartamentoById(id);
            if (existing == null) return 0;

            

            return _depRepo.deleteDepartamento(id);
        }

    }
}