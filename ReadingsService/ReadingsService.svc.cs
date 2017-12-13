using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ReadingsService.Contracts.Models;
using ReadingsService.Contracts.Controller;

namespace ReadingsService
{

    public class ReadingsService : IReadingsService
    {
                
        public ProcessRequestResultResponse ReportReadings(ReportReadingsRequest reportReadings)
        {
            var processRequestResult = ReadingsController.SaveReadings(reportReadings);
            return processRequestResult;
        }

        public ReportReadingsProcessResultResponse GetProcessResult(ReportReadingsProcessResultRequest reportReadingsProcessResultRequest)
        {
            var reportReadingsProcessResult = ReadingsController.GetProcessResult(reportReadingsProcessResultRequest);
            return reportReadingsProcessResult;
        }
    }
}
