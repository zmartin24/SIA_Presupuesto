using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Entidades.PocosAdicionales
{
    public class PartidaPresupuestalCuentaPoco
    {
        public int idParPreCue { get; set; }
        public int idParPre { get; set; }
        public int idCueCon { get; set; }
        public string numCuenta { get; set; }
        public string desCuenta { get; set; }
        public int anio { get; set; }
        
        public string usuCrea { get; set; }
        public Nullable<DateTime> fechaCrea { get; set; }
        public string usuEdita { get; set; }
        public Nullable<DateTime> fechaEdita { get; set; }
        public bool estado { get; set; }
        public string nombreEstado { get; set; }

    }
}
