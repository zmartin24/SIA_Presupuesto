using Seguridad.Log;
using SIA_Presupuesto.Datos.Base;
using SIA_Presupuesto.Negocio.Contratos.Repositorio;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Datos.Repositorio
{
    public class RequerimientoBienServicioDetalleMesRepositorio : Repositorio<RequerimientoBienServicioDetalleMes>, IRequerimientoBienServicioDetalleMesRepositorio
    {
        public RequerimientoBienServicioDetalleMesRepositorio(IContexto contexto, IOcurrencia ocurrencia)
          : base(contexto, ocurrencia)
        {

        }

        public decimal TraerTotalCantidadMensual(int idReqBieSerDet)
        {
            var contexto = this.UnidadTrabajo as IContexto;

            var query = contexto.RequerimientoBienServicioDetalleMes.Where(t => t.idReqBieSerDet == idReqBieSerDet && t.estado != Estados.Anulado).Count();

            if(query == 0)
            {
                return 0;
            }
            else
            {
                var total = contexto.RequerimientoBienServicioDetalleMes.Where(t => t.idReqBieSerDet == idReqBieSerDet && t.estado != Estados.Anulado).Sum(s => s.cantidad);
                return total;
            }
        }

    }
}
