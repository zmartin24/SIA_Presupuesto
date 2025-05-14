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
    public class RequerimientoMensualDetalleRepositorio : Repositorio<RequerimientoMensualDetalle>, IRequerimientoMensualDetalleRepositorio
    {
        public RequerimientoMensualDetalleRepositorio(IContexto contexto, IOcurrencia ocurrencia)
          : base(contexto, ocurrencia)
        {

        }

        public List<RequerimientoMensualDetallePres> TraerListaRequerimientoMensualDetalle(int idReqMenBieSer)
        {
            List<RequerimientoMensualDetallePres> lista = new List<RequerimientoMensualDetallePres>();

            var contexto = this.UnidadTrabajo as IContexto;
            contexto.AumentarLatencia(1800);
            lista = contexto.TraerListaRequerimientoMensualDetalle(idReqMenBieSer).ToList();

            return lista;
        }


    }
}
