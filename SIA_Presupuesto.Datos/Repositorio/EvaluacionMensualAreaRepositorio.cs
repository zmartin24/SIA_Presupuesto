using Seguridad.Log;
using SIA_Presupuesto.Datos.Base;
using SIA_Presupuesto.Negocio.Contratos.Repositorio;
using SIA_Presupuesto.Negocio.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace SIA_Presupuesto.Datos.Repositorio
{
    public class EvaluacionMensualAreaRepositorio : Repositorio<EvaluacionMensualArea>, IEvaluacionMensualAreaRepositorio
    {
        public EvaluacionMensualAreaRepositorio(IContexto contexto, IOcurrencia ocurrencia)
          : base(contexto, ocurrencia)
        {

        }

        public List<EvaluacionMensualAreaPres> TraerListaEvaluacionMensualArea(int idEvaMenPro)
        {
            List<EvaluacionMensualAreaPres> lista = new List<EvaluacionMensualAreaPres>();
            List<EvaluacionMensualDetallePres> listaDetallada = new List<EvaluacionMensualDetallePres>();

            var contexto = this.UnidadTrabajo as IContexto;
            lista = contexto.TraerListaEvaluacionMensualArea(idEvaMenPro).ToList();
            listaDetallada = contexto.TraerListaEvaluacionMensualDetallePorPresupuesto(idEvaMenPro).ToList();

            lista.ForEach(f => f.EvaluacionMensualDetallePres = listaDetallada.FindAll(t => t.item == f.item));

            return lista;
        }

        public List<EvaluacionMensualAreaExporta> TraerListaEvaluacionMensualExporta(int idEvaMenPro)
        {
            List<EvaluacionMensualAreaExporta> lista = new List<EvaluacionMensualAreaExporta>();
            List<EvaluacionMensualDetallePres> listaDetallada = new List<EvaluacionMensualDetallePres>();

            var contexto = this.UnidadTrabajo as IContexto;
            lista = contexto.TraerListaEvaluacionMensualAreaExporta(idEvaMenPro).ToList();
            listaDetallada = contexto.TraerListaEvaluacionMensualDetallePorPresupuesto(idEvaMenPro).ToList();
            int cantDetalle = 0;

            //lista.ForEach(f => f.EvaluacionMensualDetallePres = listaDetallada.FindAll(t => t.item == f.item && f.nivel == 3));
            lista.ForEach(f =>
            {
                f.EvaluacionMensualDetallePres = listaDetallada.FindAll(t => t.item == f.item && f.nivel == 3);
                f.posicion += cantDetalle;
                if (f.EvaluacionMensualDetallePres != null)
                    cantDetalle += f.EvaluacionMensualDetallePres.Count();
            });

            return lista;
        }

        public List<EvaluacionReajusteMensualAreaExporta> TraerListaEvaluacionReajusteMensualAreaExporta(int idProAnu, int anio, int mesRea, int mesEva)
        {
            List<EvaluacionReajusteMensualAreaExporta> lista = new List<EvaluacionReajusteMensualAreaExporta>();
            List<EvaluacionReajusteMensualDetallePorPresupuesto> listaDetallada = new List<EvaluacionReajusteMensualDetallePorPresupuesto>();

            var contexto = this.UnidadTrabajo as IContexto;
            lista = contexto.TraerListaEvaluacionReajusteMensualAreaExporta(idProAnu, anio, mesRea, mesEva).ToList();
            listaDetallada = contexto.TraerListaEvaluacionReajusteMensualDetallePorPresupuesto(idProAnu, anio, mesRea, mesEva).ToList();
            int cantDetalle = 0;
            lista.ForEach(f =>
            {
                f.EvaluacionReajusteMensualDetallePorPresupuesto = listaDetallada.FindAll(t => t.item == f.item && f.nivel == 3);
                f.posicion += cantDetalle;
                if (f.EvaluacionReajusteMensualDetallePorPresupuesto != null)
                    cantDetalle += f.EvaluacionReajusteMensualDetallePorPresupuesto.Count();
            });

            return lista;
        }

        public List<EvaluacionReajusteMensualAreaExporta> TraerListaEvaluacionReajusteMensualAreaExporta(string idsProAnu, int anio, int mesRea, int mesEva)
        {
            List<EvaluacionReajusteMensualAreaExporta> lista = new List<EvaluacionReajusteMensualAreaExporta>();
            List<EvaluacionReajusteMensualDetallePorPresupuesto> listaDetallada = new List<EvaluacionReajusteMensualDetallePorPresupuesto>();

            var contexto = this.UnidadTrabajo as IContexto;
            lista = contexto.TraerListaEvaluacionReajusteMensualAreaExportaMasivo(idsProAnu, anio, mesRea, mesEva).ToList();
            listaDetallada = contexto.TraerListaEvaluacionReajusteMensualDetallePorPresupuestoMasivo(idsProAnu, anio, mesRea, mesEva).ToList();
            int cantDetalle = 0;
            lista.ForEach(f =>

            {
                f.EvaluacionReajusteMensualDetallePorPresupuesto = listaDetallada.FindAll(t => t.item == f.item && f.nivel == 3);
                f.posicion += cantDetalle;
                if (f.EvaluacionReajusteMensualDetallePorPresupuesto != null)
                    cantDetalle += f.EvaluacionReajusteMensualDetallePorPresupuesto.Count();
            });

            return lista;
        }

        public List<EvaluacionReajusteMensualAreaExporta> TraerListaEvaluacionReajusteMensualAreaExporta2(int idProAnu, int anio, int mesRea, int mesEva)
        {
            List<EvaluacionReajusteMensualAreaExporta> lista = new List<EvaluacionReajusteMensualAreaExporta>();
            List<EvaluacionReajusteMensualDetallePorPresupuesto> listaDetallada = new List<EvaluacionReajusteMensualDetallePorPresupuesto>();

            var contexto = this.UnidadTrabajo as IContexto;
            lista = contexto.TraerListaEvaluacionReajusteMensualAreaExporta(idProAnu, anio, mesRea, mesEva).ToList();
            //listaDetallada = contexto.TraerListaEvaluacionReajusteMensualDetallePorPresupuesto(anio, mesRea, mesEva).ToList();

            lista.ForEach(f => f.EvaluacionReajusteMensualDetallePorPresupuesto = new List<EvaluacionReajusteMensualDetallePorPresupuesto>());

            return lista;
        }
        public List<ReporteEvaluacionMensualExportaPres> TraerReporteEvaluacionMensualExporta(int idEvaMenPro, int idMoneda)
        {
            List<ReporteEvaluacionMensualExportaPres> lista = new List<ReporteEvaluacionMensualExportaPres>();
            List<ReporteEvaluacionMensualDetalleExportaPres> listaDetallada = new List<ReporteEvaluacionMensualDetalleExportaPres>();

            var contexto = this.UnidadTrabajo as IContexto;
            contexto.AumentarLatencia(240);

            lista = contexto.TraerReporteEvaluacionMensualExporta(idEvaMenPro, idMoneda).ToList();
            listaDetallada = contexto.TraerReporteEvaluacionMensualDetalleExporta(idEvaMenPro, idMoneda).ToList();
            int cantDetalle = 0;

            lista.ForEach(f =>
            {
                f.ListaReporteEvaluacionMensualDetalleExportaPres = listaDetallada.FindAll(t => t.item == f.item && f.nivel == 3);
                f.posicion += cantDetalle;
                if (f.ListaReporteEvaluacionMensualDetalleExportaPres != null)
                    cantDetalle += f.ListaReporteEvaluacionMensualDetalleExportaPres.Count();
            });

            return lista;
        }
        public List<ReporteEvaluacionReajusteMensualExportaPres> TraerReporteEvaluacionReajusteMensualExporta(int idProAnu, int anio, int mesRea, int mesEva, int idMoneda)
        {
            List<ReporteEvaluacionReajusteMensualExportaPres> lista = new List<ReporteEvaluacionReajusteMensualExportaPres>();
            List<ReporteEvaluacionReajusteMensualDetalleExportaPres> listaDetallada = new List<ReporteEvaluacionReajusteMensualDetalleExportaPres>();

            var contexto = this.UnidadTrabajo as IContexto;
            lista = contexto.TraerReporteEvaluacionReajusteMensualExporta(idProAnu, anio, mesRea, mesEva, idMoneda).ToList();
            listaDetallada = contexto.TraerReporteEvaluacionReajusteMensualDetalleExporta(idProAnu, anio, mesRea, mesEva, idMoneda).ToList();
            int cantDetalle = 0;
            lista.ForEach(f =>
            {
                f.ListaReporteEvaluacionReajusteMensualDetalleExportaPres = listaDetallada.FindAll(t => t.item == f.item && f.nivel == 3);
                f.posicion += cantDetalle;
                if (f.ListaReporteEvaluacionReajusteMensualDetalleExportaPres != null)
                    cantDetalle += f.ListaReporteEvaluacionReajusteMensualDetalleExportaPres.Count();
            });

            return lista;
        }
    }
}
