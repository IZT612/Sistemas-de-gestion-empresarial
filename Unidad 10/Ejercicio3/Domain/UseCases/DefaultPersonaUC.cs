using System;
using System.Collections.Generic;
using System.Linq;
using Domain.DTO;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Repositories;

namespace Domain.UseCases
{
    public class DefaultPersonaUC : IPersonaUC
    {
        private readonly IPeopleRepository _peopleRepo;
        private readonly IDepartamentoRepository _depRepo;

        public DefaultPersonaUC(IPeopleRepository peopleRepo, IDepartamentoRepository depRepo)
        {
            _peopleRepo = peopleRepo ?? throw new ArgumentNullException(nameof(peopleRepo));
            _depRepo = depRepo ?? throw new ArgumentNullException(nameof(depRepo));
        }

        public List<Persona> getListaPersonas()
        {
            return _peopleRepo.getPersonas() ?? new List<Persona>();
        }

        public List<PersonaWithNombreDepartamentoDTO> getListaPersonasConDepartamentos()
        {
            var personas = _peopleRepo.getPersonas() ?? new List<Persona>();
            var result = new List<PersonaWithNombreDepartamentoDTO>();

            foreach (var p in personas)
            {
                var dep = _depRepo.getDepartamentoById(p.departamento);
                result.Add(new PersonaWithNombreDepartamentoDTO(
                    p.id,
                    p.nombre,
                    p.apellidos,
                    p.direccion,
                    p.telefono,
                    p.foto,
                    p.fechaNac,
                    dep?.nombre ?? ""
                ));
            }

            return result;
        }

        public PersonaWithNombreDepartamentoDTO getDetallesPersona(int id)
        {
            var p = _peopleRepo.getPersonaById(id);
            if (p == null) return null;

            var dep = _depRepo.getDepartamentoById(p.departamento);

            return new PersonaWithNombreDepartamentoDTO(
                p.id,
                p.nombre,
                p.apellidos,
                p.direccion,
                p.telefono,
                p.foto,
                p.fechaNac,
                dep?.nombre ?? ""
            );
        }

        public PersonaWithListaDepartamentosDTO getPersonaFormulario()
        {
            var listaDep = _depRepo.getDepartamentos()?.ToArray() ?? new Departamento[0];

            return new PersonaWithListaDepartamentosDTO(
                0, "", "", "", "", "", DateTime.MinValue, 0, listaDep
            );
        }

        public PersonaWithListaDepartamentosDTO getPersonaFormulario(int id)
        {
            var p = _peopleRepo.getPersonaById(id);
            var listaDep = _depRepo.getDepartamentos()?.ToArray() ?? new Departamento[0];

            if (p == null)
                return new PersonaWithListaDepartamentosDTO(0, "", "", "", "", "", DateTime.MinValue, 0, listaDep);

            return new PersonaWithListaDepartamentosDTO(
                p.id,
                p.nombre,
                p.apellidos,
                p.direccion,
                p.telefono,
                p.foto,
                p.fechaNac,
                p.departamento,
                listaDep
            );
        }

        public int crearPersona(Persona persona)
        {
            if (persona == null) throw new ArgumentNullException(nameof(persona));
            if (string.IsNullOrWhiteSpace(persona.nombre)) throw new ArgumentException("Nombre requerido");
            return _peopleRepo.crearPersona(persona);
        }

        public int actualizarPersona(int id, Persona persona)
        {
            if (persona == null) throw new ArgumentNullException(nameof(persona));
            var existing = _peopleRepo.getPersonaById(id);
            if (existing == null) return 0;
            return _peopleRepo.actualizarPersona(id, persona);
        }

        public int eliminarPersona(int id)
        {
            var existing = _peopleRepo.getPersonaById(id);
            if (existing == null) return 0;
            return _peopleRepo.deletePersona(id);
        }
    }
}
