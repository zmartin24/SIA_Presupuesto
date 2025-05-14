namespace SIA_Presupuesto.WinForm.Programacion
{
    partial class ListaRequerimientoMensualDetalle
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.riseImp = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.grcRequerimientoDetalle = new DevExpress.XtraGrid.GridControl();
            this.grvRequerimientoDetalle = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcItem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCuenta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUnidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPrecio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCantidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCantPresupuestada = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcImporte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcJustificacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtArea = new DevExpress.XtraEditors.TextEdit();
            this.lciArea = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtMoneda = new DevExpress.XtraEditors.TextEdit();
            this.lciMoneda = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.txtDesTipo = new DevExpress.XtraEditors.TextEdit();
            this.lciTipo = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtDescripcion = new DevExpress.XtraEditors.TextEdit();
            this.lciDescripcion = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcPrincipal)).BeginInit();
            this.lcPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgPrincipal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxProveedorValidacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riseImp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcRequerimientoDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvRequerimientoDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtArea.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMoneda.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciMoneda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesTipo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTipo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDescripcion)).BeginInit();
            this.SuspendLayout();
            // 
            // lcPrincipal
            // 
            this.lcPrincipal.Controls.Add(this.txtDescripcion);
            this.lcPrincipal.Controls.Add(this.txtMoneda);
            this.lcPrincipal.Controls.Add(this.txtArea);
            this.lcPrincipal.Controls.Add(this.grcRequerimientoDetalle);
            this.lcPrincipal.Controls.Add(this.txtDesTipo);
            this.lcPrincipal.Size = new System.Drawing.Size(820, 552);
            // 
            // lcgPrincipal
            // 
            this.lcgPrincipal.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.lciArea,
            this.lciMoneda,
            this.emptySpaceItem1,
            this.lciTipo,
            this.lciDescripcion});
            this.lcgPrincipal.Name = "Root";
            this.lcgPrincipal.Size = new System.Drawing.Size(820, 552);
            // 
            // riseImp
            // 
            this.riseImp.AutoHeight = false;
            this.riseImp.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.riseImp.Name = "riseImp";
            // 
            // grcRequerimientoDetalle
            // 
            this.grcRequerimientoDetalle.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.grcRequerimientoDetalle.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.grcRequerimientoDetalle.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.grcRequerimientoDetalle.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.grcRequerimientoDetalle.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.grcRequerimientoDetalle.Location = new System.Drawing.Point(12, 84);
            this.grcRequerimientoDetalle.MainView = this.grvRequerimientoDetalle;
            this.grcRequerimientoDetalle.Name = "grcRequerimientoDetalle";
            this.grcRequerimientoDetalle.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riseImp});
            this.grcRequerimientoDetalle.Size = new System.Drawing.Size(796, 456);
            this.grcRequerimientoDetalle.TabIndex = 4;
            this.grcRequerimientoDetalle.UseEmbeddedNavigator = true;
            this.grcRequerimientoDetalle.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvRequerimientoDetalle});
            // 
            // grvRequerimientoDetalle
            // 
            this.grvRequerimientoDetalle.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.grvRequerimientoDetalle.Appearance.GroupRow.Options.UseFont = true;
            this.grvRequerimientoDetalle.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcCodigo,
            this.gcItem,
            this.gcCuenta,
            this.gcDescripcion,
            this.gcUnidad,
            this.gcPrecio,
            this.gcCantidad,
            this.gcCantPresupuestada,
            this.gcImporte,
            this.gcJustificacion});
            this.grvRequerimientoDetalle.GridControl = this.grcRequerimientoDetalle;
            this.grvRequerimientoDetalle.GroupCount = 1;
            this.grvRequerimientoDetalle.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "importe", null, "Total: {0:n}")});
            this.grvRequerimientoDetalle.Name = "grvRequerimientoDetalle";
            this.grvRequerimientoDetalle.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvRequerimientoDetalle.OptionsBehavior.ReadOnly = true;
            this.grvRequerimientoDetalle.OptionsDetail.AllowOnlyOneMasterRowExpanded = true;
            this.grvRequerimientoDetalle.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Classic;
            this.grvRequerimientoDetalle.OptionsDetail.ShowDetailTabs = false;
            this.grvRequerimientoDetalle.OptionsPrint.ExpandAllDetails = true;
            this.grvRequerimientoDetalle.OptionsPrint.PrintDetails = true;
            this.grvRequerimientoDetalle.OptionsView.ColumnAutoWidth = false;
            this.grvRequerimientoDetalle.OptionsView.ShowAutoFilterRow = true;
            this.grvRequerimientoDetalle.OptionsView.ShowFooter = true;
            this.grvRequerimientoDetalle.OptionsView.ShowGroupPanel = false;
            this.grvRequerimientoDetalle.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gcCuenta, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.grvRequerimientoDetalle.MasterRowExpanded += new DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventHandler(this.grvCertificacionReq_MasterRowExpanded);
            // 
            // gcCodigo
            // 
            this.gcCodigo.AppearanceCell.BackColor = System.Drawing.Color.LightBlue;
            this.gcCodigo.AppearanceCell.Options.UseBackColor = true;
            this.gcCodigo.Caption = "Codigo";
            this.gcCodigo.FieldName = "idReqMenDet";
            this.gcCodigo.Name = "gcCodigo";
            this.gcCodigo.Width = 80;
            // 
            // gcItem
            // 
            this.gcItem.Caption = "Item";
            this.gcItem.FieldName = "item";
            this.gcItem.Name = "gcItem";
            this.gcItem.OptionsFilter.AllowAutoFilter = false;
            this.gcItem.OptionsFilter.AllowFilter = false;
            this.gcItem.OptionsFilter.AllowInHeaderSearch = DevExpress.Utils.DefaultBoolean.False;
            this.gcItem.Visible = true;
            this.gcItem.VisibleIndex = 0;
            this.gcItem.Width = 60;
            // 
            // gcCuenta
            // 
            this.gcCuenta.Caption = "Cuenta";
            this.gcCuenta.FieldName = "numCuenta";
            this.gcCuenta.Name = "gcCuenta";
            this.gcCuenta.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.BeginsWith;
            this.gcCuenta.Visible = true;
            this.gcCuenta.VisibleIndex = 1;
            // 
            // gcDescripcion
            // 
            this.gcDescripcion.Caption = "Descripción";
            this.gcDescripcion.FieldName = "descripcion";
            this.gcDescripcion.Name = "gcDescripcion";
            this.gcDescripcion.Visible = true;
            this.gcDescripcion.VisibleIndex = 1;
            this.gcDescripcion.Width = 350;
            // 
            // gcUnidad
            // 
            this.gcUnidad.Caption = "Unidad";
            this.gcUnidad.FieldName = "unidad";
            this.gcUnidad.Name = "gcUnidad";
            this.gcUnidad.OptionsColumn.AllowEdit = false;
            this.gcUnidad.Visible = true;
            this.gcUnidad.VisibleIndex = 2;
            this.gcUnidad.Width = 80;
            // 
            // gcPrecio
            // 
            this.gcPrecio.AppearanceCell.Options.UseTextOptions = true;
            this.gcPrecio.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gcPrecio.Caption = "Precio";
            this.gcPrecio.DisplayFormat.FormatString = "n2";
            this.gcPrecio.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcPrecio.FieldName = "precio";
            this.gcPrecio.Name = "gcPrecio";
            this.gcPrecio.Visible = true;
            this.gcPrecio.VisibleIndex = 3;
            this.gcPrecio.Width = 80;
            // 
            // gcCantidad
            // 
            this.gcCantidad.Caption = "Cant.";
            this.gcCantidad.DisplayFormat.FormatString = "{0:n}";
            this.gcCantidad.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcCantidad.FieldName = "cantidad";
            this.gcCantidad.Name = "gcCantidad";
            this.gcCantidad.Visible = true;
            this.gcCantidad.VisibleIndex = 4;
            // 
            // gcCantPresupuestada
            // 
            this.gcCantPresupuestada.Caption = "Cant. Pres.";
            this.gcCantPresupuestada.DisplayFormat.FormatString = "{0:n}";
            this.gcCantPresupuestada.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcCantPresupuestada.FieldName = "cantPresupuestada";
            this.gcCantPresupuestada.Name = "gcCantPresupuestada";
            this.gcCantPresupuestada.Visible = true;
            this.gcCantPresupuestada.VisibleIndex = 5;
            // 
            // gcImporte
            // 
            this.gcImporte.Caption = "Importe";
            this.gcImporte.DisplayFormat.FormatString = "{0:n}";
            this.gcImporte.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcImporte.FieldName = "importe";
            this.gcImporte.Name = "gcImporte";
            this.gcImporte.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "importe", "{0:n}")});
            this.gcImporte.Visible = true;
            this.gcImporte.VisibleIndex = 6;
            this.gcImporte.Width = 95;
            // 
            // gcJustificacion
            // 
            this.gcJustificacion.Caption = "Justificación";
            this.gcJustificacion.FieldName = "justificacion";
            this.gcJustificacion.Name = "gcJustificacion";
            this.gcJustificacion.Visible = true;
            this.gcJustificacion.VisibleIndex = 7;
            this.gcJustificacion.Width = 500;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grcRequerimientoDetalle;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(800, 460);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // txtArea
            // 
            this.txtArea.Location = new System.Drawing.Point(78, 36);
            this.txtArea.Name = "txtArea";
            this.txtArea.Properties.ReadOnly = true;
            this.txtArea.Size = new System.Drawing.Size(530, 20);
            this.txtArea.StyleController = this.lcPrincipal;
            this.txtArea.TabIndex = 5;
            // 
            // lciArea
            // 
            this.lciArea.Control = this.txtArea;
            this.lciArea.Location = new System.Drawing.Point(0, 24);
            this.lciArea.MaxSize = new System.Drawing.Size(600, 24);
            this.lciArea.MinSize = new System.Drawing.Size(600, 24);
            this.lciArea.Name = "lciArea";
            this.lciArea.Size = new System.Drawing.Size(800, 24);
            this.lciArea.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciArea.Text = "Area";
            this.lciArea.TextSize = new System.Drawing.Size(54, 13);
            // 
            // txtMoneda
            // 
            this.txtMoneda.Location = new System.Drawing.Point(278, 60);
            this.txtMoneda.Name = "txtMoneda";
            this.txtMoneda.Properties.ReadOnly = true;
            this.txtMoneda.Size = new System.Drawing.Size(130, 20);
            this.txtMoneda.StyleController = this.lcPrincipal;
            this.txtMoneda.TabIndex = 6;
            // 
            // lciMoneda
            // 
            this.lciMoneda.Control = this.txtMoneda;
            this.lciMoneda.Location = new System.Drawing.Point(200, 48);
            this.lciMoneda.MaxSize = new System.Drawing.Size(200, 24);
            this.lciMoneda.MinSize = new System.Drawing.Size(200, 24);
            this.lciMoneda.Name = "lciMoneda";
            this.lciMoneda.Size = new System.Drawing.Size(200, 24);
            this.lciMoneda.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciMoneda.Text = "Moneda";
            this.lciMoneda.TextSize = new System.Drawing.Size(54, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(400, 48);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(400, 24);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // txtDesTipo
            // 
            this.txtDesTipo.Location = new System.Drawing.Point(78, 60);
            this.txtDesTipo.Name = "txtDesTipo";
            this.txtDesTipo.Properties.ReadOnly = true;
            this.txtDesTipo.Size = new System.Drawing.Size(130, 20);
            this.txtDesTipo.StyleController = this.lcPrincipal;
            this.txtDesTipo.TabIndex = 6;
            // 
            // lciTipo
            // 
            this.lciTipo.Control = this.txtDesTipo;
            this.lciTipo.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lciTipo.CustomizationFormText = "Moneda";
            this.lciTipo.Location = new System.Drawing.Point(0, 48);
            this.lciTipo.MaxSize = new System.Drawing.Size(200, 24);
            this.lciTipo.MinSize = new System.Drawing.Size(200, 24);
            this.lciTipo.Name = "lciTipo";
            this.lciTipo.Size = new System.Drawing.Size(200, 24);
            this.lciTipo.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciTipo.Text = "Tipo Req.";
            this.lciTipo.TextSize = new System.Drawing.Size(54, 13);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(78, 12);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Properties.ReadOnly = true;
            this.txtDescripcion.Size = new System.Drawing.Size(730, 20);
            this.txtDescripcion.StyleController = this.lcPrincipal;
            this.txtDescripcion.TabIndex = 7;
            // 
            // lciDescripcion
            // 
            this.lciDescripcion.Control = this.txtDescripcion;
            this.lciDescripcion.Location = new System.Drawing.Point(0, 0);
            this.lciDescripcion.Name = "lciDescripcion";
            this.lciDescripcion.Size = new System.Drawing.Size(800, 24);
            this.lciDescripcion.Text = "Descripción";
            this.lciDescripcion.TextSize = new System.Drawing.Size(54, 13);
            // 
            // ListaRequerimientoMensualDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ListaRequerimientoMensualDetalle";
            this.Size = new System.Drawing.Size(820, 552);
            ((System.ComponentModel.ISupportInitialize)(this.lcPrincipal)).EndInit();
            this.lcPrincipal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgPrincipal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxProveedorValidacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riseImp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcRequerimientoDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvRequerimientoDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtArea.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMoneda.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciMoneda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesTipo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTipo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDescripcion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grcRequerimientoDetalle;
        private DevExpress.XtraGrid.Views.Grid.GridView grvRequerimientoDetalle;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gcCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn gcUnidad;
        private DevExpress.XtraGrid.Columns.GridColumn gcDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn gcCantidad;
        private DevExpress.XtraGrid.Columns.GridColumn gcImporte;
        private DevExpress.XtraGrid.Columns.GridColumn gcJustificacion;
        private DevExpress.XtraGrid.Columns.GridColumn gcCuenta;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit riseImp;
        private DevExpress.XtraGrid.Columns.GridColumn gcPrecio;
        private DevExpress.XtraGrid.Columns.GridColumn gcItem;
        private DevExpress.XtraEditors.TextEdit txtMoneda;
        private DevExpress.XtraEditors.TextEdit txtArea;
        private DevExpress.XtraLayout.LayoutControlItem lciArea;
        private DevExpress.XtraLayout.LayoutControlItem lciMoneda;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.TextEdit txtDesTipo;
        private DevExpress.XtraLayout.LayoutControlItem lciTipo;
        private DevExpress.XtraGrid.Columns.GridColumn gcCantPresupuestada;
        private DevExpress.XtraEditors.TextEdit txtDescripcion;
        private DevExpress.XtraLayout.LayoutControlItem lciDescripcion;
    }
}
