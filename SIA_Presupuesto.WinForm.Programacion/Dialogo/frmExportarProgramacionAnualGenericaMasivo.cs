using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using SIA_Presupuesto.WinForm.General.Base;
using SIA_Presupuesto.WinForm.Programacion.Vista;
using SIA_Presupuesto.WinForm.Programacion.Presentador;
using SIA_Presupuesto.WinForm.General.Helper;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.Programacion.Helper;
using Utilitario.Util;
using DevExpress.XtraGrid.Views.Grid;
using System.Globalization;
using System.IO;
using SIA_Presupuesto.WinForm.Programacion.Recursos;

namespace SIA_Presupuesto.WinForm.Programacion.Dialogo
{
    public partial class frmExportarProgramacionAnualGenericaMasivo : frmDialogoBase, IExportarProgramacionAnualGenericaMasivoVista
    {
        private ExportarProgramacionAnualGenericaMasivoVistaPresentador exportarProgramacionAnualGenericaMasivoVistaPresentador;

        public List<Anio> listaAnios
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueAnio.Properties, "indice", "nombre", "Años", value);
            }
        }
        public List<Moneda> listaMoneda
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueMoneda.Properties, "idMoneda", "descripcion", "Moneda", value);
            }
        }
        public List<ProgramacionAnualPres> listaProgramacionAnual
        {
            set
            {
                grcPresupuestoAnual.DataSource = value;
            }
        }

        public int anioReporte
        {
            set
            {
                lueAnio.EditValue = value;
            }
            get { return Convert.ToInt32(lueAnio.EditValue); }
        }
        public int idMoneda
        {
            set { lueMoneda.EditValue = value; }
            get { return lueMoneda.EditValue != null ? Convert.ToInt32(lueMoneda.EditValue) : 0; }
        }

        private Dictionary<ProgramacionAnualPres, bool> listaProgramacionAnualPresSeleccionados;
        public List<ProgramacionAnualPres> ListaProgramacionAnualPresSeleccionados
        {
            get { return listaProgramacionAnualPresSeleccionados.Keys.ToList(); }
        }

        public string idsProAnu
        {
            get;set;
        }

        List<ReporteProgramacionAnualGenericaGastosPres> listaExporta;
        List<ReporteProgramacionAnualExportaMasivoPres> listaProgramacionAnualExporta;

        public frmExportarProgramacionAnualGenericaMasivo()
        {
            InitializeComponent();
            this.exportarProgramacionAnualGenericaMasivoVistaPresentador = new ExportarProgramacionAnualGenericaMasivoVistaPresentador(this);
            Text = "Exportar Presupuesto Anual - Génerica de Gastos";

            this.listaExporta = new List<ReporteProgramacionAnualGenericaGastosPres>();
            this.listaProgramacionAnualExporta = new List<ReporteProgramacionAnualExportaMasivoPres>();
            this.listaProgramacionAnualPresSeleccionados = new Dictionary<ProgramacionAnualPres, bool>();
        }

        protected override void InicializarValidacion()
        {
            dxProveedorValidador.SetValidationRule(lueAnio, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(lueMoneda, ValidacionHelper.ReglaNoDebeSerVacio);
        }

        protected override void InicializarDatos()
        {
            iniciarControles();
            exportarProgramacionAnualGenericaMasivoVistaPresentador.Inicializar();
        }

        protected override bool ValidarDatos()
        {
            return proveedorValidacion.Validate();
        }
        private void lueAnio_EditValueChanged(object sender, EventArgs e)
        {
            if (lueAnio.EditValue != null)
            {
                iniciarControles();
                this.exportarProgramacionAnualGenericaMasivoVistaPresentador.CargarProgramacionAnual();
            }
        }
        private void grvPresupuestoAnual_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            GridView view = sender as GridView;
            ProgramacionAnualPres programacionAnualPres = view.GetFocusedRow() as ProgramacionAnualPres;
            int count = 0;

            if (programacionAnualPres != null)
            {
                switch (e.Action)
                {
                    case CollectionChangeAction.Add:
                        if (!this.ListaProgramacionAnualPresSeleccionados.Contains(programacionAnualPres))
                            this.listaProgramacionAnualPresSeleccionados.Add(programacionAnualPres, true);
                        break;
                    case CollectionChangeAction.Remove:
                        if (this.ListaProgramacionAnualPresSeleccionados.Contains(programacionAnualPres))
                            this.listaProgramacionAnualPresSeleccionados.Remove(programacionAnualPres);
                        break;
                    case CollectionChangeAction.Refresh:
                        if (this.ListaProgramacionAnualPresSeleccionados.Contains(programacionAnualPres))
                            view.SelectRow(e.ControllerRow);
                        break;
                }
            }
            count = this.ListaProgramacionAnualPresSeleccionados.Count > 0 ? this.ListaProgramacionAnualPresSeleccionados.Count : 0;
            if (count > 0)
            {
                string desResgistros = count == 1 ? "Registro seleccionado" : "Registros seleccionados";
                lciLblNum.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lcNumReg.Text = String.Format("{0} {1}", count, desResgistros);
            }
            else
            {
                lciLblNum.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                lcNumReg.Text = string.Empty;
            }
        }

        protected override void GuardarDatos()
        {
            idsProAnu = seleccionarIdProAnu();
            if (idsProAnu.Length == 0) EmitirMensajeResultado(true, Mensajes.RegistroVacio);

            //listaExporta = this.exportarProgramacionAnualGenericaMasivoVistaPresentador.TraerReporteProgramacionAnualGenericaGastos();
            listaProgramacionAnualExporta = this.exportarProgramacionAnualGenericaMasivoVistaPresentador.TraerReporteProgramacionAnualExportaMasivo();
            if (listaProgramacionAnualExporta.Count > 0)
            {
                //Exportar(listaExporta);
                ExportarProgramacionAnualDetalleResumen(listaProgramacionAnualExporta);
            }
            this.DialogResult = DialogResult.No;
        }

        private string seleccionarIdProAnu()
        {
            string codigos = string.Empty;
            List<string> values = new List<string>();

            foreach (ProgramacionAnualPres programacionAnualPres in ListaProgramacionAnualPresSeleccionados)
            {
                if (programacionAnualPres != null)
                {
                    values.Add(programacionAnualPres.idProAnu.ToString());
                }
            }
            codigos = String.Join("~", values);

            return codigos;
        }
        private void Exportar(List<ReporteProgramacionAnualGenericaGastosPres> lista)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                string format = "yyyy-MM-dd_hh.mm.ss.tt";
                sfd.Filter = "Excel XLSX|*.xlsx";
                sfd.Title = "Guardar el siguiente archivo";

                string ruta = Path.GetTempPath() + "PresupuestoAnualGenerica_" + DateTime.Now.ToString(format, CultureInfo.InvariantCulture).ToLower() + ".xlsx";

                ExportarProHelper.ExportarProgramacionAnualGenericaGastos(ruta, lista);
                ExportarHelper.AbrirArchivoExcel(ruta);
            }
        }
        private void ExportarProgramacionAnualDetalleResumen(List<ReporteProgramacionAnualExportaMasivoPres> lista)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                string format = "yyyy-MM-dd_hh.mm.ss.tt";
                sfd.Filter = "Excel XLSX|*.xlsx";
                sfd.Title = "Guardar el siguiente archivo";

                string ruta = Path.GetTempPath() + "PresupuestoAnualGenerica_" + DateTime.Now.ToString(format, CultureInfo.InvariantCulture).ToLower() + ".xlsx";

                ExportarProHelper.ExportarProgramacionAnualGenericaDetalleResumen(ruta, lista);
                ExportarHelper.AbrirArchivoExcel(ruta);
            }
        }
        private void iniciarControles()
        {
            lciLblNum.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lcNumReg.Text = string.Empty;
            this.listaProgramacionAnualPresSeleccionados.Clear();
        }

    }
}