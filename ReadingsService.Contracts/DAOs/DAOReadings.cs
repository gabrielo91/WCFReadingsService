using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using ReadingsService.Contracts.DataBase;
using ReadingsService.Contracts.Logging;
using ReadingsService.Contracts.Models;
using ReadingsService.Contracts.Utils;

namespace ReadingsService.Contracts.DAOs
{
    public class DAOReadings : IDAOReadings
    {
        private readonly string INSERT_PROCEDURE = "insertar_lecturas";

        public bool CheckIfExist(Readings reading)
        {
            throw new NotImplementedException();
        }

        public bool Save(List<Readings> readingsList)
        {
            throw new NotImplementedException();
        }

        public bool SaveIfNotExists(List<Readings> readingsList)
        {
            var readingsInserted = false;

            try
            {
                IDatabaseController db = new DatabaseController();

                using (OracleConnection conn = db.GetConnection())
                {
                    conn.Open();

                    //Create command and set values
                    var command = new OracleCommand();
                    command.Connection = conn;
                    command.CommandText = INSERT_PROCEDURE;
                    command.CommandType = CommandType.StoredProcedure;


                    foreach (Readings reading in readingsList)
                    {

                    }

                    readingsInserted = true;
                }

            }
            catch (Exception e)
            {
                Logger.Log(e);
                throw new Exception("Error insertando el paquete de lecturas", e);
            }



            return readingsInserted;
        }


        
 
    }
}
