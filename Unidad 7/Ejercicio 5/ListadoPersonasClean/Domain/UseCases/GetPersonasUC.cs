using Domain.Interfaces;
using Domain.Entities;

namespace Domain.UseCases
{
    public class GetPersonasUseCase
    {

        private IPersonasRepo _personaRepository;

        public GetPersonasUseCase(IPersonasRepo personaRepository)
        {
            _personaRepository = personaRepository;
        }

        public List<Persona> GetPersonas()
        {
            return _personaRepository.GetPersonas();
        }
    }
}
