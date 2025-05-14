using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.General.Base.Vista;
using SIA_Presupuesto.WinForm.General.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitario.Util;

namespace SIA_Presupuesto.WinForm.Adquisicion.Vista
{
    public interface IListaEvaluacionPresupuestoCuentaVista : IControlBaseVista
    {
        List<ReporteEvaluacionPresupuestoPorCuentasPres> listaDatosPrincipales { set; }
        List<Anio> listaAnio { set; }
        List<Moneda> listaMonedas { set; }
        int anio { get; set; }
        int idMoneda { get; set; }
        int idPresupuesto { get; set; }
        int nivelPresupuesto { get; set; }
        GrupoPresupuesto GrupoPresupuesto { get; set; }
        Presupuesto Presupuesto { get; set; }
        Subpresupuesto Subpresupuesto { get; set; }
    }
}
