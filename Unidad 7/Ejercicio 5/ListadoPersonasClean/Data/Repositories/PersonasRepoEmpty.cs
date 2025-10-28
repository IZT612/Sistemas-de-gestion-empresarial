using Domain.Entities;
using Domain.Interfaces;

namespace Data.Repositories
{
    public class PersonasRepoEmpty : IPersonasRepo
    {

        private List<Persona> listaPersonas = new List<Persona>()
        {
        };

        public List<Persona> GetPersonas()
        {
            return listaPersonas;
        }

    }
}
