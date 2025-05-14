using DevExpress.XtraReports.UI;
using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.Adquisicion.Helper;
using SIA_Presupuesto.WinForm.Adquisicion.Reporte;
using SIA_Presupuesto.WinForm.Adquisicion.Vista;
using SIA_Presupuesto.WinForm.General.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilitario.Reporte;
using Utilitario.Util;

namespace SIA_Presupuesto.WinForm.Adquisicion.Presentador
{
    public class ListaPresupuestoEjecutadoFondosPresentador
    {
        private readonly IListaPresupuestoEjecutadoFondosVista listaPresupuestoEjecutadoFondosVista;
        private IGeneralReporteServicio generalReporteServicio;
        private IGeneralServicio generalServicio;
        private IGrupoPresupuestoServicio grupoPresupuestoServicio;
        private List<ReporteEvaluacionDetalladaBienSerExportaPres> listaReporteExporta;
        public ListaPresupuestoEjecutadoFondosPresentador(IListaPresupuestoEjecutadoFondosVista listaPresupuestoEjecutadoFondosVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.generalReporteServicio = _Contenedor.Resolver(typeof(IGeneralReporteServicio)) as IGeneralReporteServicio;
            this.generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;
            this.grupoPresupuestoServicio = _Contenedor.Resolver(typeof(IGrupoPresupuestoServicio)) as IGrupoPresupuestoServicio;

            this.listaPresupuestoEjecutadoFondosVista = listaPresupuestoEjecutadoFondosVista;
            this.listaReporteExporta = new List<ReporteEvaluacionDetalladaBienSerExportaPres>();
        }
        public void IniciarDatos()
        {
            var listaAnio = UtilitarioComun.ListarAnios(DateTime.Now.Date.AddYears(1).Year, 2015);//PredeterminadoHelper.ListaAnio();
            if (listaAnio != null)
            {
                this.listaPresupuestoEjecutadoFondosVista.listaAnio = listaAnio;
                this.listaPresupuestoEjecutadoFondosVista.vanio = DateTime.Now.Year;
            }

            var listaMes = UtilitarioComun.ListarMeses();
            if (listaMes != null && listaMes.Count > 0)
            {
                this.listaPresupuestoEjecutadoFondosVista.listaMes = listaMes;
                this.listaPresupuestoEjecutadoFondosVista.mes = DateTime.Now.Month;
            }

            var listaMoneda = generalServicio.ListaMonedas().Where(x => x.idMoneda != 5926).ToList();
            if (listaMoneda != null)
            {
                this.listaPresupuestoEjecutadoFondosVista.listaMoneda = listaMoneda;
                this.listaPresupuestoEjecutadoFondosVista.idMoneda = 63;
            }
            
        }
        public void llenarGridPivot()
        {
            this.listaPresupuestoEjecutadoFondosVista.listaSplash = generalReporteServicio.TraerReportePresupuestoEjecutadoFondos(this.listaPresupuestoEjecutadoFondosVista.idMoneda,
                                                                                                                                            this.listaPresupuestoEjecutadoFondosVista.vanio,1,
                                                                                                                                            this.listaPresupuestoEjecutadoFondosVista.mes,string.Empty
                                                                                                                                            );
        }

        public List<object> TraerReporteCertificacionOrdenProvision()
        {
            return generalReporteServicio.TraerReporteCertificacionOrdenProvision(
                                                this.listaPresupuestoEjecutadoFondosVista.vanio,
                                                this.listaPresupuestoEjecutadoFondosVista.mes,
                                                this.listaPresupuestoEjecutadoFondosVista.idMoneda
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
