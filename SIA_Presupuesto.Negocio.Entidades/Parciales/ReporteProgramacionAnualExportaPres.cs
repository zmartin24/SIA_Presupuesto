using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SIA_Presupuesto.Negocio.Entidades
{
    public partial class ReporteProgramacionAnualExportaPres
    {
        [DataMember]
        public List<ReporteProgramacionAnualDetalleExportaPres> ListaReporteProgramacionAnualDetalleExportaPres { get; set; }
    }
}
