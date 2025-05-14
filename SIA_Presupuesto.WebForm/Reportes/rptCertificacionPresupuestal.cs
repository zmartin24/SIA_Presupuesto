using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace SIA_Presupuesto.WebForm.Reporte
{
    public partial class rptCertificacionPresupuestal : DevExpress.XtraReports.UI.XtraReport
    {
        public rptCertificacionPresupuestal()
        {
            InitializeComponent();
        }

        private void xrlTituloObservacion_BeforePrint(object sender, CancelEventArgs e)
        {
            e.Cancel = GetCurrentColumnValue("observacion").Equals("") ? true : false;
        }

        private void xrlObservacion_BeforePrint(object sender, CancelEventArgs e)
        {
            e.Cancel = GetCurrentColumnValue("observacion").Equals("") ? true : false;
        }
    }
}
