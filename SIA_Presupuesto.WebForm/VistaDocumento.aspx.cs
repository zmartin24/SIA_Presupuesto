using SIA_Presupuesto.WebForm.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIA_Presupuesto.WebForm
{
    public partial class VistaDocumento : System.Web.UI.Page
    {
        const string LoadReportArgsKey = "ReportArgs";
        protected void Page_Load(object sender, EventArgs e)
        {
            var report = ReporteHelper.CrearReporte(Request.QueryString[LoadReportArgsKey]);
            if (report != null)
                DocumentViewerControl.Report = report;
        }
    }
}