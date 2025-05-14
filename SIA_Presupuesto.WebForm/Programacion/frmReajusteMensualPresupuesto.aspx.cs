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
    public partial class frmReajusteMensualPresupuesto : System.Web.UI.Page, IReajusteMensualPresupuestoDetalleVista
    {
        private ReajusteMensualPresupuestoDetallePresentador evaluacionMensualPresupuestoDetallePresentador;

        public List<ReajusteMensualAreaPres> listaDatosPrincipales
        {
            set
            {
                this.grvPresupuesto.DataSource = value;
                this.grvPresupuesto.DataBind();
            }
        }

        public string nomUsuario { get { return Session["nomUsuario"] != null ? Session["nomUsuario"].ToString() : string.Empty; } }

        public int idReaMenArea
        {
            set { hdfValores["idReaMenArea"] = value.ToString(); }
            get { return Convert.ToInt32(hdfValores["idReaMenArea"]); }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            evaluacionMensualPresupuestoDetallePresentador = new ReajusteMensualPresupuestoDetallePresentador(this);
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
                hdfValores.Add("idReaMenArea", Request.Params.Get("id"));

                //int id = Convert.ToInt32(Request.Params.Get("id")); 
                //hdfValores.Add("id", id);

                //var simbolo = evaluacionMensualPresupuestoDetallePresentador.BuscarSimboloMoneda(Convert.ToInt32(Request.Params.Get("idReq")));
                //grvReqDet.Columns["cantidad"].Caption = string.Format("Total {0}", simbolo);

                ReajusteMensualProgramacion ReajusteMensualProgramacion = evaluacionMensualPresupuestoDetallePresentador.Buscar(idReaMenArea);
                hdfValores.Add("mesReajuste", ReajusteMensualProgramacion.mesReajuste);
                EvaluarOcultarMeses(grvPresupuesto, ReajusteMensualProgramacion.mesReajuste, 7);
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
            cpPrincipal.JSProperties["cpGrid"] = "grvPresupuesto";
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("ListaReajusteMensualPresupuesto.aspx?id={0}", idReaMenArea));
        }

        protected void grvDetalle_BeforePerformDataSelect(object sender, EventArgs e)
        {
            ASPxGridView detailGrid = (ASPxGridView)sender;
            if (detailGrid != null)
            {
                int mesReajuste = Convert.ToInt32(hdfValores["mesReajuste"].ToString());
                EvaluarOcultarMeses(detailGrid, mesReajuste, 4);
                
                int id = (int)detailGrid.GetMasterRowKeyValue();

                ReajusteMensualAreaPres prin = grvPresupuesto.GetRow(grvPresupuesto.FindVisibleIndexByKeyValue(id)) as ReajusteMensualAreaPres;
                if (prin != null)
                    if (prin.ReajusteMensualDetallePres != null)
                        detailGrid.DataSource = prin.ReajusteMensualDetallePres;
            }
        }

        private void EvaluarOcultarMeses(ASPxGridView detailGrid, int mes, int adquisicion)
        {
            if (mes > 1)
            {
                detailGrid.Columns[0 + adquisicion].Visible = false;
            }

            if (mes > 2)
            {
                detailGrid.Columns[1 + adquisicion].Visible = false;
            }

            if (mes > 3)
            {
                detailGrid.Columns[2 + adquisicion].Visible = false;
            }

            if (mes > 4)
            {
                detailGrid.Columns[3 + adquisicion].Visible = false;
            }

            if (mes > 5)
            {
                detailGrid.Columns[4 + adquisicion].Visible = false;
            }

            if (mes > 6)
            {
                detailGrid.Columns[5 + adquisicion].Visible = false;
            }

            if (mes > 7)
            {
                detailGrid.Columns[6 + adquisicion].Visible = false;
            }

            if (mes > 8)
            {
                detailGrid.Columns[7 + adquisicion].Visible = false;
            }

            if (mes > 9)
            {
                detailGrid.Columns[8 + adquisicion].Visible = false;
            }

            if (mes > 10)
            {
                detailGrid.Columns[9 + adquisicion].Visible = false;
            }

            if (mes > 11)
            {
                detailGrid.Columns[10 + adquisicion].Visible = false;
            }

        }
    }
}