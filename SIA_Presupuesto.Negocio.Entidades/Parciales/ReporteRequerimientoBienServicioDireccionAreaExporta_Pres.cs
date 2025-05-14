using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Entidades
{
    public partial class ReporteRequerimientoBienServicioDireccionAreaExporta_Pres
    {
        [DataMember] 
        public List<ReporteRequerimientoBienServicioDireccionAreaDetalleExporta_Pres> ListaReporteRequerimientoBienServicioDireccionAreaDetalleExporta_Pres { get; set; }

    }
}
