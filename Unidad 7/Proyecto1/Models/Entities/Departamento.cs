namespace Proyecto1.Models.Entities
{
    public class Departamento
    {

        #region atributos
        private int _id;
        private string _nombre;
        #endregion 

        #region setter y getters
        public int id
        {
            get { return _id; }

        }

        public string nombre
        {

            get { return _nombre; }
            set { _nombre = value; }

        }
        #endregion

        #region constructores
        public Departamento(int id, string nombre)
        {

            this._id = id;
            this._nombre = nombre;

        }
        #endregion
    }
}
