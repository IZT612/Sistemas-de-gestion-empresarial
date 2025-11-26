using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Repositories;
using Domain.Entities

namespace Domain.DTO
{
	public class PersonaWithListaDepartamentosDTO
	{
		// TESTEAR FORMA DE HACER ESTO SIN INYECTAR EL REPOSITORIO EN EL CONSTRUCTOR
		private readonly IDepartamentoRepository _departamentoRepository;

		private Departamento[] listaDeps = _departamentoRepository.getListaDepartamentos;

		/*

		#region atributos
		private int _id;
		private string _nombre;
		private string _apellido;
		private string _direccion;
		private string _telefono;
		private string _foto;
		private DateTime _fechaNac;
		private Departamento[] _listaDepartamento;

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

		public DateTime fechaNac
		{
			get { return _fechaNac; }
			set { _fechaNac = value; }
		}

		public string nombreDepartamento
		{
			get { return _nombreDepartamento; }
			set { _nombreDepartamento = value; }
		}
		#endregion

		#region constructor
		public PersonaWithListaDepartamentosDTO(int id, string nombre, string apellido,
			   string direccion, string telefono, string foto, DateTime fechaNac, string nombreDepartamento)
		{
			_id = id;
			_nombre = nombre;
			_apellido = apellido;
			_direccion = direccion;
			_telefono = telefono;
			_foto = foto;
			_fechaNac = fechaNac;
			_nombreDepartamento = nombreDepartamento;
		}
		#endregion
		*/
	}
}