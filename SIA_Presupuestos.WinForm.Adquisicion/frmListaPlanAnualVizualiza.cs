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
using DevExpress.XtraGrid.Columns;

namespace SIA_Presupuesto.WinForm.Adquisicion
{
    public partial class frmListaPlanAnualVizualiza : ControlDetalleBase, IPlanAnualRequerimientoVista
    {
        private PlanAnualAdquisicionRequerimientoPresentador planAnualAdquisicionRequerimientoPresentador;

        public List<PlanAnualAdquisicionRequerimientoPres> listaDatosPrincipales
        {
            set
            {
                grcProgramacion.DataSource = value;
            }
        }

        private PlanAnualAdquisicion planAnualAdquisicion;
        public frmListaPlanAnualVizualiza(PlanAnualAdquisicion planAnualAdquisicion)
        {
            InitializeComponent();
            this.planAnualAdquisicion = planAnualAdquisicion;
            this.planAnualAdquisicionRequerimientoPresentador = new PlanAnualAdquisicionRequerimientoPresentador(planAnualAdquisicion, this);
            Text = planAnualAdquisicion.descripcion;
            esSoloListado = true;
        }

        protected override ColumnView ColumnaActual { get { return grcProgramacion.MainView as ColumnView; } }
        protected override DevExpress.XtraGrid.GridControl GridPrincipal { get { return grcProgramacion; } }

        public PlanAnualAdquisicionRequerimiento planAnualAdquisicionRequerimiento
        {
            get
            {
                if (ColumnaActual == null || ColumnaActual.FocusedRowHandle < 0) return null;
                var pro = ColumnaActual.GetRow(ColumnaActual.FocusedRowHandle) as PlanAnualAdquisicionRequerimientoPres;
                return pro != null ? planAnualAdquisicionRequerimientoPresentador.BuscarArea((Int32)pro.idPaaReq) : null;
            }
        }

        protected ColumnView ColumnaActual1 { get { return grcProgramacion.ViewCollection[2] as ColumnView; } }

        public PlanAnualAdquisicionDetalle planAnualAdquisicionDetalle
        {
            get
            {
                if (ColumnaActual1 == null || ColumnaActual1.FocusedRowHandle < 0) return null;
                var pro = ColumnaActual1.GetRow(ColumnaActual1.FocusedRowHandle) as PlanAnualAdquisicionDetallePres;
                return pro != null ? planAnualAdquisicionRequerimientoPresentador.BuscarDetalle((Int32)pro.idPaaDet) : null;
            }
            
        }

        public PlanAnualAdquisicionRequerimientoPres planAnualAdquisicionRequerimientoPres
        {
            get
            {
                if (ColumnaActual == null || ColumnaActual.FocusedRowHandle < 0) return null;
                return ColumnaActual.GetRow(ColumnaActual.FocusedRowHandle) as PlanAnualAdquisicionRequerimientoPres;
            }
        }

        protected override void InicializarDatos()
        {
            this.planAnualAdquisicionRequerimientoPresentador.IniciarDatos();
            //if(planAnualAdquisicion.tipo.Equals("NN"))
            //{
                //gcDiasAbr.Visible = false;
                //gcDiasAgo.Visible = false;
                //gcDiasDic.Visible = false;
                //gcDiasEne.Visible = false;
                //gcDiasFeb.Visible = false;
                //gcDiasJul.Visible = false;
                //gcDiasJun.Visible = false;
                //gcDiasMar.Visible = false;
                //gcDiasMay.Visible = false;
                //gcDiasNov.Visible = false;
                //gcDiasOct.Visible = false;
                //gcDiasSet.Visible = false;
            //}
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
            planAnualAdquisicionRequerimientoPresentador.ObtenerDatosListado();
        }

        protected override void Nuevo()
        {
            using (frmPlanAnualAdquisicionCabecera frm = new frmPlanAnualAdquisicionCabecera(this.planAnualAdquisicion, null, this.FindForm()))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LlenarGrid();
                }
            }
        }

        protected override void Modificar()
        {
            using (frmPlanAnualAdquisicionCabecera frm = new frmPlanAnualAdquisicionCabecera(this.planAnualAdquisicion, planAnualAdquisicionRequerimiento, this.FindForm()))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LlenarGrid();
                }
            }
        }

        protected override void Anular()
        {
            if (EmitirMensajePregunta(Mensajes.PreguntaAnularRegistro))
            {
                if (planAnualAdquisicionRequerimientoPresentador.AnularArea())
                    EmitirMensajeResultado(true, "Anulado correctamente");
                else
                    EmitirMensajeResultado(false, "No se puedo anular");
            }
        }

        protected void AnularDetalle()
        {
            if (EmitirMensajePregunta(Mensajes.PreguntaAnularRegistro))
            {
                if (planAnualAdquisicionRequerimientoPresentador.AnularDetalle())
                    EmitirMensajeResultado(true, "Anulado correctamente");
                else
                    EmitirMensajeResultado(false, "No se puedo anular el detalle");
            }
        }


        private void AbrirDetalle(bool esModificacion)
        {
            //if (planAnualAdquisicionRequerimiento != null)
            //{
            //    string numCuenta = string.Empty;
            //    using (frmPlanAnualAdquisicionDetalle frm = new frmPlanAnualAdquisicionDetalle("", numCuenta, planAnualAdquisicionRequerimiento, esModificacion ? planAnualAdquisicionDetalle : null, this.FindForm()))
            //    {
            //        if (frm.ShowDialog() == DialogResult.OK)
            //        {
            //            LlenarGrid();
            //        }
            //    }
            //}

            if (planAnualAdquisicionRequerimiento != null)
            {
                string numCuenta = string.Empty;
                
                var gv = grcProgramacion.MainView as GridView;
                var topRowIndex = gv.TopRowIndex;
                var index = gv.FocusedRowHandle;

                var vistaDet = (ColumnView)grcProgramacion.FocusedView;
                var indexDet = vistaDet.FocusedRowHandle;

                using (frmPlanAnualAdquisicionDetalle frm = new frmPlanAnualAdquisicionDetalle("", numCuenta, planAnualAdquisicionRequerimiento, esModificacion ? planAnualAdquisicionDetalle : null, this.FindForm()))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        LlenarGrid();

                        grvProgramacion.SetMasterRowExpanded(index, true);
                        grvProgramacion.FocusedRowHandle = index;
                        grvProgramacion.TopRowIndex = topRowIndex;
                    }
                }
            }
        }

        protected override void GuardarDatos()
        { 
            //if (programacionAnualPresentador.GuardarDatos())
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
                                planAnualAdquisicionRequerimientoPresentador.IngresarMontoArea(1, num);
                            //}
                        }
                        break;

                    case "febrero":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            //if (num != cambio.febrero)
                            //{
                                planAnualAdquisicionRequerimientoPresentador.IngresarMontoArea(2, num);
                            //}
                        }
                        break;
                    case "marzo":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            //if (num != cambio.marzo)
                            //{
                                planAnualAdquisicionRequerimientoPresentador.IngresarMontoArea(3, num);
                            //}
                        }
                        break;
                    case "abril":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            //if (num != cambio.abril)
                            //{
                                planAnualAdquisicionRequerimientoPresentador.IngresarMontoArea(4, num);
                            //}
                        }
                        break;
                    case "mayo":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            //if (num != cambio.mayo)
                            //{
                                planAnualAdquisicionRequerimientoPresentador.IngresarMontoArea(5, num);
                            //}
                        }
                        break;
                    case "junio":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            //if (num != cambio.junio)
                            //{
                                planAnualAdquisicionRequerimientoPresentador.IngresarMontoArea(6, num);
                            //}
                        }
                        break;
                    case "julio":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            //if (num != cambio.julio)
                            //{
                                planAnualAdquisicionRequerimientoPresentador.IngresarMontoArea(7, num);
                            //}
                        }
                        break;
                    case "agosto":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            //if (num != cambio.agosto)
                            //{
                                planAnualAdquisicionRequerimientoPresentador.IngresarMontoArea(8, num);
                            //}
                        }
                        break;
                    case "setiembre":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            //if (num != cambio.setiembre)
                            //{
                                planAnualAdquisicionRequerimientoPresentador.IngresarMontoArea(9, num);
                            //}
                        }
                        break;
                    case "octubre":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            //if (num != cambio.octubre)
                            //{
                                planAnualAdquisicionRequerimientoPresentador.IngresarMontoArea(10, num);
                            //}
                        }
                        break;
                    case "novimebre":
                        numero = Convert.ToString(e.Value);
                        
                        if (decimal.TryParse(numero, out num))
                        {
                            //if (num != cambio.novimebre)
                            //{
                                planAnualAdquisicionRequerimientoPresentador.IngresarMontoArea(11, num);
                            //}
                        }
                        break;
                    case "diciembre":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            //if (num != cambio.diciembre)
                            //{
                                planAnualAdquisicionRequerimientoPresentador.IngresarMontoArea(12, num);
                            //}
                        }
                        break;
                }
            }
        }

        private void grvProgramacion_MasterRowExpanded(object sender, DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventArgs e)
        {
            //GridView view = sender as GridView;
            //if (view != null)
            //{
            //    GridView detailView = view.GetDetailView(e.RowHandle, e.RelationIndex) as GridView;
            //    if (detailView != null) detailView.ExpandGroupRow(-1);
            //}

            GridView view = sender as GridView;
            if (view != null)
            {
                GridView detailView = view.GetDetailView(e.RowHandle, e.RelationIndex) as GridView;
                if (detailView != null)
                {
                    if (SoloLectura)
                        foreach (GridColumn columna in detailView.Columns)
                        {
                            columna.OptionsColumn.AllowEdit = false;
                        }

                    detailView.ExpandGroupRow(-1);
                }
            }
        }

        private void bgvDetalle_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            ColumnView focusedView = (ColumnView)grcProgramacion.FocusedView;
            var cambio = focusedView.GetRow(e.RowHandle) as PlanAnualAdquisicionDetallePres;

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
                            planAnualAdquisicionRequerimientoPresentador.IngresarMontoDetalle(1, num);
                        }
                        break;

                    case "cantEnero":

                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            planAnualAdquisicionRequerimientoPresentador.IngresarCantidadDetalle(1, 1, cambio.precio, num);
                        }

                        break;

                    case "febrero":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            planAnualAdquisicionRequerimientoPresentador.IngresarMontoDetalle(2, num);
                        }
                        break;

                    case "cantFebrero":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            planAnualAdquisicionRequerimientoPresentador.IngresarCantidadDetalle(2, 1, cambio.precio, num);
                        }
                        break;

                    case "marzo":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            if (num != cambio.marzo)
                            {
                                planAnualAdquisicionRequerimientoPresentador.IngresarMontoDetalle(3, num);
                            }
                        }
                        break;

                    case "cantMarzo":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            planAnualAdquisicionRequerimientoPresentador.IngresarCantidadDetalle(3, 1, cambio.precio, num);
                        }
                        break;

                    case "abril":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            planAnualAdquisicionRequerimientoPresentador.IngresarMontoDetalle(4, num);
                        }
                        break;

                    case "cantAbril":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            planAnualAdquisicionRequerimientoPresentador.IngresarCantidadDetalle(4, 1, cambio.precio, num);
                        }
                        break;

                    case "mayo":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            planAnualAdquisicionRequerimientoPresentador.IngresarMontoDetalle(5, num);
                        }
                        break;

                    case "cantMayo":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            planAnualAdquisicionRequerimientoPresentador.IngresarCantidadDetalle(5, 1, cambio.precio, num);
                        }
                        break;

                    case "junio":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            planAnualAdquisicionRequerimientoPresentador.IngresarMontoDetalle(6, num);
                        }
                        break;

                    case "cantJunio":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            planAnualAdquisicionRequerimientoPresentador.IngresarCantidadDetalle(6, 1, cambio.precio, num);
                        }
                        break;

                    case "julio":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            planAnualAdquisicionRequerimientoPresentador.IngresarMontoDetalle(7, num);
                        }
                        break;

                    case "cantJulio":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            planAnualAdquisicionRequerimientoPresentador.IngresarCantidadDetalle(7, 1, cambio.precio, num);
                        }
                        break;

                    case "agosto":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            planAnualAdquisicionRequerimientoPresentador.IngresarMontoDetalle(8, num);
                        }
                        break;

                    case "cantAgosto":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            planAnualAdquisicionRequerimientoPresentador.IngresarCantidadDetalle(8, 1, cambio.precio, num);
                        }
                        break;

                    case "setiembre":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            planAnualAdquisicionRequerimientoPresentador.IngresarMontoDetalle(9, num);
                        }
                        break;

                    case "cantSetiembre":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            planAnualAdquisicionRequerimientoPresentador.IngresarCantidadDetalle(9, 1, cambio.precio, num);
                        }
                        break;

                    case "octubre":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            planAnualAdquisicionRequerimientoPresentador.IngresarMontoDetalle(10, num);
                        }
                        break;

                    case "cantOctubre":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            planAnualAdquisicionRequerimientoPresentador.IngresarCantidadDetalle(10, 1, cambio.precio, num);
                        }
                        break;

                    case "noviembre":
                        numero = Convert.ToString(e.Value);

                        if (decimal.TryParse(numero, out num))
                        {
                            planAnualAdquisicionRequerimientoPresentador.IngresarMontoDetalle(11, num);
                        }
                        break;

                    case "cantNoviembre":
                        numero = Convert.ToString(e.Value);

                        if (decimal.TryParse(numero, out num))
                        {
                            planAnualAdquisicionRequerimientoPresentador.IngresarCantidadDetalle(11, 1, cambio.precio, num);
                        }
                        break;

                    case "diciembre":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            planAnualAdquisicionRequerimientoPresentador.IngresarMontoArea(12, num);
                        }
                        break;

                    case "cantDiciembre":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            planAnualAdquisicionRequerimientoPresentador.IngresarCantidadDetalle(12, 1, cambio.precio, num);
                        }
                        break;
                }
                //RefrescarGrilla(e.RowHandle);
                //if (grvProgramacion.GetMasterRowExpanded(fila))
                //{
                //    grcProgramacion.MainView.SetMasterRowExpanded(fila, false);
                //    grvProgramacion.SetMasterRowExpanded(fila, true);
                //}
            }
            grvProgramacion.SetMasterRowExpanded(index, true);
            grvProgramacion.FocusedRowHandle = index;

            bgvDetalle.FocusedRowHandle = e.RowHandle;
        }

        private void grcProgramacion_FocusedViewChanged(object sender, DevExpress.XtraGrid.ViewFocusEventArgs e)
        {
            //if (e.View != null && e.View.IsDetailView)
            //{
            //    (e.View.ParentView as GridView).FocusedRowHandle = e.View.SourceRowHandle;
            //    RefrescarGrilla(e.View.SourceRowHandle);
            //    (e.View.ParentView as GridView).FocusedRowHandle = e.View.SourceRowHandle;
            //    (e.View.ParentView as GridView).SetMasterRowExpanded(e.View.SourceRowHandle, true);
            //}
            //else if (e.View != null)
            //{
            //    (e.View as GridView).FocusedRowHandle = e.View.SourceRowHandle;
            //    (e.View as GridView).SetMasterRowExpanded(e.View.SourceRowHandle, true);
            //    RefrescarGrilla(e.View.SourceRowHandle);
            //}

            if (e.View != null && e.View.IsDetailView)
            {
                (e.View.ParentView as GridView).FocusedRowHandle = e.View.SourceRowHandle;
                //RefrescarGrilla(e.View.SourceRowHandle);
                //(e.View.ParentView as GridView).FocusedRowHandle = e.View.SourceRowHandle;
                (e.View.ParentView as GridView).SetMasterRowExpanded(e.View.SourceRowHandle, true);
            }
            else if (e.View != null)
            {
                (e.View as GridView).FocusedRowHandle = e.View.SourceRowHandle;
                (e.View as GridView).SetMasterRowExpanded(e.View.SourceRowHandle, true);
                //RefrescarGrilla(e.View.SourceRowHandle);
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
    }
}
