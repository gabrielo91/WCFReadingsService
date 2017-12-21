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
using ReadingsService.Contracts.DAOs;
using ReadingsService.Contracts.Models;

namespace ClassTester
{
    class Program
    {
        static void Main(string[] args)
        {

            IPreferencesManager preferencesManager = new PreferencesManager(@"D:\DesarrolloReadingsService\Recursos\config.json");
            try
            {
                Console.WriteLine("Empezando: "+ Guid.NewGuid().ToString());
                IDatabaseController db = new DatabaseController();
                ;

                var username = "gabriel";
                var password = "gabriel";

                OracleCommand cmd = new OracleCommand();
                const string sql = "select count(*) cuenta from m_proveedores where vcusername = :username and vcpassword = :password";

                var cuenta = 0;
                var resultado = false;
                using (OracleConnection conn = db.GetConnection())
                {

                    conn.Open();
                    using (var command = new OracleCommand(sql, conn))
                    {
                        using (var oracleParameter = new OracleParameter(nameof(username), username))
                        {
                            command.Parameters.Add(oracleParameter);
                        }
                        using (var oracleParameter = new OracleParameter(nameof(password), password))
                        {
                            command.Parameters.Add(oracleParameter);
                        }

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
                }

                //-----------------------------------------------------------
                Console.WriteLine("probando processregistry");
                IDAOProcessRegistry dao = new DAOProcessRegistry();
                var processRegistry = new ProcessRegistry
                {
                    ProcessID = "asdasdasdasdasd",
                    EstadoTransaccion = 1,
                    MensajeError = "hola, este es mi mensaje 3"
                };

                //dao.InsertProcessRegistry(processRegistry);
                dao.UpdateProcessRegistry(processRegistry);
                //-----------------------------------------------------------
                //ProcessRegistry dato = dao.retrieveProcessRegistryById("asdasdasdasdasd");
                List<ProcessRegistry> datos = dao.retrieveProcessListRegistryByGroupId("asdasdasdasdas");



                Console.WriteLine("el dato es: " + cuenta);

                //Testing readings insert -----------------------------------------------------------
                ReadingsManager readingsManager = new ReadingsManager();
                List<Readings> readingsList = new List<Readings>();

                Readings reading = new Readings();
                reading.CodigoProveedor = "1";
                reading.IdSuministroElectrico = "abc";
                reading.FechaLectura = new DateTime();
                reading.ConsecutivoProceso = 46;

                readingsList.Add(reading);


                readingsManager.SaveIfNotExists(readingsList);
                Console.WriteLine("Terminamos");
                //-----------------------------------------------------------------------------------



            }
            catch (Exception e)
            {
                Console.WriteLine("estamos en exception");
                Console.ReadLine();
                Logger.Log(e);
            }

            Console.ReadLine();
        }
    }
}
