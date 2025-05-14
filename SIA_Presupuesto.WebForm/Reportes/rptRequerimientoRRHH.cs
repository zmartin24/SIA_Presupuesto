using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace SIA_Presupuesto.WebForm.Reporte
{
    public partial class rptRequerimientoRRHH : DevExpress.XtraReports.UI.XtraReport
    {
        private bool ocultaDirPer = true;
        private bool ocultaDirCon = true;
        private bool ocultaDirDes = true;
        private bool ocultaEmpPer = true;
        private bool ocultaEmpCon = true;
        private bool ocultaObrPer = true;
        private bool ocultaObrCon = true;
        public rptRequerimientoRRHH()
        {
            InitializeComponent();
            //this.ocultaDirPer = true;
        }

        private void xrTCGradoPro_BeforePrint(object sender, CancelEventArgs e)
        {
            xrTCGradoPro.Text = Convert.ToInt32(GetCurrentColumnValue("remPropuesta")) == 0 ? string.Empty : GetCurrentColumnValue("remPropuesta").ToString();
        }

        private void xrTCRemPro_BeforePrint(object sender, CancelEventArgs e)
        {
            xrTCRemPro.Text = Convert.ToInt32(GetCurrentColumnValue("remPropuesta")) == 0 ? string.Empty : GetCurrentColumnValue("remPropuesta").ToString();
        }

        private void xrtrDirPer_BeforePrint(object sender, CancelEventArgs e)
        {
            e.Cancel = ocultaDirPer;
        }

        private void xrtrDirCon_BeforePrint(object sender, CancelEventArgs e)
        {
            e.Cancel = ocultaDirCon;
        }

        private void xrtrDirDes_BeforePrint(object sender, CancelEventArgs e)
        {
            e.Cancel = ocultaDirDes;
        }

        private void xrtrEmpPer_BeforePrint(object sender, CancelEventArgs e)
        {
            e.Cancel = ocultaEmpPer;
        }

        private void xrtrEmpCon_BeforePrint(object sender, CancelEventArgs e)
        {
            e.Cancel = ocultaEmpCon;
        }

        private void xrtrObrPer_BeforePrint(object sender, CancelEventArgs e)
        {
            e.Cancel = ocultaObrPer;
        }

        private void xrtrObrCon_BeforePrint(object sender, CancelEventArgs e)
        {
            e.Cancel = ocultaObrCon;
        }

        private void Detail_BeforePrint(object sender, CancelEventArgs e)
        {
            //switch (GetCurrentColumnValue("ordGruCatLab").ToString())
            //{
            //    case "12":
            //        ocultaDirPer = false; break;
            //    case "13":
            //        ocultaDirCon = false; break;
            //    case "11":
            //        ocultaDirDes = false; break;
            //    case "22":
            //        ocultaEmpPer = false; break;
            //    case "23":
            //        ocultaEmpCon = false; break;
            //    case "32":
            //        ocultaObrPer = false; break;
            //    case "33":
            //        ocultaObrCon = false; break;
            //}
        }
    }
}
