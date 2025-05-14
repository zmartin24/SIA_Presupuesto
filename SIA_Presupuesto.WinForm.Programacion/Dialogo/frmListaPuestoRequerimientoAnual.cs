using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using SIA_Presupuesto.WinForm.General.Base;
using SIA_Presupuesto.WinForm.Programacion.Vista;
using SIA_Presupuesto.WinForm.Programacion.Presentador;
using SIA_Presupuesto.Negocio.Entidades;
using DevExpress.XtraGrid.Views.Grid;
using SIA_Presupuesto.WinForm.Programacion.Recursos;
using DevExpress.XtraGrid.Views.Base;

namespace SIA_Presupuesto.WinForm.Programacion.Dialogo
{
    public partial class frmListaPuestoRequerimientoAnual : frmDialogoBase, IListaPuestoRequerimientoAnualVista
    {
        private ListaPuestoRequerimientoAnualPresentador listaPuestoRequerimientoAnualPresentador;

        public ProgramacionAnual programacionAnual
        {
            get;
        }
        public List<PuestoRequerimientoAnualPres> listaPuestoRequerimientoAnual
        {
            set
            {
                grcPuestoRequerimientoAnual.DataSource = value;
            }
        }

        private Dictionary<PuestoRequerimientoAnualPres, bool> listaPuestoRequerimientoAnualPresSeleccionados;
        public List<PuestoRequerimientoAnualPres> ListaPuestoRequerimientoAnualPresSeleccionados
        {
            get { return listaPuestoRequerimientoAnualPresSeleccionados.Keys.ToList(); }
        }

        public string idsPueReq
        {
            get;set;
        }
        public PuestoRequerimientoAnualPres puestoRequerimientoAnualPresActual
        {
            get
            {
                if (ColumnaActual == null || ColumnaActual.FocusedRowHandle < 0) return null;
                return ColumnaActual.GetRow(ColumnaActual.FocusedRowHandle) as PuestoRequerimientoAnualPres;
            }
        }

        List<ReporteProgramacionAnualGenericaGastosPres> listaExporta;
        List<ReporteProgramacionAnualExportaMasivoPres> listaProgramacionAnualExporta;

        public frmListaPuestoRequerimientoAnual(ProgramacionAnual programacionAnual, Form padre) : base(padre, true)
        {
            InitializeComponent();
            this.listaPuestoRequerimientoAnualPresentador = new ListaPuestoRequerimientoAnualPresentador(this);
            Text = "Lista Puesto de Requerimiento de RRHH";
            this.programacionAnual = programacionAnual;
            this.listaExporta = new List<ReporteProgramacionAnualGenericaGastosPres>();
            this.listaProgramacionAnualExporta = new List<ReporteProgramacionAnualExportaMasivoPres>();
            this.listaPuestoRequerimientoAnualPresSeleccionados = new Dictionary<PuestoRequerimientoAnualPres, bool>();
        }
        public override ColumnView ColumnaActual { get { return grcPuestoRequerimientoAnual.MainView as ColumnView; } }
        protected override ColumnView VistaActual { get { return grcPuestoRequerimientoAnual.MainView as GridView; } }
        protected override void InicializarValidacion()
        {
        }

        protected override void InicializarDatos()
        {
            iniciarControles();
            listaPuestoRequerimientoAnualPresentador.Inicializar();
        }

        protected override bool ValidarDatos()
        {
            return proveedorValidacion.Validate();
        }
        
        private void grvPresupuestoAnual_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            GridView view = sender as GridView;
            PuestoRequerimientoAnualPres puestoRequerimientoAnualPres = view.GetFocusedRow() as PuestoRequerimientoAnualPres;
            int count = 0;

            switch (e.Action)
            {
                case CollectionChangeAction.Add:
                    if (puestoRequerimientoAnualPres != null && !this.ListaPuestoRequerimientoAnualPresSeleccionados.Contains(puestoRequerimientoAnualPres))
                        this.listaPuestoRequerimientoAnualPresSeleccionados.Add(puestoRequerimientoAnualPres, true);
                    break;
                case CollectionChangeAction.Remove:
                    if (puestoRequerimientoAnualPres != null && this.ListaPuestoRequerimientoAnualPresSeleccionados.Contains(puestoRequerimientoAnualPres))
                        this.listaPuestoRequerimientoAnualPresSeleccionados.Remove(puestoRequerimientoAnualPres);
                    break;
                case CollectionChangeAction.Refresh:
                        
                    for (int i = 0; i < view.DataRowCount; i++)
                    {
                        PuestoRequerimientoAnualPres puestoRequerimientoPres = view.GetRow(i) as PuestoRequerimientoAnualPres;
                        if (puestoRequerimientoPres != null)
                        {
                            switch (puestoRequerimientoPres.esSeleccionado)
                            {
                                case true:
                                    if (!this.ListaPuestoRequerimientoAnualPresSeleccionados.Contains(puestoRequerimientoPres))
                                    {
                                        this.listaPuestoRequerimientoAnualPresSeleccionados.Add(puestoRequerimientoPres, true);
                                        view.SetRowCellValue(i, "esSeleccionado", true);
                                    }
                                    break;
                                case false:
                                    if (this.ListaPuestoRequerimientoAnualPresSeleccionados.Contains(puestoRequerimientoPres))
                                        this.listaPuestoRequerimientoAnualPresSeleccionados.Remove(puestoRequerimientoPres);
                                    break;
                            }
                        }
                    }
                    break;
            }
            count = this.ListaPuestoRequerimientoAnualPresSeleccionados.Count > 0 ? this.ListaPuestoRequerimientoAnualPresSeleccionados.Count : 0;
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
            idsPueReq = seleccionarIdProAnu();
            int n = idsPueReq.Length;
            if (idsPueReq.Length == 0)
            {
                EmitirMensajeResultado(true, Mensajes.RegistroVacio);
                this.DialogResult = DialogResult.No;
            }
            else
            {
                if (this.listaPuestoRequerimientoAnualPresentador.GuardarPuestoRequerimientoEnProgramacionAnual(idsPueReq))
                {
                    EmitirMensajeResultado(true, Mensajes.MensajeRegistroSatisfactorio);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    EmitirMensajeResultado(false, Mensajes.MensajeErrorRegistro);
                    this.DialogResult = DialogResult.No;
                }
            }
        }

        private string seleccionarIdProAnu()
        {
            string codigos = string.Empty;
            List<string> values = new List<string>();

            foreach (PuestoRequerimientoAnualPres puestoRequerimientoAnualPres in ListaPuestoRequerimientoAnualPresSeleccionados)
            {
                if (puestoRequerimientoAnualPres != null)
                {
                    values.Add(puestoRequerimientoAnualPres.idPueReq.ToString());
                }
            }
            codigos = String.Join("~", values);

            return codigos;
        }
        private void iniciarControles()
        {
            lciLblNum.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lcNumReg.Text = string.Empty;
            this.listaPuestoRequerimientoAnualPresSeleccionados.Clear();
        }

        
    }
}