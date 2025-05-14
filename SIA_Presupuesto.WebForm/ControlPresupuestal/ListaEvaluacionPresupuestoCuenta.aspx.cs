using DevExpress.Web;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WebForm.Helper;
using SIA_Presupuesto.WebForm.Presentador;
using SIA_Presupuesto.WebForm.Vista;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Utilitario.Util;

namespace SIA_Presupuesto.WebForm.ControlPresupuestal
{
    public partial class ListaEvaluacionPresupuestoCuenta : System.Web.UI.Page, IListaEvaluacionPresupuestoCuentaVista
    {
        private ListaEvaluacionPresupuestoCuentaPresentador listaEvaluacionPresupuestoCuentaPresentador;
        
        public string nomUsuario { get { return Session["nomUsuario"]!=null ? Session["nomUsuario"].ToString() : string.Empty; } }

        public int idUsuario { get { return Session["idUsuario"] != null ? Convert.ToInt32(Session["idUsuario"].ToString()) : 0; } }


        public List<EvaluacionPresupuestoPorCuentasPres> listaDatosPrincipales
        {
            set
            {
                this.grvPresupuestoClase.DataSource = value;
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
        public int anioPresentacion
        {
            set { cbAnio.Value = value.ToString(); }
            get { return cbAnio.Value != null ? Convert.ToInt32(cbAnio.Value.ToString()) : 0; }
        }
        public int idMoneda
        {
            set { cbMoneda.Value = value.ToString(); }
            get { return cbMoneda.Value != null ? Convert.ToInt32(cbMoneda.Value.ToString()) : 63; }
        }

        public int idSubPresupuesto
        {
            //set { hdfValores["idSubPresupuesto"] = value.ToString(); }
            //get { return Convert.ToInt32(hdfValores["idSubPresupuesto"] == null ? 0 : hdfValores["idSubPresupuesto"]); }

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

        List<EvaluacionPresupuestoPorCuentasPres> listaEvaluacion;

        protected void Page_Init(object sender, EventArgs e)
        {
            listaEvaluacionPresupuestoCuentaPresentador = new ListaEvaluacionPresupuestoCuentaPresentador(this);
            listaEvaluacionPresupuestoCuentaPresentador.CargarServicios();
            listaEvaluacion = new List<EvaluacionPresupuestoPorCuentasPres>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["nomUsuario"] == null)
            {
                Response.Redirect("~/Error.htm");
            }

            if (!IsPostBack)
            {
                listaEvaluacionPresupuestoCuentaPresentador.Iniciar();
                Session["listaEvaluacion"] = null;
                Session["idSubPresupuesto"] = "0";
                Session["desPresupuesto"] = "";
                Session["desSubPresupuesto"] = "";
            }

            Actualizar();
        }

        public void Actualizar()
        {
            if (Session["listaEvaluacion"] != null)
                listaEvaluacion = (List<EvaluacionPresupuestoPorCuentasPres>)Session["listaEvaluacion"];
            listaDatosPrincipales = listaEvaluacion;
            grvPresupuestoClase.ExpandAll();
        }

        protected void btnAgregar_Click(object sender, ImageClickEventArgs e)
        {

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
            
            this.Subpresupuesto = listaEvaluacionPresupuestoCuentaPresentador.traerSubPresupuesto(Convert.ToInt32(e.Parameters));
            Session["desSubPresupuesto"] = this.Subpresupuesto.descripcion;
            Session["desPresupuesto"] = this.Subpresupuesto.ProgramacionAnual.descripcion;

            if (Session["listaEvaluacion"] != null)
                listaEvaluacion = (List<EvaluacionPresupuestoPorCuentasPres>)Session["listaEvaluacion"];
            
            listaEvaluacion = listaEvaluacionPresupuestoCuentaPresentador.TraerListaEvaluacionPresupuestoPorCuentasTodo();
            Session["listaEvaluacion"] = listaEvaluacion;

            grvPresupuestoClase.DataBind();
        }
        protected void grvPresupuestoClase_DataBinding(object sender, EventArgs e)
        {
            (sender as ASPxGridView).ForceDataRowType(typeof(EvaluacionPresupuestoPorCuentasPres));
            
            if (Session["listaEvaluacion"] != null)
                listaEvaluacion = (List<EvaluacionPresupuestoPorCuentasPres>)Session["listaEvaluacion"];
            listaDatosPrincipales = listaEvaluacion;
        }
        
        protected void grvReqDet_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            if (!grvPresupuestoClase.IsNewRowEditing)
            {
                grvPresupuestoClase.DoRowValidation();
            }
        }
        protected void grvPresupuestoDivisionaria_DataBinding(object sender, EventArgs e)
        {
            (sender as ASPxGridView).ForceDataRowType(typeof(EvaluacionPresupuestoPorCuentasPres));

            if (Session["listaEvaluacion"] != null)
                listaEvaluacion = (List<EvaluacionPresupuestoPorCuentasPres>)Session["listaEvaluacion"];
            listaDatosPrincipales = listaEvaluacion;
        }
        protected void grvPresupuestoDivisionaria_BeforePerformDataSelect(object sender, EventArgs e)
        {
            ASPxGridView detailGrid = (ASPxGridView)sender;
            vGrvPresupuestoDivisionaria = detailGrid;
            if (detailGrid != null)
            {
                int id = Convert.ToInt32(vGrvPresupuestoDivisionaria.GetMasterRowKeyValue());
                EvaluacionPresupuestoPorCuentasPres result = grvPresupuestoClase.GetRow(grvPresupuestoClase.FindVisibleIndexByKeyValue(id)) as EvaluacionPresupuestoPorCuentasPres;
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
                EvaluacionPresupuestoPorCuentasPres result = vGrvPresupuestoDivisionaria.GetRow(vGrvPresupuestoDivisionaria.FindVisibleIndexByKeyValue(id)) as EvaluacionPresupuestoPorCuentasPres;
                if (result != null)
                    if (result.ListaCuentasEspecificas != null)
                        detailGrid.DataSource = result.ListaCuentasEspecificas;
            }
        }
        protected void grvMovimiento_BeforePerformDataSelect(object sender, EventArgs e)
        {
            ASPxGridView detailGrid = (ASPxGridView)sender;

            if (detailGrid != null)
            {
                int id = Convert.ToInt32(detailGrid.GetMasterRowKeyValue());
                EvaluacionPresupuestoPorCuentasPres result = vGrvPresupuestoCuenta.GetRow(vGrvPresupuestoCuenta.FindVisibleIndexByKeyValue(id)) as EvaluacionPresupuestoPorCuentasPres;
                if (result != null)
                    if (result.ListaDeVouchers != null)
                        detailGrid.DataSource = result.ListaDeVouchers;
            }
        }
        protected void cbPresupuesto_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            int idGruPre = Convert.ToInt32(e.Parameter);
            listaEvaluacionPresupuestoCuentaPresentador.LlenarComboPresupuesto(idGruPre);

            cbSubPresupuesto.Fields.Clear();
        }
        protected void cbSubPresupuesto_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            listaEvaluacionPresupuestoCuentaPresentador.LlenarComboSubPresupuesto(Convert.ToInt32(e.Parameter));
        }
        protected void btnExportarExcel_Click(object sender, EventArgs e)
        {
            listaEvaluacion = (List<EvaluacionPresupuestoPorCuentasPres>)Session["listaEvaluacion"] == null ? new List<EvaluacionPresupuestoPorCuentasPres>() : (List<EvaluacionPresupuestoPorCuentasPres>)Session["listaEvaluacion"];
            if (listaEvaluacion.Count > 0)
            {
                string format = "yyyy-MM-dd_hh.mm.ss.tt";
                string ruta = ExportarEvaluacion(listaEvaluacion, (string)Session["desPresupuesto"], (string)Session["desSubPresupuesto"]);
                if (!string.IsNullOrEmpty(ruta))
                {
                    string nombreArchivo = "EvaluacionPorCuenta_" + DateTime.Now.ToString(format).ToLower() + ".xlsx";
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
        public string ExportarEvaluacion(List<EvaluacionPresupuestoPorCuentasPres> lista, string vpresupuesto, string vsubPresupuesto)
        {
            string ruta = string.Empty;
            if (lista.Count > 0)
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    string format = "yyyy-MM-dd_hh.mm.ss.tt";
                    sfd.Filter = "Excel XLSX|*.xlsx";
                    sfd.Title = "Guardar el siguiente archivo";

                    ruta = Path.GetTempPath() + "EvaluacionPorCuenta_" + DateTime.Now.ToString(format).ToLower() + ".xlsx";

                    ExportarProHelper.ExportarEvaluacionPresupuestoPorCuentas(ruta, lista.OrderBy(o => o.numCuenta).ToList(), idMoneda, vpresupuesto, vsubPresupuesto);
                }
            }

            return ruta;
        }
    }
}