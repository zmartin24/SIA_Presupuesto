using DevExpress.Web.Bootstrap;
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

namespace SIA_Presupuesto.WebForm.Pac
{
    public partial class ListaPac : System.Web.UI.Page, IListaPacVista
    {
        private ListaPacPresentador listaPacPresentador;
        
        public string nomUsuario { get { return Session["nomUsuario"]!=null ? Session["nomUsuario"].ToString() : string.Empty; } }

        public int idUsuario { get { return Session["idUsuario"] != null ? Convert.ToInt32(Session["idUsuario"].ToString()) : 0; } }

        public List<PlanAnualAdquisicion> listaDatosPrincipales
        {
            set
            {
                this.grvPac.DataSource = value;
                //this.grvRequerimiento.DataBind();
            }
        }
        public List<Predeterminado> listaReporte
        {
            set
            {
                cbReporte.DataSource = value;
                cbReporte.DataBind();
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
        public List<FuenteFinanciamiento> listaFuenteFinanciamientoReporte
        {
            set
            {
                cbFueFin.DataSource = value;
                cbFueFin.DataBind();
            }
        }

        public string codReporte
        {
            set { cbReporte.Value = value.ToString(); }
            get { return cbReporte.Value.ToString(); }
        }
        public int idDireccion
        {
            set { cbDir.Value = value.ToString(); }
            get { return Convert.ToInt32(cbDir.Value.ToString()); }
        }
        public int idFueFin
        {
            set { cbFueFin.Value = value.ToString(); }
            get { return Convert.ToInt32(cbFueFin.Value.ToString()); }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            listaPacPresentador = new ListaPacPresentador(this);
            listaPacPresentador.CargarServicios();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["nomUsuario"] == null)
            {
                Response.Redirect("~/Error.htm");
            }

            if(!IsPostBack)
                listaPacPresentador.Iniciar();

            Actualizar();
        }
        public void Actualizar()
        {
            //listaRequerimientoBienServicioPresentador.Iniciar();
            grvPac.DataBind();
        }

        protected void cpPrincipal_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            
            var args = Util.DeserializeCallbackArgs(e.Parameter);
            if (args.Count == 0)
                return;

            if (args[0] == "Guardar")
            {
                Resultado resultado = listaPacPresentador.GuardarDatosRequerimiento(args[2]);
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

                if (listaPacPresentador.AnularRegistro(Convert.ToInt32(args[1])))
                    cpPrincipal.JSProperties["cpMensaje"] = "Anulado correctamente";
                else
                    cpPrincipal.JSProperties["cpMensaje"] = "No se pudo anular";
            }

            cpPrincipal.JSProperties["cpGrid"] = "grvPac";
        }

        

        protected void cbDireccion_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {

        }
        protected void cbReporte_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            
        }

        protected void cbSubdireccion_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            listaPacPresentador.LlenarCombosSubdireccion(Convert.ToInt32(e.Parameter));
        }


        protected void cbArea_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            listaPacPresentador.LlenarCombosAreas(Convert.ToInt32(e.Parameter));
        }

        protected void btnDetalle_Click(object sender, EventArgs e)
        {
            //int idPac = Convert.ToInt32(grvPac.GetRowValues(grvPac.FocusedRowIndex + 1, grvPac.KeyFieldName));
            
            var obj = grvPac.GetSelectedFieldValues(grvPac.KeyFieldName) == null ? null : grvPac.GetSelectedFieldValues(grvPac.KeyFieldName);
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
                int idPac = Convert.ToInt32(obj[0].ToString());
                Response.Redirect(string.Format("ListaPacDetalles.aspx?idPac={0}", idPac));
            }

        }
        
        protected void popReporteDireccion_WindowCallback(object source, DevExpress.Web.CallbackEventArgsBase e)
        {
            listaPacPresentador.IniciarReporte(0);
        }

        protected void grvRequerimiento_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            //anioPresentacion = Convert.ToInt32(e.Parameters);
            grvPac.DataBind();
        }

        protected void grvRequerimiento_DataBinding(object sender, EventArgs e)
        {
            listaPacPresentador.ObtenerDatosListado();
        }
        
        protected void btnExportarExcel_Click(object sender, EventArgs e)
        {
            //int id = Convert.ToInt32(grvPac.GetRowValues(grvPac.FocusedRowIndex, grvPac.KeyFieldName));
            var obj = grvPac.GetSelectedFieldValues(grvPac.KeyFieldName) == null ? null : grvPac.GetSelectedFieldValues(grvPac.KeyFieldName);
            int id = Convert.ToInt32(obj[0].ToString());
            
            string ruta = listaPacPresentador.ExportarPac(id);
            if (!string.IsNullOrEmpty(ruta))
            {
                string nombreArchivo = "PlanAnualContrataciones.xlsx";
                FileInfo file = new FileInfo(ruta);
                if (file.Exists)
                {
                    Response.Clear();
                    Response.ClearHeaders();
                    Response.ClearContent();
                    Response.AddHeader("content-disposition", "attachment; filename=" + nombreArchivo);
                    Response.AddHeader("Content-Type", "application/Excel");
                    Response.ContentType = "application/vnd.xls";
                    Response.AddHeader("Content-Length", file.Length.ToString());
                    Response.WriteFile(file.FullName);
                    Response.End();
                }
                else
                {
                    Response.Write("Este archivo no existe.");
                }
            }


            //if (obj == null || obj.Count == 0)
            //{
            //    // Gets the executing web page 
            //    Page page = HttpContext.Current.CurrentHandler as Page;

            //    string script = string.Format("alert('{0}');", "Debe Seleccionar un registro");
            //    if (page != null && !page.ClientScript.IsClientScriptBlockRegistered("alert"))
            //    {
            //        page.ClientScript.RegisterClientScriptBlock(page.GetType(), "alert", script, true /* addScriptTags */);
            //    }
            //}
            //else
            //{
                
            //}
            
        }
    }
}