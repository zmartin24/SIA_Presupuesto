using Seguridad.Log;
using SIA_Presupuesto.Datos.Base;
using SIA_Presupuesto.Negocio.Contratos.Repositorio;
using SIA_Presupuesto.Negocio.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace SIA_Presupuesto.Datos.Repositorio
{
    public class PlanAnualAdquisicionRepositorio : Repositorio<PlanAnualAdquisicion>, IPlanAnualAdquisicionRepositorio
    {
        private IContexto contexto;
        public PlanAnualAdquisicionRepositorio(IContexto contexto, IOcurrencia ocurrencia)
          : base(contexto, ocurrencia)
        {
            this.contexto = contexto;
        }

        #region Operaciones
        public bool ActualizarDetallesPac(int idPaa, string nomUsuario)
        {
            bool res = false;
            var contexto = this.UnidadTrabajo as IContexto;
            contexto.AumentarLatencia(600);
            res = (bool)contexto.ActualizarDetallesPac(idPaa, nomUsuario).ToList().FirstOrDefault();
            return res;
        }
        #endregion

        #region Listas 
        public List<PlanAnualAdquisicionRequerimientoPres> TraerListaPlanAnualAdquisicionRequerimiento(int idPaa)
        {
            List<PlanAnualAdquisicionRequerimientoPres> lista = new List<PlanAnualAdquisicionRequerimientoPres>();
            List<PlanAnualAdquisicionDetallePres> listaDetallada = new List<PlanAnualAdquisicionDetallePres>();

            var contexto = this.UnidadTrabajo as IContexto;
            lista = contexto.TraerListaPlanAnualAdquisicionRequerimiento(idPaa).ToList();
            listaDetallada = contexto.TraerListaPlanAnualAdquisicionDetalle(idPaa).ToList();

            lista.ForEach(f => f.PlanAnualAdquisicionDetallePres = listaDetallada.FindAll(t => t.item == f.item));

            return lista;
        }
        public List<RequerimientoBienServicioPendientePorCuentaPres> TraerListaRequerimientoBienServicioPendientePorCuenta(int idCueCon, int anio, int tipoRubro)
        {
            return contexto.TraerListaRequerimientoBienServicioPendientePorCuenta(idCueCon, anio, tipoRubro).ToList();
        }
        public List<ReportePlanAnualAdquisicionDetallePres> TraerReportePlanAnualAdquisicionDetalle(int idPaa, int? idFueFin)
        {
            return contexto.TraerReportePlanAnualAdquisicionDetalle(idPaa, idFueFin).ToList();
        }
        public List<ReportePlanAnualAdquisicionDireccionPres> TraerReportePlanAnualAdquisicionDireccion(int idPaa, int? idDireccion, int? idFueFin)
        {
            return contexto.TraerReportePlanAnualAdquisicionDireccion(idPaa, idDireccion, idFueFin).ToList();
        }
        public List<ReportePlanAnualAdquisicionExportaPres> TraerReportePlanAnualAdquisicionExporta(int idPaa, int? idDireccion, int? idFueFin)
        {
            return contexto.TraerReportePlanAnualAdquisicionExporta(idPaa, idDireccion, idFueFin).ToList();
        }
        #endregion
    }
}
