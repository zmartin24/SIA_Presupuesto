namespace SIA_Presupuesto.WinForm.Programacion.Dialogo
{
    partial class frmExportarProgramacionAnualGenericaMasivo
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            this.lueAnio = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lueMoneda = new DevExpress.XtraEditors.LookUpEdit();
            this.lciMoneda = new DevExpress.XtraLayout.LayoutControlItem();
            this.grcPresupuestoAnual = new DevExpress.XtraGrid.GridControl();
            this.grvPresupuestoAnual = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcSelect = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcGruPre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcNumReg = new DevExpress.XtraEditors.LabelControl();
            this.lciLblNum = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcBase)).BeginInit();
            this.lcBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxProveedorValidador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueAnio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMoneda.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciMoneda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcPresupuestoAnual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPresupuestoAnual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciLblNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // lcCuerpo
            // 
            this.lcCuerpo.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(803, 132, 386, 350);
            this.lcCuerpo.Size = new System.Drawing.Size(848, 493);
            // 
            // lcgCuerpo
            // 
            this.lcgCuerpo.Size = new System.Drawing.Size(848, 493);
            // 
            // lcBase
            // 
            this.lcBase.Controls.Add(this.lcNumReg);
            this.lcBase.Controls.Add(this.grcPresupuestoAnual);
            this.lcBase.Controls.Add(this.lueMoneda);
            this.lcBase.Controls.Add(this.lueAnio);
            this.lcBase.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(276, 300, 450, 400);
            this.lcBase.Size = new System.Drawing.Size(818, 423);
            // 
            // lcgBase
            // 
            this.lcgBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem2,
            this.lciMoneda,
            this.layoutControlItem2,
            this.lciLblNum,
            this.emptySpaceItem1});
            this.lcgBase.Name = "Root";
            this.lcgBase.Size = new System.Drawing.Size(818, 423);
            // 
            // lueAnio
            // 
            this.lueAnio.Location = new System.Drawing.Point(62, 12);
            this.lueAnio.Name = "lueAnio";
            this.lueAnio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueAnio.Size = new System.Drawing.Size(120, 20);
            this.lueAnio.StyleController = this.lcBase;
            this.lueAnio.TabIndex = 4;
            this.lueAnio.EditValueChanged += new System.EventHandler(this.lueAnio_EditValueChanged);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.lueAnio;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(174, 24);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(174, 24);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(174, 24);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.Text = "Año";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(38, 13);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(380, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(418, 24);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lueMoneda
            // 
            this.lueMoneda.Location = new System.Drawing.Point(236, 12);
            this.lueMoneda.Name = "lueMoneda";
            this.lueMoneda.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueMoneda.Size = new System.Drawing.Size(120, 20);
            this.lueMoneda.StyleController = this.lcBase;
            this.lueMoneda.TabIndex = 10;
            // 
            // lciMoneda
            // 
            this.lciMoneda.Control = this.lueMoneda;
            this.lciMoneda.Location = new System.Drawing.Point(174, 0);
            this.lciMoneda.MaxSize = new System.Drawing.Size(174, 24);
            this.lciMoneda.MinSize = new System.Drawing.Size(174, 24);
            this.lciMoneda.Name = "lciMoneda";
            this.lciMoneda.Size = new System.Drawing.Size(174, 24);
            this.lciMoneda.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciMoneda.Text = "Moneda";
            this.lciMoneda.TextSize = new System.Drawing.Size(38, 13);
            // 
            // grcPresupuestoAnual
            // 
            this.grcPresupuestoAnual.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.grcPresupuestoAnual.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.grcPresupuestoAnual.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.grcPresupuestoAnual.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.grcPresupuestoAnual.EmbeddedNavigator.Buttons.Remove.Visible = false;
            gridLevelNode2.RelationName = "Level1";
            this.grcPresupuestoAnual.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode2});
            this.grcPresupuestoAnual.Location = new System.Drawing.Point(12, 36);
            this.grcPresupuestoAnual.MainView = this.grvPresupuestoAnual;
            this.grcPresupuestoAnual.Name = "grcPresupuestoAnual";
            this.grcPresupuestoAnual.Size = new System.Drawing.Size(794, 375);
            this.grcPresupuestoAnual.TabIndex = 11;
            this.grcPresupuestoAnual.UseEmbeddedNavigator = true;
            this.grcPresupuestoAnual.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvPresupuestoAnual});
            // 
            // grvPresupuestoAnual
            // 
            this.grvPresupuestoAnual.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcSelect,
            this.gcCodigo,
            this.gcDescripcion,
            this.gcGruPre});
            this.grvPresupuestoAnual.GridControl = this.grcPresupuestoAnual;
            this.grvPresupuestoAnual.Name = "grvPresupuestoAnual";
            this.grvPresupuestoAnual.OptionsBehavior.ReadOnly = true;
            this.grvPresupuestoAnual.OptionsSelection.CheckBoxSelectorField = "esSeleccionado";
            this.grvPresupuestoAnual.OptionsSelection.MultiSelect = true;
            this.grvPresupuestoAnual.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.grvPresupuestoAnual.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.False;
            this.grvPresupuestoAnual.OptionsSelection.ShowCheckBoxSelectorInGroupRow = DevExpress.Utils.DefaultBoolean.False;
            this.grvPresupuestoAnual.OptionsSelection.UseIndicatorForSelection = false;
            this.grvPresupuestoAnual.OptionsView.ColumnAutoWidth = false;
            this.grvPresupuestoAnual.OptionsView.ShowAutoFilterRow = true;
            this.grvPresupuestoAnual.OptionsView.ShowGroupPanel = false;
            this.grvPresupuestoAnual.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.grvPresupuestoAnual_SelectionChanged);
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
            this.gcCodigo.FieldName = "idProAnu";
            this.gcCodigo.Name = "gcCodigo";
            this.gcCodigo.OptionsColumn.ReadOnly = true;
            this.gcCodigo.Visible = true;
            this.gcCodigo.VisibleIndex = 1;
            this.gcCodigo.Width = 60;
            // 
            // gcDescripcion
            // 
            this.gcDescripcion.AppearanceCell.Options.UseTextOptions = true;
            this.gcDescripcion.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gcDescripcion.Caption = "Presupuesto Anual";
            this.gcDescripcion.FieldName = "descripcion";
            this.gcDescripcion.Name = "gcDescripcion";
            this.gcDescripcion.OptionsColumn.ReadOnly = true;
            this.gcDescripcion.Visible = true;
            this.gcDescripcion.VisibleIndex = 2;
            this.gcDescripcion.Width = 450;
            // 
            // gcGruPre
            // 
            this.gcGruPre.AppearanceCell.Options.UseTextOptions = true;
            this.gcGruPre.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gcGruPre.Caption = "Grupo Presupuesto";
            this.gcGruPre.FieldName = "grupo";
            this.gcGruPre.Name = "gcGruPre";
            this.gcGruPre.OptionsColumn.ReadOnly = true;
            this.gcGruPre.Visible = true;
            this.gcGruPre.VisibleIndex = 3;
            this.gcGruPre.Width = 250;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.grcPresupuestoAnual;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(798, 379);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // lcNumReg
            // 
            this.lcNumReg.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lcNumReg.Appearance.Options.UseFont = true;
            this.lcNumReg.Location = new System.Drawing.Point(380, 12);
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
            this.lciLblNum.Location = new System.Drawing.Point(368, 0);
            this.lciLblNum.Name = "lciLblNum";
            this.lciLblNum.Size = new System.Drawing.Size(12, 24);
            this.lciLblNum.Text = "Registros Seleccionados :";
            this.lciLblNum.TextSize = new System.Drawing.Size(0, 0);
            this.lciLblNum.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(348, 0);
            this.emptySpaceItem1.MaxSize = new System.Drawing.Size(20, 24);
            this.emptySpaceItem1.MinSize = new System.Drawing.Size(20, 24);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(20, 24);
            this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frmExportarProgramacionAnualGenericaMasivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 493);
            this.Name = "frmExportarProgramacionAnualGenericaMasivo";
            this.Text = "Exporta Presupueto Anual - Génerica Gastos";
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcBase)).EndInit();
            this.lcBase.ResumeLayout(false);
            this.lcBase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxProveedorValidador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueAnio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMoneda.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciMoneda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcPresupuestoAnual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPresupuestoAnual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciLblNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.LookUpEdit lueAnio;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraEditors.LookUpEdit lueMoneda;
        private DevExpress.XtraLayout.LayoutControlItem lciMoneda;
        private DevExpress.XtraGrid.GridControl grcPresupuestoAnual;
        private DevExpress.XtraGrid.Views.Grid.GridView grvPresupuestoAnual;
        private DevExpress.XtraGrid.Columns.GridColumn gcCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn gcDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn gcGruPre;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.Columns.GridColumn gcSelect;
        private DevExpress.XtraEditors.LabelControl lcNumReg;
        private DevExpress.XtraLayout.LayoutControlItem lciLblNum;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}