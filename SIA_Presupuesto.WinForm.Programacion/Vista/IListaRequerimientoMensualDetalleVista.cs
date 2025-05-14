using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Base.Vista;
using System.Collections.Generic;
using Utilitario.Util;

namespace SIA_Presupuesto.WinForm.Programacion.Vista
{
    public interface IListaRequerimientoMensualDetalleVista : IControlDetalleBaseVista
    {
        List<RequerimientoMensualDetallePres> listaDatosPrincipales { set; }
        RequerimientoMensualDetalle requerimientoMensualDetalle { get; }
        string descripcion { set; }
        string desArea { set; }
        string desTipo { set; }
        string desMoneda { set; }
    }
}
