using Proyecto1.Models.Entities;

namespace Proyecto1.Models.DAL
{
    public class DepartamentosDAL
    {

        #region atributos
        private List<Departamento> _lista;
        #endregion

        #region getter
        public List<Departamento> lista
            {
            get { return _lista; }
        }
        #endregion

        #region constructor
        public DepartamentosDAL(List<Departamento> lista)
        {
            this._lista = lista;
        }
        #endregion

    }
}
