using DevExpress.Web;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WebForm.Presentador;
using SIA_Presupuesto.WebForm.Vista;
using System;
using System.Collections.Generic;

namespace SIA_Presupuesto.WebForm.ControlPresupuestal
{
    public partial class ListaCertificacionDetalles : System.Web.UI.Page, IListaCertificacionDetalleVista
    {
        private ListaCertificacionDetallePresentador listaCertificacionDetallePresentador;
        public List<CertificacionRequerimientoPres> listaDatosPrincipales
        {
            set
            {
                this.grvCertificacionDetalle.DataSource = value;
                this.grvCertificacionDetalle.DataBind();
            }
        }
        public ASPxGridView vGrvCertificacionDetalleDetail;
        
        public string nomUsuario { get { return Session["nomUsuario"] != null ? Session["nomUsuario"].ToString() : string.Empty; } }

        public int idCerMas
        {
            set { hdfValores["idCerMas"] = value.ToString(); }
            get { return Convert.ToInt32(hdfValores["idCerMas"]); }
        }

       
        protected void Page_Init(object sender, EventArgs e)
        {
            listaCertificacionDetallePresentador = new ListaCertificacionDetallePresentador(this);
            listaCertificacionDetallePresentador.CargarServicios();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["nomUsuario"]==null)
            {
                Response.Redirect("~/Error.htm");
            }

            if (!IsPostBack)
            {
                hdfValores.Add("idCerMas", Request.Params.Get("idCerMas"));
            }
            Actualizar();
        }

        public void Actualizar()
        {
            listaCertificacionDetallePresentador.Iniciar();
            grvCertificacionDetalle.ExpandAll();
        }

        protected void cpPrincipal_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            cpPrincipal.JSProperties["cpGrid"] = "grvCertificacionDetalle";
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("ListaCertificacionMaster.aspx", idCerMas));
        }

        void AddError(Dictionary<GridViewColumn, string> errors, GridViewColumn column, string errorText)
        {
            if (errors.ContainsKey(column)) return;
            errors[column] = errorText;
        }

        protected void grvCertificacionDetalleDetail_BeforePerformDataSelect(object sender, EventArgs e)
        {
            ASPxGridView detailGrid = (ASPxGridView)sender;
            vGrvCertificacionDetalleDetail = detailGrid;
            if (detailGrid != null)
            {
                int id = Convert.ToInt32(vGrvCertificacionDetalleDetail.GetMasterRowKeyValue());
                CertificacionRequerimientoPres result = grvCertificacionDetalle.GetRow(grvCertificacionDetalle.FindVisibleIndexByKeyValue(id)) as CertificacionRequerimientoPres;
                if (result != null)
                    if (result.CertificacionDetallePres != null)
                        detailGrid.DataSource = result.CertificacionDetallePres;
            }
        }
    }
}