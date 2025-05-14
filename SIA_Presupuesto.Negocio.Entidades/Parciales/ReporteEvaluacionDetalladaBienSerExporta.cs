using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SIA_Presupuesto.Negocio.Entidades
{
    public partial class ReporteEvaluacionDetalladaBienSerExporta
    {
        [DataMember]
        public List<ReporteEvaluacionDetalladaBienSerExportaPres> ReporteEvaluacionDetalladaBienSerExportaPres { get; set; }
    }
}
