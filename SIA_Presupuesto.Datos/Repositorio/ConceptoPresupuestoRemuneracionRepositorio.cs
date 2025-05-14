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
    public class ConceptoPresupuestoRemuneracionRepositorio : Repositorio<ConceptoPresupuestoRemuneracion>, IConceptoPresupuestoRemuneracionRepositorio
    {
        public ConceptoPresupuestoRemuneracionRepositorio(IContexto contexto, IOcurrencia ocurrencia)
          : base(contexto, ocurrencia)
        {

        }

        public int TraerUltimoNumero(string tipo)
        {
            var contexto = this.UnidadTrabajo as IContexto;
            int codigo = 0;

            var cod = (from con in contexto.ConceptoPresupuestoRemuneracion
                          where con.tipo.Equals(tipo)
                          orderby con.codigo descending
                          select con.codigo
                          ).FirstOrDefault();

            if(cod!=null)
            {
                codigo = Convert.ToInt32(cod.Substring(2, 3));
            }

            return codigo + 1;
        }

        public List<ConceptoPresupuestoRemuneracion> TraerConceptosEstructura(int idEstPreRem, int idConcepto)
        {
            var contexto = this.UnidadTrabajo as IContexto;

            return (from con in contexto.ConceptoPresupuestoRemuneracion
                       join pro in contexto.PropiedadPresupuestoRemuneracion on con.idConPreRem equals pro.idConPreRem
                       where con.estado!=1 && pro.estado!=1 && pro.idEstPreRem == idEstPreRem && pro.idConPreRem != idConcepto
                    orderby con.codigo descending
                       select con
                          ).ToList();
        }

        public List<ConceptoPresupuestoRemuneracion> TraerConceptosMenosdeEstructura(int idEstPreRem)
        {
            var contexto = this.UnidadTrabajo as IContexto;

            var propiedadesConcepto = contexto.PropiedadPresupuestoRemuneracion.Where(w => w.idEstPreRem == idEstPreRem && w.estado != 1).Select(s => s.idConPreRem).Distinct();

            return (from con in contexto.ConceptoPresupuestoRemuneracion
                    where con.estado != 1 && !propiedadesConcepto.Contains(con.idConPreRem)
                    orderby con.codigo ascending
                    select con
                          ).ToList();
        }
    }
}
