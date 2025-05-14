using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SIA_Presupuesto.Negocio.Entidades
{
    public partial class ReporteEjecucionPresupuestoPorCuentasPres
    {
        [DataMember]
        public List<ReporteEjecucionPresupuestoPorCuentasPres> ListaDivisionarias{ get; set; }
        [DataMember]
        public List<ReporteEjecucionPresupuestoPorCuentasPres> ListaCuentasEspecificas { get; set; }
        [DataMember]
        public List<ReporteEjecucionPresupuestoPorCuentasDetallePres> ListaDeVouchers { get; set; }
    }
    
}
