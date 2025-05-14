using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DevExpress.Spreadsheet;
using DevExpress.Spreadsheet.Export;




namespace SIA_Presupuesto.WebForm
{
    public partial class prueba : System.Web.UI.Page
    {
        string FilePath
        {
            get { return Session["FilePath"] == null ? String.Empty : Session["FilePath"].ToString(); }
            set { Session["FilePath"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                FilePath = String.Empty;
        }
        protected void Upload_FileUploadComplete(object sender, DevExpress.Web.FileUploadCompleteEventArgs e)
        {
            FilePath = Page.MapPath("~/XlsTables/") + e.UploadedFile.FileName;
            e.UploadedFile.SaveAs(FilePath);
        }
        private DataTable GetTableFromExcel()
        {
            Workbook book = new Workbook();
            book.InvalidFormatException += book_InvalidFormatException;
            book.LoadDocument(FilePath);
            Worksheet sheet = book.Worksheets.ActiveWorksheet;
            CellRange range = sheet.GetUsedRange();
            DataTable table = sheet.CreateDataTable(range, false);
            DataTableExporter exporter = sheet.CreateDataTableExporter(range, table, false);
            exporter.CellValueConversionError += exporter_CellValueConversionError;
            exporter.Export();
            return table;
        }

        void exporter_CellValueConversionError(object sender, CellValueConversionErrorEventArgs e)
        {
            e.Action = DataTableExporterAction.Continue;
            e.DataTableValue = null;
        }
        void book_InvalidFormatException(object sender, SpreadsheetInvalidFormatExceptionEventArgs e)
        {

        }

        protected void Grid_Init(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(FilePath))
            {
                Grid.DataSource = GetTableFromExcel();
                Grid.DataBind();
                //BootstrapGridView1.DataSource = GetTableFromExcel();
                //BootstrapGridView1.DataBind();

            }
        }
    }
}