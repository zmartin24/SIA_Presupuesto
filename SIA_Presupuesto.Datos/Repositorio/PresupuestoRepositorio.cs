using Seguridad.Log;
using SIA_Presupuesto.Datos.Base;
using SIA_Presupuesto.Negocio.Contratos.Repositorio;
using SIA_Presupuesto.Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Datos.Repositorio
{
    public class PresupuestoRepositorio : Repositorio<Presupuesto>, IPresupuestoRepositorio
    {
        public PresupuestoRepositorio(IContexto contexto, IOcurrencia ocurrencia)
          : base(contexto, ocurrencia)
        {

        }

        public List<PresupuestoPres> TraerListaPresupuestoPres()
        {
            List<PresupuestoPres> lista = new List<PresupuestoPres>();

            var contexto = this.UnidadTrabajo as IContexto;
            lista = contexto.TraerListaPresupuestoPres().ToList();

            return lista;
        }
        public List<Presupuesto> TraerListaPresupuestoPorGrupoPresupuesto(int idGruPre)
        {
            var contexto = this.UnidadTrabajo as IContexto;
            return contexto.TraerListaPresupuestoPorGrupoPresupuesto(idGruPre).ToList();
        }
    }
}
