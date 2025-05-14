using Seguridad.Log;
using SIA_Presupuesto.Datos.Base;
using SIA_Presupuesto.Negocio.Contratos.Repositorio;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Datos.Repositorio
{
    public class ProgramacionAnualAreaRepositorio : Repositorio<ProgramacionAnualArea>, IProgramacionAnualAreaRepositorio
    {
        public ProgramacionAnualAreaRepositorio(IContexto contexto, IOcurrencia ocurrencia)
          : base(contexto, ocurrencia)
        {

        }
        #region Operaciones
        public bool AnularProgramacionAnualArea(int idProAnuArea, string nomUsuario)
        {
            bool res = false;
            var contexto = this.UnidadTrabajo as IContexto;
            contexto.AumentarLatencia(120);
            res = (bool)contexto.AnularProgramacionAnualArea(idProAnuArea, nomUsuario).ToList().FirstOrDefault();
            return res;
        }

        public bool AnularProgramacionAnualAreaPorCuenta(int idProAnu, int idCueCon, int idArea, string nomUsuario)
        {
            bool res = false;
            var contexto = this.UnidadTrabajo as IContexto;
            contexto.AumentarLatencia(120);
            res = (bool)contexto.AnularProgramacionAnualAreaPorCuenta(idProAnu, idCueCon, idArea, nomUsuario).ToList().FirstOrDefault();
            return res;
        }

        #endregion
        #region Listas
        public List<ProgramacionAnualAreaPres> TraerListaProgramacionAnualArea(int idProAnu)
        {
            List<ProgramacionAnualAreaPres> lista = new List<ProgramacionAnualAreaPres>();
            List <ProgramacionAnualDetallePres> listaDetallada = new List<ProgramacionAnualDetallePres>();

            var contexto = this.UnidadTrabajo as IContexto;
            contexto.AumentarLatencia(600);
            lista = contexto.TraerListaProgramacionAnualArea(idProAnu).ToList();
            listaDetallada = contexto.TraerListaProgramacionAnualDetallePorPresupuestoPres(idProAnu).ToList();

            lista.ForEach(f => f.ProgramacionAnualDetallePres = listaDetallada.FindAll(t => t.item == f.item));

            return lista;
        }

        public List<ProgramacionAnualAreaExporta> TraerListaProgramacionAnualExporta(int idProAnu)
        {
            List<ProgramacionAnualAreaExporta> lista = new List<ProgramacionAnualAreaExporta>();
            List<ProgramacionAnualDetallePres> listaDetallada = new List<ProgramacionAnualDetallePres>();

            var contexto = this.UnidadTrabajo as IContexto;
            lista = contexto.TraerListaProgramacionAnualAreaExporta(idProAnu).ToList();
            listaDetallada = contexto.TraerListaProgramacionAnualDetallePorPresupuesto(idProAnu).ToList();
            int cantDetalle = 0;

            lista.ForEach(f => 
            {
                f.ProgramacionAnualDetallePres = listaDetallada.FindAll(t => t.item == f.item && f.nivel == 3);
                f.posicion += cantDetalle;
                if (f.ProgramacionAnualDetallePres != null)
                    cantDetalle += f.ProgramacionAnualDetallePres.Count();
            });

            return lista;
        }
        public List<ReporteProgramacionAnualExportaPres> TraerReporteProgramacionAnualExporta(int idProAnu, int idMoneda)
        {
            List<ReporteProgramacionAnualExportaPres> lista = new List<ReporteProgramacionAnualExportaPres>();
            List<ReporteProgramacionAnualDetalleExportaPres> listaDetallada = new List<ReporteProgramacionAnualDetalleExportaPres>();

            var contexto = this.UnidadTrabajo as IContexto;
            lista = contexto.TraerReporteProgramacionAnualExporta(idProAnu, idMoneda).ToList();
            listaDetallada = contexto.TraerReporteProgramacionAnualDetalleExporta(idProAnu, idMoneda).ToList();
            int cantDetalle = 0;

            lista.ForEach(f =>
            {
                f.ListaReporteProgramacionAnualDetalleExportaPres = listaDetallada.FindAll(t => t.item == f.item && f.nivel == 3);
                f.posicion += cantDetalle;
                if (f.ListaReporteProgramacionAnualDetalleExportaPres != null)
                    cantDetalle += f.ListaReporteProgramacionAnualDetalleExportaPres.Count();
            });

            return lista;
        }
        #endregion

    }
}
