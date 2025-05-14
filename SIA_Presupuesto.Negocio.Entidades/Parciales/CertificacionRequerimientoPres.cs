using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SIA_Presupuesto.Negocio.Entidades
{
    public partial class CertificacionRequerimientoPres
    {
        [DataMember]
        public List<CertificacionDetallePres> CertificacionDetallePres { get; set; }   
    }
}
