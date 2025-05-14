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
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using SIA_Presupuesto.WinForm.General.Base;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Presentador;
using SIA_Presupuesto.WinForm.General.Vistas;

namespace SIA_Presupuesto.WinForm.General.Ayuda
{
    public partial class frmAyudaProducto : frmDialogoBaseAyuda, IAyudaProductoVista
    {
        private AyudaProductoPresentador ayudaProducto;
        public List<Producto> listaDatosPrincipales
        {
            set
            {
                grcProducto.DataSource = value;
            }
        }

        public frmAyudaProducto(string numCuenta)
        {
            InitializeComponent();
            this.ayudaProducto = new AyudaProductoPresentador(numCuenta, this);
            Text = "Ayuda Producto";
        }

        protected override ColumnView Vista { get { return grcProducto.MainView as GridView; } }
        protected override ColumnView ColumnaActual { get { return grcProducto.MainView as ColumnView; } }

        public Producto DatoActual
        {
            get
            {
                if (ColumnaActual == null || ColumnaActual.FocusedRowHandle < 0) return null;
                return ColumnaActual.GetRow(ColumnaActual.FocusedRowHandle) as Producto;
            }
        }

        protected override void Inicializar()
        {
            base.Inicializar();
        }

        protected override void LlenarGrid()
        {
            ayudaProducto.ObtenerDatosCuentas();
        }

        public override void SelecionarItem()
        {
            ayudaProducto.AsignarDatosActual(this);
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