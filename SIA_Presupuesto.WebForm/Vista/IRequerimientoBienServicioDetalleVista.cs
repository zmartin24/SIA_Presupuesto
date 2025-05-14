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
    public interface IRequerimientoBienServicioDetalleVista : IFormularioBase
    {
        int idReqBieSer { get; }
        
        List<RequerimientoBienServicioDetallePres> listaDatosPrincipales { set; }
        List<RequerimientoBienServicioDetalleMes> listaRequerimientoDetalleMes { set; }
        List<RequerimientoBienServicioDetallePres> listaGridData { set; get; }
        //List<RequerimientoBienServicioDetalleMes> listaGridDataDetMes { set; get; }
        List<Predeterminado> listaTipo { set; }
        
        List<Unidad> listaUnidades { set; }
        //List<CuentaContable> listaCuentaContable { set; }
        
        int tipo { set; get; }
        bool conPartida { get; set; }
        int idUnidad { get; set; }
        int idProducto { get; set; }
        int? idParPre { get; set; }
        int idCueCon { get; set; }
        string desCuenta { get; set; }
        string descripcion { get; set; }
        string justificacion { get; set; }
        decimal precio { get; set; }
        object listaPartidaPresupuestal { set; }
        object listaProductoPrecio { set; }
        object precioActual { get; }
        object productoPrecioActual { get; }
        string desArea { set; }
        string datoDescripcionPartida { set; get; }
        string datoDescripcion { set; get; }
        int idMoneda { set; get; }
    }
}
