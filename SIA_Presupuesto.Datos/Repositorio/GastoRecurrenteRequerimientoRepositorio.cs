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
    public class GastoRecurrenteRequerimientoRepositorio : Repositorio<GastoRecurrenteRequerimiento>, IGastoRecurrenteRequerimientoRepositorio
    {
        private IContexto contexto;
        public GastoRecurrenteRequerimientoRepositorio(IContexto contexto, IOcurrencia ocurrencia)
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
            return contexto.TraerListaRequerimientoBienServicioDetallePendiente(idReqBieSer).ToList();
        }
        public List<RequerimientoBienServicioDetalleMes> TraerListaRequerimientoBienServicioDetalleMesPendiente(int idReqBieSerDet, int tipoRubro)
        {
            return contexto.TraerListaRequerimientoBienServicioDetalleMesPendiente(idReqBieSerDet, tipoRubro).ToList();
        }
        
        #endregion
    }
}
