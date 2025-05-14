using Seguridad.Modelo;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WebForm.Helper;
using SIA_Presupuesto.WebForm.Presentador;
using SIA_Presupuesto.WebForm.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitario.Util;

namespace SIA_Presupuesto.WebForm.Programacion
{
    public partial class ListaRequerimientoRecursoHumano : System.Web.UI.Page, IListaRequerimientoRecursoHumanoVista
    {
        private ListaRequerimientoRecursoHumanoPresentador listaRequerimientoRecursoHumanoPresentador;

        public string nomUsuario { get { return Session["nomUsuario"]!=null ? Session["nomUsuario"].ToString() : string.Empty; } }

        public int idUsuario { get { return Session["idUsuario"] != null ? Convert.ToInt32(Session["idUsuario"].ToString()) : 0; } }

        public List<RequerimientoRecursoHumanoPres> listaDatosPrincipales
        {
            set
            {
                this.grvReqRecursosHumanos.DataSource = value;
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
            set { cbAnioPeriodo.Value = value; }
            get { return Convert.ToInt32(cbAnioPeriodo.Value); }
        }

        public List<Subdireccion> listaSubdirecciones
        {
            set
            {
                cbSubdireccion.DataSource = value;
                cbSubdireccion.DataBind();
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
            //set { deFechaEmision.Value = value; }
            //get { return Convert.ToDateTime(deFechaEmision.Value); }
            set;
            get;
        }

        /**Interface reporte con importe**/
        public List<Direccion> listaDireccionesReporteImp
        {
            set
            {
                cbDireccionReporteImp.DataSource = value;
                cbDireccionReporteImp.DataBind();
            }
        }

        public List<Periodo> listaAnioReporteImp
        {
            set
            {
                cbAnioPeriodoImp.DataSource = value;
                cbAnioPeriodoImp.DataBind();
            }
        }
        public List<Subdireccion> listaSubdireccionesReporteImp
        {
            set
            {
                cbSubdireccionReporteImp.DataSource = value;
                cbSubdireccionReporteImp.DataBind();
            }
        }
        public List<Moneda> listaMonedasReporteImp
        {
            set
            {
                cbMonedaReporteImp.DataSource = value;
                cbMonedaReporteImp.DataBind();
            }
        }
        public int anioReporteImp
        {
            set { cbAnioPeriodoImp.Value = value.ToString(); }
            get { return cbAnioPeriodoImp.Value != null ? Convert.ToInt32(cbAnioPeriodoImp.Value.ToString()) : 0; }
        }
        public int idMonedaReporteImp
        {
            set { cbMonedaReporteImp.Value = value.ToString(); }
            get { return Convert.ToInt32(cbMonedaReporteImp.Value.ToString()); }
        }
        public int idDireccionReporteImp
        {
            set { cbDireccionReporteImp.Value = value.ToString(); }
            get { return Convert.ToInt32(cbDireccionReporteImp.Value.ToString()); }
        }
        public int idSubdireccionReporteImp
        {
            set { cbSubdireccionReporteImp.Value = value.ToString(); }
            get { return Convert.ToInt32(cbSubdireccionReporteImp.Value.ToString()); }
        }



        protected void Page_Init(object sender, EventArgs e)
        {
            listaRequerimientoRecursoHumanoPresentador = new ListaRequerimientoRecursoHumanoPresentador(this);
            listaRequerimientoRecursoHumanoPresentador.CargarServicios();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["nomUsuario"] == null)
            {
                Response.Redirect("~/Error.htm");
            }

            if(!IsPostBack)
                listaRequerimientoRecursoHumanoPresentador.Iniciar();

            Actualizar();
        }
        public void Actualizar()
        {
            grvReqRecursosHumanos.DataBind();
        }

        protected void cpPrincipal_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            popRequerimiento.JSProperties["cpNombre"] = "Registro de Requerimiento";

            var args = Util.DeserializeCallbackArgs(e.Parameter);

            if (args.Count == 0)
                return;

            if (args[0] == "Nuevo" || args[0] == "Editar") //if (args[0] == "Guardar")
            {
                string valor = txtDescripcion.Text;

                Resultado resultado = listaRequerimientoRecursoHumanoPresentador.GuardarDatosRequerimiento(args[2]);
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

                if (listaRequerimientoRecursoHumanoPresentador.AnularRegistro(Convert.ToInt32(args[1])))
                    cpPrincipal.JSProperties["cpMensaje"] = "Anulado correctamente";
                else
                    cpPrincipal.JSProperties["cpMensaje"] = "No se pudo anular";
            }

            cpPrincipal.JSProperties["cpGrid"] = "grvReqRecursosHumanos";

            Periodo objPeriodo = listaRequerimientoRecursoHumanoPresentador.ObtenerxAnio();


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

        protected void cbSubdireccion_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            listaRequerimientoRecursoHumanoPresentador.LlenarCombosSubdireccion(Convert.ToInt32(e.Parameter), false);
        }
        protected void cbSubdireccionReporte_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            listaRequerimientoRecursoHumanoPresentador.LlenarCombosSubdireccion(Convert.ToInt32(e.Parameter), true);
        }


        protected void cbArea_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            listaRequerimientoRecursoHumanoPresentador.LlenarCombosAreas(Convert.ToInt32(e.Parameter));
        }
        protected void popReporteDireccion_WindowCallback(object source, DevExpress.Web.CallbackEventArgsBase e)
        {
            listaRequerimientoRecursoHumanoPresentador.IniciarReporte(0);
        }
        protected void grvRequerimiento_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            anioPresentacion = Convert.ToInt32(e.Parameters);
            grvReqRecursosHumanos.DataBind();
        }

        protected void grvRequerimiento_DataBinding(object sender, EventArgs e)
        {
            listaRequerimientoRecursoHumanoPresentador.ObtenerDatosListado();
        }

        protected void popRequerimiento_WindowCallback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            var args = e.Parameter.Split('|');
            int id = 0;
            string opcion = string.Empty;
            switch (args[0])
            {
                case "Nuevo":
                    listaRequerimientoRecursoHumanoPresentador.IniciarDatosRequerimiento(0);
                    opcion = "Nuevo";
                    break;
                case "Editar":
                    opcion = "Editar";
                    id = !string.IsNullOrEmpty(args[1]) ? int.Parse(args[1]) : 0;
                    listaRequerimientoRecursoHumanoPresentador.IniciarDatosRequerimiento(id);
                    break;
                case "Mostrar":
                    id = !string.IsNullOrEmpty(args[1]) ? int.Parse(args[1]) : 0;
                    listaRequerimientoRecursoHumanoPresentador.IniciarDatosRequerimiento(id);
                    opcion = "Mostrar";
                    break;
            }
            popRequerimiento.JSProperties["cpID"] = id;
            popRequerimiento.JSProperties["cpOpcion"] = opcion;
        }

        /**PopReporte con importes**/
        protected void popReporteDireccionImp_WindowCallback(object source, DevExpress.Web.CallbackEventArgsBase e)
        {
            this.listaRequerimientoRecursoHumanoPresentador.IniciarReporteImporte();
        }
        protected void cbSubdireccionReporteImp_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            this.listaRequerimientoRecursoHumanoPresentador.LlenarCombosSubdireccionReporteImp(Convert.ToInt32(e.Parameter));
        }
    }
}