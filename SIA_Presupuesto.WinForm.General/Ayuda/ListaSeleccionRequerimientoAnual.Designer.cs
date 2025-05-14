namespace SIA_Presupuesto.WinForm.General.Ayuda
{
    partial class ListaSeleccionRequerimientoAnual
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.lcNumReg = new DevExpress.XtraEditors.LabelControl();
            this.grcRequerimientoBienSer = new DevExpress.XtraGrid.GridControl();
            this.grvRequerimientoBienSer = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcSelect = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDireccion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDesSubdireccion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDesArea = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciLblNum = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcRequerimientoBienSer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvRequerimientoBienSer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciLblNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.lcNumReg);
            this.layoutControl1.Controls.Add(this.grcRequerimientoBienSer);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(757, 389);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // lcNumReg
            // 
            this.lcNumReg.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lcNumReg.Appearance.Options.UseFont = true;
            this.lcNumReg.Location = new System.Drawing.Point(12, 360);
            this.lcNumReg.Name = "lcNumReg";
            this.lcNumReg.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.lcNumReg.Size = new System.Drawing.Size(8, 17);
            this.lcNumReg.StyleController = this.layoutControl1;
            this.lcNumReg.TabIndex = 13;
            this.lcNumReg.Text = "0";
            // 
            // grcRequerimientoBienSer
            // 
            this.grcRequerimientoBienSer.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.grcRequerimientoBienSer.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.grcRequerimientoBienSer.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.grcRequerimientoBienSer.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.grcRequerimientoBienSer.EmbeddedNavigator.Buttons.Remove.Visible = false;
            gridLevelNode1.RelationName = "Level1";
            this.grcRequerimientoBienSer.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.grcRequerimientoBienSer.Location = new System.Drawing.Point(12, 12);
            this.grcRequerimientoBienSer.MainView = this.grvRequerimientoBienSer;
            this.grcRequerimientoBienSer.Name = "grcRequerimientoBienSer";
            this.grcRequerimientoBienSer.Size = new System.Drawing.Size(733, 344);
            this.grcRequerimientoBienSer.TabIndex = 12;
            this.grcRequerimientoBienSer.UseEmbeddedNavigator = true;
            this.grcRequerimientoBienSer.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvRequerimientoBienSer});
            // 
            // grvRequerimientoBienSer
            // 
            this.grvRequerimientoBienSer.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcSelect,
            this.gcCodigo,
            this.gcFecha,
            this.gcTotal,
            this.gcDescripcion,
            this.gcDireccion,
            this.gcDesSubdireccion,
            this.gcDesArea});
            this.grvRequerimientoBienSer.GridControl = this.grcRequerimientoBienSer;
            this.grvRequerimientoBienSer.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total", null, "(Total={0:n2})")});
            this.grvRequerimientoBienSer.Name = "grvRequerimientoBienSer";
            this.grvRequerimientoBienSer.OptionsBehavior.ReadOnly = true;
            this.grvRequerimientoBienSer.OptionsSelection.CheckBoxSelectorField = "esSeleccionado";
            this.grvRequerimientoBienSer.OptionsSelection.MultiSelect = true;
            this.grvRequerimientoBienSer.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.grvRequerimientoBienSer.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.False;
            this.grvRequerimientoBienSer.OptionsSelection.ShowCheckBoxSelectorInGroupRow = DevExpress.Utils.DefaultBoolean.False;
            this.grvRequerimientoBienSer.OptionsSelection.UseIndicatorForSelection = false;
            this.grvRequerimientoBienSer.OptionsView.ColumnAutoWidth = false;
            this.grvRequerimientoBienSer.OptionsView.ShowAutoFilterRow = true;
            this.grvRequerimientoBienSer.OptionsView.ShowFooter = true;
            this.grvRequerimientoBienSer.OptionsView.ShowGroupPanel = false;
            this.grvRequerimientoBienSer.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.grvRequerimientoBienSer_SelectionChanged);
            // 
            // gcSelect
            // 
            this.gcSelect.Caption = "Select";
            this.gcSelect.FieldName = "esSeleccionado";
            this.gcSelect.Name = "gcSelect";
            this.gcSelect.Width = 50;
            // 
            // gcCodigo
            // 
            this.gcCodigo.Caption = "Código";
            this.gcCodigo.FieldName = "idReqBieSer";
            this.gcCodigo.Name = "gcCodigo";
            this.gcCodigo.OptionsColumn.ReadOnly = true;
            this.gcCodigo.Visible = true;
            this.gcCodigo.VisibleIndex = 1;
            this.gcCodigo.Width = 55;
            // 
            // gcFecha
            // 
            this.gcFecha.AppearanceCell.Options.UseTextOptions = true;
            this.gcFecha.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcFecha.Caption = "Fecha";
            this.gcFecha.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.gcFecha.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcFecha.FieldName = "fechaEmision";
            this.gcFecha.Name = "gcFecha";
            this.gcFecha.Visible = true;
            this.gcFecha.VisibleIndex = 2;
            this.gcFecha.Width = 80;
            // 
            // gcTotal
            // 
            this.gcTotal.AppearanceCell.Options.UseTextOptions = true;
            this.gcTotal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gcTotal.Caption = "Total";
            this.gcTotal.DisplayFormat.FormatString = "n2";
            this.gcTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcTotal.FieldName = "total";
            this.gcTotal.Name = "gcTotal";
            this.gcTotal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total", "{0:n2}")});
            this.gcTotal.Visible = true;
            this.gcTotal.VisibleIndex = 3;
            this.gcTotal.Width = 150;
            // 
            // gcDescripcion
            // 
            this.gcDescripcion.AppearanceCell.Options.UseTextOptions = true;
            this.gcDescripcion.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gcDescripcion.Caption = "Descripción";
            this.gcDescripcion.FieldName = "descripcion";
            this.gcDescripcion.Name = "gcDescripcion";
            this.gcDescripcion.OptionsColumn.ReadOnly = true;
            this.gcDescripcion.Visible = true;
            this.gcDescripcion.VisibleIndex = 4;
            this.gcDescripcion.Width = 450;
            // 
            // gcDireccion
            // 
            this.gcDireccion.AppearanceCell.Options.UseTextOptions = true;
            this.gcDireccion.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gcDireccion.Caption = "Dirección";
            this.gcDireccion.FieldName = "desDireccion";
            this.gcDireccion.Name = "gcDireccion";
            this.gcDireccion.OptionsColumn.ReadOnly = true;
            this.gcDireccion.Visible = true;
            this.gcDireccion.VisibleIndex = 5;
            this.gcDireccion.Width = 150;
            // 
            // gcDesSubdireccion
            // 
            this.gcDesSubdireccion.Caption = "Subdirección";
            this.gcDesSubdireccion.FieldName = "desSubdireccion";
            this.gcDesSubdireccion.Name = "gcDesSubdireccion";
            this.gcDesSubdireccion.Visible = true;
            this.gcDesSubdireccion.VisibleIndex = 6;
            this.gcDesSubdireccion.Width = 150;
            // 
            // gcDesArea
            // 
            this.gcDesArea.Caption = "Área";
            this.gcDesArea.FieldName = "desArea";
            this.gcDesArea.Name = "gcDesArea";
            this.gcDesArea.Visible = true;
            this.gcDesArea.VisibleIndex = 7;
            this.gcDesArea.Width = 150;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.lciLblNum,
            this.emptySpaceItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(757, 389);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grcRequerimientoBienSer;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(737, 348);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // lciLblNum
            // 
            this.lciLblNum.Control = this.lcNumReg;
            this.lciLblNum.Location = new System.Drawing.Point(0, 348);
            this.lciLblNum.Name = "lciLblNum";
            this.lciLblNum.Size = new System.Drawing.Size(12, 21);
            this.lciLblNum.TextSize = new System.Drawing.Size(0, 0);
            this.lciLblNum.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(12, 348);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(725, 21);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // ListaSeleccionRequerimientoAnual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "ListaSeleccionRequerimientoAnual";
            this.Size = new System.Drawing.Size(757, 389);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcRequerimientoBienSer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvRequerimientoBienSer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciLblNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraGrid.GridControl grcRequerimientoBienSer;
        private DevExpress.XtraGrid.Views.Grid.GridView grvRequerimientoBienSer;
        private DevExpress.XtraGrid.Columns.GridColumn gcSelect;
        private DevExpress.XtraGrid.Columns.GridColumn gcCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn gcDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn gcDireccion;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.LabelControl lcNumReg;
        private DevExpress.XtraLayout.LayoutControlItem lciLblNum;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gcFecha;
        private DevExpress.XtraGrid.Columns.GridColumn gcDesSubdireccion;
        private DevExpress.XtraGrid.Columns.GridColumn gcDesArea;
        private DevExpress.XtraGrid.Columns.GridColumn gcTotal;
    }
}
