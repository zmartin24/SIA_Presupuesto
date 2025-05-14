using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Entidades.PocosAdicionales
{
    public class RubroBienServicioPoco
    {
        public int idRubBieSer { get; set; }
        public string descripcion { get; set; }
        public int tipoRubro { get; set; }
        public string usuCrea { get; set; }
        public DateTime fechaCrea { get; set; }
        public string usuEdita{ get; set; }
        public DateTime? fechaEdita { get; set; }
        public int estado { get; set; }
    }
}
