using SIA_Presupuesto.Negocio.Base;
using SIA_Presupuesto.Negocio.Contratos.Repositorio;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Servicios
{
    public class PlanAnualAdquisicionRequerimientoServicio : ServicioBase
    {
        IPlanAnualAdquisicionRequerimientoRepositorio repositorio;
        public PlanAnualAdquisicionRequerimientoServicio(IPlanAnualAdquisicionRequerimientoRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }
        protected override void CargarUsuarioRepositorio()
        {
            CargarInformacionUsuario(repositorio);
        }

        #region Operaciones



        #endregion

        #region Busquedas y listados

        public List<RequerimientoBienServicio> TraerListaRequerimientoBienServicioPendiente(int idPaa)
        {
            return repositorio.TraerListaRequerimientoBienServicioPendiente(idPaa);
        }

        public List<RequerimientoBienServicioDetalle> TraerListaRequerimientoBienServicioDetallePendiente(int idReqBieSer)
        {
            return repositorio.TraerListaRequerimientoBienServicioDetallePendiente(idReqBieSer);
        }

        #endregion
    }
}
