namespace SIA_Presupuesto.WinForm.Mantenimiento.Dialogo
{
    partial class frmPropiedad
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
            this.glueConcepto = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lueTipoValor = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtValor = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.rgVisualiza = new DevExpress.XtraEditors.RadioGroup();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.seOrden = new DevExpress.XtraEditors.SpinEdit();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.sbAyudaFormula = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcBase)).BeginInit();
            this.lcBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxProveedorValidador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.glueConcepto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTipoValor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgVisualiza.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seOrden.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            this.SuspendLayout();
            // 
            // lcCuerpo
            // 
            this.lcCuerpo.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(803, 132, 386, 350);
            this.lcCuerpo.Size = new System.Drawing.Size(435, 248);
            // 
            // lcgCuerpo
            // 
            this.lcgCuerpo.Size = new System.Drawing.Size(435, 248);
            // 
            // lcBase
            // 
            this.lcBase.Controls.Add(this.sbAyudaFormula);
            this.lcBase.Controls.Add(this.seOrden);
            this.lcBase.Controls.Add(this.rgVisualiza);
            this.lcBase.Controls.Add(this.txtValor);
            this.lcBase.Controls.Add(this.lueTipoValor);
            this.lcBase.Controls.Add(this.glueConcepto);
            this.lcBase.Size = new System.Drawing.Size(405, 178);
            // 
            // lcgBase
            // 
            this.lcgBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6});
            this.lcgBase.Size = new System.Drawing.Size(405, 178);
            // 
            // glueConcepto
            // 
            this.glueConcepto.Location = new System.Drawing.Point(66, 12);
            this.glueConcepto.Name = "glueConcepto";
            this.glueConcepto.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.glueConcepto.Properties.View = this.gridLookUpEdit1View;
            this.glueConcepto.Size = new System.Drawing.Size(327, 20);
            this.glueConcepto.StyleController = this.lcBase;
            this.glueConcepto.TabIndex = 4;
            this.glueConcepto.EditValueChanged += new System.EventHandler(this.glueConcepto_EditValueChanged);
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcCodigo,
            this.gcDescripcion});
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gcCodigo
            // 
            this.gcCodigo.Caption = "Código";
            this.gcCodigo.FieldName = "codigo";
            this.gcCodigo.Name = "gcCodigo";
            this.gcCodigo.Visible = true;
            this.gcCodigo.VisibleIndex = 0;
            // 
            // gcDescripcion
            // 
            this.gcDescripcion.Caption = "Descripción";
            this.gcDescripcion.FieldName = "descripcion";
            this.gcDescripcion.Name = "gcDescripcion";
            this.gcDescripcion.Visible = true;
            this.gcDescripcion.VisibleIndex = 1;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.glueConcepto;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(385, 24);
            this.layoutControlItem1.Text = "Concepto";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(50, 13);
            // 
            // lueTipoValor
            // 
            this.lueTipoValor.Location = new System.Drawing.Point(66, 36);
            this.lueTipoValor.Name = "lueTipoValor";
            this.lueTipoValor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueTipoValor.Size = new System.Drawing.Size(327, 20);
            this.lueTipoValor.StyleController = this.lcBase;
            this.lueTipoValor.TabIndex = 5;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.lueTipoValor;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(385, 24);
            this.layoutControlItem2.Text = "Tipo Valor";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(50, 13);
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(66, 60);
            this.txtValor.Name = "txtValor";
            this.txtValor.Properties.ReadOnly = true;
            this.txtValor.Size = new System.Drawing.Size(294, 20);
            this.txtValor.StyleController = this.lcBase;
            this.txtValor.TabIndex = 6;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtValor;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(352, 26);
            this.layoutControlItem3.Text = "Valor";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(50, 13);
            // 
            // rgVisualiza
            // 
            this.rgVisualiza.EditValue = "NO";
            this.rgVisualiza.Location = new System.Drawing.Point(66, 86);
            this.rgVisualiza.Name = "rgVisualiza";
            this.rgVisualiza.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("SI", "SI"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("NO", "NO")});
            this.rgVisualiza.Size = new System.Drawing.Size(327, 56);
            this.rgVisualiza.StyleController = this.lcBase;
            this.rgVisualiza.TabIndex = 7;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.rgVisualiza;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 74);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(385, 60);
            this.layoutControlItem4.Text = "¿Visualiza?";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(50, 13);
            // 
            // seOrden
            // 
            this.seOrden.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seOrden.Location = new System.Drawing.Point(66, 146);
            this.seOrden.Name = "seOrden";
            this.seOrden.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.seOrden.Properties.IsFloatValue = false;
            this.seOrden.Properties.Mask.EditMask = "N00";
            this.seOrden.Size = new System.Drawing.Size(327, 20);
            this.seOrden.StyleController = this.lcBase;
            this.seOrden.TabIndex = 8;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.seOrden;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 134);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(385, 24);
            this.layoutControlItem5.Text = "Orden";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(50, 13);
            // 
            // sbAyudaFormula
            // 
            this.sbAyudaFormula.Enabled = false;
            this.sbAyudaFormula.Location = new System.Drawing.Point(364, 60);
            this.sbAyudaFormula.Name = "sbAyudaFormula";
            this.sbAyudaFormula.Size = new System.Drawing.Size(29, 22);
            this.sbAyudaFormula.StyleController = this.lcBase;
            this.sbAyudaFormula.TabIndex = 9;
            this.sbAyudaFormula.Text = "...";
            this.sbAyudaFormula.Click += new System.EventHandler(this.sbAyudaFormula_Click);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.sbAyudaFormula;
            this.layoutControlItem6.Location = new System.Drawing.Point(352, 48);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(33, 26);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // frmPropiedad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 248);
            this.Name = "frmPropiedad";
            this.Text = "frmPropiedad";
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcBase)).EndInit();
            this.lcBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxProveedorValidador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.glueConcepto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTipoValor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgVisualiza.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seOrden.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.GridLookUpEdit glueConcepto;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.SimpleButton sbAyudaFormula;
        private DevExpress.XtraEditors.SpinEdit seOrden;
        private DevExpress.XtraEditors.RadioGroup rgVisualiza;
        private DevExpress.XtraEditors.TextEdit txtValor;
        private DevExpress.XtraEditors.LookUpEdit lueTipoValor;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraGrid.Columns.GridColumn gcCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn gcDescripcion;
    }
}