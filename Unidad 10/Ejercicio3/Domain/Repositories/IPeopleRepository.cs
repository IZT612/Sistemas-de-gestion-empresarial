using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IPeopleRepository
    {
        public List<Persona> getPersonas();
        public int deletePersona(int id);
        public int crearPersona(Persona personaNueva);
        public int actualizarPersona(int idPersona, Persona personaActualizada);
        public Persona getPersonaById(int id);

    }
}
