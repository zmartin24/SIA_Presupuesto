using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WebForm.Vista.Base;
using System;
using System.Collections.Generic;
using Utilitario.Util;

namespace SIA_Presupuesto.WebForm.Vista
{
    public interface IListaRequerimientoRecursoHumanoVista : IListaBase
    {
        List<RequerimientoRecursoHumanoPres> listaDatosPrincipales { set; }
        
        List<Anio> listaAnios { set; }

        List<Moneda> listaMonedas { set; }

        List<Direccion> listaDirecciones { set; }
        List<Direccion> listaDireccionesReporte { set; }

        List<Subdireccion> listaSubdirecciones { set; }
        List<Subdireccion> listaSubdireccionesReporte { set; }

        List<Area> listaAreas { set; }

        int idMoneda { set; get; }

        int anio { set; get; }

        int anioPresentacion { set; get; }

        string descripcion { set; get; }

        DateTime fechaEmision { set; get; }

        int idDireccion { set; get; }

        int idSubdireccion { set; get; }

        int idArea { set; get; }
        List<Periodo> listaAnioReporte { set; }
        int anioReporte { set; get; }

        List<Direccion> listaDireccionesReporteImp { set;}
        List<Periodo> listaAnioReporteImp { set; }
        List<Subdireccion> listaSubdireccionesReporteImp { set;}
        List<Moneda> listaMonedasReporteImp { set; }
        int anioReporteImp { set; get; }
        int idMonedaReporteImp { set; get; }
        int idDireccionReporteImp { set; get; }
        int idSubdireccionReporteImp { set; get; }
    }
}
