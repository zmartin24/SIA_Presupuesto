using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WebForm.Helper;
using SIA_Presupuesto.WebForm.Presentador;
using SIA_Presupuesto.WebForm.Vista;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Web.UI;
using System.Windows.Forms;
using Utilitario.Util;

namespace SIA_Presupuesto.WebForm.Programacion
{
    public partial class ListaPresupuestoMensual : System.Web.UI.Page, IListaPresupuestoMensualVista
    {
        private ListaPresupuestoMensualPresentador listaPresupuestoMensualPresentador;
        
        public string nomUsuario { get { return Session["nomUsuario"]!=null ? Session["nomUsuario"].ToString() : string.Empty; } }

        public int idUsuario { get { return Session["idUsuario"] != null ? Convert.ToInt32(Session["idUsuario"].ToString()) : 0; } }

        public List<SubPresupuestoPoco> listaDatosPrincipales
        {
            set
            {
                this.grvSubPresupuesto.DataSource = value;
            }
        }

        public int idSubpresupuesto
        {
            get { return hdfValores["idSubPre"].ToString() != null ? Convert.ToInt32(hdfValores["idSubPre"]) : 0; }
        }

        public List<Anio> listaAnios
        {
            set
            {
                cbAnioPreMen.DataSource = value;
                cbAnioPreMen.DataBind();
            }
        }
        
        public int anioPresentacion
        {
            set { cbAnioPreMen.Value = value.ToString(); }
            get { return cbAnioPreMen.Value != null ? Convert.ToInt32(cbAnioPreMen.Value.ToString()) : 0; }
        }

        /*popExportarPreMen*/
        public List<Moneda> listaMoneda
        {
            set
            {
                cbMoneda.DataSource = value;
                cbMoneda.DataBind();
            }
        }
        public string desPresupuesto
        {
            set { lblDesPresupuesto.Text = value.ToString(); }
        }
        public string desSubpresupuesto
        {
            set { lblDesSubpresupuesto.Text = value.ToString(); }
        }
        public int idMoneda
        {
            set { cbMoneda.Value = value.ToString(); }
            get { return cbMoneda.Value != null ? Convert.ToInt32(cbMoneda.Value.ToString()) : 0; }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            listaPresupuestoMensualPresentador = new ListaPresupuestoMensualPresentador(this);
            listaPresupuestoMensualPresentador.CargarServicios();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["nomUsuario"] == null)
            {
                Response.Redirect("~/Error.htm");
            }

            if(!IsPostBack)
                listaPresupuestoMensualPresentador.Iniciar();

            Actualizar();
        }

        public void Actualizar()
        {
            grvSubPresupuesto.DataBind();
        }

        protected void cpPrincipal_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            //var args = Util.DeserializeCallbackArgs(e.Parameter);
            //if (args.Count == 0)
            //    return;

            //cpPrincipal.JSProperties["cpGrid"] = "grvSubPresupuesto";
        }

        protected void grvRequerimiento_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            anioPresentacion = Convert.ToInt32(e.Parameters);
            grvSubPresupuesto.DataBind();
        }

        protected void grvRequerimiento_DataBinding(object sender, EventArgs e)
        {
            listaPresupuestoMensualPresentador.ObtenerDatosListado();
        }

        protected void popPreMenMoneda_WindowCallback(object source, DevExpress.Web.CallbackEventArgsBase e)
        {
            IniciaPopExportarSubpresupuesto();
        }
        
        protected void btnExpPreMen_Click(object sender, EventArgs e)
        {
            List<ReporteSubpresupuestoExportaPres> lista = new List<ReporteSubpresupuestoExportaPres>();

            lista = this.listaPresupuestoMensualPresentador.TraerReporteSubpresupuestoExporta();

            if (lista.Count > 0)
            {
                string ruta = ExportarSubpresupuesto(lista);
                if (!string.IsNullOrEmpty(ruta))
                {
                    string format = "yyyy-MM-dd_hh.mm.ss.tt";
                    string nombreArchivo = "Subpresupuesto_" + DateTime.Now.ToString(format, CultureInfo.InvariantCulture).ToLower() + ".xlsx";
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
                else
                {
                    string javaScript = "MostrarMensaje(){alert('Hola');};";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
                }
            }
            
            IniciaPopExportarSubpresupuesto();
        }

        private void IniciaPopExportarSubpresupuesto()
        {
            popPreMenMoneda.HeaderText = "Exportar Presupuesto Mensual";
            this.listaPresupuestoMensualPresentador.IniciarExportaPresupuestoMensual(idSubpresupuesto);
            this.grvSubPresupuesto.DataBind();
        }

        private string ExportarSubpresupuesto(List<ReporteSubpresupuestoExportaPres> lista)
        {
            string ruta = string.Empty;
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                string format = "yyyy-MM-dd_hh.mm.ss.tt";
                sfd.Filter = "Excel XLSX|*.xlsx";
                sfd.Title = "Guardar el siguiente archivo";

                ruta = Path.GetTempPath() + "Subpresupuesto_" + DateTime.Now.ToString(format, CultureInfo.InvariantCulture).ToLower() + ".xlsx";

                ExportarProHelper.ExportarSubpresupuesto(ruta, lista);
            }

            return ruta;
        }
    }
}