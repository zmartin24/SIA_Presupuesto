using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.Adquisicion.Presentador;
using SIA_Presupuesto.WinForm.Adquisicion.Recursos;
using SIA_Presupuesto.WinForm.Adquisicion.Vista;
using SIA_Presupuesto.WinForm.General.Base;
using SIA_Presupuesto.WinForm.General.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SIA_Presupuesto.WinForm.Adquisicion.Dialogo
{
    public partial class frmCertificacionRequerimientoSubpresupuesto : frmDialogoBaseAyuda, ICertificacionRequerimientoSubpresupuestoVista
    {
        private CertificacionRequerimientoSubpresupuestoPresentador certificacionRequerimientoSubpresupuestoPresentador;

        public List<GrupoPresupuestoPoco> ListaGrupoPresupuesto
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueGruPre.Properties, "idGrupoPresupuesto", "descripcion", "Grupo Presupuesto", value);
            }
        }
        public List<ProgramacionAnual> ListaProgramacion
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(luePresupuesto.Properties, "idProAnu", "descripcion", "Presupuesto", value);
            }
        }
        public List<Subpresupuesto> ListaSubpresupuesto
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueSubPresupuesto.Properties, "idSubpresupuesto", "descripcion", "Presupuesto Mensual", value);
            }
        }
        
        public int idGruPre
        {
            set { lueGruPre.EditValue = value; }
            get { return Convert.ToInt32(lueGruPre.EditValue); }
        }
        public int idPresupuesto
        {
            set { luePresupuesto.EditValue = value; }
            get { return Convert.ToInt32(luePresupuesto.EditValue); }
        }
        public int idSubPresupuesto
        {
            set { lueSubPresupuesto.EditValue = value; }
            get { return Convert.ToInt32(lueSubPresupuesto.EditValue); }
        }

        private CertificacionMasterPres certificacionMasterPres;
        public CertificacionMasterPres CertificacionMasterPres
        {
            get { return certificacionMasterPres; }
            set
            {
                certificacionMasterPres = value;
                if (value != null)
                {
                    txtReq.Text = value.numeroReq;
                }
                else
                {
                    txtReq.Text = string.Empty;

                }
            }
        }
        private CertificacionRequerimiento certificacionRequerimiento;
        public CertificacionRequerimiento CertificacionRequerimiento
        {
            get { return certificacionRequerimiento; }
            set
            {
                certificacionRequerimiento = value;
                if (value != null)
                {
                    txtSigla.Text = value.sigla;
                }
                else
                {
                    txtSigla.Text = string.Empty;

                }
            }
        }

        public List<SubPresupuestoPoco> listaSubPresupuestoPoco
        {
            set
            {
                gcSubpresupuesto.DataSource = value;
                gvSubpresupuesto.RefreshData();
            }
        }
        
        private Dictionary<SubPresupuestoPoco, bool> listaSubPresupuestoPocoSeleccionados;
        public List<SubPresupuestoPoco> ListaSubPresupuestoPocoSeleccionados
        {
            get { return listaSubPresupuestoPocoSeleccionados.Keys.ToList(); }
        }
        public SubPresupuestoPoco subPresupuestoPoco
        {
            get
            {
                if (ColumnaActual == null || ColumnaActual.FocusedRowHandle < 0) return null;
                return ColumnaActual.GetRow(ColumnaActual.FocusedRowHandle) as SubPresupuestoPoco;
            }
        }

        //Para fila seleccionada
        protected override ColumnView ColumnaActual { get { return gcSubpresupuesto.MainView as ColumnView; } }
        
        public string vmensaje { set; get; }
        
        public frmCertificacionRequerimientoSubpresupuesto(CertificacionMasterPres certificacionMasterPres, CertificacionRequerimiento certificacionRequerimiento, Form padre, IDXMenuManager manager) : base(padre, manager)
        {
            InitializeComponent();
            this.certificacionRequerimientoSubpresupuestoPresentador = new CertificacionRequerimientoSubpresupuestoPresentador(certificacionMasterPres, certificacionRequerimiento, this);
            this.listaSubPresupuestoPocoSeleccionados = new Dictionary<SubPresupuestoPoco, bool>();
        }

        protected override void Inicializar()
        {
            certificacionRequerimientoSubpresupuestoPresentador.IniciarDatos();
            Text = "Registro Presupuesto Mensual - Certificación de Requerimiento";
            this.listaSubPresupuestoPocoSeleccionados.Clear();

        }
        protected override void LlenarGrid()
        {
            this.certificacionRequerimientoSubpresupuestoPresentador.llenarGrid();
        }
        protected override void AntesCerrar()
        {
            this.DialogResult = DialogResult.No;
        }
        private void lueGruPre_EditValueChanged(object sender, EventArgs e)
        {
            certificacionRequerimientoSubpresupuestoPresentador.LlenarComboPresupuesto(this.idGruPre);
        }
        private void luePresupuesto_EditValueChanged(object sender, EventArgs e)
        {
            LlenarComboSubPresupuesto();
        }
        private void sbAgregar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                if (this.certificacionRequerimientoSubpresupuestoPresentador.GuardarDatos())
                {
                    EmitirMensajeResultado(true, Mensajes.MensajeRegistroSatisfactorio);
                    LlenarComboSubPresupuesto();
                }
                else
                {
                    EmitirMensajeResultado(false, Mensajes.MensajeErrorRegistro);
                }
            }
            else
            {
                EmitirMensajeResultado(false, vmensaje);
            }
        }

        private void obgDetalle_QuitarRegistro(object sender, EventArgs e)
        {
            if (ListaSubPresupuestoPocoSeleccionados.Count > 0)
            {
                List<int> listaIds = ListaSubPresupuestoPocoSeleccionados.Select(x => x.idSubPresupuesto).ToList();
                
                if (this.certificacionRequerimientoSubpresupuestoPresentador.AnularAsignacionSubpresupuesto(listaIds))
                {
                    EmitirMensajeResultado(true, Mensajes.MensajeAnulacionSatisfactoria);
                    LlenarComboSubPresupuesto();
                    this.listaSubPresupuestoPocoSeleccionados.Clear();
                }
                else
                {
                    EmitirMensajeResultado(false, Mensajes.MensajeErrorRegistro);
                }
                
                gvSubpresupuesto.LayoutChanged();
            }
            else
                EmitirMensajeResultado(true, "Debe marcar selección de al menos un detalle, para eliminar");
        }
        private void obgDetalle_DesMarcarTodos(object sender, EventArgs e)
        {
            ActivarTodosCheck(false);
        }
        private void obgDetalle_MarcarTodos(object sender, EventArgs e)
        {
            ActivarTodosCheck(true);
        }
        private void gvSubpresupuesto_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            SubPresupuestoPoco trab = e.Row as SubPresupuestoPoco;
            if (e.IsSetData)
            {
                if (this.listaSubPresupuestoPocoSeleccionados.ContainsKey(trab))
                {
                    this.listaSubPresupuestoPocoSeleccionados.Remove(trab);
                }
                if (Convert.ToBoolean(e.Value))
                {
                    this.listaSubPresupuestoPocoSeleccionados.Add(trab, true);
                }
            }
            if (e.IsGetData)
            {
                e.Value = this.listaSubPresupuestoPocoSeleccionados.ContainsKey(trab);
            }
        }
        private void riceSeleccionar_CheckedChanged(object sender, EventArgs e)
        {
            var edit = (CheckEdit)sender;
            ActivarCheck((bool)edit.EditValue);
        }
        private void riceSeleccionar_CheckStateChanged(object sender, EventArgs e)
        {
            gvSubpresupuesto.CloseEditor();
        }

        /*Metodos*/
        protected internal void ActivarTodosCheck(bool activa)
        {
            int filas = gvSubpresupuesto.RowCount;
            for (int i = 0; i < filas; i++)
            {
                SubPresupuestoPoco prov = ColumnaActual.GetRow(i) as SubPresupuestoPoco;
                if (activa)
                {
                    if (!this.listaSubPresupuestoPocoSeleccionados.ContainsKey(prov))
                        this.listaSubPresupuestoPocoSeleccionados.Add(prov, true);
                }
                else
                {
                    this.listaSubPresupuestoPocoSeleccionados.Remove(prov);
                }
            }
            gvSubpresupuesto.LayoutChanged();
        }
        protected internal void ActivarCheck(bool activa)
        {
            if (activa)
            {
                if (!this.listaSubPresupuestoPocoSeleccionados.ContainsKey(this.subPresupuestoPoco))
                {
                    this.listaSubPresupuestoPocoSeleccionados.Add(this.subPresupuestoPoco, true);
                }
            }
            else
            {
                this.listaSubPresupuestoPocoSeleccionados.Remove(this.subPresupuestoPoco);
            }
            gvSubpresupuesto.LayoutChanged();
        }
        private bool validar()
        {
            bool res = true;
            vmensaje = string.Empty;
            int count = this.certificacionRequerimientoSubpresupuestoPresentador.listaCertificacionRequerimientoSubprespuesto().Count;

            if (count>0)
            {
                res = false;
                vmensaje = vmensaje + "\nSubpresupuesto ya esta asignado";
            }

            return res;
        }
        private void LlenarComboSubPresupuesto()
        {
            this.certificacionRequerimientoSubpresupuestoPresentador.LlenarComboSubPresupuesto(this.idPresupuesto);
            if (this.idSubPresupuesto == 0 || luePresupuesto.EditValue == null) sbAgregar.Enabled = false;
        }

    }
}
