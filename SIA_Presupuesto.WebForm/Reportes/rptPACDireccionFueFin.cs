using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace SIA_Presupuesto.WebForm.Reporte
{
    public partial class rptPACDireccionFueFin : DevExpress.XtraReports.UI.XtraReport
    {
        public rptPACDireccionFueFin()
        {
            InitializeComponent();
        }
        string vtotal = string.Empty;
        private void xrlTotal_BeforePrint(object sender, CancelEventArgs e)
        {
            xrlTotal.Text = "Total " + vtotal.ToString().Substring(1, vtotal.Length - 3) + " :";
        }

        private void xrlFueFin_BeforePrint(object sender, CancelEventArgs e)
        {
            vtotal = vtotal + " " + GetCurrentColumnValue("fuenteFinan").ToString() + ", ";
        }
    }
}
