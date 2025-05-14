using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Entidades.PocosAdicionales
{
    public class PoaVersionPoco
    {
        public int idPoaVersion { get; set; }
        public int idPoa { get; set; }
        public string codigoPoa { get; set; }
        public int versionPoa { get; set; }
        public int anio { get; set; }
        public string nombre { get; set; }
        public string objetivo { get; set; }
        public DateTime? fechaAprobacion { get; set; }
    }
}
