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
    public class DepartamentoRepositoryAzure : IDepartamentoRepository
    {

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