using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.Utils.Menu;
using DevExpress.XtraLayout.Utils;
using SIA_Presupuesto.WinForm.General.Helper;
using SIA_Presupuesto.WinForm.General.Recursos;

namespace SIA_Presupuesto.WinForm.General.Base
{
    public partial class frmDialogoBaseSecuencial : DevExpress.XtraEditors.XtraForm
    {
        internal Form padre;
        private int nroNiveles;
        protected int NroNiveles { set { nroNiveles = value < 2 ? 2 : value; } }
        private int nivelActual;
        protected int NivelActual { get { return nivelActual; } }

        private bool soloLectura = false;

        private bool esPorFinalizacion;
        private bool conImpresion;

        public frmDialogoBaseSecuencial()
        {
            InitializeComponent();
            nroNiveles = 2;
            nivelActual = 1;
        }

        public frmDialogoBaseSecuencial(bool esPorFinalizacion, bool conImpresion, Form padre, IDXMenuManager adminMenu)
            : this()
        {
            this.padre = padre;
            this.lcCuerpo.MenuManager = adminMenu;
            this.Icon = ImagenHelper.AppIcon;
            this.esPorFinalizacion = esPorFinalizacion;
            this.conImpresion = conImpresion;
        }

        public DXValidationProvider proveedorValidacion { get { return dxProveedorValidador; } }

        protected virtual void ActualizarDatosSoloLectura()
        {
            if (SoloLectura)
            {
                RecorrerSoloLectura(lcCuerpo.Controls);
                ActualizarDatosSoloLecturaFrontal();
                sbAnterior.Enabled = false;
                sbOperacion.Enabled = false;
                sbSiguiente.Enabled = false;
            }
        }

        private void CentrarFormulario()
        {
            this.Top = 0;
            this.Left = (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2;
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

        private void RecorrerSoloLectura(Control.ControlCollection coleccion)
        {
            foreach (Control item in coleccion)
            {
                BaseEdit be = item as BaseEdit;
                if (be != null) be.Properties.ReadOnly = true;

                BaseButton bb = item as BaseButton;
                if (bb != null) bb.Enabled = false;

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
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            CerrarFormulario();
            if (DialogResult == DialogResult.No)
                e.Cancel = true;
        }

        private void sbAnterior_Click(object sender, EventArgs e)
        {
            nivelActual--;
            Anterior();
            ActivacionBotonesPorNiveles();
        }

        private void sbSiguiente_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                nivelActual++;
                Siguiente();
                ActivacionBotonesPorNiveles();
            }
        }

        private void sbSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void CargarPosicion(int posicion)
        {
            if (nivelActual > nroNiveles) return;

            for (int i = 1; i <= posicion; i++)
            {
                this.nivelActual = i;
                Siguiente();
                ActivacionBotonesPorNiveles();
            }
        }

        #endregion

        #region Metodos Privados

        private void ActivacionBotonesPorNiveles()
        {
            if (nivelActual == 1)
            {
                sbAnterior.Enabled = false;
                sbSiguiente.Enabled = true;
                sbSiguiente.Text = "Siguiente>>";
                lciGuardar.Visibility = LayoutVisibility.Never;
                lciSiguiente.Visibility = LayoutVisibility.Always;
                lciImprimir.Visibility = LayoutVisibility.Never;
            }
            else if (nivelActual == nroNiveles)
            {

                sbAnterior.Enabled = true;//!esPorFinalizacion;
                sbSiguiente.Enabled = false;
                if (conImpresion) lciImprimir.Visibility = LayoutVisibility.Always;
                if (!esPorFinalizacion)
                {
                    lciGuardar.Visibility = LayoutVisibility.Always;
                    lciSiguiente.Visibility = LayoutVisibility.Never;
                }
            }
            else
            {
                if (esPorFinalizacion && nivelActual == nroNiveles - 1)
                    sbSiguiente.Text = "Finalizar>>";

                else sbSiguiente.Text = "Siguiente>>";
                sbAnterior.Enabled = true;
                sbSiguiente.Enabled = true;
                lciGuardar.Visibility = LayoutVisibility.Never;
                lciSiguiente.Visibility = LayoutVisibility.Always;
                lciImprimir.Visibility = LayoutVisibility.Never;
            }
        }

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

        protected virtual void Siguiente() { }

        protected virtual void Anterior() { }

        protected virtual void Imprimir() { }

        protected virtual void RealizarOperacion() { }

        protected virtual void ActualizarDatosSoloLecturaFrontal() {  }

        #endregion

        private void sbImprimir_Click(object sender, EventArgs e)
        {
            Imprimir();
        }

        private void sbOperacion_Click(object sender, EventArgs e)
        {
            RealizarOperacion();
        }
    }
}