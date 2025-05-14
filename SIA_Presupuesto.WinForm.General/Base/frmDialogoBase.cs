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
using SIA_Presupuesto.WinForm.General.Helper;
using SIA_Presupuesto.WinForm.General.Recursos;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid.Views.Base;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.Negocio.Entidades;
using System.Collections;
using SIA_Presupuesto.WinForm.General.ControlesDiversos;

namespace SIA_Presupuesto.WinForm.General.Base
{
    public partial class frmDialogoBase : frmDialogo
    {
        internal Form padre;
        private bool esFormuarioSegundario;
        protected bool esModificacion;
        private bool soloLectura = false;
        public IList listaSplash { get; set; }

        public int Anio
        {
            get
            {
                var formBase = padre as FormBase;
                if (formBase == null) return 0;
                return formBase.Anio;
            }
        }

        public int Mes
        {
            get
            {
                var formBase = padre as FormBase;
                if (formBase == null) return 0;
                return formBase.Mes;
            }
        }

        public int IdMoneda
        {
            get
            {
                var formBase = padre as FormBase;
                if (formBase == null) return 0;
                return formBase.IdMoneda;
            }
        }

        public int IdTipCam
        {
            get
            {
                var formBase = padre as FormBase;
                if (formBase == null) return 0;
                return formBase.IdTipCam;
            }
        }

        public UsuarioOperacion UsuarioOperacion
        {
            get
            {
                var formBase = padre as FormBase;
                if (formBase == null) return null;
                return formBase.Usuario;
            }
        }

        //public EjercicioContable EjercicioContable
        //{
        //    get
        //    {
        //        var formBase = padre as FormBase;
        //        if (formBase == null) return null;
        //        return formBase.EjercicioContable;
        //    }
        //}

        public frmDialogoBase()
        {
            InitializeComponent();
        }

        public frmDialogoBase(Form padre,bool esFormuarioSegundario)
            : this()
        {
         
            this.padre = padre;
            //this.lcCuerpo.MenuManager = adminMenu;
            this.esFormuarioSegundario = esFormuarioSegundario;
            this.Icon = ImagenHelper.AppIcon;

            if (this.esFormuarioSegundario)
            {
                this.sbAceptar.Text = "&Grabar";
                this.sbCancelar.Text = "&Cancelar";
                this.sbAceptar.Image = ImagenHelper.TraerImagen("Save", TamanioImagen.Pequenio16);
                this.sbCancelar.Image = ImagenHelper.TraerImagen("Close", TamanioImagen.Pequenio16);
            }
            else
            {
                this.sbAceptar.Image = ImagenHelper.TraerImagen("Mark", TamanioImagen.Pequenio16);
                this.sbCancelar.Image = ImagenHelper.TraerImagen("Close", TamanioImagen.Pequenio16);
            }
        }

        protected virtual void setEnabledAceptar(bool enabled)
        {
            this.sbAceptar.Enabled = enabled;
        }

        public DXValidationProvider proveedorValidacion { get { return dxProveedorValidador; } }

        protected virtual void ActualizarDatosSoloLectura()
        {
            if (SoloLectura)
            {
                //RecorrerSoloLectura(lcBase.Controls);
                RecorrerSoloLectura(lcCuerpo.Controls);
                ActualizarDatosSoloLecturaFrontal();
            }
        }

        public bool SoloLectura
        {
            get { return soloLectura; }
            set
            {
                soloLectura = value;
                ActualizarDatosSoloLectura();
            }
        }

        public void HabilitarBotonAceptar(bool enabled)
        {
            sbAceptar.Enabled = enabled;
        }

        private void RecorrerSoloLectura(Control.ControlCollection coleccion)
        {
            foreach (Control item in coleccion)
            {
                BaseEdit be = item as BaseEdit;
                if (be != null) be.Properties.ReadOnly = true;

                BaseButton bb = item as BaseButton;
                if (bb != null)
                {
                    if (bb.DialogResult != DialogResult.Cancel)
                        bb.Enabled = false;
                }

                OpcionesBarraGrid obg = item as OpcionesBarraGrid;
                if (obg != null)
                    obg.SoloLectura();

                OpcionesBarraGridMarcar obgm = item as OpcionesBarraGridMarcar;
                if (obgm != null)
                    obgm.SoloLectura();

                OpcionesBarraGridSeleccion obgs = item as OpcionesBarraGridSeleccion;
                if (obgs != null)
                    obgs.SoloLectura();

                if (item.Controls.Count > 0)
                    RecorrerSoloLectura(item.Controls);

                //Bar bi = item as Bar;
                //if (bi != null) bi.Enabled = false;
            }
        }

        #region Eventos

        protected override void OnLoad(EventArgs e)
        {
           
            base.OnLoad(e);
            InicializarValidacion();
            InicializarDatos();
            LlenarGrid();
            //if (padre != null)
            //    this.Location = new Point(padre.Left + (padre.Width - this.Width) / 2, padre.Top + (padre.Height - this.Height) / 2);

            foreach (Control item in lcCuerpo.Controls)
            {
                BaseEdit edit = item as BaseEdit;
                if (edit != null)
                {
                    edit.MenuManager = lcCuerpo.MenuManager;
                }
            }

            //Controlamos el solo lectura
            //this.SoloLectura = this.EjercicioContable != null ? EjercicioContable.cerrado && EjercicioContable.estadoConsulta : false;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            if (DialogResult == DialogResult.OK)
            {
                GuardarDatos();
                if (DialogResult == DialogResult.No)
                    e.Cancel = true;
            }
            else
            {
                CerrarFormulario();
            }
        }

        private void sbAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        #endregion

        #region Metodos Privados

        protected internal virtual void EmitirMensajeResultado(bool resultado, string mensaje)
        {
            if (resultado)
            {
                XtraMessageBox.Show(this.FindForm(), mensaje, Mensajes.Informacion, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                XtraMessageBox.Show(this.FindForm(), mensaje, Mensajes.Error, MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        protected internal virtual bool EmitirMensajePregunta(string mensaje)
        {
            bool resultado = false;
            resultado = XtraMessageBox.Show(this.FindForm(),
                mensaje, Mensajes.Pregunta, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes;
            return resultado;
        }

        protected virtual bool ValidarDatos() { return proveedorValidacion.Validate(); }

        protected virtual void CerrarFormulario() { }

        protected virtual void InicializarValidacion() { }

        protected virtual void InicializarDatos() { }

        protected virtual void GuardarDatos() { }

        protected virtual void ActualizarDatosSoloLecturaFrontal()
        {

        }

        #endregion

        #region Grid Detalle

        public virtual ColumnView ColumnaActual { get { return null; } }
        protected virtual ColumnView VistaActual { get { return ColumnaActual; } }

        protected virtual void LlenarGrid() { }

        #endregion

    }
}