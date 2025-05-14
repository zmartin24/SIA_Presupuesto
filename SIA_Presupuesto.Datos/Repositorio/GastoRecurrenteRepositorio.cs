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
    public class GastoRecurrenteRepositorio : Repositorio<GastoRecurrente>, IGastoRecurrenteRepositorio
    {
        private IContexto contexto;
        public GastoRecurrenteRepositorio(IContexto contexto, IOcurrencia ocurrencia)
          : base(contexto, ocurrencia)
        {
            this.contexto = contexto;
        }

        #region Operaciones
        public bool ActualizarDetallesGastoRecurrente(int idGasRec, string nomUsuario)
        {
            var contexto = this.UnidadTrabajo as IContexto;
            contexto.AumentarLatencia(120);

            return (bool)contexto.ActualizarDetallesGastoRecurrente(idGasRec, nomUsuario).ToList().FirstOrDefault();
        }
        #endregion

        #region Listas 
        public List<GastoRecurrenteRequerimientoPres> TraerListaGastoRecurrenteRequerimiento(int idGasRec)
        {
            List<GastoRecurrenteRequerimientoPres> lista = new List<GastoRecurrenteRequerimientoPres>();
            List<GastoRecurrenteDetallePres> listaDetallada = new List<GastoRecurrenteDetallePres>();

            var contexto = this.UnidadTrabajo as IContexto;
            lista = contexto.TraerListaGastoRecurrenteRequerimiento(idGasRec).ToList();
            listaDetallada = contexto.TraerListaGastoRecurrenteDetalle(idGasRec).ToList();

            lista.ForEach(f => f.GastoRecurrenteDetallePres = listaDetallada.FindAll(t => t.item == f.item));

            return lista;
        }
        public List<RequerimientoBienServicioPendientePorCuentaPres> TraerListaRequerimientoBienServicioPendientePorCuenta(int idCueCon, int anio, int tipoRubro)
        {
            return contexto.TraerListaRequerimientoBienServicioPendientePorCuenta(idCueCon, anio, tipoRubro).ToList();
        }
        public List<ReporteGastoRecurrenteDetallePres> TraerReporteGastoRecurrenteDetalle(int idGasRec)
        {
            return contexto.TraerReporteGastoRecurrenteDetalle(idGasRec).ToList();
        }
        public List<ReporteGastoRecurrenteDetalleDireccionPres> TraerReporteGastoRecurrenteDetalleDireccion(int idGasRec, int idDireccion)
        {
            return contexto.TraerReporteGastoRecurrenteDetalleDireccion(idGasRec, idDireccion).ToList();
        }
        #endregion
    }
}
