using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Helper;
using SIA_Presupuesto.WinForm.Programacion.Helper;
using SIA_Presupuesto.WinForm.Programacion.Vista;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using Utilitario.Util;

namespace SIA_Presupuesto.WinForm.Programacion.Presentador
{
    public class ExportarReajusteEvaluacionMasivoPresentador
    {
        private readonly IExportarReajusteEvaluacionMasivoVista exportarReajusteEvaluacionVista;
        private IReajusteMensualProgramacionServicio reajusteMensualProgramacionServicio;
        private IGeneralServicio generalServicio;
        private IGrupoPresupuestoServicio grupoServicio;
        private IEvaluacionMensualProgramacionServicio evaluacionMensualProgramacionServicio;
        private IProgramacionAnualServicio programacionServicio;

        public ExportarReajusteEvaluacionMasivoPresentador(IExportarReajusteEvaluacionMasivoVista exportarReajusteEvaluacionVista)
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
            exportarReajusteEvaluacionVista.listaAnios = UtilitarioComun.ListarAnios(DateTime.Now.Year, 2017);
            exportarReajusteEvaluacionVista.anioReporte = DateTime.Now.Year;

            exportarReajusteEvaluacionVista.listaMeses = UtilitarioComun.ListarMeses();
            exportarReajusteEvaluacionVista.listaMesesRea = UtilitarioComun.ListarMeses();
            exportarReajusteEvaluacionVista.mesReporte = DateTime.Now.Month;

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
            List<EvaluacionReajusteMensualAreaExporta> lista = evaluacionMensualProgramacionServicio.TraerListaEvaluacionReajusteMensualAreaExporta(exportarReajusteEvaluacionVista.idsProAnu, exportarReajusteEvaluacionVista.anioReporte, exportarReajusteEvaluacionVista.mesReporteRea, exportarReajusteEvaluacionVista.mesReporte);
            ExportarEvaluacionReajuste(lista);
        }

        private void ExportarEvaluacionReajuste(List<EvaluacionReajusteMensualAreaExporta> lista)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                string format = "yyyy-MM-dd_hh.mm.ss.tt";
                sfd.Filter = "Excel XLSX|*.xlsx";
                sfd.Title = "Guardar el siguiente archivo";

                string ruta = Path.GetTempPath() + "EvaluacionReajuste_" + DateTime.Now.ToString(format, CultureInfo.InvariantCulture).ToLower() + ".xlsx";

                ExportarProHelper.ExportarEvaluacionReajusteMensualConCantidad(ruta, lista, exportarReajusteEvaluacionVista.mesReporteRea);
                ExportarHelper.AbrirArchivoExcel(ruta);
            }
        }
    }
}
