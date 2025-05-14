namespace SIA_Presupuesto.WinForm.Programacion.Dialogo
{
    partial class frmExportarReajusteEvaluacionMasivo
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
            this.lueMes = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lueMesReajuste = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.trvPresupuesto = new System.Windows.Forms.TreeView();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.grcProgramacionAnual = new DevExpress.XtraGrid.GridControl();
            this.grvProgramacionAnual = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcSelect = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
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
            ((System.ComponentModel.ISupportInitialize)(this.lueMes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMesReajuste.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcProgramacionAnual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProgramacionAnual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciLblNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // lcCuerpo
            // 
            this.lcCuerpo.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(803, 132, 386, 350);
            this.lcCuerpo.Size = new System.Drawing.Size(798, 422);
            // 
            // lcgCuerpo
            // 
            this.lcgCuerpo.Size = new System.Drawing.Size(798, 422);
            // 
            // lcBase
            // 
            this.lcBase.Controls.Add(this.lcNumReg);
            this.lcBase.Controls.Add(this.grcProgramacionAnual);
            this.lcBase.Controls.Add(this.trvPresupuesto);
            this.lcBase.Controls.Add(this.lueMesReajuste);
            this.lcBase.Controls.Add(this.lueMes);
            this.lcBase.Controls.Add(this.lueAnio);
            this.lcBase.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(276, 300, 450, 400);
            this.lcBase.Size = new System.Drawing.Size(768, 352);
            // 
            // lcgBase
            // 
            this.lcgBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.emptySpaceItem2,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.lciLblNum,
            this.emptySpaceItem1});
            this.lcgBase.Name = "Root";
            this.lcgBase.Size = new System.Drawing.Size(768, 352);
            // 
            // lueAnio
            // 
            this.lueAnio.Location = new System.Drawing.Point(130, 12);
            this.lueAnio.Name = "lueAnio";
            this.lueAnio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueAnio.Size = new System.Drawing.Size(252, 20);
            this.lueAnio.StyleController = this.lcBase;
            this.lueAnio.TabIndex = 4;
            this.lueAnio.EditValueChanged += new System.EventHandler(this.lueAnio_EditValueChanged);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.lueAnio;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(374, 24);
            this.layoutControlItem1.Text = "Año";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(106, 13);
            // 
            // lueMes
            // 
            this.lueMes.Location = new System.Drawing.Point(130, 36);
            this.lueMes.Name = "lueMes";
            this.lueMes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueMes.Size = new System.Drawing.Size(252, 20);
            this.lueMes.StyleController = this.lcBase;
            this.lueMes.TabIndex = 7;
            this.lueMes.EditValueChanged += new System.EventHandler(this.lueMes_EditValueChanged);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.lueMes;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(374, 24);
            this.layoutControlItem4.Text = "Mes Evaluación";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(106, 13);
            // 
            // lueMesReajuste
            // 
            this.lueMesReajuste.Location = new System.Drawing.Point(504, 36);
            this.lueMesReajuste.Name = "lueMesReajuste";
            this.lueMesReajuste.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueMesReajuste.Properties.ReadOnly = true;
            this.lueMesReajuste.Size = new System.Drawing.Size(252, 20);
            this.lueMesReajuste.StyleController = this.lcBase;
            this.lueMesReajuste.TabIndex = 8;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.lueMesReajuste;
            this.layoutControlItem5.Location = new System.Drawing.Point(374, 24);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(374, 24);
            this.layoutControlItem5.Text = "Mes Reajuste";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(106, 13);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(374, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(374, 24);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // trvPresupuesto
            // 
            this.trvPresupuesto.CheckBoxes = true;
            this.trvPresupuesto.Location = new System.Drawing.Point(130, 60);
            this.trvPresupuesto.Name = "trvPresupuesto";
            this.trvPresupuesto.Size = new System.Drawing.Size(626, 22);
            this.trvPresupuesto.TabIndex = 9;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.trvPresupuesto;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(748, 26);
            this.layoutControlItem2.Text = "Presupuestos Anuales";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(106, 13);
            this.layoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // grcProgramacionAnual
            // 
            this.grcProgramacionAnual.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.grcProgramacionAnual.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.grcProgramacionAnual.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.grcProgramacionAnual.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.grcProgramacionAnual.EmbeddedNavigator.Buttons.Remove.Visible = false;
            gridLevelNode2.RelationName = "Level1";
            this.grcProgramacionAnual.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode2});
            this.grcProgramacionAnual.Location = new System.Drawing.Point(12, 86);
            this.grcProgramacionAnual.MainView = this.grvProgramacionAnual;
            this.grcProgramacionAnual.Name = "grcProgramacionAnual";
            this.grcProgramacionAnual.Size = new System.Drawing.Size(744, 233);
            this.grcProgramacionAnual.TabIndex = 12;
            this.grcProgramacionAnual.UseEmbeddedNavigator = true;
            this.grcProgramacionAnual.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvProgramacionAnual});
            // 
            // grvProgramacionAnual
            // 
            this.grvProgramacionAnual.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcSelect,
            this.gcCodigo,
            this.gcDescripcion});
            this.grvProgramacionAnual.GridControl = this.grcProgramacionAnual;
            this.grvProgramacionAnual.Name = "grvProgramacionAnual";
            this.grvProgramacionAnual.OptionsBehavior.ReadOnly = true;
            this.grvProgramacionAnual.OptionsSelection.CheckBoxSelectorField = "esSeleccionado";
            this.grvProgramacionAnual.OptionsSelection.MultiSelect = true;
            this.grvProgramacionAnual.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.grvProgramacionAnual.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
            this.grvProgramacionAnual.OptionsSelection.ShowCheckBoxSelectorInGroupRow = DevExpress.Utils.DefaultBoolean.True;
            this.grvProgramacionAnual.OptionsView.ColumnAutoWidth = false;
            this.grvProgramacionAnual.OptionsView.ShowAutoFilterRow = true;
            this.grvProgramacionAnual.OptionsView.ShowGroupPanel = false;
            this.grvProgramacionAnual.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.grvProgramacionAnual_SelectionChanged);
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
            this.gcSelect.Width = 20;
            // 
            // gcCodigo
            // 
            this.gcCodigo.Caption = "Código";
            this.gcCodigo.FieldName = "idProAnu";
            this.gcCodigo.Name = "gcCodigo";
            this.gcCodigo.OptionsColumn.ReadOnly = true;
            this.gcCodigo.Visible = true;
            this.gcCodigo.VisibleIndex = 1;
            this.gcCodigo.Width = 50;
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
            this.gcDescripcion.Width = 600;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.grcProgramacionAnual;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 74);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(748, 237);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // lcNumReg
            // 
            this.lcNumReg.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lcNumReg.Appearance.Options.UseFont = true;
            this.lcNumReg.Location = new System.Drawing.Point(12, 323);
            this.lcNumReg.Name = "lcNumReg";
            this.lcNumReg.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.lcNumReg.Size = new System.Drawing.Size(8, 17);
            this.lcNumReg.StyleController = this.lcBase;
            this.lcNumReg.TabIndex = 13;
            this.lcNumReg.Text = "0";
            // 
            // lciLblNum
            // 
            this.lciLblNum.Control = this.lcNumReg;
            this.lciLblNum.Location = new System.Drawing.Point(0, 311);
            this.lciLblNum.Name = "lciLblNum";
            this.lciLblNum.Size = new System.Drawing.Size(12, 21);
            this.lciLblNum.TextSize = new System.Drawing.Size(0, 0);
            this.lciLblNum.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(12, 311);
            this.emptySpaceItem1.MaxSize = new System.Drawing.Size(0, 21);
            this.emptySpaceItem1.MinSize = new System.Drawing.Size(10, 21);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(736, 21);
            this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frmExportarReajusteEvaluacionMasivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 422);
            this.Name = "frmExportarReajusteEvaluacionMasivo";
            this.Text = "frmImprimirPorDireccion";
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcBase)).EndInit();
            this.lcBase.ResumeLayout(false);
            this.lcBase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxProveedorValidador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueAnio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMesReajuste.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcProgramacionAnual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProgramacionAnual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciLblNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.LookUpEdit lueAnio;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.LookUpEdit lueMes;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.LookUpEdit lueMesReajuste;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private System.Windows.Forms.TreeView trvPresupuesto;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.GridControl grcProgramacionAnual;
        private DevExpress.XtraGrid.Views.Grid.GridView grvProgramacionAnual;
        private DevExpress.XtraGrid.Columns.GridColumn gcSelect;
        private DevExpress.XtraGrid.Columns.GridColumn gcCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn gcDescripcion;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.LabelControl lcNumReg;
        private DevExpress.XtraLayout.LayoutControlItem lciLblNum;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}