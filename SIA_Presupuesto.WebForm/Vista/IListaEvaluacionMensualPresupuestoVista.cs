using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WebForm.Vista.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitario.Util;

namespace SIA_Presupuesto.WebForm.Vista
{
    public interface IListaEvaluacionMensualPresupuestoVista : IListaBase
    {
        List<EvaluacionMensualPresupuestoPres> listaDatosPrincipales { set; }

        List<Anio> listaAnios { set; }

        List<Mes> listaMeses { set; }

        int anioPresentacion { set; get; }

        int mesPresentacion { set; get; }

        //******************
        List<Anio> listaAniosSub { set; }

        List<Mes> listaMesesEvaSub { set; }

        List<Mes> listaMesesReaSub { set; }

        List<GrupoPresupuesto> listaGrupoPresupuestoSub { set; }

        int anioSub { set; get; }

        int mesEvaSub { set; get; }

        int mesReaSub { set; get; }

        int idGruPreSub { set; get; }

        //**

        List<Anio> listaAniosCal { set; }

        List<ProgramacionAnualPres> listaProgramacionAnual { set; }

        List<FuenteFinanciamiento> listaFuenteFinanciamiento { set; }

        List<Mes> listaMesesEvaCal { set; }

        List<Mes> listaMesesReaCal { set; }

        int anioCal { set; get; }

        int mesEvaCal { set; get; }

        int mesReaCal { set; get; }

        int idFueFinCal { set; get; }

        int idProAnuCal { set; get; }

        //**
        List<Anio> listaAniosCon { set; }

        List<FuenteFinanciamiento> listaFuenteFinanciamientoCon { set; }

        List<Mes> listaMesesEvaCon { set; }

        List<Mes> listaMesesReaCon { set; }

        int anioCon { set; get; }

        int mesEvaCon { set; get; }

        int mesReaCon { set; get; }

        int idFueFinCon { set; get; }
        string desPresupuesto { set; }
        string desGrupoPresupuesto { set; }
        int idMoneda { set; get; }

        /*PopImprimir*/
        List<TipoReporte> listaTipoReporte { set; }
        List<Anio> listaAnioEvaImp { set; }
        List<Mes> listaMesEvaImp { set; }
        int idTipRep { set; get; }
        int anioEvaImp { set; get; }
        int mesEvaImp { set; get; }

        /*popEjecucionPreMen*/
        List<GrupoPresupuesto> listaGrupoPresupuestoEje { set; }
        List<ProgramacionAnual> listaProgramacionAnualEje { set; }
        List<Subpresupuesto> listaSubpresupuestoEje { set; }
        List<Moneda> listaMonedaEje { set; }
        
        int idGruPreEje { set; get; }
        int idPreEje { set; get; }
        int idSubPreEje {set; get; }
        int idMonedaEje { get; set; }

        /*pop Saldo por grupo*/
        List<Anio> listaAnio_SalGru { set; }
        List<Mes> listaMesEva_SalGru { set; }
        List<Mes> listaMesRea_SalGru { set; }

        int anio_SalGru { get; set; }
        int mesEva_SalGru { get; set; }
        int mesRea_SalGru { get; set; }

        /*popEjecucionPreMenFec*/
        List<GrupoPresupuesto> listaGrupoPresupuesto_PreMenFec { set; }
        List<ProgramacionAnual> listaProgramacionAnual_PreMenFec { set; }
        List<Moneda> listaMoneda_PreMenFec { set; }

        DateTime fecDesde_PreMenFec { set; get; }
        DateTime fecHasta_PreMenFec { set; get; }
        int idGruPre_PreMenFec { set; get; }
        int idPre_PreMenFec { set; get; }
        int idMoneda_PreMenFec { set;get; }

        /*PopEvaluación Reajuste*/
        List<Anio> listaAniosEvaRea { set; }
        List<Moneda> listaMonedaEvaRea { set; }
        List<Mes> listaMesesEvaReaEva { set; }
        List<Mes> listaMesesEvaReaRea { set; }
        List<ProgramacionAnualPres> listaProgramacionAnualEvaRea { set; }
        int anioEvaRea { set; get; }
        int idMonedaEvaRea { set; get; }
        int mesEvaReaEva { set; get; }
        int mesEvaReaRea { set; get; }
        string idsProAnuEvaRea { set; get; }
        /***********************************/
    }
}
