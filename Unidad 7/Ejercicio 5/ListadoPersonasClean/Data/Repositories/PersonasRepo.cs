using Domain.Entities;
using Domain.Interfaces;

namespace Data.Repositories
{
    public class PersonasRepo : IPersonasRepo
    {

        private List<Persona> listaPersonas = new List<Persona>()
        {
            new Persona(1, "Juan", "Pérez", 30),
            new Persona(2, "María", "Gómez", 25),
            new Persona(3, "Luis", "Rodríguez", 40),
            new Persona(4, "Ana", "López", 35),
            new Persona(5, "Carlos", "Hernández", 28)
        };

        public List<Persona> GetPersonas()
        {
            return listaPersonas;
        }

    }
}
