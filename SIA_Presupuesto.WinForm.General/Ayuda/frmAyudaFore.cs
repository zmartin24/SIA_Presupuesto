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
using SIA_Presupuesto.WinForm.General.Vistas;
using SIA_Presupuesto.WinForm.General.Presentador;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace SIA_Presupuesto.WinForm.General.Ayuda
{
    public partial class frmAyudaFore : frmDialogoBaseAyuda, IAyudaForeVista
    {
        private AyudaForePresentador ayudaForePresentador;

        public object listaDatosPrincipales
        {
            set
            {
                grcReq.DataSource = value;
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
        
        public frmAyudaFore(tipoAyudaFore tipo)
        {
            InitializeComponent();
            this.ayudaForePresentador = new AyudaForePresentador(tipo, this);
            Text = tipo.Equals(tipoAyudaFore.bien) ? "Ayuda Forebi" : "Ayuda Forese";
        }
        public frmAyudaFore(tipoAyudaFore tipo, int idSubpresupuesto)
        {
            InitializeComponent();
            this.ayudaForePresentador = new AyudaForePresentador(tipo, this, idSubpresupuesto);
            Text = tipo.Equals(tipoAyudaFore.bien) ? "Ayuda Forebi" : "Ayuda Forese";
        }

        protected override ColumnView Vista { get { return grcReq.MainView as GridView; } }
        protected override ColumnView ColumnaActual { get { return grcReq.MainView as ColumnView; } }

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
            ayudaForePresentador.CargarLista();
        }

        public override void SelecionarItem()
        {
            ayudaForePresentador.AsignarDatosActual(this);
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