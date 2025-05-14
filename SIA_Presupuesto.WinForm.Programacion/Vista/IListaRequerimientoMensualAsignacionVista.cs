using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Base.Vista;
using System.Collections.Generic;
using Utilitario.Util;

namespace SIA_Presupuesto.WinForm.Programacion.Vista
{
    public interface IListaRequerimientoMensualAsignacionVista : IControlBaseVista
    {
        List<RequerimientoMensualBienServicioPres> listaRequerimientoMensual { set; get; }
        List<RequerimientoMensualBienServicioPres> listaRequerimientoMensualAsignado { set; get; }
        List<Anio> listaAnio { set; }
        List<Mes> listaMes { set; }
        List<ProgramacionAnualPres> listaProgramacionAnual { set; }

        int anio { get; set; }
        int mes { get; set; }
        int idProAnu { get; set; }
    }
}
