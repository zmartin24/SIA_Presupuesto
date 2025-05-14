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
    public partial class frmAyudaPartidaPresupuestalPrecio : frmDialogoBaseAyuda, IAyudaPartidaPresupuestalPrecioVista
    {
        private AyudaPartidaPresupuestalPrecioPresentador ayudaPartidaPresupuestalPrecioPresentador;
        public List<PartidaPresupuestalPrecioPres> listaDatosPrincipales
        {
            set
            {
                grcParPre.DataSource = value;
            }
        }
        public string desBusqueda
        {
            set { txtDesBusqueda.Text = value; }
            get { return txtDesBusqueda.Text; }
        }
        public int idMoneda
        {
            set; get;
        }

        public frmAyudaPartidaPresupuestalPrecio(RequerimientoMensualBienServicioPres requerimientoMensualBienServicioPres)
        {
            InitializeComponent();
            this.ayudaPartidaPresupuestalPrecioPresentador = new AyudaPartidaPresupuestalPrecioPresentador(requerimientoMensualBienServicioPres, this);
            Text = "Ayuda Partida Presupuestal";
        }

        protected override ColumnView Vista { get { return grcParPre.MainView as GridView; } }
        protected override ColumnView ColumnaActual { get { return grcParPre.MainView as ColumnView; } }

        public PartidaPresupuestalPrecioPres DatoActual
        {
            get
            {
                if (ColumnaActual == null || ColumnaActual.FocusedRowHandle < 0) return null;
                return ColumnaActual.GetRow(ColumnaActual.FocusedRowHandle) as PartidaPresupuestalPrecioPres;
            }
        }

        protected override void Inicializar()
        {
            base.Inicializar();
        }

        public override void SelecionarItem()
        {
            ayudaPartidaPresupuestalPrecioPresentador.AsignarDatosActual(this);
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

        private void txtDesBusqueda_EditValueChanged(object sender, EventArgs e)
        {
            if (txtDesBusqueda.Text.Length >= 3)
                ayudaPartidaPresupuestalPrecioPresentador.llenarGrid();
        }
    }
}