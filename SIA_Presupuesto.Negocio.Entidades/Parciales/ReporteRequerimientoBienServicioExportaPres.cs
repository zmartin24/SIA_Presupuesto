using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SIA_Presupuesto.Negocio.Entidades
{
    public partial class ReporteRequerimientoBienServicioExportaPres
    {
        [DataMember]
        public List<ReporteRequerimientoBienServicioDetalleExportaPres> ListaReporteRequerimientoBienServicioDetalleExportaPres { get; set; }
    }
}
