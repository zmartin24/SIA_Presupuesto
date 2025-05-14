using DevExpress.Web;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WebForm.Helper;
using SIA_Presupuesto.WebForm.Presentador;
using SIA_Presupuesto.WebForm.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIA_Presupuesto.WebForm.Programacion
{
    public partial class frmEvaluacionMensualPresupuesto : System.Web.UI.Page, IEvaluacionMensualPresupuestoDetalleVista
    {
        private EvaluacionMensualPresupuestoDetallePresentador evaluacionMensualPresupuestoDetallePresentador;

        public List<EvaluacionMensualAreaPres> listaDatosPrincipales
        {
            set
            {
                this.grvPresupuesto.DataSource = value;
                this.grvPresupuesto.DataBind();
            }
        }

        public string nomUsuario { get { return Session["nomUsuario"] != null ? Session["nomUsuario"].ToString() : string.Empty; } }

        public int idEvaMenPro
        {
            set { hdfValores["id"] = value.ToString(); }
            get { return Convert.ToInt32(hdfValores["id"]); }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            evaluacionMensualPresupuestoDetallePresentador = new EvaluacionMensualPresupuestoDetallePresentador(this);
            evaluacionMensualPresupuestoDetallePresentador.CargarServicios();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["nomUsuario"]==null)
            {
                Response.Redirect("~/Error.htm");
            }

            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Request.Params.Get("id")); 
                hdfValores.Add("id", id);
                //var simbolo = evaluacionMensualPresupuestoDetallePresentador.BuscarSimboloMoneda(Convert.ToInt32(Request.Params.Get("idReq")));
                //grvReqDet.Columns["cantidad"].Caption = string.Format("Total {0}", simbolo);

                EvaluacionMensualProgramacion EvaluacionMensualProgramacion = evaluacionMensualPresupuestoDetallePresentador.Buscar(id);
                hdfValores.Add("mesHasta", EvaluacionMensualProgramacion.mesHasta);
                EvaluarOcultarMeses(grvPresupuesto, EvaluacionMensualProgramacion.mesHasta, 3);
            }
            Actualizar();
        }

        public void Actualizar()
        {
            evaluacionMensualPresupuestoDetallePresentador.Iniciar();
            grvPresupuesto.ExpandAll();
        }

        protected void cpPrincipal_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {

        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("ListaEvaluacionMensualPresupuesto.aspx?id={0}", idEvaMenPro));
        }

        protected void grvReqDet_RowUpdated(object sender, DevExpress.Web.Data.ASPxDataUpdatedEventArgs e)
        {
            
        }

        protected void grvReqDet_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            
        }

        protected void grvReqDet_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {
           
        }

        protected void grvReqDet_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            //if (!grvReqDet.IsNewRowEditing)
            //{
            //    grvReqDet.DoRowValidation();
            //}
        }

        protected void grvDetalle_BeforePerformDataSelect(object sender, EventArgs e)
        {
            ASPxGridView detailGrid = (ASPxGridView)sender;
            if (detailGrid != null)
            {
                int mesHasta = Convert.ToInt32(hdfValores["mesHasta"].ToString());
                EvaluarOcultarMeses(detailGrid, mesHasta, 5);

                //if (tipox.Equals("NN"))
                //{
                    //detailGrid.Columns[1].Columns[0].Visible = false;
                    //detailGrid.Columns[2].Columns[0].Visible = false;
                    //detailGrid.Columns[3].Columns[0].Visible = false;
                    //detailGrid.Columns[4].Columns[0].Visible = false;
                    //detailGrid.Columns[5].Columns[0].Visible = false;
                    //detailGrid.Columns[6].Columns[0].Visible = false;
                    //detailGrid.Columns[7].Columns[0].Visible = false;
                    //detailGrid.Columns[8].Columns[0].Visible = false;
                    //detailGrid.Columns[9].Columns[0].Visible = false;
                    //detailGrid.Columns[10].Columns[0].Visible = false;
                    //detailGrid.Columns[11].Columns[0].Visible = false;
                    //detailGrid.Columns[12].Columns[0].Visible = false;
                //}

                int id = (int)detailGrid.GetMasterRowKeyValue();

                //ASPxGridView.FindVisibleIndexByKeyValue
                
                EvaluacionMensualAreaPres prin = grvPresupuesto.GetRow(grvPresupuesto.FindVisibleIndexByKeyValue(id)) as EvaluacionMensualAreaPres;
                if (prin != null)
                    if (prin.EvaluacionMensualDetallePres != null)
                        detailGrid.DataSource = prin.EvaluacionMensualDetallePres;
            }
        }



        private void EvaluarOcultarMeses(ASPxGridView detailGrid, int mes, int adquisicion)
        {
            if (mes < 2)
            {
                detailGrid.Columns[0 + adquisicion].Visible = false;
            }

            if (mes < 3)
            {
                detailGrid.Columns[1 + adquisicion].Visible = false;
            }

            if (mes < 4)
            {
                detailGrid.Columns[2 + adquisicion].Visible = false;
            }

            if (mes < 5)
            {
                detailGrid.Columns[3 + adquisicion].Visible = false;
            }

            if (mes < 6)
            {
                detailGrid.Columns[4 + adquisicion].Visible = false;
            }

            if (mes < 7)
            {
                detailGrid.Columns[5 + adquisicion].Visible = false;
            }

            if (mes < 8)
            {
                detailGrid.Columns[6 + adquisicion].Visible = false;
            }

            if (mes < 9)
            {
                detailGrid.Columns[7 + adquisicion].Visible = false;
            }

            if (mes < 10)
            {
                detailGrid.Columns[8 + adquisicion].Visible = false;
            }

            if (mes < 11)
            {
                detailGrid.Columns[9 + adquisicion].Visible = false;
            }

            if (mes < 12)
            {
                detailGrid.Columns[10 + adquisicion].Visible = false;
            }

        }
    }
}