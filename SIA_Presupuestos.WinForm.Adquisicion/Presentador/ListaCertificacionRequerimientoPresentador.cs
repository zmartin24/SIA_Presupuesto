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
    public class ListaCertificacionRequerimientoPresentador
    {
        private readonly IListaCertificacionRequerimientoVista listaCertificacionRequerimientoVista;
        private ICertificacionRequerimientoServicio certificacionRequerimientoServicio;
        public ListaCertificacionRequerimientoPresentador(IListaCertificacionRequerimientoVista listaCertificacionRequerimientoVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.certificacionRequerimientoServicio = _Contenedor.Resolver(typeof(ICertificacionRequerimientoServicio)) as ICertificacionRequerimientoServicio;

            this.listaCertificacionRequerimientoVista = listaCertificacionRequerimientoVista;
        }
        public void Iniciar()
        {
            this.listaCertificacionRequerimientoVista.listaAnios = UtilitarioComun.ListarAnios(DateTime.Now.Date.AddYears(1).Year, 2018);
            this.listaCertificacionRequerimientoVista.anioPresentacion = DateTime.Now.Date.Year;
        }
        public void ObtenerDatosListado()
        {
            listaCertificacionRequerimientoVista.listaDatosPrincipales = certificacionRequerimientoServicio.TraerListaCertificacionRequerimiento(listaCertificacionRequerimientoVista.anioPresentacion);
        }

        public CertificacionRequerimiento Buscar(int vidCerReq)
        {
            return certificacionRequerimientoServicio.BuscarPorCodigo(vidCerReq);
        }
        public bool Anular()
        {
            bool respuesta = false;
            //if (listaCertificacionRequerimientoVista.certificacionRequerimiento != null)
            //    respuesta = this.certificacionRequerimientoServicio.Anular(listaCertificacionRequerimientoVista.certificacionRequerimiento, listaCertificacionRequerimientoVista.UsuarioOperacion.NomUsuario).esCorrecto;
            return respuesta;
        }
        public List<ReporteCertificacionPresupuestalPres> TraerReporteCertificacionPresupuestal()
        {
            return certificacionRequerimientoServicio.TraerReporteCertificacionPresupuestal(listaCertificacionRequerimientoVista.certificacionRequerimiento.idCerReq, false);
        }
        public void ReporteCertificacionPresupuestal(List<ReporteCertificacionPresupuestalPres> TraerReporteCertificacionPresupuestal)
        {
            LlamarReporte(new rptCertificacionPresupuestal(), TraerReporteCertificacionPresupuestal);
        }
        private void LlamarReporte(XtraReport report, object datosReporte)
        {
            ReporteWinForDev frm = new ReporteWinForDev();
            List<ParametrosReporte> p = new List<ParametrosReporte>();
            //p.Add(new ParametrosReporte { nombre = "Periodo", valor = titulo, tipo = TipoParametroReporteDev.Cadena });
            frm.report = report;
            frm.datosReporte = datosReporte;
            frm.listaParametros = p;
            frm.AbrirDocumento(true, false);
        }

    }
}
