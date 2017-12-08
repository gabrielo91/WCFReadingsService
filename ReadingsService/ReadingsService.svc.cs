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

    public class Service1 : IReadingsService
    {
                
        public ProcessRequestResultResponse ReportReadings(ReportReadingsRequest reportReadings)
        {
            var readingsController = new ReadingsController();
            var processRequestResult = readingsController.getProcessResult(reportReadings);
            return processRequestResult;
        }

        public ReportReadingsProcessResultResponse GetProcessResult(ReportReadingsProcessResultRequest reportReadingsProcessResultRequest)
        {
            var readingsController = new ReadingsController();
            var reportReadingsProcessResult = readingsController.saveReadings(reportReadingsProcessResultRequest);
            return reportReadingsProcessResult;

        }
    }
}
