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
using SIA_Presupuesto.Negocio.Entidades.Enumeradores;
using System.Web.DynamicData;

namespace SIA_Presupuesto.WebForm.Programacion
{
    public partial class frmRequerimientoMensualBienServicio : System.Web.UI.Page, IRequerimientoMensualBienServicioDetalleVista
    {
        private RequerimientoMensualBienServicioDetallePresentador requerimientoMensualBienServicioDetallePresentador;

        public List<RequerimientoMensualDetallePres> listaDatosPrincipales
        {
            set
            {
                this.grvReqMenDet.DataSource = value;
                this.grvReqMenDet.DataBind();
            }
        }
        
        public List<RequerimientoMensualDetallePres> listaGridData
        {
            set; get;
        }
        

        public string nomUsuario { get { return Session["nomUsuario"] != null ? Session["nomUsuario"].ToString() : string.Empty; } }

        public string desArea
        {
            set { lblDescripcion.Text = value.ToString(); }
        }
        public string desTipoCambio
        {
            set { lblTipoCambio.Text = value.ToString(); }
        }
        public int idMoneda
        {
            set { Session["idMoneda"] = value; }
            get { return Convert.ToInt32(Session["idMoneda"].ToString()); }
        }
        public string estadoReqMen
        {
            set { cpPrincipal.JSProperties["cpEstadoReqMen"] = value.ToString(); }
            get { return cpPrincipal.JSProperties["cpEstadoReqMen"].ToString(); }
        }

        /*Detalle*/
        public int idReqMenBieSer
        {
            set { hdfValores["idReq"] = value.ToString(); }
            get { return Convert.ToInt32(hdfValores["idReq"]); }
        }
        public int tipo
        {
            set { Session["tipo"] = value.ToString(); }
            get { return Convert.ToInt32(Session["tipo"]); }
        }
        public string desTipo
        {
            set { lblTipo.Text = value; }
        }
        public int? idProducto
        {
            set
            {
                hdfValores["idProducto"] = value.ToString();
                popReqDet.JSProperties["cpIdProducto"] = value.ToString();
            }
            get { return Convert.ToInt32(hdfValores["idProducto"]); }
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
        public string desPartidaPre
        {
            set { btnSelecPartida.Text = value; }
        }
        public string desProducto
        {
            set { btnSelecProducto.Text = value; }
        }


        public int idCueCon
        {
            set
            {
                hdfValores["idCueCon"] = value.ToString();
                popReqDet.JSProperties["cpIdCueCon"] = value.ToString();
            }
            get { return Convert.ToInt32(hdfValores["idCueCon"]); }
        }
        public string desCuenta
        {
            set { lblCuenta.Text = value; }
        }
        public int idUnidad
        {
            set { cbUnidad.Value = value.ToString(); }
            get { return Convert.ToInt32(cbUnidad.Value.ToString()); }
        }
        public List<Unidad> listaUnidades
        {
            set
            {
                this.cbUnidad.DataSource = value;
                this.cbUnidad.DataBind();
            }
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
        public decimal cantidad
        {
            set { seCantidad.Value = value; }
            get { return Convert.ToDecimal(seCantidad.Value); }
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

        public string datoDescripcionPartida
        {
            set { txtBuscarPartida.Text = value.ToString(); }
            get { return txtBuscarPartida.Text; }
            //set { hdfValores["datoDescripcionPartida"] = value.ToString(); }
            //get { return hdfValores["datoDescripcionPartida"].ToString(); }
        }
        public string datoDescripcion
        {
            //set { hdfValores["datoDescripcion"] = value.ToString(); }
            //get { return hdfValores["datoDescripcion"].ToString(); }
            set { txtBuscarProducto.Text = value.ToString(); }
            get { return txtBuscarProducto.Text; }
        }

        public decimal importe
        {
            set { seSubtotal.Value = value; }
            get { return Convert.ToDecimal(seSubtotal.Value); }
        }

        string FilePath
        {
            get { return Session["FilePath"] == null ? String.Empty : Session["FilePath"].ToString(); }
            set { Session["FilePath"] = value; }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            this.requerimientoMensualBienServicioDetallePresentador = new RequerimientoMensualBienServicioDetallePresentador(this);
            this.requerimientoMensualBienServicioDetallePresentador.CargarServicios();
            FilePath = String.Empty;
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
                Session["idMoneda"] = 63;
                hdfValores["idProducto"] = 0;
                hdfValores["idParPre"] = 0;
                hdfValores["idCueCon"] = 0;
                
                hdfValores["datoDescripcion"] = string.Empty;
                var simbolo = this.requerimientoMensualBienServicioDetallePresentador.BuscarSimboloMoneda(Convert.ToInt32(Request.Params.Get("idReq")));
                grvReqMenDet.Columns["precio"].Caption = string.Format("Precio {0}", simbolo);
                grvReqMenDet.Columns["importe"].Caption = string.Format("Subtotal {0}", simbolo);
                this.requerimientoMensualBienServicioDetallePresentador.TraerRequerimientoBienServicio();
                
                datoDescripcionPartida = string.Empty;
                datoDescripcion = string.Empty;

                Session["listaDetalleRequerimientoMigraSession"] = null;

            }
            Actualizar();
        }

        public void Actualizar()
        {
            // modificando the Current Culture
            Thread.CurrentThread.CurrentCulture = Session["idMoneda"] == null ? new CultureInfo("es-PE") : Convert.ToInt32(Session["idMoneda"].ToString()) == 63 ? new CultureInfo("es-PE") : new CultureInfo("en-US");
            this.requerimientoMensualBienServicioDetallePresentador.Iniciar();
            this.listaDatosPrincipales = this.listaGridData;
            
            grvReqMenDet.ExpandAll();
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
                Resultado resultado = this.requerimientoMensualBienServicioDetallePresentador.GuardarDatos(args[2]);
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
                if (this.requerimientoMensualBienServicioDetallePresentador.AnularDetalle(Convert.ToInt32(args[1])))
                    cpPrincipal.JSProperties["cpMensaje"] = "Anulado correctamente";
                else
                    cpPrincipal.JSProperties["cpMensaje"] = "No se pudo anular";
            }
            cpPrincipal.JSProperties["cpGrid"] = "grvReqMenDet";

        }

        protected void grvReqMenDet_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            grvReqMenDet.DataBind();
        }

        protected void grvReqMenDet_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            UpdateItem(e.Keys, e.NewValues, e.OldValues);
            CancelEditing(e);
        }
        protected void CancelEditing(CancelEventArgs e)
        {
            e.Cancel = true;
            grvReqMenDet.CancelEdit();
        }
        protected void grvReqMenDet_BatchUpdate(object sender, ASPxDataBatchUpdateEventArgs e)
        {
            foreach (var args in e.UpdateValues)
            {
                UpdateItem(args.Keys, args.NewValues, args.OldValues);
            }
            this.requerimientoMensualBienServicioDetallePresentador.LlenarGrid();
            this.listaDatosPrincipales = this.listaGridData;

            e.Handled = true;
        }
        protected RequerimientoMensualDetallePres UpdateItem(OrderedDictionary keys, OrderedDictionary newValues, OrderedDictionary oldValues)
        {
            var id = Convert.ToInt32(keys["idReqMenDet"]);
            var item = this.listaGridData.First(i => i.idReqMenDet == id);
            LoadNewValues(item, newValues, oldValues);
            return item;
        }
        protected void LoadNewValues(RequerimientoMensualDetallePres item, OrderedDictionary newValues, OrderedDictionary oldValues)
        {
            item.cantidad = newValues["cantidad"] != null ? Convert.ToDecimal(newValues["cantidad"]) : 0.0m;
            
            if ((newValues["cantidad"] != null ? Convert.ToDecimal(newValues["cantidad"]) : 0.0m) != (oldValues["cantidad"] != null ? Convert.ToDecimal(oldValues["cantidad"]) : 0.0m)) //(e.NewValues["cantEnero"] != e.OldValues["cantEnero"])
            {
                this.requerimientoMensualBienServicioDetallePresentador.IngresarCantidadDetalle(item.idReqMenDet, (Decimal)item.cantidad);
            }
        }

        protected void grvReqMenDet_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {
            //Validación de cantidad
            decimal enero = e.NewValues["cantidad"] != null ? (decimal)e.NewValues["cantidad"] : 0;
            if (enero < 0)
            {
                AddError(e.Errors, grvReqMenDet.Columns["cantidad"], "La cantidad debe ser mayor o igual a cero");
            }
        }

        void AddError(Dictionary<GridViewColumn, string> errors, GridViewColumn column, string errorText)
        {
            if (errors.ContainsKey(column)) return;
            errors[column] = errorText;
        }

        protected void grvReqMenDet_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            if (!grvReqMenDet.IsNewRowEditing)
            {
                grvReqMenDet.DoRowValidation();
            }
        }
        protected void grvReqMenDet_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            ASPxEdit editor = (ASPxEdit)e.Editor;
            editor.ValidationSettings.Display = Display.Dynamic;
        }

    
        protected void popReqDet_Callback(object sender, CallbackEventArgsBase e)
        {
            var args = e.Parameter.Split('|');
            int id = 0;
            var idReq = hdfValores["idReq"].ToString();

            var tipo = Session["tipo"].ToString();
            string opcion = string.Empty;

            if (tipo.Equals("2"))
            {
                chkConPartida.Checked = true;
                chkConPartida.ClientEnabled = false;
                frmDetalle.FindItemOrGroupByName("bliProducto").ClientVisible = false;
                btnSelecPartida.Focus();
            }
            else
            {
                chkConPartida.Checked = false;
                frmDetalle.FindItemOrGroupByName("bliPartida").ClientVisible = false;
                btnSelecProducto.Focus();
            }

            switch (args[0])
            {
                case "Nuevo":
                    this.requerimientoMensualBienServicioDetallePresentador.IniciarDatos(Convert.ToInt32(hdfValores["idReq"]) ,0);
                    seCantidad.Value = 1;
                    opcion = "Nuevo";
                    break;
                case "Editar":
                    id = !string.IsNullOrEmpty(args[1]) ? int.Parse(args[1]) : 0;
                    chkConPartida.ClientEnabled = false;
                    this.requerimientoMensualBienServicioDetallePresentador.IniciarDatos(Convert.ToInt32(hdfValores["idReq"]), id);
                    opcion = "Editar";
                    break;
                case "Mostrar":
                    id = !string.IsNullOrEmpty(args[1]) ? int.Parse(args[1]) : 0;
                    this.requerimientoMensualBienServicioDetallePresentador.IniciarDatos(Convert.ToInt32(hdfValores["idReq"]), id);
                    chkConPartida.ClientEnabled = false;
                    btnSelecPartida.ClientEnabled = false;
                    btnSelecProducto.ClientEnabled = false;
                    txtDescripcion.ClientEnabled = false;
                    txtJustificacion.ClientEnabled = false;
                    cbUnidad.ClientEnabled = false;
                    sePrecio.ClientEnabled = false;
                    seCantidad.ClientEnabled = false;
                    popReqDet.FindControl("btnGrabar").Visible = false;
                    opcion = "Mostrar";
                    break;
            }
            popReqDet.JSProperties["cpID"] = id;
            popReqDet.JSProperties["cpOpcion"] = opcion;
        }

        protected void popAyudaPartidaPrecio_WindowCallback(object source, DevExpress.Web.CallbackEventArgsBase e)
        {
            grvPartidaPrecio.DataBind();
        }
        protected void grvPartidaPrecio_DataBinding(object sender, EventArgs e)
        {
            var tipo = Session["tipo"].ToString();
            var idMoneda = Session["idMoneda"].ToString();

            this.requerimientoMensualBienServicioDetallePresentador.TraerPartidaPrecio(Convert.ToInt32(tipo), datoDescripcionPartida, Convert.ToInt32(idMoneda));
        }
        protected void grvPartidaPrecio_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            //string[] parametro = e.Parameters.Split('|');
            ////datoDescripcionPartida = !string.IsNullOrEmpty(parametro[0]) ? parametro[0].ToString():string.Empty;
            //grvPartidaPrecio.DataBind();
        }

        protected void popAyudaProductoPrecio_WindowCallback(object source, DevExpress.Web.CallbackEventArgsBase e)
        {
            grvProductoPrecio.DataBind();
        }
        protected void grvProductoPrecio_DataBinding(object sender, EventArgs e)
        {
            var idMoneda = Session["idMoneda"].ToString();
            requerimientoMensualBienServicioDetallePresentador.TraerProductoPrecio(datoDescripcion, Convert.ToInt32(idMoneda));
        }
        protected void grvProductoPrecio_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            //string[] parametro = e.Parameters.Split('|');
            //datoDescripcion = !string.IsNullOrEmpty(parametro[0]) ? parametro[0].ToString() : string.Empty;
            //grvProductoPrecio.DataBind();
        }
        protected void Upload_FileUploadComplete(object sender, DevExpress.Web.FileUploadCompleteEventArgs e)
        {
            FilePath = Page.MapPath("~/XlsTables/") + e.UploadedFile.FileName;
            e.UploadedFile.SaveAs(FilePath);
            Session["listaDetalleRequerimientoMigraSession"] = null;
        }
        private DataTable GetTableFromExcel()
        {
            Workbook book = new Workbook();
            var idReq = hdfValores["idReq"].ToString();

            book.InvalidFormatException += book_InvalidFormatException;
            book.LoadDocument(FilePath);
            Worksheet sheet = book.Worksheets.ActiveWorksheet;
            CellRange range = sheet.GetUsedRange();


            ///Antes
            //DataTable table = sheet.CreateDataTable(range, false);
            //DataTableExporter exporter = sheet.CreateDataTableExporter(range, table, false);
            //exporter.CellValueConversionError += exporter_CellValueConversionError;
            //exporter.Export();
            //Antes

            //IWorkbook MiExcel = null;
            //FileStream fs = new FileStream(FilePath, FileMode.Open, FileAccess.Read);

            //if (Path.GetExtension(FilePath) == ".xlsx")
            //    MiExcel = new XSSFWorkbook(fs);
            //else
            //    MiExcel = new HSSFWorkbook(fs);


            //ISheet hoja = MiExcel.GetSheetAt(0);


            DataTable dataExcel = new DataTable();
            dataExcel.Columns.Add("idParPre", typeof(int));
            dataExcel.Columns.Add("idProducto", typeof(int));
            dataExcel.Columns.Add("productoPartida", typeof(string));
            dataExcel.Columns.Add("descripcion", typeof(string));
            dataExcel.Columns.Add("idUnidad", typeof(int));
            dataExcel.Columns.Add("unidad", typeof(string));
            dataExcel.Columns.Add("idCueCon", typeof(int));
            dataExcel.Columns.Add("numCuenta", typeof(string));
            dataExcel.Columns.Add("precio", typeof(decimal));
            dataExcel.Columns.Add("cantidad", typeof(decimal));
            dataExcel.Columns.Add("justificacion", typeof(string));

            //DataTable dt = new DataTable();
            //dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Id"), new DataColumn("Name"), new DataColumn("Country") });
            //dt.Rows.Add(1, "John Hammond", "United States");
            //dt.Rows.Add(2, "Mudassar Khan", "India");
            //dt.Rows.Add(3, "Suzanne Mathews", "France");
            //dt.Rows.Add(4, "Robert Schidner", "Russia");


            // Access a collection of rows.
            //RowCollection rows = book.Worksheets[0].Rows;

            // Access the first row by its index in the collection of rows.
            //Row firstRow_byIndex = rows[0];
            if (sheet != null)
            {

                //int cantidadfilas = sheet.Rows[0].RowCount;
                int rowCount = range.RowCount;
                for (int i = 1; i <= rowCount; i++)
                {
                    Cell cellIdPartida = range[i, 0];
                    Cell cellIdProducto = range[i, 1];
                    Cell cellDescripcion = range[i, 2];
                    Cell cellIdUnidad = range[i, 3];
                    Cell cellPrecio = range[i, 4];
                    Cell cellCantidad = range[i, 5];
                    Cell cellJustificacion = range[i, 6];

                    int idPartida = cellIdPartida.Value.Type != CellValueType.Numeric ? 0 : Convert.ToInt32(cellIdPartida.Value.NumericValue);
                    int idProducto = cellIdProducto.Value.Type != CellValueType.Numeric ? 0 : Convert.ToInt32(cellIdProducto.Value.NumericValue);
                    string desProductoPartida = string.Empty;
                    string descripcion = cellDescripcion.Value.Type != CellValueType.Text ? "" : cellDescripcion.Value.TextValue;
                    int idUnidad = cellIdUnidad.Value.Type != CellValueType.Numeric ? 0 : Convert.ToInt32(cellIdUnidad.Value.NumericValue);
                    string desUnidad = string.Empty;
                    int idCuenta = 0;
                    string numCuenta = string.Empty;
                    decimal precio = cellPrecio.Value.Type != CellValueType.Numeric ? 0 : Convert.ToInt32(cellPrecio.Value.NumericValue);
                    decimal cantidad = cellCantidad.Value.Type != CellValueType.Numeric ? 0 : Convert.ToInt32(cellCantidad.Value.NumericValue);
                    string justificacion = cellJustificacion.Value.Type != CellValueType.Text ? "" : cellJustificacion.Value.TextValue;

                    //if (idPartida > 0 || idProducto > 0)
                    //{
                    //    ProductoPartidaPres obj = new ProductoPartidaPres();
                    //    var tipo = idProducto > 0 ? 1 : 2;
                    //    var idProPar = idPartida > 0 ? idPartida : idProducto;

                    //    obj = this.requerimientoMensualBienServicioDetallePresentador.BuscarProductoPartida(tipo, idProPar);

                    //    desProductoPartida = obj.descripcion;
                    //    idCuenta = (Int32)obj.idCueCon;
                    //    numCuenta = obj.numCuenta;
                    //}
                    //if (idUnidad > 0)
                    //{
                    //    Unidad objUnidad = this.requerimientoMensualBienServicioDetallePresentador.BuscarUnidadMedida(idUnidad);

                    //    desUnidad = objUnidad.nomUnidad;
                    //}

                    if (cellIdPartida != null & cellIdProducto != null & cellDescripcion != null & cellIdUnidad != null & cellPrecio != null & cellCantidad != null & cellJustificacion != null)
                        dataExcel.Rows.Add(idPartida, idProducto, desProductoPartida, descripcion, idUnidad, desUnidad, idCuenta, numCuenta, precio, cantidad, justificacion);




                    //if (cellIdPartida != null & cellIdProducto != null & cellDescripcionDetalle != null & cellIdUnidad != null & cellPrecio != null & cellCantidad != null & cellJustificacion != null)
                    //    table.Rows.Add(idPartida, idProducto, descripcionDetalle, idUnidad, precio, cantidad, justificacion);
                }
            }
            

            DataTable dataConFormato = new DataTable();
            dataConFormato = this.requerimientoMensualBienServicioDetallePresentador.ListaEstructuraCargaRequerimientoMensual(Convert.ToInt32(idReq), dataExcel);
            if(dataConFormato.Rows.Count>0)
                Session["listaDetalleRequerimientoMigraSession"] = dataConFormato;
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
            this.requerimientoMensualBienServicioDetallePresentador = new RequerimientoMensualBienServicioDetallePresentador(this);
            this.requerimientoMensualBienServicioDetallePresentador.CargarServicios();

            if (!String.IsNullOrEmpty(FilePath) || Session["listaDetalleRequerimientoMigraSession"] != null)
            {
                //LlenarGridDesdeExcel();
                grvDetalleRequerimientoMigra.DataSource = Session["listaDetalleRequerimientoMigraSession"] != null ? (DataTable)Session["listaDetalleRequerimientoMigraSession"] : GetTableFromExcel();
                grvDetalleRequerimientoMigra.DataBind();
                
                //BootstrapPopupControl popup = (BootstrapPopupControl)cpPrincipal.FindControl("popImportar");
                //BootstrapButton ctrl = popImportar.FindControl("btnMigra") as BootstrapButton;
                //BootstrapButton button = (BootstrapButton)popup.FindFieldTemplate("btnMigra");
                //button.ClientEnabled = true;
            }
        }
        protected void btnMigra_Click(object sender, EventArgs e)
        {
            var idReq = hdfValores["idReq"].ToString();

            //var objId = grvRequerimientoMensual.GetSelectedFieldValues(grvRequerimientoMensual.KeyFieldName) == null ? null : grvRequerimientoMensual.GetSelectedFieldValues(grvRequerimientoMensual.KeyFieldName);
            //var objEstado = grvRequerimientoMensual.GetSelectedFieldValues(grvRequerimientoMensual.KeyFieldName) == null ? null : grvRequerimientoMensual.GetSelectedFieldValues("estado");
            //if (objId == null || objEstado == null) return;

            //int idReqMenBieSer = Convert.ToInt32(objId[0].ToString());
            //int estado = Convert.ToInt32(objEstado[0].ToString());

            //if (estado == 2) return;
            //if (estado == 59)
            //{
            //    EmitirMensajeResultado("Error: no es posisble anular aprobación, requerimiento ya fue asignado un presupuesto");
            //    return;
            //}

            if (!String.IsNullOrEmpty(FilePath) || Session["listaDetalleRequerimientoMigraSession"] != null)
            {
                if (this.requerimientoMensualBienServicioDetallePresentador.GuardarDatosDesdeExcel(Convert.ToInt32(idReq), (DataTable)Session["listaDetalleRequerimientoMigraSession"]))
                {
                    EmitirMensajeResultado("Se registró correctamente");
                    Session["listaDetalleRequerimientoMigraSession"] = null;
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