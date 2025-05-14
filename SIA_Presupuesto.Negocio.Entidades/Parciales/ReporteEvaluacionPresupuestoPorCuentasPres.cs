using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SIA_Presupuesto.Negocio.Entidades
{
    public partial class ReporteEvaluacionPresupuestoPorCuentasPres
    {
        [DataMember]
        public List<ReporteEvaluacionPresupuestoPorCuentasPres> ListaDivisionarias{ get; set; }
        [DataMember]
        public List<ReporteEvaluacionPresupuestoPorCuentasPres> ListaCuentasEspecificas { get; set; }
        [DataMember]
        public List<ReporteEvaluacionPresupuestoPorCuentasDetallePres> ListaDeVouchers { get; set; }
    }
    
}
