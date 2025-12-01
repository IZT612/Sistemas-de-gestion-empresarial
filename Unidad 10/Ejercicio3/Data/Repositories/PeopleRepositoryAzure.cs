using Data.Database;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace Data.Repositories
{
    public class PeopleRepositoryAzure : IPeopleRepository
    {
        public List<Persona> getPersonas()
        {
            List<Persona> listaPersonas = new List<Persona>();

            using (SqlConnection conexion = new SqlConnection(Connection.getConnectionString()))
            using (SqlCommand comando = new SqlCommand("SELECT * FROM Personas", conexion))
            {
                try
                {
                    conexion.Open();
                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            var persona = new Persona(
                                (int)lector["ID"],
                                (string)lector["Nombre"],
                                (string)lector["Apellidos"],
                                (string)lector["Direccion"],
                                (string)lector["Telefono"],
                                (string)lector["Foto"],
                                (int)lector["IDDepartamento"]
                            );

                            if (lector["FechaNacimiento"] != DBNull.Value)
                                persona.fechaNac = (DateTime)lector["FechaNacimiento"];

                            listaPersonas.Add(persona);
                        }
                    }
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
            }

            return listaPersonas;
        }

        public Persona getPersonaById(int id)
        {
            Persona persona = null;

            using (SqlConnection conexion = new SqlConnection(Connection.getConnectionString()))
            using (SqlCommand comando = new SqlCommand("SELECT * FROM Personas WHERE ID=@id", conexion))
            {
                comando.Parameters.AddWithValue("@id", id);

                try
                {
                    conexion.Open();
                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        if (lector.Read())
                        {
                            persona = new Persona(
                                (int)lector["ID"],
                                (string)lector["Nombre"],
                                (string)lector["Apellidos"],
                                (string)lector["Direccion"],
                                (string)lector["Telefono"],
                                (string)lector["Foto"],
                                (int)lector["IDDepartamento"]
                            );

                            if (lector["FechaNacimiento"] != DBNull.Value)
                                persona.fechaNac = (DateTime)lector["FechaNacimiento"];
                        }
                    }
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
            }

            return persona;
        }

        public int crearPersona(Persona personaNueva)
        {
            using (SqlConnection conexion = new SqlConnection(Connection.getConnectionString()))
            using (SqlCommand comando = new SqlCommand(
                "INSERT INTO Personas (Nombre, Apellidos, Direccion, Telefono, Foto, IDDepartamento, FechaNacimiento) " +
                "VALUES (@nombre, @apellidos, @direccion, @telefono, @foto, @departamento, @fechaNac)", conexion))
            {
                comando.Parameters.AddWithValue("@nombre", personaNueva.nombre);
                comando.Parameters.AddWithValue("@apellidos", personaNueva.apellidos);
                comando.Parameters.AddWithValue("@direccion", personaNueva.direccion);
                comando.Parameters.AddWithValue("@telefono", personaNueva.telefono);
                comando.Parameters.AddWithValue("@foto", personaNueva.foto);
                comando.Parameters.AddWithValue("@departamento", personaNueva.departamento);
                comando.Parameters.AddWithValue("@fechaNac", (object)personaNueva.fechaNac ?? DBNull.Value);

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

        public int actualizarPersona(int idPersona, Persona personaActualizada)
        {
            using (SqlConnection conexion = new SqlConnection(Connection.getConnectionString()))
            using (SqlCommand comando = new SqlCommand(
                "UPDATE Personas SET Nombre=@nombre, Apellidos=@apellidos, Direccion=@direccion, Telefono=@telefono, Foto=@foto, IDDepartamento=@departamento, FechaNacimiento=@fechaNac " +
                "WHERE ID=@id", conexion))
            {
                comando.Parameters.AddWithValue("@nombre", personaActualizada.nombre);
                comando.Parameters.AddWithValue("@apellidos", personaActualizada.apellidos);
                comando.Parameters.AddWithValue("@direccion", personaActualizada.direccion);
                comando.Parameters.AddWithValue("@telefono", personaActualizada.telefono);
                comando.Parameters.AddWithValue("@foto", personaActualizada.foto);
                comando.Parameters.AddWithValue("@departamento", personaActualizada.departamento);
                comando.Parameters.AddWithValue("@fechaNac", (object)personaActualizada.fechaNac ?? DBNull.Value);
                comando.Parameters.AddWithValue("@id", idPersona);

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

        public int deletePersona(int id)
        {
            using (SqlConnection conexion = new SqlConnection(Connection.getConnectionString()))
            using (SqlCommand comando = new SqlCommand("DELETE FROM Personas WHERE ID=@id", conexion))
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
