using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitario.Reporte;

namespace SIA_Presupuesto.WinForm.General.Helper
{
    public class ExportarHelper
    {

        public static void AbrirArchivoExcel(string ruta)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "EXCEL.EXE";
            startInfo.Arguments = ruta;
            Process.Start(startInfo);
        }

        public static void ExportarExcelXLSX(string rutaArchivo, XtraReport reporte, object datos, bool esVertical)
        {
            reporte.PaperKind = System.Drawing.Printing.PaperKind.A4;
            reporte.Margins.Bottom = 0;
            reporte.PrintingSystem.ShowPrintStatusDialog = false;
            reporte.PrintingSystem.ShowMarginsWarning = false;
            reporte.Landscape = esVertical;
            reporte.DataSource = datos;

            using (var printTool = new DevExpress.XtraReports.UI.ReportPrintTool(reporte))
            {
                printTool.Report.CreateDocument(false); 
                printTool.PrintingSystem.ExportToXlsx(rutaArchivo);
            }
        }
        public static void ExportarExcelXLS(string rutaArchivo, XtraReport reporte, object datos, bool esVertical)
        {
            reporte.PaperKind = System.Drawing.Printing.PaperKind.A4;
            reporte.Margins.Bottom = 0;
            reporte.PrintingSystem.ShowPrintStatusDialog = false;
            reporte.PrintingSystem.ShowMarginsWarning = false;
            reporte.Landscape = esVertical;
            reporte.DataSource = datos;

            using (var printTool = new DevExpress.XtraReports.UI.ReportPrintTool(reporte))
            {
                printTool.Report.CreateDocument(false);
                printTool.PrintingSystem.ExportToXlsx(rutaArchivo);
            }
        }

        
        public static void ExportarExcelXLSX(string rutaArchivo, XtraReport reporte, object datos, bool esVertical, List<ParametrosReporte> p)
        {
            reporte.PaperKind = System.Drawing.Printing.PaperKind.A4;
            reporte.Margins.Bottom = 0;
            reporte.PrintingSystem.ShowPrintStatusDialog = false;
            reporte.PrintingSystem.ShowMarginsWarning = false;
            reporte.Landscape = esVertical;
            
            reporte.DataSource = datos;

            reporte.Parameters["fechaDesde"].Value = p.Where(x => x.nombre.Equals("fechaDesde")).First().valor;
            reporte.Parameters["fechaHasta"].Value = p.Where(x => x.nombre.Equals("fechaHasta")).First().valor;
            reporte.Parameters["numCtaDes"].Value = p.Where(x => x.nombre.Equals("numCtaDes")).First().valor;
            reporte.Parameters["numCtaHast"].Value = p.Where(x => x.nombre.Equals("numCtaHast")).First().valor;
            reporte.RequestParameters = false;//no vizualiza la ventana solicitando los parametros

            using (var printTool = new DevExpress.XtraReports.UI.ReportPrintTool(reporte))
            {
                printTool.Report.CreateDocument(false);
                printTool.PrintingSystem.ExportToXlsx(rutaArchivo);
            }
        }


        public static void ExportarPDF(string rutaArchivo, XtraReport reporte, object datos, bool esVertical)
        {
            reporte.PaperKind = System.Drawing.Printing.PaperKind.A4;
            reporte.Margins.Bottom = 0;
            reporte.PrintingSystem.ShowPrintStatusDialog = false;
            reporte.PrintingSystem.ShowMarginsWarning = false;
            reporte.Landscape = esVertical;
            reporte.DataSource = datos;

            using (var printTool = new DevExpress.XtraReports.UI.ReportPrintTool(reporte))
            {
                printTool.Report.CreateDocument(false);
                printTool.PrintingSystem.ExportToXlsx(rutaArchivo);
            }
        }

    }
}
