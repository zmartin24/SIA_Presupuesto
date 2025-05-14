using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.General.Base.Vista;
using SIA_Presupuesto.WinForm.General.Helper;
using System;
using System.Collections.Generic;

namespace SIA_Presupuesto.WinForm.Programacion.Vista
{
    public interface IProgramacionAnualGeneralVista : IDialogoBaseVista
    {
        List<GrupoPresupuesto> listaGrupoPresupuesto { set; }
        List<Moneda> listaMonedas { set; }
        List<FuenteFinanciamiento> listaFuenteFinan { set; }
        List<Predeterminado> listaTipos { set; }
        List<PoaVersionPoco> listaPoa { set; }
        List<TipoActividad> listaTipoActividad { set; }
        List<Predeterminado> listaNroTransferencia { set; }

        List<ProgramacionSedeLaboralPoco> listaSedes { set; get; }
        List<ProgramacionEjeOperativoPoco> listaEjeOperativos { set; get; }

        int idGruPre { set; get; }
        int idFueFin { set; get; }
        int idMoneda { set; get; }
        int anio { set; get; }
        string descripcion { set; get; }
        DateTime fechaEmision { set; get; }
        string codTipo { set; get; }
        string titulo { set; get; }
        bool esSaldo { set; get; }
        Nullable<int> idTipoActividad { set; get; }
        Nullable<int> idPoaVersion { set; get; }
        Nullable<int> idNroTransferencia { set; get; }
        Nullable<int> metaHa { set; get; }
        Nullable<decimal> costoHa { set; get; }
        string denominacion { set; get; }
        string observacion { set; get; }

    }
}
