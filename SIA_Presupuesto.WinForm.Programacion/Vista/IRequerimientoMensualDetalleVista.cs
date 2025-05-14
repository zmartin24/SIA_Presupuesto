using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Base.Vista;
using System.Collections.Generic;

namespace SIA_Presupuesto.WinForm.Programacion.Vista
{
    public interface IRequerimientoMensualDetalleVista : IDialogoBaseVista
    {
        List<Unidad> listaUnidades { set; }
        PartidaPresupuestalPrecioPres partidaPresupuestalPrecioPres { set; get; }
        ProductoPrecioPres productoPrecioPres { set; get; }
        int? idParPre { get; set; }
        string desParPre { set; get; }
        int? idProducto { get; set; }
        string desProducto { set; get; }
        int idUnidad { get; set; }
        int idCueCon { get; set; }
        string desCuenta { set; get; }
        string descripcion { get; set; }
        string justificacion { get; set; }
        decimal cantidad { get; set; }
        decimal precio { get; set; }
        decimal importe { get; set; }
    }
}
