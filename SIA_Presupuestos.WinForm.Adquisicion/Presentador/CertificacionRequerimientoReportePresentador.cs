using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.Adquisicion.Vista;
using SIA_Presupuesto.WinForm.General.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using Utilitario.Util;

namespace SIA_Presupuesto.WinForm.Adquisicion.Presentador
{
    public class CertificacionRequerimientoReportePresentador
    {
        private readonly ICertificacionRequerimientoReporteVista certificacionRequerimientoReporteVista;
        private ICertificacionRequerimientoServicio certificacionRequerimientoServicio;

        public CertificacionRequerimientoReportePresentador(ICertificacionRequerimientoReporteVista certificacionRequerimientoReporteVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.certificacionRequerimientoServicio = _Contenedor.Resolver(typeof(ICertificacionRequerimientoServicio)) as ICertificacionRequerimientoServicio;
            this.certificacionRequerimientoReporteVista = certificacionRequerimientoReporteVista;
        }
        public void IniciarDatos()
        {
            var listaAnio = UtilitarioComun.ListarAnios(DateTime.Now.Date.Year, 2020);
            if (listaAnio != null)
            {
                certificacionRequerimientoReporteVista.listaAnio = listaAnio;
                certificacionRequerimientoReporteVista.anio = DateTime.Now.Year;
            }

            var listaReporte = PredeterminadoHelper.ListarTipoCertifiacionRequerimientoReporte();
            if (listaReporte != null)
            {
                certificacionRequerimientoReporteVista.listaReporte = listaReporte;
                certificacionRequerimientoReporteVista.codReporte = Convert.ToInt32(listaReporte.OrderBy(x => x.codigo).FirstOrDefault().codigo);
            }
        }
        public List<CertificacionRequerimientoExportaPres> TraerListaCertificacionRequerimientoExporta()
        {
            return this.certificacionRequerimientoServicio.TraerListaCertificacionRequerimientoExporta(this.certificacionRequerimientoReporteVista.codReporte, this.certificacionRequerimientoReporteVista.anio);
        }
    }
}
