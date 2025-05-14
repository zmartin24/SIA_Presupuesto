using SIA_Presupuesto.Negocio.Contratos.Base;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using System;
using System.Collections.Generic;

namespace SIA_Presupuesto.Negocio.Contratos.Servicios
{
    public interface ICertificacionRequerimientoServicio : IServicio
    {
        #region Operaciones
        Resultado Nuevo(CertificacionRequerimiento certificacionRequerimiento, CertificacionMasterPres certificacionMasterPres, List<ForeDetallePoco> listaForeDetallePoco, int idSubpresupuesto);
        Resultado NuevoAmpliacion(CertificacionRequerimiento certificacionRequerimiento, CertificacionMasterPres certificacionMasterPres, List<ForeDetallePoco> listaForeDetallePoco, bool esModificacion);
        Resultado NuevoDetalle(CertificacionDetalle certificacionDetalle);
        Resultado Modificar(CertificacionRequerimiento certificacionRequerimiento);
        Resultado ModificarDetalles(CertificacionDetalle certificacionDetalle);
        Resultado Anular(CertificacionRequerimiento certificacionRequerimiento, int tipoReq, int idForebise, string usuario);
        Resultado NuevoDetalleMasivoReque(CertificacionRequerimiento certificacionRequerimiento, List<ForeDetallePoco> listaForeDetallePoco);
        Resultado ModificarDetalleMasivoReque(CertificacionRequerimiento certificacionRequerimiento, List<ForeDetallePoco> listaForeDetallePoco);
        Resultado AnularDetalle(CertificacionRequerimiento certificacionRequerimiento, CertificacionDetallePres certificacionDetallePres);
        Resultado AsignacionSubpresupuesto(CertificacionRequerimiento certificacionRequerimiento, int idSubpresupuesto);
        Resultado AnularAsignacionSubpresupuesto(CertificacionRequerimiento certificacionRequerimiento, List<int> listaSubpresupuestoIds);
        Resultado ValidaFechaCertificacion(DateTime fechaEmision, int numero, string opcion, int? idCerReq);
        bool ActualizarEstadoCertificacionPresupuestal(int idCerReq, string opcion, string usuario);
        bool ActualizarImporteCertificacion(int idCerReq, string usuario);

        #endregion

        #region Busqueda y listas
        CertificacionRequerimiento BuscarPorCodigo(int idCerReq);
        CertificacionDetalle BuscarDetallePorCodigo(int idCerDet);
        List<CertificacionRequerimiento> listarTodosActivos(int anio);
        List<CertificacionRequerimiento> listarCertificacionRequerimientoPorIdCerMas(int idCerMas);
        List<CertificacionRequerimientoPres> TraerListaCertificacionRequerimiento(int anio);
        List<CertificacionDetalle> listarDetallesTodosActivos(int idCerReq);
        int TraerUltimoNumeroCertificacion(int anio);
        SubPresupuestoImporteCertificacion_Pres TraerSubPresupuestoImporteCertificacion(int idSubPresupuesto);
        decimal TraerImporteCotizacionPorCertificacion(int idCerReq);

        List<Forebi> TraerListaForebiPorSubPresupuesto(int idSubPresupuesto);
        List<Forese> TraerListaForesePorSubPresupuesto(int idSubPresupuesto);
        
        List<ForeDetallePoco> TraerListaFormatoRequerimientoDetalle(int idFore, int tipo);

        List<SubPresupuestoDetallePres> TraerListaSubPresupuestoDetalle(int idSubPresupuesto);
        List<CertificacionDetallePres> TraerListaCertificacionDetalle(int? idCerMas,int? idCerReq);
        List<PrecioBienServicioPres> TraerListaPrecioBienServicio(int anio, int idProSer, int tipo);
        List<PrecioBienServicioPres> TraerListaPrecioBienServicioRequerimiento(int anio, int idProSer, int idCueCon, int idReqBieSer, int tipo);
        decimal TraerCantPendiente(int idForReqDet, int tipoReq);
        decimal TraerImporteMinCer();
        List<CertificacionRequerimientoExportaPres> TraerListaCertificacionRequerimientoExporta(int tipoReq, int anio);
        List<ForeDetallePoco> TraerListaCertificacionDetalleAmpiacion(int idCerReq);
        List<SubPresupuestoPoco> TraerListaSubPresupuestoPocoPorIdCerReq(int idCerReq);
        List<UsuarioCorreoPres> TraerListaUsuarioCorreo();
        List<CertificacionRequerimientoSubprespuesto> listaCertificacionRequerimientoSubprespuesto(int idCerReq, int idSubpresupuesto);
        List<OrdenPorCertificacionPres> TraerListaOrdenPorCertificacion(int idCerReq);
        #endregion

        #region Reporte
        List<ReporteCertificacionPresupuestalPres> TraerReporteCertificacionPresupuestal(int idCerReq, bool esAmpliacion);
        List<ReporteCertificacionPresupuestalPres> TraerReporteCertificacionPresupuestalVarios(string idsCerReq, bool esAmpliacion);
        VerificaCertificacionDetallePres VerificaCertificacionDetalle(int? idCerReq,int? idCerDet);
        #endregion
    }
}
