using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using SIA_Presupuesto.Negocio.Entidades;

namespace SIA_Presupuesto.WebForm.Reporte
{
    public partial class rptRequerimientoBienServicioDireccion : DevExpress.XtraReports.UI.XtraReport
    {
        List<RequerimientoBienServicioDetallePres> lista;
        public rptRequerimientoBienServicioDireccion()
        {
            InitializeComponent();
        }
        public rptRequerimientoBienServicioDireccion(List<RequerimientoBienServicioDetallePres> lista)
        {
            InitializeComponent();
            this.lista = lista;
        }

        private void xrSubreportResumen_BeforePrint(object sender, CancelEventArgs e)
        {
            ((XRSubreport)sender).ReportSource.DataSource = this.lista != null ? this.lista.Count > 0 ? this.lista : null : null;
        }
    }
}
