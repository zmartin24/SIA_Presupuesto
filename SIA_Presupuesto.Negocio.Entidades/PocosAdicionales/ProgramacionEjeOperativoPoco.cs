using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Entidades.PocosAdicionales
{
    [DataContract(IsReference = true)]
    public class ProgramacionEjeOperativoPoco
    {
        [DataMember]
        public int idProAnuEjeOpe { get; set; }
        [DataMember]
        public int idProAnu { get; set; }
        [DataMember]
        public int idEjeOpe { get; set; }
        [DataMember]
        public string ejeOperativo { get; set; }
        [DataMember]
        public string observacion { get; set; }
        [DataMember]
        public string operacion { get; set; }
    }
}
