using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Repositories;
using Domain.Entities;

namespace Domain.DTO
{
	public class PersonaWithListaDepartamentosDTO
	{

		#region atributos
		private int _id;
		private string _nombre;
		private string _apellido;
		private string _direccion;
		private string _telefono;
		private string _foto;
		private DateTime? _fechaNac;
		private int _departamento;
		private Departamento[] _departamentos;

		#endregion

		#region getters / setters
		public int id { get { return _id; } set { _id = value; } }
		public string nombre
		{
			get { return _nombre; }
			set { _nombre = value; }
		}
		public string apellido
		{
			get { return _apellido; }
			set { _apellido = value; }
		}

		public string direccion
		{
			get { return _direccion; }
			set { _direccion = value; }
		}

		public string telefono
		{
			get { return _telefono; }
			set { _telefono = value; }
		}

		public string foto
		{
			get { return _foto; }
		}

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

        public List<Departamento>? departamentos
		{
			get { return _departamentos.ToList(); }
        }
		#endregion

		#region constructor
		public PersonaWithListaDepartamentosDTO(int id, string nombre, string apellido,
			   string direccion, string telefono, string foto, DateTime fechaNac, int departamento, Departamento[] departamentos)
		{
			_id = id;
			_nombre = nombre;
			_apellido = apellido;
			_direccion = direccion;
			_telefono = telefono;
			_foto = foto;
			_fechaNac = DateTime.Now;
			_departamento = departamento;
			_departamentos = departamentos;
		}

        public PersonaWithListaDepartamentosDTO(Departamento[] departamentos)
        {
            _id = 0;
            _nombre = "";
            _apellido = "";
            _direccion = "";
            _telefono = "";
            _foto = "";
            _fechaNac = DateTime.Now;
            _departamento = 0;
            _departamentos = departamentos;
        }

        public PersonaWithListaDepartamentosDTO()
        {
            _id = 0;
            _nombre = "";
            _apellido = "";
            _direccion = "";
            _telefono = "";
            _foto = "";
            _fechaNac = DateTime.Now;
            _departamento = 0;
            _departamentos = new Departamento[0];
        }
        #endregion
    }
}