using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace SIA_Presupuesto.WinForm.Adquisicion.Reporte
{
    public partial class rptPACDireccionFueFin : DevExpress.XtraReports.UI.XtraReport
    {
        public rptPACDireccionFueFin()
        {
            InitializeComponent();
        }
        string vtotal = string.Empty;
        ArrayList sortDireccion = new ArrayList() {
                                                "Dirección Ejecutiva", "Dirección de Operaciones", "Dirección de Administración","Dirección de Infraestructura",
                                                "Dirección CADA", "Dirección de Auditoría Interna", "Programa Interdicción"
        };
        ArrayList sortFueFin = new ArrayList() { "SAAL", "CORAH DE VIDA"};
        private void xrlTotal_BeforePrint(object sender, CancelEventArgs e)
        {
            int n = vtotal.Length;
            xrlTotal.Text = "Total " + vtotal.ToString().Substring(1, vtotal.Length - 3) + " :";
        }

        private void xrlFueFin_BeforePrint(object sender, CancelEventArgs e)
        {
            vtotal = vtotal + " " + GetCurrentColumnValue("fuenteFinan").ToString() + ", ";
        }

        private void GroupHeader1_BeforePrint(object sender, CancelEventArgs e)
        {
            GroupHeader2.PageBreak = PageBreak.None;
        }

        private void GroupHeader4_BeforePrint(object sender, CancelEventArgs e)
        {
            GroupHeader2.PageBreak = PageBreak.BeforeBandExceptFirstEntry;
        }

        private void rptPACDireccionFueFin_BeforePrint(object sender, CancelEventArgs e)
        {
            xrPageInfo2.StartPageNumber = Convert.ToInt32(Parameters["vNumPag"].Value);
        }

        private void cfDireccion_GetValue(object sender, GetValueEventArgs e)
        {
            object category = e.GetColumnValue("desDireccion");
            e.Value = sortDireccion.IndexOf(category);
        }

        private void cfFueFin_GetValue(object sender, GetValueEventArgs e)
        {
            object category = e.GetColumnValue("fuenteFinan");
            e.Value = sortFueFin.IndexOf(category);
        }
    }
}
