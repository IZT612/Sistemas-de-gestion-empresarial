using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;


namespace Data.Repositories
{
    internal class PeopleRepositoryAzure
    {

        public Persona[] getListaPersonas()
        {

            SqlConnection miConexion = new SqlConnection();
            List<Persona> listadoPersonas = new List<Persona>();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector = null;






        }
        

        

    }
}
