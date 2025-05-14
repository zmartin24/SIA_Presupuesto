using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SIA_Presupuesto.Negocio.Entidades
{
    public partial class ReportePresupuestoFasesPres
    {
        [DataMember]
        public List<ReportePresupuestoFasesPres> ListaSubCuenta{ get; set; }
        [DataMember]
        public List<ReportePresupuestoFasesPres> ListaCuentasEspecificas { get; set; }


    }
    
}
