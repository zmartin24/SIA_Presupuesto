using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Entidades.PocosAdicionales
{
    public class ParametroPoco
    {
        [DataMember]
        public int idParPreRem { get; set; }
        [DataMember]
        public int idConPreRem { get; set; }
        [DataMember]
        public decimal importe { get; set; }
        [DataMember]
        public string concepto { get; set; }
        [DataMember]
        public string codigo { get; set; }
    }
}
