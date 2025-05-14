using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Entidades.PocosAdicionales
{
    public class ForeDetallePoco
    {
        public Nullable<int> idCerDet { get; set; }
        public int idDetalle { get; set; }
        public int idCabecera { get; set; }
        public string descripcion { get; set; }
        public string unidad { get; set; }
        public decimal precio { get; set; }
        public decimal cantidad { get; set; }
        public decimal subTotal { get; set; }
        public Nullable<int> idProAnuReaMen { get; set; }
        public Nullable<int> tipoDet { get; set; }
        public Nullable<int> idCueCon { get; set; }
        public string numCuenta { get; set; }
        public decimal saldoSoles { get; set; }
        public decimal saldoDolares { get; set; }
    }
}
