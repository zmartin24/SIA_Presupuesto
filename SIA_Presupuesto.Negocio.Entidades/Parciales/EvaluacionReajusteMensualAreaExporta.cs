using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Entidades
{
    public partial class EvaluacionReajusteMensualAreaExporta
    {
        [DataMember]
        public List<EvaluacionReajusteMensualDetallePorPresupuesto> EvaluacionReajusteMensualDetallePorPresupuesto { get; set; }
    }
}
