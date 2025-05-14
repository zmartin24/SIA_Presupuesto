using Seguridad.Log;
using SIA_Presupuesto.Datos.Base;
using SIA_Presupuesto.Negocio.Contratos.Repositorio;
using SIA_Presupuesto.Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Datos.Repositorio
{
    public class RequerimientoBienServicioDetalleRepositorio : Repositorio<RequerimientoBienServicioDetalle>, IRequerimientoBienServicioDetalleRepositorio
    {
        public RequerimientoBienServicioDetalleRepositorio(IContexto contexto, IOcurrencia ocurrencia)
          : base(contexto, ocurrencia)
        {

        }

        public List<RequerimientoBienServicioDetallePres> TraerListaRequerimientoBienServicioDetalle(int idReqBieSer)
        {
            List<RequerimientoBienServicioDetallePres> lista = new List<RequerimientoBienServicioDetallePres>();

            var contexto = this.UnidadTrabajo as IContexto;
            contexto.AumentarLatencia(1800);
            lista = contexto.TraerListaRequerimientoBienServicioDetalle(idReqBieSer).ToList();

            return lista;
        }

        public List<RequerimientoBienServicioDetallePres> TraerListaRequerimientoBienServicioDetalleDireccion(int idDireccion, int? idSubdireccion, int anio, int idMoneda)
        {
            List<RequerimientoBienServicioDetallePres> lista = new List<RequerimientoBienServicioDetallePres>();

            var contexto = this.UnidadTrabajo as IContexto;
            contexto.AumentarLatencia(1800);
            lista = contexto.TraerListaRequerimientoBienServicioDetalleDireccion(idDireccion, idSubdireccion, anio, idMoneda).ToList();

            return lista;
        }

        public List<RequerimientoBienServicioDetallePres> TraerListaRequerimientoBienServicioDetalleDireccionOperativos(int idDireccion, int anio, string tipo, int idMoneda)
        {
            List<RequerimientoBienServicioDetallePres> lista = new List<RequerimientoBienServicioDetallePres>();

            var contexto = this.UnidadTrabajo as IContexto;
            contexto.AumentarLatencia(1800);
            lista = contexto.TraerListaRequerimientoBienServicioDetalleDireccionOperativos(idDireccion, anio, tipo, idMoneda).ToList();

            return lista;
        }

        public List<RequerimientoBienServicioDetallePresExporta> TraerListaRequerimientoBienServicioDetalleDireccionExporta(int idDireccion, int anio)
        {
            List<RequerimientoBienServicioDetallePresExporta> lista = new List<RequerimientoBienServicioDetallePresExporta>(); 
            List<RequerimientoBienServicioDetalleExporta> listaDetallada = new List<RequerimientoBienServicioDetalleExporta>();

            var contexto = this.UnidadTrabajo as IContexto;
            contexto.AumentarLatencia(1800);
            lista = contexto.TraerListaRequerimientoBienServicioDetalleDireccionExporta(idDireccion, anio).ToList();
            listaDetallada = contexto.TraerListaRequerimientoBienServicioDetalleExporta(idDireccion, anio).ToList();
            int cantDetalle = 0;

            lista.ForEach(f =>
            {
                f.RequerimientoBienServicioDetalleExporta = listaDetallada.FindAll(t => t.item == f.item && f.nivel == 3);
                f.posicion += cantDetalle;
                if (f.RequerimientoBienServicioDetalleExporta != null)
                    cantDetalle += f.RequerimientoBienServicioDetalleExporta.Count();
            });

            return lista;
        }

        public List<RequerimientoBienServicioDetallePresExporta> TraerListaRequerimientoBienServicioDetalleDireccionAreaExporta(int idDireccion, int anio)
        {
            List<RequerimientoBienServicioDetallePresExporta> lista = new List<RequerimientoBienServicioDetallePresExporta>();
            List<RequerimientoBienServicioDetalleExporta> listaDetallada = new List<RequerimientoBienServicioDetalleExporta>();

            var contexto = this.UnidadTrabajo as IContexto;
            contexto.AumentarLatencia(1800);
            lista = contexto.TraerListaRequerimientoBienServicioDetalleDireccionAreaExporta(idDireccion, anio).ToList();
            listaDetallada = contexto.TraerListaRequerimientoBienServicioDetalleAreaExporta(idDireccion, anio).ToList();
            int cantDetalle = 0;

            lista.ForEach(f =>
            {
                f.RequerimientoBienServicioDetalleExporta = listaDetallada.FindAll(t => t.item == f.item && f.nivel == 3);
                f.posicion += cantDetalle;
                if (f.RequerimientoBienServicioDetalleExporta != null)
                    cantDetalle += f.RequerimientoBienServicioDetalleExporta.Count();
            });

            return lista;
        }
        public List<ReporteRequerimientoBienServicioExportaPres> TraerReporteRequerimientoBienServicioExporta(int idReqBieSer)
        {
            List<ReporteRequerimientoBienServicioExportaPres> lista = new List<ReporteRequerimientoBienServicioExportaPres>();
            List<ReporteRequerimientoBienServicioDetalleExportaPres> listaDetallada = new List<ReporteRequerimientoBienServicioDetalleExportaPres>();

            var contexto = this.UnidadTrabajo as IContexto;
            contexto.AumentarLatencia(1800);
            lista = contexto.TraerReporteRequerimientoBienServicioExporta(idReqBieSer).ToList();
            listaDetallada = contexto.TraerReporteRequerimientoBienServicioDetalleExporta(idReqBieSer).ToList();
            int cantDetalle = 0;

            lista.ForEach(f =>
            {
                f.ListaReporteRequerimientoBienServicioDetalleExportaPres = listaDetallada.FindAll(t => t.item == f.item && f.nivel == 3);
                f.posicion += cantDetalle;
                if (f.ListaReporteRequerimientoBienServicioDetalleExportaPres != null)
                    cantDetalle += f.ListaReporteRequerimientoBienServicioDetalleExportaPres.Count();
            });

            return lista;
        }
    }
}
