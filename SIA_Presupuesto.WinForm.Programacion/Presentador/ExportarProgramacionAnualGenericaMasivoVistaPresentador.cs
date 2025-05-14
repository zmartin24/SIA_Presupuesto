using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.Programacion.Vista;
using System;
using System.Collections.Generic;
using Utilitario.Util;

namespace SIA_Presupuesto.WinForm.Programacion.Presentador
{
    public class ExportarProgramacionAnualGenericaMasivoVistaPresentador
    {
        private readonly IExportarProgramacionAnualGenericaMasivoVista exportarProgramacionAnualGenericaMasivoVista;

        private IGeneralServicio generalServicio;
        private IGeneralReporteServicio generalReporteServicio;
        private IProgramacionAnualServicio programacionServicio;

        public ExportarProgramacionAnualGenericaMasivoVistaPresentador(IExportarProgramacionAnualGenericaMasivoVista exportarProgramacionAnualGenericaMasivoVista)
        {
            IContenedor _Contenedor = new cContenedor();

            this.generalServicio = _Contenedor.Resolver(typeof(IGeneralServicio)) as IGeneralServicio;
            this.generalReporteServicio = _Contenedor.Resolver(typeof(IGeneralReporteServicio)) as IGeneralReporteServicio;
            this.programacionServicio = _Contenedor.Resolver(typeof(IProgramacionAnualServicio)) as IProgramacionAnualServicio;

            this.exportarProgramacionAnualGenericaMasivoVista = exportarProgramacionAnualGenericaMasivoVista;
        } 

        public void Inicializar()
        {
            exportarProgramacionAnualGenericaMasivoVista.listaAnios = UtilitarioComun.ListarAnios(DateTime.Now.Year, 2017);
            exportarProgramacionAnualGenericaMasivoVista.anioReporte = DateTime.Now.Year;

            var lista = this.generalServicio.ListaMonedas();

            if (lista.Count > 0)
            {
                this.exportarProgramacionAnualGenericaMasivoVista.listaMoneda = lista;
            }
            this.exportarProgramacionAnualGenericaMasivoVista.idMoneda = 63;

            CargarProgramacionAnual();
        }

        public void CargarProgramacionAnual()
        {
            exportarProgramacionAnualGenericaMasivoVista.listaProgramacionAnual = this.programacionServicio.TraerListaProgramacionAnual(exportarProgramacionAnualGenericaMasivoVista.anioReporte);
        }

        public List<ReporteProgramacionAnualGenericaGastosPres> TraerReporteProgramacionAnualGenericaGastos()
        {
            return this.generalReporteServicio.TraerReporteProgramacionAnualGenericaGastos(this.exportarProgramacionAnualGenericaMasivoVista.idsProAnu, this.exportarProgramacionAnualGenericaMasivoVista.idMoneda);
        }
        public List<ReporteProgramacionAnualExportaMasivoPres> TraerReporteProgramacionAnualExportaMasivo()
        {
            return this.programacionServicio.TraerReporteProgramacionAnualExportaMasivo(this.exportarProgramacionAnualGenericaMasivoVista.idsProAnu, this.exportarProgramacionAnualGenericaMasivoVista.idMoneda);
        }
    }
}
