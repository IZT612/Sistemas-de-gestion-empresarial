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
        public DepartamentosDAL()
        {
            this._lista = new List<Departamento>
            {
                new Departamento(1, "Recursos Humanos"),
                new Departamento(2, "Desarrollo"),
                new Departamento(3, "Marketing"),
                new Departamento(4, "Ventas"),
                new Departamento(5, "Atención al Cliente")
            };
        }
        #endregion

    }
}
