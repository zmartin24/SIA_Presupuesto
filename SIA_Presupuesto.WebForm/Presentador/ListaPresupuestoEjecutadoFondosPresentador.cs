using DevExpress.XtraReports.UI;
using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.Enumeradores;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WebForm.Helper;
using SIA_Presupuesto.WebForm.Reporte;
using SIA_Presupuesto.WebForm.Vista;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilitario.Reporte;
using Utilitario.Util;

namespace SIA_Presupuesto.WebForm.Presentador
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
            this.listaPresupuestoEjecutadoFondosVista = listaPresupuestoEjecutadoFondosVista;
        }

        public void CargarServicios()
        {
            this.generalServicio = IoCHelper.ResolverIoC<IGeneralServicio>();
            this.generalReporteServicio = IoCHelper.ResolverIoC<IGeneralReporteServicio>();
            this.grupoPresupuestoServicio = IoCHelper.ResolverIoC<IGrupoPresupuestoServicio>();
            //this.presupuestoServicio = IoCHelper.ResolverIoC<IPresupuestoServicio>();
            //this.programacionAnualServicio = IoCHelper.ResolverIoC<IProgramacionAnualServicio>();
            //this.subpresupuestoServicio = IoCHelper.ResolverIoC<ISubpresupuestoServicio>();

            this.listaReporteExporta = new List<ReporteEvaluacionDetalladaBienSerExportaPres>();
        }

        public void Iniciar()
        {
            listaPresupuestoEjecutadoFondosVista.listaAnios = UtilitarioComun.ListarAnios(DateTime.Now.AddYears(1).Year, 2018);
            listaPresupuestoEjecutadoFondosVista.anioPresentacion = DateTime.Now.Year;

            var listaMes = UtilitarioComun.ListarMeses();
            if (listaMes != null && listaMes.Count > 0)
            {
                this.listaPresupuestoEjecutadoFondosVista.listaMeses = listaMes;
                this.listaPresupuestoEjecutadoFondosVista.idMes = DateTime.Now.Month;
            }

            var listaMonedas = generalServicio.ListaMonedas().Where(x => x.idMoneda != 5926).ToList();
            if (listaMonedas != null)
            {
                listaPresupuestoEjecutadoFondosVista.listaMonedas = listaMonedas;
                listaPresupuestoEjecutadoFondosVista.idMoneda = (Int32)listaMonedas.FirstOrDefault().idMoneda;
            }

        }
       
        public List<ReportePresupuestoEjecutadoFondosPres> TraerListaReportePresupuestoEjecutadoFondosPres()
        {
            //this.evaluacionPresupuestoCuentaServicio = IoCHelper.ResolverIoC<IEvaluacionPresupuestoCuentaServicio>();
            if (this.listaPresupuestoEjecutadoFondosVista.idMes > 0)
                return generalReporteServicio.TraerReportePresupuestoEjecutadoFondos(this.listaPresupuestoEjecutadoFondosVista.idMoneda,this.listaPresupuestoEjecutadoFondosVista.anioPresentacion, 1,this.listaPresupuestoEjecutadoFondosVista.idMes, string.Empty);
            else
                return null;
        }

        public void llenarGridPivot()
        {
            this.listaPresupuestoEjecutadoFondosVista.listaDatosPrincipales = generalReporteServicio.TraerReportePresupuestoEjecutadoFondos(this.listaPresupuestoEjecutadoFondosVista.idMoneda,
                                                                                                                                            this.listaPresupuestoEjecutadoFondosVista.anioPresentacion, 1,
                                                                                                                                            this.listaPresupuestoEjecutadoFondosVista.idMes, string.Empty
                                                                                                                                            );
        }

        public string ExportarEvaluacion(List<EvaluacionPresupuestoPorCuentasPres> lista, string vpresupuesto, string vsubPresupuesto)
        {
            string ruta = string.Empty;
            if (lista.Count > 0)
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    string format = "yyyy-MM-dd_hh.mm.ss.tt";
                    sfd.Filter = "Excel XLSX|*.xlsx";
                    sfd.Title = "Guardar el siguiente archivo";

                    ruta = Path.GetTempPath() + "EvaluacionPorCuenta_" + DateTime.Now.ToString(format).ToLower() + ".xlsx";

                    //ExportarProHelper.ExportarEvaluacionPresupuestoPorCuentas(ruta, lista.OrderBy(o => o.numCuenta).ToList(), listaEvaluacionPresupuestoCuentaVista.idMoneda, vpresupuesto, vsubPresupuesto);

                }
            }

            return ruta;
        }



    }
}
