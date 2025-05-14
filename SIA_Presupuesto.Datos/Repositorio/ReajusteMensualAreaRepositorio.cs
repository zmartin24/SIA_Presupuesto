using Seguridad.Log;
using SIA_Presupuesto.Datos.Base;
using SIA_Presupuesto.Negocio.Contratos.Repositorio;
using SIA_Presupuesto.Negocio.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace SIA_Presupuesto.Datos.Repositorio
{
    public class ReajusteMensualAreaRepositorio : Repositorio<ReajusteMensualArea>, IReajusteMensualAreaRepositorio
    {
        public ReajusteMensualAreaRepositorio(IContexto contexto, IOcurrencia ocurrencia)
          : base(contexto, ocurrencia)
        {

        }

        public List<ReajusteMensualAreaPres> TraerListaReajusteMensualArea(int idEvaMenPro)
        {
            List<ReajusteMensualAreaPres> lista = new List<ReajusteMensualAreaPres>();
            List<ReajusteMensualDetallePres> listaDetallada = new List<ReajusteMensualDetallePres>();

            var contexto = this.UnidadTrabajo as IContexto;
            lista = contexto.TraerListaReajusteMensualArea(idEvaMenPro).ToList();
            listaDetallada = contexto.TraerListaReajusteMensualDetallePorPresupuestoPres(idEvaMenPro).ToList();

            lista.ForEach(f => f.ReajusteMensualDetallePres = listaDetallada.FindAll(t => t.item == f.item));

            return lista;
        }

        public List<ReajusteMensualAreaExporta> TraerListaReajusteMensualExporta(int idEvaMenPro)
        {
            List<ReajusteMensualAreaExporta> lista = new List<ReajusteMensualAreaExporta>();
            List<ReajusteMensualDetallePres> listaDetallada = new List<ReajusteMensualDetallePres>();

            var contexto = this.UnidadTrabajo as IContexto;
            lista = contexto.TraerListaReajusteMensualAreaExporta(idEvaMenPro).ToList();
            listaDetallada = contexto.TraerListaReajusteMensualDetallePorPresupuesto(idEvaMenPro).ToList();
            int cantDetalle = 0;

            lista.ForEach(f =>
            {
                f.ReajusteMensualDetallePres = listaDetallada.FindAll(t => t.item == f.item && f.nivel == 3);
                f.posicion += cantDetalle;
                if (f.ReajusteMensualDetallePres != null)
                    cantDetalle += f.ReajusteMensualDetallePres.Count();
            });

            return lista;
        }
        public List<ReporteReajusteMensualExportaPres> TraerReporteReajusteMensualExporta(int idReaMenPro, int idMoneda)
        {
            List<ReporteReajusteMensualExportaPres> lista = new List<ReporteReajusteMensualExportaPres>();
            List<ReporteReajusteMensualDetalleExportaPres> listaDetallada = new List<ReporteReajusteMensualDetalleExportaPres>();

            var contexto = this.UnidadTrabajo as IContexto;
            lista = contexto.TraerReporteReajusteMensualExporta(idReaMenPro, idMoneda).ToList();
            listaDetallada = contexto.TraerReporteReajusteMensualDetalleExporta(idReaMenPro, idMoneda).ToList();
            int cantDetalle = 0;

            lista.ForEach(f =>
            {
                f.ListaReporteReajusteMensualDetalleExportaPres = listaDetallada.FindAll(t => t.item == f.item && f.nivel == 3);
                f.posicion += cantDetalle;
                if (f.ListaReporteReajusteMensualDetalleExportaPres != null)
                    cantDetalle += f.ListaReporteReajusteMensualDetalleExportaPres.Count();
            });

            return lista;
        }
    }
}
