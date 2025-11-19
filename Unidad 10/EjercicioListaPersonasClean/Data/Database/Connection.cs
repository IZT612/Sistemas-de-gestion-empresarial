using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Database
{
    internal class Connection
    {
        public static String getConnectionString()
        {
            return "server=ivanzamora.database.windows.net;database=PersonasDB;uid=ivan_prueba;pwd=Password123456789!;trustServerCertificate = true;";
        }
    }
}
