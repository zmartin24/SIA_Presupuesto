using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SIA_Presupuesto.Negocio.Entidades
{
    public partial class PartidaPresupuestal
    {
        [DataMember]
        public int idCueCon { get; set; }
        public int anio { get; set; }
        public CuentaContable cuentaContable { get; set; }
        public List<PartidaPresupuestalCuenta> ListaPartidaPresupuestalCuenta { get; set; }
    }
}
