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
    public class ParametroPresupuestoRemuneracionRepositorio : Repositorio<ParametroPresupuestoRemuneracion>, IParametroPresupuestoRemuneracionRepositorio
    {
        public ParametroPresupuestoRemuneracionRepositorio(IContexto contexto, IOcurrencia ocurrencia)
          : base(contexto, ocurrencia)
        {

        }

        public List<ParametroPoco> TraerParametrosPresentacion()
        {
            List<ParametroPoco> lista = new List<ParametroPoco>();

            var contexto = this.UnidadTrabajo as IContexto;
            lista = (from par in contexto.ParametroPresupuestoRemuneracion
                     join con in contexto.ConceptoPresupuestoRemuneracion on par.idConPreRem equals con.idConPreRem
                    where par.estado!=1
                    select new ParametroPoco
                    {
                        idConPreRem = par.idConPreRem,
                        idParPreRem = par.idParPreRem,
                        concepto = con.descripcion,
                        codigo = con.codigo,
                        importe = par.importe
                    }
                ).ToList();

            return lista;
        }
    }
}
