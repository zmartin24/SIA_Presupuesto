using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Entidades
{
    public partial class ReportePresupuestoAprobadoComprometidoEjecutadoPres
    {
        [DataMember]
        public List<ReportePresupuestoAprobadoComprometidoEjecutadoPres> ListaDivisionarias{ get; set; }
        [DataMember]
        public List<ReportePresupuestoAprobadoComprometidoEjecutadoPres> ListaCuentasEspecificas { get; set; }
    }
}
