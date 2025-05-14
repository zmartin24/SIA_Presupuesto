using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Entidades.PocosAdicionales
{
    public class DetalleRequerimientoMensualBienServcioMigraPoco
    {
        public int idParPre { get; set; }
        public int idProducto { get; set; }
        public string productoPartida { get; set; }
        public string descripcion { get; set; }
        public int idUnidad { get; set; }
        public string unidad { get; set; }
        public int idCueCon { get; set; }
        public string numCuenta { get; set; }
        public decimal precio { get; set; }
        public decimal cantidad { get; set; }
        public string justificacion { get; set; }
        
    }
}
