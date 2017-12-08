using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ReadingsService.Contracts.Models
{
    [DataContract]
    public class ReportReadingsProcessResultResponse
    {
        [DataMember]
        public Boolean ProcessDone { get; set; }

        [DataMember]
        public String ResultFlag { get; set; }

        [DataMember]
        public List<ProcessRegistry> ReadingsProcessResultList { get; set; }
    }
}
