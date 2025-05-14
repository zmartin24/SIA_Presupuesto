using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SIA_Presupuesto.WinForm.General.Base;
using SIA_Presupuesto.WinForm.Programacion.Vista;
using SIA_Presupuesto.WinForm.Programacion.Presentador;
using SIA_Presupuesto.WinForm.Programacion.Dialogo;
using SIA_Presupuesto.Negocio.Entidades;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace SIA_Presupuesto.WinForm.Programacion
{
    public partial class frmEvaluacionMensualPresupuesto : ControlDetalleBase, IEvaluacionMensualPresupuestoVista
    {
        private EvaluacionMensualProgramacionPresentador evaluacionMensualProgramacionPresentador;

        public List<EvaluacionMensualAreaPres> listaDatosPrincipales
        {
            set
            {
                grcProgramacion.DataSource = value;
            }
        }

        private EvaluacionMensualProgramacion EvaluacionMensual;
        private string tipo;
        public frmEvaluacionMensualPresupuesto(string tipo, EvaluacionMensualProgramacion EvaluacionMensualProgramacion)
        {
            InitializeComponent();
            this.tipo = tipo;
            this.EvaluacionMensual = EvaluacionMensualProgramacion;
            this.evaluacionMensualProgramacionPresentador = new EvaluacionMensualProgramacionPresentador(EvaluacionMensualProgramacion, this);
            Text = EvaluacionMensualProgramacion.descripcion;
            esSoloListado = true;
            riseImpTotal.ReadOnly = true;
        }

        protected override ColumnView ColumnaActual { get { return grcProgramacion.MainView as ColumnView; } }
        protected override DevExpress.XtraGrid.GridControl GridPrincipal { get { return grcProgramacion; } }

        public EvaluacionMensualArea EvaluacionMensualArea
        {
            get
            {
                if (ColumnaActual == null || ColumnaActual.FocusedRowHandle < 0) return null;
                var pro = ColumnaActual.GetRow(ColumnaActual.FocusedRowHandle) as EvaluacionMensualAreaPres;
                return pro != null ? evaluacionMensualProgramacionPresentador.BuscarArea((Int32)pro.idEvaMenArea) : null;
            }
        }

        //
        protected ColumnView ColumnaActual1 { get { return grcProgramacion.ViewCollection[2] as ColumnView; } }

        public EvaluacionMensualDetalle EvaluacionMensualDetalle
        {
            get
            {
                if (ColumnaActual1 == null || ColumnaActual1.FocusedRowHandle < 0) return null;
                var pro = ColumnaActual1.GetRow(ColumnaActual1.FocusedRowHandle) as EvaluacionMensualDetallePres;
                return pro != null ? evaluacionMensualProgramacionPresentador.BuscarDetalle((Int32)pro.idEvaMenProDet) : null;
            }
        }
        int indiceDetalle = 0;
        protected override void InicializarDatos()
        {
            this.evaluacionMensualProgramacionPresentador.IniciarDatos();
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

            EvaluarOcultarMeses(EvaluacionMensual.mesHasta);
        }

        private void EvaluarOcultarMeses(int mes)
        {
            gcCantEne.AppearanceCell.BackColor = Color.LemonChiffon;
            gcDiasEne.AppearanceCell.BackColor = Color.LemonChiffon;
            gcImpEne.AppearanceCell.BackColor = Color.LemonChiffon;
            gcSubEne.AppearanceCell.BackColor = Color.LemonChiffon;

            if (mes < 2)
            {
                gcCantFeb.Visible = false;
                gcDiasFeb.Visible = false;
                gcImpFeb.Visible = false;
                gcSubFeb.Visible = false;
                gbFebrero.Visible = false;
            }

            if (mes < 3)
            {
                gcCantMar.Visible = false;
                gcDiasMar.Visible = false;
                gcImpMar.Visible = false;
                gcSubMar.Visible = false;
                gbMarzo.Visible = false;
            }

            if (mes < 4)
            {
                gcCantAbr.Visible = false;
                gcDiasAbr.Visible = false;
                gcImpAbr.Visible = false;
                gcSubAbr.Visible = false;
                gbAbril.Visible = false;
            }

            if (mes < 5)
            {
                gcCantMay.Visible = false;
                gcDiasMay.Visible = false;
                gcImpMay.Visible = false;
                gcSubMay.Visible = false;
                gbMayo.Visible = false;
            }


            if (mes < 6)
            {
                gcCantJun.Visible = false;
                gcDiasJun.Visible = false;
                gcImpJun.Visible = false;
                gcSubJun.Visible = false;
                gbJunio.Visible = false;
            }

            if (mes < 7)
            {
                gcCantJul.Visible = false;
                gcDiasJul.Visible = false;
                gcImpJul.Visible = false;
                gcSubJul.Visible = false;
                gbJulio.Visible = false;
            }

            if (mes < 8)
            {
                gcCantAgo.Visible = false;
                gcDiasAgo.Visible = false;
                gcImpAgo.Visible = false;
                gcSubAgo.Visible = false;
                gbAgosto.Visible = false;
            }

            if (mes < 9)
            {
                gcCantSet.Visible = false;
                gcDiasSet.Visible = false;
                gcImpSet.Visible = false;
                gcSubSet.Visible = false;
                gbSetiembre.Visible = false;
            }

            if (mes < 10)
            {
                gcCantOct.Visible = false;
                gcDiasOct.Visible = false;
                gcImpOct.Visible = false;
                gcSubOct.Visible = false;
                gbOctubre.Visible = false;
            }

            if (mes < 11)
            {
                gcCantNov.Visible = false;
                gcDiasNov.Visible = false;
                gcImpNov.Visible = false;
                gcSubNov.Visible = false;
                gbNoviembre.Visible = false;
            }

            if (mes < 12)
            {
                gcCantDic.Visible = false;
                gcDiasDic.Visible = false;
                gcImpDic.Visible = false;
                gcSubDic.Visible = false;
                gbDiciembre.Visible = false;
            }

            gcCantFeb.AppearanceCell.BackColor = mes == 2 ? Color.PeachPuff : Color.LemonChiffon;
            gcDiasFeb.AppearanceCell.BackColor = mes == 2 ? Color.PeachPuff : Color.LemonChiffon;
            gcImpFeb.AppearanceCell.BackColor = mes == 2 ? Color.PeachPuff : Color.LemonChiffon;
            gcSubFeb.AppearanceCell.BackColor = mes == 2 ? Color.PeachPuff : Color.LemonChiffon;

            gcCantMar.AppearanceCell.BackColor = mes == 3 ? Color.PeachPuff : Color.LemonChiffon;
            gcDiasMar.AppearanceCell.BackColor = mes == 3 ? Color.PeachPuff : Color.LemonChiffon;
            gcImpMar.AppearanceCell.BackColor = mes == 3 ? Color.PeachPuff : Color.LemonChiffon;
            gcSubMar.AppearanceCell.BackColor = mes == 3 ? Color.PeachPuff : Color.LemonChiffon;

            gcCantAbr.AppearanceCell.BackColor = mes == 4 ? Color.PeachPuff : Color.LemonChiffon;
            gcDiasAbr.AppearanceCell.BackColor = mes == 4 ? Color.PeachPuff : Color.LemonChiffon;
            gcImpAbr.AppearanceCell.BackColor = mes == 4 ? Color.PeachPuff : Color.LemonChiffon;
            gcSubAbr.AppearanceCell.BackColor = mes == 4 ? Color.PeachPuff : Color.LemonChiffon;

            gcCantMay.AppearanceCell.BackColor = mes == 5 ? Color.PeachPuff : Color.LemonChiffon;
            gcDiasMay.AppearanceCell.BackColor = mes == 5 ? Color.PeachPuff : Color.LemonChiffon;
            gcImpMay.AppearanceCell.BackColor = mes == 5 ? Color.PeachPuff : Color.LemonChiffon;
            gcSubMay.AppearanceCell.BackColor = mes == 5 ? Color.PeachPuff : Color.LemonChiffon;

            gcCantJun.AppearanceCell.BackColor = mes == 6 ? Color.PeachPuff : Color.LemonChiffon;
            gcDiasJun.AppearanceCell.BackColor = mes == 6 ? Color.PeachPuff : Color.LemonChiffon;
            gcImpJun.AppearanceCell.BackColor = mes == 6 ? Color.PeachPuff : Color.LemonChiffon;
            gcSubJun.AppearanceCell.BackColor = mes == 6 ? Color.PeachPuff : Color.LemonChiffon;

            gcCantJul.AppearanceCell.BackColor = mes == 7 ? Color.PeachPuff : Color.LemonChiffon;
            gcDiasJul.AppearanceCell.BackColor = mes == 7 ? Color.PeachPuff : Color.LemonChiffon;
            gcImpJul.AppearanceCell.BackColor = mes == 7 ? Color.PeachPuff : Color.LemonChiffon;
            gcSubJul.AppearanceCell.BackColor = mes == 7 ? Color.PeachPuff : Color.LemonChiffon;

            gcCantAgo.AppearanceCell.BackColor = mes == 8 ? Color.PeachPuff : Color.LemonChiffon;
            gcDiasAgo.AppearanceCell.BackColor = mes == 8 ? Color.PeachPuff : Color.LemonChiffon;
            gcImpAgo.AppearanceCell.BackColor = mes == 8 ? Color.PeachPuff : Color.LemonChiffon;
            gcSubAgo.AppearanceCell.BackColor = mes == 8 ? Color.PeachPuff : Color.LemonChiffon;

            gcCantSet.AppearanceCell.BackColor = mes == 9 ? Color.PeachPuff : Color.LemonChiffon;
            gcDiasSet.AppearanceCell.BackColor = mes == 9 ? Color.PeachPuff : Color.LemonChiffon;
            gcImpSet.AppearanceCell.BackColor = mes == 9 ? Color.PeachPuff : Color.LemonChiffon;
            gcSubSet.AppearanceCell.BackColor = mes == 9 ? Color.PeachPuff : Color.LemonChiffon;

            gcCantOct.AppearanceCell.BackColor = mes == 10 ? Color.PeachPuff : Color.LemonChiffon;
            gcDiasOct.AppearanceCell.BackColor = mes == 10 ? Color.PeachPuff : Color.LemonChiffon;
            gcImpOct.AppearanceCell.BackColor = mes == 10 ? Color.PeachPuff : Color.LemonChiffon;
            gcSubOct.AppearanceCell.BackColor = mes == 10 ? Color.PeachPuff : Color.LemonChiffon;

            gcCantNov.AppearanceCell.BackColor = mes == 11 ? Color.PeachPuff : Color.LemonChiffon;
            gcDiasNov.AppearanceCell.BackColor = mes == 11 ? Color.PeachPuff : Color.LemonChiffon;
            gcImpNov.AppearanceCell.BackColor = mes == 11 ? Color.PeachPuff : Color.LemonChiffon;
            gcSubNov.AppearanceCell.BackColor = mes == 11 ? Color.PeachPuff : Color.LemonChiffon;

            gcCantDic.AppearanceCell.BackColor = mes == 12 ? Color.PeachPuff : Color.LemonChiffon;
            gcDiasDic.AppearanceCell.BackColor = mes == 12 ? Color.PeachPuff : Color.LemonChiffon;
            gcImpDic.AppearanceCell.BackColor = mes == 12 ? Color.PeachPuff : Color.LemonChiffon;
            gcSubDic.AppearanceCell.BackColor = mes == 12 ? Color.PeachPuff : Color.LemonChiffon;
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
            evaluacionMensualProgramacionPresentador.ObtenerDatosListado();
        }

        protected override void Nuevo()
        {
            using (frmEvaluacionMensualArea frm = new frmEvaluacionMensualArea(this.EvaluacionMensual, null, this.FindForm()))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LlenarGrid();
                }
            }
        }

        protected override void Modificar()
        {
            using (frmEvaluacionMensualArea frm = new frmEvaluacionMensualArea(this.EvaluacionMensual, EvaluacionMensualArea, this.FindForm()))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LlenarGrid();
                }
            }
        }

        protected override void Anular()
        {
            if (evaluacionMensualProgramacionPresentador.AnularArea())
                EmitirMensajeResultado(true, "Anulado correctamente");
            else
                EmitirMensajeResultado(false, "No se puedo anular");
        }

        protected void AnularDetalle()
        {
            if (EvaluacionMensualArea != null)
            {
                //var gv = grcProgramacion.MainView as GridView;
                //var index = gv.FocusedRowHandle;

                var gv = grcProgramacion.MainView as GridView;
                var topRowIndex = gv.TopRowIndex;
                var index = gv.FocusedRowHandle;

                if (evaluacionMensualProgramacionPresentador.AnularDetalle())
                {
                    EmitirMensajeResultado(true, "Anulado correctamente");
                    //grvProgramacion.SetMasterRowExpanded(index, true);
                    //grvProgramacion.FocusedRowHandle = index;

                    grvProgramacion.FocusedRowHandle = index;
                    grvProgramacion.SetMasterRowExpanded(index, true);
                    grvProgramacion.TopRowIndex = topRowIndex;
                    grvDetalle.FocusedRowHandle = indiceDetalle;

                }
                else
                    EmitirMensajeResultado(false, "No se puedo anular el detalle");
            }
        }

        private void AbrirDetalle(bool esModificacion)
        {
            if (EvaluacionMensualArea != null)
            {
                var gv = grcProgramacion.MainView as GridView;
                var topRowIndex = gv.TopRowIndex;
                var index = gv.FocusedRowHandle;

                //var gv = grcProgramacion.MainView as GridView;
                //var index = gv.FocusedRowHandle;

                using (frmEvaluacionMensualDetalle frm = new frmEvaluacionMensualDetalle(tipo, EvaluacionMensualArea, esModificacion ? EvaluacionMensualDetalle : null, this.FindForm()))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        LlenarGrid();

                        grvProgramacion.FocusedRowHandle = index;
                        grvProgramacion.SetMasterRowExpanded(index, true);
                        grvProgramacion.TopRowIndex = topRowIndex;
                        grvDetalle.FocusedRowHandle = indiceDetalle;
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
            var cambio = grvProgramacion.GetRow(e.RowHandle) as EvaluacionMensualAreaPres;
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
                            evaluacionMensualProgramacionPresentador.IngresarMontoArea(1, num);
                        }
                        break;

                    case "febrero":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            evaluacionMensualProgramacionPresentador.IngresarMontoArea(2, num);
                        }
                        break;
                    case "marzo":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            evaluacionMensualProgramacionPresentador.IngresarMontoArea(3, num);
                        }
                        break;
                    case "abril":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            evaluacionMensualProgramacionPresentador.IngresarMontoArea(4, num);
                        }
                        break;
                    case "mayo":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            evaluacionMensualProgramacionPresentador.IngresarMontoArea(5, num);
                        }
                        break;
                    case "junio":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            evaluacionMensualProgramacionPresentador.IngresarMontoArea(6, num);
                        }
                        break;
                    case "julio":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            evaluacionMensualProgramacionPresentador.IngresarMontoArea(7, num);
                        }
                        break;
                    case "agosto":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            evaluacionMensualProgramacionPresentador.IngresarMontoArea(8, num);
                        }
                        break;
                    case "setiembre":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            evaluacionMensualProgramacionPresentador.IngresarMontoArea(9, num);
                        }
                        break;
                    case "octubre":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            evaluacionMensualProgramacionPresentador.IngresarMontoArea(10, num);
                        }
                        break;
                    case "noviembre":
                        numero = Convert.ToString(e.Value);
                        
                        if (decimal.TryParse(numero, out num))
                        {
                            evaluacionMensualProgramacionPresentador.IngresarMontoArea(11, num);
                        }
                        break;
                    case "diciembre":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            evaluacionMensualProgramacionPresentador.IngresarMontoArea(12, num);
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
        
        private void grvDetalle_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            ColumnView focusedView = (ColumnView)grcProgramacion.FocusedView;
            var cambio = focusedView.GetRow(e.RowHandle) as EvaluacionMensualDetallePres;

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
                            evaluacionMensualProgramacionPresentador.IngresarMontoDetalle(1, num);
                        }
                        break;

                    case "cantEnero":

                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            evaluacionMensualProgramacionPresentador.IngresarCantidadDetalle(1, (Int32)cambio.diasEnero>0 ? (Int32)cambio.diasEnero : 1 , cambio.precio, num);
                        }

                        break;

                    case "diasEnero":

                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            evaluacionMensualProgramacionPresentador.IngresarCantidadDetalle(1, (Int32)num, cambio.precio, (decimal)cambio.cantEnero);
                        }

                        break;

                    case "febrero":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            evaluacionMensualProgramacionPresentador.IngresarMontoDetalle(2, num);
                        }
                        break;

                    case "cantFebrero":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            evaluacionMensualProgramacionPresentador.IngresarCantidadDetalle(2, (Int32)cambio.diasFebrero > 0 ? (Int32)cambio.diasFebrero : 1, cambio.precio, num);
                        }
                        break;

                    case "diasFebrero":

                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            evaluacionMensualProgramacionPresentador.IngresarCantidadDetalle(1, (Int32)num, cambio.precio, (decimal)cambio.cantFebrero);
                        }

                        break;

                    case "marzo":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            evaluacionMensualProgramacionPresentador.IngresarMontoDetalle(3, num);
                        }
                        break;

                    case "cantMarzo":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            evaluacionMensualProgramacionPresentador.IngresarCantidadDetalle(3, (Int32)cambio.diasMarzo > 0 ? (Int32)cambio.diasMarzo : 1, cambio.precio, num);
                        }
                        break;

                    case "diasMarzo":

                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            evaluacionMensualProgramacionPresentador.IngresarCantidadDetalle(1, (Int32)num, cambio.precio, (decimal)cambio.cantMarzo);
                        }

                        break;

                    case "abril":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            evaluacionMensualProgramacionPresentador.IngresarMontoDetalle(4, num);
                        }
                        break;

                    case "cantAbril":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            evaluacionMensualProgramacionPresentador.IngresarCantidadDetalle(4, (Int32)cambio.diasAbril > 0 ? (Int32)cambio.diasAbril : 1, cambio.precio, num);
                        }
                        break;

                    case "diasAbril":

                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            evaluacionMensualProgramacionPresentador.IngresarCantidadDetalle(1, (Int32)num, cambio.precio, (decimal)cambio.cantAbril);
                        }

                        break;

                    case "mayo":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            evaluacionMensualProgramacionPresentador.IngresarMontoDetalle(5, num);
                        }
                        break;

                    case "cantMayo":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            evaluacionMensualProgramacionPresentador.IngresarCantidadDetalle(5, (Int32)cambio.diasMayo > 0 ? (Int32)cambio.diasMayo : 1, cambio.precio, num);
                        }
                        break;

                    case "diasMayo":

                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            evaluacionMensualProgramacionPresentador.IngresarCantidadDetalle(1, (Int32)num, cambio.precio, (decimal)cambio.cantMayo);
                        }

                        break;

                    case "junio":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            evaluacionMensualProgramacionPresentador.IngresarMontoDetalle(6, num);
                        }
                        break;

                    case "cantJunio":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            evaluacionMensualProgramacionPresentador.IngresarCantidadDetalle(6, (Int32)cambio.diasJunio > 0 ? (Int32)cambio.diasJunio : 1, cambio.precio, num);
                        }
                        break;

                    case "diasJunio":

                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            evaluacionMensualProgramacionPresentador.IngresarCantidadDetalle(1, (Int32)num, cambio.precio, (decimal)cambio.cantJunio);
                        }

                        break;

                    case "julio":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            evaluacionMensualProgramacionPresentador.IngresarMontoDetalle(7, num);
                        }
                        break;

                    case "cantJulio":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            evaluacionMensualProgramacionPresentador.IngresarCantidadDetalle(7, (Int32)cambio.diasJulio > 0 ? (Int32)cambio.diasJulio : 1,  cambio.precio, num);
                        }
                        break;

                    case "diasJulio":

                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            evaluacionMensualProgramacionPresentador.IngresarCantidadDetalle(1, (Int32)num, cambio.precio, (decimal)cambio.cantJulio);
                        }

                        break;

                    case "agosto":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            evaluacionMensualProgramacionPresentador.IngresarMontoDetalle(8,  num);
                        }
                        break;

                    case "cantAgosto":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            evaluacionMensualProgramacionPresentador.IngresarCantidadDetalle(8, (Int32)cambio.diasAgosto> 0 ? (Int32)cambio.diasAgosto : 1,  cambio.precio, num);
                        }
                        break;

                    case "diasAgosto":

                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            evaluacionMensualProgramacionPresentador.IngresarCantidadDetalle(1, (Int32)num, cambio.precio, (decimal)cambio.cantAgosto);
                        }

                        break;

                    case "setiembre":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            evaluacionMensualProgramacionPresentador.IngresarMontoDetalle(9, num);
                        }
                        break;

                    case "cantSetiembre":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            evaluacionMensualProgramacionPresentador.IngresarCantidadDetalle(9, (Int32)cambio.diasSetiembre > 0 ? (Int32)cambio.diasSetiembre : 1, cambio.precio, num);
                        }
                        break;

                    case "diasSetiembre":

                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            evaluacionMensualProgramacionPresentador.IngresarCantidadDetalle(1, (Int32)num, cambio.precio, (decimal)cambio.cantSetiembre);
                        }

                        break;


                    case "octubre":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            evaluacionMensualProgramacionPresentador.IngresarMontoDetalle(10, num);
                        }
                        break;

                    case "cantOctubre":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            evaluacionMensualProgramacionPresentador.IngresarCantidadDetalle(10, (Int32)cambio.diasOctubre > 0 ? (Int32)cambio.diasOctubre : 1, cambio.precio, num);
                        }
                        break;

                    case "diasOctubre":

                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            evaluacionMensualProgramacionPresentador.IngresarCantidadDetalle(1, (Int32)num, cambio.precio, (decimal)cambio.cantOctubre);
                        }

                        break;

                    case "noviembre":
                        numero = Convert.ToString(e.Value);

                        if (decimal.TryParse(numero, out num))
                        {
                            evaluacionMensualProgramacionPresentador.IngresarMontoDetalle(11, num);
                        }
                        break;

                    case "cantNoviembre":
                        numero = Convert.ToString(e.Value);

                        if (decimal.TryParse(numero, out num))
                        {
                            evaluacionMensualProgramacionPresentador.IngresarCantidadDetalle(11, (Int32)cambio.diasNoviembre > 0 ? (Int32)cambio.diasNoviembre : 1, cambio.precio, num);
                        }
                        break;

                    case "diasNoviembre":

                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            evaluacionMensualProgramacionPresentador.IngresarCantidadDetalle(1, (Int32)num, cambio.precio, (decimal)cambio.cantNoviembre);
                        }

                        break;

                    case "diciembre":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            evaluacionMensualProgramacionPresentador.IngresarMontoArea(12, num);
                        }
                        break;

                    case "cantDiciembre":
                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            evaluacionMensualProgramacionPresentador.IngresarCantidadDetalle(12, (Int32)cambio.diasDiciembre > 0 ? (Int32)cambio.diasDiciembre : 1,  cambio.precio, num);
                        }
                        break;

                    case "diasDiciembre":

                        numero = Convert.ToString(e.Value);
                        if (decimal.TryParse(numero, out num))
                        {
                            evaluacionMensualProgramacionPresentador.IngresarCantidadDetalle(1, (Int32)num, cambio.precio, (decimal)cambio.cantDiciembre);
                        }

                        break;
                }
            }

            grvProgramacion.SetMasterRowExpanded(index, true);
            grvProgramacion.FocusedRowHandle = index;

            grvDetalle.FocusedRowHandle = e.RowHandle;
        }

        private void riseImp_Click(object sender, EventArgs e)
        {
            var spinEdit = (SpinEdit)sender;
            spinEdit.SelectAll();
        }
    }
}
