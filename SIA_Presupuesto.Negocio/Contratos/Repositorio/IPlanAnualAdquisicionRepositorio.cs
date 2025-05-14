using SIA_Presupuesto.Negocio.Contratos.Base;
using SIA_Presupuesto.Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Contratos.Repositorio
{
    public interface IPlanAnualAdquisicionRepositorio : IRepositorio<PlanAnualAdquisicion>
    {
        bool ActualizarDetallesPac(int idPaa, string nomUsuario);

        List<PlanAnualAdquisicionRequerimientoPres> TraerListaPlanAnualAdquisicionRequerimiento(int idPaa);
        List<RequerimientoBienServicioPendientePorCuentaPres> TraerListaRequerimientoBienServicioPendientePorCuenta(int idCueCon, int anio, int tipoRubro);
        List<ReportePlanAnualAdquisicionDetallePres> TraerReportePlanAnualAdquisicionDetalle(int idPaa, int? idFueFin);
        List<ReportePlanAnualAdquisicionDireccionPres> TraerReportePlanAnualAdquisicionDireccion(int idPaa, int? idDireccion, int? idFueFin);
        List<ReportePlanAnualAdquisicionExportaPres> TraerReportePlanAnualAdquisicionExporta(int idPaa, int? idDireccion, int? idFueFin);
    }
}
