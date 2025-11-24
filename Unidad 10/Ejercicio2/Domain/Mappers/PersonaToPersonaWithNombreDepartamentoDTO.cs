using Domain.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mappers
{
    public static class PersonaToPersonaWithNombreDepartamentoDTO
    {

        public static PersonaWithNombreDepartamentoDTO Mappers(Persona persona, List<Departamento> listaDepartamentos)
        {
            int idDepartamento = persona.departamento;
            var departamento = listaDepartamentos.Find(d => d.id == idDepartamento);

            if (departamento == null)
            {
                throw new Exception("Departamento no encontrado");
            }
            string nombreDepartamento = departamento.nombre;
            return new PersonaWithNombreDepartamentoDTO(persona.id, persona.nombre, persona.apellidos, persona.direccion, persona.telefono, persona.foto, persona.fechaNac, nombreDepartamento);
        }

    }
}
