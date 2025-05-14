using Seguridad.Log;
using SIA_Presupuesto.Datos.Base;
using SIA_Presupuesto.Negocio.Contratos.Repositorio;
using SIA_Presupuesto.Negocio.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace SIA_Presupuesto.Datos.Repositorio
{
    public class PlanAnualAdquisicionRequerimientoRepositorio : Repositorio<PlanAnualAdquisicionRequerimiento>, IPlanAnualAdquisicionRequerimientoRepositorio
    {
        private IContexto contexto;
        public PlanAnualAdquisicionRequerimientoRepositorio(IContexto contexto, IOcurrencia ocurrencia)
          : base(contexto, ocurrencia)
        {
            this.contexto = contexto;
        }

        #region Operaciones
        
        #endregion

        #region Busqueda y listas
        public List<RequerimientoBienServicio> TraerListaRequerimientoBienServicioPendiente(int idPaa)
        {
            return contexto.TraerListaRequerimientoBienServicioPendiente(idPaa).ToList();
        }
        public List<RequerimientoBienServicioDetalle> TraerListaRequerimientoBienServicioDetallePendiente(int idReqBieSer)
        {
            
            //var lista = (
            //            from dr in contexto.RequerimientoBienServicioDetalle
            //            join pard in contexto.PlanAnualAdquisicionDetalle on dr.idReqBieSerDet equals pard.idReqBieSerDet into grupo
            //            from pard in grupo.DefaultIfEmpty()
            //            where
            //                dr.idReqBieSer == idReqBieSer && dr.estado!= Estados.Anulado && pard.estado!=Estados.Anulado
            //            select dr
            //            ).ToList();

            return contexto.TraerListaRequerimientoBienServicioDetallePendiente(idReqBieSer).ToList();
        }
        public List<RequerimientoBienServicioDetalleMes> TraerListaRequerimientoBienServicioDetalleMesPendiente(int idReqBieSerDet, int tipoRubro)
        {

            //var lista = (
            //            from dr in contexto.RequerimientoBienServicioDetalleMes
            //            join pard in contexto.PlanAnualAdquisicionDetalleMes on dr.idReqBieSerDetMes equals pard.idReqBieSerDetMes into grupo
            //            from pard in grupo.DefaultIfEmpty()
            //            where
            //                dr.idReqBieSerDet == idReqBieSerDet && dr.estado != Estados.Anulado && pard.estado != Estados.Anulado
            //            select dr
            //            ).ToList();

            return contexto.TraerListaRequerimientoBienServicioDetalleMesPendiente(idReqBieSerDet, tipoRubro).ToList();
        }
        public RequerimientoBienServicio TraerRequerimientoPendiente(int idReq)
        {
            var query = (
                    from r in contexto.RequerimientoBienServicio
                    join pr in contexto.PlanAnualAdquisicionRequerimiento on r.idReqBieSer equals pr.idReqBieSer into grupo
                    from subpet in grupo.DefaultIfEmpty()
                    where
                        r.idReqBieSer == idReq
                    select r
    
                ).FirstOrDefault();
            return query;
        }

        public List<PlanAnualAdquisicionReqPres> TraerListaPlanAnualAdquisicionReq(int idPaa)
        {
            return contexto.TraerListaPlanAnualAdquisicionReq(idPaa).ToList();
        }
        public List<PlanAnualAdquisicionReqDetallePres> TraerListaPlanAnualAdquisicionReqDetalle(int idPaaReq)
        {
            return contexto.TraerListaPlanAnualAdquisicionReqDetalle(idPaaReq).ToList();
        }
        #endregion
    }
}
