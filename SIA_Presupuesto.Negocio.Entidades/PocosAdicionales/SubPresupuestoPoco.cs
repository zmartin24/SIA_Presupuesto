using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Entidades.PocosAdicionales
{
    public class SubPresupuestoPoco
    {
        public int idSubPresupuesto { get; set; }
        public string desSubPresupuesto { get; set; }
        public int idPresupuesto { get; set; }
        public string desPresupuesto { get; set; }
        public int idGrupoPresupuesto { get; set; }
        public string desGrupoPresupuesto { get; set; }
        public string desDireccion { get; set; }
        public string anio { get; set; }
        public int? mes { get; set; }
        public string cuentaBancaria { get; set; }
        public bool? esObra { get; set; }
        public bool? esEncargo { get; set; }
        public bool? esActividadCampo { get; set; }
        public bool? esErradicacion { get; set; }
        public bool? esLiquidado { get; set; }
        public string proyecto { get; set; }
        public decimal importeObra { get; set; }
        public decimal certificacionSoles { get; set; }
        public decimal certificacionDolares { get; set; }
        public decimal tipoCambio { get; set; }
        public string usuCrea { get; set; }
        public Nullable<DateTime> fechaCrea { get; set; }
        public string usuEdita { get; set; }
        public Nullable<DateTime> fechaEdita { get; set; }
        public int estado { get; set; }
        public string nombreEstado { get; set; }

    }
}
