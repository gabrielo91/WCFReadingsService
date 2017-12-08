using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ReadingsService.Contracts.Models;


namespace ReadingsService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IReadingsService
    {
        [OperationContract]
        ProcessRequestResultResponse ReportReadings(ReportReadingsRequest reportReadings);

        [OperationContract]
        ReportReadingsProcessResultResponse GetProcessResult(ReportReadingsProcessResultRequest reportReadingsProcessResultRequest);

    }
}
