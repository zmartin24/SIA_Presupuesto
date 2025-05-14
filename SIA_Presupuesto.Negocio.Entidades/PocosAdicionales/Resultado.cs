using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Entidades.PocosAdicionales
{
    [DataContract(IsReference = true)]
    public class Resultado
    {
        [DataMember]
        public object objetoPrincipal { get; set; }
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public bool esCorrecto { get; set; }
        [DataMember]
        public string mensajeMostrar { get; set; }
        [DataMember]
        public string mensajeInterno { get; set; }
        [DataMember]
        public string mensajeInterno2 { get; set; }
        [DataMember]
        public string mensajeInterno3 { get; set; }
        [DataMember]
        public string mensajeInterno4 { get; set; }

    }
}