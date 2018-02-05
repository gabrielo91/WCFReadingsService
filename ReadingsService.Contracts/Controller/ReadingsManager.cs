using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using ReadingsService.Contracts.DAOs;
using ReadingsService.Contracts.DataBase;
using ReadingsService.Contracts.Logging;
using ReadingsService.Contracts.Models;
using ReadingsService.Contracts.Utils;

namespace ReadingsService.Contracts.Controller
{
    public class ReadingsManager : IReadingsManager
    {
        
        public string SaveIfNotExists(List<Readings> readingsList)
        {
            string processID = null;
            var readingsInserted = false;
            var generalProcessID = ProcessIdGenerator.GenerarConsecutivo();
            var processIDSaved = InsertProcessRegistry(generalProcessID);
            var processRegistryUpdated = false;

            try
            {
                IDatabaseController db = new DatabaseController();
                IDAOReadings daoReadings = new DAOReadings();

                if (processIDSaved)
                {
                    readingsInserted = daoReadings.SaveIfNotExists(readingsList, generalProcessID);

                    if (readingsInserted)
                    {
                        UpdateProcessRegistry(generalProcessID, ProcessRegistry.TRANSACCION_COMPLETA, null);
                        processRegistryUpdated = true;
                        processID = generalProcessID;
                    }

                }

            }
            catch (Exception e)
            {
                Logger.Log(e);
                throw new Exception("Error insertando el paquete de lecturas", e);
            }
            finally
            {
                if (!processRegistryUpdated)
                {
                    UpdateProcessRegistry(generalProcessID, ProcessRegistry.TRANSACCION_INCOMPLETA, "Error insertado el paquete de lecturas");
                }
            }

            return processID;
        }

        #region Private Methods
        private static void UpdateProcessRegistry(string processID, int estadoTransaccion, string mensajeError)
        {
            IDAOProcessRegistry daoProcessRegistry = new DAOProcessRegistry();
            var processRegistry = new ProcessRegistry
            {
                ProcessID = processID,
                EstadoTransaccion = estadoTransaccion,
                MensajeError = mensajeError
            };
            daoProcessRegistry.UpdateProcessRegistry(processRegistry);
        }
        

        private static bool InsertProcessRegistry(string generalProcessID)
        {
            var resultado = false;
            IDAOProcessRegistry daoProcessRegistry = new DAOProcessRegistry();
            var processRegistry = new ProcessRegistry
            {
                ProcessID = generalProcessID,
                EstadoTransaccion = ProcessRegistry.TRANSACCION_INCOMPLETA
            };
            resultado = daoProcessRegistry.InsertProcessRegistry(processRegistry);
            return resultado;
        }

        #endregion  
    }
}
