using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Persona
    {

        #region atributos
        private int _id;
        private string _nombre;
        private string _apellidos;
        private string _telefono;
        private string _direccion;
        private string _foto;
        private DateTime _fechaNac;
        private int _departamento;
        #endregion

        #region getters / setters

        public int id
        {
            set { _id = value; }
            get { return _id; }
        }

        [MaxLength(15)]
        [Required(ErrorMessage = "El campo nombre es obligatorio.")]
        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        [MaxLength(39)]
        [Required(ErrorMessage = "El campo apellidos es obligatorio.")]
        public string apellidos
        {
            get { return _apellidos; }
            set { _apellidos = value; }
        }

        [MaxLength(200)]
        public string direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }

        [RegularExpression(@"^(\+34|0034|34)?[ -]?[6789]\d{2}[ -]?\d{2}[ -]?\d{2}[ -]?\d{2}$",
            ErrorMessage = "El formato del telefono es incorrecto.")]
        [Required(ErrorMessage = "El campo telefono es obligatorio.")]
        public string telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }

        public string foto
        {
            get { return _foto; }
            set { _foto = value; }
        }

        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime? fechaNac
        {
            get { return _fechaNac; }
            set { _fechaNac = value ??= DateTime.Now; }
        }

        public int departamento
        {
            get { return _departamento; }
            set { _departamento = value; }
        }
        #endregion

        #region constructor
        public Persona(int id, string nombre, string apellidos, string direccion, string telefono, string foto, int departamento)
        {
            this._id = id;
            this._nombre = nombre;
            this._apellidos = apellidos;
            this._direccion = direccion;
            this._telefono = telefono;
            this._foto = foto;
            this._departamento = departamento;
            this._fechaNac = DateTime.Now;
        }

        public Persona()
        {
            this._id = 0;
            this._nombre = "";
            this._apellidos = "";
            this._direccion = "";
            this._telefono = "";
            this._foto = "";
            this._departamento = 0;
            this._fechaNac = DateTime.Now;
        }
        #endregion

    }
}
