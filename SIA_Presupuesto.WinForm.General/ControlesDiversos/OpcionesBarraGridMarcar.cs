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
using System.Collections;
using SIA_Presupuesto.WinForm.General.Helper;

namespace SIA_Presupuesto.WinForm.General.ControlesDiversos
{
    public partial class OpcionesBarraGridMarcar : XtraUserControl, IXtraResizableControl {
        public event EventHandler MarcarRegistro;
        public event EventHandler DesmarcarRegistro;
        public event EventHandler MarcarTodosRegistro;
        public event EventHandler DesmarcarTodosRegistro;
        public event EventHandler SiguienteRegistro;
        public event EventHandler AnteriorRegistro;

        GridView vista;
        IDictionary lista;
        public OpcionesBarraGridMarcar()
        {
            InitializeComponent();
            bbiMarcarTodos.Glyph = ImagenHelper.TraerImagen("SelectAllMarked", TamanioImagen.Pequenio16);
            bbiMarcar.Glyph = ImagenHelper.TraerImagen("ActiveRents", TamanioImagen.Pequenio16);
            bbiDesmarcarTodos.Glyph = ImagenHelper.TraerImagen("UnmarkAll", TamanioImagen.Pequenio16);
            bbiDesmarcar.Glyph = ImagenHelper.TraerImagen("Unmark", TamanioImagen.Pequenio16);
            bbiAnterior.Glyph = ImagenHelper.TraerImagen("Previous", TamanioImagen.Pequenio16);
            bbiSiguiente.Glyph = ImagenHelper.TraerImagen("Next", TamanioImagen.Pequenio16);
        }

        public void Inicializar(GridView vista, IDictionary lista) 
        {
            this.vista = vista;
            InicializarBotones();
            this.lista = lista;
            vista.FocusedRowChanged += new FocusedRowChangedEventHandler(view_FocusedRowChanged);


        }

        internal void MostrarTituloBotones()
        {
            //bbiAgregar
        }

        protected override void OnLoad(EventArgs e) 
        {
            base.OnLoad(e);
            RaiseChanged();
        }

        public void ActualizarContador()
        {
            if (vista != null)
            {
                beiCantidad.EditValue = lista.Count;
            }
        }

        private void view_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e) {
            InicializarBotones();
        }

        private void InicializarBotones()
        {
            bool des = vista.GetRow(vista.FocusedRowHandle) != null;
            bbiMarcar.Enabled = des;
            bbiDesmarcar.Enabled = des;
            bbiMarcarTodos.Enabled = des;
            bbiDesmarcarTodos.Enabled = des;
            bbiSiguiente.Enabled = des;
            bbiAnterior.Enabled = des;
        }
        bool soloLectura = false;
        public void SoloLectura()
        {
            bbiMarcar.Enabled = false;
            bbiDesmarcar.Enabled = false;
            bbiMarcarTodos.Enabled = false;
            bbiDesmarcarTodos.Enabled = false;
            bbiSiguiente.Enabled = false;
            bbiAnterior.Enabled = false;

            this.soloLectura = true;
        }

        internal void DesabilitarBotones() {
            bbiMarcarTodos.Enabled = bbiDesmarcarTodos.Enabled = bbiMarcar.Enabled = bbiDesmarcar.Enabled = bbiSiguiente.Enabled = bbiAnterior.Enabled = false;
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

        private void bbiMarcarTodos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MarcarTodosRegistro != null) MarcarTodosRegistro(this, e);
            ActualizarContador();
        }

        private void bbiDesmarcarTodos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (DesmarcarTodosRegistro != null) DesmarcarTodosRegistro(this, e);
            ActualizarContador();
        }

        private void bbiMarcar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MarcarRegistro != null) MarcarRegistro(this, e);
            ActualizarContador();
        }

        private void bbiDesmarcar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (DesmarcarRegistro != null) DesmarcarRegistro(this, e);
            ActualizarContador();
        }

        private void bbiSiguiente_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (SiguienteRegistro != null) SiguienteRegistro(this, e);
        }

        private void bbiAnterior_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (AnteriorRegistro != null) AnteriorRegistro(this, e);
        }

        
    }
}
