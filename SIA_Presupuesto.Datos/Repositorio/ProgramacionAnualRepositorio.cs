using Seguridad.Log;
using SIA_Presupuesto.Datos.Base;
using SIA_Presupuesto.Negocio.Contratos.Repositorio;
using SIA_Presupuesto.Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SIA_Presupuesto.Datos.Repositorio
{
    public class ProgramacionAnualRepositorio : Repositorio<ProgramacionAnual>, IProgramacionAnualRepositorio
    {
        public ProgramacionAnualRepositorio(IContexto contexto, IOcurrencia ocurrencia)
          : base(contexto, ocurrencia)
        {

        }

        public List<ProgramacionAnualPres> TraerListaProgramacionAnual(int anio)
        {
            List<ProgramacionAnualPres> lista = new List<ProgramacionAnualPres>();

            var contexto = this.UnidadTrabajo as IContexto;
            lista = contexto.TraerListaProgramacionAnual(anio).ToList();

            return lista;
        }

        public List<ProgramacionAnualPres> TraerListaProgramacionAnualAprobados(int anio)
        {
            List<ProgramacionAnualPres> lista = new List<ProgramacionAnualPres>();

            var contexto = this.UnidadTrabajo as IContexto;
            lista = contexto.TraerListaProgramacionAnualAprobados(anio).ToList();

            return lista;
        }

        public List<int> TraerListaProgramacionAnualAreas(int idProAnu)
        {
            List<int> lista = new List<int>();

            var contexto = this.UnidadTrabajo as IContexto;
            lista = contexto.TraerListaProgramacionAnualAreas(idProAnu).Select(s=> (Int32)s)
                .ToList();

            return lista;
        }

        public List<ConsolidadoPresupuesto> TraerConsolidadoPresupuestoPorDirecciones(int anio)
        {
            List<ConsolidadoPresupuesto> lista = new List<ConsolidadoPresupuesto>();

            var contexto = this.UnidadTrabajo as IContexto;
            lista = contexto.TraerConsolidadoPresupuestoPorDirecciones(anio)
                .ToList();

            return lista;
        }

        public List<ResumenPresupuestoPorSubdireccion> TraerResumenPresupuestoPorSubdirecciones(int anio, int idDireccion)
        {
            List<ResumenPresupuestoPorSubdireccion> lista = new List<ResumenPresupuestoPorSubdireccion>();

            var contexto = this.UnidadTrabajo as IContexto;
            lista = contexto.TraerResumenPresupuestoPorSubdirecciones(anio, idDireccion)
                .ToList();

            return lista;
        }

        public List<CalendarioPresupuestoAnual> TraerCalendarioPresupuestoAnual(int anio, int idFueFin, int idPresupuesto)
        {
            List<CalendarioPresupuestoAnual> lista = new List<CalendarioPresupuestoAnual>();

            var contexto = this.UnidadTrabajo as IContexto;
            lista = contexto.TraerCalendarioPresupuestoAnual(anio, idFueFin, idPresupuesto)
                .ToList();

            return lista;
        }

        public List<PresupuestoPorErradicacion> TraerPresupuestoPorErradicacion(int anio)
        {
            List<PresupuestoPorErradicacion> lista = new List<PresupuestoPorErradicacion>();

            var contexto = this.UnidadTrabajo as IContexto;
            lista = contexto.TraerResumenPresupuestoPorErradicacion(anio)
                .ToList();

            return lista;
        }

        public void GuardarDetalleProgramacionAnual(int idProAnu, string codigos, string usuario, bool indicaEliminacion)
        {
            var contexto = this.UnidadTrabajo as IContexto;
            contexto.AumentarLatencia(240);
            contexto.GuardarDetalleProgramacionAnual(idProAnu, codigos, usuario, indicaEliminacion);
        }
        public void GuardarDetalleProgramacionAnualDesdeRequerimientoAnual(int idProAnu, string idsReqBieSer, string usuario)
        {
            var contexto = this.UnidadTrabajo as IContexto;
            contexto.AumentarLatencia(240);
            contexto.GuardarDetalleProgramacionAnualDesdeRequerimientoAnual(idProAnu, idsReqBieSer, usuario);
        }

        public void GuardarDetalleProgramacionAnualGastosRecuerrentes(int idProAnu, string codigos, string usuario, bool indicaEliminacion)
        {
            var contexto = this.UnidadTrabajo as IContexto;
            contexto.AumentarLatencia(600);
            contexto.GuardarDetalleProgramacionAnualGastosRecuerrentes(idProAnu, codigos, usuario, indicaEliminacion);
        }

        public void GuardarDetalleProgramacionAnualRRHH(int idProAnu, string codigos, string usuario, bool indicaEliminacion)
        {
            var contexto = this.UnidadTrabajo as IContexto;
            contexto.AumentarLatencia(600);
            contexto.GuardarDetalleProgramacionAnualRRHH(idProAnu, codigos, usuario, indicaEliminacion);
        }

        public void GuardarDetalleReajusteRRHH(int idProAnu, int idReaMenPro, string codigos, string usuario, bool indicaEliminacion)
        {
            var contexto = this.UnidadTrabajo as IContexto;
            contexto.AumentarLatencia(600);
            contexto.GuardarDetalleReajusteRRHH(idProAnu, idReaMenPro, codigos, usuario, indicaEliminacion);
        }

        public List<ReporteProgramacionAnualExportaMasivoPres> TraerReporteProgramacionAnualExportaMasivo(string idsProAnu, int idMoneda)
        {
            List<ReporteProgramacionAnualExportaMasivoPres> lista = new List<ReporteProgramacionAnualExportaMasivoPres>();
            List<ReporteProgramacionAnualDetalleExportaMasivoPres> listaDetallada = new List<ReporteProgramacionAnualDetalleExportaMasivoPres>();

            var contexto = this.UnidadTrabajo as IContexto;
            lista = contexto.TraerReporteProgramacionAnualExportaMasivo(idsProAnu, idMoneda).ToList();
            listaDetallada = contexto.TraerReporteProgramacionAnualDetalleExportaMasivo(idsProAnu, idMoneda).ToList();
            int cantDetalle = 0;

            lista.ForEach(f =>
            {
                f.ListaReporteProgramacionAnualDetalleExportaMasivoPres = listaDetallada.FindAll(t => t.item == f.item && f.nivel == 3);
                f.posicion += cantDetalle;
                if (f.ListaReporteProgramacionAnualDetalleExportaMasivoPres != null)
                    cantDetalle += f.ListaReporteProgramacionAnualDetalleExportaMasivoPres.Count();
            });

            return lista;
        }

    }
}
