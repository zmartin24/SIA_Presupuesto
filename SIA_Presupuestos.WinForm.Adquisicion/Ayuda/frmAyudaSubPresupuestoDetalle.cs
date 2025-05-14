using System;
using SIA_Presupuesto.WinForm.General.Base;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using SIA_Presupuesto.WinForm.Adquisicion.Vista;
using SIA_Presupuesto.WinForm.Adquisicion.Presentador;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.Negocio.Entidades;
using System.Collections.Generic;

namespace SIA_Presupuesto.WinForm.Adquisicion.Ayuda
{
    public partial class frmAyudaSubPresupuestoDetalle : frmDialogoBaseAyuda, IAyudaSubPresupuestoDetalleVista
    {
        private AyudaSubPresupuestoDetallePresentador ayudaSubPresupuestoDetallePresentador;

        public object listaDatosPrincipales
        {
            set
            {
                grcSubPresupuestoDet.DataSource = value;
            }
        }

        public string desGrupoPresupuesto
        {
            set { this.txtGruPre.EditValue = value; }
        }
        public string desPresupuesto
        {
            set { this.txtPresupuesto.EditValue = value; }
        }
        public string desSubPresupuesto
        {
            set { this.txtSubPresupuesto.EditValue = value; }
        }
        public string desDireccion
        {
            set { this.txtDireccion.EditValue = value; }
        }
        public string numeroFore
        {
            set { }
        }
        public decimal cantidad
        {
            set { }
        }
        public string descripcion
        {
            set { }
        }
        public decimal tipCambio
        {
            set { this.seTipCam.EditValue = value; }
        }
        public frmAyudaSubPresupuestoDetalle(int idSubPresupuesto, List<SubPresupuestoDetallePres> listaSubPresupuestoDetalle, ForeDetallePoco foreDetallePoco)
        {
            InitializeComponent();
            this.ayudaSubPresupuestoDetallePresentador = new AyudaSubPresupuestoDetallePresentador(idSubPresupuesto, listaSubPresupuestoDetalle, this);
            Text = "Detalle de Presupuesto Mensual";
            this.descripcion = foreDetallePoco.descripcion;
            this.cantidad = foreDetallePoco.cantidad;
        }

        protected override ColumnView Vista { get { return grcSubPresupuestoDet.MainView as GridView; } }
        protected override ColumnView ColumnaActual { get { return grcSubPresupuestoDet.MainView as ColumnView; } }

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
            ayudaSubPresupuestoDetallePresentador.CargarLista();
            GridView view = grcSubPresupuestoDet.MainView as GridView;
            view.RowStyle += grvSubPresupuestoDet_RowStyle;
        }

        public override void SelecionarItem()
        {
            SubPresupuestoDetallePres objDetPres = DatoActual as SubPresupuestoDetallePres;
            if (objDetPres != null)
            {
                if (objDetPres.saldoSoles > 0 && objDetPres.saldoDolares > 0)
                {
                    ayudaSubPresupuestoDetallePresentador.AsignarDatosActual(this);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    Close();
                }
                else
                {
                    //EmitirMensajeResultado(true, "Tener en cuenta que la cuenta esta sin saldo a favor");
                    ayudaSubPresupuestoDetallePresentador.AsignarDatosActual(this);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    Close();
                }
            }
            else
                EmitirMensajeResultado(true, "Selección no válido!!");
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

        private void grvSubPresupuestoDet_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            ayudaSubPresupuestoDetallePresentador.PintarLista(sender, e);
        }
    }
}