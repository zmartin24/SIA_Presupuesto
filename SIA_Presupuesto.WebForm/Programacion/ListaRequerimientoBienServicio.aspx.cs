using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WebForm.Helper;
using SIA_Presupuesto.WebForm.Presentador;
using SIA_Presupuesto.WebForm.Vista;
using System;
using System.Collections.Generic;
using System.Web.UI;
using Utilitario.Util;

namespace SIA_Presupuesto.WebForm.Programacion
{
    public partial class ListaRequerimientoBienServicio : System.Web.UI.Page, IListaRequerimientoBienServicioVista
    {
        private ListaRequerimientoBienServicioPresentador listaRequerimientoBienServicioPresentador;
        

        public string nomUsuario { get { return Session["nomUsuario"]!=null ? Session["nomUsuario"].ToString() : string.Empty; } }

        public int idUsuario { get { return Session["idUsuario"] != null ? Convert.ToInt32(Session["idUsuario"].ToString()) : 0; } }

        public List<RequerimientoBienServicioPres> listaDatosPrincipales
        {
            set
            {
                this.grvRequerimiento.DataSource = value;
            }
        }

        ////Requerimiento
        public List<Moneda> listaMonedas
        {
            set
            {
                cbMoneda.DataSource = value;
                cbMoneda.DataBind();
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

        public List<Direccion> listaDirecciones
        {
            set
            {
                cbDireccion.DataSource = value;
                cbDireccion.DataBind();
            }
        }

        public List<Direccion> listaDireccionesReporte
        {
            set
            {
                cbDireccionReporte.DataSource = value;
                cbDireccionReporte.DataBind();
            }
        }

        public List<Subdireccion> listaSubDireccionesReporte
        {
            set
            {
                cbSubdireccionReporte.DataSource = value;
                cbSubdireccionReporte.DataBind();
            }
        }

        public List<Periodo> listaAnioReporte
        {
            set
            {
                cbAnioPeriodo.DataSource = value;
                cbAnioPeriodo.DataBind();
            }
        }
        public int anioReporte
        {
            set { cbAnioPeriodo.Value = value.ToString(); }
            get { return cbAnioPeriodo.Value != null ? Convert.ToInt32(cbAnioPeriodo.Value.ToString()) : 0; }
        }
        public int idMonedaReporte
        {
            set { cbMonedaReporte.Value = value.ToString(); }
            get { return Convert.ToInt32(cbMonedaReporte.Value.ToString()); }
        }
        public List<Moneda> listaMonedasReporte
        {
            set
            {
                cbMonedaReporte.DataSource = value;
                cbMonedaReporte.DataBind();
            }
        }

        public List<Subdireccion> listaSubdirecciones
        {
            set
            {
                cbSubdireccion.DataSource = value;
                cbSubdireccion.DataBind();
            }
        }

        public List<Area> listaAreas
        {
            set
            {
                cbArea.DataSource = value;
                cbArea.DataBind();
            }
        }

        public int idMoneda
        {
            set { cbMoneda.Value = value.ToString(); }
            get { return Convert.ToInt32(cbMoneda.Value.ToString()); }
        }

        public int idDireccion
        {
            set { cbDireccion.Value = value.ToString(); }
            get { return Convert.ToInt32(cbDireccion.Value.ToString()); }
        }

        public int idSubdireccion
        {
            set { cbSubdireccion.Value = value.ToString(); }
            get { return Convert.ToInt32(cbSubdireccion.Value.ToString()); }
        }

        public int idArea
        {
            set { cbArea.Value = value.ToString(); }
            get { return Convert.ToInt32(cbArea.Value.ToString()); }
        }

        public int anioPresentacion
        {
            set { cbAnio.Value = value.ToString(); }
            get { return cbAnio.Value!=null ? Convert.ToInt32(cbAnio.Value.ToString()) : 0; }
        }

        public string tipo
        {
            set { cbTipo.Value = value; }
            get { return Convert.ToString(cbTipo.Value); }
        }

        public int anio
        {
            set { seAnio.Value = value; }
            get { return Convert.ToInt32(seAnio.Value); }
        }

        public string descripcion
        {
            set { txtDescripcion.Text = value; }
            get { return txtDescripcion.Text; }
        }

        public DateTime fechaEmision
        {
            set;
            get;
        }

        decimal usd, soles;

        protected void Page_Init(object sender, EventArgs e)
        {
            listaRequerimientoBienServicioPresentador = new ListaRequerimientoBienServicioPresentador(this);
            listaRequerimientoBienServicioPresentador.CargarServicios();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["nomUsuario"] == null)
            {
                Response.Redirect("~/Error.htm");
            }

            if(!IsPostBack)
                listaRequerimientoBienServicioPresentador.Iniciar();

            Actualizar();
        }
        public void Actualizar()
        {
            grvRequerimiento.DataBind();
        }

        protected void cpPrincipal_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            popRequerimiento.JSProperties["cpNombre"] = "Registro de Requerimiento";

            var args = Util.DeserializeCallbackArgs(e.Parameter);

            if (args.Count == 0)
                return;

            if (args[0] == "Nuevo" || args[0] == "Editar")
            {
                string valor = txtDescripcion.Text;

                Resultado resultado = listaRequerimientoBienServicioPresentador.GuardarDatosRequerimiento(args[2]);
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
            else if (args[0] == "Clonar")
            {
                Resultado resultado = listaRequerimientoBienServicioPresentador.ClonarDatosRequerimiento(args[2]);
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
            else if(args[0] == "Anular")
            {

                if (listaRequerimientoBienServicioPresentador.AnularRegistro(Convert.ToInt32(args[1])))
                    cpPrincipal.JSProperties["cpMensaje"] = "Anulado correctamente";
                else
                    cpPrincipal.JSProperties["cpMensaje"] = "No se pudo anular";
            }

            cpPrincipal.JSProperties["cpGrid"] = "grvRequerimiento";

            Periodo objPeriodo = listaRequerimientoBienServicioPresentador.ObtenerxAnio();


            if (objPeriodo.estado == "A")
            {
                btnNuevo.Enabled = true;
                btnEditar.Enabled = true;
                btnAnular.Enabled = true;
                btnDetalle.Enabled = true;
            }
            else
            {
                if (objPeriodo.estado == "C")
                {
                    btnNuevo.Enabled = false;
                    btnEditar.Enabled = false;
                    btnAnular.Enabled = false;
                    btnDetalle.Enabled = false;
                }
            }

        }
        protected void btnAgregar_Click(object sender, ImageClickEventArgs e)
        {
        }
        protected void cbDireccion_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {

        }

        protected void cbSubdireccion_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            listaRequerimientoBienServicioPresentador.LlenarCombosSubdireccion(Convert.ToInt32(e.Parameter));
        }
        protected void cbSubdireccionReporte_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            listaRequerimientoBienServicioPresentador.LlenarCombosSubdireccionReporte(Convert.ToInt32(e.Parameter));
        }

        protected void cbArea_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            listaRequerimientoBienServicioPresentador.LlenarCombosAreas(Convert.ToInt32(e.Parameter));
        }

        protected void popReporteDireccion_WindowCallback(object source, DevExpress.Web.CallbackEventArgsBase e)
        {
            listaRequerimientoBienServicioPresentador.IniciarReporte(0);
        }

        protected void grvRequerimiento_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            anioPresentacion = Convert.ToInt32(e.Parameters);
            grvRequerimiento.DataBind();
        }
        protected void grvRequerimiento_DataBinding(object sender, EventArgs e)
        {
            listaRequerimientoBienServicioPresentador.ObtenerDatosListado();
        }
        protected void popRequerimiento_WindowCallback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            var args = e.Parameter.Split('|');
            int id = 0;
            string opcion = string.Empty;
            switch (args[0])
            {
                case "Nuevo":
                    listaRequerimientoBienServicioPresentador.IniciarDatosRequerimiento(0);
                    opcion = "Nuevo";
                    break;
                case "Editar":
                    id = !string.IsNullOrEmpty(args[1]) ? int.Parse(args[1]) : 0;
                    listaRequerimientoBienServicioPresentador.IniciarDatosRequerimiento(id);
                    seAnio.ClientEnabled = false;
                    cbMoneda.ClientEnabled = false;
                    opcion = "Editar";
                    break;
                case "Clonar":
                    id = !string.IsNullOrEmpty(args[1]) ? int.Parse(args[1]) : 0;//IdReqBieSerOrigen
                    listaRequerimientoBienServicioPresentador.IniciarDatosRequerimientoClonar(id);
                    seAnio.ClientEnabled = false;
                    opcion = "Clonar";
                    break;
                case "Mostrar":
                    id = !string.IsNullOrEmpty(args[1]) ? int.Parse(args[1]) : 0;
                    listaRequerimientoBienServicioPresentador.IniciarDatosRequerimiento(id);
                    opcion = "Mostrar";
                    break;
            }
            popRequerimiento.JSProperties["cpID"] = id;
            popRequerimiento.JSProperties["cpOpcion"] = opcion;
        }
        protected void grvRequerimiento_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            if (e.IsTotalSummary)
            {
                if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Start)
                {
                    usd = 0;
                    soles = 0;
                }
                else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Calculate)
                {
                    string currency = e.GetValue("moneda").ToString();
                    if (currency == "$/.")
                        usd += Convert.ToDecimal(e.GetValue("total"));
                    else if (currency == "S/.")
                        soles += Convert.ToDecimal(e.GetValue("total"));
                }
                else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
                {
                    e.TotalValue = string.Format("S/{0}; ${1}", FormatDecimal(soles), FormatDecimal(usd));
                }
            }
        }
        protected void grvRequerimiento_CustomUnboundColumnData(object sender, DevExpress.Web.Bootstrap.BootstrapGridViewColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "moneda")
                e.Value = e.ListSourceRowIndex % 2 == 0 ? "USD" : "SOL";
        }
        string FormatDecimal(decimal value)
        {
            return string.Format("{0:n}", value);
        }
    }
}