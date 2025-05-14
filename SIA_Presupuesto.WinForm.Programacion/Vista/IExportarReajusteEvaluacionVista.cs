using SIA_Presupuesto.Negocio.Entidades;
using System.Collections.Generic;
using Utilitario.Util;

namespace SIA_Presupuesto.WinForm.Programacion.Vista
{
    public interface IExportarReajusteEvaluacionVista
    {
        List<Anio> listaAnios{ set; }
        List<Moneda> listaMoneda { set; }
        int anioReporte { set; get; }
        List<Mes> listaMeses { set; }
        int mesReporte { set; get; }
        List<Mes> listaMesesRea { set; }
        int mesReporteRea { set; get; }
        int idProAnu { set; get; }
        List<ProgramacionAnualPres> listaProgramacionAnual { set; }
        int idMoneda { set; get; }
    }
}
