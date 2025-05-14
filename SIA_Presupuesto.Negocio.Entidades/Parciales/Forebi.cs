using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SIA_Presupuesto.Negocio.Entidades
{
    public partial class Forebi
    {
        [DataMember]
        public List<ForeDetallePoco> ListaForeDetallePoco { get; set; }
        public List<ForebiDetalle> ListaForebiDetalle { get; set; }

    }
}
