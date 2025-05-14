using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.Adquisicion.Helper;
using SIA_Presupuesto.WinForm.General.Base.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.Adquisicion.Vista
{
    public interface IListaPresupuestoAproComVista : IControlBaseVista
    {
        List<ReportePresupuestoAprobadoComprometidoEjecutadoPres> listaDatosPrincipales { set; }
        List<Moneda> listaMonedas { set; }
        int idMoneda { get; set; }
        GrupoPresupuesto GrupoPresupuesto { get; set; }
        Presupuesto Presupuesto { get; set; }
        Subpresupuesto Subpresupuesto { get; set; }
    }
}
