using Proyecto1.Models.DAL;
using Proyecto1.Models.Entities;

namespace Proyecto1.Models.ViewModels
{
    public class FormularioVM
    {
        #region atributos privados
        private Persona _persona;
        private DepartamentosDAL _listaDepartamentos;
        #endregion

        #region getters
        public Persona persona
        {

            get { return _persona; }

        }

        public DepartamentosDAL listaDepartamentos
        {

            get { return _listaDepartamentos; }

        }
        #endregion

        #region constructor
        public FormularioVM(Persona persona, DepartamentosDAL listaDepartamentos)
        {

            this._persona = persona;
            this._listaDepartamentos = listaDepartamentos;

        }
        #endregion
    }
}
