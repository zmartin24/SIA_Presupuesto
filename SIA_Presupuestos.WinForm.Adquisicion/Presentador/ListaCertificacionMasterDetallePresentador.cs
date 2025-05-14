using DevExpress.XtraReports.UI;
using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.Adquisicion.Reporte;
using SIA_Presupuesto.WinForm.Adquisicion.Vista;
using SIA_Presupuesto.WinForm.General.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using Utilitario.Reporte;

namespace SIA_Presupuesto.WinForm.Adquisicion.Presentador
{
    public class ListaCertificacionMasterDetallePresentador
    {
        private readonly IListaCertificacionMasterDetalleVista listaCertificacionMasterDetalleVista;
        private ICertificacionMasterServicio certificacionMasterServicio;
        private ICertificacionRequerimientoServicio certificacionRequerimientoServicio;
        private CertificacionMasterPres certificacionMasterPres;
        
        public ListaCertificacionMasterDetallePresentador(CertificacionMasterPres certificacionMasterPres, IListaCertificacionMasterDetalleVista listaCertificacionMasterDetalleVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.certificacionMasterServicio = _Contenedor.Resolver(typeof(ICertificacionMasterServicio)) as ICertificacionMasterServicio;
            this.certificacionRequerimientoServicio = _Contenedor.Resolver(typeof(ICertificacionRequerimientoServicio)) as ICertificacionRequerimientoServicio;

            this.listaCertificacionMasterDetalleVista = listaCertificacionMasterDetalleVista;
            this.certificacionMasterPres = certificacionMasterPres;
        }
        public void Iniciar()
        {
        }
        public void ObtenerDatosListado()
        {
            listaCertificacionMasterDetalleVista.listaDatosPrincipales = certificacionRequerimientoServicio.TraerListaCertificacionRequerimiento(this.certificacionMasterPres.idCerMas);
        }

        public CertificacionMaster BuscarCertificacionMaster(int idCerMas)
        {
            return this.certificacionMasterServicio.BuscarPorCodigo(idCerMas);
        }
        public CertificacionRequerimiento Buscar(int vidCerReq)
        {
            return certificacionRequerimientoServicio.BuscarPorCodigo(vidCerReq);
        }
        public CertificacionDetalle BuscarDetalle(int vidCerDet)
        {
            return certificacionRequerimientoServicio.BuscarDetallePorCodigo(vidCerDet);
        }
        public Forebi BuscarForebi(int idForebi)
        {
            return certificacionMasterServicio.BuscarForebi(idForebi);
        }
        public Forese BuscarForese(int idForese)
        {
            return certificacionMasterServicio.BuscarForese(idForese);
        }
        public ValidarForebisePres ValidarForebise(int idCerMas)
        {
            return certificacionMasterServicio.ValidarForebise(idCerMas);
        }
        public VerificaCertificacionDetallePres VerificaCertificacionDetalle(int? idCerReq,int? idCerDet)
        {
            return certificacionRequerimientoServicio.VerificaCertificacionDetalle(idCerReq, idCerDet);
        }
        public bool Anular()
        {
            bool respuesta = false;
            if (listaCertificacionMasterDetalleVista.certificacionRequerimiento != null)
                respuesta = this.certificacionRequerimientoServicio.Anular(listaCertificacionMasterDetalleVista.certificacionRequerimiento, certificacionMasterPres.tipoReq, certificacionMasterPres.idForebise, listaCertificacionMasterDetalleVista.UsuarioOperacion.NomUsuario).esCorrecto;
            return respuesta;
        }
        public bool AnularDetalle(CertificacionRequerimiento certificacionRequerimiento, CertificacionDetallePres certificacionDetallePres)
        {
            bool respuesta = false;
            certificacionRequerimiento.usuEdita = listaCertificacionMasterDetalleVista.UsuarioOperacion.NomUsuario;
            if (listaCertificacionMasterDetalleVista.certificacionDetallePres != null)
                respuesta = this.certificacionRequerimientoServicio.AnularDetalle(certificacionRequerimiento, certificacionDetallePres).esCorrecto;
            return respuesta;
        }
        public List<ReporteCertificacionPresupuestalPres> TraerReporteCertificacionPresupuestal(bool esAmpliacion)
        {
            return certificacionRequerimientoServicio.TraerReporteCertificacionPresupuestal(listaCertificacionMasterDetalleVista.certificacionRequerimientoPres.idCerReq, esAmpliacion);
        }
        public List<Predeterminado> TraerListaEstado()
        {
            
            List<Predeterminado> lista = new List<Predeterminado>();
            lista.Add(new Predeterminado { codigo = "10", descripcion = "APROBADO" });
            lista.Add(new Predeterminado { codigo = "2", descripcion = "ACTIVO" });

            return lista.Where(x => Convert.ToInt32(x.codigo) != listaCertificacionMasterDetalleVista.certificacionRequerimientoPres.estado).ToList();
        }
        public decimal TraerImporteCotizacionPorCertificacion()
        {
            var obj = this.listaCertificacionMasterDetalleVista.certificacionRequerimientoPres;
            return this.certificacionRequerimientoServicio.TraerImporteCotizacionPorCertificacion(this.listaCertificacionMasterDetalleVista.certificacionRequerimientoPres.idCerReq);
        }
        public List<OrdenPorCertificacionPres> TraerListaOrdenPorCertificacion()
        {
            return this.certificacionRequerimientoServicio.TraerListaOrdenPorCertificacion(this.listaCertificacionMasterDetalleVista.certificacionRequerimientoPres.idCerReq);
        }
        public bool ActualizarImporte()
        {
            return this.certificacionRequerimientoServicio.ActualizarImporteCertificacion(this.listaCertificacionMasterDetalleVista.certificacionRequerimientoPres.idCerReq, this.listaCertificacionMasterDetalleVista.UsuarioOperacion.NomUsuario);
        }

        public void ReporteCertificacionPresupuestal(List<ReporteCertificacionPresupuestalPres> TraerReporteCertificacionPresupuestal)
        {
            LlamarReporte(new rptCertificacionPresupuestal(), TraerReporteCertificacionPresupuestal);
        }
        private void LlamarReporte(XtraReport report, object datosReporte)
        {
            ReporteWinForDev frm = new ReporteWinForDev();
            List<ParametrosReporte> p = new List<ParametrosReporte>();
            
            frm.report = report;
            frm.datosReporte = datosReporte;
            frm.listaParametros = p;
            frm.AbrirDocumento(true, false);
        }
    }
}
