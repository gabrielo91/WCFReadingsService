using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client; 
using Oracle.ManagedDataAccess.Types;

namespace ReadingsService.Contracts.DataBase
{
    public class DatabaseController : IDatabaseController
    {
        private OracleConnection connection { get; set; }

        public OracleConnection GetConnection()
        {
            if (connection == null) {
                var connStrig = Properties.Settings.Default.METROLINK_DB_CONEXION;
                connection = new OracleConnection(connStrig);
            }
            return connection;
        }
    }
}
