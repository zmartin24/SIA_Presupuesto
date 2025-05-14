using DevExpress.XtraReports.UI;
using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.WinForm.Adquisicion.Reporte;
using SIA_Presupuesto.WinForm.Adquisicion.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using Utilitario.Reporte;
using Utilitario.Util;

namespace SIA_Presupuesto.WinForm.Adquisicion.Presentador
{
    public class ListaPresupuestoEjecutadoPresentador
    {
        private readonly IListaPresupuestoEjecutadoVista listaPresupuestoEjecutadoVista;
        private IGeneralReporteServicio generalReporteServicio;
        private IGeneralServicio generalServicio;
       
        public ListaPresupuestoEjecutadoPresentador(IListaPresupuestoEjecutadoVista listaPresupuestoEjecutadoVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.generalReporteServicio = _Contenedor.Resolver(typeof(IGeneralReporteServicio)) as IGeneralReporteServicio;
            this.generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;

            this.listaPresupuestoEjecutadoVista = listaPresupuestoEjecutadoVista;
        }
        public void IniciarDatos()
        {
            var listaAnio = UtilitarioComun.ListarAnios(DateTime.Now.Date.AddYears(1).Year, 2015);//PredeterminadoHelper.ListaAnio();
            if (listaAnio != null)
            {
                this.listaPresupuestoEjecutadoVista.listaAnio = listaAnio;
                this.listaPresupuestoEjecutadoVista.anio = DateTime.Now.Year;
            }

            var listaMes = UtilitarioComun.ListarMeses();
            if (listaMes != null && listaMes.Count > 0)
            {
                this.listaPresupuestoEjecutadoVista.listaMes = listaMes;
                this.listaPresupuestoEjecutadoVista.mes = DateTime.Now.Month;
            }

            var listaMoneda = generalServicio.ListaMonedas().Where(x => x.idMoneda != 5926).ToList();
            if (listaMoneda != null)
            {
                this.listaPresupuestoEjecutadoVista.listaMoneda = listaMoneda;
                this.listaPresupuestoEjecutadoVista.idMoneda = 63;
            }
            
        }
        public void llenarGridPivot()
        {
            this.listaPresupuestoEjecutadoVista.listaSplash = generalReporteServicio.TraerReportePresupuestoEjecutado(this.listaPresupuestoEjecutadoVista.idMoneda,
                                                                                                                                            this.listaPresupuestoEjecutadoVista.anio,1,
                                                                                                                                            this.listaPresupuestoEjecutadoVista.mes,string.Empty
                                                                                                                                            );
        }

        public List<object> TraerReporteCertificacionOrdenProvision()
        {
            return generalReporteServicio.TraerReporteCertificacionOrdenProvision(
                                                this.listaPresupuestoEjecutadoVista.anio,
                                                this.listaPresupuestoEjecutadoVista.mes,
                                                this.listaPresupuestoEjecutadoVista.idMoneda
                                 ).ToList<object>().ToList();
        }

        public void Imprimir(List<object> vlista)
        {
            XtraReport reporte = new XtraReport();

            reporte = new rptReporteCertificacionOrdenProvision();


            ReporteWinForDev frm = new ReporteWinForDev();
            List<ParametrosReporte> p = new List<ParametrosReporte>();
            frm.report = reporte;
            frm.datosReporte = vlista;
            frm.listaParametros = p;
            frm.AbrirDocumento(true, false);

        }
    }
}
