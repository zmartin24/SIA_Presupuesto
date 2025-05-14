namespace SIA_Presupuesto.WinForm.Adquisicion.Dialogo
{
    partial class frmGastoRecurrente
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
            this.txtDescripcion = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.seAnio = new DevExpress.XtraEditors.SpinEdit();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.seTipCam = new DevExpress.XtraEditors.SpinEdit();
            this.lueMoneda = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcBase)).BeginInit();
            this.lcBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxProveedorValidador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seAnio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seTipCam.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMoneda.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).BeginInit();
            this.SuspendLayout();
            // 
            // lcCuerpo
            // 
            this.lcCuerpo.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(803, 132, 386, 350);
            this.lcCuerpo.Size = new System.Drawing.Size(484, 201);
            // 
            // lcgCuerpo
            // 
            this.lcgCuerpo.Size = new System.Drawing.Size(484, 201);
            // 
            // lcBase
            // 
            this.lcBase.Controls.Add(this.seAnio);
            this.lcBase.Controls.Add(this.txtDescripcion);
            this.lcBase.Controls.Add(this.lueMoneda);
            this.lcBase.Controls.Add(this.seTipCam);
            this.lcBase.Size = new System.Drawing.Size(454, 131);
            // 
            // lcgBase
            // 
            this.lcgBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem5,
            this.layoutControlItem4,
            this.layoutControlItem13,
            this.emptySpaceItem1,
            this.layoutControlItem11});
            this.lcgBase.Size = new System.Drawing.Size(454, 131);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 72);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(434, 39);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(70, 12);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(372, 20);
            this.txtDescripcion.StyleController = this.lcBase;
            this.txtDescripcion.TabIndex = 7;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtDescripcion;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(434, 24);
            this.layoutControlItem4.Text = "Descripción";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(54, 13);
            // 
            // seAnio
            // 
            this.seAnio.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seAnio.Location = new System.Drawing.Point(70, 60);
            this.seAnio.Name = "seAnio";
            this.seAnio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.seAnio.Properties.DisplayFormat.FormatString = "{0:0000}";
            this.seAnio.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.seAnio.Properties.EditFormat.FormatString = "{0:0000}";
            this.seAnio.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.seAnio.Size = new System.Drawing.Size(155, 20);
            this.seAnio.StyleController = this.lcBase;
            this.seAnio.TabIndex = 9;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.seAnio;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(217, 24);
            this.layoutControlItem5.Text = "Año";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(54, 13);
            // 
            // seTipCam
            // 
            this.seTipCam.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.seTipCam.Location = new System.Drawing.Point(287, 36);
            this.seTipCam.Name = "seTipCam";
            this.seTipCam.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.seTipCam.Properties.Mask.EditMask = "n3";
            this.seTipCam.Properties.ReadOnly = true;
            this.seTipCam.Size = new System.Drawing.Size(155, 20);
            this.seTipCam.StyleController = this.lcBase;
            this.seTipCam.TabIndex = 15;
            // 
            // lueMoneda
            // 
            this.lueMoneda.Location = new System.Drawing.Point(70, 36);
            this.lueMoneda.Name = "lueMoneda";
            this.lueMoneda.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueMoneda.Size = new System.Drawing.Size(155, 20);
            this.lueMoneda.StyleController = this.lcBase;
            this.lueMoneda.TabIndex = 5;
            this.lueMoneda.EditValueChanged += new System.EventHandler(this.lueMoneda_EditValueChanged);
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.lueMoneda;
            this.layoutControlItem11.CustomizationFormText = "Unidad";
            this.layoutControlItem11.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(217, 24);
            this.layoutControlItem11.Text = "Moneda";
            this.layoutControlItem11.TextSize = new System.Drawing.Size(54, 13);
            // 
            // layoutControlItem13
            // 
            this.layoutControlItem13.Control = this.seTipCam;
            this.layoutControlItem13.CustomizationFormText = "T.C.";
            this.layoutControlItem13.Location = new System.Drawing.Point(217, 24);
            this.layoutControlItem13.Name = "layoutControlItem13";
            this.layoutControlItem13.Size = new System.Drawing.Size(217, 48);
            this.layoutControlItem13.Text = "T.C.";
            this.layoutControlItem13.TextSize = new System.Drawing.Size(54, 13);
            // 
            // frmGastoRecurrente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 201);
            this.Name = "frmGastoRecurrente";
            this.Text = "";
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcBase)).EndInit();
            this.lcBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxProveedorValidador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seAnio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seTipCam.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMoneda.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.SpinEdit seAnio;
        private DevExpress.XtraEditors.TextEdit txtDescripcion;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.LookUpEdit lueMoneda;
        private DevExpress.XtraEditors.SpinEdit seTipCam;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem13;
    }
}