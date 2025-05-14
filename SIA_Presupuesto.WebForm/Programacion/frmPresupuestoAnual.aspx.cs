using DevExpress.Web;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WebForm.Presentador;
using SIA_Presupuesto.WebForm.Vista;
using System;
using System.Collections.Generic;

namespace SIA_Presupuesto.WebForm.Programacion
{
    public partial class frmPresupuestoAnual : System.Web.UI.Page, IPresupuestoAnualDetalleVista
    {
        private PresupuestoAnualDetallePresentador presupuestoAnualDetallePresentador;

        public List<ProgramacionAnualAreaPres> listaDatosPrincipales
        {
            set
            {
                this.grvPresupuesto.DataSource = value;
                this.grvPresupuesto.DataBind();
            }
        }

        public string nomUsuario { get { return Session["nomUsuario"] != null ? Session["nomUsuario"].ToString() : string.Empty; } }

        public int idPreAnu
        {
            set { hdfValores["id"] = value.ToString(); }
            get { return Convert.ToInt32(hdfValores["id"]); }
        }
        public string desPresupuesto
        {
            set { lblDescripcion.Text = value.ToString(); }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            presupuestoAnualDetallePresentador = new PresupuestoAnualDetallePresentador(this);
            presupuestoAnualDetallePresentador.CargarServicios();
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
                //var simbolo = presupuestoAnualDetallePresentador.BuscarSimboloMoneda(Convert.ToInt32(Request.Params.Get("idReq")));
                //grvReqDet.Columns["cantidad"].Caption = string.Format("Total {0}", simbolo);
                ProgramacionAnual ProgramacionAnual = presupuestoAnualDetallePresentador.Buscar(id);
                desPresupuesto = ProgramacionAnual.descripcion;
                hdfValores.Add("tipox", ProgramacionAnual != null ? ProgramacionAnual.tipo : "0");

            }
            Actualizar();
        }

        public void Actualizar()
        {
            presupuestoAnualDetallePresentador.Iniciar();
            grvPresupuesto.ExpandAll();
        }

        protected void cpPrincipal_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("ListaPresupuestoAnual.aspx?id={0}", idPreAnu));
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
        }

        protected void grvDetalle_BeforePerformDataSelect(object sender, EventArgs e)
        {
            ASPxGridView detailGrid = (ASPxGridView)sender;
            if (detailGrid != null)
            {
                int id = (int)detailGrid.GetMasterRowKeyValue();

                ProgramacionAnualAreaPres prin = grvPresupuesto.GetRow(grvPresupuesto.FindVisibleIndexByKeyValue(id)) as ProgramacionAnualAreaPres;
                if (prin != null)
                    if (prin.ProgramacionAnualDetallePres != null)
                        detailGrid.DataSource = prin.ProgramacionAnualDetallePres;
            }
        }
    }
}