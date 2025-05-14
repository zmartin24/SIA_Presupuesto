using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Entidades
{
    public partial class SubPresupuestoAreaPres
    {
        [DataMember]
        public List<SubPresupuestoAreaDetallePres> SubPresupuestoAreaDetallePres { get; set; }   
    }
}
