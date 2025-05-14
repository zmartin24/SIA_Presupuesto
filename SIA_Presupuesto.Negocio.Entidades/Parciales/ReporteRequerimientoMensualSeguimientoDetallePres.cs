using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SIA_Presupuesto.Negocio.Entidades
{
    public partial class ReporteRequerimientoMensualSeguimientoDetallePres
    {
        [DataMember]
        public List<ReporteRequerimientoMensualSeguimientoDetallePres> ListaDivisionarias{ get; set; }
        [DataMember]
        public List<ReporteRequerimientoMensualSeguimientoDetallePres> ListaCuentasEspecificas { get; set; }
        [DataMember]
        public List<ReporteRequerimientoMensualSeguimientoDetalleForebisePres> listaDetalleMovimiento { get; set; }
    }
    
}
