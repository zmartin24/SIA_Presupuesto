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
    public class EvaluacionMensualDetalleRepositorio : Repositorio<EvaluacionMensualDetalle>, IEvaluacionMensualDetalleRepositorio
    {
        public EvaluacionMensualDetalleRepositorio(IContexto contexto, IOcurrencia ocurrencia)
          : base(contexto, ocurrencia)
        {

        }

        public List<EvaluacionMensualDetallePres> TraerListaEvaluacionMensualDetalle(int idEvaMenArea)
        {
            List<EvaluacionMensualDetallePres> lista = new List<EvaluacionMensualDetallePres>();

            var contexto = this.UnidadTrabajo as IContexto;
            lista = contexto.TraerListaEvaluacionMensualDetalle(idEvaMenArea).ToList();

            return lista;
        }
    }
}
