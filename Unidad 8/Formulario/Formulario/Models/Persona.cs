using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Persona
    {

        private int _id;
        private string _nombre;
        private string _apellidos;
        private int _edad;

        public Persona(int id, string nombre, string apellidos, int edad)
        {
            this._id = id;
            this._nombre = nombre;
            this._apellidos = apellidos;
            this._edad = edad;
        }

        public int Id
        {
            get { return _id; }
        }

        public string Nombre
        {

            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Apellidos
        {

            get { return _apellidos; }
            set { _apellidos = value; }
        }

        public int Edad
        {
            get { return _edad; }
            set { _edad = value; }
        }

    }
}
