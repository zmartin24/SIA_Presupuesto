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
    public interface IListaPresupuestoAnualVista : IListaBase
    {
        List<ProgramacionAnualPres> listaDatosPrincipales { set; }

        //RequerimientoBienServicio RequerimientoBienServicio { get; }

        //Requerimientos Generales
        List<Anio> listaAnios { set; }

        List<Anio> listaAniosRep { set; }

        List<Direccion> listaDireccionesReporte { set; }

        int anioPresentacion { set; get; }

        int anioReporte { set; get; }

        List<Anio> listaAniosCal { set; }

        List<ProgramacionAnualPres> listaProgramacionAnual { set; }

        List<FuenteFinanciamiento> listaFuenteFinanciamiento { set; }

        int anioCal { set; get; }

        int idFueFinCal { set; get; }

        int idProAnuCal { set; get; }

        /*Pop Exportar Programacion Anual*/
        List<Moneda> listaMonedaExpProAnu { set; }
        string desPresupuesto { set; }
        
        string desGrupoPresupuesto { set; }
        int idMonedaExpProAnu { set; get; }
        int idProAnuExp { set; get; }

        /*Pop Exportar Programacion Anual Masivo*/
        List<Anio> listaAnioPopExpProAnuMas { set; }
        List<Moneda> listaMonedaPopExpProAnuMas { set; }
        List<ProgramacionAnualPres> listaProgramacionAnualPopExpProAnuMas { set; }
        int anioPopExpProAnuMas { set; get; }
        int idMonedaPopExpProAnuMas { set; get; }
        string idsProAnuMas { set; get; }

    }
}
