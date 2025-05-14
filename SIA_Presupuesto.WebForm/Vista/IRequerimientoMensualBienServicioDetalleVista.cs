using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WebForm.Helper;
using SIA_Presupuesto.WebForm.Vista.Base;
using System.Collections.Generic;

namespace SIA_Presupuesto.WebForm.Vista
{
    public interface IRequerimientoMensualBienServicioDetalleVista : IFormularioBase
    {
        int idReqMenBieSer { get; }
        string desArea { set; }
        string desTipoCambio { set; }
        int idMoneda { set; get; }
        string estadoReqMen { set; get; }

        //List<Predeterminado> listaTipo { set; }
        List<Unidad> listaUnidades { set; }
        //List<CuentaContable> listaCuentaContable { set; }
        //PartidaPresupuestalPrecioPres partidaPresupuestalPrecioPres { set; get; }
        //ProductoPrecioPres productoPrecioPres { set; get; }
        //int? idParPre { get; set; }
        //string desParPre { set; get; }
        //int? idProducto { get; set; }
        //string desProducto { set; get; }
        int tipo { set; get; }
        //bool conPartida { get; set; }
        int idUnidad { get; set; }
        int? idProducto { get; set; }
        int? idParPre { get; set; }
        string desPartidaPre{ set; }
        string desProducto { set; }
        int idCueCon { get; set; }
        string desTipo { set; }
        string desCuenta { set; }
        string descripcion { get; set; }
        string justificacion { get; set; }
        decimal cantidad { get; set; }
        decimal precio { get; set; }
        object listaPartidaPresupuestal { set; }
        object listaProductoPrecio { set; }
        decimal importe { get; set; }

        List<RequerimientoMensualDetallePres> listaDatosPrincipales { set; }
        List<RequerimientoMensualDetallePres> listaGridData { set; get; }
    }
}
