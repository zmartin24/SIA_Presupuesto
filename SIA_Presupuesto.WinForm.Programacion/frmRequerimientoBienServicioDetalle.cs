using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SIA_Presupuesto.WinForm.General.Base;
using SIA_Presupuesto.WinForm.Programacion.Vista;
using SIA_Presupuesto.WinForm.Programacion.Presentador;
using SIA_Presupuesto.WinForm.Programacion.Recursos;
using SIA_Presupuesto.WinForm.Programacion.Dialogo;
using SIA_Presupuesto.Negocio.Entidades;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace SIA_Presupuesto.WinForm.Programacion
{
    public partial class frmRequerimientoBienServicioDetalle : ControlDetalleBase, IRequerimientoBienServicioDetalleVista
    {
        private RequerimientoBienServicioDetallePresentador requerimientoBienServicioDetallePresentador;

        public List<RequerimientoBienServicioDetallePres> listaDatosPrincipales
        {
            set
            {
                grcProgramacion.DataSource = value;
            }
        }

        private RequerimientoBienServicio RequerimientoBienServicio;
        private string numCuenta;
        public frmRequerimientoBienServicioDetalle(string numCuenta, RequerimientoBienServicio RequerimientoBienServicio)
        {
            InitializeComponent();
            this.numCuenta = numCuenta;
            this.RequerimientoBienServicio = RequerimientoBienServicio;
            this.requerimientoBienServicioDetallePresentador = new RequerimientoBienServicioDetallePresentador(RequerimientoBienServicio, this);
            Text = RequerimientoBienServicio.descripcion;
            this.esSoloListado = true;
        }

        protected override ColumnView ColumnaActual { get { return grcProgramacion.MainView as ColumnView; } }
        protected override DevExpress.XtraGrid.GridControl GridPrincipal { get { return grcProgramacion; } }

        public RequerimientoBienServicioDetalle RequerimientoBienServicioDetalle
        {
            get
            {
                if (ColumnaActual == null || ColumnaActual.FocusedRowHandle < 0) return null;
                var pro = ColumnaActual.GetRow(ColumnaActual.FocusedRowHandle) as RequerimientoBienServicioDetallePres;
                return pro != null ? requerimientoBienServicioDetallePresentador.BuscarDetalle((Int32)pro.idReqBieSerDet) : null;
            }
        }

        protected override void InicializarDatos()
        {
            this.requerimientoBienServicioDetallePresentador.IniciarDatos();
        }

        protected override void InicializarValidacion()
        {

        }
        protected override bool ValidarDatos()
        {
            return ProveedorValidacion.Validate(); 
        }

        protected override void LlenarGrid()
        {
            requerimientoBienServicioDetallePresentador.ObtenerDatosListado();
        }

        protected override void Nuevo()
        {
            using (frmRequerimientoBienServicioDet frm = new frmRequerimientoBienServicioDet(this.numCuenta, null, this.RequerimientoBienServicio, this.FindForm()))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LlenarGrid();
                }
            }
        }

        protected override void Modificar()
        {
            using (frmRequerimientoBienServicioDet frm = new frmRequerimientoBienServicioDet(this.numCuenta, RequerimientoBienServicioDetalle, this.RequerimientoBienServicio, this.FindForm()))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LlenarGrid();
                }
            }
        }


        protected override void Anular()
        {
            if (requerimientoBienServicioDetallePresentador.AnularArea())
                EmitirMensajeResultado(true, "Anulado correctamente");
            else
                EmitirMensajeResultado(false, "No se puedo anular");
        }


        protected override void GuardarDatos()
        { 
            //if (requerimientoBienServicioDetallePresentador.GuardarDatos())
            //{
            //    if (!esModificacion)
            //        EmitirMensajeResultado(true, Mensajes.MensajeRegistroSatisfactorio);
            //    else
            //        EmitirMensajeResultado(true, Mensajes.MensajeModificacionSatisfactoria);
            //}
            //else
            //{
            //    retornarResultado = DialogResult.No;
            //    EmitirMensajeResultado(false, Mensajes.MensajeErrorRegistro);
            //}
        }

        protected override void CerrarFormularioCancelar()
        {

        }

        protected override void LlenarLookUpGenerales()
        {

        }

        private void grvProgramacion_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            var cambio = grvProgramacion.GetRow(e.RowHandle) as RequerimientoBienServicioDetallePres;
            if (cambio != null)
            {
                string numero = string.Empty;
                decimal num = 0;
                switch (e.Column.FieldName)
                {
                    case "cantEnero":

                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            //if (num != cambio.cantEnero)
                            //{
                                requerimientoBienServicioDetallePresentador.IngresarCantidadDetalle(1, num);
                            //}
                        }
                        break;

                    case "cantFebrero":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            //if (num != cambio.cantFebrero)
                            //{
                                requerimientoBienServicioDetallePresentador.IngresarCantidadDetalle(2, num);
                            //}
                        }
                        break;
                    case "cantMarzo":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            //if (num != cambio.cantMarzo)
                            //{
                                requerimientoBienServicioDetallePresentador.IngresarCantidadDetalle(3, num);
                            //}
                        }
                        break;
                    case "cantAbril":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            //if (num != cambio.cantAbril)
                            //{
                                requerimientoBienServicioDetallePresentador.IngresarCantidadDetalle(4, num);
                            //}
                        }
                        break;
                    case "cantMayo":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            //if (num != cambio.cantMayo)
                            //{
                                requerimientoBienServicioDetallePresentador.IngresarCantidadDetalle(5, num);
                            //}
                        }
                        break;
                    case "cantJunio":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            //if (num != cambio.cantJunio)
                            //{
                                requerimientoBienServicioDetallePresentador.IngresarCantidadDetalle(6, num);
                            //}

                        }
                        break;
                    case "cantJulio":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            //if (num != cambio.cantJulio)
                            //{
                                requerimientoBienServicioDetallePresentador.IngresarCantidadDetalle(7, num);
                            //}
                        }
                        break;
                    case "cantAgosto":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            //if (num != cambio.cantAgosto)
                            //{
                                requerimientoBienServicioDetallePresentador.IngresarCantidadDetalle(8, num);
                            //}
                        }
                        break;
                    case "cantSetiembre":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            //if (num != cambio.cantSetiembre)
                            //{
                                requerimientoBienServicioDetallePresentador.IngresarCantidadDetalle(9, num);
                            //}
                        }
                        break;
                    case "cantOctubre":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            //if (num != cambio.cantOctubre)
                            //{
                                requerimientoBienServicioDetallePresentador.IngresarCantidadDetalle(10, num);
                            //}
                        }
                        break;
                    case "cantNoviembre":
                        numero = Convert.ToString(e.Value);
                        
                        if (decimal.TryParse(numero, out num))
                        {
                            //if (num != cambio.cantNoviembre)
                            //{
                                requerimientoBienServicioDetallePresentador.IngresarCantidadDetalle(11, num);
                            //}
                        }
                        break;
                    case "cantDiciembre":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            //if (num != cambio.cantDiciembre)
                            //{
                                requerimientoBienServicioDetallePresentador.IngresarCantidadDetalle(12, num);
                            //}
                        }
                        break;
                }
            }
        }

        private void grvProgramacion_MasterRowExpanded(object sender, DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventArgs e)
        {
            GridView view = sender as GridView;
            if (view != null)
            {
                GridView detailView = view.GetDetailView(e.RowHandle, e.RelationIndex) as GridView;
                if (detailView != null) detailView.ExpandGroupRow(-1);
            }
        }

        
    }
}
