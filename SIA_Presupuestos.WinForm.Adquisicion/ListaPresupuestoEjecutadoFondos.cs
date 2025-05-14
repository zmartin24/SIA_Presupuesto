using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SIA_Presupuesto.WinForm.General.Base;
using SIA_Presupuesto.WinForm.Adquisicion.Presentador;
using SIA_Presupuesto.WinForm.General.Helper;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.Adquisicion.Vista;
using Utilitario.Util;
using System.IO;

namespace SIA_Presupuesto.WinForm.Adquisicion
{
    public partial class ListaPresupuestoEjecutadoFondos : ControlBase, IListaPresupuestoEjecutadoFondosVista
    {
        private ListaPresupuestoEjecutadoFondosPresentador listaPresupuestoEjecutadoFondosPresentador;

        public List<ReportePresupuestoEjecutadoFondosPres> listaDatosPrincipales
        {
            set
            {
                pivotGridControl1.DataSource = value;
            }
        }
        public List<Anio> listaAnio
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueAnio.Properties, "indice", "nombre", "Año", value);
            }
        }
        
        public List<Moneda> listaMoneda
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueMoneda.Properties, "idMoneda", "descripcion", "Moneda", value);
            }
        }
        public List<Mes> listaMes
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueMes.Properties, "indice", "nombre", "Meses", value);
            }
        }

        public int idMoneda
        {
            set { lueMoneda.EditValue = value; }
            get { return lueMoneda.EditValue != null ? Convert.ToInt32(lueMoneda.EditValue) : 63; }
        }
        public int mes
        {
            set { lueMes.EditValue = value; }
            get { return lueMes.EditValue!= null ? (Int32)lueMes.EditValue : DateTime.Now.Month; }
        }
        public int vanio
        {
            get { return lueAnio.EditValue != null ? Convert.ToInt32(lueAnio.EditValue) : DateTime.Now.Year; }
            set { lueAnio.EditValue = value; }
        }

        public bool inicio = false;
        
        public ListaPresupuestoEjecutadoFondos()
        {
            InitializeComponent();
            this.listaPresupuestoEjecutadoFondosPresentador = new ListaPresupuestoEjecutadoFondosPresentador(this);
            Text = "Reporte de Ejecución de Presupuesto por Fondos";
        }
        
        protected override DevExpress.XtraPivotGrid.PivotGridControl PivotGridPrincipal { get { return pivotGridControl1; } }
        protected override bool ExportarDePivot { get { return true; } }
        protected override void InicializarDatos()
        {
            this.listaPresupuestoEjecutadoFondosPresentador.IniciarDatos();
        }
        private void ExportarPresupuestoEjecutado()
        {
            pivotGridControl1.OptionsPrint.PrintFilterHeaders = DevExpress.Utils.DefaultBoolean.False;
            pivotGridControl1.OptionsPrint.PrintColumnHeaders = DevExpress.Utils.DefaultBoolean.False;
            pivotGridControl1.OptionsPrint.PrintDataHeaders = DevExpress.Utils.DefaultBoolean.False;


            var pivotExportOptions = new DevExpress.XtraPivotGrid.PivotXlsxExportOptions();
            pivotExportOptions.ExportType = DevExpress.Export.ExportType.WYSIWYG;
            pivotExportOptions.AllowGrouping = DevExpress.Utils.DefaultBoolean.False;

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                string format = "yyyy-MM-dd_hh.mm.ss.tt";
                sfd.Filter = "Excel XLSX|*.xlsx";
                sfd.Title = "Guardar el siguiente archivo";

                string ruta = Path.GetTempPath() + "PresupuestoEjecutado_" + DateTime.Now.ToString(format).ToLower() + ".xlsx";

                pivotGridControl1.ExportToXlsx(ruta, pivotExportOptions);
                ExportarHelper.AbrirArchivoExcel(ruta);
            }
        }
        protected override void LlenarGrid()
        {
            CargarDatosConSplash();
        }
        protected override void EjecutarCargarConSplash()
        {
            if (lueAnio.EditValue != null && lueMoneda.EditValue != null && lueMes.EditValue != null)
            {
                this.listaPresupuestoEjecutadoFondosPresentador.llenarGridPivot();
                inicio = true;
            }
        }

        private void lueAnio_EditValueChanged(object sender, EventArgs e)
        {
            //if (lueAnio.EditValue != null && lueMoneda.EditValue != null && lueMes.EditValue != null && inicio)
            //    LlenarGrid();
        }
        private void lueMoneda_EditValueChanged(object sender, EventArgs e)
        {
            //if (lueAnio.EditValue != null && lueMoneda.EditValue != null && lueMes.EditValue != null && inicio)
            //    LlenarGrid();
        }
        private void lueMes_EditValueChanged(object sender, EventArgs e)
        {
            //if (lueAnio.EditValue != null && lueMoneda.EditValue != null && lueMes.EditValue != null && inicio)
            //    LlenarGrid();
        }

        private void sbConsulta_Click(object sender, EventArgs e)
        {
            if (lueAnio.EditValue != null && lueMoneda.EditValue != null && lueMes.EditValue != null && inicio)
                LlenarGrid();
        }
        private void sbConsultaDetalles_Click(object sender, EventArgs e)
        {
            List<object> lista = this.listaPresupuestoEjecutadoFondosPresentador.TraerReporteCertificacionOrdenProvision();
            if (lista.Count > 0) this.listaPresupuestoEjecutadoFondosPresentador.Imprimir(lista);
            else
                EmitirMensajeResultado(true, "Consulta no generó datos");
        }
    }
}
