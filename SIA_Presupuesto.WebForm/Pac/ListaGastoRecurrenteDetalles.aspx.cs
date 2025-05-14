using DevExpress.Web;
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

namespace SIA_Presupuesto.WebForm.Pac
{
    public partial class ListaGastoRecurrenteDetalles : System.Web.UI.Page, IListaGastoRecurrenteDetalleVista
    {
        private ListaGastoRecurrenteDetallePresentador listaGastoRecurrenteDetallePresentador;
        public List<GastoRecurrenteRequerimientoPres> listaDatosPrincipales
        {
            set
            {
                this.grvGastoRecurrenteDet.DataSource = value;
                this.grvGastoRecurrenteDet.DataBind();
            }
        }
        
        public string nomUsuario { get { return Session["nomUsuario"] != null ? Session["nomUsuario"].ToString() : string.Empty; } }

        public int idGasRec
        {
            set { hdfValores["idGasRec"] = value.ToString(); }
            get { return Convert.ToInt32(hdfValores["idGasRec"]); }
        }

        public int idProducto
        {
            set { hdfValores["idProducto"] = value.ToString(); }
            get { return Convert.ToInt32(hdfValores["idProducto"]); }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            listaGastoRecurrenteDetallePresentador = new ListaGastoRecurrenteDetallePresentador(this);
            listaGastoRecurrenteDetallePresentador.CargarServicios();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["nomUsuario"]==null)
            {
                Response.Redirect("~/Error.htm");
            }

            if (!IsPostBack)
            {
                hdfValores.Add("idGasRec", Request.Params.Get("idGasRec"));
                hdfValores["idProducto"] = 0;
            }
            Actualizar();
        }

        
        public void Actualizar()
        {
            listaGastoRecurrenteDetallePresentador.Iniciar();
            grvGastoRecurrenteDet.ExpandAll();
        }

        protected void cpPrincipal_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            //popReqDet.JSProperties["cpNombre"] = "Registro de Requerimiento";

            //var args = Util.DeserializeCallbackArgs(e.Parameter);
            //if (args.Count == 0)
            //    return;

            //if (args[0] == "Guardar")
            //{
            //    Resultado resultado = listaGastoRecurrenteDetallePresentador.GuardarDatos(args[2]);
            //    if (resultado != null)
            //    {
            //        if (resultado.esCorrecto)
            //            cpPrincipal.JSProperties["cpMensaje"] = string.Format(resultado.mensajeMostrar, " el requerimiento", resultado.id);
            //        else
            //            cpPrincipal.JSProperties["cpMensaje"] = "Error: " + resultado.mensajeMostrar;
            //    }
            //    else
            //        cpPrincipal.JSProperties["cpMensaje"] = "A ocurrido un error";
            //}
            //else if (args[0] == "Anular")
            //{

            //    if (pacDetallePresentador.AnularArea(Convert.ToInt32(args[1])))
            //        cpPrincipal.JSProperties["cpMensaje"] = "Anulado correctamente";
            //    else
            //        cpPrincipal.JSProperties["cpMensaje"] = "No se pudo anular";
            //}
            cpPrincipal.JSProperties["cpGrid"] = "grvGastoRecurrenteDet";

        }

        protected void popReqDet_WindowCallback(object source, DevExpress.Web.PopupWindowCallbackArgs e)
        {
            var args = e.Parameter.Split('|');
            int id = 0;
            switch (args[0])
            {
                case "Nuevo":
                    listaGastoRecurrenteDetallePresentador.IniciarDatos(0);
                    break;
                case "Editar":
                    id = !string.IsNullOrEmpty(args[1]) ? int.Parse(args[1]) : 0;
                    listaGastoRecurrenteDetallePresentador.IniciarDatos(id);
                    break;
                case "Mostrar":
                    id = !string.IsNullOrEmpty(args[1]) ? int.Parse(args[1]) : 0;
                    listaGastoRecurrenteDetallePresentador.IniciarDatos(id);
                    break;
            }
            grvGastoRecurrenteDet.JSProperties["cpID"] = id;
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("ListaGastoRecurrente.aspx", idGasRec));
        }

        protected void grvReqDet_RowUpdated(object sender, DevExpress.Web.Data.ASPxDataUpdatedEventArgs e)
        {
            
        }

        protected void grvReqDet_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            ASPxGridView grid = sender as ASPxGridView;
            int id = (Int32)e.Keys[0];

            //Enero
            if (e.NewValues["cantEnero"] != e.OldValues["cantEnero"])
            {
                Decimal enero = e.NewValues["cantEnero"] != null ? Convert.ToDecimal(e.NewValues["cantEnero"]) : 0.0m;
                //pacDetallePresentador.IngresarCantidadDetalle(id, 1, enero);
            }

            //Febrero
            if (e.NewValues["cantFebrero"] != e.OldValues["cantFebrero"])
            {
                Decimal enero = e.NewValues["cantFebrero"] != null ? Convert.ToDecimal(e.NewValues["cantFebrero"]) : 0.0m;
                //pacDetallePresentador.IngresarCantidadDetalle(id, 2, enero);
            }

            //Marzo
            if (e.NewValues["cantMarzo"] != e.OldValues["cantMarzo"])
            {
                Decimal enero = e.NewValues["cantMarzo"] != null ? Convert.ToDecimal(e.NewValues["cantMarzo"]) : 0.0m;
                //pacDetallePresentador.IngresarCantidadDetalle(id, 3, enero);
            }

            //Abril
            if (e.NewValues["cantAbril"] != e.OldValues["cantAbril"])
            {
                Decimal enero = e.NewValues["cantAbril"] != null ? Convert.ToDecimal(e.NewValues["cantAbril"]) : 0.0m;
                //pacDetallePresentador.IngresarCantidadDetalle(id, 4, enero);
            }

            //Mayo
            if (e.NewValues["cantMayo"] != e.OldValues["cantMayo"])
            {
                Decimal enero = e.NewValues["cantMayo"] != null ? Convert.ToDecimal(e.NewValues["cantMayo"]) : 0.0m;
                //pacDetallePresentador.IngresarCantidadDetalle(id, 5, enero);
            }

            //Junio
            if (e.NewValues["cantJunio"] != e.OldValues["cantJunio"])
            {
                Decimal enero = e.NewValues["cantJunio"] != null ? Convert.ToDecimal(e.NewValues["cantJunio"]) : 0.0m;
                //pacDetallePresentador.IngresarCantidadDetalle(id, 6, enero);
            }

            //Julio
            if (e.NewValues["cantJulio"] != e.OldValues["cantJulio"])
            {
                Decimal enero = e.NewValues["cantJulio"] != null ? Convert.ToDecimal(e.NewValues["cantJulio"]) : 0.0m;
                //pacDetallePresentador.IngresarCantidadDetalle(id, 7, enero);
            }

            //Agosto
            if (e.NewValues["cantAgosto"] != e.OldValues["cantAgosto"])
            {
                Decimal enero = e.NewValues["cantAgosto"] != null ? Convert.ToDecimal(e.NewValues["cantAgosto"]) : 0.0m;
                //pacDetallePresentador.IngresarCantidadDetalle(id, 8, enero);
            }
            //Setiembre
            if (e.NewValues["cantSetiembre"] != e.OldValues["cantSetiembre"])
            {
                Decimal enero = e.NewValues["cantSetiembre"] != null ? Convert.ToDecimal(e.NewValues["cantSetiembre"]) : 0.0m;
                //pacDetallePresentador.IngresarCantidadDetalle(id, 9, enero);
            }
            //Octubre
            if (e.NewValues["cantOctubre"] != e.OldValues["cantOctubre"])
            {
                Decimal enero = e.NewValues["cantOctubre"] != null ? Convert.ToDecimal(e.NewValues["cantOctubre"]) : 0.0m;
                //pacDetallePresentador.IngresarCantidadDetalle(id, 10, enero);
            }
            //Noviembre
            if (e.NewValues["cantNoviembre"] != e.OldValues["cantNoviembre"])
            {
                Decimal enero = e.NewValues["cantNoviembre"] != null ? Convert.ToDecimal(e.NewValues["cantNoviembre"]) : 0.0m;
                //pacDetallePresentador.IngresarCantidadDetalle(id, 11, enero);
            }
            //Diciembre
            if (e.NewValues["cantDiciembre"] != e.OldValues["cantDiciembre"])
            {
                Decimal enero = e.NewValues["cantDiciembre"] != null ? Convert.ToDecimal(e.NewValues["cantDiciembre"]) : 0.0m;
                //pacDetallePresentador.IngresarCantidadDetalle(id, 12, enero);
            }

            e.Cancel = true;
            grid.CancelEdit();
        }

        protected void grvReqDet_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {
            //Validación de enero
            decimal enero = e.NewValues["cantEnero"] != null ? (decimal)e.NewValues["cantEnero"] : 0;
            if (enero < 0)
            {
                AddError(e.Errors, grvGastoRecurrenteDet.Columns["cantEnero"], "La cantidad debe ser mayor o igual a cero");
            }

            //Validación de febrero
            decimal febrero = e.NewValues["cantFebrero"] != null ? (decimal)e.NewValues["cantFebrero"] : 0;
            if (febrero < 0)
            {
                AddError(e.Errors, grvGastoRecurrenteDet.Columns["cantFebrero"], "La cantidad debe ser mayor o igual a cero");
            }

            //Validación de marzo
            decimal marzo = e.NewValues["cantMarzo"] != null ? (decimal)e.NewValues["cantMarzo"] : 0;
            if (marzo < 0)
            {
                AddError(e.Errors, grvGastoRecurrenteDet.Columns["cantMarzo"], "La cantidad debe ser mayor o igual a cero");
            }

            //Validación de abril
            decimal abril = e.NewValues["cantAbril"] != null ? (decimal)e.NewValues["cantAbril"] : 0;
            if (abril < 0)
            {
                AddError(e.Errors, grvGastoRecurrenteDet.Columns["cantAbril"], "La cantidad debe ser mayor o igual a cero");
            }

            //Validación de mayo
            decimal mayo = e.NewValues["cantMayo"] != null ? (decimal)e.NewValues["cantMayo"] : 0;
            if (mayo < 0)
            {
                AddError(e.Errors, grvGastoRecurrenteDet.Columns["cantMayo"], "La cantidad debe ser mayor o igual a cero");
            }

            //Validación de junio
            decimal junio = e.NewValues["cantJunio"] != null ? (decimal)e.NewValues["cantJunio"] : 0;
            if (junio < 0)
            {
                AddError(e.Errors, grvGastoRecurrenteDet.Columns["cantJunio"], "La cantidad debe ser mayor o igual a cero");
            }

            //Validación de julio
            decimal julio = e.NewValues["cantJulio"] != null ? (decimal)e.NewValues["cantJulio"] : 0;
            if (julio < 0)
            {
                AddError(e.Errors, grvGastoRecurrenteDet.Columns["cantJulio"], "La cantidad debe ser mayor o igual a cero");
            }

            //Validación de agosto
            decimal agosto = e.NewValues["cantAgosto"] != null ? (decimal)e.NewValues["cantAgosto"] : 0;
            if (agosto < 0)
            {
                AddError(e.Errors, grvGastoRecurrenteDet.Columns["cantAgosto"], "La cantidad debe ser mayor o igual a cero");
            }

            //Validación de setiembre
            decimal setiembre = e.NewValues["cantSetiembre"] != null ? (decimal)e.NewValues["cantSetiembre"] : 0;
            if (setiembre < 0)
            {
                AddError(e.Errors, grvGastoRecurrenteDet.Columns["cantSetiembre"], "La cantidad debe ser mayor o igual a cero");
            }

            //Validación de octubre
            decimal octubre = e.NewValues["cantOctubre"] != null ? (decimal)e.NewValues["cantOctubre"] : 0;
            if (octubre < 0)
            {
                AddError(e.Errors, grvGastoRecurrenteDet.Columns["cantOctubre"], "La cantidad debe ser mayor o igual a cero");
            }

            //Validación de noviembre
            decimal noviembre = e.NewValues["cantNoviembre"] != null ? (decimal)e.NewValues["cantNoviembre"] : 0;
            if (noviembre < 0)
            {
                AddError(e.Errors, grvGastoRecurrenteDet.Columns["cantNoviembre"], "La cantidad debe ser mayor o igual a cero");
            }

            //Validación de diciembre
            decimal diciembre = e.NewValues["cantDiciembre"] != null ? (decimal)e.NewValues["cantDiciembre"] : 0;
            if (diciembre < 0)
            {
                AddError(e.Errors, grvGastoRecurrenteDet.Columns["cantDiciembre"], "La cantidad debe ser mayor o igual a cero");
            }
        }

        void AddError(Dictionary<GridViewColumn, string> errors, GridViewColumn column, string errorText)
        {
            if (errors.ContainsKey(column)) return;
            errors[column] = errorText;
        }

        protected void grvReqDet_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            if (!grvGastoRecurrenteDet.IsNewRowEditing)
            {
                grvGastoRecurrenteDet.DoRowValidation();
            }
        }

        protected void clbUnidad_Callback(object source, CallbackEventArgs e)
        {
            e.Result = listaGastoRecurrenteDetallePresentador.BuscarIDUnidadProducto(Convert.ToInt32(e.Parameter)).ToString();
        }

        protected void detailGrid_BeforePerformDataSelect(object sender, EventArgs e)
        {
            ASPxGridView detailGrid = (ASPxGridView)sender;
            if (detailGrid != null)
            {
                int id = (int)detailGrid.GetMasterRowKeyValue();

                GastoRecurrenteRequerimientoPres result = grvGastoRecurrenteDet.GetRow(grvGastoRecurrenteDet.FindVisibleIndexByKeyValue(id)) as GastoRecurrenteRequerimientoPres;

                if (result != null)
                    if (result.GastoRecurrenteDetallePres != null)
                        detailGrid.DataSource = result.GastoRecurrenteDetallePres;
            }
        }
        protected void grid_DataBinding(object sender, EventArgs e)
        {
            (sender as ASPxGridView).ForceDataRowType(typeof(PlanAnualAdquisicionRequerimientoPres));
        }
    }
}