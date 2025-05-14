using SIA_Presupuesto.Negocio.Contratos.Base;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System.Collections.Generic;
using System.Data;

namespace SIA_Presupuesto.Negocio.Contratos.Servicios
{
    public interface IRequerimientoMensualBienServicioServicio : IServicio
    {
        #region Operaciones

        Resultado Nuevo(RequerimientoMensualBienServicio requerimientoMensualBienServicio);
        Resultado Nuevo(RequerimientoMensualBienServicio requerimientoMensualBienServicio, string idsReqBieSer);
        Resultado Modificar(RequerimientoMensualBienServicio requerimientoMensualBienServicio);
        Resultado ModificarSinClonar(RequerimientoMensualBienServicio requerimientoMensualBienServicio);
        Resultado Anular(RequerimientoMensualBienServicio requerimientoMensualBienServicio, string usuario);

        /*****Detalles*****/
        Resultado NuevoDetalle(RequerimientoMensualDetalle requerimientoMensualDetalle);
        Resultado ModificarDetalles(RequerimientoMensualDetalle requerimientoMensualDetalle);
        Resultado ModificarDetallesSinClonar(RequerimientoMensualDetalle requerimientoMensualDetalle);
        Resultado AnularDetalle(RequerimientoMensualDetalle requerimientoMensualDetalle, string usuario);
        Resultado GuardarDetalleRequerimientoMensualBienesServiciosToClonar(RequerimientoMensualBienServicio requerimientoMensualBienServicio);
        bool GuardarDetalleRequerimientoMensualBienesServiciosToExcel(int idReqMenBieSer, string usuario, DataTable estructuraCarga);

        #endregion

        #region Busquedas y listados

        RequerimientoMensualBienServicio BuscarPorCodigo(int idReqMenBieSer);
        RequerimientoMensualBienServicio BuscarRequerimientoMensualBienServicio(int idReqMenBieSer);
        RequerimientoMensualDetalle BuscarDetallePorCodigo(int idReqMenDet);
        List<RequerimientoMensualBienServicio> listarTodos();
        List<RequerimientoMensualBienServicioPres> TraerListaRequerimientoMensualBienServicio(int anio, int mes, int idUsuario, int? idPresupuesto, bool listarTodos);
        /***Detalles**/
        List<RequerimientoMensualDetallePres> TraerListaRequerimientoMensualDetalle(int idReqMenBieSer);
        List<RequerimientoMensualDetalle> TraerListarDetallesTodos(int idReqMenBieSer);
        List<RequerimientoMensualDetallePres> TraerListaRequerimientoMensualDetalleDireccion(int idDireccion, int idSubdireccion, string tipo, int idTipoRequerimiento, int anio, int mes);
        #endregion
        #region Reportes
        List<ReporteRequerimientoMensualSeguimientoPres> TraerReporteRequerimientoMensualSeguimiento(int idReqMenBieSer, int idMoneda);
        List<ReporteRequerimientoMensualSeguimientoDetallePres> TraerReporteRequerimientoMensualSeguimientoDetalle(int idReqMenBieSer, int idMoneda);
        List<ReporteRequerimientoMensualSeguimientoForebisePres> TraerReporteRequerimientoMensualSeguimientoForebise(int idReqMenBieSer, int idMoneda);
        List<ReporteRequerimientoMensualSeguimientoForebiseCabecera> TraerReporteRequerimientoMensualSeguimientoForebiseCabecera(int idReqMenBieSer, int idMoneda);
        DataTable ListaEstructuraCargaRequerimientoMensual(int idReqMenBieSer, DataTable estructuraCarga);
        #endregion
    }
}
