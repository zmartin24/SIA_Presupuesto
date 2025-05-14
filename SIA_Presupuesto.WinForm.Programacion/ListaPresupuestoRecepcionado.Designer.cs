namespace SIA_Presupuesto.WinForm.Programacion
{
    partial class ListaPresupuestoRecepcionado
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
            this.grcProgramacionAnual = new DevExpress.XtraGrid.GridControl();
            this.grvProgramacionAnual = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.cboAnio = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.cboMesInicio = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.cboMesFin = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcGeneral)).BeginInit();
            this.lcGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgGeneral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcProgramacionAnual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProgramacionAnual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAnio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMesInicio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMesFin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // lcGeneral
            // 
            this.lcGeneral.Controls.Add(this.cboMesFin);
            this.lcGeneral.Controls.Add(this.cboMesInicio);
            this.lcGeneral.Controls.Add(this.cboAnio);
            this.lcGeneral.Controls.Add(this.grcProgramacionAnual);
            // 
            // lcgGeneral
            // 
            this.lcgGeneral.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.emptySpaceItem1,
            this.layoutControlItem3,
            this.layoutControlItem4});
            // 
            // grcProgramacionAnual
            // 
            this.grcProgramacionAnual.Location = new System.Drawing.Point(12, 36);
            this.grcProgramacionAnual.MainView = this.grvProgramacionAnual;
            this.grcProgramacionAnual.Name = "grcProgramacionAnual";
            this.grcProgramacionAnual.Size = new System.Drawing.Size(832, 536);
            this.grcProgramacionAnual.TabIndex = 5;
            this.grcProgramacionAnual.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvProgramacionAnual});
            // 
            // grvProgramacionAnual
            // 
            this.grvProgramacionAnual.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcCodigo,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.grvProgramacionAnual.GridControl = this.grcProgramacionAnual;
            this.grvProgramacionAnual.Name = "grvProgramacionAnual";
            this.grvProgramacionAnual.OptionsBehavior.Editable = false;
            this.grvProgramacionAnual.OptionsView.ColumnAutoWidth = false;
            this.grvProgramacionAnual.OptionsView.ShowAutoFilterRow = true;
            this.grvProgramacionAnual.OptionsView.ShowFooter = true;
            // 
            // gcCodigo
            // 
            this.gcCodigo.Caption = "Código";
            this.gcCodigo.FieldName = "idGruPre";
            this.gcCodigo.Name = "gcCodigo";
            this.gcCodigo.Visible = true;
            this.gcCodigo.VisibleIndex = 0;
            this.gcCodigo.Width = 50;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Grupo";
            this.gridColumn1.FieldName = "grupo";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 2;
            this.gridColumn1.Width = 350;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Año";
            this.gridColumn2.FieldName = "anio";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 99;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Importe";
            this.gridColumn3.DisplayFormat.FormatString = "{0:n}";
            this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn3.FieldName = "cantidad";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "cantidad", "{0:n}")});
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            this.gridColumn3.Width = 122;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grcProgramacionAnual;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(836, 540);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // cboAnio
            // 
            this.cboAnio.Location = new System.Drawing.Point(71, 12);
            this.cboAnio.Name = "cboAnio";
            this.cboAnio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboAnio.Size = new System.Drawing.Size(121, 20);
            this.cboAnio.StyleController = this.lcGeneral;
            this.cboAnio.TabIndex = 6;
            this.cboAnio.EditValueChanged += new System.EventHandler(this.cboAnio_EditValueChanged);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.cboAnio;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(184, 24);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(184, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(184, 24);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Text = "Año";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(47, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(514, 0);
            this.emptySpaceItem1.MaxSize = new System.Drawing.Size(322, 24);
            this.emptySpaceItem1.MinSize = new System.Drawing.Size(322, 24);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(322, 24);
            this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // cboMesInicio
            // 
            this.cboMesInicio.Location = new System.Drawing.Point(255, 12);
            this.cboMesInicio.Name = "cboMesInicio";
            this.cboMesInicio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboMesInicio.Size = new System.Drawing.Size(96, 20);
            this.cboMesInicio.StyleController = this.lcGeneral;
            this.cboMesInicio.TabIndex = 7;
            this.cboMesInicio.EditValueChanged += new System.EventHandler(this.cboMes_EditValueChanged);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.cboMesInicio;
            this.layoutControlItem3.Location = new System.Drawing.Point(184, 0);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(159, 24);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(159, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(159, 24);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Text = "Mes Inicio";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(47, 13);
            // 
            // cboMesFin
            // 
            this.cboMesFin.Location = new System.Drawing.Point(414, 12);
            this.cboMesFin.Name = "cboMesFin";
            this.cboMesFin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboMesFin.Size = new System.Drawing.Size(108, 20);
            this.cboMesFin.StyleController = this.lcGeneral;
            this.cboMesFin.TabIndex = 8;
            this.cboMesFin.EditValueChanged += new System.EventHandler(this.cboMesFin_EditValueChanged);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.cboMesFin;
            this.layoutControlItem4.Location = new System.Drawing.Point(343, 0);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(171, 24);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(171, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(171, 24);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.Text = "Mes Final";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(47, 13);
            // 
            // ListaPresupuestoRecepcionado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ListaPresupuestoRecepcionado";
            ((System.ComponentModel.ISupportInitialize)(this.lcGeneral)).EndInit();
            this.lcGeneral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgGeneral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcProgramacionAnual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProgramacionAnual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAnio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMesInicio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMesFin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grcProgramacionAnual;
        private DevExpress.XtraGrid.Views.Grid.GridView grvProgramacionAnual;
        private DevExpress.XtraGrid.Columns.GridColumn gcCodigo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.LookUpEdit cboMesInicio;
        private DevExpress.XtraEditors.LookUpEdit cboAnio;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.LookUpEdit cboMesFin;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}