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
    public class ImprimirSaldoEvaluacionReajustePresentador
    {
        private readonly IImprimirSaldoEvaluacionReajusteAnualVista imprimirSaldoEvaluacionReajusteAnualVista;
        //private IReajusteMensualProgramacionServicio reajusteMensualProgramacionServicio;
        //private IGeneralServicio generalServicio;
        //private IFuenteFinanciamientoServicio fuenteServicio;
        //private IGrupoPresupuestoServicio grupoServicio;
        private IGeneralReporteServicio generalReporteServicio;

        public ImprimirSaldoEvaluacionReajustePresentador(IImprimirSaldoEvaluacionReajusteAnualVista imprimirSaldoEvaluacionReajusteAnualVista)
        {
            IContenedor _Contenedor = new cContenedor();
            //this.reajusteMensualProgramacionServicio = _Contenedor.Resolver(typeof(IReajusteMensualProgramacionServicio)) as IReajusteMensualProgramacionServicio;
            //this.generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;
            //this.fuenteServicio = _Contenedor.Resolver(typeof(IFuenteFinanciamientoServicio)) as IFuenteFinanciamientoServicio;
            //this.grupoServicio = _Contenedor.Resolver(typeof(IGrupoPresupuestoServicio)) as IGrupoPresupuestoServicio;
            this.generalReporteServicio = _Contenedor.Resolver(typeof(IGeneralReporteServicio)) as IGeneralReporteServicio;
            this.imprimirSaldoEvaluacionReajusteAnualVista = imprimirSaldoEvaluacionReajusteAnualVista;
        } 

        public void Inicializar()
        {
            imprimirSaldoEvaluacionReajusteAnualVista.listaAnios = UtilitarioComun.ListarAnios(DateTime.Now.Year, 2017);
            imprimirSaldoEvaluacionReajusteAnualVista.anioReporte = DateTime.Now.Year;

            imprimirSaldoEvaluacionReajusteAnualVista.listaMeses = UtilitarioComun.ListarMeses();
            imprimirSaldoEvaluacionReajusteAnualVista.listaMesesRea = UtilitarioComun.ListarMeses();
            imprimirSaldoEvaluacionReajusteAnualVista.mesReporte = DateTime.Now.Month;

        }

        public void AsignarMesReajuste()
        {
            imprimirSaldoEvaluacionReajusteAnualVista.mesReporteRea = imprimirSaldoEvaluacionReajusteAnualVista.mesReporte == 12 ? imprimirSaldoEvaluacionReajusteAnualVista.mesReporte :
                imprimirSaldoEvaluacionReajusteAnualVista.mesReporte + 1;
        }

        public void ImprimirCalenarios()
        {
            ImprimirCalendario();
        }

        private void ExportarSaldo(List<RequerimientoBienServicioDetallePresExporta> lista)
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

            List<SaldosEvaReaPorDir> comp =
            generalReporteServicio.SaldosEvaluacionReajustePorDirecciones(imprimirSaldoEvaluacionReajusteAnualVista.anioReporte, imprimirSaldoEvaluacionReajusteAnualVista.mesReporteRea, imprimirSaldoEvaluacionReajusteAnualVista.mesReporte);
            rptSaldoEvaluacionReajustePorDireccion reporte = new rptSaldoEvaluacionReajustePorDireccion();
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
