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
    public interface IListaReajusteMensualPresupuestoVista : IListaBase
    {
        List<ReajusteMensualPresupuestoPres> listaDatosPrincipales { set; }

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

    }
}
