namespace SIA_Presupuesto.WinForm.Programacion.Dialogo
{
    partial class frmListaPuestoRequerimientoAnual
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
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.grcPuestoRequerimientoAnual = new DevExpress.XtraGrid.GridControl();
            this.grvPuestoRequerimientoAnual = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcSelect = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcNroDocumento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPersona = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcRemuneracion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcGrado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCargo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcEsRemDiaria = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCantVacante = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcArea = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSubdireccion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDireccion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcNumReg = new DevExpress.XtraEditors.LabelControl();
            this.lciLblNum = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcBase)).BeginInit();
            this.lcBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxProveedorValidador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcPuestoRequerimientoAnual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPuestoRequerimientoAnual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciLblNum)).BeginInit();
            this.SuspendLayout();
            // 
            // lcCuerpo
            // 
            this.lcCuerpo.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(803, 132, 386, 350);
            this.lcCuerpo.Size = new System.Drawing.Size(900, 558);
            // 
            // lcgCuerpo
            // 
            this.lcgCuerpo.Size = new System.Drawing.Size(900, 558);
            // 
            // lcBase
            // 
            this.lcBase.Controls.Add(this.lcNumReg);
            this.lcBase.Controls.Add(this.grcPuestoRequerimientoAnual);
            this.lcBase.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(276, 300, 450, 400);
            this.lcBase.Size = new System.Drawing.Size(870, 488);
            // 
            // lcgBase
            // 
            this.lcgBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem2,
            this.lciLblNum,
            this.layoutControlItem2});
            this.lcgBase.Name = "Root";
            this.lcgBase.Size = new System.Drawing.Size(870, 488);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(12, 444);
            this.emptySpaceItem2.MinSize = new System.Drawing.Size(104, 24);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(838, 24);
            this.emptySpaceItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // grcPuestoRequerimientoAnual
            // 
            this.grcPuestoRequerimientoAnual.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.grcPuestoRequerimientoAnual.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.grcPuestoRequerimientoAnual.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.grcPuestoRequerimientoAnual.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.grcPuestoRequerimientoAnual.EmbeddedNavigator.Buttons.Remove.Visible = false;
            gridLevelNode1.RelationName = "Level1";
            this.grcPuestoRequerimientoAnual.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.grcPuestoRequerimientoAnual.Location = new System.Drawing.Point(12, 12);
            this.grcPuestoRequerimientoAnual.MainView = this.grvPuestoRequerimientoAnual;
            this.grcPuestoRequerimientoAnual.Name = "grcPuestoRequerimientoAnual";
            this.grcPuestoRequerimientoAnual.Size = new System.Drawing.Size(846, 440);
            this.grcPuestoRequerimientoAnual.TabIndex = 11;
            this.grcPuestoRequerimientoAnual.UseEmbeddedNavigator = true;
            this.grcPuestoRequerimientoAnual.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvPuestoRequerimientoAnual});
            // 
            // grvPuestoRequerimientoAnual
            // 
            this.grvPuestoRequerimientoAnual.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcSelect,
            this.gcCodigo,
            this.gcNroDocumento,
            this.gcPersona,
            this.gcRemuneracion,
            this.gcGrado,
            this.gcCargo,
            this.gcEsRemDiaria,
            this.gcCantVacante,
            this.gcArea,
            this.gcSubdireccion,
            this.gcDireccion});
            this.grvPuestoRequerimientoAnual.GridControl = this.grcPuestoRequerimientoAnual;
            this.grvPuestoRequerimientoAnual.GroupCount = 1;
            this.grvPuestoRequerimientoAnual.Name = "grvPuestoRequerimientoAnual";
            this.grvPuestoRequerimientoAnual.OptionsBehavior.ReadOnly = true;
            this.grvPuestoRequerimientoAnual.OptionsSelection.CheckBoxSelectorField = "esSeleccionado";
            this.grvPuestoRequerimientoAnual.OptionsSelection.MultiSelect = true;
            this.grvPuestoRequerimientoAnual.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.grvPuestoRequerimientoAnual.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
            this.grvPuestoRequerimientoAnual.OptionsSelection.ShowCheckBoxSelectorInGroupRow = DevExpress.Utils.DefaultBoolean.True;
            this.grvPuestoRequerimientoAnual.OptionsView.ColumnAutoWidth = false;
            this.grvPuestoRequerimientoAnual.OptionsView.ShowAutoFilterRow = true;
            this.grvPuestoRequerimientoAnual.OptionsView.ShowFooter = true;
            this.grvPuestoRequerimientoAnual.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gcDireccion, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.grvPuestoRequerimientoAnual.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.grvPresupuestoAnual_SelectionChanged);
            // 
            // gcSelect
            // 
            this.gcSelect.AppearanceHeader.Options.UseTextOptions = true;
            this.gcSelect.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcSelect.Caption = "Select";
            this.gcSelect.CustomizationCaption = "Select";
            this.gcSelect.FieldName = "esSeleccionado";
            this.gcSelect.Name = "gcSelect";
            this.gcSelect.OptionsColumn.AllowMove = false;
            this.gcSelect.OptionsColumn.AllowSize = false;
            this.gcSelect.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gcSelect.OptionsColumn.FixedWidth = true;
            this.gcSelect.UnboundDataType = typeof(bool);
            this.gcSelect.Width = 30;
            // 
            // gcCodigo
            // 
            this.gcCodigo.Caption = "Código";
            this.gcCodigo.FieldName = "idPueReq";
            this.gcCodigo.Name = "gcCodigo";
            this.gcCodigo.OptionsColumn.ReadOnly = true;
            this.gcCodigo.Width = 60;
            // 
            // gcNroDocumento
            // 
            this.gcNroDocumento.Caption = "Nro. Doc. Identidad";
            this.gcNroDocumento.FieldName = "nroDocIdentidad";
            this.gcNroDocumento.Name = "gcNroDocumento";
            this.gcNroDocumento.Visible = true;
            this.gcNroDocumento.VisibleIndex = 1;
            this.gcNroDocumento.Width = 90;
            // 
            // gcPersona
            // 
            this.gcPersona.AppearanceCell.Options.UseTextOptions = true;
            this.gcPersona.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gcPersona.Caption = "Persona";
            this.gcPersona.FieldName = "persona";
            this.gcPersona.Name = "gcPersona";
            this.gcPersona.OptionsColumn.ReadOnly = true;
            this.gcPersona.Visible = true;
            this.gcPersona.VisibleIndex = 2;
            this.gcPersona.Width = 260;
            // 
            // gcRemuneracion
            // 
            this.gcRemuneracion.AppearanceCell.Options.UseTextOptions = true;
            this.gcRemuneracion.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gcRemuneracion.Caption = "Remuneración";
            this.gcRemuneracion.DisplayFormat.FormatString = "n2";
            this.gcRemuneracion.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcRemuneracion.FieldName = "remuneracion";
            this.gcRemuneracion.Name = "gcRemuneracion";
            this.gcRemuneracion.Visible = true;
            this.gcRemuneracion.VisibleIndex = 3;
            this.gcRemuneracion.Width = 80;
            // 
            // gcGrado
            // 
            this.gcGrado.AppearanceCell.Options.UseTextOptions = true;
            this.gcGrado.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gcGrado.Caption = "Grado/Nivel";
            this.gcGrado.DisplayFormat.FormatString = "n0";
            this.gcGrado.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcGrado.FieldName = "grado";
            this.gcGrado.Name = "gcGrado";
            this.gcGrado.Visible = true;
            this.gcGrado.VisibleIndex = 4;
            this.gcGrado.Width = 65;
            // 
            // gcCargo
            // 
            this.gcCargo.Caption = "Cargo";
            this.gcCargo.FieldName = "cargo";
            this.gcCargo.Name = "gcCargo";
            this.gcCargo.Visible = true;
            this.gcCargo.VisibleIndex = 5;
            this.gcCargo.Width = 150;
            // 
            // gcEsRemDiaria
            // 
            this.gcEsRemDiaria.AppearanceCell.Options.UseTextOptions = true;
            this.gcEsRemDiaria.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcEsRemDiaria.Caption = "Es Rem. Diaria";
            this.gcEsRemDiaria.FieldName = "esRemDiaria";
            this.gcEsRemDiaria.Name = "gcEsRemDiaria";
            this.gcEsRemDiaria.Visible = true;
            this.gcEsRemDiaria.VisibleIndex = 6;
            this.gcEsRemDiaria.Width = 80;
            // 
            // gcCantVacante
            // 
            this.gcCantVacante.AppearanceCell.Options.UseTextOptions = true;
            this.gcCantVacante.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gcCantVacante.Caption = "Cant. Vac.";
            this.gcCantVacante.DisplayFormat.FormatString = "n0";
            this.gcCantVacante.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcCantVacante.FieldName = "cantVacante";
            this.gcCantVacante.Name = "gcCantVacante";
            this.gcCantVacante.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "cantVacante", "{0:n0}")});
            this.gcCantVacante.Visible = true;
            this.gcCantVacante.VisibleIndex = 7;
            this.gcCantVacante.Width = 70;
            // 
            // gcArea
            // 
            this.gcArea.Caption = "Área";
            this.gcArea.FieldName = "desArea";
            this.gcArea.Name = "gcArea";
            this.gcArea.Visible = true;
            this.gcArea.VisibleIndex = 8;
            this.gcArea.Width = 150;
            // 
            // gcSubdireccion
            // 
            this.gcSubdireccion.Caption = "Subdirección";
            this.gcSubdireccion.FieldName = "desSubdireccion";
            this.gcSubdireccion.Name = "gcSubdireccion";
            this.gcSubdireccion.Visible = true;
            this.gcSubdireccion.VisibleIndex = 9;
            this.gcSubdireccion.Width = 150;
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
            this.gcDireccion.VisibleIndex = 11;
            this.gcDireccion.Width = 120;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.grcPuestoRequerimientoAnual;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(850, 444);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // lcNumReg
            // 
            this.lcNumReg.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lcNumReg.Appearance.Options.UseFont = true;
            this.lcNumReg.Location = new System.Drawing.Point(12, 456);
            this.lcNumReg.Name = "lcNumReg";
            this.lcNumReg.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.lcNumReg.Size = new System.Drawing.Size(8, 17);
            this.lcNumReg.StyleController = this.lcBase;
            this.lcNumReg.TabIndex = 12;
            this.lcNumReg.Text = "0";
            // 
            // lciLblNum
            // 
            this.lciLblNum.Control = this.lcNumReg;
            this.lciLblNum.Location = new System.Drawing.Point(0, 444);
            this.lciLblNum.Name = "lciLblNum";
            this.lciLblNum.Size = new System.Drawing.Size(12, 24);
            this.lciLblNum.Text = "Registros Seleccionados :";
            this.lciLblNum.TextSize = new System.Drawing.Size(0, 0);
            this.lciLblNum.TextVisible = false;
            // 
            // frmListaPuestoRequerimientoAnual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 558);
            this.Name = "frmListaPuestoRequerimientoAnual";
            this.Text = "Exporta Presupueto Anual - Génerica Gastos";
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcBase)).EndInit();
            this.lcBase.ResumeLayout(false);
            this.lcBase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxProveedorValidador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcPuestoRequerimientoAnual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPuestoRequerimientoAnual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciLblNum)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraGrid.GridControl grcPuestoRequerimientoAnual;
        private DevExpress.XtraGrid.Views.Grid.GridView grvPuestoRequerimientoAnual;
        private DevExpress.XtraGrid.Columns.GridColumn gcCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn gcPersona;
        private DevExpress.XtraGrid.Columns.GridColumn gcDireccion;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.Columns.GridColumn gcSelect;
        private DevExpress.XtraEditors.LabelControl lcNumReg;
        private DevExpress.XtraLayout.LayoutControlItem lciLblNum;
        private DevExpress.XtraGrid.Columns.GridColumn gcNroDocumento;
        private DevExpress.XtraGrid.Columns.GridColumn gcRemuneracion;
        private DevExpress.XtraGrid.Columns.GridColumn gcGrado;
        private DevExpress.XtraGrid.Columns.GridColumn gcCargo;
        private DevExpress.XtraGrid.Columns.GridColumn gcEsRemDiaria;
        private DevExpress.XtraGrid.Columns.GridColumn gcCantVacante;
        private DevExpress.XtraGrid.Columns.GridColumn gcArea;
        private DevExpress.XtraGrid.Columns.GridColumn gcSubdireccion;
    }
}