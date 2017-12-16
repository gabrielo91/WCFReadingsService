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
                ;

                var username = "gabriel";
               
                OracleCommand cmd = new OracleCommand();
                var conn = db.GetConnection();
                //cmd.CommandText ="select count(*) from m_proveedores where vcusername = :username and vcpassword = :password";ç
                var sql = "select count(*) cuenta from m_proveedores where vcusername = :username and vcpassword = :password";
                //cmd.CommandType = CommandType.Text;


                //OracleDataReader reader = cmd.ExecuteReader();

                var cuenta = 0;
                var resultado = false;
                using (conn)
                {

                    conn.Open();
                    var command = new OracleCommand(sql, conn);
                    command.Parameters.Add(new OracleParameter(@"userame", username));
                    command.Parameters.Add(new OracleParameter(@"password", username));

                    OracleDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        cuenta = Convert.ToInt32(reader["cuenta"]);
                    }

                    if (cuenta > 0)
                    {
                        resultado = true;
                        Console.WriteLine("HAY DATOS");
                    }
                }



                Console.WriteLine("el dato es: " + cuenta);
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
