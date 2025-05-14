using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SIA_Presupuesto.WinForm.General.Base;
using SIA_Presupuesto.WinForm.Programacion.Vista;
using SIA_Presupuesto.WinForm.Programacion.Presentador;
using SIA_Presupuesto.WinForm.Programacion.Dialogo;
using SIA_Presupuesto.Negocio.Entidades;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors;

namespace SIA_Presupuesto.WinForm.Programacion
{
    public partial class frmProgramacionAnual : ControlDetalleBase, IProgramacionAnualVista
    {
        private ProgramacionAnualPresentador programacionAnualPresentador;

        public List<ProgramacionAnualAreaPres> listaDatosPrincipales
        {
            set
            {
                grcProgramacion.DataSource = value;
            }
        }

        private ProgramacionAnual ProgramacionAnual;
        public frmProgramacionAnual(ProgramacionAnual ProgramacionAnual)
        {
            InitializeComponent();
            this.ProgramacionAnual = ProgramacionAnual;
            this.programacionAnualPresentador = new ProgramacionAnualPresentador(ProgramacionAnual, this,0);
            Text = ProgramacionAnual.descripcion;
            esSoloListado = true;
            riseTotal.ReadOnly = true;
        }

        protected override ColumnView ColumnaActual { get { return grcProgramacion.MainView as ColumnView; } }
        protected override DevExpress.XtraGrid.GridControl GridPrincipal { get { return grcProgramacion; } }

        public ProgramacionAnualArea ProgramacionAnualArea
        {
            get
            {
                if (ColumnaActual == null || ColumnaActual.FocusedRowHandle < 0) return null;
                var pro = ColumnaActual.GetRow(ColumnaActual.FocusedRowHandle) as ProgramacionAnualAreaPres;
                return pro != null ? programacionAnualPresentador.BuscarArea((Int32)pro.idProAnuArea) : null;
            }
        }

        //
        protected ColumnView ColumnaActual1 { get { return grcProgramacion.ViewCollection[2] as ColumnView; } }

        public ProgramacionAnualDetalle ProgramacionAnualDetalle
        {
            get
            {
                if (ColumnaActual1 == null || ColumnaActual1.FocusedRowHandle < 0) return null;
                var pro = ColumnaActual1.GetRow(ColumnaActual1.FocusedRowHandle) as ProgramacionAnualDetallePres;
                indiceDetalle = ColumnaActual1.FocusedRowHandle;
                return pro != null ? programacionAnualPresentador.BuscarDetalle((Int32)pro.idProAnuDet) : null;
            }
        }

        public ProgramacionAnualAreaPres ProgramacionAnualAreaPres
        {
            get
            {
                if (ColumnaActual == null || ColumnaActual.FocusedRowHandle < 0) return null;
                return ColumnaActual.GetRow(ColumnaActual.FocusedRowHandle) as ProgramacionAnualAreaPres;
            }
        }
        int indiceDetalle = 0;
        protected override void InicializarDatos()
        {
            this.programacionAnualPresentador.IniciarDatos();
            if(ProgramacionAnual.tipo.Equals("NN"))
            {
                gcDiasAbr.Visible = false;
                gcDiasAgo.Visible = false;
                gcDiasDic.Visible = false;
                gcDiasEne.Visible = false;
                gcDiasFeb.Visible = false;
                gcDiasJul.Visible = false;
                gcDiasJun.Visible = false;
                gcDiasMar.Visible = false;
                gcDiasMay.Visible = false;
                gcDiasNov.Visible = false;
                gcDiasOct.Visible = false;
                gcDiasSet.Visible = false;
            }
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
            programacionAnualPresentador.ObtenerDatosListado();
        }

        protected override void Nuevo()
        {
            using (frmProgramacionAnualArea frm = new frmProgramacionAnualArea(this.ProgramacionAnual, null, this.FindForm()))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LlenarGrid();
                }
            }
        }

        protected override void Modificar()
        {
            using (frmProgramacionAnualArea frm = new frmProgramacionAnualArea(this.ProgramacionAnual, ProgramacionAnualArea, this.FindForm()))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LlenarGrid();
                }
            }
        }


        protected override void Anular()
        {
            if (programacionAnualPresentador.AnularArea())
                EmitirMensajeResultado(true, "Anulado correctamente");
            else
                EmitirMensajeResultado(false, "No se puedo anular");
        }

        protected void AnularDetalle()
        {
            if (ProgramacionAnualArea != null)
            {
                string numCuenta = string.Empty;

                var gv = grcProgramacion.MainView as GridView;
                var topRowIndex = gv.TopRowIndex;
                var index = gv.FocusedRowHandle;

                //var vistaDet = (ColumnView)grcProgramacion.FocusedView;
                //var indexDet = vistaDet.FocusedRowHandle;

                if (programacionAnualPresentador.AnularDetalle())
                    EmitirMensajeResultado(true, "Detalle anulado correctamente");
                else
                    EmitirMensajeResultado(false, "No se puedo anular el detalle");

                grvProgramacion.SetMasterRowExpanded(index, true);
                grvProgramacion.FocusedRowHandle = index;
                grvProgramacion.TopRowIndex = topRowIndex;
            }
        }


        private void AbrirDetalle(bool esModificacion)
        {
            if (ProgramacionAnualArea != null)
            {
                string numCuenta = string.Empty;
                
                var gv = grcProgramacion.MainView as GridView;
                var topRowIndex = gv.TopRowIndex;
                var index = gv.FocusedRowHandle;

                var vistaDet = (ColumnView)grcProgramacion.FocusedView;
                var indexDet = vistaDet.FocusedRowHandle;

                using (frmProgramacionAnualDetalle frm = new frmProgramacionAnualDetalle(ProgramacionAnual.tipo, numCuenta, ProgramacionAnualArea, esModificacion ? ProgramacionAnualDetalle : null, this.FindForm()))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        LlenarGrid();
                        indiceDetalle = esModificacion ? indiceDetalle : 0;
                        grvProgramacion.SetMasterRowExpanded(index, true);
                        grvProgramacion.FocusedRowHandle = index;
                        grvProgramacion.TopRowIndex = topRowIndex;
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
            var cambio = grvProgramacion.GetRow(e.RowHandle) as ProgramacionAnualAreaPres;
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
                            //if (num != cambio.enero)
                            //{
                                programacionAnualPresentador.IngresarMontoArea(1, num);
                            //}
                        }
                        break;

                    case "febrero":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            //if (num != cambio.febrero)
                            //{
                                programacionAnualPresentador.IngresarMontoArea(2, num);
                            //}
                        }
                        break;
                    case "marzo":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            //if (num != cambio.marzo)
                            //{
                                programacionAnualPresentador.IngresarMontoArea(3, num);
                            //}
                        }
                        break;
                    case "abril":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            //if (num != cambio.abril)
                            //{
                                programacionAnualPresentador.IngresarMontoArea(4, num);
                            //}
                        }
                        break;
                    case "mayo":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            //if (num != cambio.mayo)
                            //{
                                programacionAnualPresentador.IngresarMontoArea(5, num);
                            //}
                        }
                        break;
                    case "junio":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            //if (num != cambio.junio)
                            //{
                                programacionAnualPresentador.IngresarMontoArea(6, num);
                            //}
                        }
                        break;
                    case "julio":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            //if (num != cambio.julio)
                            //{
                                programacionAnualPresentador.IngresarMontoArea(7, num);
                            //}
                        }
                        break;
                    case "agosto":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            //if (num != cambio.agosto)
                            //{
                                programacionAnualPresentador.IngresarMontoArea(8, num);
                            //}
                        }
                        break;
                    case "setiembre":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            //if (num != cambio.setiembre)
                            //{
                                programacionAnualPresentador.IngresarMontoArea(9, num);
                            //}
                        }
                        break;
                    case "octubre":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            //if (num != cambio.octubre)
                            //{
                                programacionAnualPresentador.IngresarMontoArea(10, num);
                            //}
                        }
                        break;
                    case "novimebre":
                        numero = Convert.ToString(e.Value);
                        
                        if (decimal.TryParse(numero, out num))
                        {
                            //if (num != cambio.novimebre)
                            //{
                                programacionAnualPresentador.IngresarMontoArea(11, num);
                            //}
                        }
                        break;
                    case "diciembre":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            //if (num != cambio.diciembre)
                            //{
                                programacionAnualPresentador.IngresarMontoArea(12, num);
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
                if (detailView != null) {
                    if(SoloLectura)
                        foreach (GridColumn columna in detailView.Columns)
                        {
                            columna.OptionsColumn.AllowEdit = false;
                        }

                    //detailView.ExpandGroupRow(-1);
                    detailView.FocusedRowHandle = indiceDetalle;
                }
            }
            grvProgramacion.GetDetailView(e.RowHandle, e.RelationIndex).Focus();
        }

        //int indiceDetalle = 0;
        private void grvDetalle_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            ColumnView focusedView = (ColumnView)grcProgramacion.FocusedView;
            var cambio = focusedView.GetRow(e.RowHandle) as ProgramacionAnualDetallePres;

            var gv = grcProgramacion.MainView as GridView;
            var index = gv.FocusedRowHandle;
            indiceDetalle = e.RowHandle;
            //grvDetalle.sel

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
                            programacionAnualPresentador.IngresarMontoDetalle(1, num);
                        }
                        break;

                    case "cantEnero":

                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            programacionAnualPresentador.IngresarCantidadDetalle((Int32)cambio.idProAnuDet, cambio.idProAnuArea, 1, (Int32)cambio.diasEnero > 0 ? (Int32)cambio.diasEnero : 1, cambio.precio, num);
                        }

                        break;

                    case "diasEnero":

                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            programacionAnualPresentador.IngresarCantidadDetalle(1, (Int32)num, cambio.precio, (decimal)cambio.cantEnero);
                        }

                        break;

                    case "febrero":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            programacionAnualPresentador.IngresarMontoDetalle(2, num);
                        }
                        break;

                    case "cantFebrero":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            programacionAnualPresentador.IngresarCantidadDetalle((Int32)cambio.idProAnuDet, cambio.idProAnuArea, 2, (Int32)cambio.diasFebrero > 0 ? (Int32)cambio.diasFebrero : 1, cambio.precio, num);
                        }
                        break;

                    case "diasFebrero":

                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            programacionAnualPresentador.IngresarCantidadDetalle(1, (Int32)num, cambio.precio, (decimal)cambio.cantFebrero);
                        }

                        break;

                    case "marzo":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            programacionAnualPresentador.IngresarMontoDetalle(3, num);
                        }
                        break;

                    case "cantMarzo":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            programacionAnualPresentador.IngresarCantidadDetalle((Int32)cambio.idProAnuDet, cambio.idProAnuArea, 3, (Int32)cambio.diasMarzo > 0 ? (Int32)cambio.diasMarzo : 1, cambio.precio, num);
                        }
                        break;

                    case "diasMarzo":

                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            programacionAnualPresentador.IngresarCantidadDetalle(1, (Int32)num, cambio.precio, (decimal)cambio.cantMarzo);
                        }

                        break;

                    case "abril":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            programacionAnualPresentador.IngresarMontoDetalle(4, num);
                        }
                        break;

                    case "cantAbril":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            programacionAnualPresentador.IngresarCantidadDetalle((Int32)cambio.idProAnuDet, cambio.idProAnuArea, 4, (Int32)cambio.diasAbril > 0 ? (Int32)cambio.diasAbril : 1, cambio.precio, num);
                        }
                        break;

                    case "diasAbril":

                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            programacionAnualPresentador.IngresarCantidadDetalle(1, (Int32)num, cambio.precio, (decimal)cambio.cantAbril);
                        }

                        break;

                    case "mayo":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            programacionAnualPresentador.IngresarMontoDetalle(5, num);
                        }
                        break;

                    case "cantMayo":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            programacionAnualPresentador.IngresarCantidadDetalle((Int32)cambio.idProAnuDet, cambio.idProAnuArea, 5, (Int32)cambio.diasMayo > 0 ? (Int32)cambio.diasMayo : 1, cambio.precio, num);
                        }
                        break;

                    case "diasMayo":

                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            programacionAnualPresentador.IngresarCantidadDetalle(1, (Int32)num, cambio.precio, (decimal)cambio.cantMayo);
                        }

                        break;

                    case "junio":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            programacionAnualPresentador.IngresarMontoDetalle(6, num);
                        }
                        break;

                    case "cantJunio":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            programacionAnualPresentador.IngresarCantidadDetalle((Int32)cambio.idProAnuDet, cambio.idProAnuArea, 6, (Int32)cambio.diasJunio > 0 ? (Int32)cambio.diasJunio : 1, cambio.precio, num);
                        }
                        break;

                    case "diasJunio":

                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            programacionAnualPresentador.IngresarCantidadDetalle(1, (Int32)num, cambio.precio, (decimal)cambio.cantJunio);
                        }

                        break;

                    case "julio":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            programacionAnualPresentador.IngresarMontoDetalle(7, num);
                        }
                        break;

                    case "cantJulio":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            programacionAnualPresentador.IngresarCantidadDetalle((Int32)cambio.idProAnuDet, cambio.idProAnuArea, 7, (Int32)cambio.diasJulio > 0 ? (Int32)cambio.diasJulio : 1, cambio.precio, num);
                        }
                        break;

                    case "diasJulio":

                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            programacionAnualPresentador.IngresarCantidadDetalle(1, (Int32)num, cambio.precio, (decimal)cambio.cantJulio);
                        }

                        break;

                    case "agosto":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            programacionAnualPresentador.IngresarMontoDetalle(8, num);
                        }
                        break;

                    case "cantAgosto":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            programacionAnualPresentador.IngresarCantidadDetalle((Int32)cambio.idProAnuDet, cambio.idProAnuArea, 8, (Int32)cambio.diasAgosto > 0 ? (Int32)cambio.diasAgosto : 1, cambio.precio, num);
                        }
                        break;

                    case "diasAgosto":

                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            programacionAnualPresentador.IngresarCantidadDetalle(1, (Int32)num, cambio.precio, (decimal)cambio.cantAgosto);
                        }

                        break;

                    case "setiembre":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            programacionAnualPresentador.IngresarMontoDetalle(9, num);
                        }
                        break;

                    case "cantSetiembre":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            programacionAnualPresentador.IngresarCantidadDetalle((Int32)cambio.idProAnuDet, cambio.idProAnuArea, 9, (Int32)cambio.diasSetiembre > 0 ? (Int32)cambio.diasSetiembre : 1, cambio.precio, num);
                        }
                        break;

                    case "diasSetiembre":

                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            programacionAnualPresentador.IngresarCantidadDetalle(1, (Int32)num, cambio.precio, (decimal)cambio.cantSetiembre);
                        }

                        break;


                    case "octubre":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            programacionAnualPresentador.IngresarMontoDetalle(10, num);
                        }
                        break;

                    case "cantOctubre":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            programacionAnualPresentador.IngresarCantidadDetalle((Int32)cambio.idProAnuDet, cambio.idProAnuArea, 10, (Int32)cambio.diasOctubre > 0 ? (Int32)cambio.diasOctubre : 1, cambio.precio, num);
                        }
                        break;

                    case "diasOctubre":

                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            programacionAnualPresentador.IngresarCantidadDetalle(1, (Int32)num, cambio.precio, (decimal)cambio.cantOctubre);
                        }

                        break;

                    case "noviembre":
                        numero = Convert.ToString(e.Value);

                        if (decimal.TryParse(numero, out num))
                        {
                            programacionAnualPresentador.IngresarMontoDetalle(11, num);
                        }
                        break;

                    case "cantNoviembre":
                        numero = Convert.ToString(e.Value);

                        if (decimal.TryParse(numero, out num))
                        {
                            programacionAnualPresentador.IngresarCantidadDetalle((Int32)cambio.idProAnuDet, cambio.idProAnuArea, 11, (Int32)cambio.diasNoviembre > 0 ? (Int32)cambio.diasNoviembre : 1, cambio.precio, num);
                        }
                        break;

                    case "diasNoviembre":

                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            programacionAnualPresentador.IngresarCantidadDetalle(1, (Int32)num, cambio.precio, (decimal)cambio.cantNoviembre);
                        }

                        break;

                    case "diciembre":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            programacionAnualPresentador.IngresarMontoArea(12, num);
                        }
                        break;

                    case "cantDiciembre":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            programacionAnualPresentador.IngresarCantidadDetalle((Int32)cambio.idProAnuDet, cambio.idProAnuArea, 12, (Int32)cambio.diasDiciembre > 0 ? (Int32)cambio.diasDiciembre : 1, cambio.precio, num);
                        }
                        break;

                    case "diasDiciembre":

                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            programacionAnualPresentador.IngresarCantidadDetalle(1, (Int32)num, cambio.precio, (decimal)cambio.cantDiciembre);
                        }

                        break;
                }
            }

            //grvProgramacion.FocusedRowHandle = index;
            grvProgramacion.SetMasterRowExpanded(index, true);

            //.FocusedRowHandle = e.RowHandle;
        }

        private void grcProgramacion_FocusedViewChanged(object sender, DevExpress.XtraGrid.ViewFocusEventArgs e)
        {
            if (e.View != null && e.View.IsDetailView)
            {
                (e.View.ParentView as GridView).FocusedRowHandle = e.View.SourceRowHandle;
                (e.View.ParentView as GridView).SetMasterRowExpanded(e.View.SourceRowHandle, true);
            }
            else if (e.View != null)
            {
                (e.View as GridView).FocusedRowHandle = e.View.SourceRowHandle;
                (e.View as GridView).SetMasterRowExpanded(e.View.SourceRowHandle, true);
            }
        }

        private void RefrescarGrilla(int fila)
        {
            if (grvProgramacion.GetMasterRowExpanded(fila))
            {
                grvProgramacion.SetMasterRowExpanded(fila, false);
                grvProgramacion.SetMasterRowExpanded(fila, true);
            }
        }

        private void grvProgramacion_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            //GridView view = sender as GridView;
            //if (view != null)
            //{
            //    GridView detailView = view.GetDetailView(e.FocusedRowHandle, e.RelationIndex) as GridView;
            //}
        }

        private void riseImp_Click(object sender, EventArgs e)
        {
            var spinEdit = (SpinEdit)sender;
            spinEdit.SelectAll();
        }
    }
}
