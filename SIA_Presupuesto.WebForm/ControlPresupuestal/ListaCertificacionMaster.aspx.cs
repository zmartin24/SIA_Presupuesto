using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WebForm.Helper;
using SIA_Presupuesto.WebForm.Presentador;
using SIA_Presupuesto.WebForm.Vista;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitario.Util;

namespace SIA_Presupuesto.WebForm.ControlPresupuestal
{
    public partial class ListaCertificacionMaster : System.Web.UI.Page, IListaCertificacionPresupuestalVista
    {
        private ListaCertificacionPresupuestalPresentador listaCertificacionPresupuestalPresentador;

        public int idUsuario { get { return Session["idUsuario"] != null ? Convert.ToInt32(Session["idUsuario"].ToString()) : 0; } }
        public string nomUsuario { get { return Session["nomUsuario"] != null ? Session["nomUsuario"].ToString() : string.Empty; } }

        public List<CertificacionMasterPres> listaDatosPrincipales
        {
            set
            {
                this.grvCertificacion.DataSource = value;
            }
        }
        public List<Anio> listaAnios
        {
            set
            {
                cbAnio.DataSource = value;
                cbAnio.DataBind();
            }
        }
        public int anioPresentacion
        {
            set { cbAnio.Value = value.ToString(); }
            get { return cbAnio.Value != null ? Convert.ToInt32(cbAnio.Value.ToString()) : 0; }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            listaCertificacionPresupuestalPresentador = new ListaCertificacionPresupuestalPresentador(this);
            listaCertificacionPresupuestalPresentador.CargarServicios();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["nomUsuario"] == null)
            {
                Response.Redirect("~/Error.htm");
            }

            if (!IsPostBack)
                listaCertificacionPresupuestalPresentador.Iniciar();

            Actualizar();
        }

        public void Actualizar()
        {
            grvCertificacion.DataBind();
        }


        protected void cpPrincipal_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            var args = Util.DeserializeCallbackArgs(e.Parameter);
            if (args.Count == 0)
                return;

            if (args[0] == "Guardar")
            {
                Resultado resultado = listaCertificacionPresupuestalPresentador.GuardarDatosRequerimiento(args[2]);
                if (resultado != null)
                {
                    if (resultado.esCorrecto)
                        cpPrincipal.JSProperties["cpMensaje"] = string.Format(resultado.mensajeMostrar, " el requerimiento", resultado.id);
                    else
                        cpPrincipal.JSProperties["cpMensaje"] = "Error: " + resultado.mensajeMostrar;
                }
                else
                    cpPrincipal.JSProperties["cpMensaje"] = "A ocurrido un error";
            }
            else if (args[0] == "Anular")
            {

                //if (listaCertificacionPresupuestalPresentador.AnularRegistro(Convert.ToInt32(args[1])))
                //    cpPrincipal.JSProperties["cpMensaje"] = "Anulado correctamente";
                //else
                //    cpPrincipal.JSProperties["cpMensaje"] = "No se pudo anular";
            }

            cpPrincipal.JSProperties["cpGrid"] = "grvCertificacion";
        }
        protected void popRequerimiento_WindowCallback(object source, DevExpress.Web.PopupWindowCallbackArgs e)
        {
            var args = e.Parameter.Split('|');
            int id = 0;
            switch (args[0])
            {
                case "Nuevo":
                    listaCertificacionPresupuestalPresentador.IniciarDatosRequerimiento(0);
                    break;
                case "Editar":
                    id = !string.IsNullOrEmpty(args[1]) ? int.Parse(args[1]) : 0;
                    listaCertificacionPresupuestalPresentador.IniciarDatosRequerimiento(id);
                    break;
                case "Mostrar":
                    id = !string.IsNullOrEmpty(args[1]) ? int.Parse(args[1]) : 0;
                    listaCertificacionPresupuestalPresentador.IniciarDatosRequerimiento(id);
                    break;
            }
            // popRequerimiento.JSProperties["cpID"] = id;
        }
        protected void btnDetalle_Click(object sender, EventArgs e)
        {
            string nom = grvCertificacion.KeyFieldName == null ? string.Empty : grvCertificacion.KeyFieldName;
            var obj = grvCertificacion.GetSelectedFieldValues(nom) == null ? null : grvCertificacion.GetSelectedFieldValues(grvCertificacion.KeyFieldName);
            if (obj == null || obj.Count == 0)
            {
                // Gets the executing web page 
                Page page = HttpContext.Current.CurrentHandler as Page;

                string script = string.Format("alert('{0}');", "Debe Seleccionar un registro");
                if (page != null && !page.ClientScript.IsClientScriptBlockRegistered("alert"))
                {
                    page.ClientScript.RegisterClientScriptBlock(page.GetType(), "alert", script, true /* addScriptTags */);
                }
            }
            else
            {
                int idCerReq = Convert.ToInt32(obj[0].ToString());//Convert.ToInt32(grvCertificacion.GetSelectedFieldValues(grvCertificacion.KeyFieldName)[0].ToString());
                Response.Redirect(string.Format("ListaCertificacionDetalles.aspx?idCerMas={0}", idCerReq));
            }

        }

        protected void grvRequerimiento_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            anioPresentacion = Convert.ToInt32(e.Parameters);
            grvCertificacion.DataBind();
        }

        protected void grvRequerimiento_DataBinding(object sender, EventArgs e)
        {
            listaCertificacionPresupuestalPresentador.ObtenerDatosListado();
        }
    }
}