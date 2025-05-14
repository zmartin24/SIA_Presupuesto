using DevExpress.XtraReports.UI;
using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Helper;
using SIA_Presupuesto.WinForm.Programacion.Helper;
using SIA_Presupuesto.WinForm.Programacion.Reporte;
using SIA_Presupuesto.WinForm.Programacion.Vista;
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
    public class ListaProgramacionAnualPresentador
    {
        private readonly IListaProgramacionAnualVista listaProgramacionAnualVista;
        private IProgramacionAnualServicio programacionAnualServicio;
        private IPresupuestoRemuneracionServicio presupuestoRemuneracionServicio;
        private IPeriodoServicio periodoServicio;
        public ListaProgramacionAnualPresentador(IListaProgramacionAnualVista IListaProgramacionAnualVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.programacionAnualServicio = _Contenedor.Resolver(typeof(IProgramacionAnualServicio)) as IProgramacionAnualServicio;
            this.presupuestoRemuneracionServicio = _Contenedor.Resolver(typeof(IPresupuestoRemuneracionServicio)) as IPresupuestoRemuneracionServicio;
            this.periodoServicio = _Contenedor.Resolver(typeof(IPeriodoServicio)) as IPeriodoServicio;
            this.listaProgramacionAnualVista = IListaProgramacionAnualVista;
        }

        public void Iniciar()
        {
            listaProgramacionAnualVista.listaAnios = UtilitarioComun.ListarAnios(DateTime.Now.Date.AddYears(1).Year, 2005);

            listaProgramacionAnualVista.anioPresentacion = this.periodoServicio.ObtenerActivo().anio;//DateTime.Now.Date.AddYears(1).Year;
        }

        public void ObtenerDatosListado()
        {
            listaProgramacionAnualVista.listaDatosPrincipales = programacionAnualServicio.TraerListaProgramacionAnual(listaProgramacionAnualVista.anioPresentacion);
        }

        public ProgramacionAnual Buscar(int id)
        {
            return programacionAnualServicio.BuscarPorCodigo(id);
        }

        private void LlamarReporte(XtraReport report, object datosReporte, string titulo)
        {
            ReporteWinForDev frm = new ReporteWinForDev();
            List<ParametrosReporte> p = new List<ParametrosReporte>();
            //p.Add(new ParametrosReporte { nombre = "Titulo", valor = titulo, tipo = TipoParametroReporteDev.Cadena });
            frm.report = report;
            frm.datosReporte = datosReporte;
            frm.listaParametros = p;
            frm.AbrirDocumento(true, false);
        }

        public void ReporteConsolidadoPorDireccion()
        {
            rptPresConsolidadoPorDireccion rpt = new rptPresConsolidadoPorDireccion();
            List<ConsolidadoPresupuesto> lista = programacionAnualServicio.TraerConsolidadoPresupuestoPorDirecciones(listaProgramacionAnualVista.anioPresentacion);
            LlamarReporte(rpt, lista, "");
        }


        public bool AnularRegistro()
        {
            return listaProgramacionAnualVista.ProgramacionAnual != null ? programacionAnualServicio.Anular(listaProgramacionAnualVista.ProgramacionAnual, listaProgramacionAnualVista.UsuarioOperacion.NomUsuario).esCorrecto : false;
        }

        public void ExportarProgramacionAnual()
        {
            if (listaProgramacionAnualVista.ProgramacionAnual != null)
            {
                List<ProgramacionAnualAreaExporta> lista = programacionAnualServicio.TraerListaProgramacionAnualAreaExporta(listaProgramacionAnualVista.ProgramacionAnual.idProAnu);
                if (lista.Count > 0)
                    ExportarProgramacionAnual(lista);
            }
        }


        private void ExportarProgramacionAnual(List<ProgramacionAnualAreaExporta> lista)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel XLSX|*.xlsx";
                sfd.Title = "Guardar el siguiente archivo";

                string ruta = Path.GetTempPath() + "ProgramacionAnual_" + Path.GetRandomFileName() + ".xlsx";

                ExportarProHelper.ExportarProgramacionAnual(ruta, lista);
                ExportarHelper.AbrirArchivoExcel(ruta);
            }
        }

        //
        public void ExportarPresupuestoRemuneracion()
        {
            if (listaProgramacionAnualVista.ProgramacionAnual != null)
            {
                List<PresupuestoRemuneracionExporta> lista = presupuestoRemuneracionServicio.PresupuestoRemuneracionExporta(listaProgramacionAnualVista.ProgramacionAnual.idProAnu);
                if (lista.Count > 0)
                    ExportarPresupuestoRemuneracion(lista);
            }
        }


        private void ExportarPresupuestoRemuneracion(List<PresupuestoRemuneracionExporta> lista)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel XLSX|*.xlsx";
                sfd.Title = "Guardar el siguiente archivo";

                string ruta = Path.GetTempPath() + "PresupuestoRemuneracion_" + Path.GetRandomFileName() + ".xlsx";

                ExportarProHelper.ExportarPresupuestoRemuneracion(ruta, lista);
                ExportarHelper.AbrirArchivoExcel(ruta);
            }
        }

        public List<ReporteProgramacionAnualExportaPres> TraerReporteProgramacionAnualExporta()
        {
            return programacionAnualServicio.TraerReporteProgramacionAnualExporta(listaProgramacionAnualVista.ProgramacionAnual.idProAnu, listaProgramacionAnualVista.idMoneda);
        }
    }
}
