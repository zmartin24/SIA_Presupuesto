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
using SIA_Presupuesto.WinForm.Adquisicion.Vista;
using SIA_Presupuesto.WinForm.Adquisicion.Presentador;
using SIA_Presupuesto.WinForm.Adquisicion.Recursos;
using SIA_Presupuesto.WinForm.Adquisicion.Dialogo;
using SIA_Presupuesto.Negocio.Entidades;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace SIA_Presupuesto.WinForm.Adquisicion
{
    public partial class frmListaGastoRecurrenteRequerimiento : ControlDetalleBase, IListaGastoRecurrenteRequerimientoVista
    {
        private GastoRecurrenteRequerimientoPresentador gastoRecurrenteRequerimientoPresentador;

        public List<GastoRecurrenteRequerimientoPres> listaDatosPrincipales
        {
            set
            {
                grcProgramacion.DataSource = value;
            }
        }

        private GastoRecurrente gastoRecurrente;
        public frmListaGastoRecurrenteRequerimiento(GastoRecurrente gastoRecurrente)
        {
            InitializeComponent();
            this.gastoRecurrente = gastoRecurrente;
            this.gastoRecurrenteRequerimientoPresentador = new GastoRecurrenteRequerimientoPresentador(gastoRecurrente, this);
            Text = gastoRecurrente == null ? string.Empty : gastoRecurrente.descripcion;
            esSoloListado = true;
        }

        protected override ColumnView ColumnaActual { get { return grcProgramacion.MainView as ColumnView; } }
        protected override DevExpress.XtraGrid.GridControl GridPrincipal { get { return grcProgramacion; } }

        public GastoRecurrenteRequerimiento gastoRecurrenteRequerimiento
        {
            get
            {
                if (ColumnaActual == null || ColumnaActual.FocusedRowHandle < 0) return null;
                var pro = ColumnaActual.GetRow(ColumnaActual.FocusedRowHandle) as GastoRecurrenteRequerimientoPres;
                return pro != null ? gastoRecurrenteRequerimientoPresentador.BuscarArea((Int32)pro.idGasRecReq) : null;
            }
        }

        protected ColumnView ColumnaActual1 { get { return grcProgramacion.ViewCollection[2].DataRowCount > 0 ? grcProgramacion.ViewCollection[2] as ColumnView : null; } }

        public GastoRecurrenteDetalle gastoRecurrenteDetalle
        {
            get
            {
                if (ColumnaActual1 == null || ColumnaActual1.FocusedRowHandle < 0) return null;
                var pro = ColumnaActual1.GetRow(ColumnaActual1.FocusedRowHandle) as GastoRecurrenteDetallePres;
                return pro != null ? gastoRecurrenteRequerimientoPresentador.BuscarDetalle((Int32)pro.idGasRecDet) : null;
            }
            
        }

        public GastoRecurrenteRequerimientoPres gastoRecurrenteRequerimientoPres
        {
            get
            {
                if (ColumnaActual == null || ColumnaActual.FocusedRowHandle < 0) return null;
                return ColumnaActual.GetRow(ColumnaActual.FocusedRowHandle) as GastoRecurrenteRequerimientoPres;
            }
        }

        protected override void InicializarDatos()
        {
            this.gastoRecurrenteRequerimientoPresentador.IniciarDatos();
        }

        protected override void InicializarValidacion()
        {

        }
        protected override bool ValidarDatos()
        {
            return ProveedorValidacion.Validate(); 
        }
        protected override void OtrasOperaciones(string nomOperacion)
        {
            switch(nomOperacion)
            {
                case "DetalleDet":
                    AbrirDetalle(false);
                    break;
                case "ModificarDetalle":
                    AbrirDetalle(true);
                    break;
                case "AnularDetalle":
                    AnularDetalle();
                    break;
            }
        }

        protected override void LlenarGrid()
        {
            gastoRecurrenteRequerimientoPresentador.ObtenerDatosListado();
        }

        protected override void Nuevo()
        {
            using (frmGastoRecurrenteCabecera frm = new frmGastoRecurrenteCabecera(this.gastoRecurrente, null, this.FindForm()))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LlenarGrid();
                }
            }
        }

        protected override void Modificar()
        {
            if (this.gastoRecurrenteRequerimiento != null)
            {
                using (frmGastoRecurrenteCabecera frm = new frmGastoRecurrenteCabecera(this.gastoRecurrente, gastoRecurrenteRequerimiento, this.FindForm()))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        LlenarGrid();
                    }
                }
            }
            else
                EmitirMensajeResultado(false, Mensajes.RegistroVacio);
        }

        protected override void Anular()
        {
            if (EmitirMensajePregunta(Mensajes.PreguntaAnularRegistro))
            {
                if (gastoRecurrenteRequerimientoPresentador.AnularGastoRecurrenteCab())
                    EmitirMensajeResultado(true, "Anulado correctamente");
                else
                    EmitirMensajeResultado(false, "No se puedo anular");
            }
        }

        protected void AnularDetalle()
        {
            if (this.gastoRecurrenteRequerimiento != null)
            {
                if (EmitirMensajePregunta(Mensajes.PreguntaAnularRegistro))
                {
                    if (gastoRecurrenteRequerimientoPresentador.AnularDetalle())
                        EmitirMensajeResultado(true, "Anulado correctamente");
                    else
                        EmitirMensajeResultado(false, "No se puedo anular el detalle");
                }
            }
            else
                EmitirMensajeResultado(false, Mensajes.RegistroVacio);
        }


        private void AbrirDetalle(bool esModificacion)
        {
            if (gastoRecurrenteRequerimiento != null)
            {
                string numCuenta = string.Empty;

                var gv = grcProgramacion.MainView as GridView;
                var topRowIndex = gv.TopRowIndex;
                var index = gv.FocusedRowHandle;

                var vistaDet = (ColumnView)grcProgramacion.FocusedView;
                var indexDet = vistaDet.FocusedRowHandle;

                if (esModificacion && gastoRecurrenteDetalle == null) return;

                using (frmGastoRecurrenteDetalle frm = new frmGastoRecurrenteDetalle("", numCuenta, gastoRecurrenteRequerimiento, esModificacion ? gastoRecurrenteDetalle : null, this.FindForm()))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        LlenarGrid();

                        grvGastoRecurrente.SetMasterRowExpanded(index, true);
                        grvGastoRecurrente.FocusedRowHandle = index;
                        grvGastoRecurrente.TopRowIndex = topRowIndex;
                    }
                }
            }
        }

        protected override void GuardarDatos()
        { 
        }

        protected override void CerrarFormularioCancelar()
        {
        }

        protected override void LlenarLookUpGenerales()
        {
        }

        private void grvProgramacion_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            var cambio = grvGastoRecurrente.GetRow(e.RowHandle) as ProgramacionAnualAreaPres;
            if (cambio != null)
            {
                string numero = string.Empty;
                decimal num = 0;
                switch (e.Column.FieldName)
                {
                    case "enero":

                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            gastoRecurrenteRequerimientoPresentador.IngresarMontoArea(1, num);
                        }
                        break;

                    case "febrero":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            //if (num != cambio.febrero)
                            //{
                            gastoRecurrenteRequerimientoPresentador.IngresarMontoArea(2, num);
                            //}
                        }
                        break;
                    case "marzo":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            //if (num != cambio.marzo)
                            //{
                            gastoRecurrenteRequerimientoPresentador.IngresarMontoArea(3, num);
                            //}
                        }
                        break;
                    case "abril":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            //if (num != cambio.abril)
                            //{
                            gastoRecurrenteRequerimientoPresentador.IngresarMontoArea(4, num);
                            //}
                        }
                        break;
                    case "mayo":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            //if (num != cambio.mayo)
                            //{
                            gastoRecurrenteRequerimientoPresentador.IngresarMontoArea(5, num);
                            //}
                        }
                        break;
                    case "junio":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            //if (num != cambio.junio)
                            //{
                            gastoRecurrenteRequerimientoPresentador.IngresarMontoArea(6, num);
                            //}
                        }
                        break;
                    case "julio":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            //if (num != cambio.julio)
                            //{
                            gastoRecurrenteRequerimientoPresentador.IngresarMontoArea(7, num);
                            //}
                        }
                        break;
                    case "agosto":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            //if (num != cambio.agosto)
                            //{
                            gastoRecurrenteRequerimientoPresentador.IngresarMontoArea(8, num);
                            //}
                        }
                        break;
                    case "setiembre":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            //if (num != cambio.setiembre)
                            //{
                            gastoRecurrenteRequerimientoPresentador.IngresarMontoArea(9, num);
                            //}
                        }
                        break;
                    case "octubre":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            //if (num != cambio.octubre)
                            //{
                            gastoRecurrenteRequerimientoPresentador.IngresarMontoArea(10, num);
                            //}
                        }
                        break;
                    case "novimebre":
                        numero = Convert.ToString(e.Value);
                        
                        if (decimal.TryParse(numero, out num))
                        {
                            //if (num != cambio.novimebre)
                            //{
                            gastoRecurrenteRequerimientoPresentador.IngresarMontoArea(11, num);
                            //}
                        }
                        break;
                    case "diciembre":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            //if (num != cambio.diciembre)
                            //{
                            gastoRecurrenteRequerimientoPresentador.IngresarMontoArea(12, num);
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

        private void bgvDetalle_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            ColumnView focusedView = (ColumnView)grcProgramacion.FocusedView;
            var cambio = focusedView.GetRow(e.RowHandle) as GastoRecurrenteDetallePres;

            var gv = grcProgramacion.MainView as GridView;
            var index = gv.FocusedRowHandle;

            if (cambio != null)
            {
                string numero = string.Empty;
                decimal num = 0;
                switch (e.Column.FieldName)
                {
                    case "enero":

                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            gastoRecurrenteRequerimientoPresentador.IngresarMontoDetalle(1, num);
                        }
                        break;

                    case "cantEnero":

                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            gastoRecurrenteRequerimientoPresentador.IngresarCantidadDetalle(1, 1, cambio.precio, num);
                        }

                        break;

                    case "febrero":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            gastoRecurrenteRequerimientoPresentador.IngresarMontoDetalle(2, num);
                        }
                        break;

                    case "cantFebrero":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            gastoRecurrenteRequerimientoPresentador.IngresarCantidadDetalle(2, 1, cambio.precio, num);
                        }
                        break;

                    case "marzo":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            if (num != cambio.marzo)
                            {
                                gastoRecurrenteRequerimientoPresentador.IngresarMontoDetalle(3, num);
                            }
                        }
                        break;

                    case "cantMarzo":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            gastoRecurrenteRequerimientoPresentador.IngresarCantidadDetalle(3, 1, cambio.precio, num);
                        }
                        break;

                    case "abril":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            gastoRecurrenteRequerimientoPresentador.IngresarMontoDetalle(4, num);
                        }
                        break;

                    case "cantAbril":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            gastoRecurrenteRequerimientoPresentador.IngresarCantidadDetalle(4, 1, cambio.precio, num);
                        }
                        break;

                    case "mayo":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            gastoRecurrenteRequerimientoPresentador.IngresarMontoDetalle(5, num);
                        }
                        break;

                    case "cantMayo":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            gastoRecurrenteRequerimientoPresentador.IngresarCantidadDetalle(5, 1, cambio.precio, num);
                        }
                        break;

                    case "junio":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            gastoRecurrenteRequerimientoPresentador.IngresarMontoDetalle(6, num);
                        }
                        break;

                    case "cantJunio":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            gastoRecurrenteRequerimientoPresentador.IngresarCantidadDetalle(6, 1, cambio.precio, num);
                        }
                        break;

                    case "julio":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            gastoRecurrenteRequerimientoPresentador.IngresarMontoDetalle(7, num);
                        }
                        break;

                    case "cantJulio":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            gastoRecurrenteRequerimientoPresentador.IngresarCantidadDetalle(7, 1, cambio.precio, num);
                        }
                        break;

                    case "agosto":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            gastoRecurrenteRequerimientoPresentador.IngresarMontoDetalle(8, num);
                        }
                        break;

                    case "cantAgosto":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            gastoRecurrenteRequerimientoPresentador.IngresarCantidadDetalle(8, 1, cambio.precio, num);
                        }
                        break;

                    case "setiembre":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            gastoRecurrenteRequerimientoPresentador.IngresarMontoDetalle(9, num);
                        }
                        break;

                    case "cantSetiembre":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            gastoRecurrenteRequerimientoPresentador.IngresarCantidadDetalle(9, 1, cambio.precio, num);
                        }
                        break;

                    case "octubre":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            gastoRecurrenteRequerimientoPresentador.IngresarMontoDetalle(10, num);
                        }
                        break;

                    case "cantOctubre":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            gastoRecurrenteRequerimientoPresentador.IngresarCantidadDetalle(10, 1, cambio.precio, num);
                        }
                        break;

                    case "noviembre":
                        numero = Convert.ToString(e.Value);

                        if (decimal.TryParse(numero, out num))
                        {
                            gastoRecurrenteRequerimientoPresentador.IngresarMontoDetalle(11, num);
                        }
                        break;

                    case "cantNoviembre":
                        numero = Convert.ToString(e.Value);

                        if (decimal.TryParse(numero, out num))
                        {
                            gastoRecurrenteRequerimientoPresentador.IngresarCantidadDetalle(11, 1, cambio.precio, num);
                        }
                        break;

                    case "diciembre":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            gastoRecurrenteRequerimientoPresentador.IngresarMontoArea(12, num);
                        }
                        break;

                    case "cantDiciembre":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            gastoRecurrenteRequerimientoPresentador.IngresarCantidadDetalle(12, 1, cambio.precio, num);
                        }
                        break;
                }
            }
            grvGastoRecurrente.SetMasterRowExpanded(index, true);
            grvGastoRecurrente.FocusedRowHandle = index;

            bgvDetalle.FocusedRowHandle = e.RowHandle;
        }

        private void grcProgramacion_FocusedViewChanged(object sender, DevExpress.XtraGrid.ViewFocusEventArgs e)
        {
            if (e.View != null && e.View.IsDetailView)
            {
                (e.View.ParentView as GridView).FocusedRowHandle = e.View.SourceRowHandle;
                RefrescarGrilla(e.View.SourceRowHandle);
                (e.View.ParentView as GridView).FocusedRowHandle = e.View.SourceRowHandle;
                (e.View.ParentView as GridView).SetMasterRowExpanded(e.View.SourceRowHandle, true);
            }
            else if (e.View != null)
            {
                (e.View as GridView).FocusedRowHandle = e.View.SourceRowHandle;
                (e.View as GridView).SetMasterRowExpanded(e.View.SourceRowHandle, true);
                RefrescarGrilla(e.View.SourceRowHandle);
            }
        }

        private void RefrescarGrilla(int fila)
        {
            if (grvGastoRecurrente.GetMasterRowExpanded(fila))
            {
                grvGastoRecurrente.SetMasterRowExpanded(fila, false);
                grvGastoRecurrente.SetMasterRowExpanded(fila, true);
            }
        }
    }
}
