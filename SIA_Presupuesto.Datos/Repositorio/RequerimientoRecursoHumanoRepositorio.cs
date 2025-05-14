using Seguridad.Log;
using Seguridad.Modelo;
using SIA_Presupuesto.Datos.Base;
using SIA_Presupuesto.Negocio.Contratos.Repositorio;
using SIA_Presupuesto.Negocio.Entidades;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Utilitario.Util;

namespace SIA_Presupuesto.Datos.Repositorio
{
    public class RequerimientoRecursoHumanoRepositorio : Repositorio<RequerimientoRecursoHumano>, IRequerimientoRecursoHumanoRepositorio
    {
        public RequerimientoRecursoHumanoRepositorio(IContexto contexto, IOcurrencia ocurrencia)
          : base(contexto, ocurrencia)
        {

        }
        #region Operaciones
        public bool AnularRequerimientoRecursoHumano(int idReqRecHum, string nomUsuario)
        {
            var contexto = this.UnidadTrabajo as IContexto;
            return (bool)contexto.AnularRequerimientoRecursoHumano(idReqRecHum, nomUsuario).FirstOrDefault();
        }
        #endregion
        #region Listas y Busquedas
        public RequerimientoRecursoHumanoPres BuscarRequerimientoRecursoHumano(int idReqRecHum)
        {
            var contexto = this.UnidadTrabajo as IContexto;
            var query = contexto.BuscarRequerimientoRecursoHumano(idReqRecHum).FirstOrDefault();

            return query;
        }
        public List<RequerimientoRecursoHumanoPres> TraerListaRequerimientoRecursoHumano(int anio, int idUsuario)
        {
            List<RequerimientoRecursoHumanoPres> lista = new List<RequerimientoRecursoHumanoPres>();

            var contexto = this.UnidadTrabajo as IContexto;
            lista = contexto.TraerListaRequerimientoRecursoHumano(anio, idUsuario).ToList();

            return lista;
        }
        public List<RequerimientoRecursoHumanoDetallePres> TraerListaRequerimientoRecursoHumanoDetalle(int idReqRecHum)
        {
            var contexto = this.UnidadTrabajo as IContexto;

            return contexto.TraerListaRequerimientoRecursoHumanoDetalle(idReqRecHum).ToList();
        }
        #endregion

        #region Reporte
        public List<ReporteRequerimientoRRHHPres> TraerReporteRequerimientoRRHH(int anio, int idDireccion, int idReqRecHum)
        {
            List<ReporteRequerimientoRRHHPres> lista = new List<ReporteRequerimientoRRHHPres>();
            var contexto = this.UnidadTrabajo as IContexto;
            contexto.AumentarLatencia(120);
            lista = contexto.TraerReporteRequerimientoRRHH(anio, idDireccion, idReqRecHum).ToList();
            return lista;
        }
        public List<ReporteRequerimientoRRHHPres> TraerReporteRequerimientoRRHHDireccionArea(int anio, int idDireccion, int idSubdireccion, int idReqRecHum)
        {
            List<ReporteRequerimientoRRHHPres> lista = new List<ReporteRequerimientoRRHHPres>();
            var contexto = this.UnidadTrabajo as IContexto;
            contexto.AumentarLatencia(120);
            lista = contexto.TraerReporteRequerimientoRRHHDireccionArea(anio, idDireccion, idSubdireccion, idReqRecHum).ToList();
            return lista;
        }
        public List<ReporteRequerimientoRRHHDireccionImportePres> TraerReporteRequerimientoRRHHDireccionImporte(int anio, int idDireccion, int idSubdireccion, int idReqRecHum, int idMoneda)
        {
            List<ReporteRequerimientoRRHHDireccionImportePres> lista = new List<ReporteRequerimientoRRHHDireccionImportePres>();
            var contexto = this.UnidadTrabajo as IContexto;
            contexto.AumentarLatencia(120);
            lista = contexto.TraerReporteRequerimientoRRHHDireccionImporte(anio, idDireccion, idSubdireccion, idReqRecHum, idMoneda).ToList();
            return lista;
        }
        #endregion
    }
}
