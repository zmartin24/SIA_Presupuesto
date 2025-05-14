using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Entidades.PocosAdicionales
{
    public class CuentaContablePoco
    {
        public int idCueCon { get; set; }
        
        public string numCuenta { get; set; }

        public string descripcion2 { get; set; }
        
        public string descripcion { get; set; }

        public int idCueConN1 { get; set; }

        public string numCuentaN1 { get; set; }
        public int idCueConN2 { get; set; }

        public string numCuentaN2 { get; set; }

        public Nullable<int> idPlaCue { get; set; }
        
        public string abreviatura { get; set; }
        
        public string abreviaturaliq { get; set; }
        
        public Nullable<int> idTipCtaCon { get; set; }
        
        public string DeudorAcreedor { get; set; }
        
        public string anexoPrincipal { get; set; }
        
        public string anexoSecundario { get; set; }
        
        public Nullable<int> idNivSal { get; set; }

        public Nullable<bool> inConBan { get; set; }
        
        public Nullable<bool> esManual { get; set; }
        
        public Nullable<int> dependencia { get; set; }
        
        public Nullable<int> nivel { get; set; }
        
        public string usuCrea { get; set; }
        
        public string usuEdita { get; set; }
        
        public Nullable<System.DateTime> fecCrea { get; set; }
        
        public Nullable<System.DateTime> fecEdita { get; set; }
        
        public Nullable<int> idCatCon { get; set; }
        
        public Nullable<bool> estado { get; set; }
    }
}
