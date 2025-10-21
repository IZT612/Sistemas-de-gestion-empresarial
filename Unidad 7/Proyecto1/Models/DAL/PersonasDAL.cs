using Proyecto1.Models.Entities;

namespace Proyecto1.Models.DAL
{
    public class PersonasDAL
    {

        #region Atributos
        private List<Persona> _lista;
        #endregion

        #region getter
        public List<Persona> lista
        {
            get { return _lista; }
        }
        #endregion

        #region constructor
        public PersonasDAL(List<Departamento> departamentos) 
        {

            this._lista = new List<Persona>
            {
                new Persona(1, "Iván",  "Zamora Torres", 18, departamentos[4]),
                new Persona(2, "María", "García López", 25, departamentos[3]),
                new Persona(3, "Carlos", "Sánchez Pérez", 30, departamentos[2]),
                new Persona(4, "Ana", "Fernández Gómez", 22, departamentos[1]),
                new Persona(5, "Luis", "Rodríguez Díaz", 28, departamentos[0])
            };

        }
        #endregion

        #region funciones

        #endregion
    }
}
