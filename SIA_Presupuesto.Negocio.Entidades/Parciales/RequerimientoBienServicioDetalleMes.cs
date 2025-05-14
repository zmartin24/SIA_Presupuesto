using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Entidades
{
    public partial class RequerimientoBienServicioDetalleMes
    {
        [DataMember] 
        public decimal cantEne { get; set; }
        [DataMember]
        public decimal cantFeb { get; set; }
        [DataMember]
        public decimal cantMar { get; set; }
        [DataMember]
        public decimal cantAbr { get; set; }
        [DataMember]
        public decimal cantMay { get; set; }
        [DataMember]
        public decimal cantJun { get; set; }
        [DataMember]
        public decimal cantJul { get; set; }
        [DataMember]
        public decimal cantAgo { get; set; }
        [DataMember]
        public decimal cantSet { get; set; }
        [DataMember]
        public decimal cantOct { get; set; }
        [DataMember]
        public decimal cantNov { get; set; }
        [DataMember]
        public decimal cantDic { get; set; }

    }
}
