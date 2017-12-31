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
        public int Id { get; set; }

        [DataMember]
        public string CodigoProveedor { get; set; }
        [DataMember]
        public string IdSuministroElectrico { get; set; }
        [DataMember]
        public string FechaLectura { get; set; }
        [DataMember]
        public string NumeroMedidor { get; set; }
        [DataMember]
        public string CodigoMarcaMedidor { get; set; }
        [DataMember]
        public string TipoLectura { get; set; }
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

        public string FechaTransaccion { get; set; }
        [DataMember]
        public int GeneroAlarma { get; set; }
        [DataMember]
        public int Certificada { get; set; }
        [DataMember]
        public int ConsecutivoProceso { get; set; }

    }
}
