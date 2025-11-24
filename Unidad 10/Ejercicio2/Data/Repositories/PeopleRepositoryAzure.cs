using Data.Database;
using Domain.Entities;
using Microsoft.Data.SqlClient;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Data.Repositories
{
    internal class PeopleRepositoryAzure: IPeopleRepository
    {

        public Persona[] getListaPersonas()
        {

            SqlConnection conexion = new SqlConnection();
            List<Persona> listaPersonas = new List<Persona>();
            SqlDataReader lector = null;
            SqlCommand comando = new SqlCommand();
            Persona oPersona = null;

            conexion.ConnectionString = Connection.getConnectionString();

            try
            {
                conexion.Open();

                comando.CommandText = "SELECT * FROM Personas";
                comando.Connection = conexion;

                lector = comando.ExecuteReader();

                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        oPersona = new Persona((int)lector["ID"], (string)lector["Nombre"], (string)lector["Apellidos"],
                            (string)lector["Direccion"], (string)lector["Telefono"], (string)lector["Foto"], (int)lector["IDDepartamento"]);

                        if (lector["FechaNacimiento"] != DBNull.Value)
                        {
                            oPersona.fechaNac = (DateTime)lector["FechaNacimiento"];
                        }

                        listaPersonas.Add(oPersona);
                    }
                }

                lector.Close();
                conexion.Close();


            } catch (SqlException eSql)
            {
                throw eSql;
            }


            return listaPersonas.ToArray();

        }

        public Departamento[] getListaDepartamentos()
        {
            SqlConnection conexion = new SqlConnection();
            List<Departamento> listaDepartamentos = new List<Departamento>();
            SqlDataReader lector = null;
            SqlCommand comando = new SqlCommand();
            Departamento oDepartamento;

            conexion.ConnectionString = Connection.getConnectionString();

            try
            {
                conexion.Open();

                comando.CommandText = "SELECT * FROM Departamentos";
                comando.Connection = conexion;

                lector = comando.ExecuteReader();

                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        oDepartamento = new Departamento((int)lector["ID"], (string)lector["Nombre"]);

                        listaDepartamentos.Add(oDepartamento);
                    }
                }

                lector.Close();
                conexion.Close();
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }

            return listaDepartamentos.ToArray();
        }


    }
}
