using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Departamento
    {

        #region atributos
        private int _id;
        private string _nombre;
        #endregion

        #region getters / setters
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

        #region constructor
        public Departamento(int id, string nombre)
        {
            _id = id;
            _nombre = nombre;
        }
        #endregion

    }
}
