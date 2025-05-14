using SIA_Presupuesto.Negocio.Contratos.Base;
using SIA_Presupuesto.Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Contratos.Repositorio
{
    public interface IPlanAnualAdquisicionRequerimientoRepositorio : IRepositorio<PlanAnualAdquisicionRequerimiento>
    {
        List<RequerimientoBienServicio> TraerListaRequerimientoBienServicioPendiente(int idPaa);
        List<RequerimientoBienServicioDetalle> TraerListaRequerimientoBienServicioDetallePendiente(int idReqBieSer);
        List<RequerimientoBienServicioDetalleMes> TraerListaRequerimientoBienServicioDetalleMesPendiente(int idReqBieSerDet, int tipoRubro);
        RequerimientoBienServicio TraerRequerimientoPendiente(int idReq);
        List<PlanAnualAdquisicionReqPres> TraerListaPlanAnualAdquisicionReq(int idPaa);
        List<PlanAnualAdquisicionReqDetallePres> TraerListaPlanAnualAdquisicionReqDetalle(int idPaaReq);
    }
}
