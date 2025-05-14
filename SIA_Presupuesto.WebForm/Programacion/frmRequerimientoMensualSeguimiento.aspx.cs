using DevExpress.CodeParser;
using DevExpress.Web;
using DevExpress.Web.Bootstrap;
using DevExpress.Web.Data;
using DevExpress.Web.Internal.XmlProcessor;
using DevExpress.XtraEditors.Popup;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WebForm.Helper;
using SIA_Presupuesto.WebForm.Presentador;
using SIA_Presupuesto.WebForm.Vista;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Data;
using Utilitario.Util;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Globalization;
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;
using DevExpress.Utils;
using DevExpress.Web.ASPxPivotGrid;
using DevExpress.XtraPrinting;
using DevExpress.Web.ASPxTreeList;

namespace SIA_Presupuesto.WebForm.Programacion
{
    public partial class frmRequerimientoMensualSeguimiento : System.Web.UI.Page, IRequerimientoMensualSeguimientoVista
    {
        private RequerimientoMensualSeguimientoPresentador requerimientoMensualSeguimientoPresentador;
        
        public string nomUsuario { get { return Session["nomUsuario"] != null ? Session["nomUsuario"].ToString() : string.Empty; } }
        public List<ReporteRequerimientoMensualSeguimientoPres> listaDatosPrincipales
        {
            set
            {
                this.grvPivot.DataSource = value;
            }
        }
        public List<ReporteRequerimientoMensualSeguimientoDetallePres> listaPresupuestoEvaluacionCuenta
        {
            set
            {
                this.grvPresupuestoClase.DataSource = value;
            }
        }
        public List<ReporteRequerimientoMensualSeguimientoForebiseCabecera> listaForebiseCabecera
        {
            set
            {
                this.grvForebise.DataSource = value;
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
        public List<Mes> listaMeses
        {
            set
            {
                cbMes.DataSource = value;
                cbMes.DataBind();
            }
        }

        public int idReqMenBieSer
        {
            set { hdfValores["idReq"] = value.ToString(); }
            get { return Convert.ToInt32(hdfValores["idReq"]); }
        }
        public string desPrespupuesto
        {
            set { txtDesPresupuesto.Text = value.ToString(); }
        }
        public int tipo
        {
            set { Session["tipo"] = value.ToString(); }
            get { return Convert.ToInt32(Session["tipo"]); }
        }
        public int idProAnu
        {
            set { hdfValores["idProAnu"] = value.ToString(); }
            get { return Convert.ToInt32(hdfValores["idProAnu"]); }
        }
        public int idMoneda
        {
            ////set { hdfValores["idMoneda"] = value.ToString(); }
            ////get { return Convert.ToInt32(hdfValores["idMoneda"]); }

            //set { Session["idMoneda"] = value; }
            //get { return Convert.ToInt32(Session["idMoneda"].ToString()); }

            set
            {
                cbMoneda.Value = value.ToString();
                //Session["idMoneda"] = value;
            }
            get { return Convert.ToInt32(cbMoneda.Value.ToString()); }
        }
        public int idMes
        {
            set { cbMes.Value = value.ToString(); }
            get { return cbMes.Value != null ? Convert.ToInt32(cbMes.Value.ToString()) : 0; }
        }
        /// <summary>
        /// Listas
        /// </summary>
        List<ReporteRequerimientoMensualSeguimientoPres> listaGridPivot;
        List<ReporteRequerimientoMensualSeguimientoDetallePres> listaEvaluacion;
        List<ReporteRequerimientoMensualSeguimientoForebiseCabecera> listaForebi;

        public ASPxGridView vGrvPresupuestoDivisionaria;
        public ASPxGridView vGrvPresupuestoCuenta;

        protected void Page_Init(object sender, EventArgs e)
        {
            this.requerimientoMensualSeguimientoPresentador = new RequerimientoMensualSeguimientoPresentador(this);
            this.requerimientoMensualSeguimientoPresentador.CargarServicios();

            listaGridPivot = new List<ReporteRequerimientoMensualSeguimientoPres>();
            listaEvaluacion = new List<ReporteRequerimientoMensualSeguimientoDetallePres>();
            listaForebi = new List<ReporteRequerimientoMensualSeguimientoForebiseCabecera>();
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["nomUsuario"]==null)
            {
                Response.Redirect("~/Error.htm");
            }

            if (!IsPostBack)
            {
                hdfValores.Add("idReq", Request.Params.Get("idReq"));
                this.requerimientoMensualSeguimientoPresentador.IniciarDatos(Convert.ToInt32(Request.Params.Get("idReq")));
                Session["listaPivot"] = null;
                Session["listaEvaluacion"] = null;
                Session["listaForebi"] = null;
            }
            Actualizar();
        }

        public void Actualizar()
        {
            if (Session["idMoneda"] == null) Session["idMoneda"] = idMoneda;
            // modificando the Current Culture
            //Thread.CurrentThread.CurrentCulture = Session["idMoneda"] == null ? new CultureInfo("es-PE") : Convert.ToInt32(Session["idMoneda"].ToString()) == 63 ? new CultureInfo("es-PE") : new CultureInfo("en-US");
            
            if (Session["listaPivot"] != null)
                listaGridPivot = (List<ReporteRequerimientoMensualSeguimientoPres>)Session["listaPivot"];
            else
            {
                listaGridPivot = this.requerimientoMensualSeguimientoPresentador.TraerReporteRequerimientoMensualSeguimiento();
                Session["listaPivot"] = listaGridPivot;
            }

            if (Session["listaEvaluacion"] != null)
                listaEvaluacion = (List<ReporteRequerimientoMensualSeguimientoDetallePres>)Session["listaEvaluacion"];
            else
            {
                listaEvaluacion = this.requerimientoMensualSeguimientoPresentador.TraerReporteRequerimientoMensualSeguimientoDetalle();
                Session["listaEvaluacion"] = listaEvaluacion;
            }

            if (Session["listaForebi"] != null)
                listaForebi = (List<ReporteRequerimientoMensualSeguimientoForebiseCabecera>)Session["listaForebi"];
            else
            {
                listaForebi = this.requerimientoMensualSeguimientoPresentador.TraerReporteRequerimientoMensualSeguimientoForebiseCabecera();
                Session["listaForebi"] = listaForebi;
            }

            listaDatosPrincipales = listaGridPivot;
            listaPresupuestoEvaluacionCuenta = listaEvaluacion;
            listaForebiseCabecera = listaForebi;

            grvPivot.ExpandAll();
            grvPresupuestoClase.ExpandAll();
            grvForebise.ExpandAll();
        }

        protected void cpPrincipal_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
        }
        protected void cbMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["idMoneda"] = idMoneda;
            llenarGrillas();
        }
        protected void btnExportarExcel_Click(object sender, EventArgs e)
        {
            // Exports using the Data-Aware type. 
            ASPxPivotGridExporter1.ExportXlsxToResponse("Requerimiento_Presupuesto", new XlsxExportOptionsEx
            {
                AllowFixedColumns = DefaultBoolean.False,
                SheetName = "Requerimiento Presupuesto"
            },
            true);
        }
        protected void grvPresupuestoClase_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            if (Session["listaEvaluacion"] != null)
                listaEvaluacion = (List<ReporteRequerimientoMensualSeguimientoDetallePres>)Session["listaEvaluacion"];

            listaEvaluacion = this.requerimientoMensualSeguimientoPresentador.TraerReporteRequerimientoMensualSeguimientoDetalle();
            Session["listaEvaluacion"] = listaEvaluacion;

            grvPresupuestoClase.DataBind();
        }
        protected void grvPresupuestoClase_DataBinding(object sender, EventArgs e)
        {
            (sender as ASPxGridView).ForceDataRowType(typeof(ReporteRequerimientoMensualSeguimientoDetallePres));

            if (Session["listaEvaluacion"] != null)
                listaEvaluacion = (List<ReporteRequerimientoMensualSeguimientoDetallePres>)Session["listaEvaluacion"];
            listaPresupuestoEvaluacionCuenta = listaEvaluacion;
        }
        protected void grvPresupuestoClase_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            if (!grvPresupuestoClase.IsNewRowEditing)
            {
                grvPresupuestoClase.DoRowValidation();
            }
        }
        protected void grvPresupuestoDivisionaria_DataBinding(object sender, EventArgs e)
        {
            (sender as ASPxGridView).ForceDataRowType(typeof(ReporteRequerimientoMensualSeguimientoDetallePres));

            if (Session["listaEvaluacion"] != null)
                listaEvaluacion = (List<ReporteRequerimientoMensualSeguimientoDetallePres>)Session["listaEvaluacion"];
            listaPresupuestoEvaluacionCuenta = listaEvaluacion;
        }
        protected void grvPresupuestoDivisionaria_BeforePerformDataSelect(object sender, EventArgs e)
        {
            ASPxGridView detailGrid = (ASPxGridView)sender;
            vGrvPresupuestoDivisionaria = detailGrid;
            if (detailGrid != null)
            {
                int id = Convert.ToInt32(vGrvPresupuestoDivisionaria.GetMasterRowKeyValue());
                ReporteRequerimientoMensualSeguimientoDetallePres result = grvPresupuestoClase.GetRow(grvPresupuestoClase.FindVisibleIndexByKeyValue(id)) as ReporteRequerimientoMensualSeguimientoDetallePres;
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
                ReporteRequerimientoMensualSeguimientoDetallePres result = vGrvPresupuestoDivisionaria.GetRow(vGrvPresupuestoDivisionaria.FindVisibleIndexByKeyValue(id)) as ReporteRequerimientoMensualSeguimientoDetallePres;
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
                ReporteRequerimientoMensualSeguimientoDetallePres result = vGrvPresupuestoCuenta.GetRow(vGrvPresupuestoCuenta.FindVisibleIndexByKeyValue(id)) as ReporteRequerimientoMensualSeguimientoDetallePres;
                if (result != null)
                    if (result.listaDetalleMovimiento != null)
                        detailGrid.DataSource = result.listaDetalleMovimiento;
            }
        }

        protected void grvForebise_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            if (Session["listaForebi"] != null)
                listaForebi = (List<ReporteRequerimientoMensualSeguimientoForebiseCabecera>)Session["listaForebi"];

            listaForebi = this.requerimientoMensualSeguimientoPresentador.TraerReporteRequerimientoMensualSeguimientoForebiseCabecera();
            Session["listaForebi"] = listaForebi;

            grvForebise.DataBind();
        }
        protected void grvForebise_DataBinding(object sender, EventArgs e)
        {
            (sender as ASPxGridView).ForceDataRowType(typeof(ReporteRequerimientoMensualSeguimientoForebiseCabecera));

            if (Session["listaForebi"] != null)
                listaForebi = (List<ReporteRequerimientoMensualSeguimientoForebiseCabecera>)Session["listaForebi"];
            listaForebiseCabecera = listaForebi;
        }
        protected void grvForebise_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            if (!grvForebise.IsNewRowEditing)
            {
                grvForebise.DoRowValidation();
            }
        }
      
        protected void grvForebiseDetalle_BeforePerformDataSelect(object sender, EventArgs e)
        {
            ASPxGridView detailGrid = (ASPxGridView)sender;
            vGrvPresupuestoDivisionaria = detailGrid;
            if (detailGrid != null)
            {
                int id = Convert.ToInt32(vGrvPresupuestoDivisionaria.GetMasterRowKeyValue());
                ReporteRequerimientoMensualSeguimientoForebiseCabecera result = grvForebise.GetRow(grvForebise.FindVisibleIndexByKeyValue(id)) as ReporteRequerimientoMensualSeguimientoForebiseCabecera;
                if (result != null)
                    if (result.ListaDetalles != null)
                        detailGrid.DataSource = result.ListaDetalles;
            }
        }

        protected void llenarGrillas()
        {
            Session["listaPivot"] = null;
            Session["listaEvaluacion"] = null;
            Session["listaForebi"] = null;

            listaGridPivot = this.requerimientoMensualSeguimientoPresentador.TraerReporteRequerimientoMensualSeguimiento();
            listaEvaluacion = this.requerimientoMensualSeguimientoPresentador.TraerReporteRequerimientoMensualSeguimientoDetalle();
            listaForebi = this.requerimientoMensualSeguimientoPresentador.TraerReporteRequerimientoMensualSeguimientoForebiseCabecera();
            
            Session["listaPivot"] = listaGridPivot;
            Session["listaEvaluacion"] = listaEvaluacion;
            Session["listaForebi"] = listaForebi;

            listaDatosPrincipales = listaGridPivot;
            listaPresupuestoEvaluacionCuenta = listaEvaluacion;
            listaForebiseCabecera = listaForebi;

            grvPivot.DataBind();
            grvPresupuestoClase.DataBind();
            grvForebise.DataBind();
        }
    }
}