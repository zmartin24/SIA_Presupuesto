using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Entidades.PocosAdicionales
{
    public class ResultadoCalculoPoco
    {
        [DataMember]
        public int idPuePre { get; set; }
        [DataMember]
        public int idProPreRem { get; set; }
        [DataMember]
        public int mes { get; set; }
        [DataMember]
        public decimal valor { get; set; }
    }
}
