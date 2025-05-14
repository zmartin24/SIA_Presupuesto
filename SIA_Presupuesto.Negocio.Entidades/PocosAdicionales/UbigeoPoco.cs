using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Entidades.PocosAdicionales
{
    public class UbigeoPoco
    {
        public int idDistrito { get; set; }
        public string codDistrito { get; set; }
        public string distrito { get; set; }
        public int idProvincia { get; set; }
        public string codProvincia { get; set; }
        public string provincia { get; set; }
        public int idRegion { get; set; }
        public string codRegion { get; set; }
        public string region { get; set; }
    }
}
