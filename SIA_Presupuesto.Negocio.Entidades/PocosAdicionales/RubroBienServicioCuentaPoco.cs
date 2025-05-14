using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Entidades.PocosAdicionales
{
    public class RubroBienServicioCuentaPoco
    {
        public int idRubBieSerCue { get; set; }
        public int idRubBieSer { get; set; }
        public int idTipoGasto { get; set; }
        public string tipoGasto { get; set; }
        public int idCueCon { get; set; }
        public string cuenta { get; set; }
        public string numCuenta { get; set; }
        public string usuCrea { get; set; }
        public DateTime fechaCrea { get; set; }
        public string usuEdita { get; set; }
        public DateTime? fechaEdita { get; set; }
        public int estado { get; set; }
    }
}
