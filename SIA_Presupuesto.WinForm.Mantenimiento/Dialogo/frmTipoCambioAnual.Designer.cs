namespace SIA_Presupuesto.WinForm.Mantenimiento.Dialogo
{
    partial class frmTipoCambioAnual
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
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.seValor = new DevExpress.XtraEditors.SpinEdit();
            this.lciValor = new DevExpress.XtraLayout.LayoutControlItem();
            this.lueMoneda = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.seAnio = new DevExpress.XtraEditors.SpinEdit();
            this.lciAnio = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcBase)).BeginInit();
            this.lcBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxProveedorValidador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seValor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciValor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMoneda.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seAnio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciAnio)).BeginInit();
            this.SuspendLayout();
            // 
            // lcCuerpo
            // 
            this.lcCuerpo.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(803, 132, 386, 350);
            this.lcCuerpo.Size = new System.Drawing.Size(384, 175);
            // 
            // lcgCuerpo
            // 
            this.lcgCuerpo.Size = new System.Drawing.Size(384, 175);
            // 
            // lcBase
            // 
            this.lcBase.Controls.Add(this.lueMoneda);
            this.lcBase.Controls.Add(this.seValor);
            this.lcBase.Controls.Add(this.seAnio);
            this.lcBase.Size = new System.Drawing.Size(354, 105);
            // 
            // lcgBase
            // 
            this.lcgBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem1,
            this.layoutControlItem4,
            this.lciAnio,
            this.lciValor});
            this.lcgBase.Name = "Root";
            this.lcgBase.Size = new System.Drawing.Size(354, 105);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 48);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(334, 37);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // seValor
            // 
            this.seValor.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seValor.Location = new System.Drawing.Point(201, 36);
            this.seValor.Name = "seValor";
            this.seValor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.seValor.Properties.Mask.EditMask = "[0-9]{1,2}(\\.[0-9]{0,3})?";
            this.seValor.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.seValor.Properties.Mask.ShowPlaceHolders = false;
            this.seValor.Size = new System.Drawing.Size(141, 20);
            this.seValor.StyleController = this.lcBase;
            this.seValor.TabIndex = 16;
            // 
            // lciValor
            // 
            this.lciValor.Control = this.seValor;
            this.lciValor.Location = new System.Drawing.Point(147, 24);
            this.lciValor.Name = "lciValor";
            this.lciValor.Size = new System.Drawing.Size(187, 24);
            this.lciValor.Text = "Valor";
            this.lciValor.TextSize = new System.Drawing.Size(38, 13);
            // 
            // lueMoneda
            // 
            this.lueMoneda.Location = new System.Drawing.Point(54, 12);
            this.lueMoneda.Name = "lueMoneda";
            this.lueMoneda.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueMoneda.Size = new System.Drawing.Size(288, 20);
            this.lueMoneda.StyleController = this.lcBase;
            this.lueMoneda.TabIndex = 17;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.lueMoneda;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(334, 24);
            this.layoutControlItem4.Text = "Moneda";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(38, 13);
            // 
            // seAnio
            // 
            this.seAnio.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seAnio.Location = new System.Drawing.Point(54, 36);
            this.seAnio.Name = "seAnio";
            this.seAnio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.seAnio.Properties.Mask.EditMask = "[0-9]{4}";
            this.seAnio.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.seAnio.Properties.Mask.ShowPlaceHolders = false;
            this.seAnio.Size = new System.Drawing.Size(101, 20);
            this.seAnio.StyleController = this.lcBase;
            this.seAnio.TabIndex = 16;
            this.seAnio.EditValueChanged += new System.EventHandler(this.seAnio_EditValueChanged);
            // 
            // lciAnio
            // 
            this.lciAnio.Control = this.seAnio;
            this.lciAnio.CustomizationFormText = "Valor";
            this.lciAnio.Location = new System.Drawing.Point(0, 24);
            this.lciAnio.Name = "lciAnio";
            this.lciAnio.Size = new System.Drawing.Size(147, 24);
            this.lciAnio.Text = "Año";
            this.lciAnio.TextSize = new System.Drawing.Size(38, 13);
            // 
            // frmTipoCambioAnual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 175);
            this.Name = "frmTipoCambioAnual";
            this.Text = "";
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcBase)).EndInit();
            this.lcBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxProveedorValidador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seValor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciValor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMoneda.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seAnio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciAnio)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.LookUpEdit lueMoneda;
        private DevExpress.XtraEditors.SpinEdit seValor;
        private DevExpress.XtraLayout.LayoutControlItem lciValor;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.SpinEdit seAnio;
        private DevExpress.XtraLayout.LayoutControlItem lciAnio;
    }
}