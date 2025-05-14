using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.General.Base.Vista;
using System.Collections.Generic;

namespace SIA_Presupuesto.WinForm.Mantenimiento.Vista
{
    public interface IListaPartidaPresupuestalCuentaVista : IControlDetalleBaseVista

    {
        List<PartidaPresupuestalCuentaPoco> listaDatosPrincipales { set; }
        PartidaPresupuestalCuentaPoco partidaPresupuestalCuentaPoco { get; }
        string tipo { set; get; }
        string descripcion { set; get; }
        string desUnidad { set; get; }
        decimal precio { set; get; }
    }
}
