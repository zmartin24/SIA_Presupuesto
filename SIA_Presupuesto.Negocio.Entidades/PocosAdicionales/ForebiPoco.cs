using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Entidades.PocosAdicionales
{
    public class ForebiPoco
    {
        public int idForebi { get; set; }
        
        public string codigo { get; set; }
        
        public string numero { get; set; }
        
        public Nullable<System.DateTime> fechaEmision { get; set; }
        
        public Nullable<int> idGruPre { get; set; }
        
        public Nullable<int> idPresupuesto { get; set; }
        
        public Nullable<int> idSubPresupuesto { get; set; }
        public string desGruPre { get; set; }

        public string desPresupuesto { get; set; }

        public string desSubPresupuesto { get; set; }

        public Nullable<int> idDireccion { get; set; }
        
        public Nullable<int> idSubdireccion { get; set; }
        public string desDireccion { get; set; }

        public string desSubdireccion { get; set; }

        public string justificacion { get; set; }
        
        public Nullable<int> estado { get; set; }

        public List<ForebiDetalle> listaDetalle { get; set; }
    }
}
