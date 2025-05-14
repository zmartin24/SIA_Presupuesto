using SIA_Presupuesto.Negocio.Contratos.Base;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Contratos.Servicios
{
    public interface IPlanAnualAdquisicionServicio : IServicio
    {
        #region Operaciones

        Resultado Nuevo(PlanAnualAdquisicion planAnualAdquisicion);
        Resultado NuevoDetalle(PlanAnualAdquisicionDetalle planAnualAdquisicionDetalle);
        Resultado NuevoDetalleMasivo(PlanAnualAdquisicion planAnualAdquisicion, bool actualizaArea);
        Resultado NuevoPaaReq(PlanAnualAdquisicionRequerimiento planAnualAdquisicionRequerimiento);
        Resultado NuevoPaaDetMes(PlanAnualAdquisicionDetalleMes planAnualAdquisicionDetalleMes, bool actualizaArea);
        Resultado NuevoDetalleMasivoPorCuentas(PlanAnualAdquisicion planAnualAdquisicion, List<RequerimientoBienServicioPendientePorCuentaPres> requerimientoPendientePorCuentaPres);
        Resultado NuevoDetalleMasivoPorCuentas(PlanAnualAdquisicion planAnualAdquisicion, List<RequerimientoBienServicioPendientePorCuentaPres> requerimientoPendientePorCuentaPres, PlanAnualAdquisicionDetallePoco planAnualAdquisicionDetallePoco);

        Resultado Modificar(PlanAnualAdquisicion planAnualAdquisicion);
        Resultado ModificarSinClonar(PlanAnualAdquisicion planAnualAdquisicion);
        Resultado ModificarDetalles(PlanAnualAdquisicionDetalle planAnualAdquisicionDetalle);
        Resultado ModificarDetallesSinClonar(PlanAnualAdquisicionDetalle planAnualAdquisicionDetalle);
        Resultado ModificarPaaReq(PlanAnualAdquisicionRequerimiento planAnualAdquisicionRequerimiento);
        Resultado ModificarPaaDetMes(PlanAnualAdquisicionDetalleMes planAnualAdquisicionDetalleMes, bool actualizaArea);

        Resultado AnularPaaReq(PlanAnualAdquisicionRequerimiento planAnualAdquisicionRequerimiento, string usuario);
        Resultado AnularPaaReqPres(PlanAnualAdquisicionRequerimientoPres planAnualAdquisicionRequerimientoPres, string usuario); 
        Resultado AnularDetalle(PlanAnualAdquisicionDetalle planAnualAdquisicionDetalle, string usuario);
        Resultado Anular(PlanAnualAdquisicion planAnualAdquisicion, string usuario);
        bool ActualizarDetallesPac(int idPaa, string nomUsuario);
        #endregion

        #region Busqueda y listas
        PlanAnualAdquisicion Buscar(int idPaa);
        PlanAnualAdquisicionRequerimiento BuscarReqPorCodigo(int idPaaReq);
        PlanAnualAdquisicionRequerimiento BuscarReqPorDescripcion_Area(int idPaa, string descripcion, int idArea);
        PlanAnualAdquisicionDetalle BuscarDetallePorCodigo(int idPaaDet);
        PlanAnualAdquisicionDetalle BuscarDetallePorVarios(int idPaaReq, int idCueCon, string descripcion, int idUnidad, decimal precio);
        List<PlanAnualAdquisicion> listarTodosActivos();
        List<PlanAnualAdquisicionRequerimientoPres> TraerListaPlanAnualAdquisicionRequerimiento(int idPaa);
        PlanAnualAdquisicionDetalleMes BuscarPorCodigoPaaDetalleMes(int idPaaDet, int mes);
        decimal BuscarImporteDetalle(int idPaaDet, decimal precio);
        List<RequerimientoBienServicioPendientePorCuentaPres> TraerListaRequerimientoBienServicioPendientePorCuenta(int idCueCon, int anio, int tipoRubro);
        List<PlanAnualAdquisicionReqPres> TraerListaPlanAnualAdquisicionReq(int idPaa);
        List<PlanAnualAdquisicionReqDetallePres> TraerListaPlanAnualAdquisicionReqDetalle(int idPaaReq);
        #endregion
        #region Reporte
        List<ReportePlanAnualAdquisicionDetallePres> TraerReportePlanAnualAdquisicionDetalle(int idPaa, int? idFueFin);
        List<ReportePlanAnualAdquisicionDireccionPres> TraerReportePlanAnualAdquisicionDireccion(int idPaa, int? idDireccion, int? idFueFin);
        List<ReportePlanAnualAdquisicionExportaPres> TraerReportePlanAnualAdquisicionExporta(int idPaa, int? idDireccion, int? idFueFin);

        #endregion
    }
}
