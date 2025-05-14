using DevExpress.Web;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WebForm.Helper;
using SIA_Presupuesto.WebForm.Presentador;
using SIA_Presupuesto.WebForm.Vista;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Utilitario.Util;

namespace SIA_Presupuesto.WebForm.Programacion
{
    public partial class ListaPresupuestoAnual : System.Web.UI.Page, IListaPresupuestoAnualVista
    {
        private ListaPresupuestoAnualPresentador listaPresupuestoAnualPresentador;
        
        public string nomUsuario { get { return Session["nomUsuario"]!=null ? Session["nomUsuario"].ToString() : string.Empty; } }

        public int idUsuario { get { return Session["idUsuario"] != null ? Convert.ToInt32(Session["idUsuario"].ToString()) : 0; } }

        public List<ProgramacionAnualPres> listaDatosPrincipales
        {
            set
            {
                this.grvRequerimiento.DataSource = value;
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

        public List<Anio> listaAniosRep
        {
            set
            {
                cbAnioDir.DataSource = value;
                cbAnioDir.DataBind();
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

        public int anioPresentacion
        {
            set { cbAnio.Value = value.ToString(); }
            get { return cbAnio.Value!=null ? Convert.ToInt32(cbAnio.Value.ToString()) : 0; }
        }

        public int anioReporte
        {
            set { cbAnioDir.Value = value.ToString(); }
            get { return cbAnioDir.Value != null ? Convert.ToInt32(cbAnioDir.Value.ToString()) : 0; }
        }

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

        public int anioCal
        {
            set { cbAnioCal.Value = value.ToString(); }
            get { return cbAnioCal.Value != null ? Convert.ToInt32(cbAnioCal.Value.ToString()) : 0; }
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

        /*Pop Exportar Programacion Anual*/
        public List<Moneda> listaMonedaExpProAnu
        {
            set
            {
                cbMonedaExpProAnu.DataSource = value;
                cbMonedaExpProAnu.DataBind();
            }
        }
        public string desPresupuesto
        {
            set { lblDesPresupuesto.Text = value.ToString(); }
        }
        public string desGrupoPresupuesto
        {
            set { lblDesGrupoPre.Text = value.ToString(); }
        }
        public int idMonedaExpProAnu
        {
            set { cbMonedaExpProAnu.Value = value.ToString(); }
            get { return cbMonedaExpProAnu.Value != null ? Convert.ToInt32(cbMonedaExpProAnu.Value.ToString()) : 0; }
        }
        public int idProAnuExp
        {
            set; get;
        }

        /*Pop Exportar Programacion Anual Masivo*/
        public List<Anio> listaAnioPopExpProAnuMas
        {
            set
            {
                cbAnioPopExpProAnuMas.DataSource = value;
                cbAnioPopExpProAnuMas.DataBind();
            }
        }
        public List<Moneda> listaMonedaPopExpProAnuMas
        {
            set
            {
                cbMonedaPopExpProAnuMas.DataSource = value;
                cbMonedaPopExpProAnuMas.DataBind();
            }
        }
        public List<ProgramacionAnualPres> listaProgramacionAnualPopExpProAnuMas
        {
            set
            {
                this.grvPopExpProAnuMas.DataSource = value;
            }
        }
        public int anioPopExpProAnuMas
        {
            set
            {
                cbAnioPopExpProAnuMas.Value = value.ToString();
            }
            get { return cbAnioPopExpProAnuMas.Value != null ? Convert.ToInt32(cbAnioPopExpProAnuMas.Value.ToString()) : 0; }
        }
        public int idMonedaPopExpProAnuMas
        {
            set { cbMonedaPopExpProAnuMas.Value = value.ToString(); }
            get { return cbMonedaPopExpProAnuMas.Value != null ? Convert.ToInt32(cbMonedaPopExpProAnuMas.Value.ToString()) : 0; }
        }

        public string idsProAnuMas
        {
            set; get;
        }
        /*********************************************************************/
        protected void Page_Init(object sender, EventArgs e)
        {
            listaPresupuestoAnualPresentador = new ListaPresupuestoAnualPresentador(this);
            listaPresupuestoAnualPresentador.CargarServicios();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["nomUsuario"] == null)
            {
                Response.Redirect("~/Error.htm");
            }

            if (!IsPostBack)
            {
                listaPresupuestoAnualPresentador.Iniciar();
                hdfValores["anioPopExpProAnuMas"] = DateTime.Now.Year;
            }
            Actualizar();
        }

        public void Actualizar()
        {
            grvRequerimiento.DataBind();
        }

        protected void btnAgregar_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void cpPrincipal_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            //popRequerimiento.JSProperties["cpNombre"] = "Registro de Requerimiento";

        }

        protected void popReporteDireccion_WindowCallback(object source, DevExpress.Web.CallbackEventArgsBase e)
        {
            listaPresupuestoAnualPresentador.IniciarReporte(0);
        }

        protected void popCalendarioAnual_WindowCallback(object source, DevExpress.Web.CallbackEventArgsBase e)
        {
            listaPresupuestoAnualPresentador.IniciarCalendario(0);
        }
        /*Pop Exportar Programación Anual*/
        protected void popExportaProAnu_WindowCallback(object source, DevExpress.Web.CallbackEventArgsBase e)
        {
            idProAnuExp = Convert.ToInt32(hdfValores["idProAnu"]);
            this.listaPresupuestoAnualPresentador.IniciarPopExportaPresupuestoAnual();
        }
        protected void btnExpProAnu_Click(object sender, EventArgs e)
        {
            idProAnuExp = Convert.ToInt32(hdfValores["idProAnu"]);
            idMonedaExpProAnu = Convert.ToInt32(hdfValores["idMonedaExpProAnu"]);
            
            List<ReporteProgramacionAnualExportaPres> lista = new List<ReporteProgramacionAnualExportaPres>();
            lista = this.listaPresupuestoAnualPresentador.listaProgramacionAnualAreaExporta();
            if (lista.Count > 0)
            {
                string ruta = ExportarProgramacionAnual(lista);

                if (!string.IsNullOrEmpty(ruta))
                {
                    string format = "yyyy-MM-dd_hh.mm.ss.tt";
                    string nombreArchivo = "PresupuestoAnual_" + DateTime.Now.ToString(format, CultureInfo.InvariantCulture).ToLower() + ".xlsx";
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
                        Response.Write("This file does not exist.");
                    }
                }
            }
        }
        /*Pop Exportar Programación Anual Masivo*/
        protected void grvPopExpProAnuMas_CustomJSProperties(object sender, ASPxGridViewClientJSPropertiesEventArgs e)
        {
            e.Properties["cpVisibleRowCount"] = grvPopExpProAnuMas.VisibleRowCount;

        }
        protected void popExportaProAnuMasivo_WindowCallback(object source, DevExpress.Web.CallbackEventArgsBase e)
        {
            IniciaPopExpProAnuMas();
        }
        protected void grvPopExpProAnuMas_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            string[] parametro = e.Parameters.Split('|');
            this.grvPopExpProAnuMas.DataBind();
        }
        protected void grvPopExpProAnuMas_DataBinding(object sender, EventArgs e)
        {
            anioPopExpProAnuMas = Convert.ToInt32(hdfValores["anioPopExpProAnuMas"]);
            this.listaPresupuestoAnualPresentador.LlenarGridPopExpProAnuMas();
        }
        protected void btnExpProAnuMas_Click(object sender, EventArgs e)
        {
            idsProAnuMas = string.Empty;
            List<Object> selectItems = new List<object>();
            List<ReporteProgramacionAnualExportaMasivoPres> lista = new List<ReporteProgramacionAnualExportaMasivoPres>();

            ASPxGridView grid = grvPopExpProAnuMas as ASPxGridView;

            selectItems = grid.GetSelectedFieldValues("idProAnu");
            idMonedaPopExpProAnuMas = Convert.ToInt32(hdfValores["idMonedaPopExpProAnuMas"]);

            if (selectItems.Count > 0)
            {
                idsProAnuMas = String.Join("~", selectItems);

                lista = this.listaPresupuestoAnualPresentador.TraerReporteProgramacionAnualExportaMasivo();

                if (lista.Count > 0)
                {
                    string ruta = ExportarProgramacionAnualMasivo(lista);
                    if (!string.IsNullOrEmpty(ruta))
                    {
                        string format = "yyyy-MM-dd_hh.mm.ss.tt";
                        string nombreArchivo = "PresupuestoAnualMasivo_" + DateTime.Now.ToString(format, CultureInfo.InvariantCulture).ToLower() + ".xlsx";
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
            IniciaPopExpProAnuMas();
        }
        private void IniciaPopExpProAnuMas()
        {
            this.listaPresupuestoAnualPresentador.IniciarPopExportaPresupuestoAnualMasivo();
            this.grvPopExpProAnuMas.DataBind();
        }

        protected void grvRequerimiento_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            anioPresentacion = !string.IsNullOrEmpty(e.Parameters) ? Convert.ToInt32(e.Parameters) : DateTime.Now.Year;
            grvRequerimiento.DataBind();
        }

        protected void grvRequerimiento_DataBinding(object sender, EventArgs e)
        {
            listaPresupuestoAnualPresentador.ObtenerDatosListado();
        }

        private string ExportarProgramacionAnual(List<ReporteProgramacionAnualExportaPres> lista)
        {
            string ruta = string.Empty;
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                string format = "yyyy-MM-dd_hh.mm.ss.tt";
                sfd.Filter = "Excel XLSX|*.xlsx";
                sfd.Title = "Guardar el siguiente archivo";

                ruta = Path.GetTempPath() + "PresupuestoAnual_" + DateTime.Now.ToString(format, CultureInfo.InvariantCulture).ToLower() + ".xlsx";

                ExportarProHelper.ExportarProgramacionAnual(ruta, lista);
            }

            return ruta;
        }
        private string ExportarProgramacionAnualMasivo(List<ReporteProgramacionAnualExportaMasivoPres> lista)
        {
            string ruta = string.Empty;
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                string format = "yyyy-MM-dd_hh.mm.ss.tt";
                sfd.Filter = "Excel XLSX|*.xlsx";
                sfd.Title = "Guardar el siguiente archivo";

                ruta = Path.GetTempPath() + "PresupuestoAnualMasivo_" + DateTime.Now.ToString(format, CultureInfo.InvariantCulture).ToLower() + ".xlsx";

                ExportarProHelper.ExportarProgramacionAnualGenericaDetalleResumen(ruta, lista);
            }

            return ruta;
        }
        //private void RutaExporta(string nombreArchivo)
        //{
        //    string ruta = string.Empty;
        //    using (SaveFileDialog sfd = new SaveFileDialog())
        //    {
        //        string format = "yyyy-MM-dd_hh.mm.ss.tt";
        //        sfd.Filter = "Excel XLSX|*.xlsx";
        //        sfd.Title = "Guardar el siguiente archivo";

        //        ruta = Path.GetTempPath() + nombreArchivo + DateTime.Now.ToString(format, CultureInfo.InvariantCulture).ToLower() + ".xlsx";

        //        ExportarProHelper.ExportarProgramacionAnual(ruta, lista);
        //    }
        //}

    }
}