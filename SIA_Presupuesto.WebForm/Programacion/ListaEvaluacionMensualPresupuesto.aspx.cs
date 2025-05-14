using DevExpress.Web;
using SIA_Presupuesto.Negocio.Entidades;
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
    public partial class ListaEvaluacionMensualPresupuesto : System.Web.UI.Page, IListaEvaluacionMensualPresupuestoVista
    {
        private ListaEvaluacionMensualPresupuestoPresentador listaEvaluacionMensualPresupuestoPresentador;
        
        public string nomUsuario { get { return Session["nomUsuario"]!=null ? Session["nomUsuario"].ToString() : string.Empty; } }

        public int idUsuario { get { return Session["idUsuario"] != null ? Convert.ToInt32(Session["idUsuario"].ToString()) : 0; } }

        public List<EvaluacionMensualPresupuestoPres> listaDatosPrincipales
        {
            set
            {
                this.grvEvaluacion.DataSource = value;
            }
        }

        ////Requerimiento
        
        public List<Anio> listaAnios
        {
            set
            {
                cbAnio.DataSource = value;
                cbAnio.DataBind();
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

        public int anioPresentacion
        {
            set { cbAnio.Value = value.ToString(); }
            get { return cbAnio.Value!=null ? Convert.ToInt32(cbAnio.Value.ToString()) : 0; }
        }

        public int mesPresentacion
        {
            set { cbMes.Value = value.ToString(); }
            get { return cbMes.Value != null ? Convert.ToInt32(cbMes.Value.ToString()) : 0; }
        }

        //******************
        public List<Anio> listaAniosSub
        {
            set
            {
                cbAnioSub.DataSource = value;
                cbAnioSub.DataBind();
            }
        }

        public List<Mes> listaMesesEvaSub
        {
            set
            {
                cbMesEvaSub.DataSource = value;
                cbMesEvaSub.DataBind();
            }
        }

        public List<Mes> listaMesesReaSub
        {
            set
            {
                cbMesReaSub.DataSource = value;
                cbMesReaSub.DataBind();
            }
        }

        public List<GrupoPresupuesto> listaGrupoPresupuestoSub
        {
            set
            {
                cbGruPre.DataSource = value;
                cbGruPre.DataBind();
            }
        }

        public int anioSub
        {
            set { cbAnioSub.Value = value.ToString(); }
            get { return cbAnioSub.Value != null ? Convert.ToInt32(cbAnioSub.Value.ToString()) : 0; }
        }

        public int mesEvaSub
        {
            set { cbMesEvaSub.Value = value.ToString(); }
            get { return cbMesEvaSub.Value != null ? Convert.ToInt32(cbMesEvaSub.Value.ToString()) : 0; }
        }

        public int mesReaSub
        {
            set { cbMesReaSub.Value = value.ToString(); }
            get { return cbMesReaSub.Value != null ? Convert.ToInt32(cbMesReaSub.Value.ToString()) : 0; }
        }

        public int idGruPreSub
        {
            set { cbGruPre.Value = value.ToString(); }
            get { return cbGruPre.Value != null ? Convert.ToInt32(cbGruPre.Value.ToString()) : 0; }
        }


        //**
                
        public List<Anio> listaAniosCal
        {
            set
            {
                cbAnioCal.DataSource = value;
                cbAnioCal.DataBind();
            }
        }

        public List<ProgramacionAnualPres> listaProgramacionAnual
        {
            set
            {
                cbPresAnual.DataSource = value;
                cbPresAnual.DataBind();
            }
        }

        public List<FuenteFinanciamiento> listaFuenteFinanciamiento
        {
            set
            {
                cbFueFinCal.DataSource = value;
                cbFueFinCal.DataBind();
            }
        }

        public List<Mes> listaMesesEvaCal
        {
            set
            {
                cbMesEvaCal.DataSource = value;
                cbMesEvaCal.DataBind();
            }
        }

        public List<Mes> listaMesesReaCal
        {
            set
            {
                cbMesReaCal.DataSource = value;
                cbMesReaCal.DataBind();
            }
        }

        public int anioCal
        {
            set { cbAnioCal.Value = value.ToString(); }
            get { return cbAnioCal.Value != null ? Convert.ToInt32(cbAnioCal.Value.ToString()) : 0; }
        }

        public int mesEvaCal
        {
            set { cbMesEvaCal.Value = value.ToString(); }
            get { return cbMesEvaCal.Value != null ? Convert.ToInt32(cbMesEvaCal.Value.ToString()) : 0; }
        }

        public int mesReaCal
        {
            set { cbMesReaCal.Value = value.ToString(); }
            get { return cbMesReaCal.Value != null ? Convert.ToInt32(cbMesReaCal.Value.ToString()) : 0; }
        }

        public int idFueFinCal
        {
            set { cbFueFinCal.Value = value.ToString(); }
            get { return cbFueFinCal.Value != null ? Convert.ToInt32(cbFueFinCal.Value.ToString()) : 0; }
        }

        public int idProAnuCal
        {
            set { cbPresAnual.Value = value.ToString(); }
            get { return cbPresAnual.Value != null ? Convert.ToInt32(cbPresAnual.Value.ToString()) : 0; }
        }

        //**
        public List<Anio> listaAniosCon
        {
            set
            {
                cbAnioCon.DataSource = value;
                cbAnioCon.DataBind();
            }
        }

        public List<FuenteFinanciamiento> listaFuenteFinanciamientoCon
        {
            set
            {
                cbFueFinCon.DataSource = value;
                cbFueFinCon.DataBind();
            }
        }

        public List<Mes> listaMesesEvaCon
        {
            set
            {
                cbMesEvaCon.DataSource = value;
                cbMesEvaCon.DataBind();
            }
        }

        public List<Mes> listaMesesReaCon
        {
            set
            {
                cbMesReaCon.DataSource = value;
                cbMesReaCon.DataBind();
            }
        }

        public int anioCon
        {
            set { cbAnioCon.Value = value.ToString(); }
            get { return cbAnioCon.Value != null ? Convert.ToInt32(cbAnioCon.Value.ToString()) : 0; }
        }

        public int mesEvaCon
        {
            set { cbMesEvaCon.Value = value.ToString(); }
            get { return cbMesEvaCon.Value != null ? Convert.ToInt32(cbMesEvaCon.Value.ToString()) : 0; }
        }

        public int mesReaCon
        {
            set { cbMesReaCon.Value = value.ToString(); }
            get { return cbMesReaCon.Value != null ? Convert.ToInt32(cbMesReaCon.Value.ToString()) : 0; }
        }

        public int idFueFinCon
        {
            set { cbFueFinCon.Value = value.ToString(); }
            get { return cbFueFinCon.Value != null ? Convert.ToInt32(cbFueFinCon.Value.ToString()) : 0; }
        }
        public string desPresupuesto
        {
            set { lblDesPresupuesto.Text = value.ToString(); }
        }
        public string desGrupoPresupuesto
        {
            set { lblDesGrupoPre.Text = value.ToString(); }
        }
        public int idMoneda
        {
            set { cbMoneda.Value = value.ToString(); }
            get { return cbMoneda.Value != null ? Convert.ToInt32(cbMoneda.Value.ToString()) : 0; }
        }
        /*PopImprimir*/
        public List<TipoReporte> listaTipoReporte
        {
            set
            {
                cbTipRep.DataSource = value;
                cbTipRep.DataBind();
            }
        }
        public List<Anio> listaAnioEvaImp
        {
            set
            {
                cbAnioEvaImp.DataSource = value;
                cbAnioEvaImp.DataBind();
            }
        }
        public List<Mes> listaMesEvaImp
        {
            set
            {
                cbMesEvaImp.DataSource = value;
                cbMesEvaImp.DataBind();
            }
        }
        public int idTipRep
        {
            set { cbTipRep.Value = value.ToString(); }
            get { return cbTipRep.Value != null ? Convert.ToInt32(cbTipRep.Value.ToString()) : 0; }
        }
        public int anioEvaImp
        {
            set { cbAnioEvaImp.Value = value.ToString(); }
            get { return cbAnioEvaImp.Value != null ? Convert.ToInt32(cbAnioEvaImp.Value.ToString()) : 0; }
        }

        public int mesEvaImp
        {
            set { cbMesEvaImp.Value = value.ToString(); }
            get { return cbMesEvaImp.Value != null ? Convert.ToInt32(cbMesEvaImp.Value.ToString()) : 0; }
        }
        /*Pop Saldo por Grupo*/
        
        public List<Anio> listaAnio_SalGru
        {
            set
            {
                cbAnio_SalGru.DataSource = value;
                cbAnio_SalGru.DataBind();
            }
        }
        public List<Mes> listaMesEva_SalGru
        {
            set
            {
                cbMesEva_SalGru.DataSource = value;
                cbMesEva_SalGru.DataBind();
            }
        }
        public List<Mes> listaMesRea_SalGru
        {
            set
            {
                cbMesRea_SalGru.DataSource = value;
                cbMesRea_SalGru.DataBind();
            }
        }
        
        public int anio_SalGru
        {
            set { cbAnio_SalGru.Value = value.ToString(); }
            get { return cbAnio_SalGru.Value != null ? Convert.ToInt32(cbAnio_SalGru.Value.ToString()) : 0; }
        }

        public int mesEva_SalGru
        {
            set { cbMesEva_SalGru.Value = value.ToString(); }
            get { return cbMesEva_SalGru.Value != null ? Convert.ToInt32(cbMesEva_SalGru.Value.ToString()) : 0; }
        }
        public int mesRea_SalGru
        {
            set { cbMesRea_SalGru.Value = value.ToString(); }
            get { return cbMesRea_SalGru.Value != null ? Convert.ToInt32(cbMesRea_SalGru.Value.ToString()) : 0; }
        }
        /*popEjecucionPreMen*/
        public List<GrupoPresupuesto> listaGrupoPresupuestoEje
        {
            set
            {
                cbGruPreEje.DataSource = value;
                cbGruPreEje.DataBind();
            }
        }
        public List<ProgramacionAnual> listaProgramacionAnualEje
        {
            set
            {
                cbPreEje.DataSource = value;
                cbPreEje.DataBind();
            }
        }
        public List<Subpresupuesto> listaSubpresupuestoEje
        {
            set
            {
                cbSubPreEje.DataSource = value;
                cbSubPreEje.DataBind();
            }
        }
        public List<Moneda> listaMonedaEje
        {
            set
            {
                cbMonedaEje.DataSource = value;
                cbMonedaEje.DataBind();
            }
        }

        public int idGruPreEje
        {
            set { cbGruPreEje.Value = value.ToString(); }
            get { return cbGruPreEje.Value != null ? Convert.ToInt32(cbGruPreEje.Value.ToString()) : 0; }
        }
        public int idPreEje
        {
            set { cbPreEje.Value = value.ToString(); }
            get { return cbPreEje.Value != null ? Convert.ToInt32(cbPreEje.Value.ToString()) : 0; }
        }
        public int idSubPreEje
        {
            set { cbSubPreEje.Value = value.ToString(); }
            get { return cbSubPreEje.Value != null ? Convert.ToInt32(cbSubPreEje.Value.ToString()) : 0; }
        }
        public int idMonedaEje
        {
            set { cbMonedaEje.Value = value.ToString(); }
            get { return cbMonedaEje.Value != null ? Convert.ToInt32(cbMonedaEje.Value.ToString()) : 0; }
        }

        /*popEjecucionPreMenFec*/
        public List<GrupoPresupuesto> listaGrupoPresupuesto_PreMenFec
        {
            set
            {
                cbGruPre_PreMenFec.DataSource = value;
                cbGruPre_PreMenFec.DataBind();
            }
        }
        public List<ProgramacionAnual> listaProgramacionAnual_PreMenFec
        {
            set
            {
                cbPre_PreMenFec.DataSource = value;
                cbPre_PreMenFec.DataBind();
            }
        }
        public List<Moneda> listaMoneda_PreMenFec
        {
            set
            {
                cbMoneda_PreMenFec.DataSource = value;
                cbMoneda_PreMenFec.DataBind();
            }
        }
        public DateTime fecDesde_PreMenFec
        {
            set { cFecDesde_PreMenFec.Value = value; }
            get {
                DateTime fechatemp = DateTime.Today;
                return cFecDesde_PreMenFec.Value != null ? Convert.ToDateTime(cFecDesde_PreMenFec.Value.ToString()) : new DateTime(fechatemp.Year, fechatemp.Month, 1); 
            }
        }
        public DateTime fecHasta_PreMenFec
        {
            set { cFecHasta_PreMenFec.Value = value; }
            get { return cFecHasta_PreMenFec.Value != null ? Convert.ToDateTime(cFecHasta_PreMenFec.Value.ToString()) : DateTime.Now.Date; }
        }
        public int idGruPre_PreMenFec
        {
            set { cbGruPre_PreMenFec.Value = value.ToString(); }
            get { return cbGruPre_PreMenFec.Value != null ? Convert.ToInt32(cbGruPre_PreMenFec.Value.ToString()) : 0; }
        }
        public int idPre_PreMenFec
        {
            set { cbPre_PreMenFec.Value = value.ToString(); }
            get { return cbPre_PreMenFec.Value != null ? Convert.ToInt32(cbPre_PreMenFec.Value.ToString()) : 0; }
        }
        public int idMoneda_PreMenFec
        {
            set { cbMoneda_PreMenFec.Value = value.ToString(); }
            get { return cbMoneda_PreMenFec.Value != null ? Convert.ToInt32(cbMoneda_PreMenFec.Value.ToString()) : 0; }
        }

        /*PopEvaluación Reajuste*/
        public List<Anio> listaAniosEvaRea
        {
            set
            {
                cbAnioEvaRea.DataSource = value;
                cbAnioEvaRea.DataBind();
            }
        }
        public List<Moneda> listaMonedaEvaRea
        {
            set
            {
                cbMonedaEvaRea.DataSource = value;
                cbMonedaEvaRea.DataBind();
            }
        }
        public List<Mes> listaMesesEvaReaEva
        {
            set
            {
                cbMesEvaReaEva.DataSource = value;
                cbMesEvaReaEva.DataBind();
            }
        }
        public List<Mes> listaMesesEvaReaRea
        {
            set
            {
                cbMesEvaReaRea.DataSource = value;
                cbMesEvaReaRea.DataBind();
            }
        }
        public List<ProgramacionAnualPres> listaProgramacionAnualEvaRea
        {
            set
            {
                this.grvPresupuestoAnualEvaRea.DataSource = value;
            }
        }
        public int anioEvaRea
        {
            set { cbAnioEvaRea.Value = value.ToString(); }
            get { return cbAnioEvaRea.Value != null ? Convert.ToInt32(cbAnioEvaRea.Value.ToString()) : 0; }
        }
        public int idMonedaEvaRea
        {
            set { cbMonedaEvaRea.Value = value.ToString(); }
            get { return cbMonedaEvaRea.Value != null ? Convert.ToInt32(cbMonedaEvaRea.Value.ToString()) : 0; }
        }

        public int mesEvaReaEva
        {
            set { cbMesEvaReaEva.Value = value.ToString(); }
            get { return cbMesEvaReaEva.Value != null ? Convert.ToInt32(cbMesEvaReaEva.Value.ToString()) : 0; }
        }

        public int mesEvaReaRea
        {
            set { cbMesEvaReaRea.Value = value.ToString(); }
            get { return cbMesEvaReaRea.Value != null ? Convert.ToInt32(cbMesEvaReaRea.Value.ToString()) : 0; }
        }
        public string idsProAnuEvaRea
        {
            get;set;
        }
        /************************/

        protected void Page_Init(object sender, EventArgs e)
        {
            listaEvaluacionMensualPresupuestoPresentador = new ListaEvaluacionMensualPresupuestoPresentador(this);
            listaEvaluacionMensualPresupuestoPresentador.CargarServicios();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["nomUsuario"] == null)
            {
                Response.Redirect("~/Error.htm");
            }

            if (!IsPostBack)
            {
                listaEvaluacionMensualPresupuestoPresentador.Iniciar();
                hdfValores["anioEvaRea"] = DateTime.Now.Year;
            }

            Actualizar();
        }
        public void Actualizar()
        {
            this.grvEvaluacion.DataBind();
        }

        protected void btnAgregar_Click(object sender, ImageClickEventArgs e)
        {
        }

        protected void cpPrincipal_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            //popRequerimiento.JSProperties["cpNombre"] = "Registro de Requerimiento";
        }

        protected void popImprimirEvaluacion_Callback(object source, DevExpress.Web.CallbackEventArgsBase e)
        {
            listaEvaluacionMensualPresupuestoPresentador.IniciarImprimir();
        }
        protected void popEvaRea_WindowCallback(object source, DevExpress.Web.CallbackEventArgsBase e)
        {
            IniciaPopupEvaluacionReajuste();
        }
        protected void popEvaluacionMoneda_WindowCallback(object source, DevExpress.Web.CallbackEventArgsBase e)
        {
            int id = Convert.ToInt32(hdfValores["id"]);
            listaEvaluacionMensualPresupuestoPresentador.IniciarExportaEvaluacion(id);
        }
        
        /*Pop Reporte Ejecucion*/
        protected void popEjecucionPreMen_Callback(object source, DevExpress.Web.CallbackEventArgsBase e)
        {
            listaEvaluacionMensualPresupuestoPresentador.IniciarReporteEjecucion();
        }
        protected void cbPreEje_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            idGruPreEje = Convert.ToInt32(e.Parameter);
            listaEvaluacionMensualPresupuestoPresentador.CargarPresupuestoEje();
        }
        protected void cbSubPreEje_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            idPreEje = Convert.ToInt32(e.Parameter);
            listaEvaluacionMensualPresupuestoPresentador.CargarSubpresupuestoEje();
        }
        
        /*Pop Reporte Ejecucion de Presupuesto Mensual por Fechas*/
        protected void popEjecucionPreMenFec_Callback(object source, DevExpress.Web.CallbackEventArgsBase e)
        {
            listaEvaluacionMensualPresupuestoPresentador.IniciarReporteEjecucionPorFechas();
        }
        protected void cbPre_PreMenFec_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            idGruPre_PreMenFec = Convert.ToInt32(e.Parameter);
            listaEvaluacionMensualPresupuestoPresentador.CargarPresupuestoEjeFec();
        }

        protected void GridViewSelectionAPI_CustomJSProperties(object sender, ASPxGridViewClientJSPropertiesEventArgs e)
        {
            e.Properties["cpVisibleRowCount"] = grvPresupuestoAnualEvaRea.VisibleRowCount;
            
        }
        protected void grvPresupuestoAnualEvaRea_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            string[] parametro = e.Parameters.Split('|');
            grvPresupuestoAnualEvaRea.DataBind();
        }
        protected void grvPresupuestoAnualEvaRea_DataBinding(object sender, EventArgs e)
        {
            anioEvaRea = Convert.ToInt32(hdfValores["anioEvaRea"]);
            
            this.listaEvaluacionMensualPresupuestoPresentador.CargarPresupuestoAnualPopEvaRea();
        }
        
        protected void popReporteDireccion_WindowCallback(object source, DevExpress.Web.CallbackEventArgsBase e)
        {
            listaEvaluacionMensualPresupuestoPresentador.IniciarReporte(0);
        }

        protected void grvRequerimiento_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            string[] parametro = e.Parameters.Split('|');
            anioPresentacion = Convert.ToInt32(parametro[0]);
            mesPresentacion = Convert.ToInt32(parametro[1]);
            grvEvaluacion.DataBind();
        }
        protected void grvRequerimiento_DataBinding(object sender, EventArgs e)
        {
            listaEvaluacionMensualPresupuestoPresentador.ObtenerDatosListado();
        }

        protected void btnExpEva_Click(object sender, EventArgs e)
        {
            List<ReporteEvaluacionMensualExportaPres> lista = new List<ReporteEvaluacionMensualExportaPres>();
            int id = Convert.ToInt32(hdfValores["id"]);
            lista = this.listaEvaluacionMensualPresupuestoPresentador.TraerReporteEvaluacionMensualExporta(id);
            string ruta = ExportarReporteEvaluacion(lista);

            if(!string.IsNullOrEmpty(ruta))
            {
                string format = "yyyy-MM-dd_hh.mm.ss.tt";
                string nombreArchivo = "EvaluacionMensualPresupuesto_" + DateTime.Now.ToString(format, CultureInfo.InvariantCulture).ToLower() + ".xlsx";
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
        protected void btnPopExpEvaRea_Click(object sender, EventArgs e)
        {
            idsProAnuEvaRea = string.Empty;
            List<Object> selectItems = new List<object>();
            List<EvaluacionReajusteMensualAreaExporta> lista = new List<EvaluacionReajusteMensualAreaExporta>();

            ASPxGridView grid = grvPresupuestoAnualEvaRea as ASPxGridView;

            selectItems = grid.GetSelectedFieldValues("idProAnu");
            anioEvaRea = Convert.ToInt32(hdfValores["anioEvaRea"]);
            mesEvaReaEva = Convert.ToInt32(hdfValores["mesEvaReaEva"]);
            mesEvaReaRea = Convert.ToInt32(hdfValores["mesEvaReaRea"]);

            if (selectItems.Count > 0)
            {
                idsProAnuEvaRea = String.Join("~", selectItems);

                lista = listaEvaluacionMensualPresupuestoPresentador.TraerListaEvaluacionReajusteMensualAreaExporta();
                
                if (lista.Count > 0)
                {
                    string ruta = ExportarEvaluacionReajuste(lista);
                    if (!string.IsNullOrEmpty(ruta))
                    {
                        string format = "yyyy-MM-dd_hh.mm.ss.tt";
                        string nombreArchivo = "EvaluacionReajusteMensualPresupuesto_" + DateTime.Now.ToString(format, CultureInfo.InvariantCulture).ToLower() + ".xlsx";
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
            }
            IniciaPopupEvaluacionReajuste();
        }

        protected void popCalendarioAnual_WindowCallback(object source, DevExpress.Web.CallbackEventArgsBase e)
        {
            listaEvaluacionMensualPresupuestoPresentador.IniciarCalendario(0);
        }
        /*Pop Reporte Saldo por grupo*/
        protected void popSaldoGrupo_WindowCallback(object source, DevExpress.Web.CallbackEventArgsBase e)
        {
            listaEvaluacionMensualPresupuestoPresentador.IniciarSaldoPorGrupo();
        }

        protected void popCalendarioAnualCon_WindowCallback(object source, DevExpress.Web.CallbackEventArgsBase e)
        {
            listaEvaluacionMensualPresupuestoPresentador.IniciarConsolidado(0);
        }

        private void IniciaPopupEvaluacionReajuste()
        {
            listaEvaluacionMensualPresupuestoPresentador.IniciarExportaEvaluacionReajuste();
            this.grvPresupuestoAnualEvaRea.DataBind();
        }
        private string ExportarEvaluacionReajuste(List<EvaluacionReajusteMensualAreaExporta> lista)
        {
            string ruta = string.Empty;
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                string format = "yyyy-MM-dd_hh.mm.ss.tt";
                sfd.Filter = "Excel XLSX|*.xlsx";
                sfd.Title = "Guardar el siguiente archivo";

                ruta = Path.GetTempPath() + "EvaluacionReajusteMensualPresupuesto_" + DateTime.Now.ToString(format, CultureInfo.InvariantCulture).ToLower() + ".xlsx";

                ExportarProHelper.ExportarEvaluacionReajusteMensualConCantidad(ruta, lista, mesEvaReaRea);
            }

            return ruta;
        }
        private string ExportarReporteEvaluacion(List<ReporteEvaluacionMensualExportaPres> lista)
        {
            string ruta = string.Empty;
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                string format = "yyyy-MM-dd_hh.mm.ss.tt";
                sfd.Filter = "Excel XLSX|*.xlsx";
                sfd.Title = "Guardar el siguiente archivo";

                ruta = Path.GetTempPath() + "EvaluacionMensualPresupuesto_" + DateTime.Now.ToString(format, CultureInfo.InvariantCulture).ToLower() + ".xlsx";

                ExportarProHelper.ExportarEvaluacionMensualPresupuesto(ruta, lista);
            }

            return ruta;
        }
    }
}