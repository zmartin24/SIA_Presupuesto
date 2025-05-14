using System;
using SIA_Presupuesto.WinForm.General.Base;
using SIA_Presupuesto.WinForm.General.Vistas;
using SIA_Presupuesto.WinForm.General.Presentador;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace SIA_Presupuesto.WinForm.General.Ayuda
{
    public partial class frmAyudaPresupuesto : frmDialogoBaseAyuda, IAyudaPresupuestoVista
    {
        private AyudaPresupuestoPresentador ayudaPresupuestoPresentador;

        public object listaDatosPrincipales
        {
            set
            {
                grcPresupuesto.DataSource = value;
            }
        }

        public string tituloColumna
        {
            set
            {
                gcDescripcion.Caption = value;
            }
        }

        public string nombreColumna
        {
            set
            {
                gcDescripcion.FieldName = value;
            }
        }

        public string tituloColumnaCodigo
        {
            set
            {
                gcCodigo.Caption = value;
            }
        }

        public string nombreColumnaCodigo
        {
            set
            {
                gcCodigo.FieldName = value;
            }
        }

        public frmAyudaPresupuesto(int id, tipoAyudaPresupuesto tipo)
        {
            InitializeComponent();
            this.ayudaPresupuestoPresentador = new AyudaPresupuestoPresentador(id, tipo, this);
            Text = "Ayuda de Presupuestos";
        }

        protected override ColumnView Vista { get { return grcPresupuesto.MainView as GridView; } }
        protected override ColumnView ColumnaActual { get { return grcPresupuesto.MainView as ColumnView; } }

        public object DatoActual
        {
            get
            {
                if (ColumnaActual == null || ColumnaActual.FocusedRowHandle < 0) return null;
                return ColumnaActual.GetRow(ColumnaActual.FocusedRowHandle) as object;
            }
        }

        protected override void Inicializar()
        {
            base.Inicializar();
        }

        protected override void LlenarGrid()
        {
            ayudaPresupuestoPresentador.CargarLista();
        }

        public override void SelecionarItem()
        {
            ayudaPresupuestoPresentador.AsignarDatosActual(this);
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
    }
}