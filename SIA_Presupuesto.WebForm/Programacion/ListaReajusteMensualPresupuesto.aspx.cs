using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WebForm.Presentador;
using SIA_Presupuesto.WebForm.Vista;
using System;
using System.Collections.Generic;
using System.IO;
using Utilitario.Util;

namespace SIA_Presupuesto.WebForm.Programacion
{
    public partial class ListaReajusteMensualPresupuesto : System.Web.UI.Page, IListaReajusteMensualPresupuestoVista
    {
        private ListaReajusteMensualPresupuestoPresentador listaReajusteMensualPresupuestoPresentador;
        
        public string nomUsuario { get { return Session["nomUsuario"]!=null ? Session["nomUsuario"].ToString() : string.Empty; } }

        public int idUsuario { get { return Session["idUsuario"] != null ? Convert.ToInt32(Session["idUsuario"].ToString()) : 0; } }

        public List<ReajusteMensualPresupuestoPres> listaDatosPrincipales
        {
            set
            {
                this.grvReajuste.DataSource = value;
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

        //public string tipo
        //{
        //    set { cbTipo.Value = value; }
        //    get { return Convert.ToString(cbTipo.Value); }
        //}

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

        protected void Page_Init(object sender, EventArgs e)
        {
            listaReajusteMensualPresupuestoPresentador = new ListaReajusteMensualPresupuestoPresentador(this);
            listaReajusteMensualPresupuestoPresentador.CargarServicios();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["nomUsuario"] == null)
            {
                Response.Redirect("~/Error.htm");
            }

            if(!IsPostBack)
                listaReajusteMensualPresupuestoPresentador.Iniciar();

            Actualizar();
        }
        public void Actualizar()
        {
            grvReajuste.DataBind();
        }

        protected void cpPrincipal_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
        }

        protected void popReporteDireccion_WindowCallback(object source, DevExpress.Web.CallbackEventArgsBase e)
        {
            listaReajusteMensualPresupuestoPresentador.IniciarReporte(0);
        }

        protected void grvRequerimiento_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            string[] parametro = e.Parameters.Split('|');
            anioPresentacion = Convert.ToInt32(parametro[0]);
            mesPresentacion = Convert.ToInt32(parametro[1]);
            grvReajuste.DataBind();
        }

        protected void grvRequerimiento_DataBinding(object sender, EventArgs e)
        {
            listaReajusteMensualPresupuestoPresentador.ObtenerDatosListado();
        }

        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            //int id = Convert.ToInt32(grvReajuste.GetRowValues(grvReajuste.FocusedRowIndex, grvReajuste.KeyFieldName));
            var obj = grvReajuste.GetSelectedFieldValues(grvReajuste.KeyFieldName) == null ? null : grvReajuste.GetSelectedFieldValues(grvReajuste.KeyFieldName);
            int id = Convert.ToInt32(obj[0].ToString());
            string ruta = listaReajusteMensualPresupuestoPresentador.ExportarReajuste(id);
            if(!string.IsNullOrEmpty(ruta))
            {
                string nombreArchivo = "ReajusteMensualPresupuesto.xlsx";
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

        protected void popCalendarioAnual_WindowCallback(object source, DevExpress.Web.CallbackEventArgsBase e)
        {
            listaReajusteMensualPresupuestoPresentador.IniciarCalendario(0);
        }

        protected void popCalendarioAnualCon_WindowCallback(object source, DevExpress.Web.CallbackEventArgsBase e)
        {
            listaReajusteMensualPresupuestoPresentador.IniciarConsolidado(0);
        }
    }
}