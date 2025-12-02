using Domain.DTO;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IPersonaUC
    {
        public List<Persona> getListaPersonas();
        public List<PersonaWithNombreDepartamentoDTO> getListaPersonasConDepartamentos();
        public PersonaWithNombreDepartamentoDTO getDetallesPersona(int id);
        public PersonaWithListaDepartamentosDTO getPersonaFormulario();
        public PersonaWithListaDepartamentosDTO getPersonaFormulario(int id); 
        public int crearPersona(Persona persona);
        public int actualizarPersona(int id, Persona persona);
        public int eliminarPersona(int id);

        public Persona PersonaWithListDepartamentoDTOPasarAPersona(PersonaWithListaDepartamentosDTO dto);
    }
}