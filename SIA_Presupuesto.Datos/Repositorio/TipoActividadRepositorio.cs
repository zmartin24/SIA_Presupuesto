using Seguridad.Log;
using SIA_Presupuesto.Datos.Base;
using SIA_Presupuesto.Negocio.Contratos.Repositorio;
using SIA_Presupuesto.Negocio.Entidades;

namespace SIA_Presupuesto.Datos.Repositorio
{
    public class TipoActividadRepositorio : Repositorio<TipoActividad>, ITipoActividadRepositorio
    {
        private IContexto contexto;

        public TipoActividadRepositorio(IContexto contexto, IOcurrencia ocurrencia)
          : base(contexto, ocurrencia)
        {
            this.contexto = contexto;
        }
    }
}
