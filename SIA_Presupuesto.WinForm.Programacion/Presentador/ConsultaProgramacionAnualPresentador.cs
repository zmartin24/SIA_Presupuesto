using DevExpress.XtraReports.UI;
using SIA_Presupuesto.IoC.Contenedor;
using SIA_Presupuesto.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Helper;
using SIA_Presupuesto.WinForm.Programacion.Helper;
using SIA_Presupuesto.WinForm.Programacion.Vista;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilitario.Reporte;

namespace SIA_Presupuesto.WinForm.Programacion.Presentador
{
    public class ConsultaProgramacionAnualPresentador
    {
        private readonly IConsultaProgramacionAnualVista listaProgramacionAnualVista;
        private IProgramacionAnualServicio programacionAnualServicio;

        public ConsultaProgramacionAnualPresentador(IConsultaProgramacionAnualVista listaProgramacionAnualVista)
        {
            IContenedor _Contenedor = new cContenedor();
            this.programacionAnualServicio = _Contenedor.Resolver(typeof(IProgramacionAnualServicio)) as IProgramacionAnualServicio;

            this.listaProgramacionAnualVista = listaProgramacionAnualVista;
        }

        public void Iniciar()
        {

        }

        public void ObtenerDatosListado()
        {
            listaProgramacionAnualVista.listaDatosPrincipales = programacionAnualServicio.TraerListaProgramacionAnualAprobados(0);
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

        public void ExportarProgramacionAnual()
        {
            List<ProgramacionAnualAreaExporta> lista = programacionAnualServicio.TraerListaProgramacionAnualAreaExporta(listaProgramacionAnualVista.ProgramacionAnual.idProAnu);
            ExportarProgramacionAnual(lista);
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
    }
}
