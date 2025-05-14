using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Utils.Controls;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using SIA_Presupuesto.WinForm.General.Helper;

namespace SIA_Presupuesto.WinForm.General.ControlesDiversos
{
    public partial class OpcionesBarraGridSeleccion : XtraUserControl, IXtraResizableControl {
        public event EventHandler SeleccionarRegistro;
        public event EventHandler SiguienteRegistro;
        public event EventHandler AnteriorRegistro;

        GridView vista;
        bool permitir;

        public OpcionesBarraGridSeleccion()
        {
            InitializeComponent();
            bbiSeleccionar.Glyph = ImagenHelper.TraerImagen("ActiveRents", TamanioImagen.Pequenio16);
            bbiSiguiente.Glyph = ImagenHelper.TraerImagen("Next", TamanioImagen.Pequenio16);
            bbiAnterior.Glyph = ImagenHelper.TraerImagen("Previous", TamanioImagen.Pequenio16);
        }

        public void Inicializar()
        {
            InicializarBotones();
        }

        public void Inicializar(GridView vista) 
        {
            this.vista = vista;
            Inicializar();
            vista.FocusedRowChanged += new FocusedRowChangedEventHandler(view_FocusedRowChanged);
        }

        protected override void OnLoad(EventArgs e) 
        {
            base.OnLoad(e);
            RaiseChanged();
        }

        public void VisibleBotonesRecorrido(bool permitir) 
        {
            this.permitir = permitir;
        }

        private void view_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            InicializarBotones();
        }

        private void InicializarBotones()
        {
            if (this.permitir)
            {
                bbiSiguiente.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                bbiAnterior.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }

            if (this.vista != null)
            {
                bool des = vista.GetRow(vista.FocusedRowHandle) != null;
                bbiSeleccionar.Enabled = des;
                bbiSiguiente.Enabled = des;
                bbiAnterior.Enabled = des;
            }
        }

        bool soloLectura = false;
        public void SoloLectura()
        {
            bbiSeleccionar.Enabled = false;
            bbiSiguiente.Enabled = false;
            bbiAnterior.Enabled = false;
            this.soloLectura = true;
        }

        #region Miembros de IXtraResizableControl 

        public event EventHandler Changed;

        protected virtual void RaiseChanged()
        {
            if (Changed != null)
                Changed(this, EventArgs.Empty);
        }

        public bool IsCaptionVisible
        {
            get { return false; }
        }

        public Size MaxSize
        {
            get { return new Size(3000, AlturaControl); }
        }
        public Size MinSize
        {
            get { return new Size(170, AlturaControl); }
        }

        private int AlturaControl
        {
            get
            {
                if (BarraPrincipal == null || BarraPrincipal.Size.IsEmpty || BarraPrincipal.Size.Height == 0)
                    return 25;
                return BarraPrincipal.Size.Height;
            }
        }

        #endregion

        private void bbiSeleccionar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (SeleccionarRegistro != null) SeleccionarRegistro(this, e);
        }

        private void bbiAnterior_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (AnteriorRegistro != null) AnteriorRegistro(this, e);
        }

        private void bbiSiguiente_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (SiguienteRegistro != null) SiguienteRegistro(this, e);
        }


        
    }
}
