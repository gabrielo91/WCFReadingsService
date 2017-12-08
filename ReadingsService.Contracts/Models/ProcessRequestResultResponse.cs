using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ReadingsService.Contracts.Models
{
    [DataContract]
    public class ProcessRequestResultResponse
    {
        [DataMember]
        public string ErrorMessage { get; set; }

        [DataMember]
        public bool ProcessAccepted { get; set; }

        [DataMember]
        public string ProcessID { get; set; }

    }
}
