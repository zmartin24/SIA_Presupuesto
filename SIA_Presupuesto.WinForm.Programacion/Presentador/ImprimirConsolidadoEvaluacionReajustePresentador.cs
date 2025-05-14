using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Helper;
using SIA_Presupuesto.WinForm.Programacion.Helper;
using SIA_Presupuesto.WinForm.Programacion.Reporte;
using SIA_Presupuesto.WinForm.Programacion.Vista;
using SIA_Presupuesto.WinForm.Reporte;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilitario.Reporte;
using Utilitario.Util;

namespace SIA_Presupuesto.WinForm.Programacion.Presentador
{
    public class ImprimirConsolidadoEvaluacionReajustePresentador
    {
        private readonly IImprimirConsolidadoEvaluacionReajusteAnualVista imprimirConsolidadoEvaluacionReajusteAnualVista;
        private IReajusteMensualProgramacionServicio reajusteMensualProgramacionServicio;
        private IGeneralServicio generalServicio;
        private IFuenteFinanciamientoServicio fuenteServicio;
        private IGrupoPresupuestoServicio grupoServicio;

        public ImprimirConsolidadoEvaluacionReajustePresentador(IImprimirConsolidadoEvaluacionReajusteAnualVista imprimirConsolidadoEvaluacionReajusteAnualVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.reajusteMensualProgramacionServicio = _Contenedor.Resolver(typeof(IReajusteMensualProgramacionServicio)) as IReajusteMensualProgramacionServicio;
            this.generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;
            this.fuenteServicio = _Contenedor.Resolver(typeof(IFuenteFinanciamientoServicio)) as IFuenteFinanciamientoServicio;
            this.grupoServicio = _Contenedor.Resolver(typeof(IGrupoPresupuestoServicio)) as IGrupoPresupuestoServicio;

            this.imprimirConsolidadoEvaluacionReajusteAnualVista = imprimirConsolidadoEvaluacionReajusteAnualVista;
        } 

        public void Inicializar()
        {
            imprimirConsolidadoEvaluacionReajusteAnualVista.listaAnios = UtilitarioComun.ListarAnios(DateTime.Now.Year, 2017);
            imprimirConsolidadoEvaluacionReajusteAnualVista.anioReporte = DateTime.Now.Year;

            imprimirConsolidadoEvaluacionReajusteAnualVista.listaMeses = UtilitarioComun.ListarMeses();
            imprimirConsolidadoEvaluacionReajusteAnualVista.listaMesesRea = UtilitarioComun.ListarMeses();
            imprimirConsolidadoEvaluacionReajusteAnualVista.mesReporte = DateTime.Now.Month;

            List<FuenteFinanciamiento> lista = new List<FuenteFinanciamiento>();
            lista.Add(new FuenteFinanciamiento { idFueFin = 0, anio = DateTime.Now.Year, fuente = "[TODOS]" });
            lista.AddRange(fuenteServicio.TraerListaFuenteFinanciamiento(imprimirConsolidadoEvaluacionReajusteAnualVista.anioReporte));
           
            imprimirConsolidadoEvaluacionReajusteAnualVista.listaFueFin = lista;
            imprimirConsolidadoEvaluacionReajusteAnualVista.idFueFin = 0;
        }

        public void AsignarMesReajuste()
        {
            imprimirConsolidadoEvaluacionReajusteAnualVista.mesReporteRea = imprimirConsolidadoEvaluacionReajusteAnualVista.mesReporte == 12 ? imprimirConsolidadoEvaluacionReajusteAnualVista.mesReporte :
                imprimirConsolidadoEvaluacionReajusteAnualVista.mesReporte + 1;
        }

        public void ImprimirCalenarios()
        {
            ImprimirCalendario();
        }

        private void ExportarRequerimientoDireccion(List<RequerimientoBienServicioDetallePresExporta> lista)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel XLSX|*.xlsx";
                sfd.Title = "Guardar el siguiente archivo";

                string ruta = Path.GetTempPath() + "Requerimiento_" + Path.GetRandomFileName() + ".xlsx";

                ExportarProHelper.ExportarRequerimientos(ruta, lista);
                ExportarHelper.AbrirArchivoExcel(ruta);
            }
        }

        public void ImprimirCalendario()
        {
            List<ConsolidadoEvaluacionReajuste> comp =
            reajusteMensualProgramacionServicio.TraerConsolidadoEvaluacionReajustePorDirecciones(imprimirConsolidadoEvaluacionReajusteAnualVista.anioReporte, imprimirConsolidadoEvaluacionReajusteAnualVista.idFueFin,
            imprimirConsolidadoEvaluacionReajusteAnualVista.mesReporteRea, imprimirConsolidadoEvaluacionReajusteAnualVista.mesReporte);
            rptEvaReaConsolidadoPorDireccion reporte = new rptEvaReaConsolidadoPorDireccion();
            //string titulo = "COMPROBANTE DE INGRESO";

            ReporteWinForDev frm = new ReporteWinForDev();
            List<ParametrosReporte> p = new List<ParametrosReporte>();
            frm.report = reporte;
            frm.datosReporte = comp;
            frm.listaParametros = p;
            frm.AbrirDocumento(true, false);
        }
    }
}
