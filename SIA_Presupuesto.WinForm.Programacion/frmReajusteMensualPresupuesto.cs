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
using DevExpress.XtraEditors;

namespace SIA_Presupuesto.WinForm.Programacion
{
    public partial class frmReajusteMensualPresupuesto : ControlDetalleBase, IReajusteMensualPresupuestoVista
    {
        private ReajusteMensualPresupuestoPresentador programacionAnualPresentador;

        public List<ReajusteMensualAreaPres> listaDatosPrincipales
        {
            set
            {
                grcProgramacion.DataSource = value;
            }
        }

        private ReajusteMensualProgramacion ReajusteMensual;
        private string tipo;
        //object expandedRow;
        public frmReajusteMensualPresupuesto(string tipo, ReajusteMensualProgramacion ReajusteMensualProgramacion)
        {
            InitializeComponent();
            this.tipo = tipo;
            this.ReajusteMensual = ReajusteMensualProgramacion;
            this.programacionAnualPresentador = new ReajusteMensualPresupuestoPresentador(ReajusteMensualProgramacion, this);
            Text = ReajusteMensualProgramacion.descripcion;
            esSoloListado = true;
            riseImpTotal.ReadOnly = true;
        }

        protected override ColumnView ColumnaActual { get { return grcProgramacion.MainView as ColumnView; } }
        protected override DevExpress.XtraGrid.GridControl GridPrincipal { get { return grcProgramacion; } }

        public ReajusteMensualArea ReajusteMensualArea
        {
            get
            {
                if (ColumnaActual == null || ColumnaActual.FocusedRowHandle < 0) return null;
                var pro = ColumnaActual.GetRow(ColumnaActual.FocusedRowHandle) as ReajusteMensualAreaPres;
                return pro != null ? programacionAnualPresentador.BuscarArea((Int32)pro.idReaMenArea) : null;
            }
        }

        //
        protected ColumnView ColumnaActual1 { get { return grcProgramacion.ViewCollection[2] as ColumnView; } }

        public ReajusteMensualDetalle ReajusteMensualDetalle
        {
            get
            {
                if (ColumnaActual1 == null || ColumnaActual1.FocusedRowHandle < 0) return null;
                var pro = ColumnaActual1.GetRow(ColumnaActual1.FocusedRowHandle) as ReajusteMensualDetallePres;
                indiceDetalle = ColumnaActual1.FocusedRowHandle;
                return pro != null ? programacionAnualPresentador.BuscarDetalle((Int32)pro.idReaMenDet) : null;
            }
        }
        int indiceDetalle = 0;
        protected override void InicializarDatos()
        {
            this.programacionAnualPresentador.IniciarDatos();
            if(tipo.Equals("NN"))
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

            EvaluarOcultarMeses(ReajusteMensual.mesReajuste);
        }

        private void EvaluarOcultarMeses(int mes)
        {
            if(mes != 1)
            {
                gcCantEne.Visible = false;
                gcDiasEne.Visible = false;
                gcImpEne.Visible = false;
                gcSubEne.Visible = false;
                gbEnero.Visible = false;
            }

            if (mes != 2)
            {
                gcCantFeb.Visible = false;
                gcDiasFeb.Visible = false;
                gcImpFeb.Visible = false;
                gcSubFeb.Visible = false;
                gbFebrero.Visible = false;
            }

            if (mes != 3)
            {
                gcCantMar.Visible = false;
                gcDiasMar.Visible = false;
                gcImpMar.Visible = false;
                gcSubMar.Visible = false;
                gbMarzo.Visible = false;
            }

            if (mes != 4)
            {
                gcCantAbr.Visible = false;
                gcDiasAbr.Visible = false;
                gcImpAbr.Visible = false;
                gcSubAbr.Visible = false;
                gbAbril.Visible = false;
            }

            if (mes != 5)
            {
                gcCantMay.Visible = false;
                gcDiasMay.Visible = false;
                gcImpMay.Visible = false;
                gcSubMay.Visible = false;
                gbMayo.Visible = false;
            }


            if (mes != 6)
            {
                gcCantJun.Visible = false;
                gcDiasJun.Visible = false;
                gcImpJun.Visible = false;
                gcSubJun.Visible = false;
                gbJunio.Visible = false;
            }

            if (mes != 7)
            {
                gcCantJul.Visible = false;
                gcDiasJul.Visible = false;
                gcImpJul.Visible = false;
                gcSubJul.Visible = false;
                gbJulio.Visible = false;
            }

            if (mes != 8)
            {
                gcCantAgo.Visible = false;
                gcDiasAgo.Visible = false;
                gcImpAgo.Visible = false;
                gcSubAgo.Visible = false;
                gbAgosto.Visible = false;
            }

            if (mes != 9)
            {
                gcCantSet.Visible = false;
                gcDiasSet.Visible = false;
                gcImpSet.Visible = false;
                gcSubSet.Visible = false;
                gbSetiembre.Visible = false;
            }

            if (mes != 10)
            {
                gcCantOct.Visible = false;
                gcDiasOct.Visible = false;
                gcImpOct.Visible = false;
                gcSubOct.Visible = false;
                gbOctubre.Visible = false;
            }

            if (mes != 11)
            {
                gcCantNov.Visible = false;
                gcDiasNov.Visible = false;
                gcImpNov.Visible = false;
                gcSubNov.Visible = false;
                gbNoviembre.Visible = false;
            }

            if (mes != 12)
            {
                gcCantDic.Visible = false;
                gcDiasDic.Visible = false;
                gcImpDic.Visible = false;
                gcSubDic.Visible = false;
                gbDiciembre.Visible = false;
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
            using (frmReajusteMensualArea frm = new frmReajusteMensualArea(this.ReajusteMensual, null, this.FindForm()))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LlenarGrid();
                }
            }
        }

        protected override void Modificar()
        {
            using (frmReajusteMensualArea frm = new frmReajusteMensualArea(this.ReajusteMensual, ReajusteMensualArea, this.FindForm()))
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
            if (ReajusteMensualArea != null)
            {
                var gv = grcProgramacion.MainView as GridView;
                var topRowIndex = gv.TopRowIndex;
                var index = gv.FocusedRowHandle;

                if (programacionAnualPresentador.AnularDetalle())
                    EmitirMensajeResultado(true, "Anulado correctamente");
                else
                    EmitirMensajeResultado(false, "No se puedo anular el detalle");

                grvProgramacion.FocusedRowHandle = index;
                grvProgramacion.SetMasterRowExpanded(index, true);
                grvProgramacion.TopRowIndex = topRowIndex;
            }
        }

        private void AbrirDetalle(bool esModificacion)
        {
            if (ReajusteMensualArea != null)
            {
                var gv = grcProgramacion.MainView as GridView;
                var topRowIndex = gv.TopRowIndex;
                var index = gv.FocusedRowHandle;

                using (frmReajusteMensualDetalle frm = new frmReajusteMensualDetalle(tipo, ReajusteMensualArea, esModificacion ? ReajusteMensualDetalle : null, this.FindForm()))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        LlenarGrid();
                        indiceDetalle = esModificacion ? indiceDetalle : 0;
                        grvProgramacion.FocusedRowHandle = index;
                        grvProgramacion.SetMasterRowExpanded(index, true);
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
            var cambio = grvProgramacion.GetRow(e.RowHandle) as ReajusteMensualAreaPres;
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
                    case "noviembre":
                        numero = Convert.ToString(e.Value);
                        
                        if (decimal.TryParse(numero, out num))
                        {
                            //if (num != cambio.noviembre)
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
                if (detailView != null)
                {
                    //detailView.ExpandGroupRow(-1);
                    detailView.FocusedRowHandle = indiceDetalle;
                }
            }

            //if (expandedRow != null) //Otra forma
            //{
            //    GridView detailView = view.GetDetailView(e.RowHandle, e.RelationIndex) as GridView;
            //    grvProgramacion.FocusedRowHandle = e.RowHandle;
            //    detailView.FocusedRowHandle = indiceDetalle;
            //}
            //expandedRow = e.RowHandle;

            // Set focus on the first row (after the 'click to add new row') of the detail grid  
            grvProgramacion.GetDetailView(e.RowHandle, e.RelationIndex).Focus();
        }

        private void grvDetalle_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            ColumnView focusedView = (ColumnView)grcProgramacion.FocusedView;
            var cambio = focusedView.GetRow(e.RowHandle) as ReajusteMensualDetallePres;

            var gv = grcProgramacion.MainView as GridView;
            var index = gv.FocusedRowHandle;
            indiceDetalle = e.RowHandle;
            
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
                            programacionAnualPresentador.IngresarCantidadDetalle(1, (Int32)cambio.diasEnero>0 ? (Int32)cambio.diasEnero : 1 , cambio.precio, num);
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
                            programacionAnualPresentador.IngresarCantidadDetalle(2, (Int32)cambio.diasFebrero > 0 ? (Int32)cambio.diasFebrero : 1, cambio.precio, num);
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
                            programacionAnualPresentador.IngresarCantidadDetalle(3, (Int32)cambio.diasMarzo > 0 ? (Int32)cambio.diasMarzo : 1, cambio.precio, num);
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
                            programacionAnualPresentador.IngresarCantidadDetalle(4, (Int32)cambio.diasAbril > 0 ? (Int32)cambio.diasAbril : 1, cambio.precio, num);
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
                            programacionAnualPresentador.IngresarCantidadDetalle(5, (Int32)cambio.diasMayo > 0 ? (Int32)cambio.diasMayo : 1, cambio.precio, num);
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
                            programacionAnualPresentador.IngresarCantidadDetalle(6, (Int32)cambio.diasJunio > 0 ? (Int32)cambio.diasJunio : 1, cambio.precio, num);
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
                            programacionAnualPresentador.IngresarCantidadDetalle(7, (Int32)cambio.diasJulio > 0 ? (Int32)cambio.diasJulio : 1,  cambio.precio, num);
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
                            programacionAnualPresentador.IngresarMontoDetalle(8,  num);
                        }
                        break;

                    case "cantAgosto":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            programacionAnualPresentador.IngresarCantidadDetalle(8, (Int32)cambio.diasAgosto> 0 ? (Int32)cambio.diasAgosto : 1,  cambio.precio, num);
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
                            programacionAnualPresentador.IngresarCantidadDetalle(9, (Int32)cambio.diasSetiembre > 0 ? (Int32)cambio.diasSetiembre : 1, cambio.precio, num);
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
                            programacionAnualPresentador.IngresarCantidadDetalle(10, (Int32)cambio.diasOctubre > 0 ? (Int32)cambio.diasOctubre : 1, cambio.precio, num);
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
                            programacionAnualPresentador.IngresarCantidadDetalle(11, (Int32)cambio.diasNoviembre > 0 ? (Int32)cambio.diasNoviembre : 1, cambio.precio, num);
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
                            programacionAnualPresentador.IngresarCantidadDetalle(12, (Int32)cambio.diasDiciembre > 0 ? (Int32)cambio.diasDiciembre : 1,  cambio.precio, num);
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

            grvProgramacion.FocusedRowHandle = index;
            ///grvDetalle.FocusedRowHandle = e.RowHandle;
            grvProgramacion.SetMasterRowExpanded(index, true);
        }

        private void riseImp_Click(object sender, EventArgs e)
        {
            var spinEdit = (SpinEdit)sender;
            spinEdit.SelectAll();
        }
    }
}
