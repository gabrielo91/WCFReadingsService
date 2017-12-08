using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ReadingsService.Contracts.Models
{
    [DataContract]
    public class ReportReadingsRequest
    {
        [DataMember]
        public Authentication Authentication { get; set; }

        [DataMember]
        public List<Readings> Readings { get; set; }
    }
}
