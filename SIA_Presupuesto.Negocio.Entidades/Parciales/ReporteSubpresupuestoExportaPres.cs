using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SIA_Presupuesto.Negocio.Entidades
{
    public partial class ReporteSubpresupuestoExportaPres
    {
        [DataMember]
        public List<ReporteSubpresupuestoDetalleExportaPres> ListaReporteSubpresupuestoDetalleExportaPres { get; set; }
    }
}
