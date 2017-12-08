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
        public string ProcessRegistryId { get; set; }

        //Id de el resultado de inserciòn de cada una de las lecturas (Id de la lectura asociada)
        public int ConsecutivoProcesoId { get; set; }

        //Consecutivo que agrupa un conjunto de elementos ProcessRegistry
        [DataMember]
        public int IdProcesoGeneral { get; set; }

        [DataMember]
        public DateTime Fecha { get; set; }

        [DataMember]
        public string EstadoTransaccion { get; set; }

        [DataMember]
        public string MensajeError { get; set; }








    }
}
