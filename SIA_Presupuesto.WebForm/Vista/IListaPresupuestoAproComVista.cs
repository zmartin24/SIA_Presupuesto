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
    public interface IListaPresupuestoAproComVista : IListaBase
    {
        List<ReportePresupuestoAprobadoComprometidoEjecutadoPres> listaDatosPrincipales { set; }
        List<Moneda> listaMonedas { set; }
        List<GrupoPresupuesto> listaGrupoPresupuesto { set; }
        List<Presupuesto> listaPresupuesto { set; }
        List<Subpresupuesto> listaSubPresupuesto { set; }
        int idSubPresupuesto { get; set; }
        int idMoneda { get; set; }
        GrupoPresupuesto GrupoPresupuesto { get; set; }
        Presupuesto Presupuesto { get; set; }
        Subpresupuesto Subpresupuesto { get; set; }
    }
}
