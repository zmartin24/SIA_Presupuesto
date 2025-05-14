using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WebForm.Helper;
using SIA_Presupuesto.WebForm.Vista.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitario.Util;

namespace SIA_Presupuesto.WebForm.Vista
{
    public interface IListaRequerimientoMensualBienServicioVista : IListaBase
    {
        List<RequerimientoMensualBienServicioPres> listaDatosPrincipales { set; }

        #region Listado Requerimiento Mensual

        List<Anio> listaAniosListado { set; }

        List<Mes> listaMesListado { set; }

        int anioListado { set; get; }

        int mesListado { set; get; }
        List<RequerimientoBienServicio> listaRequerimientoBienServicio { set; }

        #endregion 

        #region Registro Requerimiento Mensual

        List<Direccion> listaDirecciones { set; }

        List<Subdireccion> listaSubdirecciones { set; }

        List<Area> listaAreas { set; }

        List<Predeterminado> listaTipoRequerimiento { set; }

        List<Moneda> listaMonedas { set; }

        List<Mes> listaMes { set; }
        int idReqMenBieSer { set; get; }
        int idDireccion { set; get; }

        int idSubdireccion { set; get; }

        int idArea { set; get; }

        int idTipoRequerimiento { set; get; }

        int idMoneda { set; get; }

        int anio { set; get; }

        int mes { set; get; }

        string descripcion { set; get; }
                
        int estado { set; get; }

        bool tieneDetalles { set; get; }

        DateTime fechaEmision { set; get; }
        string idsReqBieSer { set; get; }

        #endregion

        #region Reporte Requerimiento Mensual

        List<Direccion> listaDireccionesReporte { set; }

        List<Subdireccion> listaSubdireccionesReporte { set; }

        List<Predeterminado> listaTipoRequerimientoReporte { set; }

        List<Anio> listaAniosReporte { set; }

        List<Mes> listaMesReporte { set; }

        int idDireccionReporte { set; get; }

        int idSubdireccionReporte { set; get; }

        string tipoReporte { set; get; }

        int idTipoRequerimientoReporte { set; get; }

        int anioReporte { set; get; }

        int mesReporte { set; get; }

        #endregion
    }
}