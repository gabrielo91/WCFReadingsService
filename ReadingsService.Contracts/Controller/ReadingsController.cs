using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReadingsService.Contracts.Models;
using ReadingsService.Contracts.DAOs;
using ReadingsService.Contracts.Logging;

namespace ReadingsService.Contracts.Controller
{
    public class ReadingsController
    {
        public readonly static string MENSAJE_USUARIO_INVALIDO = "Las crédenciales para el reporte de lecturas son inválidas";
        public readonly static string MENSAJE_ERROR_TECNICO = "Se presentó un error ejecutando la operación";
        public readonly static string MENSAJE_ERROR_REGISTRO_NO_ENCONTRAD = "No se encontraron registros con el id de proceso ingresado";
        public readonly static string FLAG_SUCCES = "Success";
        public readonly static string FLAG_WARNING = "Warning";
        public readonly static string FLAG_ERROR = "Error";


        public static ProcessRequestResultResponse SaveReadings(ReportReadingsRequest reportReadings)
        {
            var processRequestResultResponse = new ProcessRequestResultResponse();

            try
            {
                IDAOProveedores daoProveedores = new DAOProveedores();
                IDAOReadings daoReadings = new DAOReadings();
                string processID = null;

                var userIsValid = daoProveedores.ValidateProveedor(reportReadings.Authentication.UserName, reportReadings.Authentication.Password);

                if (userIsValid)
                {
                    try
                    {
                        processID = daoReadings.SaveIfNotExists(reportReadings.Readings);
                        processRequestResultResponse.ProcessID = processID;
                        processRequestResultResponse.ProcessAccepted = true;

                    }
                    catch (Exception e)
                    {
                        processRequestResultResponse.ErrorMessage = MENSAJE_ERROR_TECNICO;
                        Logger.Log(e);
                    }

                }
                else
                {
                    processRequestResultResponse.ErrorMessage = MENSAJE_USUARIO_INVALIDO;
                    processRequestResultResponse.ProcessAccepted = false;
                }
            }
            catch (Exception e)
            {
                Logger.Log(e);
            }
            
            

            return processRequestResultResponse;

        }
        

        public static ReportReadingsProcessResultResponse GetProcessResult(ReportReadingsProcessResultRequest reportReadingsProcessResultRequest)
        {
            var reportReadingsProcessResultResponse = new ReportReadingsProcessResultResponse();

            try
            {
                IDAOProcessRegistry daoProcessRegistry = new DAOProcessRegistry();
                IDAOProveedores daoProveedores = new DAOProveedores();
                var userIsValid = daoProveedores.ValidateProveedor(reportReadingsProcessResultRequest.Authentication.UserName, reportReadingsProcessResultRequest.Authentication.Password);
                List<ProcessRegistry> listaRegistrosProceso = null;

                if (userIsValid)
                {
                    var processID = reportReadingsProcessResultRequest.ProcessID;
                    var generalProcessRegistry = daoProcessRegistry.retrieveProcessRegistryById(processID);

                    if (null != generalProcessRegistry)
                    {
                        reportReadingsProcessResultResponse.ProcessDone = true;
                        reportReadingsProcessResultResponse.ResultFlag = FLAG_SUCCES;
                        listaRegistrosProceso = daoProcessRegistry.retrieveProcessListRegistryByGroupId(processID);
                        reportReadingsProcessResultResponse.ReadingsProcessResultList = listaRegistrosProceso;
                    }
                    else {
                        reportReadingsProcessResultResponse.ProcessDone = false;
                        reportReadingsProcessResultResponse.ErrorMessage = MENSAJE_ERROR_REGISTRO_NO_ENCONTRAD;
                        reportReadingsProcessResultResponse.ResultFlag = FLAG_ERROR;
                    }
                }
                else {
                    reportReadingsProcessResultResponse.ErrorMessage = MENSAJE_USUARIO_INVALIDO;
                }
            }
            catch (Exception e)
            {
                Logger.Log(e);
            }

            return reportReadingsProcessResultResponse;
        }
    }
}
