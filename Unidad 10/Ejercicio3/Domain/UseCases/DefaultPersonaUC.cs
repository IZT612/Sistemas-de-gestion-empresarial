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
            List<Persona> personas = _peopleRepo.getPersonas() ?? new List<Persona>();
            List<PersonaWithNombreDepartamentoDTO> result = new List<PersonaWithNombreDepartamentoDTO>();

            foreach (Persona p in personas)
            {
                Departamento dep = _depRepo.getDepartamentoById(p.departamento);
                result.Add(new PersonaWithNombreDepartamentoDTO(
                    p.id,
                    p.nombre,
                    p.apellidos,
                    p.direccion,
                    p.telefono,
                    p.foto,
                    p.fechaNac ??= DateTime.Now,
                    dep?.nombre ?? ""
                ));
            }

            return result;
        }

        public PersonaWithNombreDepartamentoDTO getDetallesPersona(int id)
        {
            Persona p = _peopleRepo.getPersonaById(id);
            if (p == null) return null;

            Departamento dep = _depRepo.getDepartamentoById(p.departamento);

            return new PersonaWithNombreDepartamentoDTO(
                p.id,
                p.nombre,
                p.apellidos,
                p.direccion,
                p.telefono,
                p.foto,
                p.fechaNac ??= DateTime.Now,
                dep?.nombre ?? ""
            );
        }

        public PersonaWithListaDepartamentosDTO getPersonaFormulario()
        {
            Departamento[] listaDep = _depRepo.getDepartamentos()?.ToArray() ?? new Departamento[0];

            return new PersonaWithListaDepartamentosDTO(
                0, "", "", "", "", "", DateTime.MinValue, 0, listaDep
            );
        }

        public PersonaWithListaDepartamentosDTO getPersonaFormulario(int id)
        {
            Persona p = _peopleRepo.getPersonaById(id);
            Departamento[] listaDep = _depRepo.getDepartamentos()?.ToArray() ?? new Departamento[0];

            if (p == null)
                return new PersonaWithListaDepartamentosDTO(0, "", "", "", "", "", DateTime.MinValue, 0, listaDep);

            return new PersonaWithListaDepartamentosDTO(
                p.id,
                p.nombre,
                p.apellidos,
                p.direccion,
                p.telefono,
                p.foto,
                p.fechaNac ??= DateTime.Now,
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
            Persona existing = _peopleRepo.getPersonaById(id);
            if (existing == null) return 0;
            return _peopleRepo.actualizarPersona(id, persona);
        }

        public int eliminarPersona(int id)
        {
            Persona persona = _peopleRepo.getPersonaById(id);
            if (persona == null) return 0;

            if (_peopleRepo.getPersonasEnDepartamento(persona.departamento) == 0) return _peopleRepo.deletePersona(id);
            else return 0;


        }

        public Persona PersonaWithListDepartamentoDTOPasarAPersona(PersonaWithListaDepartamentosDTO dto)
        {

            Persona persona = new Persona(dto.id, dto.nombre, dto.apellido, dto.direccion, dto.telefono, dto.foto, dto.departamento);

            return persona;
        }

    }
}
