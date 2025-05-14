using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SIA_Presupuesto.WinForm.General.Base;
using SIA_Presupuesto.WinForm.Mantenimiento.Vista;
using SIA_Presupuesto.WinForm.Mantenimiento.Presentador;
using DevExpress.XtraGrid.Views.Base;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.Mantenimiento.Dialogo;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.Mantenimiento.Recursos;

namespace SIA_Presupuesto.WinForm.Mantenimiento
{
    public partial class ListaPartidaPresupuestalCuenta : ControlDetalleBase, IListaPartidaPresupuestalCuentaVista
    {
        private ListaPartidaPresupuestalCuentaPresentador listaPartidaPresupuestalCuentaPresentador;
        public List<PartidaPresupuestalCuentaPoco> listaDatosPrincipales
        {
            set
            {
                grcPartidaPresupuestal.DataSource = value;
            }
        }
        public string tipo
        {
            set { txtTipo.EditValue = value; }
            get { return txtTipo.Text; }
        }
        public string descripcion
        {
            set { txtDescripcion.EditValue = value; }
            get { return txtDescripcion.Text; }
        }
        public string desUnidad
        {
            set { txtUnidad.EditValue = value; }
            get { return txtUnidad.Text; }
        }
        public decimal precio
        {
            set { sePrecio.EditValue = value; }
            get { return Convert.ToDecimal(sePrecio.EditValue); }
        }

        protected override ColumnView ColumnaActual { get { return grcPartidaPresupuestal.MainView as ColumnView; } }
        protected override DevExpress.XtraGrid.GridControl GridPrincipal { get { return grcPartidaPresupuestal; } }

        public PartidaPresupuestalCuentaPoco partidaPresupuestalCuentaPoco
        {
            get
            {
                if (ColumnaActual == null || ColumnaActual.FocusedRowHandle < 0) return null;
                return ColumnaActual.GetRow(ColumnaActual.FocusedRowHandle) as PartidaPresupuestalCuentaPoco;
            }
        }
        private PartidaPresupuestal partidaPresupuestal;

        public ListaPartidaPresupuestalCuenta(PartidaPresupuestal partidaPresupuestal)
        {
            InitializeComponent();
            this.partidaPresupuestal = partidaPresupuestal;
            this.listaPartidaPresupuestalCuentaPresentador = new ListaPartidaPresupuestalCuentaPresentador(partidaPresupuestal, this);
            Text = "Detalle de Cuentas";
            esSoloListado = true;
        }

        protected override void InicializarDatos()
        {
            base.InicializarDatos();
            this.listaPartidaPresupuestalCuentaPresentador.Iniciar();
        }
        protected override void Nuevo()
        {
            if (this.partidaPresupuestal != null)
            {
                using (frmPartidaPresupuestalAsignarCuenta frm = new frmPartidaPresupuestalAsignarCuenta(this.partidaPresupuestal, this.FindForm()))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        LlenarGrid();
                    }
                }
            }
        }
        
        protected override void Anular()
        {
            if (this.partidaPresupuestal != null)
            {
                if (EmitirMensajePregunta(Mensajes.PreguntaAnularRegistro))
                {
                    if (this.listaPartidaPresupuestalCuentaPresentador.Anular())
                        EmitirMensajeResultado(true, "Anulado correctamente");
                    else
                        EmitirMensajeResultado(false, "No se puedo anular");
                }  
            }
            else
                EmitirMensajeResultado(true, "Seleccione un detalle válido");
        }

        protected override void LlenarGrid()
        {
            this.listaPartidaPresupuestalCuentaPresentador.ObtenerDatosListado();
        }
    }
}
