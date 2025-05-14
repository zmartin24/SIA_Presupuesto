using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using SIA_Presupuesto.Negocio.Entidades;
using System.Collections.Generic;

namespace SIA_Presupuesto.WebForm.Reporte
{
    public partial class rptRequerimientoRRHHImportes : DevExpress.XtraReports.UI.XtraReport
    {
        List<ReporteRequerimientoRRHHDireccionImportePres> lista;
        public rptRequerimientoRRHHImportes(List<ReporteRequerimientoRRHHDireccionImportePres> lista)
        {
            InitializeComponent();
            this.lista = lista;
        }

        private void xrSubreportResumen_BeforePrint(object sender, CancelEventArgs e)
        {
            ((XRSubreport)sender).ReportSource.DataSource = this.lista.Count > 0 ? this.lista : null;
        }
    }
}
