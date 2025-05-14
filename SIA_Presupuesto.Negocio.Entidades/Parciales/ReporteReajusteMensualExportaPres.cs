using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SIA_Presupuesto.Negocio.Entidades
{
    public partial class ReporteReajusteMensualExportaPres
    {
        [DataMember]
        public List<ReporteReajusteMensualDetalleExportaPres> ListaReporteReajusteMensualDetalleExportaPres { get; set; }
    }
}
