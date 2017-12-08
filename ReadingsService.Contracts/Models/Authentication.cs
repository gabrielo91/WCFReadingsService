using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ReadingsService.Contracts.Models
{
    [DataContract]
    public class Authentication
    {
        [DataMember]
        public int UserName { get; set; }

        [DataMember]
        public int Password { get; set; }
    }
}
