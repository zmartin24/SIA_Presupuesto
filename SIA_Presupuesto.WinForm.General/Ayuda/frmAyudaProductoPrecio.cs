using System;
using System.Collections.Generic;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using SIA_Presupuesto.WinForm.General.Base;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Presentador;
using SIA_Presupuesto.WinForm.General.Vistas;

namespace SIA_Presupuesto.WinForm.General.Ayuda
{
    public partial class frmAyudaProductoPrecio : frmDialogoBaseAyuda, IAyudaProductoPrecioVista
    {
        private AyudaProductoPrecioPresentador ayudaProductoPrecio;
        public List<ProductoPrecioPres> listaDatosPrincipales
        {
            set
            {
                grcProducto.DataSource = value;
            }
        }
        public string desBusqueda
        {
            set { txtBusqueda.Text = value; }
            get { return txtBusqueda.Text; }
        }
        public int idMoneda
        {
            set;get;
        }

        public frmAyudaProductoPrecio(int idMoneda)
        {
            InitializeComponent();
            this.ayudaProductoPrecio = new AyudaProductoPrecioPresentador(idMoneda, this);
            Text = "Ayuda Producto";
        }

        protected override ColumnView Vista { get { return grcProducto.MainView as GridView; } }
        protected override ColumnView ColumnaActual { get { return grcProducto.MainView as ColumnView; } }

        public ProductoPrecioPres DatoActual
        {
            get
            {
                if (ColumnaActual == null || ColumnaActual.FocusedRowHandle < 0) return null;
                return ColumnaActual.GetRow(ColumnaActual.FocusedRowHandle) as ProductoPrecioPres;
            }
        }

        protected override void Inicializar()
        {
            base.Inicializar();
        }

        public override void SelecionarItem()
        {
            ayudaProductoPrecio.AsignarDatosActual(this);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void obgsSeleccion_AnteriorRegistro(object sender, EventArgs e)
        {
            Anterior();
        }

        private void obgsSeleccion_SeleccionarRegistro(object sender, EventArgs e)
        {
            SelecionarItem();
        }

        private void obgsSeleccion_SiguienteRegistro(object sender, EventArgs e)
        {
            Siguiente();
        }

        private void txtBusqueda_EditValueChanged(object sender, EventArgs e)
        {
            if (txtBusqueda.Text.Length >= 3)
                ayudaProductoPrecio.llenarGrid();
        }
    }
}