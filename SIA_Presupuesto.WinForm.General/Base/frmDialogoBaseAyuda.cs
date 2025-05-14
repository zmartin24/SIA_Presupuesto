using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using SIA_Presupuesto.WinForm.General.Helper;
using SIA_Presupuesto.WinForm.General.Recursos;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.Negocio.Entidades;
using System.Collections;
using SIA_Presupuesto.WinForm.General.ControlesDiversos;

namespace SIA_Presupuesto.WinForm.General.Base
{
    public partial class frmDialogoBaseAyuda : frmDialogo
    {
        internal Form padre;
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

        public frmDialogoBaseAyuda()
        {
            InitializeComponent();
        }

        public frmDialogoBaseAyuda(Form padre, IDXMenuManager adminMenu):this()
        {
            this.padre = padre;
            this.lcCuerpo.MenuManager = adminMenu;
            this.sbSalir.Image = ImagenHelper.TraerImagen("Close", TamanioImagen.Pequenio16);
            this.Icon = ImagenHelper.AppIcon;
          
        }

        protected virtual void ActualizarDatosSoloLectura()
        {
            if (SoloLectura)
            {
                //RecorrerSoloLectura(lcBase.Controls);
                RecorrerSoloLectura(lcCuerpo.Controls);
                ActualizarDatosSoloLecturaFrontal();
            }
        }

        protected virtual void ActualizarDatosSoloLecturaFrontal()
        {

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

        protected virtual ColumnView ColumnaActual { get { return null; } }
        protected virtual ColumnView Vista { get { return ColumnaActual; } }

        protected virtual ColumnView ColumnaActual2 { get { return null; } }
        protected virtual ColumnView Vista2 { get { return ColumnaActual2; } }

        protected virtual void LlenarGrid()
        {

        }

        protected virtual void Inicializar()
        {
            if (Vista != null)
            {
                Vista.GridControl.MouseDoubleClick += new MouseEventHandler(GridControl_MouseDoubleClick);
                Vista.GridControl.KeyDown += new KeyEventHandler(GridControl_KeyDown);
            }
        }

        private void Seleccionar()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (!soloLectura)
                SelecionarItem();
            Cursor.Current = Cursors.Default;
        }

        public virtual void SelecionarItem() { }

        protected internal virtual void EmitirMensajeResusltadoEliminar(bool resultado, string mensaje)
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

        protected internal virtual void EmitirMensajeResultado(bool resultado, string mensaje)
        {
            if (resultado)
            {
                XtraMessageBox.Show(this.FindForm(), mensaje, Mensajes.Informacion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                LlenarGrid();
            }
            else
                XtraMessageBox.Show(this.FindForm(), mensaje, Mensajes.Error, MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }


        protected internal virtual void Siguiente()
        {
            Vista.FocusedRowHandle++;
        }

        protected internal virtual void Anterior()
        {
            Vista.FocusedRowHandle--;
        }

        #region Eventos

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Inicializar();
            LlenarGrid();

            //Controlamos el solo lectura
            //this.SoloLectura = this.EjercicioContable != null ? EjercicioContable.cerrado && EjercicioContable.estadoConsulta : false;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            AntesCerrar();
            base.OnClosing(e);
        }

        void GridControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.Vista.OptionsBehavior.Editable == false && e.KeyCode == Keys.Enter)
                Seleccionar();
        }

        void GridControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            GridView gv = ((GridControl)sender).MainView as GridView;
            if (gv != null)
            {
                GridHitInfo info = gv.CalcHitInfo(new Point(e.X, e.Y));
                if (!info.InRow) return;
                Seleccionar();
            }
            else
            {
                ColumnView cv = ((GridControl)sender).MainView as ColumnView;
                if (cv != null)
                {
                    Seleccionar();
                }
            }
        }

        protected virtual void AntesCerrar()
        {

        }



        #endregion

    }
}