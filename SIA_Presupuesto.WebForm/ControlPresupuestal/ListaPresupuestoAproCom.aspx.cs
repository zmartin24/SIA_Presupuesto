using DevExpress.CodeParser;
using DevExpress.Web;
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
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitario.Util;

namespace SIA_Presupuesto.WebForm.ControlPresupuestal
{
    public partial class ListaPresupuestoAproCom : System.Web.UI.Page, IListaPresupuestoAproComVista
    {
        private ListaPresupuestoAproComPresentador listaPresupuestoAproComPresentador;
        
        public string nomUsuario { get { return Session["nomUsuario"]!=null ? Session["nomUsuario"].ToString() : string.Empty; } }

        public int idUsuario { get { return Session["idUsuario"] != null ? Convert.ToInt32(Session["idUsuario"].ToString()) : 0; } }


        public List<ReportePresupuestoAprobadoComprometidoEjecutadoPres> listaDatosPrincipales
        {
            set
            {
                this.grvPresupuestoClase.DataSource = value;
            }
        }
        public List<Moneda> listaMonedas
        {
            set
            {
                cbMoneda.DataSource = value;
                cbMoneda.DataBind();
            }
        }

        public List<GrupoPresupuesto> listaGrupoPresupuesto
        {
            set
            {
                cbGruPre.DataSource = value;
                cbGruPre.DataBind();
            }
        }
        public List<Presupuesto> listaPresupuesto
        {
            set
            {
                cbPresupuesto.DataSource = value;
                cbPresupuesto.DataBind();
            }
        }
        public List<Subpresupuesto> listaSubPresupuesto
        {
            set
            {
                cbSubPresupuesto.DataSource = value;
                cbSubPresupuesto.DataBind();
            }
        }
        public int idMoneda
        {
            set { cbMoneda.Value = value.ToString(); }
            get { return cbMoneda.Value != null ? Convert.ToInt32(cbMoneda.Value.ToString()) : 63; }
        }

        public int idSubPresupuesto
        {
            set { Session["idSubPresupuesto"] = value.ToString(); }
            get { return Convert.ToInt32(Session["idSubPresupuesto"]); }
        }

        private GrupoPresupuesto grupoPresupuesto;
        private Presupuesto presupuesto;
        private Subpresupuesto subpresupuesto;

        public GrupoPresupuesto GrupoPresupuesto
        {
            get { return grupoPresupuesto; }
            set
            {
                grupoPresupuesto = value;
                if (value != null)
                {
                    cbGruPre.Text = value.descripcion;
                }
                else
                {
                    cbGruPre.Text = string.Empty;
                }
            }
        }
        public Presupuesto Presupuesto
        {
            get { return presupuesto; }
            set
            {
                presupuesto = value;
                if (value != null)
                {
                    cbPresupuesto.Text = value.descripcion;
                }
                else
                {
                    cbPresupuesto.Text = string.Empty;
                }

            }
        }
        public Subpresupuesto Subpresupuesto
        {
            get { return subpresupuesto; }
            set
            {
                subpresupuesto = value;
                if (value != null)
                {
                    cbSubPresupuesto.Text = value.descripcion;

                }
                else
                {
                    cbSubPresupuesto.Text = string.Empty;

                }
            }
        }

        public ASPxGridView vGrvPresupuestoDivisionaria;
        public ASPxGridView vGrvPresupuestoCuenta;

        List<ReportePresupuestoAprobadoComprometidoEjecutadoPres> listaPresupuestoAprobado;

        protected void Page_Init(object sender, EventArgs e)
        {
            listaPresupuestoAproComPresentador = new ListaPresupuestoAproComPresentador(this);
            listaPresupuestoAproComPresentador.CargarServicios();
            listaPresupuestoAprobado = new List<ReportePresupuestoAprobadoComprometidoEjecutadoPres>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["nomUsuario"] == null)
            {
                Response.Redirect("~/Error.htm");
            }

            if (!IsPostBack)
            {
                listaPresupuestoAproComPresentador.Iniciar();
                Session["listaPresupuestoAprobado"] = null;
                Session["idSubPresupuesto"] = "0";
                Session["desPresupuesto"] = "";
                Session["desSubPresupuesto"] = "";
            }

            Actualizar();
        }

        public void Actualizar()
        {
            if (Session["listaPresupuestoAprobado"] != null)
                listaPresupuestoAprobado = (List<ReportePresupuestoAprobadoComprometidoEjecutadoPres>)Session["listaPresupuestoAprobado"];
            listaDatosPrincipales = listaPresupuestoAprobado;
            grvPresupuestoClase.ExpandAll();
        }

        protected void cpPrincipal_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            var args = Util.DeserializeCallbackArgs(e.Parameter);
            if (args.Count == 0)
                return;

            cpPrincipal.JSProperties["cpGrid"] = "grvPresupuestoClase";
        }

        protected void grvPresupuestoClase_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            Session["idSubPresupuesto"] = e.Parameters.ToString();
            
            this.Subpresupuesto = listaPresupuestoAproComPresentador.traerSubPresupuesto(Convert.ToInt32(e.Parameters));
            Session["desSubPresupuesto"] = this.Subpresupuesto.descripcion;
            Session["desPresupuesto"] = this.Subpresupuesto.ProgramacionAnual.descripcion;

            if (Session["listaPresupuestoAprobado"] != null)
                listaPresupuestoAprobado = (List<ReportePresupuestoAprobadoComprometidoEjecutadoPres>)Session["listaPresupuestoAprobado"];

            listaPresupuestoAprobado = listaPresupuestoAproComPresentador.TraerReportePresupuestoAprobadoComprometidoEjecutado();
            Session["listaPresupuestoAprobado"] = listaPresupuestoAprobado;

            grvPresupuestoClase.DataBind();
        }

        protected void grvPresupuestoClase_DataBinding(object sender, EventArgs e)
        {
            (sender as ASPxGridView).ForceDataRowType(typeof(ReportePresupuestoAprobadoComprometidoEjecutadoPres));
            if (Session["listaPresupuestoAprobado"] != null)
                listaPresupuestoAprobado = (List<ReportePresupuestoAprobadoComprometidoEjecutadoPres>)Session["listaPresupuestoAprobado"];
            listaDatosPrincipales = listaPresupuestoAprobado;
        }
        protected void grvPresupuestoDivisionaria_DataBinding(object sender, EventArgs e)
        {
            (sender as ASPxGridView).ForceDataRowType(typeof(ReportePresupuestoAprobadoComprometidoEjecutadoPres));
            if (Session["listaPresupuestoAprobado"] != null)
                listaPresupuestoAprobado = (List<ReportePresupuestoAprobadoComprometidoEjecutadoPres>)Session["listaPresupuestoAprobado"];
            listaDatosPrincipales = listaPresupuestoAprobado;
        }
        protected void grvPresupuestoDivisionaria_BeforePerformDataSelect(object sender, EventArgs e)
        {
            ASPxGridView detailGrid = (ASPxGridView)sender;
            vGrvPresupuestoDivisionaria = detailGrid;
            if (detailGrid != null)
            {
                int id = Convert.ToInt32(vGrvPresupuestoDivisionaria.GetMasterRowKeyValue());
                ReportePresupuestoAprobadoComprometidoEjecutadoPres result = grvPresupuestoClase.GetRow(grvPresupuestoClase.FindVisibleIndexByKeyValue(id)) as ReportePresupuestoAprobadoComprometidoEjecutadoPres;
                if (result != null)
                    if (result.ListaDivisionarias != null)
                        detailGrid.DataSource = result.ListaDivisionarias;
            }
        }
        protected void grvPresupuestoCuenta_BeforePerformDataSelect(object sender, EventArgs e)
        {
            ASPxGridView detailGrid = (ASPxGridView)sender;
            vGrvPresupuestoCuenta = detailGrid;
            if (detailGrid != null)
            {
                int id = Convert.ToInt32(vGrvPresupuestoCuenta.GetMasterRowKeyValue());
                ReportePresupuestoAprobadoComprometidoEjecutadoPres result = vGrvPresupuestoDivisionaria.GetRow(vGrvPresupuestoDivisionaria.FindVisibleIndexByKeyValue(id)) as ReportePresupuestoAprobadoComprometidoEjecutadoPres;
                if (result != null)
                    if (result.ListaCuentasEspecificas != null)
                        detailGrid.DataSource = result.ListaCuentasEspecificas;
            }
        }
        protected void cbPresupuesto_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            int idGruPre = Convert.ToInt32(e.Parameter);
            listaPresupuestoAproComPresentador.LlenarComboPresupuesto(idGruPre);

            cbSubPresupuesto.Fields.Clear();
        }
        protected void cbSubPresupuesto_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            listaPresupuestoAproComPresentador.LlenarComboSubPresupuesto(Convert.ToInt32(e.Parameter));
        }
        protected void btnExportarExcel_Click(object sender, EventArgs e)
        {
            listaPresupuestoAprobado = (List<ReportePresupuestoAprobadoComprometidoEjecutadoPres>)Session["listaPresupuestoAprobado"] == null ? new List<ReportePresupuestoAprobadoComprometidoEjecutadoPres>() : (List<ReportePresupuestoAprobadoComprometidoEjecutadoPres>)Session["listaPresupuestoAprobado"];
            if (listaPresupuestoAprobado.Count > 0)
            {
                string format = "yyyy-MM-dd_hh.mm.ss.tt";
                string ruta = listaPresupuestoAproComPresentador.ExportarPresupuestoAprobadoComprometidoEjecutado(listaPresupuestoAprobado, (string)Session["desPresupuesto"], (string)Session["desSubPresupuesto"]);
                if (!string.IsNullOrEmpty(ruta))
                {
                    string nombreArchivo = "PresupuestoAprobadoComprometidoEjecutado_" + DateTime.Now.ToString(format).ToLower() + ".xlsx";
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
            }
            else
            {
                Response.Write("Lista vacía...");
            }
        }
    }
}