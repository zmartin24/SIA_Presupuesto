using SIA_Presupuesto.Negocio.Entidades;
using System.Collections.Generic;
using Utilitario.Util;

namespace SIA_Presupuesto.WinForm.Programacion.Vista
{
    public interface IExportarProgramacionAnualGenericaMasivoVista
    {
        List<Anio> listaAnios{ set; }
        List<Moneda> listaMoneda { set; }
        int anioReporte { set; get; }
        int idMoneda { set; get; }
        string idsProAnu { get; set; }
        List<ProgramacionAnualPres> listaProgramacionAnual { set; }
    }
}
