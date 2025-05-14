using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SIA_Presupuesto.Negocio.Entidades
{
    public partial class Forese
    {
        [DataMember]
        public List<ForeDetallePoco> ListaForeDetallePoco { get; set; }
        public List<ForeseDetalle> ListaForeseDetalle { get; set; }
    }
}
