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
        public PersonasDAL(List<Persona> lista) 
        {

            this._lista = lista;

        }
        #endregion

        #region funciones

        #endregion
    }
}
