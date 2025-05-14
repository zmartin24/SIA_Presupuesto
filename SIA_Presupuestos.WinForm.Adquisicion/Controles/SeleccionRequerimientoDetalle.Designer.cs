namespace SIA_Presupuesto.WinForm.Adquisicion.Controles
{
    partial class SeleccionRequerimientoDetalle
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gcRequerimiento = new DevExpress.XtraGrid.GridControl();
            this.gvRequerimiento = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcSeleccionar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riceSeleccionar = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gcCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUnidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPrecio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.risePrecio = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.gcCantidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riseCant = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.gcSubTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCuenta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcIdPreMen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.obgDetalle = new SIA_Presupuesto.WinForm.General.ControlesDiversos.OpcionesBarraGrid();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciOpcionDetalle = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcRequerimiento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRequerimiento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riceSeleccionar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.risePrecio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riseCant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciOpcionDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gcRequerimiento);
            this.layoutControl1.Controls.Add(this.obgDetalle);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(757, 389);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gcRequerimiento
            // 
            this.gcRequerimiento.EmbeddedNavigator.Buttons.Append.Enabled = false;
            this.gcRequerimiento.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcRequerimiento.EmbeddedNavigator.Buttons.CancelEdit.Enabled = false;
            this.gcRequerimiento.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcRequerimiento.EmbeddedNavigator.Buttons.Edit.Enabled = false;
            this.gcRequerimiento.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcRequerimiento.EmbeddedNavigator.Buttons.EndEdit.Enabled = false;
            this.gcRequerimiento.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gcRequerimiento.EmbeddedNavigator.Buttons.Remove.Enabled = false;
            this.gcRequerimiento.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcRequerimiento.Location = new System.Drawing.Point(12, 40);
            this.gcRequerimiento.MainView = this.gvRequerimiento;
            this.gcRequerimiento.Name = "gcRequerimiento";
            this.gcRequerimiento.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riceSeleccionar,
            this.risePrecio,
            this.riseCant});
            this.gcRequerimiento.Size = new System.Drawing.Size(733, 337);
            this.gcRequerimiento.TabIndex = 20;
            this.gcRequerimiento.UseEmbeddedNavigator = true;
            this.gcRequerimiento.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvRequerimiento});
            // 
            // gvRequerimiento
            // 
            this.gvRequerimiento.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcSeleccionar,
            this.gcCodigo,
            this.gcDesc,
            this.gcUnidad,
            this.gcPrecio,
            this.gcCantidad,
            this.gcSubTotal,
            this.gcCuenta,
            this.gcIdPreMen});
            this.gvRequerimiento.GridControl = this.gcRequerimiento;
            this.gvRequerimiento.Name = "gvRequerimiento";
            this.gvRequerimiento.OptionsBehavior.SummariesIgnoreNullValues = true;
            this.gvRequerimiento.OptionsPrint.PrintSelectedRowsOnly = true;
            this.gvRequerimiento.OptionsView.ColumnAutoWidth = false;
            this.gvRequerimiento.OptionsView.ShowAutoFilterRow = true;
            this.gvRequerimiento.OptionsView.ShowFooter = true;
            this.gvRequerimiento.OptionsView.ShowGroupPanel = false;
            this.gvRequerimiento.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvRequerimiento_CellValueChanged);
            this.gvRequerimiento.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gvRequerimiento_CustomUnboundColumnData);
            this.gvRequerimiento.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.grvRequerimiento_CustomColumnDisplayText);
            // 
            // gcSeleccionar
            // 
            this.gcSeleccionar.Caption = "Seleccion";
            this.gcSeleccionar.ColumnEdit = this.riceSeleccionar;
            this.gcSeleccionar.FieldName = "retornar";
            this.gcSeleccionar.Name = "gcSeleccionar";
            this.gcSeleccionar.OptionsColumn.AllowMove = false;
            this.gcSeleccionar.OptionsColumn.AllowSize = false;
            this.gcSeleccionar.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gcSeleccionar.OptionsColumn.FixedWidth = true;
            this.gcSeleccionar.OptionsColumn.ShowCaption = false;
            this.gcSeleccionar.OptionsFilter.AllowAutoFilter = false;
            this.gcSeleccionar.OptionsFilter.AllowFilter = false;
            this.gcSeleccionar.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            this.gcSeleccionar.Visible = true;
            this.gcSeleccionar.VisibleIndex = 0;
            this.gcSeleccionar.Width = 30;
            // 
            // riceSeleccionar
            // 
            this.riceSeleccionar.Name = "riceSeleccionar";
            this.riceSeleccionar.CheckedChanged += new System.EventHandler(this.riceSeleccionar_CheckedChanged);
            this.riceSeleccionar.CheckStateChanged += new System.EventHandler(this.riceSeleccionar_CheckStateChanged);
            // 
            // gcCodigo
            // 
            this.gcCodigo.Caption = "Codigo";
            this.gcCodigo.FieldName = "idDetalle";
            this.gcCodigo.Name = "gcCodigo";
            this.gcCodigo.OptionsColumn.ReadOnly = true;
            this.gcCodigo.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcCodigo.Visible = true;
            this.gcCodigo.VisibleIndex = 1;
            this.gcCodigo.Width = 55;
            // 
            // gcDesc
            // 
            this.gcDesc.Caption = "Descripción";
            this.gcDesc.FieldName = "descripcion";
            this.gcDesc.Name = "gcDesc";
            this.gcDesc.OptionsColumn.ReadOnly = true;
            this.gcDesc.Visible = true;
            this.gcDesc.VisibleIndex = 2;
            this.gcDesc.Width = 250;
            // 
            // gcUnidad
            // 
            this.gcUnidad.AppearanceCell.Options.UseTextOptions = true;
            this.gcUnidad.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gcUnidad.Caption = "Unidad";
            this.gcUnidad.FieldName = "unidad";
            this.gcUnidad.Name = "gcUnidad";
            this.gcUnidad.OptionsColumn.ReadOnly = true;
            this.gcUnidad.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcUnidad.Visible = true;
            this.gcUnidad.VisibleIndex = 3;
            this.gcUnidad.Width = 60;
            // 
            // gcPrecio
            // 
            this.gcPrecio.AppearanceCell.Options.UseTextOptions = true;
            this.gcPrecio.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gcPrecio.Caption = "Precio";
            this.gcPrecio.ColumnEdit = this.risePrecio;
            this.gcPrecio.DisplayFormat.FormatString = "{0:n}";
            this.gcPrecio.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcPrecio.FieldName = "precio";
            this.gcPrecio.Name = "gcPrecio";
            this.gcPrecio.Visible = true;
            this.gcPrecio.VisibleIndex = 4;
            this.gcPrecio.Width = 65;
            // 
            // risePrecio
            // 
            this.risePrecio.AutoHeight = false;
            this.risePrecio.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.risePrecio.EditFormat.FormatString = "n2";
            this.risePrecio.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.risePrecio.Mask.EditMask = "n2";
            this.risePrecio.Name = "risePrecio";
            // 
            // gcCantidad
            // 
            this.gcCantidad.Caption = "Cantidad";
            this.gcCantidad.ColumnEdit = this.riseCant;
            this.gcCantidad.DisplayFormat.FormatString = "{0:n}";
            this.gcCantidad.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcCantidad.FieldName = "cantidad";
            this.gcCantidad.Name = "gcCantidad";
            this.gcCantidad.Visible = true;
            this.gcCantidad.VisibleIndex = 5;
            this.gcCantidad.Width = 65;
            // 
            // riseCant
            // 
            this.riseCant.AutoHeight = false;
            this.riseCant.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.riseCant.EditFormat.FormatString = "n2";
            this.riseCant.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.riseCant.Mask.EditMask = "n2";
            this.riseCant.Name = "riseCant";
            // 
            // gcSubTotal
            // 
            this.gcSubTotal.Caption = "Sub. Total";
            this.gcSubTotal.DisplayFormat.FormatString = "{0:n}";
            this.gcSubTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcSubTotal.FieldName = "subTotal";
            this.gcSubTotal.Name = "gcSubTotal";
            this.gcSubTotal.OptionsColumn.ReadOnly = true;
            this.gcSubTotal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "subTotal", "Total = {0:n}")});
            this.gcSubTotal.Visible = true;
            this.gcSubTotal.VisibleIndex = 6;
            this.gcSubTotal.Width = 100;
            // 
            // gcCuenta
            // 
            this.gcCuenta.Caption = "Cta. Asig.";
            this.gcCuenta.FieldName = "numCuenta";
            this.gcCuenta.Name = "gcCuenta";
            this.gcCuenta.Visible = true;
            this.gcCuenta.VisibleIndex = 7;
            this.gcCuenta.Width = 60;
            // 
            // gcIdPreMen
            // 
            this.gcIdPreMen.AppearanceCell.Options.UseTextOptions = true;
            this.gcIdPreMen.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcIdPreMen.Caption = "IdPre";
            this.gcIdPreMen.FieldName = "idProAnuReaMen";
            this.gcIdPreMen.Name = "gcIdPreMen";
            this.gcIdPreMen.OptionsColumn.ReadOnly = true;
            this.gcIdPreMen.Width = 70;
            // 
            // obgDetalle
            // 
            this.obgDetalle.ConAgregar = true;
            this.obgDetalle.ConDesMarcarTodos = true;
            this.obgDetalle.ConMarcarTodos = true;
            this.obgDetalle.ConModificar = false;
            this.obgDetalle.ConNuevoDetalle = true;
            this.obgDetalle.ConOtros = false;
            this.obgDetalle.ConQuitar = true;
            this.obgDetalle.ConVisualizar = true;
            this.obgDetalle.Location = new System.Drawing.Point(12, 12);
            this.obgDetalle.Name = "obgDetalle";
            this.obgDetalle.NombreAgregar = "Agregar";
            this.obgDetalle.NombreModificar = "";
            this.obgDetalle.NombreNuevoDetalleRegistro = "Asignar Cta. Pre.";
            this.obgDetalle.NombreOtros = "";
            this.obgDetalle.NombreQuitar = "Quitar";
            this.obgDetalle.NombreVisualizar = "Ver Precio";
            this.obgDetalle.Size = new System.Drawing.Size(733, 24);
            this.obgDetalle.TabIndex = 22;
            this.obgDetalle.AgregarRegistro += new System.EventHandler(this.obgDetalle_AgregarRegistro);
            this.obgDetalle.QuitarRegistro += new System.EventHandler(this.obgDetalle_QuitarRegistro);
            this.obgDetalle.VisualizarRegistro += new System.EventHandler(this.obgDetalle_VisualizarRegistro);
            this.obgDetalle.MarcarTodos += new System.EventHandler(this.obgDetalleMarcar_MarcarTodosRegistro);
            this.obgDetalle.DesMarcarTodos += new System.EventHandler(this.obgDetalleMarcar_DesmarcarTodosRegistro);
            this.obgDetalle.NuevoDetalleRegistro += new System.EventHandler(this.obgDetalle_NuevoDetalleRegistro);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.lciOpcionDetalle});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(757, 389);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gcRequerimiento;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 28);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(737, 341);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // lciOpcionDetalle
            // 
            this.lciOpcionDetalle.Control = this.obgDetalle;
            this.lciOpcionDetalle.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lciOpcionDetalle.CustomizationFormText = "layoutControlItem9";
            this.lciOpcionDetalle.Location = new System.Drawing.Point(0, 0);
            this.lciOpcionDetalle.Name = "lciOpcionDetalle";
            this.lciOpcionDetalle.Size = new System.Drawing.Size(737, 28);
            this.lciOpcionDetalle.TextSize = new System.Drawing.Size(0, 0);
            this.lciOpcionDetalle.TextVisible = false;
            // 
            // SeleccionRequerimientoDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "SeleccionRequerimientoDetalle";
            this.Size = new System.Drawing.Size(757, 389);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcRequerimiento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRequerimiento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riceSeleccionar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.risePrecio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riseCant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciOpcionDetalle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraGrid.GridControl gcRequerimiento;
        private DevExpress.XtraGrid.Views.Grid.GridView gvRequerimiento;
        private DevExpress.XtraGrid.Columns.GridColumn gcSeleccionar;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit riceSeleccionar;
        private DevExpress.XtraGrid.Columns.GridColumn gcCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn gcDesc;
        private DevExpress.XtraGrid.Columns.GridColumn gcUnidad;
        private DevExpress.XtraGrid.Columns.GridColumn gcPrecio;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit risePrecio;
        private DevExpress.XtraGrid.Columns.GridColumn gcCantidad;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit riseCant;
        private DevExpress.XtraGrid.Columns.GridColumn gcSubTotal;
        private DevExpress.XtraGrid.Columns.GridColumn gcCuenta;
        private DevExpress.XtraGrid.Columns.GridColumn gcIdPreMen;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private General.ControlesDiversos.OpcionesBarraGrid obgDetalle;
        private DevExpress.XtraLayout.LayoutControlItem lciOpcionDetalle;
    }
}
