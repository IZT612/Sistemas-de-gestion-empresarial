namespace Proyecto1.Models.Entities
{
    public class Persona
    {
        #region atributos privados
        private int _id;
        private string _nombre;
        private string _apellidos;
        private int _edad;
        #endregion

        #region getters y setters
        public int id { get { return _id; }}
        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }

        }

        public string apellidos
        {

            get { return _apellidos; }
            set { _apellidos = value; }

        }
        public int edad
        {

            get { return _edad; }
            set { _edad = value; }
        }
        #endregion

        #region constructores
        public Persona(){}

        public Persona (int id, string nombre, string apellidos, int edad)
        {

            this._id = id;
            this._nombre = nombre;
            this._apellidos = apellidos;
            this._edad = edad;

        }
        #endregion
    }
}
