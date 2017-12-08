using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ReadingsService.Contracts.Models
{
    [DataContract]
    public class Readings
    {
        [DataMember]
        public int ConsecutivoProcesoId { get; set; }
        [DataMember]
        public string CodigoProveedor { get; set; }
        [DataMember]
        public DateTime FechaLectura { get; set; }
        [DataMember]
        public string NumeroMedidor { get; set; }
        [DataMember]
        public string CodigoMarcaMedidor { get; set; }
        [DataMember]
        public string TipoMedidor { get; set; }
        [DataMember]
        public int Lectura { get; set; }
        [DataMember]
        public int ConsumoOriginal { get; set; }
        [DataMember]
        public int ConsumoModificado { get; set; }
        [DataMember]
        public int ConsumoBloqueado { get; set; }
        [DataMember]
        public int Enviado { get; set; }
        [DataMember]
        public string CodigoUsuario { get; set; }
        [DataMember]
        public string Programa { get; set; }
        [DataMember]
        public string FechaTransaccion { get; set; }
        [DataMember]
        public int GeneroAlarma { get; set; }
        [DataMember]
        public int Certificada { get; set; }

    }
}
