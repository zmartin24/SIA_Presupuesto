using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Base.Vista;
using System.Collections.Generic;
using Utilitario.Util;

namespace SIA_Presupuesto.WinForm.Adquisicion.Vista
{
    public interface IListaPresupuestoEjecutadoVista : IControlBaseVista
    {
        List<Moneda> listaMoneda { set; }
        List<Anio> listaAnio { set; }
        List<Mes> listaMes { set; }
        
        int idMoneda { get; set; }
        int anio { get; set; }
        int mes { set; get; }

        List<ReportePresupuestoEjecutadoPres> listaDatosPrincipales { set; }
    }
}
