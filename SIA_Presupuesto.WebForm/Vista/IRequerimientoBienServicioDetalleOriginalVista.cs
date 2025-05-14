using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WebForm.Helper;
using SIA_Presupuesto.WebForm.Vista.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitario.Util;

namespace SIA_Presupuesto.WebForm.Vista
{
    public interface IRequerimientoBienServicioDetalleOriginalVista : IFormularioBase
    {
        int idReqBieSer { get; }
        
        List<RequerimientoBienServicioDetallePres> listaDatosPrincipales { set; }
        List<RequerimientoBienServicioDetallePres> listaGridData { set; get; }
        List<Producto> listaDatosProductos { set; }
        
        List<Unidad> listaUnidades { set; }
        List<CuentaContable> listaCuentaContable { set; }
        List<Anio> listaAnios { set; }

        int idUnidad { get; set; }
        int idProducto { get; set; }
        int idCueCon { get; set; }
        string descripcion { get; set; }
        string justificacion { get; set; }
        decimal precio { get; set; }

        object listaPrecio { set; }
        object precioActual { get; }
        int anioPresentacion { get; set; }
        string desArea { set; }

    }
}
