using SIA_Presupuesto.Negocio.Contratos.Base;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Contratos.Servicios
{
    public interface IGastoRecurrenteServicio : IServicio
    {
        #region Operaciones

        Resultado Nuevo(GastoRecurrente gastoRecurrente);
        Resultado NuevoGasRecReq(GastoRecurrenteRequerimiento gastoRecurrenteRequerimiento);
        Resultado NuevoDetalle(GastoRecurrenteDetalle gastoRecurrenteDetalle);
        Resultado NuevoGasRecDetMes(GastoRecurrenteDetalleMes gastoRecurrenteDetalleMes, bool actualizaArea);
        Resultado NuevoDetalleMasivoPorCuentas(GastoRecurrente gastoRecurrente, List<RequerimientoBienServicioPendientePorCuentaPres> requerimientoPendientePorCuentaPres);

        Resultado Modificar(GastoRecurrente gastoRecurrente);
        Resultado ModificarSinClonar(GastoRecurrente gastoRecurrente);
        Resultado ModificarDetalles(GastoRecurrenteDetalle gastoRecurrenteDetalle);
        Resultado ModificarDetallesSinClonar(GastoRecurrenteDetalle gastoRecurrenteDetalle);
        Resultado ModificarGasRecReq(GastoRecurrenteRequerimiento gastoRecurrenteRequerimiento);
        Resultado ModificarGasRecDetMes(GastoRecurrenteDetalleMes gastoRecurrenteDetalleMes, bool actualizaArea);

        Resultado AnularGasRecReq(GastoRecurrenteRequerimiento gastoRecurrenteRequerimiento, string usuario);
        Resultado AnularGasRecReqPres(GastoRecurrenteRequerimientoPres gastoRecurrenteRequerimientoPres, string usuario);
        Resultado AnularDetalle(GastoRecurrenteDetalle gastoRecurrenteDetalle, string usuario);
        Resultado Anular(GastoRecurrente gastoRecurrente, string usuario);
        bool ActualizarDetallesGastoRecurrente(int idGasRec, string nomUsuario);

        #endregion

        #region Busqueda y listas
        GastoRecurrente Buscar(int idGasRec);
        GastoRecurrenteRequerimiento BuscarReqPorCodigo(int idGasRecReq);
        GastoRecurrenteDetalle BuscarDetallePorCodigo(int idGasRecDet);
        List<GastoRecurrente> listarTodosActivos();
        List<GastoRecurrenteRequerimientoPres> TraerListaGastoRecurrenteRequerimiento(int idGasRec);
        GastoRecurrenteDetalleMes BuscarPorCodigoPaaDetalleMes(int idGasRecDet, int mes);
        decimal BuscarImporteDetalle(int idGasRecDet, decimal precio);
        List<RequerimientoBienServicioPendientePorCuentaPres> TraerListaRequerimientoBienServicioPendientePorCuenta(int idCueCon, int anio, int tipoRubro);
        #endregion
        #region Reporte
        List<ReporteGastoRecurrenteDetallePres> TraerReporteGastoRecurrenteDetalle(int idGasRec);
        List<ReporteGastoRecurrenteDetalleDireccionPres> TraerReporteGastoRecurrenteDetalleDireccion(int idGasRec, int idDireccion);
        #endregion
    }
}
