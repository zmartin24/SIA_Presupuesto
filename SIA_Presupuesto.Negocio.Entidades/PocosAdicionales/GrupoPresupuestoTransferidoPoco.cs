using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Entidades.PocosAdicionales
{
    public class GrupoPresupuestoTransferidoPoco
    {
        public int idPreRec { get; set; }

        public int idGruPre { get; set; }

        public string nombreGruPre { get; set; }

        public int anio { get; set; }

        public string operacion { get; set; }

        public int mes { get; set; }

        public string nombreMes{ get; set; }

        public decimal importe { get; set; }

        public string tipo { get; set; }
    }
}
