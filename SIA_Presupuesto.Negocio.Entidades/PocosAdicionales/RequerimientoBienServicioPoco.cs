using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Entidades.PocosAdicionales
{
    public class RequerimientoBienServicioPoco
    {
        public int idReqBieSer { get; set; }
        public int idArea { get; set; }
        public int idMoneda { get; set; }
        public string descripcion { get; set; }
        public System.DateTime fechaEmision { get; set; }
        public Nullable<System.DateTime> fechaAprobacion { get; set; }
        public int anio { get; set; }
        public string desArea { get; set; }
        public string desSubdireccion { get; set; }
        public string desDireccion { get; set; }
        public string usuCrea { get; set; }
        public System.DateTime fechaCrea { get; set; }
        public string usuEdita { get; set; }
        public Nullable<System.DateTime> fechaEdita { get; set; }
        public int estado { get; set; }
    }
}
