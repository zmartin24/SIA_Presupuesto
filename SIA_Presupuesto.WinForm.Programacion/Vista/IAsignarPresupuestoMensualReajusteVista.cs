using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.General.Base.Vista;
using System.Collections.Generic;

namespace SIA_Presupuesto.WinForm.Programacion.Vista
{
    public interface IAsignarPresupuestoMensualReajusteVista : IDialogoBaseVista
    {
        List<ReajusteMensualDetallePorMesPres> listaDetalleReajusteMensual { get; set; }
        List<ReajusteMensualDetallePorMesPres> listaDetalleSubPre { get; set; }
        List<ItemPoco> listaMes { set; }
        List<Subpresupuesto> listaSubpresupuesto { set; }

        string desPresupuesto { set; }
        int mes { get; set; }
        int idSubpresupuesto { get; set; }
        int opcion { get; set; }
    }
}
