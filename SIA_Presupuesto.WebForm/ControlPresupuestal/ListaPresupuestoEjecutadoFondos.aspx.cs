using DevExpress.CodeParser;
using DevExpress.Export;
using DevExpress.Utils;
using DevExpress.Web;
using DevExpress.Web.ASPxPivotGrid;
using DevExpress.Web.Bootstrap;
using DevExpress.XtraPrinting;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WebForm.Helper;
using SIA_Presupuesto.WebForm.Presentador;
using SIA_Presupuesto.WebForm.Vista;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitario.Util;

namespace SIA_Presupuesto.WebForm.ControlPresupuestal
{
    public partial class ListaPresupuestoEjecutadoFondos : System.Web.UI.Page, IListaPresupuestoEjecutadoFondosVista
    {
        private ListaPresupuestoEjecutadoFondosPresentador listaPresupuestoEjecutadoFondosPresentador;
        
        public string nomUsuario { get { return Session["nomUsuario"]!=null ? Session["nomUsuario"].ToString() : string.Empty; } }

        public int idUsuario { get { return Session["idUsuario"] != null ? Convert.ToInt32(Session["idUsuario"].ToString()) : 0; } }


        public List<ReportePresupuestoEjecutadoFondosPres> listaDatosPrincipales
        {
            set
            {
                this.grvPivot.DataSource = value;
            }
        }
        public List<Anio> listaAnios
        {
            set
            {
                cbAnio.DataSource = value;
                cbAnio.DataBind();
            }
        }
        public List<Mes> listaMeses
        {
            set
            {
                cbMes.DataSource = value;
                cbMes.DataBind();
            }
        }
        public List<Moneda> listaMonedas
        {
            set
            {
                cbMoneda.DataSource = value;
                cbMoneda.DataBind();
            }
        }

        
        public int anioPresentacion
        {
            set { cbAnio.Value = value.ToString(); }
            get { return cbAnio.Value != null ? Convert.ToInt32(cbAnio.Value.ToString()) : 0; }
        }
        public int idMes
        {
            set { cbMes.Value = value.ToString(); }
            get { return cbMes.Value != null ? Convert.ToInt32(cbMes.Value.ToString()) : 0; }
        }
        public int idMoneda
        {
            set { cbMoneda.Value = value.ToString(); }
            get { return cbMoneda.Value != null ? Convert.ToInt32(cbMoneda.Value.ToString()) : 63; }
        }

        public int idSubPresupuesto
        {
            //set { hdfValores["idSubPresupuesto"] = value.ToString(); }
            //get { return Convert.ToInt32(hdfValores["idSubPresupuesto"] == null ? 0 : hdfValores["idSubPresupuesto"]); }

            set { Session["idSubPresupuesto"] = value.ToString(); }
            get { return Convert.ToInt32(Session["idSubPresupuesto"]); }
        }

        public ASPxGridView vGrvPresupuestoDivisionaria;
        public ASPxGridView vGrvPresupuestoCuenta;

        List<ReportePresupuestoEjecutadoFondosPres> listaGridPivot;

        protected void Page_Init(object sender, EventArgs e)
        {
            listaPresupuestoEjecutadoFondosPresentador = new ListaPresupuestoEjecutadoFondosPresentador(this);
            listaPresupuestoEjecutadoFondosPresentador.CargarServicios();
            listaGridPivot = new List<ReportePresupuestoEjecutadoFondosPres>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["nomUsuario"] == null)
            {
                Response.Redirect("~/Error.htm");
            }

            if (!IsPostBack)
            {
                listaPresupuestoEjecutadoFondosPresentador.Iniciar();
                Session["listaPivot"] = null;
                Session["idSubPresupuesto"] = "0";
                Session["desPresupuesto"] = "";
                Session["desSubPresupuesto"] = "";
            }

            Actualizar();

            
        }

        public void Actualizar()
        {
            if (Session["listaPivot"] != null)
                listaGridPivot = (List<ReportePresupuestoEjecutadoFondosPres>)Session["listaPivot"];
            else
            {
                listaGridPivot = listaPresupuestoEjecutadoFondosPresentador.TraerListaReportePresupuestoEjecutadoFondosPres();
                Session["listaPivot"] = listaGridPivot;
            }

            listaDatosPrincipales = listaGridPivot;
            grvPivot.ExpandAll();
        }

        

        protected void cpPrincipal_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            var args = Util.DeserializeCallbackArgs(e.Parameter);
            if (args.Count == 0)
                return;

            cpPrincipal.JSProperties["cpGrid"] = "grvPivot";
        }

        
        protected void btnExportarExcel_Click(object sender, EventArgs e)
        {
            listaGridPivot = (List<ReportePresupuestoEjecutadoFondosPres>)Session["listaPivot"] == null ? new List<ReportePresupuestoEjecutadoFondosPres>() : (List<ReportePresupuestoEjecutadoFondosPres>)Session["listaPivot"];
            if (listaGridPivot.Count > 0)
            {
                string format = "yyyy-MM-dd_hh.mm.ss.tt";
                //string ruta = listaPresupuestoEjecutadoFondosPresentador.ExportarEvaluacion(listaGridPivot, (string)Session["desPresupuesto"], (string)Session["desSubPresupuesto"]);
                //if (!string.IsNullOrEmpty(ruta))
                //{
                //    string nombreArchivo = "EvaluacionPorCuenta_" + DateTime.Now.ToString(format).ToLower() + ".xlsx";
                //    FileInfo file = new FileInfo(ruta);
                //    if (file.Exists)
                //    {
                //        Response.Clear();
                //        Response.ClearHeaders();
                //        Response.ClearContent();
                //        Response.AddHeader("content-disposition", "attachment; filename=" + nombreArchivo);
                //        Response.AddHeader("Content-Type", "application/Excel");
                //        Response.ContentType = "application/vnd.xls";
                //        Response.AddHeader("Content-Length", file.Length.ToString());
                //        Response.WriteFile(file.FullName);
                //        Response.End();
                //    }
                //    else
                //    {
                //        Response.Write("Este archivo no existe.");
                //    }
                //}
            }
            else
            {
                Response.Write("Lista vacía...");
            }
        }

        protected void buttonSaveAs_Click(object sender, EventArgs e)
        {
            //foreach (PivotGridField field in grvPivot.Fields)
            //{
            //    if (field.ValueFormat != null && !string.IsNullOrEmpty(field.ValueFormat.FormatString))
            //        field.UseNativeFormat = checkCustomFormattedValuesAsText.Checked ? DefaultBoolean.False : DefaultBoolean.True;
            //}

            ////ASPxPivotGridExporter1.OptionsPrint.PrintColumnAreaOnEveryPage = checkPrintColumnAreaOnEveryPage.Checked;
            ////ASPxPivotGridExporter1.OptionsPrint.PrintRowAreaOnEveryPage = checkPrintRowAreaOnEveryPage.Checked;
            //ASPxPivotGridExporter1.OptionsPrint.PrintColumnFieldValues = checkPrintColumnAreaOnEveryPage.Checked;
            //ASPxPivotGridExporter1.OptionsPrint.PrintRowFieldValues = checkPrintRowAreaOnEveryPage.Checked;
            //ASPxPivotGridExporter1.OptionsPrint.MergeColumnFieldValues = checkMergeColumnFieldValues.Checked;
            //ASPxPivotGridExporter1.OptionsPrint.MergeRowFieldValues = checkMergeRowFieldValues.Checked;

            //ASPxPivotGridExporter1.OptionsPrint.PrintFilterHeaders = checkPrintFilterFieldHeaders.Checked ? DefaultBoolean.True : DefaultBoolean.False;
            //ASPxPivotGridExporter1.OptionsPrint.PrintColumnHeaders = checkPrintColumnFieldHeaders.Checked ? DefaultBoolean.True : DefaultBoolean.False;
            //ASPxPivotGridExporter1.OptionsPrint.PrintRowHeaders = checkPrintRowFieldHeaders.Checked ? DefaultBoolean.True : DefaultBoolean.False;
            //ASPxPivotGridExporter1.OptionsPrint.PrintDataHeaders = checkPrintDataFieldHeaders.Checked ? DefaultBoolean.True : DefaultBoolean.False;

            //const string fileName = "PivotGrid";
            //XlsxExportOptionsEx options;
            //switch (listExportFormat.SelectedIndex)
            //{
            //    case 0:
            //        ASPxPivotGridExporter1.ExportPdfToResponse(fileName);
            //        break;
            //    case 1:
            //        options = new XlsxExportOptionsEx() { ExportType = ExportType.WYSIWYG };
            //        ASPxPivotGridExporter1.ExportXlsxToResponse(fileName, options);
            //        break;
            //    case 2:
            //        ASPxPivotGridExporter1.ExportMhtToResponse(fileName, "utf-8", "ASPxPivotGrid Printing Sample", true);
            //        break;
            //    case 3:
            //        ASPxPivotGridExporter1.ExportRtfToResponse(fileName);
            //        break;
            //    case 4:
            //        ASPxPivotGridExporter1.ExportTextToResponse(fileName);
            //        break;
            //    case 5:
            //        ASPxPivotGridExporter1.ExportHtmlToResponse(fileName, "utf-8", "ASPxPivotGrid Printing Sample", true);
            //        break;
            //    case 6:
            //        options = new XlsxExportOptionsEx()
            //        {
            //            ExportType = ExportType.DataAware,
            //            AllowGrouping = allowGroupingCheckBox.Checked ? DefaultBoolean.True : DefaultBoolean.False,
            //            TextExportMode = exportCellValuesAsText.Checked ? TextExportMode.Text : TextExportMode.Value,
            //            AllowFixedColumns = allowFixedColumns.Checked ? DefaultBoolean.True : DefaultBoolean.False,
            //            AllowFixedColumnHeaderPanel = allowFixedColumns.Checked ? DefaultBoolean.True : DefaultBoolean.False,
            //            RawDataMode = exportRawData.Checked
            //        };
            //        ASPxPivotGridExporter1.ExportXlsxToResponse(fileName, options);
            //        break;
            //}

        }
        protected void DataAwareExportButton_Click(object sender, EventArgs e)
        {
            // Exports using the Data-Aware type. 
            ASPxPivotGridExporter1.ExportXlsxToResponse("Presupuesto_Ejecutado", new XlsxExportOptionsEx
            {
                AllowFixedColumns = DefaultBoolean.False,
                SheetName = "Presupuesto Ejecutado"
            },
            true);
        }
        
        protected void cbMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarGridPivot();
        }

        protected void cbAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarGridPivot();
        }

        protected void cbMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarGridPivot();
        }
        protected void llenarGridPivot()
        {
            Session["listaPivot"] = null;
            listaGridPivot = listaPresupuestoEjecutadoFondosPresentador.TraerListaReportePresupuestoEjecutadoFondosPres();
            Session["listaPivot"] = listaGridPivot;
            listaDatosPrincipales = listaGridPivot;
            grvPivot.DataBind();
        }
    }
}