using Seguridad.Log;
using SIA_Presupuesto.Datos.Base;
using SIA_Presupuesto.Negocio.Contratos.Repositorio;
using SIA_Presupuesto.Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;

namespace SIA_Presupuesto.Datos.Repositorio
{
    public class RubroBienServicioRepositorio : Repositorio<RubroBienServicio>, IRubroBienServicioRepositorio
    {
        private IContexto contexto;

        public RubroBienServicioRepositorio(IContexto contexto, IOcurrencia ocurrencia)
          : base(contexto, ocurrencia)
        {
            this.contexto = contexto;
        }

        public List<RubroBienServicioPoco> TraerLista()
        {
            var rubrobienservicio = (
                           from d in contexto.RubroBienServicio
                           
                           where d.estado == 2 && d.tipoRubro == 1
                           select new RubroBienServicioPoco
                           {
                                idRubBieSer = d.idRubBieSer,
                                descripcion = d.descripcion,
                                usuCrea = d.usuCrea,
                                fechaCrea = d.fechaCrea
                           }).OrderBy(t=>t.descripcion).ToList();

            return rubrobienservicio;
        }
    }
}
