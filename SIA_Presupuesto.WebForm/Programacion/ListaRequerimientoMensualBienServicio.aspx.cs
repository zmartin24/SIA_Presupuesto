using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Globalization;

using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.Enumeradores;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WebForm.Helper;
using SIA_Presupuesto.WebForm.Presentador;
using SIA_Presupuesto.WebForm.Vista;

using DevExpress.Web;
using DevExpress.Web.Bootstrap;

using DevExpress.Spreadsheet;
using DevExpress.Spreadsheet.Export;


using Utilitario.Util;
using Seguridad.Modelo;
using DevExpress.XtraEditors;


namespace SIA_Presupuesto.WebForm.Programacion
{
    public partial class ListaRequerimientoMensualBienServicio : System.Web.UI.Page, IListaRequerimientoMensualBienServicioVista
    {
        private ListaRequerimientoMensualBienServicioPresentador olistaRequerimientoMensualBienServicioPresentador;

        public string nomUsuario { get { return Session["nomUsuario"]!=null ? Session["nomUsuario"].ToString() : string.Empty; } }

        public int idUsuario { get { return Session["idUsuario"] != null ? Convert.ToInt32(Session["idUsuario"].ToString()) : 0; } }

        public List<RequerimientoMensualBienServicioPres> listaDatosPrincipales
        {
            set
            {
                this.grvRequerimientoMensual.DataSource = value;
            }
        }

        #region Requerimiento Mensual - Listado

        public List<Anio> listaAniosListado
        {
            set
            {
                cbAnioListado.DataSource = value;
                cbAnioListado.DataBind();
            }
        }

        public List<Mes> listaMesListado
        {
            set
            {
                cbMesListado.DataSource = value;
                cbMesListado.DataBind();                
            }
        }

        public int anioListado
        {
            set { cbAnioListado.Value = value.ToString(); }
            get { return cbAnioListado.Value != null ? Convert.ToInt32(cbAnioListado.Value.ToString()) : 0; }
        }

        public int mesListado
        {
            set { cbMesListado.Value = value.ToString(); }
            get { return cbMesListado.Value != null ? Convert.ToInt32(cbMesListado.Value.ToString()) : 0; }
        }
        

        #endregion

        #region Requerimiento Mensual - Registro

        public List<Direccion> listaDirecciones
        {
            set
            {
                cbDireccionReqMensual.DataSource = value;
                cbDireccionReqMensual.DataBind();
            }
        }

        public List<Subdireccion> listaSubdirecciones
        {
            set
            {
                cbSubdireccionReqMensual.DataSource = value;
                cbSubdireccionReqMensual.DataBind();
            }
        }

        public List<Area> listaAreas
        {
            set
            {
                cbAreaReqMensual.DataSource = value;
                cbAreaReqMensual.DataBind();
            }
        }

        public List<Predeterminado> listaTipoRequerimiento
        {
            set
            {
                this.cbTipoRequerimiento.DataSource = value;
                this.cbTipoRequerimiento.DataBind();
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

        public List<Mes> listaMes
        {
            set
            {
                cbMesRegReqMensual.DataSource = value;
                cbMesRegReqMensual.DataBind();
            }
        }
        public int idReqMenBieSer
        {
            set { Session["idReqMenBieSer"] = value.ToString(); }
            get { return Convert.ToInt32(Session["idReqMenBieSer"].ToString()); }
        }
        public int idDireccion
        {
            set { cbDireccionReqMensual.Value = value.ToString(); }
            get { return Convert.ToInt32(cbDireccionReqMensual.Value.ToString()); }
        }

        public int idSubdireccion
        {
            set { cbSubdireccionReqMensual.Value = value.ToString(); }
            get { return Convert.ToInt32(cbSubdireccionReqMensual.Value.ToString()); }
        }

        public int idArea
        {
            set { 
                cbAreaReqMensual.Value = value.ToString();
                Session["idArea"] = value.ToString();
            }
            get { return Convert.ToInt32(cbAreaReqMensual.Value != null ? cbAreaReqMensual.Value.ToString() : Session["idArea"].ToString()); }
        }

        public int idTipoRequerimiento
        {
            set { cbTipoRequerimiento.Value = value.ToString(); }
            get { return Convert.ToInt32(cbTipoRequerimiento.Value.ToString()); }
        }

        public int idMoneda
        {
            set { cbMoneda.Value = value.ToString(); }
            get { return Convert.ToInt32(cbMoneda.Value.ToString()); }
        }

        public int anio
        {
            set { 
                seAnio.Value = value;
                Session["anio"] = value.ToString();
            }
            get { return Convert.ToInt32(seAnio.Value != null ? seAnio.Value : Session["anio"].ToString()); }
        }

        public int mes
        {
            set { cbMesRegReqMensual.Value = value.ToString(); }
            get { return Convert.ToInt32(cbMesRegReqMensual.Value.ToString()); }
        }

        public string descripcion
        {
            set { txtDescripcion.Text = value; }
            get { return txtDescripcion.Text; }
        }

        public int estado
        {
            set
            {
                hdfValores["estado"] = value.ToString();
            }
            get { return Convert.ToInt32(hdfValores.Count > 0 ? hdfValores["estado"].ToString() : "0"); }
        }

        public bool tieneDetalles
        {
            set
            {
                hdfValores["tieneDetalles"] = value.ToString();
            }
            get { return Convert.ToBoolean(hdfValores.Count > 0 ? hdfValores["tieneDetalles"].ToString() : "0"); }
        }

        public DateTime fechaEmision
        {
            set;
            get;
        }
        //DataTable listaDetalleRequerimientoMigraSession;
        //public List<DetalleRequerimientoMensualBienServcioMigraPoco> listaDetalleRequerimientoMigra
        //{
        //    set
        //    {
        //        this.grvDetalleRequerimientoMigra.DataSource = value;
        //        //this.grvDetalleRequerimientoMigra.DataBind();
        //    }
        //}
        public List<RequerimientoBienServicio> listaRequerimientoBienServicio
        {
            set
            {
                this.grvRequerimientoBienServicio.DataSource = value;
            }
        }
        public string idsReqBieSer
        {
            get; set;
        }
        #endregion

        #region Requerimiento Mensual - Reporte

        public List<Direccion> listaDireccionesReporte
        {
            set
            {
                cbDireccionReporte.DataSource = value;
                cbDireccionReporte.DataBind();
            }
        }

        public List<Subdireccion> listaSubdireccionesReporte
        {
            set
            {
                cbSubdireccionReporte.DataSource = value;
                cbSubdireccionReporte.DataBind();
            }
        }

        public List<Predeterminado> listaTipoRequerimientoReporte
        {
            set
            {
                this.cbRequerimientoReporte.DataSource = value;
                this.cbRequerimientoReporte.DataBind();
            }
        }

        public List<Anio> listaAniosReporte
        {
            set
            {
                cbAnioReporte.DataSource = value;
                cbAnioReporte.DataBind();
            }
        }

        public List<Mes> listaMesReporte
        {
            set
            {
                cbMesReporte.DataSource = value;
                cbMesReporte.DataBind();
            }
        }

        public int idDireccionReporte
        {
            set { cbDireccionReporte.Value = value.ToString(); }
            get { return Convert.ToInt32(cbDireccionReporte.Value.ToString()); }
        }

        public int idSubdireccionReporte
        {
            set { cbSubdireccionReporte.Value = value.ToString(); }
            get { return Convert.ToInt32(cbSubdireccionReporte.Value.ToString()); }
        }

        public string tipoReporte
        {
            set { cbTipoReporte.Value = value.ToString(); }
            get { return cbTipoReporte.Value.ToString(); }
        }

        public int idTipoRequerimientoReporte
        {
            set { cbRequerimientoReporte.Value = value.ToString(); }
            get { return Convert.ToInt32(cbRequerimientoReporte.Value.ToString()); }
        }

        public int anioReporte
        {
            set { cbAnioReporte.Value = value.ToString(); }
            get { return Convert.ToInt32(cbAnioReporte.Value.ToString()); }
        }

        public int mesReporte
        {
            set { cbMesReporte.Value = value.ToString(); }
            get { return Convert.ToInt32(cbMesReporte.Value.ToString()); }
        }
        string FilePath
        {
            get { return Session["FilePath"] == null ? String.Empty : Session["FilePath"].ToString(); }
            set { Session["FilePath"] = value; }
        }
        #endregion        

        decimal usd, soles;
        protected void Page_Init(object sender, EventArgs e)
        {
            olistaRequerimientoMensualBienServicioPresentador = new ListaRequerimientoMensualBienServicioPresentador(this);
            olistaRequerimientoMensualBienServicioPresentador.CargarServicios();
            FilePath = String.Empty;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["nomUsuario"] == null)
            {
                Response.Redirect("~/Error.htm");
            }

            if (!IsPostBack)
            {
                olistaRequerimientoMensualBienServicioPresentador.Iniciar();
                List<OpcionMenuSistemaUsuarioPres> lista = olistaRequerimientoMensualBienServicioPresentador.TraerOpcionPorMenuSistemaUsuario();
                if (lista.Where(x => x.idOpcion == 2317 && x.estadoPerfil == true).FirstOrDefault() == null) btnAprobar.ClientVisible = false; //parqa mostrar boton Aprobar
                if (lista.Where(x => x.idOpcion == 2319 && x.estadoPerfil == true).FirstOrDefault() == null) btnVolver.ClientVisible = false; //parqa mostrar boton volver
            }
            Actualizar();
        }

        public void Actualizar()
        {
            // Si hay un valor en la sesión, seleccionarlo
            if (Session["SelectedValueAnioListado"] != null)
            {
                cbAnioListado.Value = Session["SelectedValueAnioListado"];
            }
            if (Session["SelectedValueMesListado"] != null)
            {
                cbMesListado.Value = Session["SelectedValueMesListado"];
            }

            grvRequerimientoMensual.DataBind();
        }

        protected void cpPrincipal_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            popRequerimientoMensual.JSProperties["cpNombre"] = "Registro de Requerimiento Mensual";

            var args = Util.DeserializeCallbackArgs(e.Parameter);

            if (args.Count == 0)
                return;

            if (args[0] == "Nuevo" || args[0] == "Editar")
            {
                string valor = txtDescripcion.Text;
                idsReqBieSer = string.Empty;
                List<Object> selectItems = new List<object>();
                List<EvaluacionReajusteMensualAreaExporta> lista = new List<EvaluacionReajusteMensualAreaExporta>();

                ASPxGridView grid = grvRequerimientoBienServicio as ASPxGridView;

                selectItems = grid.GetSelectedFieldValues("idReqBieSer");
                if (selectItems.Count > 0)
                {
                    idsReqBieSer = String.Join("~", selectItems);
                }
                
                Resultado resultado = olistaRequerimientoMensualBienServicioPresentador.GuardarDatosRequerimiento(args[2]);
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
                Resultado resultado = olistaRequerimientoMensualBienServicioPresentador.ClonarDatosRequerimiento(args[2]);
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
                if (olistaRequerimientoMensualBienServicioPresentador.AnularRegistro(Convert.ToInt32(args[1])))
                    cpPrincipal.JSProperties["cpMensaje"] = "Anulado correctamente";
                else
                    cpPrincipal.JSProperties["cpMensaje"] = "No se pudo anular";
            }

            cpPrincipal.JSProperties["cpGrid"] = "grvRequerimientoMensual";
            

            //Periodo objPeriodo = olistaRequerimientoMensualBienServicioPresentador.ObtenerxAnio();

            //if (objPeriodo.estado == "A")
            //{
            //    btnNuevo.Enabled = true;
            //    btnEditar.Enabled = true;
            //    btnAnular.Enabled = true;
            //    btnDetalle.Enabled = true;
            //}
            //else
            //{
            //    if (objPeriodo.estado == "C")
            //    {
            //        btnNuevo.Enabled = false;
            //        btnEditar.Enabled = false;
            //        btnAnular.Enabled = false;
            //        btnDetalle.Enabled = false;
            //    }
            //}
        }
        
        protected void cbSubdireccionReqMensual_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            olistaRequerimientoMensualBienServicioPresentador.LlenarCombosSubdireccion(Convert.ToInt32(e.Parameter));
        }

        protected void cbSubdireccionReporte_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            olistaRequerimientoMensualBienServicioPresentador.LlenarCombosSubdireccionReporte(Convert.ToInt32(e.Parameter));
        }

        protected void cbAreaReqMensual_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            olistaRequerimientoMensualBienServicioPresentador.LlenarCombosAreas(Convert.ToInt32(e.Parameter));
        }

        protected void popReporteDireccion_WindowCallback(object source, DevExpress.Web.CallbackEventArgsBase e)
        {
            olistaRequerimientoMensualBienServicioPresentador.IniciarReporte(0);
        }

        protected void grvRequerimientoMensual_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            string[] parametro = e.Parameters.Split('|');
            Session["SelectedValueAnioListado"] = parametro[0];
            Session["SelectedValueMesListado"] = parametro[1];
            anioListado = Convert.ToInt32(Session["SelectedValueAnioListado"].ToString());  //Convert.ToInt32(parametro[0]);
            mesListado = Convert.ToInt32(Session["SelectedValueMesListado"].ToString());  //Convert.ToInt32(parametro[1]);
                     
            grvRequerimientoMensual.DataBind();
        }

        protected void grvRequerimientoMensual_DataBinding(object sender, EventArgs e)
        {
            olistaRequerimientoMensualBienServicioPresentador.ObtenerDatosListado();         
        }

        protected void popRequerimientoMensual_WindowCallback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            var args = e.Parameter.Split('|');
            idReqMenBieSer = 0;
            string opcion = string.Empty;

            switch (args[0])
            {
                case "Nuevo":
                    
                    olistaRequerimientoMensualBienServicioPresentador.IniciarDatosRequerimiento(0);
                    idArea = 0;// Convert.ToInt32(Session["idArea"].ToString());
                    grvRequerimientoBienServicio.FilterExpression = string.Empty;
                    grvRequerimientoBienServicio.DataSource = null;
                    grvRequerimientoBienServicio.DataBind();

                    opcion = "Nuevo";
                    break;
                case "Editar":
                    idReqMenBieSer = !string.IsNullOrEmpty(args[1]) ? int.Parse(args[1]) : 0;

                    olistaRequerimientoMensualBienServicioPresentador.IniciarDatosRequerimiento(idReqMenBieSer);
                    if (tieneDetalles)
                    {
                        cbMoneda.ClientReadOnly = true;
                        cbTipoRequerimiento.ClientReadOnly = true;
                    }
                    if(estado== 10 || estado==59)
                    {
                        SoloLecturaControlesPopRequerimientoMensual(true);
                    }
                    opcion = "Editar";
                    break;
                case "Clonar":
                    idReqMenBieSer = !string.IsNullOrEmpty(args[1]) ? int.Parse(args[1]) : 0;// Es el IdReqMenBieSer Origen
                    olistaRequerimientoMensualBienServicioPresentador.IniciarDatosRequerimientoClonar(idReqMenBieSer);
                    //seAnio.ClientEnabled = false;
                    cbTipoRequerimiento.ClientEnabled = false;
                    opcion = "Clonar";
                    break;
                case "Mostrar":
                    idReqMenBieSer = !string.IsNullOrEmpty(args[1]) ? int.Parse(args[1]) : 0;
                    olistaRequerimientoMensualBienServicioPresentador.IniciarDatosRequerimiento(idReqMenBieSer);
                    SoloLecturaControlesPopRequerimientoMensual(true);
                    opcion = "Mostrar";
                    break;
            }
            popRequerimientoMensual.JSProperties["cpID"] = idReqMenBieSer;
            popRequerimientoMensual.JSProperties["cpOpcion"] = opcion;
        }

        protected void btnAprobar_Click(object sender, EventArgs e)
        {
            var objId = grvRequerimientoMensual.GetSelectedFieldValues(grvRequerimientoMensual.KeyFieldName) == null ? null : grvRequerimientoMensual.GetSelectedFieldValues(grvRequerimientoMensual.KeyFieldName);
            var objEstado = grvRequerimientoMensual.GetSelectedFieldValues(grvRequerimientoMensual.KeyFieldName) == null ? null : grvRequerimientoMensual.GetSelectedFieldValues("estado");
            if(objId == null || objEstado ==null) return;
            
            int idReqMenBieSer = Convert.ToInt32(objId[0].ToString());
            int estado = Convert.ToInt32(objEstado[0].ToString());
            olistaRequerimientoMensualBienServicioPresentador.IniciarDatosRequerimiento(idReqMenBieSer);
            if (!tieneDetalles) return;

            if (estado == 10 || estado == 59)
            {
                EmitirMensajeResultado("Error: no es posisble aprobar, requerimiento ya fue procesado");
                return;
            }

            if (this.olistaRequerimientoMensualBienServicioPresentador.AsignarEstadoRequerimiento(idReqMenBieSer, Estados.Aprobado))
            {
                EmitirMensajeResultado("Se aprobó correctamente");

            }
            else
                EmitirMensajeResultado("Error al procesar requerimiento");
            Actualizar();
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            var objId = grvRequerimientoMensual.GetSelectedFieldValues(grvRequerimientoMensual.KeyFieldName) == null ? null : grvRequerimientoMensual.GetSelectedFieldValues(grvRequerimientoMensual.KeyFieldName);
            var objEstado = grvRequerimientoMensual.GetSelectedFieldValues(grvRequerimientoMensual.KeyFieldName) == null ? null : grvRequerimientoMensual.GetSelectedFieldValues("estado");
            if (objId == null || objEstado == null) return;

            int idReqMenBieSer = Convert.ToInt32(objId[0].ToString());
            int estado = Convert.ToInt32(objEstado[0].ToString());

            if (estado == 2) return;
            if (estado == 59)
            {
                EmitirMensajeResultado("Error: no es posisble anular aprobación, requerimiento ya fue asignado un presupuesto");
                return;
            }

            if (this.olistaRequerimientoMensualBienServicioPresentador.AsignarEstadoRequerimiento(idReqMenBieSer, Estados.Activo))
            {
                EmitirMensajeResultado("Se volvió a registrado correctamente");

            }
            else
                EmitirMensajeResultado("Error al procesar requerimiento");
            Actualizar();

        }

        protected void GridViewCustomSummary_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
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
                    string currency = e.GetValue("idMoneda").ToString();
                    if (currency == "64")
                        usd += Convert.ToDecimal(e.GetValue("total"));
                    else if (currency == "63")
                        soles += Convert.ToDecimal(e.GetValue("total"));
                }
                else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
                {
                    e.TotalValue = string.Format("S/{0}; ${1}", FormatDecimal(soles), FormatDecimal(usd));
                }
            }
        }
        protected void GridViewCustomSummary_CustomUnboundColumnData(object sender, DevExpress.Web.Bootstrap.BootstrapGridViewColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "idMoneda")
                e.Value = e.ListSourceRowIndex % 2 == 0 ? "USD" : "SOL";
        }
        protected void GrvRequerimientoBienServicioAPI_CustomJSProperties(object sender, ASPxGridViewClientJSPropertiesEventArgs e)
        {
            e.Properties["cpVisibleRowCount"] = grvRequerimientoBienServicio.VisibleRowCount;

        }
        //Combos de detalles
        protected void cbTipoRequerimiento_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            var parametro = Convert.ToInt32(e.Parameter);
        }
        protected void cbMesRegReqMensual_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            var parametro = Convert.ToInt32(e.Parameter);
        }
        
        protected void GrvRequerimientoBienServicio_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            string[] parametro = e.Parameters.Split('|');

            idTipoRequerimiento = Convert.ToInt32(parametro[0]);
            anio = parametro[0] == null || parametro[1].ToString() == "0" ? Convert.ToInt32(Session["anio"].ToString()) : Convert.ToInt32(parametro[1]);
            mes = Convert.ToInt32(parametro[2]);

            Session["idArea"] = parametro[3];
            idArea = Convert.ToInt32(Session["idArea"].ToString());

            grvRequerimientoBienServicio.DataBind();
        }
        protected void GrvRequerimientoBienServicio_DataBinding(object sender, EventArgs e)
        {
            this.olistaRequerimientoMensualBienServicioPresentador.CargarRequerimientosAnualesBienesServicios();
        }
        protected void SeAnio_ValueChanged(object sender, EventArgs e)
        {
            // Obtén el valor actual del BootstrapSpinEdit
            decimal spinValue = Convert.ToDecimal(seAnio.Value!= null ? seAnio.Value.ToString() : "0");

            // Almacena el valor en una variable de sesión
            Session["anio"] = spinValue;

            grvRequerimientoBienServicio.DataBind();

            // (Opcional) Realiza otras acciones relacionadas
            //Response.Write($"Valor guardado en sesión: {spinValue}");
        }
        string FormatDecimal(decimal value)
        {
            return string.Format("{0:n}", value);
        }
        private void SoloLecturaControlesPopRequerimientoMensual(bool esVisible)
        {
            cbDireccionReqMensual.ClientReadOnly = esVisible;
            cbSubdireccionReqMensual.ClientReadOnly = esVisible;
            cbAreaReqMensual.ClientReadOnly = esVisible;
            txtDescripcion.ClientReadOnly = esVisible;
            cbMoneda.ClientReadOnly = esVisible;
            cbTipoRequerimiento.ClientReadOnly = esVisible;
            seAnio.ClientReadOnly = esVisible;
            cbMesRegReqMensual.ClientReadOnly = esVisible;
        }

        private void EmitirMensajeResultado(string mensaje)
        {
            BootstrapPopupControl popup = (BootstrapPopupControl)cpPrincipal.FindControl("popInformacion");
            popup.Text = mensaje;
            popup.ShowOnPageLoad = true;
        }
    }
}