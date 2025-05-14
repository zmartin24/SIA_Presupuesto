using Seguridad.Log;
using SIA_Presupuesto.Datos.Base;
using SIA_Presupuesto.Negocio.Contratos.Repositorio;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Datos.Repositorio
{
    public class ProgramacionAnualSedeRepositorio : Repositorio<ProgramacionAnualSede>, IProgramacionAnualSedeRepositorio
    {
        public ProgramacionAnualSedeRepositorio(IContexto contexto, IOcurrencia ocurrencia)
          : base(contexto, ocurrencia)
        {

        }

        public List<ProgramacionSedeLaboralPoco> ListaProgramacionSedeLaboralPoco(int idProAnu)
        {
            var contexto = this.UnidadTrabajo as IContexto;

            var lista = (from p in contexto.ProgramacionAnualSede
                         join pd in contexto.SedeLaboral on p.idSede equals pd.idSede
                         where p.estado != 1 && p.idProAnu == idProAnu
                         select new ProgramacionSedeLaboralPoco
                         {
                             idProAnuSed = p.idProAnuSed,
                             idProAnu = p.idProAnu,
                             idSede = p.idSede,
                             desSede = pd.desSede,
                             observacion = p.observacion,
                             operacion = ""
                         }).ToList();

            return lista;
        }
    }
}
