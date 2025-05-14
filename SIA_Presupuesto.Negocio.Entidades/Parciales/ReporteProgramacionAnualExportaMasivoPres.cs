using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SIA_Presupuesto.Negocio.Entidades
{
    public partial class ReporteProgramacionAnualExportaMasivoPres
    {
        [DataMember]
        public List<ReporteProgramacionAnualDetalleExportaMasivoPres> ListaReporteProgramacionAnualDetalleExportaMasivoPres { get; set; }
    }
}
