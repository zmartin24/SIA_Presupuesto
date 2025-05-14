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
using DevExpress.Spreadsheet.Export;
using DevExpress.Spreadsheet;
using Seguridad.Modelo;

namespace SIA_Presupuesto.WebForm.Programacion
{
    public partial class frmRequerimientoBienServicio : System.Web.UI.Page, IRequerimientoBienServicioDetalleVista
    {
        private RequerimientoBienServicioDetallePresentador requerimientoBienServicioDetallePresentador;

        public List<RequerimientoBienServicioDetallePres> listaDatosPrincipales
        {
            set
            {
                this.grvReqDet.DataSource = value;
                this.grvReqDet.DataBind();
            }
        }
        public List<RequerimientoBienServicioDetalleMes> listaRequerimientoDetalleMes
        {
            set
            {
                this.grvDetalleMes.DataSource = value;
            }
        }
        public List<RequerimientoBienServicioDetallePres> listaGridData
        {
            set; get;
        }

        public string nomUsuario { get { return Session["nomUsuario"] != null ? Session["nomUsuario"].ToString() : string.Empty; } }

        public List<Predeterminado> listaTipo
        {
            set
            {
                this.cbTipo.DataSource = value;
                this.cbTipo.DataBind();
            }
        }
        public List<Unidad> listaUnidades
        {
            set
            {
                this.cbUnidad.DataSource = value;
                this.cbUnidad.DataBind();
            }
        }
        public int idReqBieSer
        {
            set { hdfValores["idReq"] = value.ToString(); }
            get { return Convert.ToInt32(hdfValores["idReq"]); }
        }
        public int tipo
        {
            set 
            { 
                cbTipo.Value = value.ToString();
                hdfValores["tipo"] = value.ToString();
            }
            get { return Convert.ToInt32(cbTipo.Value.ToString()); }
        }
        public bool conPartida
        {
            set
            {
                chkConPartida.Checked = value;
                btnSelecPartida.ClientEnabled = conPartida;
            }
            get { return chkConPartida.Checked; }

        }
        public int idProducto
        {
            set 
            {
                hdfValores["idProducto"] = value.ToString();
                popReqDet.JSProperties["cpIdProducto"] = value.ToString();
            }
            get { return Convert.ToInt32(hdfValores["idProducto"]); }
        }

        public int idUnidad
        {
            set { cbUnidad.Value = value.ToString(); }
            get { return Convert.ToInt32(cbUnidad.Value.ToString()); }
        }

        public int? idParPre
        {
            set 
            { 
                hdfValores["idParPre"] = value.ToString();
                popReqDet.JSProperties["cpIdParPre"] = value.ToString();
            }
            get { return Convert.ToInt32(hdfValores["idParPre"]); }
        }
        public int idCueCon
        {
            set
            {
                hdfValores["idCueCon"] = value.ToString();
                popReqDet.JSProperties["cpIdCueCon"] = value.ToString();
            }
            get { return Convert.ToInt32(hdfValores["idCueCon"].ToString()); }
        }

        public string desCuenta
        {
            set { lblCuenta.Text = value; }
            get { return lblCuenta.Text; }
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
        
        public object listaPartidaPresupuestal
        {
            set
            {
                this.grvPartidaPrecio.DataSource = value;
            }
        }
        public object listaProductoPrecio
        {
            set
            {
                this.grvProductoPrecio.DataSource = value;
            }
        }

        public object precioActual { get; }
        public object productoPrecioActual { get; }
        

        public string desArea
        {
            set { lblDescripcion.Text = value.ToString(); }
        }
        
        public string datoDescripcionPartida
        {
            set { 
                txtBuscarProducto.Text = value.ToString();
                btnSelecPartida.Text = value;
            }
            get { return txtBuscarPartida.Text; }
        }
        public string datoDescripcion
        {
            set {
                txtBuscarProducto.Text = value.ToString();
                btnSelecProducto.Text = value;
            }
            get { return txtBuscarProducto.Text; }
        }

        public int idMoneda
        {
            set { hdfValores["idMoneda"] = value; }
            get { return Convert.ToInt32(hdfValores["idMoneda"].ToString()); }
        }
        public decimal subTotal
        {
            set { seSubtotal.Value = value; }
            get { return Convert.ToDecimal(seSubtotal.Value); }
        }
        public List<RequerimientoBienServicioDetalleMes> listaGridDataDetMes;

        string FilePath
        {
            get { return Session["FilePath"] == null ? string.Empty : Session["FilePath"].ToString(); }
            set { Session["FilePath"] = value; }
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            this.requerimientoBienServicioDetallePresentador = new RequerimientoBienServicioDetallePresentador(this);
            this.requerimientoBienServicioDetallePresentador.CargarServicios();
            this.listaGridDataDetMes = new List<RequerimientoBienServicioDetalleMes>();
            FilePath = string.Empty;
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["nomUsuario"]==null)
            {
                Response.Redirect("~/Error.htm");
            }

            if (!IsPostBack)
            {
                Session["listaGridDataDetMes"] = null;
                Session["listaDetalleRequerimientoAnualMigraSession"] = null;
                hdfValores.Add("idReq", Request.Params.Get("idReq"));
                hdfValores["idProducto"] = 0;
                hdfValores["idMoneda"] = 63;//Session["idMoneda"];
                hdfValores["idParPre"] = 0;
                hdfValores["idCueCon"] = 0;
                hdfValores["datoDescripcion"] = string.Empty;
                var simbolo = this.requerimientoBienServicioDetallePresentador.BuscarSimboloMoneda(Convert.ToInt32(Request.Params.Get("idReq")));
                grvReqDet.Columns["precio"].Caption = string.Format("Precio {0}", simbolo);
                grvReqDet.Columns["subtotal"].Caption = string.Format("Subtotal {0}", simbolo);
                this.requerimientoBienServicioDetallePresentador.TraerRequerimientoBienServicio();
                

                datoDescripcionPartida = string.Empty;
                datoDescripcion = string.Empty;
            }
            Actualizar();
        }

        public void Actualizar()
        {
            // Modify the Current Culture
            Thread.CurrentThread.CurrentCulture = hdfValores["idMoneda"] == null ? new CultureInfo("es-PE") : Convert.ToInt32(hdfValores["idMoneda"].ToString()) == 63 ? new CultureInfo("es-PE") : new CultureInfo("en-US");
            
            //hdfValores["idMoneda"] = hdfValores["idMoneda"] == null ? Session["idMoneda"] : hdfValores["idMoneda"];
            this.requerimientoBienServicioDetallePresentador.Iniciar();
            this.listaDatosPrincipales = this.listaGridData;
            if (Session["listaGridDataDetMes"] != null)
                this.listaGridDataDetMes = (List<RequerimientoBienServicioDetalleMes>)Session["listaGridDataDetMes"];
            
            this.listaRequerimientoDetalleMes = this.listaGridDataDetMes;
            grvReqDet.ExpandAll();
        }

        protected void cpPrincipal_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            popReqDet.JSProperties["cpNombre"] = "Registro de Requerimiento";
            popImportar.JSProperties["cpImportar"] = "Importar Detalles";

            var args = Util.DeserializeCallbackArgs(e.Parameter);
            if (args.Count == 0)
                return;

            //if (args[0] == "Guardar")
            if (args[0] == "Nuevo" || args[0] == "Editar")
            {
                Resultado resultado = this.requerimientoBienServicioDetallePresentador.GuardarDatos(args[2], this.listaGridDataDetMes);
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
                if (this.requerimientoBienServicioDetallePresentador.AnularArea(Convert.ToInt32(args[1])))
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
            this.requerimientoBienServicioDetallePresentador.ObtenerDatosListado();
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

    
        protected void popReqDet_Callback(object sender, CallbackEventArgsBase e)
        {
            var args = e.Parameter.Split('|');
            int id = 0;
            string opcion = string.Empty;
            switch (args[0])
            {
                case "Nuevo":
                    this.requerimientoBienServicioDetallePresentador.IniciarDatos(0);

                    this.listaGridDataDetMes = this.requerimientoBienServicioDetallePresentador.TraerListaRequerimientoDetalleMes(0);
                    Session["listaGridDataDetMes"] = this.listaGridDataDetMes;
                    grvDetalleMes.DataBind();
                    opcion = "Nuevo";
                    chkConPartida.Checked = false;
                    frmDetalle.FindItemOrGroupByName("bliProducto").ClientVisible = true;
                    btnSelecProducto.ClientEnabled = true;
                    btnSelecProducto.Focus();

                    frmDetalle.FindItemOrGroupByName("bliPartida").ClientVisible = false;
                    btnSelecPartida.ClientEnabled = false;

                    break;
                case "Editar":
                    id = !string.IsNullOrEmpty(args[1]) ? int.Parse(args[1]) : 0;
                    this.requerimientoBienServicioDetallePresentador.IniciarDatos(id);
                    cbTipo.ClientEnabled = false;

                    this.listaGridDataDetMes = this.requerimientoBienServicioDetallePresentador.TraerListaRequerimientoDetalleMes(id);
                    Session["listaGridDataDetMes"] = this.listaGridDataDetMes;
                    grvDetalleMes.DataBind();
                    opcion = "Editar";

                    if (tipo.ToString().Equals("2"))
                    {
                        chkConPartida.Checked = true;
                        chkConPartida.ClientEnabled = false;
                        frmDetalle.FindItemOrGroupByName("bliProducto").ClientVisible = false;
                        btnSelecPartida.ClientEnabled = true;

                        btnSelecPartida.Focus();
                    }
                    else
                    {
                        chkConPartida.Checked = idProducto == 0 ? true : false;
                        frmDetalle.FindItemOrGroupByName("bliPartida").ClientVisible = idProducto == 0 ? true : false;
                        frmDetalle.FindItemOrGroupByName("bliProducto").ClientVisible = idProducto == 0 ? false : true;
                        btnSelecPartida.ClientEnabled = idProducto == 0 ? true : false;
                        btnSelecProducto.ClientEnabled = idProducto == 0 ? false : true;

                        if(idProducto==0)
                            btnSelecPartida.Focus();
                        else
                            btnSelecProducto.Focus();
                    }

                    break;
                case "Mostrar":
                    id = !string.IsNullOrEmpty(args[1]) ? int.Parse(args[1]) : 0;
                    this.requerimientoBienServicioDetallePresentador.IniciarDatos(id);
                    cbTipo.ClientEnabled = false;
                    opcion = "Mostrar";
                    break;
            }

            popReqDet.JSProperties["cpID"] = id;
            popReqDet.JSProperties["cpOpcion"] = opcion;
        }

        protected void popAyudaPartidaPrecio_WindowCallback(object source, DevExpress.Web.CallbackEventArgsBase e)
        {
            string[] parametro = e.Parameter.Split('|');

            hdfValores["tipo"] = parametro[0].ToString();
            grvPartidaPrecio.DataBind();
        }
        protected void grvPartidaPrecio_DataBinding(object sender, EventArgs e)
        {
            var tipo = hdfValores["tipo"].ToString();
            var idMoneda = hdfValores["idMoneda"].ToString();

            this.requerimientoBienServicioDetallePresentador.TraerPartidaPrecio(Convert.ToInt32(tipo), datoDescripcionPartida, Convert.ToInt32(idMoneda));
        }
        protected void popAyudaProductoPrecio_WindowCallback(object source, DevExpress.Web.CallbackEventArgsBase e)
        {
            grvProductoPrecio.DataBind();
        }
        protected void grvPartidaPrecio_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            //string[] parametro = e.Parameters.Split('|');
            //datoDescripcionPartida = !string.IsNullOrEmpty(parametro[0]) ? parametro[0].ToString():string.Empty;
            //grvPartidaPrecio.DataBind();
        }
        protected void grvProductoPrecio_DataBinding(object sender, EventArgs e)
        {
            var idMoneda = hdfValores["idMoneda"].ToString();
            requerimientoBienServicioDetallePresentador.TraerProductoPrecio(datoDescripcion, Convert.ToInt32(idMoneda));
        }
        protected void grvProductoPrecio_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            //string[] parametro = e.Parameters.Split('|');
            //datoDescripcion = !string.IsNullOrEmpty(parametro[0]) ? parametro[0].ToString() : string.Empty;
            //grvProductoPrecio.DataBind();
        }

        //Grid Detalle Meses
        protected void grvDetalleMes_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            if (!grvDetalleMes.IsNewRowEditing)
            {
                grvDetalleMes.DoRowValidation();
            }
        }
        protected void grvDetalleMes_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            UpdateDetalleMes(e.Keys, e.NewValues, e.OldValues);
            CancelEditingGrvDetalleMes(e);
        }
        protected void CancelEditingGrvDetalleMes(CancelEventArgs e)
        {
            e.Cancel = true;
            grvDetalleMes.CancelEdit();
        }
        protected RequerimientoBienServicioDetalleMes UpdateDetalleMes(OrderedDictionary keys, OrderedDictionary newValues, OrderedDictionary oldValues)
        {
            var id = Convert.ToInt32(keys["idReqBieSerDet"]);
            var item = this.listaGridDataDetMes.First(i => i.idReqBieSerDet == id);
            LoadNewValuesDetMes(item, newValues, oldValues);
            return item;
        }
        protected void LoadNewValuesDetMes(RequerimientoBienServicioDetalleMes item, OrderedDictionary newValues, OrderedDictionary oldValues)
        {
            item.cantEne = newValues["cantEne"] != null ? Convert.ToDecimal(newValues["cantEne"]) : 0.0m;
            item.cantFeb = newValues["cantFeb"] != null ? Convert.ToDecimal(newValues["cantFeb"]) : 0.0m;
            item.cantMar = newValues["cantMar"] != null ? Convert.ToDecimal(newValues["cantMar"]) : 0.0m;
            item.cantAbr = newValues["cantAbr"] != null ? Convert.ToDecimal(newValues["cantAbr"]) : 0.0m;
            item.cantMay = newValues["cantMay"] != null ? Convert.ToDecimal(newValues["cantMay"]) : 0.0m;
            item.cantJun = newValues["cantJun"] != null ? Convert.ToDecimal(newValues["cantJun"]) : 0.0m;
            item.cantJul = newValues["cantJul"] != null ? Convert.ToDecimal(newValues["cantJul"]) : 0.0m;
            item.cantAgo = newValues["cantAgo"] != null ? Convert.ToDecimal(newValues["cantAgo"]) : 0.0m;
            item.cantSet = newValues["cantSet"] != null ? Convert.ToDecimal(newValues["cantSet"]) : 0.0m;
            item.cantOct = newValues["cantOct"] != null ? Convert.ToDecimal(newValues["cantOct"]) : 0.0m;
            item.cantNov = newValues["cantNov"] != null ? Convert.ToDecimal(newValues["cantNov"]) : 0.0m;
            item.cantDic = newValues["cantDic"] != null ? Convert.ToDecimal(newValues["cantDic"]) : 0.0m;

            ////Enero
            if ((newValues["cantEne"] != null ? Convert.ToDecimal(newValues["cantEne"]) : 0.0m) != (oldValues["cantEne"] != null ? Convert.ToDecimal(oldValues["cantEne"]) : 0.0m)) 
            {
                this.listaGridDataDetMes.Where(x => x.idReqBieSerDet == item.idReqBieSerDet).ToList().ForEach(x => x.cantEne = (Decimal)item.cantEne);
            }

            //Febrero
            if ((newValues["cantFeb"] != null ? Convert.ToDecimal(newValues["cantFeb"]) : 0.0m) != (oldValues["cantFeb"] != null ? Convert.ToDecimal(oldValues["cantFeb"]) : 0.0m)) 
            {
                this.listaGridDataDetMes.Where(x => x.idReqBieSerDet == item.idReqBieSerDet).ToList().ForEach(x => x.cantFeb = (Decimal)item.cantFeb);
            }
            //Marzo
            if ((newValues["cantMar"] != null ? Convert.ToDecimal(newValues["cantMar"]) : 0.0m) != (oldValues["cantMar"] != null ? Convert.ToDecimal(oldValues["cantMar"]) : 0.0m)) 
            {
                this.listaGridDataDetMes.Where(x => x.idReqBieSerDet == item.idReqBieSerDet).ToList().ForEach(x => x.cantMar = (Decimal)item.cantMar);
            }

            //Abril
            if ((newValues["cantAbr"] != null ? Convert.ToDecimal(newValues["cantAbr"]) : 0.0m) != (oldValues["cantAbr"] != null ? Convert.ToDecimal(oldValues["cantAbr"]) : 0.0m)) 
            {
                this.listaGridDataDetMes.Where(x => x.idReqBieSerDet == item.idReqBieSerDet).ToList().ForEach(x => x.cantAbr = (Decimal)item.cantAbr);
            }

            //Mayo
            if ((newValues["cantMay"] != null ? Convert.ToDecimal(newValues["cantMay"]) : 0.0m) != (oldValues["cantMay"] != null ? Convert.ToDecimal(oldValues["cantMay"]) : 0.0m)) 
            {
                this.listaGridDataDetMes.Where(x => x.idReqBieSerDet == item.idReqBieSerDet).ToList().ForEach(x => x.cantMay = (Decimal)item.cantMay);
            }

            //Junio
            if ((newValues["cantJun"] != null ? Convert.ToDecimal(newValues["cantJun"]) : 0.0m) != (oldValues["cantJun"] != null ? Convert.ToDecimal(oldValues["cantJun"]) : 0.0m))
            {
                this.listaGridDataDetMes.Where(x => x.idReqBieSerDet == item.idReqBieSerDet).ToList().ForEach(x => x.cantJun = (Decimal)item.cantJun);
            }

            //Julio
            if ((newValues["cantJul"] != null ? Convert.ToDecimal(newValues["cantJul"]) : 0.0m) != (oldValues["cantJul"] != null ? Convert.ToDecimal(oldValues["cantJul"]) : 0.0m)) 
            {
                this.listaGridDataDetMes.Where(x => x.idReqBieSerDet == item.idReqBieSerDet).ToList().ForEach(x => x.cantJul = (Decimal)item.cantJul);
            }

            //Agosto
            if ((newValues["cantAgo"] != null ? Convert.ToDecimal(newValues["cantAgo"]) : 0.0m) != (oldValues["cantAgo"] != null ? Convert.ToDecimal(oldValues["cantAgo"]) : 0.0m)) 
            {
                this.listaGridDataDetMes.Where(x => x.idReqBieSerDet == item.idReqBieSerDet).ToList().ForEach(x => x.cantAgo = (Decimal)item.cantAgo);
            }
            //Setiembre
            if ((newValues["cantSet"] != null ? Convert.ToDecimal(newValues["cantSet"]) : 0.0m) != (oldValues["cantSet"] != null ? Convert.ToDecimal(oldValues["cantSet"]) : 0.0m)) 
            {
                this.listaGridDataDetMes.Where(x => x.idReqBieSerDet == item.idReqBieSerDet).ToList().ForEach(x => x.cantSet = (Decimal)item.cantSet);
            }
            //Octubre
            if ((newValues["cantOct"] != null ? Convert.ToDecimal(newValues["cantOct"]) : 0.0m) != (oldValues["cantOct"] != null ? Convert.ToDecimal(oldValues["cantOct"]) : 0.0m)) 
            {
                this.listaGridDataDetMes.Where(x => x.idReqBieSerDet == item.idReqBieSerDet).ToList().ForEach(x => x.cantOct = (Decimal)item.cantOct);
            }
            //Noviembre
            if ((newValues["cantNov"] != null ? Convert.ToDecimal(newValues["cantNov"]) : 0.0m) != (oldValues["cantNov"] != null ? Convert.ToDecimal(oldValues["cantNov"]) : 0.0m))
            {
                this.listaGridDataDetMes.Where(x => x.idReqBieSerDet == item.idReqBieSerDet).ToList().ForEach(x => x.cantNov = (Decimal)item.cantNov);
            }
            //Diciembre
            if ((newValues["cantDic"] != null ? Convert.ToDecimal(newValues["cantDic"]) : 0.0m) != (oldValues["cantDic"] != null ? Convert.ToDecimal(oldValues["cantDic"]) : 0.0m)) 
            {
                this.listaGridDataDetMes.Where(x => x.idReqBieSerDet == item.idReqBieSerDet).ToList().ForEach(x => x.cantDic = (Decimal)item.cantDic);
            }
        }

        protected void grvDetalleMes_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            if (Session["listaGridDataDetMes"] != null)
                this.listaGridDataDetMes = (List<RequerimientoBienServicioDetalleMes>)Session["listaGridDataDetMes"];

            
            var subtotal = Math.Round(Convert.ToDecimal(sePrecio.Value) * (this.listaGridDataDetMes.FirstOrDefault().cantEne + this.listaGridDataDetMes.FirstOrDefault().cantFeb + this.listaGridDataDetMes.FirstOrDefault().cantMar + this.listaGridDataDetMes.FirstOrDefault().cantAbr + this.listaGridDataDetMes.FirstOrDefault().cantMay + this.listaGridDataDetMes.FirstOrDefault().cantJun +
                        this.listaGridDataDetMes.FirstOrDefault().cantJul + this.listaGridDataDetMes.FirstOrDefault().cantAgo + this.listaGridDataDetMes.FirstOrDefault().cantSet + this.listaGridDataDetMes.FirstOrDefault().cantOct + this.listaGridDataDetMes.FirstOrDefault().cantNov + this.listaGridDataDetMes.FirstOrDefault().cantDic), 2, MidpointRounding.AwayFromZero);//lista.Sum(s => s.subtotal - s.impuesto);
            seSubtotal.Value = subtotal;
            grvDetalleMes.DataBind();
        }
        protected void grvDetalleMes_DataBinding(object sender, EventArgs e)
        {
            (sender as BootstrapGridView).ForceDataRowType(typeof(RequerimientoBienServicioDetalleMes));
            //(sender as ASPxGridView).ForceDataRowType(typeof(RequerimientoBienServicioDetalleMes));

            if (Session["listaGridDataDetMes"] != null)
                this.listaGridDataDetMes = (List<RequerimientoBienServicioDetalleMes>)Session["listaGridDataDetMes"];
            this.listaRequerimientoDetalleMes = this.listaGridDataDetMes;
        }
        protected void grvDetalleMes_DataBound(object sender, EventArgs e)
        {
            ASPxGridView gridView = sender as ASPxGridView;
            List<RequerimientoBienServicioDetalleMes> listaDetalle = this.listaGridDataDetMes;
            if (listaDetalle != null)
            {
                var lista = listaDetalle.ToList();//.Where(s => !s.operacion.Equals("E")).ToList();
                if (lista != null)
                {
                    if (lista.Count > 0)
                    {
                        //var impuesto = lista.Sum(s => s.impuesto);
                        var subtotal = Math.Round(precio * (lista.FirstOrDefault().cantEne + lista.FirstOrDefault().cantFeb + lista.FirstOrDefault().cantMar + lista.FirstOrDefault().cantAbr + lista.FirstOrDefault().cantMay + lista.FirstOrDefault().cantJun +
                                                            lista.FirstOrDefault().cantJul + lista.FirstOrDefault().cantAgo + lista.FirstOrDefault().cantSet + lista.FirstOrDefault().cantOct + lista.FirstOrDefault().cantNov + lista.FirstOrDefault().cantDic), 2, MidpointRounding.AwayFromZero);
                        gridView.JSProperties["cpSubtotal"] = subtotal;
                        seSubtotal.Value = subtotal;
                        return;
                    }
                }
            }
            gridView.JSProperties["cpSubtotal"] = 0.0m;
            //gridView.JSProperties["cpTotals"] = "0.0";
        }
        protected void grvDetalleMes_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {
            int ene = Convert.ToInt32(e.NewValues["cantEne"] != null ? e.NewValues["cantEne"].ToString().Replace("-", "0") : "0");
            int feb = Convert.ToInt32(e.NewValues["cantFeb"] != null ? e.NewValues["cantFeb"].ToString().Replace("-", "0") : "0");
            int mar = Convert.ToInt32(e.NewValues["cantMar"] != null ? e.NewValues["cantMar"].ToString().Replace("-", "0") : "0");
            int abr = Convert.ToInt32(e.NewValues["cantAbr"] != null ? e.NewValues["cantAbr"].ToString().Replace("-", "0") : "0");
            int may = Convert.ToInt32(e.NewValues["cantMay"] != null ? e.NewValues["cantMay"].ToString().Replace("-", "0") : "0");
            int jun = Convert.ToInt32(e.NewValues["cantJun"] != null ? e.NewValues["cantJun"].ToString().Replace("-", "0") : "0");
            int jul = Convert.ToInt32(e.NewValues["cantJul"] != null ? e.NewValues["cantJul"].ToString().Replace("-", "0") : "0");
            int ago = Convert.ToInt32(e.NewValues["cantAgo"] != null ? e.NewValues["cantAgo"].ToString().Replace("-", "0") : "0");
            int set = Convert.ToInt32(e.NewValues["cantSet"] != null ? e.NewValues["cantSet"].ToString().Replace("-", "0") : "0");
            int oct = Convert.ToInt32(e.NewValues["cantOct"] != null ? e.NewValues["cantOct"].ToString().Replace("-", "0") : "0");
            int nov = Convert.ToInt32(e.NewValues["cantNov"] != null ? e.NewValues["cantNov"].ToString().Replace("-", "0") : "0");
            int dic = Convert.ToInt32(e.NewValues["cantDic"] != null ? e.NewValues["cantDic"].ToString().Replace("-", "0") : "0");

            //var errors = ValidateRow(
            //        Convert.ToInt32(e.NewValues["cantEne"].ToString().Replace("-", "0")), Convert.ToInt32(e.NewValues["cantFeb"].ToString().Replace("-", "0")), Convert.ToInt32(e.NewValues["cantMar"].ToString().Replace("-", "0")), Convert.ToInt32(e.NewValues["cantAbr"].ToString().Replace("-", "0")), Convert.ToInt32(e.NewValues["cantMay"].ToString().Replace("-", "0")), Convert.ToInt32(e.NewValues["cantJun"].ToString().Replace("-", "0")),
            //        Convert.ToInt32(e.NewValues["cantJul"].ToString().Replace("-", "0")), Convert.ToInt32(e.NewValues["cantAgo"].ToString().Replace("-", "0")), Convert.ToInt32(e.NewValues["cantSet"].ToString().Replace("-", "0")), Convert.ToInt32(e.NewValues["cantOct"].ToString().Replace("-", "0")), Convert.ToInt32(e.NewValues["cantNov"].ToString().Replace("-", "0")), Convert.ToInt32(e.NewValues["cantDic"].ToString().Replace("-", "0")));
            var errors = ValidateRow(ene, feb, mar, abr, may, jun, jul, ago, set, oct, nov, dic);

            if (string.IsNullOrEmpty(e.RowError) && errors.Any())
                e.RowError = "Por favor, corrija todos los errores.";
            foreach (var key in errors.Keys)
                e.Errors[grvDetalleMes.Columns[key]] = errors[key];
        }
        protected void grvDetalleMes_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {
            if (!object.Equals(e.RowType, GridViewRowType.Data)) return;

            int ene = Convert.ToInt32(e.GetValue("cantEne") != null ? e.GetValue("cantEne").ToString().Replace("-", "0").Replace(".0", "").Replace(".00", "") : "0");
            int feb = Convert.ToInt32(e.GetValue("cantFeb") != null ? e.GetValue("cantFeb").ToString().Replace("-", "0").Replace(".0", "").Replace(".00", "") : "0");
            int mar = Convert.ToInt32(e.GetValue("cantMar") != null ? e.GetValue("cantMar").ToString().Replace("-", "0").Replace(".0", "").Replace(".00", "") : "0");
            int abr = Convert.ToInt32(e.GetValue("cantAbr") != null ? e.GetValue("cantAbr").ToString().Replace("-", "0").Replace(".0", "").Replace(".00", "") : "0");
            int may = Convert.ToInt32(e.GetValue("cantMay") != null ? e.GetValue("cantMay").ToString().Replace("-", "0").Replace(".0", "").Replace(".00", "") : "0");
            int jun = Convert.ToInt32(e.GetValue("cantJun") != null ? e.GetValue("cantJun").ToString().Replace("-", "0").Replace(".0", "").Replace(".00", "") : "0");
            int jul = Convert.ToInt32(e.GetValue("cantJul") != null ? e.GetValue("cantJul").ToString().Replace("-", "0").Replace(".0", "").Replace(".00", "") : "0");
            int ago = Convert.ToInt32(e.GetValue("cantAgo") != null ? e.GetValue("cantAgo").ToString().Replace("-", "0").Replace(".0", "").Replace(".00", "") : "0");
            int set = Convert.ToInt32(e.GetValue("cantSet") != null ? e.GetValue("cantSet").ToString().Replace("-", "0").Replace(".0", "").Replace(".00", "") : "0");
            int oct = Convert.ToInt32(e.GetValue("cantOct") != null ? e.GetValue("cantOct").ToString().Replace("-", "0").Replace(".0", "").Replace(".00", "") : "0");
            int nov = Convert.ToInt32(e.GetValue("cantNov") != null ? e.GetValue("cantNov").ToString().Replace("-", "0").Replace(".0", "").Replace(".00", "") : "0");
            int dic = Convert.ToInt32(e.GetValue("cantNov") != null ? e.GetValue("cantNov").ToString().Replace("-", "0").Replace(".0", "").Replace(".00", "") : "0");

            var errors = ValidateRow(ene, feb, mar, abr, may, jun, jul, ago, set, oct, nov, dic);

            if (errors.Any())
                e.Row.CssClass = "text-danger";
        }
        protected Dictionary<string, string> ValidateRow(
                                                            int cantEne, int cantFeb, int cantMar, int cantAbr, int cantMay, int cantJun,
                                                            int cantJul, int cantAgo, int cantSet, int cantOct, int cantNov, int cantDic)
        {
            var errors = new Dictionary<string, string>();
            string mensaje = "Cantidad debe ser mayor ó igual a 0.";

            //if (!email.Contains("@"))
            //    errors["Email"] = "Invalid e-mail.";
            if (cantEne < 0)
                errors["cantEne"] = mensaje;
            if (cantFeb < 0)
                errors["cantFeb"] = mensaje;
            if (cantMar < 0)
                errors["cantMar"] = mensaje;
            if (cantAbr < 0)
                errors["cantAbr"] = mensaje;
            if (cantMay < 0)
                errors["cantMay"] = mensaje;
            if (cantJun < 0)
                errors["cantJun"] = mensaje;
            if (cantJul < 0)
                errors["cantJul"] = mensaje;
            if (cantAgo < 0)
                errors["cantAgo"] = mensaje;
            if (cantSet < 0)
                errors["cantSet"] = mensaje;
            if (cantOct < 0)
                errors["cantOct"] = mensaje;
            if (cantNov < 0)
                errors["cantNov"] = mensaje;
            if (cantDic < 0)
                errors["cantDic"] = mensaje;


            //if (DateTime.Today.Year != arrival.Year || DateTime.Today.Month != arrival.Month)
            //    errors["ArrivalDate"] = "Arrival date is required and must belong to the current month.";
            return errors;
        }

        protected void Upload_FileUploadComplete(object sender, DevExpress.Web.FileUploadCompleteEventArgs e)
        {
            FilePath = Page.MapPath("~/XlsTables/") + e.UploadedFile.FileName;
            e.UploadedFile.SaveAs(FilePath);
            Session["listaDetalleRequerimientoAnualMigraSession"] = null;
        }
        private DataTable GetTableFromExcel()
        {
            Workbook book = new Workbook();
            var idReq = hdfValores["idReq"].ToString();

            book.InvalidFormatException += book_InvalidFormatException;
            book.LoadDocument(FilePath);
            Worksheet sheet = book.Worksheets.ActiveWorksheet;
            CellRange range = sheet.GetUsedRange();

            DataTable dataExcel = new DataTable();
            dataExcel.Columns.Add("item", typeof(int));
            dataExcel.Columns.Add("idParPre", typeof(int));
            dataExcel.Columns.Add("idProducto", typeof(int));
            dataExcel.Columns.Add("tipo", typeof(int));
            dataExcel.Columns.Add("productoPartida", typeof(string));
            dataExcel.Columns.Add("descripcion", typeof(string));
            dataExcel.Columns.Add("idUnidad", typeof(int));
            dataExcel.Columns.Add("unidad", typeof(string));
            dataExcel.Columns.Add("idCueCon", typeof(int));
            dataExcel.Columns.Add("numCuenta", typeof(string));
            dataExcel.Columns.Add("precio", typeof(decimal));
            dataExcel.Columns.Add("justificacion", typeof(string));
            dataExcel.Columns.Add("cantEne", typeof(decimal));
            dataExcel.Columns.Add("cantFeb", typeof(decimal));
            dataExcel.Columns.Add("cantMar", typeof(decimal));
            dataExcel.Columns.Add("cantAbr", typeof(decimal));
            dataExcel.Columns.Add("cantMay", typeof(decimal));
            dataExcel.Columns.Add("cantJun", typeof(decimal));
            dataExcel.Columns.Add("cantJul", typeof(decimal));
            dataExcel.Columns.Add("cantAgo", typeof(decimal));
            dataExcel.Columns.Add("cantSet", typeof(decimal));
            dataExcel.Columns.Add("cantOct", typeof(decimal));
            dataExcel.Columns.Add("cantNov", typeof(decimal));
            dataExcel.Columns.Add("cantDic", typeof(decimal));


            if (sheet != null)
            {
                int rowCount = range.RowCount;
                for (int i = 1; i <= rowCount; i++)
                {
                    Cell cellIdPartida = range[i, 0];
                    Cell cellIdProducto = range[i, 1];
                    Cell cellDescripcion = range[i, 2];
                    Cell cellIdUnidad = range[i, 3];
                    Cell cellPrecio = range[i, 4];
                    Cell cellJustificacion = range[i, 5];
                    Cell cellCantEne = range[i, 6];
                    Cell cellCantFeb = range[i, 7];
                    Cell cellCantMar = range[i, 8];
                    Cell cellCantAbr = range[i, 9];
                    Cell cellCantMay = range[i, 10];
                    Cell cellCantJun = range[i, 11];
                    Cell cellCantJul = range[i, 12];
                    Cell cellCantAgo = range[i, 13];
                    Cell cellCantSet = range[i, 14];
                    Cell cellCantOct = range[i, 15];
                    Cell cellCantNov = range[i, 16];
                    Cell cellCantDic = range[i, 17];

                    int item = 0;
                    int idPartida = cellIdPartida.Value.Type != CellValueType.Numeric ? 0 : Convert.ToInt32(cellIdPartida.Value.NumericValue);
                    int idProducto = cellIdProducto.Value.Type != CellValueType.Numeric ? 0 : Convert.ToInt32(cellIdProducto.Value.NumericValue);
                    int tipo = 0;
                    string desProductoPartida = string.Empty;
                    string descripcion = cellDescripcion.Value.Type != CellValueType.Text ? "" : cellDescripcion.Value.TextValue;
                    int idUnidad = cellIdUnidad.Value.Type != CellValueType.Numeric ? 0 : Convert.ToInt32(cellIdUnidad.Value.NumericValue);
                    string desUnidad = string.Empty;
                    int idCuenta = 0;
                    string numCuenta = string.Empty;
                    decimal precio = cellPrecio.Value.Type != CellValueType.Numeric ? 0 : Convert.ToInt32(cellPrecio.Value.NumericValue);
                    string justificacion = cellJustificacion.Value.Type != CellValueType.Text ? "" : cellJustificacion.Value.TextValue;
                    
                    decimal cantEne = cellCantEne.Value.Type != CellValueType.Numeric ? Convert.ToDecimal(0) : Convert.ToDecimal(cellCantEne.Value.NumericValue);
                    decimal cantFeb = cellCantFeb.Value.Type != CellValueType.Numeric ? Convert.ToDecimal(0) : Convert.ToDecimal(cellCantFeb.Value.NumericValue);
                    decimal cantMar = cellCantMar.Value.Type != CellValueType.Numeric ? Convert.ToDecimal(0) : Convert.ToDecimal(cellCantMar.Value.NumericValue);
                    decimal cantAbr = cellCantAbr.Value.Type != CellValueType.Numeric ? Convert.ToDecimal(0) : Convert.ToDecimal(cellCantAbr.Value.NumericValue);
                    decimal cantMay = cellCantMay.Value.Type != CellValueType.Numeric ? Convert.ToDecimal(0) : Convert.ToDecimal(cellCantMay.Value.NumericValue);
                    decimal cantJun = cellCantJun.Value.Type != CellValueType.Numeric ? Convert.ToDecimal(0) : Convert.ToDecimal(cellCantJun.Value.NumericValue);
                    decimal cantJul = cellCantJul.Value.Type != CellValueType.Numeric ? Convert.ToDecimal(0) : Convert.ToDecimal(cellCantJul.Value.NumericValue);
                    decimal cantAgo = cellCantAgo.Value.Type != CellValueType.Numeric ? Convert.ToDecimal(0) : Convert.ToDecimal(cellCantAgo.Value.NumericValue);
                    decimal cantSet = cellCantSet.Value.Type != CellValueType.Numeric ? Convert.ToDecimal(0) : Convert.ToDecimal(cellCantSet.Value.NumericValue);
                    decimal cantOct = cellCantOct.Value.Type != CellValueType.Numeric ? Convert.ToDecimal(0) : Convert.ToDecimal(cellCantOct.Value.NumericValue);
                    decimal cantNov = cellCantNov.Value.Type != CellValueType.Numeric ? Convert.ToDecimal(0) : Convert.ToDecimal(cellCantNov.Value.NumericValue);
                    decimal cantDic = cellCantDic.Value.Type != CellValueType.Numeric ? Convert.ToDecimal(0) : Convert.ToDecimal(cellCantDic.Value.NumericValue);
                    

                    if (cellIdPartida != null & cellIdProducto != null & cellDescripcion != null & cellIdUnidad != null & cellPrecio != null & cellJustificacion != null)
                        dataExcel.Rows.Add(
                            item, idPartida, idProducto, tipo, desProductoPartida, descripcion, idUnidad, desUnidad, idCuenta, numCuenta, precio, justificacion,
                            cantEne, cantFeb, cantMar, cantAbr, cantMay, cantJun,
                            cantJul, cantAgo, cantSet, cantOct, cantNov, cantDic
                            );

                }
            }


            DataTable dataConFormato = new DataTable();
            dataConFormato = this.requerimientoBienServicioDetallePresentador.ListaEstructuraCargaRequerimientoAnual(Convert.ToInt32(idReq), dataExcel);
            if (dataConFormato.Rows.Count > 0)
                Session["listaDetalleRequerimientoAnualMigraSession"] = dataConFormato;
            else
                dataConFormato = null;

            return dataConFormato;
        }

        void exporter_CellValueConversionError(object sender, CellValueConversionErrorEventArgs e)
        {
            e.Action = DataTableExporterAction.Continue;
            e.DataTableValue = null;
        }

        void book_InvalidFormatException(object sender, SpreadsheetInvalidFormatExceptionEventArgs e)
        {

        }

        protected void grvDetalleRequerimientoMigra_Init(object sender, EventArgs e)
        {
            this.requerimientoBienServicioDetallePresentador = new RequerimientoBienServicioDetallePresentador(this);
            this.requerimientoBienServicioDetallePresentador.CargarServicios();

            if (!String.IsNullOrEmpty(FilePath) || Session["listaDetalleRequerimientoAnualMigraSession"] != null)
            {
                grvDetalleRequerimientoMigra.DataSource = Session["listaDetalleRequerimientoAnualMigraSession"] != null ? (DataTable)Session["listaDetalleRequerimientoAnualMigraSession"] : GetTableFromExcel();
                grvDetalleRequerimientoMigra.DataBind();

            }
        }
        protected void btnMigra_Click(object sender, EventArgs e)
        {
            var idReq = hdfValores["idReq"].ToString();

            if (!String.IsNullOrEmpty(FilePath) || Session["listaDetalleRequerimientoAnualMigraSession"] != null)
            {
                if (this.requerimientoBienServicioDetallePresentador.GuardarDatosDesdeExcel(Convert.ToInt32(idReq), (DataTable)Session["listaDetalleRequerimientoAnualMigraSession"]))
                {
                    EmitirMensajeResultado("Se registró correctamente");
                    Session["listaDetalleRequerimientoAnualMigraSession"] = null;
                    grvDetalleRequerimientoMigra.DataSource = null;
                    grvDetalleRequerimientoMigra.DataBind();
                    popImportar.ShowOnPageLoad = false;
                }
                else
                    EmitirMensajeResultado("Error al procesar requerimiento");
                Actualizar();

            }
        }

        private void EmitirMensajeResultado(string mensaje)
        {
            BootstrapPopupControl popup = (BootstrapPopupControl)cpPrincipal.FindControl("popInformacion");
            popup.Text = mensaje;
            popup.ShowOnPageLoad = true;
        }

    }
}