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
    public class ReajusteMensualDetalleRepositorio : Repositorio<ReajusteMensualDetalle>, IReajusteMensualDetalleRepositorio
    {
        public ReajusteMensualDetalleRepositorio(IContexto contexto, IOcurrencia ocurrencia)
          : base(contexto, ocurrencia)
        {

        }

        public List<ReajusteMensualDetallePres> TraerListaReajusteMensualDetalle(int idEvaMenArea)
        {
            List<ReajusteMensualDetallePres> lista = new List<ReajusteMensualDetallePres>();

            var contexto = this.UnidadTrabajo as IContexto;
            lista = contexto.TraerListaReajusteMensualDetalle(idEvaMenArea).ToList();

            return lista;
        }
        public List<ReajusteMensualDetallePorMesPres> TraerListaReajusteMensualDetallePorMes(int idReaMenPro, int mes, int? idSubpresupuesto)
        {
            var contexto = this.UnidadTrabajo as IContexto;

            return contexto.TraerListaReajusteMensualDetallePorMes(idReaMenPro, mes, idSubpresupuesto).ToList();
        }
    }
}
