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
    public class ConceptoCuentaContableRepositorio : Repositorio<ConceptoCuentaContable>, IConceptoCuentaContableRepositorio
    {
        public ConceptoCuentaContableRepositorio(IContexto contexto, IOcurrencia ocurrencia)
          : base(contexto, ocurrencia)
        {

        }

        public List<DatoConceptoCuentaContable> TraerDatosConceptoCuentaContable(int idConCueCon)
        {
            List<DatoConceptoCuentaContable> lista = new List<DatoConceptoCuentaContable>();

            var contexto = this.UnidadTrabajo as IContexto;
            lista = contexto.TraerDatosConceptoCuentaContable(idConCueCon).ToList();

            return lista;
        }
    }
}
