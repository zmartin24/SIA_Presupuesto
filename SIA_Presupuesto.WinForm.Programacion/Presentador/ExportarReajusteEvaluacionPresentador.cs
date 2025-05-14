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
    public class ExportarReajusteEvaluacionPresentador
    {
        private readonly IExportarReajusteEvaluacionVista exportarReajusteEvaluacionVista;
        private IReajusteMensualProgramacionServicio reajusteMensualProgramacionServicio;
        private IGeneralServicio generalServicio;
        private IGrupoPresupuestoServicio grupoServicio;
        private IEvaluacionMensualProgramacionServicio evaluacionMensualProgramacionServicio;
        private IProgramacionAnualServicio programacionServicio;

        public ExportarReajusteEvaluacionPresentador(IExportarReajusteEvaluacionVista exportarReajusteEvaluacionVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.reajusteMensualProgramacionServicio = _Contenedor.Resolver(typeof(IReajusteMensualProgramacionServicio)) as IReajusteMensualProgramacionServicio;
            this.generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;
            this.evaluacionMensualProgramacionServicio = _Contenedor.Resolver(typeof(IEvaluacionMensualProgramacionServicio)) as IEvaluacionMensualProgramacionServicio;
            this.grupoServicio = _Contenedor.Resolver(typeof(IGrupoPresupuestoServicio)) as IGrupoPresupuestoServicio;
            this.programacionServicio = _Contenedor.Resolver(typeof(IProgramacionAnualServicio)) as IProgramacionAnualServicio;
            this.exportarReajusteEvaluacionVista = exportarReajusteEvaluacionVista;
        } 

        public void Inicializar()
        {
            this.exportarReajusteEvaluacionVista.listaAnios = UtilitarioComun.ListarAnios(DateTime.Now.Year, 2017);
            this.exportarReajusteEvaluacionVista.anioReporte = DateTime.Now.Year;

            this.exportarReajusteEvaluacionVista.listaMeses = UtilitarioComun.ListarMeses();
            this.exportarReajusteEvaluacionVista.listaMesesRea = UtilitarioComun.ListarMeses();
            this.exportarReajusteEvaluacionVista.mesReporte = DateTime.Now.Month;

            var lista = generalServicio.ListaMonedas();
            if (lista.Count > 0)
            {
                this.exportarReajusteEvaluacionVista.listaMoneda = generalServicio.ListaMonedas();
                this.exportarReajusteEvaluacionVista.idMoneda = 63;
            }

            CargarProgramacionAnual();
        }

        public void CargarProgramacionAnual()
        {
            exportarReajusteEvaluacionVista.listaProgramacionAnual = programacionServicio.TraerListaProgramacionAnual(exportarReajusteEvaluacionVista.anioReporte);
        }

        public void AsignarMesReajuste()
        {
            exportarReajusteEvaluacionVista.mesReporteRea = exportarReajusteEvaluacionVista.mesReporte == 12 ? exportarReajusteEvaluacionVista.mesReporte :
                exportarReajusteEvaluacionVista.mesReporte + 1;
        }
        public void Exportar()
        {
            ExportarEvaluacionReajuste();
        }
        public void ExportarEvaluacionReajuste()
        {
            List<EvaluacionReajusteMensualAreaExporta> lista = evaluacionMensualProgramacionServicio.TraerListaEvaluacionReajusteMensualAreaExporta(exportarReajusteEvaluacionVista.idProAnu, exportarReajusteEvaluacionVista.anioReporte, exportarReajusteEvaluacionVista.mesReporteRea, exportarReajusteEvaluacionVista.mesReporte);   
        }
        public List<ReporteEvaluacionReajusteMensualExportaPres> TraerReporteEvaluacionReajusteMensualExporta()
        {
            return this.evaluacionMensualProgramacionServicio.TraerReporteEvaluacionReajusteMensualExporta(exportarReajusteEvaluacionVista.idProAnu, exportarReajusteEvaluacionVista.anioReporte, exportarReajusteEvaluacionVista.mesReporteRea, exportarReajusteEvaluacionVista.mesReporte, exportarReajusteEvaluacionVista.idMoneda);
        }
    }
}
