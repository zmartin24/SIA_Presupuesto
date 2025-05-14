using SIA_Presupuesto.Negocio.Contratos.Base;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.Negocio.Contratos.Repositorio
{
    public interface ICertificacionRequerimientoRepositorio : IRepositorio<CertificacionRequerimiento>
    {
        bool ActualizarEstadoRequerimientoForebise(int opcion, int tipo, int idForebise, int estado, string usuario, DateTime fecha);
        bool ActualizarEstadoCertificacionPresupuestal(int idCerReq, string opcion, string usuario);
        bool ActualizarImporteCertificacion(int idCerReq, string usuario);
        void ActualizarTotalCertificacionRequerimiento(int idCerReq);
        CertificacionRequerimiento BuscarPorCodigo(int idCerReq);
        decimal TraerImporteCotizacionPorCertificacion(int idCerReq);
        Resultado ValidaFechaCertificacion(DateTime fechaEmision, int numero, string opcion, int? idCerReq);
        List<Forebi> TraerListaForebiPorSubPresupuesto(int idSubPresupuesto);
        List<Forese> TraerListaForesePorSubPresupuesto(int idSubPresupuesto);
        List<ForeDetallePoco> TraerListaForebiDetallePoco(int idForebi);
        List<ForeDetallePoco> TraerListaForeseDetallePoco(int idForese);
        List<ForeDetallePoco> TraerListaFormatoRequerimientoDetalle(int idFore, int tipo);
        List<SubPresupuestoDetallePres> TraerListaSubPresupuestoDetalle(int idSubPresupuesto);
        List<CertificacionDetallePres> TraerListaCertificacionDetalle(int? idCerMas, int? idCerReq);
        List<CertificacionRequerimientoPres> TraerListaCertificacionRequerimiento(int anio);
        List<PrecioBienServicioPres> TraerListaPrecioBienServicio(int anio, int idProSer, int tipo);
        List<PrecioBienServicioPres> TraerListaPrecioBienServicioRequerimiento(int anio, int idProducto, int idCueCon, int idReqBieSer, int tipo);
        List<CertificacionRequerimientoExportaPres> TraerListaCertificacionRequerimientoExporta(int tipoReq, int anio);
        List<ForeDetallePoco> TraerListaCertificacionDetalleAmpiacion(int idCerReq);
        List<SubPresupuestoPoco> TraerListaSubPresupuestoPocoPorIdCerReq(int idCerReq);
        List<UsuarioCorreoPres> TraerListaUsuarioCorreo();
        List<OrdenPorCertificacionPres> TraerListaOrdenPorCertificacion(int idCerReq);
        int TraerUltimoNumeroCertificacion(int anio);
        SubPresupuestoImporteCertificacion_Pres TraerSubPresupuestoImporteCertificacion(int idSubPresupuesto);
        List<ReporteCertificacionPresupuestalPres> TraerReporteCertificacionPresupuestal(int idCerReq, bool esAmpliacion);
        List<ReporteCertificacionPresupuestalPres> TraerReporteCertificacionPresupuestalVarios(string idsCerReq, bool esAmpliacion);
        VerificaCertificacionDetallePres VerificaCertificacionDetalle(int? idCerReq, int? idCerDet);
        decimal TraerCantPendiente(int idForReqDet, int tipoReq);
        decimal TraerImporteMinCer();
    }
}
