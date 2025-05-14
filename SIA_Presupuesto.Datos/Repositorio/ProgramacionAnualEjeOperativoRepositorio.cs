using Seguridad.Log;
using SIA_Presupuesto.Datos.Base;
using SIA_Presupuesto.Negocio.Contratos.Repositorio;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Datos.Repositorio
{
    public class ProgramacionAnualEjeOperativoRepositorio : Repositorio<ProgramacionAnualEjeOperativo>, IProgramacionAnualEjeOperativoRepositorio
    {
        public ProgramacionAnualEjeOperativoRepositorio(IContexto contexto, IOcurrencia ocurrencia)
          : base(contexto, ocurrencia)
        {

        }

        public List<ProgramacionEjeOperativoPoco> ListaProgramacionEjeOperativoPoco(int idProAnu)
        {
            var contexto = this.UnidadTrabajo as IContexto;

            var lista = (from p in contexto.ProgramacionAnualEjeOperativo
                         join pd in contexto.EjeOperativo on p.idEjeOpe equals pd.idEjeOpe
                         where p.estado != 1 && p.idProAnu == idProAnu
                         select new ProgramacionEjeOperativoPoco
                         {
                             idProAnuEjeOpe = p.idProAnuEjeOpe,
                             idProAnu = p.idProAnu,
                             idEjeOpe = p.idEjeOpe,
                             ejeOperativo = pd.descripcion,
                             observacion = p.observacion,
                             operacion = ""
                         }).ToList();

            return lista;
        }
    }
}
