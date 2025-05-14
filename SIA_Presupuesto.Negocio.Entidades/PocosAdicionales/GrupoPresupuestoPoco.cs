using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Entidades.PocosAdicionales
{
    public class GrupoPresupuestoPoco
    {
        public int idGrupoPresupuesto { get; set; }

        public string codigo { get; set; }

        public string descripcion { get; set; }

        public int? idFuenteFinanciamiento { get; set; }

        public string abreviatura { get; set; }

        public string esEncargo { get; set; }

        public string nombreFuente { get; set; }

        public string observacion { get; set; }

        public string grupo { get; set; }
    }
}
