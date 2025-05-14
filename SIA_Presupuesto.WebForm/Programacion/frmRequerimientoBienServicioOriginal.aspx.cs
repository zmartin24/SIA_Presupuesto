using DevExpress.CodeParser;
using DevExpress.Web;
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
using Utilitario.Util;

namespace SIA_Presupuesto.WebForm.Programacion
{
    public partial class frmRequerimientoBienServicioOriginal : System.Web.UI.Page, IRequerimientoBienServicioDetalleOriginalVista
    {
        
        private RequerimientoBienServicioDetalleOrginalPresentador requerimientoBienServicioDetallePresentador;

        public List<RequerimientoBienServicioDetallePres> listaDatosPrincipales
        {
            set
            {
                this.grvReqDet.DataSource = value;
                this.grvReqDet.DataBind();
            }
        }
        public List<RequerimientoBienServicioDetallePres> listaGridData
        {
            set;get;
        }

        public List<Producto> listaDatosProductos
        {
            set
            {
                this.grvProducto.DataSource = value;
            }
        }

        public string nomUsuario { get { return Session["nomUsuario"] != null ? Session["nomUsuario"].ToString() : string.Empty; } }

        public List<Unidad> listaUnidades
        {
            set
            {
                this.cbUnidad.DataSource = value;
                this.cbUnidad.DataBind();
            }
        }

        public List<CuentaContable> listaCuentaContable
        {
            set
            {
                this.cbCuenta.DataSource = value;
                this.cbCuenta.DataBind();
            }
        }

        public int idReqBieSer
        {
            set { hdfValores["idReq"] = value.ToString(); }
            get { return Convert.ToInt32(hdfValores["idReq"]); }
        }

        public int idProducto
        {
            set { hdfValores["idProducto"] = value.ToString(); }
            get { return Convert.ToInt32(hdfValores["idProducto"]); }
        }

        public int idUnidad
        {
            set { cbUnidad.Value = value.ToString(); }
            get { return Convert.ToInt32(cbUnidad.Value.ToString()); }
        }

        public int idCueCon
        {
            set
            {
                cbCuenta.Value = value.ToString();
                hdfValores["idCueCon"] = value.ToString();
            }
            get { return Convert.ToInt32(cbCuenta.Value.ToString()); }
        }

        public string descripcion
        {
            set { txtDescripcion.Text = value; }
            get { return txtDescripcion.Text; }
        }

        public string justificacion
        {
            set { txtJustificacion.Text = value; }
            get { return txtJustificacion.Text; }
        }

        public decimal precio
        {
            set { sePrecio.Value = value; }
            get { return Convert.ToDecimal(sePrecio.Value); }
        }
        public List<Anio> listaAnios
        {
            set
            {
                cbAnio.DataSource = value;
                cbAnio.DataBind();
            }
        }
        public object listaPrecio
        {
            set
            {
                this.grvPrecio.DataSource = value;
            }
        }
        public object precioActual { get; }
        public int anioPresentacion
        {
            set
            {
                cbAnio.Value = value.ToString();
                hdfValores["anioPrecio"] = value.ToString();
            }
            get { return cbAnio.Value != null ? Convert.ToInt32(cbAnio.Value.ToString()) : 0; }
        }

        public string desArea
        {
            set { lblDescripcion.Text = value.ToString(); }
        }



        protected void Page_Init(object sender, EventArgs e)
        {
            requerimientoBienServicioDetallePresentador = new RequerimientoBienServicioDetalleOrginalPresentador(this);
            requerimientoBienServicioDetallePresentador.CargarServicios();
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
                hdfValores["idProducto"] = 0;
                hdfValores["anioPrecio"] = DateTime.Now.Year;
                hdfValores["idCueCon"] = 0;
                hdfValores["precioActual"] = 0;
                var simbolo = requerimientoBienServicioDetallePresentador.BuscarSimboloMoneda(Convert.ToInt32(Request.Params.Get("idReq")));
                grvReqDet.Columns["subtotal"].Caption = string.Format("Subtotal {0}", simbolo);
                requerimientoBienServicioDetallePresentador.TraerRequerimientoBienServicio();
            }
            Actualizar();
        }

        public void Actualizar()
        {
            requerimientoBienServicioDetallePresentador.Iniciar();
            this.listaDatosPrincipales = this.listaGridData;
            grvReqDet.ExpandAll();
        }

        protected void cpPrincipal_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            popReqDet.JSProperties["cpNombre"] = "Registro de Requerimiento";

            var args = Util.DeserializeCallbackArgs(e.Parameter);
            if (args.Count == 0)
                return;

            if (args[0] == "Guardar")
            {
                Resultado resultado = requerimientoBienServicioDetallePresentador.GuardarDatos(args[2]);
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

                if (requerimientoBienServicioDetallePresentador.AnularArea(Convert.ToInt32(args[1])))
                    cpPrincipal.JSProperties["cpMensaje"] = "Anulado correctamente";
                else
                    cpPrincipal.JSProperties["cpMensaje"] = "No se pudo anular";
            }
            cpPrincipal.JSProperties["cpGrid"] = "grvReqDet";

        }

        protected void grvReqDet_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            grvReqDet.DataBind();
        }

        protected void grvReqDet_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            UpdateItem(e.Keys, e.NewValues, e.OldValues);
            CancelEditing(e);
        }
        protected void CancelEditing(CancelEventArgs e)
        {
            e.Cancel = true;
            grvReqDet.CancelEdit();
        }
        protected void grvReqDet_BatchUpdate(object sender, ASPxDataBatchUpdateEventArgs e)
        {
            foreach (var args in e.UpdateValues)
            {
                UpdateItem(args.Keys, args.NewValues, args.OldValues);
            }
            requerimientoBienServicioDetallePresentador.ObtenerDatosListado();
            this.listaDatosPrincipales = this.listaGridData;

            e.Handled = true;
        }
        protected RequerimientoBienServicioDetallePres UpdateItem(OrderedDictionary keys, OrderedDictionary newValues, OrderedDictionary oldValues)
        {
            var id = Convert.ToInt32(keys["idReqBieSerDet"]);
            var item = this.listaGridData.First(i => i.idReqBieSerDet == id);
            LoadNewValues(item, newValues, oldValues);
            return item;
        }
        protected void LoadNewValues(RequerimientoBienServicioDetallePres item, OrderedDictionary newValues, OrderedDictionary oldValues)
        {
            item.cantEnero = newValues["cantEnero"] != null ? Convert.ToDecimal(newValues["cantEnero"]) : 0.0m;
            item.cantFebrero = newValues["cantFebrero"] != null ? Convert.ToDecimal(newValues["cantFebrero"]) : 0.0m;
            item.cantMarzo = newValues["cantMarzo"] != null ? Convert.ToDecimal(newValues["cantMarzo"]) : 0.0m;
            item.cantAbril = newValues["cantAbril"] != null ? Convert.ToDecimal(newValues["cantAbril"]) : 0.0m;
            item.cantMayo = newValues["cantMayo"] != null ? Convert.ToDecimal(newValues["cantMayo"]) : 0.0m;
            item.cantJunio = newValues["cantJunio"] != null ? Convert.ToDecimal(newValues["cantJunio"]) : 0.0m;
            item.cantJulio = newValues["cantJulio"] != null ? Convert.ToDecimal(newValues["cantJulio"]) : 0.0m;
            item.cantAgosto = newValues["cantAgosto"] != null ? Convert.ToDecimal(newValues["cantAgosto"]) : 0.0m;
            item.cantSetiembre = newValues["cantSetiembre"] != null ? Convert.ToDecimal(newValues["cantSetiembre"]) : 0.0m;
            item.cantOctubre = newValues["cantOctubre"] != null ? Convert.ToDecimal(newValues["cantOctubre"]) : 0.0m;
            item.cantNoviembre = newValues["cantNoviembre"] != null ? Convert.ToDecimal(newValues["cantNoviembre"]) : 0.0m;
            item.cantDiciembre = newValues["cantDiciembre"] != null ? Convert.ToDecimal(newValues["cantDiciembre"]) : 0.0m;

            ////Enero
            if ((newValues["cantEnero"] != null ? Convert.ToDecimal(newValues["cantEnero"]) : 0.0m) != (oldValues["cantEnero"] != null ? Convert.ToDecimal(oldValues["cantEnero"]) : 0.0m)) //(e.NewValues["cantEnero"] != e.OldValues["cantEnero"])
            {
                //Decimal enero = newValues["cantEnero"] != null ? Convert.ToDecimal(newValues["cantEnero"]) : 0.0m;
                requerimientoBienServicioDetallePresentador.IngresarCantidadDetalle(item.idReqBieSerDet, 1, (Decimal)item.cantEnero);
            }

            //Febrero
            if ((newValues["cantFebrero"] != null ? Convert.ToDecimal(newValues["cantFebrero"]) : 0.0m) != (oldValues["cantFebrero"] != null ? Convert.ToDecimal(oldValues["cantFebrero"]) : 0.0m)) //(e.NewValues["cantFebrero"] != e.OldValues["cantFebrero"])
            {
                //Decimal enero = newValues["cantFebrero"] != null ? Convert.ToDecimal(newValues["cantFebrero"]) : 0.0m;
                requerimientoBienServicioDetallePresentador.IngresarCantidadDetalle(item.idReqBieSerDet, 2, (Decimal)item.cantFebrero);
            }
            //Marzo
            if ((newValues["cantMarzo"] != null ? Convert.ToDecimal(newValues["cantMarzo"]) : 0.0m) != (oldValues["cantMarzo"] != null ? Convert.ToDecimal(oldValues["cantMarzo"]) : 0.0m)) //(e.NewValues["cantMarzo"] != e.OldValues["cantMarzo"])
            {
                //Decimal enero = newValues["cantMarzo"] != null ? Convert.ToDecimal(newValues["cantMarzo"]) : 0.0m;
                requerimientoBienServicioDetallePresentador.IngresarCantidadDetalle(item.idReqBieSerDet, 3, (Decimal)item.cantMarzo);
            }

            //Abril
            if ((newValues["cantAbril"] != null ? Convert.ToDecimal(newValues["cantAbril"]) : 0.0m) != (oldValues["cantAbril"] != null ? Convert.ToDecimal(oldValues["cantAbril"]) : 0.0m)) // (e.NewValues["cantAbril"] != e.OldValues["cantAbril"])
            {
                //Decimal enero = newValues["cantAbril"] != null ? Convert.ToDecimal(newValues["cantAbril"]) : 0.0m;
                requerimientoBienServicioDetallePresentador.IngresarCantidadDetalle(item.idReqBieSerDet, 4, (Decimal)item.cantAbril);
            }

            //Mayo
            if ((newValues["cantMayo"] != null ? Convert.ToDecimal(newValues["cantMayo"]) : 0.0m) != (oldValues["cantMayo"] != null ? Convert.ToDecimal(oldValues["cantMayo"]) : 0.0m)) // (e.NewValues["cantMayo"] != e.OldValues["cantMayo"])
            {
                //Decimal enero = newValues["cantMayo"] != null ? Convert.ToDecimal(newValues["cantMayo"]) : 0.0m;
                requerimientoBienServicioDetallePresentador.IngresarCantidadDetalle(item.idReqBieSerDet, 5, (Decimal)item.cantMayo);
            }

            //Junio
            if ((newValues["cantJunio"] != null ? Convert.ToDecimal(newValues["cantJunio"]) : 0.0m) != (oldValues["cantJunio"] != null ? Convert.ToDecimal(oldValues["cantJunio"]) : 0.0m)) // (e.NewValues["cantJunio"] != e.OldValues["cantJunio"])
            {
                //Decimal enero = newValues["cantJunio"] != null ? Convert.ToDecimal(newValues["cantJunio"]) : 0.0m;
                requerimientoBienServicioDetallePresentador.IngresarCantidadDetalle(item.idReqBieSerDet, 6, (Decimal)item.cantJunio);
            }

            //Julio
            if ((newValues["cantJulio"] != null ? Convert.ToDecimal(newValues["cantJulio"]) : 0.0m) != (oldValues["cantJulio"] != null ? Convert.ToDecimal(oldValues["cantJulio"]) : 0.0m)) // (e.NewValues["cantJulio"] != e.OldValues["cantJulio"])
            {
                //Decimal enero = newValues["cantJulio"] != null ? Convert.ToDecimal(newValues["cantJulio"]) : 0.0m;
                requerimientoBienServicioDetallePresentador.IngresarCantidadDetalle(item.idReqBieSerDet, 7, (Decimal)item.cantJulio);
            }

            //Agosto
            if ((newValues["cantAgosto"] != null ? Convert.ToDecimal(newValues["cantAgosto"]) : 0.0m) != (oldValues["cantAgosto"] != null ? Convert.ToDecimal(oldValues["cantAgosto"]) : 0.0m)) // (e.NewValues["cantAgosto"] != e.OldValues["cantAgosto"])
            {
                //Decimal enero = newValues["cantAgosto"] != null ? Convert.ToDecimal(newValues["cantAgosto"]) : 0.0m;
                requerimientoBienServicioDetallePresentador.IngresarCantidadDetalle(item.idReqBieSerDet, 8, (Decimal)item.cantAgosto);
            }
            //Setiembre
            if ((newValues["cantSetiembre"] != null ? Convert.ToDecimal(newValues["cantSetiembre"]) : 0.0m) != (oldValues["cantSetiembre"] != null ? Convert.ToDecimal(oldValues["cantSetiembre"]) : 0.0m)) // (e.NewValues["cantSetiembre"] != e.OldValues["cantSetiembre"])
            {
                //Decimal enero = newValues["cantSetiembre"] != null ? Convert.ToDecimal(newValues["cantSetiembre"]) : 0.0m;
                requerimientoBienServicioDetallePresentador.IngresarCantidadDetalle(item.idReqBieSerDet, 9, (Decimal)item.cantSetiembre);
            }
            //Octubre
            if ((newValues["cantOctubre"] != null ? Convert.ToDecimal(newValues["cantOctubre"]) : 0.0m) != (oldValues["cantOctubre"] != null ? Convert.ToDecimal(oldValues["cantOctubre"]) : 0.0m)) // (e.NewValues["cantOctubre"] != e.OldValues["cantOctubre"])
            {
                //Decimal enero = newValues["cantOctubre"] != null ? Convert.ToDecimal(newValues["cantOctubre"]) : 0.0m;
                requerimientoBienServicioDetallePresentador.IngresarCantidadDetalle(item.idReqBieSerDet, 10, (Decimal)item.cantOctubre);
            }
            //Noviembre
            if ((newValues["cantNoviembre"] != null ? Convert.ToDecimal(newValues["cantNoviembre"]) : 0.0m) != (oldValues["cantNoviembre"] != null ? Convert.ToDecimal(oldValues["cantNoviembre"]) : 0.0m)) // (e.NewValues["cantNoviembre"] != e.OldValues["cantNoviembre"])
            {
                //Decimal enero = newValues["cantNoviembre"] != null ? Convert.ToDecimal(newValues["cantNoviembre"]) : 0.0m;
                requerimientoBienServicioDetallePresentador.IngresarCantidadDetalle(item.idReqBieSerDet, 11, (Decimal)item.cantNoviembre);
            }
            //Diciembre
            if ((newValues["cantDiciembre"] != null ? Convert.ToDecimal(newValues["cantDiciembre"]) : 0.0m) != (oldValues["cantDiciembre"] != null ? Convert.ToDecimal(oldValues["cantDiciembre"]) : 0.0m)) // (e.NewValues["cantDiciembre"] != e.OldValues["cantDiciembre"])
            {
                //Decimal enero = newValues["cantDiciembre"] != null ? Convert.ToDecimal(newValues["cantDiciembre"]) : 0.0m;
                requerimientoBienServicioDetallePresentador.IngresarCantidadDetalle(item.idReqBieSerDet, 12, (Decimal)item.cantDiciembre);
            }
        }


        protected void grvReqDet_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {
            //Validación de enero
            decimal enero = e.NewValues["cantEnero"] != null ? (decimal)e.NewValues["cantEnero"] : 0;
            if (enero < 0)
            {
                AddError(e.Errors, grvReqDet.Columns["cantEnero"], "La cantidad debe ser mayor o igual a cero");
            }

            //Validación de febrero
            decimal febrero = e.NewValues["cantFebrero"] != null ? (decimal)e.NewValues["cantFebrero"] : 0;
            if (febrero < 0)
            {
                AddError(e.Errors, grvReqDet.Columns["cantFebrero"], "La cantidad debe ser mayor o igual a cero");
            }

            //Validación de marzo
            decimal marzo = e.NewValues["cantMarzo"] != null ? (decimal)e.NewValues["cantMarzo"] : 0;
            if (marzo < 0)
            {
                AddError(e.Errors, grvReqDet.Columns["cantMarzo"], "La cantidad debe ser mayor o igual a cero");
            }

            //Validación de abril
            decimal abril = e.NewValues["cantAbril"] != null ? (decimal)e.NewValues["cantAbril"] : 0;
            if (abril < 0)
            {
                AddError(e.Errors, grvReqDet.Columns["cantAbril"], "La cantidad debe ser mayor o igual a cero");
            }

            //Validación de mayo
            decimal mayo = e.NewValues["cantMayo"] != null ? (decimal)e.NewValues["cantMayo"] : 0;
            if (mayo < 0)
            {
                AddError(e.Errors, grvReqDet.Columns["cantMayo"], "La cantidad debe ser mayor o igual a cero");
            }

            //Validación de junio
            decimal junio = e.NewValues["cantJunio"] != null ? (decimal)e.NewValues["cantJunio"] : 0;
            if (junio < 0)
            {
                AddError(e.Errors, grvReqDet.Columns["cantJunio"], "La cantidad debe ser mayor o igual a cero");
            }

            //Validación de julio
            decimal julio = e.NewValues["cantJulio"] != null ? (decimal)e.NewValues["cantJulio"] : 0;
            if (julio < 0)
            {
                AddError(e.Errors, grvReqDet.Columns["cantJulio"], "La cantidad debe ser mayor o igual a cero");
            }

            //Validación de agosto
            decimal agosto = e.NewValues["cantAgosto"] != null ? (decimal)e.NewValues["cantAgosto"] : 0;
            if (agosto < 0)
            {
                AddError(e.Errors, grvReqDet.Columns["cantAgosto"], "La cantidad debe ser mayor o igual a cero");
            }

            //Validación de setiembre
            decimal setiembre = e.NewValues["cantSetiembre"] != null ? (decimal)e.NewValues["cantSetiembre"] : 0;
            if (setiembre < 0)
            {
                AddError(e.Errors, grvReqDet.Columns["cantSetiembre"], "La cantidad debe ser mayor o igual a cero");
            }

            //Validación de octubre
            decimal octubre = e.NewValues["cantOctubre"] != null ? (decimal)e.NewValues["cantOctubre"] : 0;
            if (octubre < 0)
            {
                AddError(e.Errors, grvReqDet.Columns["cantOctubre"], "La cantidad debe ser mayor o igual a cero");
            }

            //Validación de noviembre
            decimal noviembre = e.NewValues["cantNoviembre"] != null ? (decimal)e.NewValues["cantNoviembre"] : 0;
            if (noviembre < 0)
            {
                AddError(e.Errors, grvReqDet.Columns["cantNoviembre"], "La cantidad debe ser mayor o igual a cero");
            }

            //Validación de diciembre
            decimal diciembre = e.NewValues["cantDiciembre"] != null ? (decimal)e.NewValues["cantDiciembre"] : 0;
            if (diciembre < 0)
            {
                AddError(e.Errors, grvReqDet.Columns["cantDiciembre"], "La cantidad debe ser mayor o igual a cero");
            }
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
        protected void grvReqDet_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            ASPxEdit editor = (ASPxEdit)e.Editor;
            editor.ValidationSettings.Display = Display.Dynamic;
        }


        protected void capProducto_Callback(object sender, CallbackEventArgsBase e)
        {
            grvProducto.DataBind();
        }

        protected void capPrecio_Callback(object sender, CallbackEventArgsBase e)
        {
            grvPrecio.DataBind();
        }
        protected void grvPrecio_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            string[] parametro = e.Parameters.Split('|');
            anioPresentacion = Convert.ToInt32(parametro[0]);
            idProducto = Convert.ToInt32(parametro[1]);
            idCueCon = Convert.ToInt32(parametro[2]);
            idReqBieSer = Convert.ToInt32(parametro[3]);
            grvPrecio.DataBind();
        }

        protected void grvProducto_DataBinding(object sender, EventArgs e)
        {
            requerimientoBienServicioDetallePresentador.ObtenerDatosProductos();
        }

        protected void grvPrecio_DataBinding(object sender, EventArgs e)
        {
            int anio = Convert.ToInt32(hdfValores["anioPrecio"]);
            int idCuenta = Convert.ToInt32(hdfValores["idCueCon"]);
            requerimientoBienServicioDetallePresentador.ObtenerDatosPrecios(anio, idCuenta);
        }

        protected void clbUnidad_Callback(object source, CallbackEventArgs e)
        {
            e.Result = requerimientoBienServicioDetallePresentador.BuscarIDUnidadProducto(Convert.ToInt32(e.Parameter)).ToString();
        }

        protected void popReqDet_Callback(object sender, CallbackEventArgsBase e)
        {
            var args = e.Parameter.Split('|');
            int id = 0;
            switch (args[0])
            {
                case "Nuevo":
                    requerimientoBienServicioDetallePresentador.IniciarDatos(0);
                    break;
                case "Editar":
                    id = !string.IsNullOrEmpty(args[1]) ? int.Parse(args[1]) : 0;
                    requerimientoBienServicioDetallePresentador.IniciarDatos(id);
                    break;
                case "Mostrar":
                    id = !string.IsNullOrEmpty(args[1]) ? int.Parse(args[1]) : 0;
                    requerimientoBienServicioDetallePresentador.IniciarDatos(id);
                    break;
            }
            popReqDet.JSProperties["cpID"] = id;
        }

        protected void popAyudaPrecio_WindowCallback(object source, DevExpress.Web.CallbackEventArgsBase e)
        {
            var args = e.Parameter.Split('|');
            idCueCon = Convert.ToInt32(args[1]);
            requerimientoBienServicioDetallePresentador.IniciarPopAyudaPrecio();
            var idanio = anioPresentacion;
            grvPrecio.DataBind();
        }
        protected void Callback1_Callback(object source, DevExpress.Web.CallbackEventArgs e)
        {
            var id = Convert.ToInt32(e.Parameter);// Convert.ToInt32(keys["idReqBieSerDet"]);
            var item = this.listaGridData.First(i => i.idReqBieSerDet == id);
            e.Result = item.justificacion;
            //using (var context = new NorthwindContextSL())
            //{
            //    int employeeId = Convert.ToInt32(e.Parameter);
            //    var employee = context.Employees.Single(em => em.EmployeeID == employeeId);
            //    e.Result = employee.Notes;
            //}
        }
    }
}