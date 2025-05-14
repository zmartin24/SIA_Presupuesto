using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Entidades
{
    public partial class GastoRecurrenteRequerimientoPres
    {
        [DataMember]
        public List<GastoRecurrenteDetallePres> GastoRecurrenteDetallePres { get; set; }   
    }
}
