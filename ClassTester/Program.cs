using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReadingsService.Contracts.Controller;
using ReadingsService.Contracts.Configuration;
using ReadingsService.Contracts.Logging;
using ReadingsService.Contracts.DataBase;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace ClassTester
{
    class Program
    {
        static void Main(string[] args)
        {

            IPreferencesManager preferencesManager = new PreferencesManager(@"D:\DesarrolloReadingsService\Recursos\config.json");

            try
            {
                Console.WriteLine("Empezando");
                IDatabaseController db = new DatabaseController();
                var conn = db.GetConnection();
                Console.WriteLine("la conexion es: "+ conn);

                conn.Open();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from m_proveedores";
                cmd.CommandType = CommandType.Text;
                OracleDataReader dr = cmd.ExecuteReader();
                dr.Read();
                Console.WriteLine("el dato es: " + dr);
                conn.Dispose();

                Console.ReadLine();



            }
            catch (Exception e)
            {
                Console.WriteLine("estamos en exception");
                Console.ReadLine();
                Logger.Log(e);
            }

        }
    }
}
