using Data.Database;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace Data.Repositories
{
    public class DepartamentoRepositoryAzure : IDepartamentoRepository
    {
        public List<Departamento> getDepartamentos()
        {
            List<Departamento> listaDepartamentos = new List<Departamento>();

            using (SqlConnection conexion = new SqlConnection(Connection.getConnectionString()))
            using (SqlCommand comando = new SqlCommand("SELECT * FROM Departamentos", conexion))
            {
                try
                {
                    conexion.Open();
                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            listaDepartamentos.Add(new Departamento(
                                (int)lector["ID"],
                                (string)lector["Nombre"]
                            ));
                        }
                    }
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
            }

            return listaDepartamentos;
        }

        public Departamento getDepartamentoById(int id)
        {
            Departamento dep = null;

            using (SqlConnection conexion = new SqlConnection(Connection.getConnectionString()))
            using (SqlCommand comando = new SqlCommand("SELECT * FROM Departamentos WHERE ID=@id", conexion))
            {
                comando.Parameters.AddWithValue("@id", id);

                try
                {
                    conexion.Open();
                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        if (lector.Read())
                        {
                            dep = new Departamento(
                                (int)lector["ID"],
                                (string)lector["Nombre"]
                            );
                        }
                    }
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
            }

            return dep;
        }

        public int crearDepartamento(Departamento departamentoNuevo)
        {
            using (SqlConnection conexion = new SqlConnection(Connection.getConnectionString()))
            using (SqlCommand comando = new SqlCommand("INSERT INTO Departamentos (Nombre) VALUES (@nombre)", conexion))
            {
                comando.Parameters.AddWithValue("@nombre", departamentoNuevo.nombre);

                try
                {
                    conexion.Open();
                    return comando.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
            }
        }

        public int actualizarDepartamento(int idDepartamento, Departamento departamentoActualizado)
        {
            using (SqlConnection conexion = new SqlConnection(Connection.getConnectionString()))
            using (SqlCommand comando = new SqlCommand("UPDATE Departamentos SET Nombre=@nombre WHERE ID=@id", conexion))
            {
                comando.Parameters.AddWithValue("@nombre", departamentoActualizado.nombre);
                comando.Parameters.AddWithValue("@id", idDepartamento);

                try
                {
                    conexion.Open();
                    return comando.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
            }
        }

        public int deleteDepartamento(int id)
        {
            using (SqlConnection conexion = new SqlConnection(Connection.getConnectionString()))
            using (SqlCommand comando = new SqlCommand("DELETE FROM Departamentos WHERE ID=@id", conexion))
            {
                comando.Parameters.AddWithValue("@id", id);

                try
                {
                    conexion.Open();
                    return comando.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
            }
        }
    }
}
