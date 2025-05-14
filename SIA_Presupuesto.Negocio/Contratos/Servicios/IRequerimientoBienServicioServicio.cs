using Seguridad.Datos.Infraestructura;
using SIA_Presupuesto.Negocio.Contratos.Base;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Contratos.Servicios
{
    public interface IRequerimientoBienServicioServicio : IServicio
    {
        #region Operaciones

        Resultado Nuevo(RequerimientoBienServicio RequerimientoBienServicio);

        Resultado NuevoDetalle(RequerimientoBienServicioDetalle RequerimientoBienServicioDetalle);
        Resultado NuevoDetalleConMeses(RequerimientoBienServicioDetalle RequerimientoBienServicioDetalle, List<RequerimientoBienServicioDetalleMes> listaMeses);

        Resultado NuevoDetalle(RequerimientoBienServicioDetalleMes RequerimientoBienServicioDetalleMes, bool actualizaDet);

        Resultado Modificar(RequerimientoBienServicio RequerimientoBienServicio);

        Resultado ModificarSinClonar(RequerimientoBienServicio RequerimientoBienServicio);

        Resultado ModificarDetalles(RequerimientoBienServicioDetalle RequerimientoBienServicioDetalle);

        Resultado ModificarDetallesSinClonar(RequerimientoBienServicioDetalle RequerimientoBienServicioDetalle);
        Resultado ModificarDetallesSinClonarConMeses(RequerimientoBienServicioDetalle RequerimientoBienServicioDetalle, List<RequerimientoBienServicioDetalleMes> listaMeses);

        Resultado ModificarDetalles(RequerimientoBienServicioDetalleMes RequerimientoBienServicioDetalleMes, bool actualizaArea);

        Resultado Eliminar(RequerimientoBienServicio RequerimientoBienServicio);

        Resultado Anular(RequerimientoBienServicio RequerimientoBienServicio, string usuario);

        Resultado AnularArea(RequerimientoBienServicioDetalle RequerimientoBienServicioDetalle, string usuario);

        Resultado EliminarDetalle(RequerimientoBienServicioDetalle RequerimientoBienServicioDetalle);
        Resultado GuardarDetalleRequerimientoAnualBienesServiciosToClonar(RequerimientoBienServicio RequerimientoBienServicio);
        bool GuardarDetalleRequerimientoAnualBienesServiciosToExcel(int idReqBieSer, string usuario, DataTable estructuraCarga);

        #endregion

        #region Busquedas y listados

        RequerimientoBienServicio BuscarPorCodigo(int idRequerimientoBienServicio);
        RequerimientoBienServicio TraerRequerimientoBienServicio(int idReqBieSer);

        RequerimientoBienServicioDetalle BuscarPorCodigoDetalle(int idReqBieSerDet);

        RequerimientoBienServicioDetalleMes BuscarPorCodigoDetalleMes(int idProAnuDet);

        List<RequerimientoBienServicio> listarTodos();

        List<RequerimientoBienServicioPres> TraerListaRequerimientoBienServicio(int anio, int idUsuario);
        List<RequerimientoBienServicio> TraerListaRequerimientoBienServicioPorArea(int tipo, int anio, int mes, int idArea);

        List<RequerimientoBienServicioDetallePres> TraerListaRequerimientoBienServicioDetalle(int idProAnuArea);

        RequerimientoBienServicioDetalleMes BuscarPorCodigoDetalleMes(int idReqBieSerDet, int mes);

        List<RequerimientoBienServicioDetallePres> TraerListaRequerimientoBienServicioDetalleDireccion(int idDireccion, int? idSubdireccion, int anio, int idMoneda);

        List<RequerimientoBienServicioDetallePresExporta> TraerListaRequerimientoBienServicioDireccionExporta(int idDireccion,int anio);

        List<RequerimientoBienServicioDetallePresExporta> TraerListaRequerimientoBienServicioDetalleDireccionAreaExporta(int idDireccion,int anio);

        List<ReporteRequerimientoBienServicioExportaPres> TraerReporteRequerimientoBienServicioExporta(int idReqBieSer);

        List<RequerimientoBienServicioDetallePres> TraerListaRequerimientoBienServicioDetalleDireccionOperativos(int idDireccion, int anio, string tipo, int idMoneda);

        #endregion

        #region Reportes
        List<ReporteRequerimientoBienServicioDireccionAreaExporta_Pres> TraerReporteRequerimientoBienServicioDireccionAreaExporta(int idDireccion, int anio, string tipo);
        List<ReporteRequerimientoBienServicioDetalleMensualPres> TraerReporteRequerimientoBienServicioDetalleMensual(int idReqBieSer);
        List<RequerimientoBienServicioDetalleMes> TraerRequerimientoBienServicioDetalleMeses(int idReqBieSerDet);
        DataTable ListaEstructuraCargaRequerimientoAnual(int idReqBieSer, DataTable estructuraCarga);
        #endregion
    }
}
