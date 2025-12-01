using Domain.DTO;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IPersonaUC
    {
        public List<PersonaWithNombreDepartamentoDTO> getListaPersonasConDepartamentos();
        public PersonaWithNombreDepartamentoDTO getDetallesPersona(int id);
        public PersonaWithListaDepartamentosDTO getPersonaFormulario(); // para Create
        public PersonaWithListaDepartamentosDTO getPersonaFormulario(int id); // para Edit
        public int crearPersona(Persona persona);
        public int actualizarPersona(int id, Persona persona);
        public int eliminarPersona(int id);
    }
}