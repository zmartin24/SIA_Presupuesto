using DevExpress.Web;
using Seguridad.Modelo;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WebForm.Helper;
using SIA_Presupuesto.WebForm.Presentador;
using SIA_Presupuesto.WebForm.Vista;
using System;
using System.Collections.Generic;
using Utilitario.Util;

namespace SIA_Presupuesto.WebForm.Programacion
{
    public partial class frmRequerimientoRecursoHumano : System.Web.UI.Page, IRequerimientoRecursoHumanoVista
    {
        private RequerimientoRecursoHumanoPresentador requerimientoRecursoHumanoPresentador;

        public List<RequerimientoRecursoHumanoDetallePres> listaDatosPrincipales
        {
            set
            {
                this.grvReqDet.DataSource = value;
                this.grvReqDet.DataBind();
            }
        }

        public string nomUsuario { get { return Session["nomUsuario"] != null ? Session["nomUsuario"].ToString() : string.Empty; } }

        
        public int idReqRecHum
        {
            set { hdfValores["idReqRecHum"] = value.ToString(); }
            get { return Convert.ToInt32(hdfValores["idReqRecHum"]); }
        }

        public string descripcion
        {
            set { lblDescripcion.Text = value.ToString(); }
        }

        public int idTrabajador
        {
            set { hdfValores["idTrabajador"] = value.ToString(); }
            get { return Convert.ToInt32(hdfValores["idTrabajador"]); }
        }

        public string desPersonal
        {
            set { txtPersonal.Text = value; }
            get { return txtPersonal.Text; }
        }
        public List<TrabajadorPres> listaTrabajador
        {
            set
            {
                this.grvPersonal.DataSource = value;
            }
            
        }

        public List<CargoPres> listaCargos
        {
            set
            {
                this.grvCargo.DataSource = value;
            }
        }

        public List<CargoPres> listaCargosPro
        {
            get; set;
        }

        public List<SedeLaboral> listaSedes
        {
            set
            {
                this.cbSede.DataSource = value;
                this.cbSede.DataBind();
            }
        }

        public List<Moneda> listaMonedas
        {
            set
            {
                this.cbMoneda.DataSource = value;
                this.cbMoneda.DataBind();
            }
        }

        public List<DatoRegimenLaboral> listaRegimelLaboral
        {
            set
            {
                this.cbRegLab.DataSource = value;
                this.cbRegLab.DataBind();
            }
        }

        public List<DatoCategoriaLaboral> listaCategoriaLaboral
        {
            set
            {
                this.cbCatLab.DataSource = value;
                this.cbCatLab.DataBind();
            }
        }

        public List<DatoCondicionLaboral> listaCondicionLaboral
        {
            set
            {
                this.cbConLab.DataSource = value;
                this.cbConLab.DataBind();
            }
        }

        public List<FuenteFinanciamiento> listaFuenteFinanciamiento
        {
            set
            {
                this.cbFueFin.DataSource = value;
                this.cbFueFin.DataBind();
            }
        }
        
        public int idRegLab
        {
            set { cbRegLab.Value = value.ToString(); }
            get { return Convert.ToInt32(cbRegLab.Value.ToString()); }
        }

        public int idCatLab
        {
            set { cbCatLab.Value = value.ToString(); }
            get { return Convert.ToInt32(cbCatLab.Value.ToString()); }
        }

        public int idConLab
        {
            set { cbConLab.Value = value.ToString(); }
            get { return Convert.ToInt32(cbConLab.Value.ToString()); }
        }

        public int idSede
        {
            set { cbSede.Value = value.ToString(); }
            get { return Convert.ToInt32(cbSede.Value.ToString()); }
        }

        public int idMoneda
        {
            set { cbMoneda.Value = value.ToString(); }
            get { return Convert.ToInt32(cbMoneda.Value.ToString()); }
        }
        public int idCargo
        {
            set { hdfValores["idCargo"] = value.ToString(); }
            get { return Convert.ToInt32(hdfValores["idCargo"]); }
        }
        public string desCargo
        {
            set { txtCargo.Text = value; }
            get { return txtCargo.Text; }
        }
        public int grado
        {
            set { seGrado.Value = value; }
            get { return Convert.ToInt32(seGrado.Value); }
        }

        public decimal remuneracion
        {
            set { seRemuneracion.Value = value; }
            get { return Convert.ToDecimal(seRemuneracion.Value); }
        }

        public int idCargoPropuesto
        {
            get;set;
        }
        public int gradoPropuesto
        {
            get; set;
        }

        public decimal remPropuesta
        {
            get; set;
        }

        public bool esVacante
        {
            set {
                ceEsVacante.Checked = value;
                seCantVacante.ClientEnabled = esVacante;
            }
            get { return ceEsVacante.Checked; }
            
        }

        public int cantVacante
        {
            set { seCantVacante.Value = value; }
            get { return Convert.ToInt32(seCantVacante.Value); }
        }

        public bool esRemDiaria
        {
            set { ceEsRemDiaria.Checked = value; }
            get { return ceEsRemDiaria.Checked; }
        }

        public string justificacion
        {
            set { txtJustificacion.Text = value; }
            get { return txtJustificacion.Text; }
        }

        public int idFueFin
        {
            set { cbFueFin.Value = value.ToString(); }
            get { return Convert.ToInt32(cbFueFin.Value.ToString()); }
        }

        public string observacion
        {
            set { txtObservacion.Text = value; }
            get { return txtObservacion.Text; }
        }
        public DateTime fechaInicio
        {
            set { defechaInicio.Date = value; }
            get { return Convert.ToDateTime(defechaInicio.Value.ToString()); }
        }
        public DateTime fechaTermino
        {
            set { defechaTermino.Value = value; }
            get { return Convert.ToDateTime(defechaTermino.Value.ToString()); }
        }


        protected void Page_Init(object sender, EventArgs e)
        {
            requerimientoRecursoHumanoPresentador = new RequerimientoRecursoHumanoPresentador(this);
            requerimientoRecursoHumanoPresentador.CargarServicios();
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["nomUsuario"]==null)
            {
                Response.Redirect("~/Error.htm");
            }

            if (!IsPostBack)
            {
                hdfValores.Add("idReqRecHum", Request.Params.Get("idReqRecHum"));
                hdfValores["idTrabajador"] = 0;
                hdfValores["idCargo"] = 0;
            }
            Actualizar();
        }
        public void Actualizar()
        {
            requerimientoRecursoHumanoPresentador.Iniciar();
            grvReqDet.ExpandAll();
        }

        protected void cpPrincipal_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            popPuestoReq.JSProperties["cpNombre"] = "Registro de Personal";

            var args = Util.DeserializeCallbackArgs(e.Parameter);
            if (args.Count == 0)
                return;

            //if (args[0] == "Guardar")
            if (args[0] == "Nuevo" || args[0] == "Editar")
            {
                Resultado resultado = requerimientoRecursoHumanoPresentador.GuardarDatos(args[2]);
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
            else if (args[0] == "Anular")
            {

                if (requerimientoRecursoHumanoPresentador.Anular(Convert.ToInt32(args[1])))
                    cpPrincipal.JSProperties["cpMensaje"] = "Anulado correctamente";
                else
                    cpPrincipal.JSProperties["cpMensaje"] = "No se pudo anular";
            }
            cpPrincipal.JSProperties["cpGrid"] = "grvReqDet";

        }
        void AddError(Dictionary<GridViewColumn, string> errors, GridViewColumn column, string errorText)
        {
            if (errors.ContainsKey(column)) return;
            errors[column] = errorText;
        }
        protected void grvReqDet_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            if (!grvReqDet.IsNewRowEditing)
            {
                grvReqDet.DoRowValidation();
            }
        }
        protected void popPuestoReq_Callback(object sender, CallbackEventArgsBase e)
        {
            var args = e.Parameter.Split('|');
            int id = 0;
            string opcion = string.Empty;
            switch (args[0])
            {
                case "Nuevo":
                    requerimientoRecursoHumanoPresentador.IniciarDatos(0);
                    opcion = "Nuevo";
                    break;
                case "Editar":
                    id = !string.IsNullOrEmpty(args[1]) ? int.Parse(args[1]) : 0;
                    requerimientoRecursoHumanoPresentador.IniciarDatos(id);
                    opcion = "Editar";
                    break;
                case "Mostrar":
                    id = !string.IsNullOrEmpty(args[1]) ? int.Parse(args[1]) : 0;
                    requerimientoRecursoHumanoPresentador.IniciarDatos(id);
                    opcion = "Mostrar";
                    break;
            }
            popPuestoReq.JSProperties["cpID"] = id;
            popPuestoReq.JSProperties["cpOpcion"] = opcion;
        }
        protected void grvPersonal_DataBinding(object sender, EventArgs e)
        {
            requerimientoRecursoHumanoPresentador.ListaTrabajadores(Convert.ToInt32(hdfValores["idReqRecHum"]));
        }
        protected void grvCargo_DataBinding(object sender, EventArgs e)
        {
            requerimientoRecursoHumanoPresentador.ListaCargos();
        }
        protected void grvPersonal_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            string[] parametro = e.Parameters.Split('|');
            grvPersonal.DataBind();
        }
        protected void grvCargo_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            grvCargo.DataBind();
        }
        protected void popAyudaPersonal_WindowCallback(object source, DevExpress.Web.CallbackEventArgsBase e)
        {
            grvPersonal.DataBind();
        }
        protected void popAyudaCargo_WindowCallback(object source, DevExpress.Web.CallbackEventArgsBase e)
        {
            grvCargo.DataBind();
        }
        protected void capPersonal_Callback(object sender, CallbackEventArgsBase e)
        {
            grvPersonal.DataBind();
        }
        protected void capCargo_Callback(object sender, CallbackEventArgsBase e)
        {
            grvCargo.DataBind();
        }
    }
}