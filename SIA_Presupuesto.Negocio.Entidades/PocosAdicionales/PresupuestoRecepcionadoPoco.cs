using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Entidades.PocosAdicionales
{
    public class PresupuestoRecepcionadoPoco
    {
        public int idGruPre { get; set; }

        public int idPreRec { get; set; }
        public string nombreGrupre { get; set; }
        public int anio { get; set; }
        public string grupo { get; set; }
        public string operacion { get; set; }
        public decimal cantidad { get; set; }

        public string tipo { get; set; }

        public string usuCrea { get; set; }

        public DateTime fechaCrea { get; set; }
        public decimal importe { get; set; }
        public string nombreMes { get; set; }

        public int mes { get; set; }
    }
}
