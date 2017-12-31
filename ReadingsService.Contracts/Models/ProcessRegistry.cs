using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ReadingsService.Contracts.Models
{
    [DataContract]
    public class ProcessRegistry
    {

        public readonly static int TRANSACCION_INCOMPLETA = 0;
        public readonly static int TRANSACCION_COMPLETA = 1;


        public string IndividualRegistryId { get; set; }
        public long IDLectura { get; set; }

        //Consecutivo que agrupa un conjunto de elementos ProcessRegistry
        [DataMember]
        public string ProcessID { get; set; }

        [DataMember]
        public DateTime Fecha { get; set; }

        [DataMember]
        public int EstadoTransaccion { get; set; }

        [DataMember]
        public string MensajeError { get; set; }








    }
}
