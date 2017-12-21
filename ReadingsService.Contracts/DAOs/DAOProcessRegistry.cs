using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using ReadingsService.Contracts.DataBase;
using ReadingsService.Contracts.Logging;
using ReadingsService.Contracts.Models;

namespace ReadingsService.Contracts.DAOs
{
    public class DAOProcessRegistry : IDAOProcessRegistry
    {
        private readonly string CAMPO_PROCESS_ID_INDIVIDUAL = "VCPROCESS_ID";
        private readonly string CAMPO_ID_LECTURA = "ID_LECTURA";
        private readonly string CAMPO_FECHA = "FECHA";
        private readonly string CAMPO_ESTADO_TRANSACCION = "VCESTADO_TRANSACCION";
        private readonly string CAMPO_MENSAJE_ERROR = "VCMENSAJE_ERROR";
        private readonly string CAMPO_PROCESS_ID_PADRE = "VCPROCESS_ID_PADRE";

        public bool InsertProcessRegistry(ProcessRegistry processRegistry)
        {
            var resultado = false;

            try
            {
                IDatabaseController db = new DatabaseController();
                const string sql = "INSERT INTO MOV_PROCESS_REGISTRY (VCPROCESS_ID, " +
                    "VCESTADO_TRANSACCION )" +
                    "VALUES (:processID, :estadoTransaccion) ";

                using (OracleConnection conn = db.GetConnection())
                {
                    conn.Open();

                    using (var command = new OracleCommand(sql, conn))
                    {
                        command.Parameters.Add(new OracleParameter("processID", processRegistry.ProcessID));
                        command.Parameters.Add(new OracleParameter("estadoTransaccion", processRegistry.EstadoTransaccion));
                        command.ExecuteNonQuery();
                        resultado = true;

                    }

                }
            }
            catch (Exception e)
            {
                Logger.Log(e);
                throw new Exception("Error insertando el registro del proceso", e);
            }

            return resultado;
        }

        public bool UpdateProcessRegistry(ProcessRegistry processRegistry)
        {
            var resultado = false;
            
            try
            {
                IDatabaseController db = new DatabaseController();
                const string sql = "UPDATE MOV_PROCESS_REGISTRY SET " +
                    "VCESTADO_TRANSACCION = :estadoTransaccion, " +
                    "VCMENSAJE_ERROR = :mensajeError " +
                    "WHERE VCPROCESS_ID = :processID";

                using (OracleConnection conn = db.GetConnection())
                {
                    conn.Open();

                    using (var command = new OracleCommand(sql, conn))
                    {                        
                        command.Parameters.Add(new OracleParameter("estadoTransaccion", processRegistry.EstadoTransaccion));
                        command.Parameters.Add(new OracleParameter("mensajeError", processRegistry.MensajeError));
                        command.Parameters.Add(new OracleParameter("processID", processRegistry.ProcessID));
                        command.ExecuteNonQuery();
                        resultado = true;

                    }

                }
            }
            catch (Exception e)
            {
                Logger.Log(e);
                throw new Exception("Error actualizando el registro del proceso", e);
            }

            return resultado;
        }

        public List<ProcessRegistry> retrieveProcessListRegistryByGroupId(string generalProcessId)
        {
            var processRegistryList = new List<ProcessRegistry>();
            ProcessRegistry processRegistry;
            IDatabaseController db = new DatabaseController();
            const string sql = "SELECT * FROM MOV_PROCESS_REGISTRY WHERE VCPROCESS_ID_PADRE = :processID";
            OracleDataReader reader;

            try
            {
                using (OracleConnection conn = db.GetConnection())
                {
                    conn.Open();

                    using (OracleCommand command = new OracleCommand(sql, conn))
                    {
                        command.Parameters.Add(new OracleParameter("processID", generalProcessId));
                        reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                processRegistry = convertSQLResultToObject(reader);
                                processRegistryList.Add(processRegistry);
                            }
                        }
                    }

                }

            }
            catch (Exception e)
            {
                Logger.Log(e);
                throw new Exception(string.Format("Error consultado los subregistros del proceso {0}", generalProcessId), e);
            }

            return processRegistryList;
        }

        public ProcessRegistry retrieveProcessRegistryById(string processId)
        {
            ProcessRegistry processRegistry = null;
            IDatabaseController db = new DatabaseController();
            const string sql = "SELECT * FROM MOV_PROCESS_REGISTRY WHERE VCPROCESS_ID = :processID";
            OracleDataReader reader;

            try
            {
                using(OracleConnection conn = db.GetConnection()) {
                    conn.Open();

                    using (OracleCommand command = new OracleCommand(sql, conn))
                    {
                        command.Parameters.Add(new OracleParameter("processID", processId));
                        reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                processRegistry = convertSQLResultToObject(reader);
                            }
                        }
                    }

                }

            }
            catch (Exception e)
            {
                Logger.Log(e);
                throw new Exception(string.Format("Error consultado el registro de proceso {0}", processId), e);
            }
            
            return processRegistry;
        }



        #region Private methods
        private ProcessRegistry convertSQLResultToObject(OracleDataReader reader)
        {
            var processRegistry = new ProcessRegistry();
            if (reader[CAMPO_PROCESS_ID_INDIVIDUAL] != DBNull.Value)
            {
                processRegistry.IndividualRegistryId = Convert.ToString(reader[CAMPO_PROCESS_ID_INDIVIDUAL]);
            }

            if (reader[CAMPO_ID_LECTURA] != DBNull.Value)
            {
                processRegistry.IDLectura = Convert.ToInt64(reader[CAMPO_ID_LECTURA]);
            }

            if (reader[CAMPO_PROCESS_ID_PADRE] != DBNull.Value)
            {
                processRegistry.ProcessID = Convert.ToString(reader[CAMPO_PROCESS_ID_PADRE]);
            }

            if (reader[CAMPO_FECHA] != DBNull.Value)
            {
                processRegistry.Fecha = Convert.ToDateTime(reader[CAMPO_FECHA]);
            }

            if (reader[CAMPO_ESTADO_TRANSACCION] != DBNull.Value)
            {
                processRegistry.EstadoTransaccion = Convert.ToByte(reader[CAMPO_ESTADO_TRANSACCION]);
            }

            if (reader[CAMPO_MENSAJE_ERROR] != DBNull.Value)
            {
                processRegistry.MensajeError = Convert.ToString(reader[CAMPO_MENSAJE_ERROR]);
            }

            return processRegistry;
        }
        #endregion

    }
}
