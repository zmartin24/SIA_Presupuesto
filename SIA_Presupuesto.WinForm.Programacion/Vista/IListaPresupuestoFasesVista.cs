using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Base.Vista;
using System;
using System.Collections.Generic;
using Utilitario.Util;

namespace SIA_Presupuesto.WinForm.Programacion.Vista
{
    public interface IListaPresupuestoFasesVista : IControlBaseVista
    {
        List<Moneda> listaMoneda { set; }
        List<Anio> listaAnio { set; }
        
        int idMoneda { get; set; }
        int vanio { get; set; }
        DateTime fechaIni { get; set; }
        DateTime fechaFin { get; set; }
        int idPresupuesto { get; set; }
        int nivelPresupuesto { get; set; }
        GrupoPresupuesto GrupoPresupuesto { get; set; }
        Presupuesto Presupuesto { get; set; }
        Subpresupuesto Subpresupuesto { get; set; }

        List<ReportePresupuestoFasesPres> listaDatosPrincipales { set; }
        List<ReportePresupuestoFasesPres> listaReportePresupuestoFasesPres { set; get; }

    }
}
