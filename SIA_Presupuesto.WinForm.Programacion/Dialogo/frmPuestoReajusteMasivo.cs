using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SIA_Presupuesto.WinForm.General.Base;
using SIA_Presupuesto.WinForm.Programacion.Vista;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Helper;
using SIA_Presupuesto.WinForm.Programacion.Presentador;
using SIA_Presupuesto.WinForm.Programacion.Recursos;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;

namespace SIA_Presupuesto.WinForm.Programacion.Dialogo
{
    public partial class frmPuestoReajusteMasivo : frmDialogoBase, IPuestoReajusteMasivoVista
    {
        private PuestoReajusteMasivoPresentador puestoMasivoPresentador;

        private Dictionary<DatosPuestoCalculo, bool> ListaDetallesSeleccionados;

        public List<DatosPuestoCalculo> listaSeleccionada
        {
            get { return ListaDetallesSeleccionados.Keys.ToList(); }
        }

        public List<GrupoPresupuesto> listaGrupoPresupuesto
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueGruPre.Properties, "idGruPre", "descripcion", "Origenes", value);
            }
        }

        public List<ProgramacionAnual> listaPresupuesto
        {
            set
            {
                ////ElementoHelper.LlenarLookUpEdit(luePresupuesto.Properties, "idProAnu", "descripcion", "Programación Anual", value);
                ////luePresupuesto.ToolTip = "Selecciona un elemento de la lista.";
                gluePresupuesto.Properties.DataSource = value;
            }
        }

        public List<Direccion> listaDireccion
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueDireccion.Properties, "idDireccion", "desDireccion", "Dirección", value);
            }
        }

        public List<Subdireccion> listaSubdireccion
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueSubdireccion.Properties, "idSubdireccion", "desSubdireccion", "Subdirección", value);
            }
        }

        public int idGruPre
        {
            set { lueGruPre.EditValue = value; }
            get { return lueGruPre.EditValue != null ? Convert.ToInt32(lueGruPre.EditValue) : 0; }
        }

        public int idProAnu
        {
            set { gluePresupuesto.EditValue = value; }
            get { return gluePresupuesto.EditValue != null ? Convert.ToInt32(gluePresupuesto.EditValue) : 0; }
            //set { luePresupuesto.EditValue = value; }
            //get { return luePresupuesto.EditValue != null ?  Convert.ToInt32(luePresupuesto.EditValue) : 0; }
        }

        public int idDireccion
        {
            set { lueDireccion.EditValue = value; }
            get { return lueDireccion.EditValue != null ? Convert.ToInt32(lueDireccion.EditValue) : 0; }
        }

        public int idSubdireccion
        {
            set { lueSubdireccion.EditValue = value; }
            get { return lueSubdireccion.EditValue!= null ? Convert.ToInt32(lueSubdireccion.EditValue) : 0; }
        }

        public bool soloActivos
        {
            set { ceSoloActivos.Checked = value; }
            get { return ceSoloActivos.Checked; }
        }

        public List<DatosPuestoCalculo> listaPuestos
        {
            set
            {
                grcTrabajador.DataSource = value;
            }
        }

        public frmPuestoReajusteMasivo(ReajusteMensualProgramacion reajusteMensualProgramacion, Form padre) 
            : base(padre, false)
        {
            puestoMasivoPresentador = new PuestoReajusteMasivoPresentador(reajusteMensualProgramacion, this);
            ListaDetallesSeleccionados = new Dictionary<DatosPuestoCalculo, bool>();
            InitializeComponent();
            Text = "Registro Masivo de Puesto Laboral";
        }

        public override ColumnView ColumnaActual { get { return grcTrabajador.MainView as ColumnView; } }
        protected override ColumnView VistaActual { get { return grcTrabajador.MainView as GridView; } }
        public DatosPuestoCalculo DatoActual
        {
            get
            {
                if (ColumnaActual == null || ColumnaActual.FocusedRowHandle < 0) return null;
                return ColumnaActual.GetRow(ColumnaActual.FocusedRowHandle) as DatosPuestoCalculo;
            }
        }

        protected override void InicializarValidacion()
        {
            //dxProveedorValidador.SetValidationRule(txtDescripcion, ValidacionHelper.ReglaNoDebeSerVacio);
        }
        protected override void InicializarDatos()
        {
            obgmTrabajador.Inicializar(grvTrabajador, ListaDetallesSeleccionados);
            puestoMasivoPresentador.IniciarDatos();
        }

        protected override void LlenarGrid()
        {
            puestoMasivoPresentador.CargarDatosGenerales();
        }
        protected override void GuardarDatos()
        {
            if (puestoMasivoPresentador.GuardarDatos())
            {
                if (this.esModificacion)
                    EmitirMensajeResultado(true, Mensajes.MensajeModificacionSatisfactoria);
                else
                    EmitirMensajeResultado(true, Mensajes.MensajeRegistroSatisfactorio);

                this.DialogResult = DialogResult.OK;
            }
            else
                EmitirMensajeResultado(false, Mensajes.MensajeErrorRegistro);
        }

        protected internal void ActivarTodosCheck(bool activa)
        {
            int filas = grvTrabajador.RowCount;
            for (int i = 0; i < filas; i++)
            {
                DatosPuestoCalculo prov = ColumnaActual.GetRow(i) as DatosPuestoCalculo;
                if (activa)
                {
                    if (!ListaDetallesSeleccionados.ContainsKey(prov))
                        ListaDetallesSeleccionados.Add(prov, true);
                }
                else
                {
                    ListaDetallesSeleccionados.Remove(prov);
                }
            }

            grvTrabajador.LayoutChanged();
        }

        protected internal void ActivarCheck(bool activa)
        {
            if (activa)
            {
                if (!ListaDetallesSeleccionados.ContainsKey(DatoActual))
                {
                    ListaDetallesSeleccionados.Add(DatoActual, true);
                }
            }
            else
            {
                ListaDetallesSeleccionados.Remove(DatoActual);
            }
            grvTrabajador.LayoutChanged();
        }

        private void obgmTrabajador_AnteriorRegistro(object sender, EventArgs e)
        {
            ColumnaActual.FocusedRowHandle--;
        }

        private void obgmTrabajador_MarcarRegistro(object sender, EventArgs e)
        {
            ActivarCheck(true);
        }

        private void obgmTrabajador_DesmarcarRegistro(object sender, EventArgs e)
        {
            ActivarCheck(false);
        }

        private void obgmTrabajador_DesmarcarTodosRegistro(object sender, EventArgs e)
        {
            ActivarTodosCheck(false);
        }

        private void obgmTrabajador_MarcarTodosRegistro(object sender, EventArgs e)
        {
            ActivarTodosCheck(true);
        }

        private void obgmTrabajador_SiguienteRegistro(object sender, EventArgs e)
        {
            ColumnaActual.FocusedRowHandle++;
        }

        private void lueDireccion_EditValueChanged(object sender, EventArgs e)
        {
            if(lueDireccion.EditValue != null)
            {
                puestoMasivoPresentador.CargarDatosSubdireccion();
            }
        }

        private void lueGruPre_EditValueChanged(object sender, EventArgs e)
        {
            if (lueGruPre.EditValue != null)
            {
                puestoMasivoPresentador.CargarDatosPresupuesto();
            }
        }

        private void grvTrabajador_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            DatosPuestoCalculo trab = e.Row as DatosPuestoCalculo;
            if (e.IsSetData)
            {
                if (ListaDetallesSeleccionados.ContainsKey(trab))
                {
                    ListaDetallesSeleccionados.Remove(trab);
                }
                if (Convert.ToBoolean(e.Value))
                {
                    ListaDetallesSeleccionados.Add(trab, true);
                }
                obgmTrabajador.ActualizarContador();
            }
            if (e.IsGetData)
            {
                e.Value = ListaDetallesSeleccionados.ContainsKey(trab);
            }
        }

        private void riceSelect_CheckStateChanged(object sender, EventArgs e)
        {
            grvTrabajador.CloseEditor();
        }

        private void sbBuscar_Click(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        private void gluePresupuesto_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}