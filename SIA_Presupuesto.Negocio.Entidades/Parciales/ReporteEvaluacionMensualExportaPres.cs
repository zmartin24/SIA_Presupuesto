using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SIA_Presupuesto.Negocio.Entidades
{
    public partial class ReporteEvaluacionMensualExportaPres
    {
        [DataMember]
        public List<ReporteEvaluacionMensualDetalleExportaPres> ListaReporteEvaluacionMensualDetalleExportaPres { get; set; }
    }
}
