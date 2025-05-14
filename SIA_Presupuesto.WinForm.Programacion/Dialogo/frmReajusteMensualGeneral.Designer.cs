namespace SIA_Presupuesto.WinForm.Programacion.Dialogo
{
    partial class frmReajusteMensualGeneral
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
            this.deFechaEmision = new DevExpress.XtraEditors.DateEdit();
            this.txtDescripcion = new DevExpress.XtraEditors.TextEdit();
            this.lueMesReajuste = new DevExpress.XtraEditors.LookUpEdit();
            this.seTipoCambio = new DevExpress.XtraEditors.SpinEdit();
            this.sbAyudaTipoCambio = new DevExpress.XtraEditors.SimpleButton();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lueAnio = new DevExpress.XtraEditors.LookUpEdit();
            this.gluePresupuesto = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcIdProAnu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciPresupuesto = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcBase)).BeginInit();
            this.lcBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxProveedorValidador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaEmision.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaEmision.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMesReajuste.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seTipoCambio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueAnio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gluePresupuesto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPresupuesto)).BeginInit();
            this.SuspendLayout();
            // 
            // lcCuerpo
            // 
            this.lcCuerpo.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(803, 132, 386, 350);
            this.lcCuerpo.Size = new System.Drawing.Size(714, 216);
            // 
            // lcgCuerpo
            // 
            this.lcgCuerpo.Size = new System.Drawing.Size(714, 216);
            // 
            // lcBase
            // 
            this.lcBase.Controls.Add(this.gluePresupuesto);
            this.lcBase.Controls.Add(this.lueAnio);
            this.lcBase.Controls.Add(this.sbAyudaTipoCambio);
            this.lcBase.Controls.Add(this.seTipoCambio);
            this.lcBase.Controls.Add(this.lueMesReajuste);
            this.lcBase.Controls.Add(this.txtDescripcion);
            this.lcBase.Controls.Add(this.deFechaEmision);
            this.lcBase.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(646, 273, 450, 400);
            this.lcBase.Size = new System.Drawing.Size(684, 146);
            // 
            // lcgBase
            // 
            this.lcgBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem7,
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem8,
            this.layoutControlItem5,
            this.layoutControlItem4,
            this.lciPresupuesto});
            this.lcgBase.Name = "Root";
            this.lcgBase.Size = new System.Drawing.Size(684, 146);
            // 
            // deFechaEmision
            // 
            this.deFechaEmision.EditValue = null;
            this.deFechaEmision.Location = new System.Drawing.Point(432, 60);
            this.deFechaEmision.Name = "deFechaEmision";
            this.deFechaEmision.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaEmision.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaEmision.Size = new System.Drawing.Size(240, 20);
            this.deFechaEmision.StyleController = this.lcBase;
            this.deFechaEmision.TabIndex = 4;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(101, 84);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(571, 20);
            this.txtDescripcion.StyleController = this.lcBase;
            this.txtDescripcion.TabIndex = 7;
            // 
            // lueMesReajuste
            // 
            this.lueMesReajuste.Location = new System.Drawing.Point(101, 60);
            this.lueMesReajuste.Name = "lueMesReajuste";
            this.lueMesReajuste.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueMesReajuste.Size = new System.Drawing.Size(238, 20);
            this.lueMesReajuste.StyleController = this.lcBase;
            this.lueMesReajuste.TabIndex = 11;
            this.lueMesReajuste.EditValueChanged += new System.EventHandler(this.lueMesReajuste_EditValueChanged);
            // 
            // seTipoCambio
            // 
            this.seTipoCambio.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seTipoCambio.Location = new System.Drawing.Point(101, 108);
            this.seTipoCambio.Name = "seTipoCambio";
            this.seTipoCambio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.seTipoCambio.Properties.ReadOnly = true;
            this.seTipoCambio.Size = new System.Drawing.Size(222, 20);
            this.seTipoCambio.StyleController = this.lcBase;
            this.seTipoCambio.TabIndex = 14;
            // 
            // sbAyudaTipoCambio
            // 
            this.sbAyudaTipoCambio.Location = new System.Drawing.Point(327, 108);
            this.sbAyudaTipoCambio.Name = "sbAyudaTipoCambio";
            this.sbAyudaTipoCambio.Size = new System.Drawing.Size(27, 20);
            this.sbAyudaTipoCambio.StyleController = this.lcBase;
            this.sbAyudaTipoCambio.TabIndex = 15;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(346, 96);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(318, 30);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lueAnio
            // 
            this.lueAnio.Location = new System.Drawing.Point(101, 12);
            this.lueAnio.Name = "lueAnio";
            this.lueAnio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueAnio.Size = new System.Drawing.Size(571, 20);
            this.lueAnio.StyleController = this.lcBase;
            this.lueAnio.TabIndex = 16;
            this.lueAnio.EditValueChanged += new System.EventHandler(this.lueAnio_EditValueChanged);
            // 
            // gluePresupuesto
            // 
            this.gluePresupuesto.Location = new System.Drawing.Point(101, 36);
            this.gluePresupuesto.Name = "gluePresupuesto";
            this.gluePresupuesto.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gluePresupuesto.Properties.DisplayMember = "descripcion";
            this.gluePresupuesto.Properties.PopupView = this.gridLookUpEdit1View;
            this.gluePresupuesto.Properties.ValueMember = "idProAnu";
            this.gluePresupuesto.Size = new System.Drawing.Size(571, 20);
            this.gluePresupuesto.StyleController = this.lcBase;
            this.gluePresupuesto.TabIndex = 17;
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcIdProAnu,
            this.gcDescripcion});
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsBehavior.ReadOnly = true;
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ColumnAutoWidth = false;
            this.gridLookUpEdit1View.OptionsView.ShowAutoFilterRow = true;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gcIdProAnu
            // 
            this.gcIdProAnu.Caption = "Código";
            this.gcIdProAnu.FieldName = "idProAnu";
            this.gcIdProAnu.Name = "gcIdProAnu";
            this.gcIdProAnu.Visible = true;
            this.gcIdProAnu.VisibleIndex = 0;
            this.gcIdProAnu.Width = 60;
            // 
            // gcDescripcion
            // 
            this.gcDescripcion.Caption = "Descripción";
            this.gcDescripcion.FieldName = "descripcion";
            this.gcDescripcion.Name = "gcDescripcion";
            this.gcDescripcion.Visible = true;
            this.gcDescripcion.VisibleIndex = 1;
            this.gcDescripcion.Width = 700;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.lueMesReajuste;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(331, 24);
            this.layoutControlItem3.Text = "Mes de reajuste";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(77, 13);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.seTipoCambio;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 96);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(315, 30);
            this.layoutControlItem7.Text = "Tipo de Cambio";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(77, 13);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.deFechaEmision;
            this.layoutControlItem1.Location = new System.Drawing.Point(331, 48);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(333, 24);
            this.layoutControlItem1.Text = "Fecha Emisión";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(77, 13);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.sbAyudaTipoCambio;
            this.layoutControlItem8.Location = new System.Drawing.Point(315, 96);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(31, 30);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.lueAnio;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(664, 24);
            this.layoutControlItem5.Text = "Año";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(77, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtDescripcion;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(664, 24);
            this.layoutControlItem4.Text = "Descripción";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(77, 13);
            // 
            // lciPresupuesto
            // 
            this.lciPresupuesto.Control = this.gluePresupuesto;
            this.lciPresupuesto.Location = new System.Drawing.Point(0, 24);
            this.lciPresupuesto.Name = "lciPresupuesto";
            this.lciPresupuesto.Size = new System.Drawing.Size(664, 24);
            this.lciPresupuesto.Text = "Pres. Anual";
            this.lciPresupuesto.TextSize = new System.Drawing.Size(77, 13);
            // 
            // frmReajusteMensualGeneral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 216);
            this.Name = "frmReajusteMensualGeneral";
            this.Text = "";
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcBase)).EndInit();
            this.lcBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxProveedorValidador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaEmision.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaEmision.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMesReajuste.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seTipoCambio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueAnio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gluePresupuesto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPresupuesto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.DateEdit deFechaEmision;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.TextEdit txtDescripcion;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.LookUpEdit lueMesReajuste;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.SimpleButton sbAyudaTipoCambio;
        private DevExpress.XtraEditors.SpinEdit seTipoCambio;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.LookUpEdit lueAnio;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.GridLookUpEdit gluePresupuesto;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraLayout.LayoutControlItem lciPresupuesto;
        private DevExpress.XtraGrid.Columns.GridColumn gcIdProAnu;
        private DevExpress.XtraGrid.Columns.GridColumn gcDescripcion;
    }
}