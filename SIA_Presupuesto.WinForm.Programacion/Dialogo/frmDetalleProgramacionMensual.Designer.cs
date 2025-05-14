namespace SIA_Presupuesto.WinForm.Programacion.Dialogo
{
    partial class frmDetalleProgramacionMensual
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.grvDetalle = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.Principal = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand5 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand6 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand7 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand8 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand9 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand10 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand11 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand12 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand13 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gbPrincipal = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumn1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn3 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn4 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gbTotal = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumn5 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.grcProgramacion = new DevExpress.XtraGrid.GridControl();
            this.grvProgramacion = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcCuenta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcNombreCuenta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDireccion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSubDireccion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcArea = new DevExpress.XtraGrid.Columns.GridColumn();
            this.numCuentaNivel2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.numCuentaNivel1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcImpEne = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riseImp = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcBase)).BeginInit();
            this.lcBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxProveedorValidador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcProgramacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProgramacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riseImp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // lcCuerpo
            // 
            this.lcCuerpo.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(803, 132, 386, 350);
            this.lcCuerpo.Size = new System.Drawing.Size(944, 529);
            // 
            // lcgCuerpo
            // 
            this.lcgCuerpo.Size = new System.Drawing.Size(944, 529);
            // 
            // lcBase
            // 
            this.lcBase.Controls.Add(this.grcProgramacion);
            this.lcBase.Size = new System.Drawing.Size(914, 459);
            // 
            // lcgBase
            // 
            this.lcgBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.lcgBase.Size = new System.Drawing.Size(914, 459);
            // 
            // grvDetalle
            // 
            this.grvDetalle.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.Principal,
            this.gridBand2,
            this.gridBand3,
            this.gridBand4,
            this.gridBand5,
            this.gridBand6,
            this.gridBand7,
            this.gridBand8,
            this.gridBand9,
            this.gridBand10,
            this.gridBand11,
            this.gridBand12,
            this.gridBand13,
            this.gridBand1,
            this.gbPrincipal,
            this.gbTotal});
            this.grvDetalle.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.bandedGridColumn1,
            this.bandedGridColumn2,
            this.bandedGridColumn3,
            this.bandedGridColumn4,
            this.bandedGridColumn5});
            this.grvDetalle.GridControl = this.grcProgramacion;
            this.grvDetalle.Name = "grvDetalle";
            this.grvDetalle.OptionsView.ColumnAutoWidth = false;
            this.grvDetalle.OptionsView.ShowAutoFilterRow = true;
            this.grvDetalle.OptionsView.ShowGroupPanel = false;
            // 
            // Principal
            // 
            this.Principal.AppearanceHeader.Options.UseTextOptions = true;
            this.Principal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Principal.Caption = "Principal";
            this.Principal.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.Principal.Name = "Principal";
            this.Principal.Visible = false;
            this.Principal.VisibleIndex = -1;
            this.Principal.Width = 474;
            // 
            // gridBand2
            // 
            this.gridBand2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand2.Caption = "Total";
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.Visible = false;
            this.gridBand2.VisibleIndex = -1;
            this.gridBand2.Width = 75;
            // 
            // gridBand3
            // 
            this.gridBand3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand3.Caption = "Febrero";
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.Visible = false;
            this.gridBand3.VisibleIndex = -1;
            this.gridBand3.Width = 235;
            // 
            // gridBand4
            // 
            this.gridBand4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand4.Caption = "Marzo";
            this.gridBand4.Name = "gridBand4";
            this.gridBand4.Visible = false;
            this.gridBand4.VisibleIndex = -1;
            this.gridBand4.Width = 235;
            // 
            // gridBand5
            // 
            this.gridBand5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand5.Caption = "Abril";
            this.gridBand5.Name = "gridBand5";
            this.gridBand5.Visible = false;
            this.gridBand5.VisibleIndex = -1;
            this.gridBand5.Width = 235;
            // 
            // gridBand6
            // 
            this.gridBand6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand6.Caption = "Mayo";
            this.gridBand6.Name = "gridBand6";
            this.gridBand6.Visible = false;
            this.gridBand6.VisibleIndex = -1;
            this.gridBand6.Width = 235;
            // 
            // gridBand7
            // 
            this.gridBand7.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand7.Caption = "Junio";
            this.gridBand7.Name = "gridBand7";
            this.gridBand7.Visible = false;
            this.gridBand7.VisibleIndex = -1;
            this.gridBand7.Width = 235;
            // 
            // gridBand8
            // 
            this.gridBand8.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand8.Caption = "Julio";
            this.gridBand8.Name = "gridBand8";
            this.gridBand8.Visible = false;
            this.gridBand8.VisibleIndex = -1;
            this.gridBand8.Width = 235;
            // 
            // gridBand9
            // 
            this.gridBand9.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand9.Caption = "Agosto";
            this.gridBand9.Name = "gridBand9";
            this.gridBand9.Visible = false;
            this.gridBand9.VisibleIndex = -1;
            this.gridBand9.Width = 235;
            // 
            // gridBand10
            // 
            this.gridBand10.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand10.Caption = "Setiembre";
            this.gridBand10.Name = "gridBand10";
            this.gridBand10.Visible = false;
            this.gridBand10.VisibleIndex = -1;
            this.gridBand10.Width = 235;
            // 
            // gridBand11
            // 
            this.gridBand11.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand11.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand11.Caption = "Octubre";
            this.gridBand11.Name = "gridBand11";
            this.gridBand11.Visible = false;
            this.gridBand11.VisibleIndex = -1;
            this.gridBand11.Width = 235;
            // 
            // gridBand12
            // 
            this.gridBand12.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand12.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand12.Caption = "Noviembre";
            this.gridBand12.Name = "gridBand12";
            this.gridBand12.Visible = false;
            this.gridBand12.VisibleIndex = -1;
            this.gridBand12.Width = 235;
            // 
            // gridBand13
            // 
            this.gridBand13.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand13.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand13.Caption = "Diciembre";
            this.gridBand13.Name = "gridBand13";
            this.gridBand13.Visible = false;
            this.gridBand13.VisibleIndex = -1;
            this.gridBand13.Width = 235;
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "gridBand1";
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.Visible = false;
            this.gridBand1.VisibleIndex = -1;
            // 
            // gbPrincipal
            // 
            this.gbPrincipal.Caption = "Principal";
            this.gbPrincipal.Columns.Add(this.bandedGridColumn1);
            this.gbPrincipal.Columns.Add(this.bandedGridColumn2);
            this.gbPrincipal.Columns.Add(this.bandedGridColumn3);
            this.gbPrincipal.Columns.Add(this.bandedGridColumn4);
            this.gbPrincipal.Name = "gbPrincipal";
            this.gbPrincipal.VisibleIndex = 0;
            this.gbPrincipal.Width = 610;
            // 
            // bandedGridColumn1
            // 
            this.bandedGridColumn1.Caption = "Descripcion";
            this.bandedGridColumn1.FieldName = "descripcion";
            this.bandedGridColumn1.Name = "bandedGridColumn1";
            this.bandedGridColumn1.Visible = true;
            this.bandedGridColumn1.Width = 300;
            // 
            // bandedGridColumn2
            // 
            this.bandedGridColumn2.Caption = "Unidad";
            this.bandedGridColumn2.FieldName = "Abreviado";
            this.bandedGridColumn2.Name = "bandedGridColumn2";
            this.bandedGridColumn2.Visible = true;
            this.bandedGridColumn2.Width = 150;
            // 
            // bandedGridColumn3
            // 
            this.bandedGridColumn3.Caption = "Cantidad";
            this.bandedGridColumn3.DisplayFormat.FormatString = "n2";
            this.bandedGridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.bandedGridColumn3.FieldName = "cantidad";
            this.bandedGridColumn3.Name = "bandedGridColumn3";
            this.bandedGridColumn3.Visible = true;
            this.bandedGridColumn3.Width = 80;
            // 
            // bandedGridColumn4
            // 
            this.bandedGridColumn4.Caption = "Precio";
            this.bandedGridColumn4.DisplayFormat.FormatString = "n2";
            this.bandedGridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.bandedGridColumn4.FieldName = "precio";
            this.bandedGridColumn4.Name = "bandedGridColumn4";
            this.bandedGridColumn4.Visible = true;
            this.bandedGridColumn4.Width = 80;
            // 
            // gbTotal
            // 
            this.gbTotal.Caption = "Total";
            this.gbTotal.Columns.Add(this.bandedGridColumn5);
            this.gbTotal.Name = "gbTotal";
            this.gbTotal.VisibleIndex = 1;
            this.gbTotal.Width = 100;
            // 
            // bandedGridColumn5
            // 
            this.bandedGridColumn5.Caption = "Importe";
            this.bandedGridColumn5.DisplayFormat.FormatString = "n2";
            this.bandedGridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.bandedGridColumn5.FieldName = "importe";
            this.bandedGridColumn5.Name = "bandedGridColumn5";
            this.bandedGridColumn5.Visible = true;
            this.bandedGridColumn5.Width = 100;
            // 
            // grcProgramacion
            // 
            this.grcProgramacion.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.grcProgramacion.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.grcProgramacion.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.grcProgramacion.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.grcProgramacion.EmbeddedNavigator.Buttons.Remove.Visible = false;
            gridLevelNode1.LevelTemplate = this.grvDetalle;
            gridLevelNode1.RelationName = "SubPresupuestoAreaDetallePres";
            this.grcProgramacion.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.grcProgramacion.Location = new System.Drawing.Point(12, 12);
            this.grcProgramacion.MainView = this.grvProgramacion;
            this.grcProgramacion.Name = "grcProgramacion";
            this.grcProgramacion.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riseImp});
            this.grcProgramacion.Size = new System.Drawing.Size(890, 435);
            this.grcProgramacion.TabIndex = 5;
            this.grcProgramacion.UseEmbeddedNavigator = true;
            this.grcProgramacion.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvProgramacion,
            this.grvDetalle});
            // 
            // grvProgramacion
            // 
            this.grvProgramacion.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.grvProgramacion.Appearance.GroupRow.Options.UseFont = true;
            this.grvProgramacion.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcCuenta,
            this.gcNombreCuenta,
            this.gcDireccion,
            this.gcSubDireccion,
            this.gcArea,
            this.numCuentaNivel2,
            this.numCuentaNivel1,
            this.gcImpEne});
            this.grvProgramacion.GridControl = this.grcProgramacion;
            this.grvProgramacion.GroupCount = 2;
            this.grvProgramacion.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "importe", null, "Total: {0:n}")});
            this.grvProgramacion.Name = "grvProgramacion";
            this.grvProgramacion.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvProgramacion.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Classic;
            this.grvProgramacion.OptionsPrint.ExpandAllDetails = true;
            this.grvProgramacion.OptionsPrint.PrintDetails = true;
            this.grvProgramacion.OptionsView.ColumnAutoWidth = false;
            this.grvProgramacion.OptionsView.ShowAutoFilterRow = true;
            this.grvProgramacion.OptionsView.ShowFooter = true;
            this.grvProgramacion.OptionsView.ShowGroupPanel = false;
            this.grvProgramacion.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.numCuentaNivel1, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.numCuentaNivel2, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gcCuenta
            // 
            this.gcCuenta.AppearanceCell.BackColor = System.Drawing.Color.LightBlue;
            this.gcCuenta.AppearanceCell.Options.UseBackColor = true;
            this.gcCuenta.Caption = "Cuenta";
            this.gcCuenta.FieldName = "numCuenta";
            this.gcCuenta.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gcCuenta.Name = "gcCuenta";
            this.gcCuenta.OptionsColumn.AllowEdit = false;
            this.gcCuenta.Visible = true;
            this.gcCuenta.VisibleIndex = 0;
            this.gcCuenta.Width = 129;
            // 
            // gcNombreCuenta
            // 
            this.gcNombreCuenta.AppearanceCell.BackColor = System.Drawing.Color.LightBlue;
            this.gcNombreCuenta.AppearanceCell.Options.UseBackColor = true;
            this.gcNombreCuenta.Caption = "Descripción";
            this.gcNombreCuenta.FieldName = "descripcion";
            this.gcNombreCuenta.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gcNombreCuenta.Name = "gcNombreCuenta";
            this.gcNombreCuenta.OptionsColumn.AllowEdit = false;
            this.gcNombreCuenta.Visible = true;
            this.gcNombreCuenta.VisibleIndex = 1;
            this.gcNombreCuenta.Width = 291;
            // 
            // gcDireccion
            // 
            this.gcDireccion.Caption = "Dirección";
            this.gcDireccion.FieldName = "desDireccion";
            this.gcDireccion.Name = "gcDireccion";
            this.gcDireccion.OptionsColumn.AllowEdit = false;
            this.gcDireccion.Visible = true;
            this.gcDireccion.VisibleIndex = 2;
            this.gcDireccion.Width = 114;
            // 
            // gcSubDireccion
            // 
            this.gcSubDireccion.Caption = "Subdirección";
            this.gcSubDireccion.FieldName = "desSubdireccion";
            this.gcSubDireccion.Name = "gcSubDireccion";
            this.gcSubDireccion.OptionsColumn.AllowEdit = false;
            this.gcSubDireccion.Visible = true;
            this.gcSubDireccion.VisibleIndex = 3;
            this.gcSubDireccion.Width = 112;
            // 
            // gcArea
            // 
            this.gcArea.Caption = "Area";
            this.gcArea.FieldName = "desArea";
            this.gcArea.Name = "gcArea";
            this.gcArea.OptionsColumn.AllowEdit = false;
            this.gcArea.Visible = true;
            this.gcArea.VisibleIndex = 4;
            this.gcArea.Width = 114;
            // 
            // numCuentaNivel2
            // 
            this.numCuentaNivel2.Caption = "Cuenta";
            this.numCuentaNivel2.FieldName = "numCuentaNivel2";
            this.numCuentaNivel2.Name = "numCuentaNivel2";
            this.numCuentaNivel2.OptionsColumn.AllowEdit = false;
            this.numCuentaNivel2.Visible = true;
            this.numCuentaNivel2.VisibleIndex = 5;
            // 
            // numCuentaNivel1
            // 
            this.numCuentaNivel1.Caption = "Cuenta";
            this.numCuentaNivel1.FieldName = "numCuentaNivel1";
            this.numCuentaNivel1.Name = "numCuentaNivel1";
            this.numCuentaNivel1.OptionsColumn.AllowEdit = false;
            this.numCuentaNivel1.Visible = true;
            this.numCuentaNivel1.VisibleIndex = 5;
            // 
            // gcImpEne
            // 
            this.gcImpEne.Caption = "Monto";
            this.gcImpEne.ColumnEdit = this.riseImp;
            this.gcImpEne.DisplayFormat.FormatString = "{0:n}";
            this.gcImpEne.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcImpEne.FieldName = "importe";
            this.gcImpEne.Name = "gcImpEne";
            this.gcImpEne.OptionsColumn.AllowEdit = false;
            this.gcImpEne.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "importe", "{0:n}")});
            this.gcImpEne.Visible = true;
            this.gcImpEne.VisibleIndex = 5;
            this.gcImpEne.Width = 100;
            // 
            // riseImp
            // 
            this.riseImp.AutoHeight = false;
            this.riseImp.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.riseImp.Name = "riseImp";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grcProgramacion;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(894, 439);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // frmDetalleProgramacionMensual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 529);
            this.Name = "frmDetalleProgramacionMensual";
            this.Text = "frmDetalleProgramacionMensual";
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcBase)).EndInit();
            this.lcBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxProveedorValidador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcProgramacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProgramacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riseImp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grcProgramacion;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView grvDetalle;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit riseImp;
        private DevExpress.XtraGrid.Views.Grid.GridView grvProgramacion;
        private DevExpress.XtraGrid.Columns.GridColumn gcCuenta;
        private DevExpress.XtraGrid.Columns.GridColumn gcNombreCuenta;
        private DevExpress.XtraGrid.Columns.GridColumn gcDireccion;
        private DevExpress.XtraGrid.Columns.GridColumn gcSubDireccion;
        private DevExpress.XtraGrid.Columns.GridColumn gcArea;
        private DevExpress.XtraGrid.Columns.GridColumn numCuentaNivel2;
        private DevExpress.XtraGrid.Columns.GridColumn numCuentaNivel1;
        private DevExpress.XtraGrid.Columns.GridColumn gcImpEne;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand Principal;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand4;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand5;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand6;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand7;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand8;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand9;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand10;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand11;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand12;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand13;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gbPrincipal;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn3;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn4;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gbTotal;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn5;
    }
}