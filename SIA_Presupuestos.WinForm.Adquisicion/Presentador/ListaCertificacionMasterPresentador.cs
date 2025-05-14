using DevExpress.XtraReports.UI;
using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.Adquisicion.Reporte;
using SIA_Presupuesto.WinForm.Adquisicion.Vista;
using System;
using System.Collections.Generic;
using Utilitario.Reporte;
using Utilitario.Util;

namespace SIA_Presupuesto.WinForm.Adquisicion.Presentador
{
    public class ListaCertificacionMasterPresentador
    {
        private readonly IListaCertificacionMasterVista listaCertificacionMasterVista;
        private ICertificacionMasterServicio certificacionMasterServicio;
        private ICertificacionRequerimientoServicio certificacionRequerimientoServicio;
        public ListaCertificacionMasterPresentador(IListaCertificacionMasterVista listaCertificacionMasterVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.certificacionMasterServicio = _Contenedor.Resolver(typeof(ICertificacionMasterServicio)) as ICertificacionMasterServicio;
            this.certificacionRequerimientoServicio = _Contenedor.Resolver(typeof(ICertificacionRequerimientoServicio)) as ICertificacionRequerimientoServicio;

            this.listaCertificacionMasterVista = listaCertificacionMasterVista;
        }
        public void Iniciar()
        {
            this.listaCertificacionMasterVista.listaAnios = UtilitarioComun.ListarAnios(DateTime.Now.Date.AddYears(1).Year, 2018);
            this.listaCertificacionMasterVista.anioPresentacion = DateTime.Now.Date.Year;
        }
        public void ObtenerDatosListado()
        {
            listaCertificacionMasterVista.listaDatosPrincipales = certificacionMasterServicio.TraerListaCertificacionMaster(listaCertificacionMasterVista.anioPresentacion);
        }
        public CertificacionMaster Buscar(int vidCerMas)
        {
            return certificacionMasterServicio.BuscarPorCodigo(vidCerMas);
        }
        public Forebi BuscarForebi(int id)
        {
            return certificacionMasterServicio.BuscarForebi(id);
        }
        public Forese BuscarForese(int id)
        {
            return certificacionMasterServicio.BuscarForese(id);
        }
        public bool Anular()
        {
            bool respuesta = false;
            if (listaCertificacionMasterVista.certificacionMaster != null)
                respuesta = this.certificacionMasterServicio.Anular(1, listaCertificacionMasterVista.certificacionMaster, listaCertificacionMasterVista.UsuarioOperacion.NomUsuario).esCorrecto;
            return respuesta;
        }
        public List<UsuarioCorreoPres> TraerListaUsuarioCorreo()
        {
            return certificacionRequerimientoServicio.TraerListaUsuarioCorreo();
        }
        public List<CertificacionRequerimiento> listarCertificacionRequerimientoPorIdCerMas(int idCerMas)
        {
            return certificacionRequerimientoServicio.listarCertificacionRequerimientoPorIdCerMas(idCerMas);
        }
        public List<ReporteCertificacionPresupuestalPres> TraerReporteCertificacionPresupuestalVarios(string idsCerReq, bool esAmpliacion)
        {
            return certificacionRequerimientoServicio.TraerReporteCertificacionPresupuestalVarios(idsCerReq, esAmpliacion);
        }
        //public List<ReporteCertificacionPresupuestalPres> TraerReporteCertificacionPresupuestal()
        //{
        //    return certificacionMasterServicio.TraerReporteCertificacionPresupuestal(listaCertificacionMasterVista.certificacionRequerimiento.idCerReq);
        //}
        //public void ReporteCertificacionPresupuestal(List<ReporteCertificacionPresupuestalPres> TraerReporteCertificacionPresupuestal)
        //{
        //    LlamarReporte(new rptCertificacionPresupuestal(), TraerReporteCertificacionPresupuestal);
        //}
        //private void LlamarReporte(XtraReport report, object datosReporte)
        //{
        //    ReporteWinForDev frm = new ReporteWinForDev();
        //    List<ParametrosReporte> p = new List<ParametrosReporte>();
        //    //p.Add(new ParametrosReporte { nombre = "Periodo", valor = titulo, tipo = TipoParametroReporteDev.Cadena });
        //    frm.report = report;
        //    frm.datosReporte = datosReporte;
        //    frm.listaParametros = p;
        //    frm.AbrirDocumento(true, false);
        //}

    }
}
