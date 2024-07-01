using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAdvancedNew.DataAccess.Tests.Utilities
{    
    /// <summary>
    /// Provedor de cadena de conexion
    /// </summary>
    public static class ConnectionStringProvider
    {
        public static string GetConnectionString() => "Data Source= Data.sqlite";
    }
}
