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
using Utilitario.Util;

namespace SIA_Presupuesto.WebForm.Pac
{
    public partial class ListaGastoRecurrente : System.Web.UI.Page, IListaGasRecVista
    {
        private ListaGasRecPresentador listaGasRecPresentador;
        
        public string nomUsuario { get { return Session["nomUsuario"]!=null ? Session["nomUsuario"].ToString() : string.Empty; } }

        public int idUsuario { get { return Session["idUsuario"] != null ? Convert.ToInt32(Session["idUsuario"].ToString()) : 0; } }

        public List<GastoRecurrente> listaDatosPrincipales
        {
            set
            {
                this.grvGasRec.DataSource = value;
                //this.grvRequerimiento.DataBind();
            }
        }

        public List<Direccion> listaDireccionesReporte
        {
            set
            {
                cbDir.DataSource = value;
                cbDir.DataBind();
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            listaGasRecPresentador = new ListaGasRecPresentador(this);
            listaGasRecPresentador.CargarServicios();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["nomUsuario"] == null)
            {
                Response.Redirect("~/Error.htm");
            }

            if(!IsPostBack)
                listaGasRecPresentador.Iniciar();

            Actualizar();
        }

        public void Actualizar()
        {
            //listaRequerimientoBienServicioPresentador.Iniciar();
            grvGasRec.DataBind();
        }

        protected void btnAgregar_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void cpPrincipal_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            //popRequerimiento.JSProperties["cpNombre"] = "Registro de Requerimiento";

            var args = Util.DeserializeCallbackArgs(e.Parameter);
            if (args.Count == 0)
                return;

            if (args[0] == "Guardar")
            {
                Resultado resultado = listaGasRecPresentador.GuardarDatosRequerimiento(args[2]);
                if (resultado != null)
                {
                    if (resultado.esCorrecto)
                        cpPrincipal.JSProperties["cpMensaje"] = string.Format(resultado.mensajeMostrar," el requerimiento", resultado.id);
                    else
                        cpPrincipal.JSProperties["cpMensaje"] = "Error: " + resultado.mensajeMostrar;
                }
                else
                    cpPrincipal.JSProperties["cpMensaje"] = "A ocurrido un error";
            }
            else if(args[0] == "Anular")
            {

                if (listaGasRecPresentador.AnularRegistro(Convert.ToInt32(args[1])))
                    cpPrincipal.JSProperties["cpMensaje"] = "Anulado correctamente";
                else
                    cpPrincipal.JSProperties["cpMensaje"] = "No se pudo anular";
            }

            cpPrincipal.JSProperties["cpGrid"] = "grvGasRec";
        }

        protected void popRequerimiento_WindowCallback(object source, DevExpress.Web.PopupWindowCallbackArgs e)
        {
            var args = e.Parameter.Split('|');
            int id = 0;
            switch (args[0])
            {
                case "Nuevo":
                    listaGasRecPresentador.IniciarDatosRequerimiento(0);
                    break;
                case "Editar":
                    id = !string.IsNullOrEmpty(args[1]) ? int.Parse(args[1]) : 0;
                    listaGasRecPresentador.IniciarDatosRequerimiento(id);
                    break;
                case "Mostrar":
                    id = !string.IsNullOrEmpty(args[1]) ? int.Parse(args[1]) : 0;
                    listaGasRecPresentador.IniciarDatosRequerimiento(id);
                    break;
            }
           // popRequerimiento.JSProperties["cpID"] = id;
        }

        protected void cbDireccion_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {

        }

        protected void btnDetalle_Click(object sender, EventArgs e)
        {
            //int idGasRec = Convert.ToInt32(grvGasRec.GetRowValues(grvGasRec.FocusedRowIndex, grvGasRec.KeyFieldName)); 
            //Response.Redirect(string.Format("ListaGastoRecurrenteDetalles.aspx?idGasRec={0}", idGasRec));

            var obj = grvGasRec.GetSelectedFieldValues(grvGasRec.KeyFieldName) == null ? null : grvGasRec.GetSelectedFieldValues(grvGasRec.KeyFieldName);
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
                int idGasRec = Convert.ToInt32(obj[0].ToString());
                Response.Redirect(string.Format("ListaGastoRecurrenteDetalles.aspx?idGasRec={0}", idGasRec));
            }
        }

        protected void popReporteDireccion_WindowCallback(object source, DevExpress.Web.CallbackEventArgsBase e)
        {
            listaGasRecPresentador.IniciarReporte(0);
        }

        protected void grvRequerimiento_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            //anioPresentacion = Convert.ToInt32(e.Parameters);
            grvGasRec.DataBind();
        }

        protected void grvRequerimiento_DataBinding(object sender, EventArgs e)
        {
            listaGasRecPresentador.ObtenerDatosListado();
        }
    }
}