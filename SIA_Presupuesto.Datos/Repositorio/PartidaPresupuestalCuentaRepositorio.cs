using Seguridad.Log;
using SIA_Presupuesto.Datos.Base;
using SIA_Presupuesto.Negocio.Contratos.Repositorio;
using SIA_Presupuesto.Negocio.Entidades;

namespace SIA_Presupuesto.Datos.Repositorio
{
    public class PartidaPresupuestalCuentaRepositorio : Repositorio<PartidaPresupuestalCuenta>, IPartidaPresupuestalCuentaRepositorio
    {
        private IContexto contexto;
        public PartidaPresupuestalCuentaRepositorio(IContexto contexto, IOcurrencia ocurrencia)
          : base(contexto, ocurrencia)
        {
            this.contexto = contexto;
        }
    }
}
