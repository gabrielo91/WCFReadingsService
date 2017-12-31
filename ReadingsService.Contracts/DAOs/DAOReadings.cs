using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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
        public readonly string DATES_FORMAT = "yyyy-MM-dd HH:mm:ss";
        private readonly string INSERT_PROCEDURE = "insertar_lecturas";

        public bool CheckIfExist(Readings reading)
        {
            throw new NotImplementedException();
        }

        public bool Save(List<Readings> readingsList)
        {
            throw new NotImplementedException();
        }

        public bool SaveIfNotExists(List<Readings> readingsList, string processID)
        {
            var readingsInserted = false;
            OracleDataReader reader = null;

            try
            {
                IDatabaseController db = new DatabaseController();

                using (OracleConnection conn = db.GetConnection())
                {
                    conn.Open();

                    //Create command and set properties
                    using (var command = new OracleCommand
                    {
                        Connection = conn,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = INSERT_PROCEDURE

                    })
                    {
                        {
                            foreach (Readings reading in readingsList)
                            {
                                command.Parameters.Clear();
                                var parameters = setReadingParameters(reading, processID);
                                foreach (var eachParamenter in parameters)
                                {
                                    command.Parameters.Add(eachParamenter);
                                }
                                                               
                                reader = command.ExecuteReader();

                            }

                            readingsInserted = true;
                        }
                    }
                }

            }
            catch (Exception e)
            {
                Logger.Log(e);
                throw new Exception("Error insertando el paquete de lecturas", e);

            }

            return readingsInserted;
        }

        #region Private Methods
        private List<OracleParameter> setReadingParameters(Readings reading, string processID)
        {
            var oracleParameterCollection = new List<OracleParameter>();

            var in_ncod_prov = new OracleParameter();
            in_ncod_prov.ParameterName = nameof(in_ncod_prov);
            in_ncod_prov.OracleDbType = OracleDbType.Int32;
            in_ncod_prov.Direction = ParameterDirection.Input;
            in_ncod_prov.Value = reading.CodigoProveedor;
            oracleParameterCollection.Add(in_ncod_prov);

            var in_nnis_rad = new OracleParameter();
            in_nnis_rad.ParameterName = nameof(in_nnis_rad);
            in_nnis_rad.OracleDbType = OracleDbType.NVarchar2;
            in_nnis_rad.Direction = ParameterDirection.Input;
            in_nnis_rad.Value = reading.IdSuministroElectrico;
            oracleParameterCollection.Add(in_nnis_rad);
            
            var in_tsfecha_lec = new OracleParameter();
            in_tsfecha_lec.ParameterName = nameof(in_tsfecha_lec);
            in_tsfecha_lec.OracleDbType = OracleDbType.Date;
            in_tsfecha_lec.Direction = ParameterDirection.Input;
            in_tsfecha_lec.Value = datesFormatter(reading.FechaLectura);
            oracleParameterCollection.Add(in_tsfecha_lec);

            var in_vcnum_med = new OracleParameter();
            in_vcnum_med.ParameterName = nameof(in_vcnum_med);
            in_vcnum_med.OracleDbType = OracleDbType.NVarchar2;
            in_vcnum_med.Direction = ParameterDirection.Input;
            in_vcnum_med.Value = reading.NumeroMedidor;
            oracleParameterCollection.Add(in_vcnum_med);
                        
            var in_vctipo_med = new OracleParameter();
            in_vctipo_med.ParameterName = nameof(in_vctipo_med);
            in_vctipo_med.OracleDbType = OracleDbType.NVarchar2;
            in_vctipo_med.Direction = ParameterDirection.Input;
            in_vctipo_med.Value = reading.TipoMedidor;
            oracleParameterCollection.Add(in_vctipo_med);

            var in_vctipo_lec = new OracleParameter();
            in_vctipo_lec.ParameterName = nameof(in_vctipo_lec);
            in_vctipo_lec.OracleDbType = OracleDbType.NVarchar2;
            in_vctipo_lec.Direction = ParameterDirection.Input;
            in_vctipo_lec.Value = reading.TipoLectura;
            oracleParameterCollection.Add(in_vctipo_lec);

            var in_vccodmarca = new OracleParameter();
            in_vccodmarca.ParameterName = nameof(in_vccodmarca);
            in_vccodmarca.OracleDbType = OracleDbType.NVarchar2;
            in_vccodmarca.Direction = ParameterDirection.Input;
            in_vccodmarca.Value = reading.CodigoMarcaMedidor;
            oracleParameterCollection.Add(in_vccodmarca);
   
            var in_nlectura = new OracleParameter();
            in_nlectura.ParameterName = nameof(in_nlectura);
            in_nlectura.OracleDbType = OracleDbType.Int32;
            in_nlectura.Direction = ParameterDirection.Input;
            in_nlectura.Value = reading.Lectura;
            oracleParameterCollection.Add(in_nlectura);

            var in_nconsumo_ori = new OracleParameter();
            in_nconsumo_ori.ParameterName = nameof(in_nconsumo_ori);
            in_nconsumo_ori.OracleDbType = OracleDbType.Int32;
            in_nconsumo_ori.Direction = ParameterDirection.Input;
            in_nconsumo_ori.Value = reading.ConsumoOriginal;
            oracleParameterCollection.Add(in_nconsumo_ori);
            
            var in_nconsumo_mod = new OracleParameter();
            in_nconsumo_mod.ParameterName = nameof(in_nconsumo_mod);
            in_nconsumo_mod.OracleDbType = OracleDbType.Int32;
            in_nconsumo_mod.Direction = ParameterDirection.Input;
            in_nconsumo_mod.Value = reading.ConsumoModificado;
            oracleParameterCollection.Add(in_nconsumo_mod);
            
            var in_lbloqueado = new OracleParameter();
            in_lbloqueado.ParameterName = nameof(in_lbloqueado);
            in_lbloqueado.OracleDbType = OracleDbType.Int16;
            in_lbloqueado.Direction = ParameterDirection.Input;
            in_lbloqueado.Value = reading.ConsumoBloqueado;
            oracleParameterCollection.Add(in_lbloqueado);
            
            var in_lenviado = new OracleParameter();
            in_lenviado.ParameterName = nameof(in_lenviado);
            in_lenviado.OracleDbType = OracleDbType.Int16;
            in_lenviado.Direction = ParameterDirection.Input;
            in_lenviado.Value = reading.Enviado;
            oracleParameterCollection.Add(in_lenviado);

            var in_vccoduser = new OracleParameter();
            in_vccoduser.ParameterName = nameof(in_vccoduser);
            in_vccoduser.OracleDbType = OracleDbType.NVarchar2;
            in_vccoduser.Direction = ParameterDirection.Input;
            in_vccoduser.Value = reading.CodigoUsuario;
            oracleParameterCollection.Add(in_vccoduser);

            var in_vcprograma = new OracleParameter();
            in_vcprograma.ParameterName = nameof(in_vcprograma);
            in_vcprograma.OracleDbType = OracleDbType.NVarchar2;
            in_vcprograma.Direction = ParameterDirection.Input;
            in_vcprograma.Value = reading.Programa;
            oracleParameterCollection.Add(in_vcprograma);

            var in_lgen_alarma = new OracleParameter();
            in_lgen_alarma.ParameterName = nameof(in_lgen_alarma);
            in_lgen_alarma.OracleDbType = OracleDbType.Int16;
            in_lgen_alarma.Direction = ParameterDirection.Input;
            in_lgen_alarma.Value = reading.GeneroAlarma;
            oracleParameterCollection.Add(in_lgen_alarma);
            
            var in_lcertificada = new OracleParameter();
            in_lcertificada.ParameterName = nameof(in_lcertificada);
            in_lcertificada.OracleDbType = OracleDbType.Int16;
            in_lcertificada.Direction = ParameterDirection.Input;
            in_lcertificada.Value = reading.Certificada;
            oracleParameterCollection.Add(in_lcertificada);
            
            var in_ncons_proceso = new OracleParameter();
            in_ncons_proceso.ParameterName = nameof(in_ncons_proceso);
            in_ncons_proceso.OracleDbType = OracleDbType.Int32;
            in_ncons_proceso.Direction = ParameterDirection.Input;
            in_ncons_proceso.Value = reading.ConsecutivoProceso;
            oracleParameterCollection.Add(in_ncons_proceso);
            
            var in_vcprocess_id = new OracleParameter(); //ID del proceso padre
            in_vcprocess_id.ParameterName = nameof(in_vcprocess_id);
            in_vcprocess_id.OracleDbType = OracleDbType.NVarchar2;
            in_vcprocess_id.Direction = ParameterDirection.Input;
            in_vcprocess_id.Value = processID;
            oracleParameterCollection.Add(in_vcprocess_id);

            var out_nresultado_proceso = new OracleParameter();
            out_nresultado_proceso.ParameterName = nameof(out_nresultado_proceso);
            out_nresultado_proceso.OracleDbType = OracleDbType.Int16;
            out_nresultado_proceso.Direction = ParameterDirection.Output;
            oracleParameterCollection.Add(out_nresultado_proceso);

            var out_vcmensaje_tecnico = new OracleParameter();
            out_vcmensaje_tecnico.ParameterName = nameof(out_vcmensaje_tecnico);
            out_vcmensaje_tecnico.OracleDbType = OracleDbType.NVarchar2;
            out_vcmensaje_tecnico.Direction = ParameterDirection.Input;
            out_vcmensaje_tecnico.Value = reading.CodigoProveedor;
            oracleParameterCollection.Add(out_vcmensaje_tecnico);

            return oracleParameterCollection;
        }

        private DateTime datesFormatter(string fechaLectura)
        {
            DateTime dateTime;
            try
            {
                dateTime = DateTime.ParseExact(fechaLectura, DATES_FORMAT, new CultureInfo("en-US"));
            }
            catch (Exception e)
            {                
                throw new Exception("Invalid input date format, it must be YYYY-MM-DD HH24:MI:SS", e);
            }
            
            return dateTime;
        }
        #endregion

    }
}
