namespace Proyecto1.Models.Entities
{
    public class Persona
    {
        #region atributos privados
        private int _id;
        private string _nombre;
        private string _apellidos;
        private int _edad;
        private Departamento _departamento;
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

        public Departamento departamento
        {
            get { return _departamento; }
            set { _departamento = value; }
        }
        #endregion

        #region constructores
        public Persona(){}

        public Persona (int id, string nombre, string apellidos, int edad, Departamento departamento)
        {

            this._id = id;
            this._nombre = nombre;
            this._apellidos = apellidos;
            this._edad = edad;
            this._departamento = departamento;
        }
        #endregion
    }
}
