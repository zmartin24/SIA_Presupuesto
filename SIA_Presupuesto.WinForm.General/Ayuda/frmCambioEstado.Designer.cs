namespace SIA_Presupuesto.WinForm.General.Ayuda
{
    partial class frmCambioEstado
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
            this.lueEstado = new DevExpress.XtraEditors.LookUpEdit();
            this.lciMoneda = new DevExpress.XtraLayout.LayoutControlItem();
            this.separatorControl2 = new DevExpress.XtraEditors.SeparatorControl();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcBase)).BeginInit();
            this.lcBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxProveedorValidador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueEstado.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciMoneda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // lcCuerpo
            // 
            this.lcCuerpo.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(803, 132, 386, 350);
            this.lcCuerpo.Size = new System.Drawing.Size(361, 149);
            // 
            // lcgCuerpo
            // 
            this.lcgCuerpo.Size = new System.Drawing.Size(361, 149);
            // 
            // lcBase
            // 
            this.lcBase.Controls.Add(this.separatorControl2);
            this.lcBase.Controls.Add(this.lueEstado);
            this.lcBase.Size = new System.Drawing.Size(331, 79);
            // 
            // lcgBase
            // 
            this.lcgBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.lciMoneda});
            this.lcgBase.Size = new System.Drawing.Size(331, 79);
            // 
            // lueEstado
            // 
            this.lueEstado.Location = new System.Drawing.Point(57, 12);
            this.lueEstado.Name = "lueEstado";
            this.lueEstado.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueEstado.Size = new System.Drawing.Size(262, 20);
            this.lueEstado.StyleController = this.lcBase;
            this.lueEstado.TabIndex = 4;
            // 
            // lciMoneda
            // 
            this.lciMoneda.Control = this.lueEstado;
            this.lciMoneda.Location = new System.Drawing.Point(0, 0);
            this.lciMoneda.Name = "lciMoneda";
            this.lciMoneda.Size = new System.Drawing.Size(311, 24);
            this.lciMoneda.Text = "Estado";
            this.lciMoneda.TextSize = new System.Drawing.Size(33, 13);
            // 
            // separatorControl2
            // 
            this.separatorControl2.Location = new System.Drawing.Point(12, 36);
            this.separatorControl2.Name = "separatorControl2";
            this.separatorControl2.Size = new System.Drawing.Size(307, 31);
            this.separatorControl2.TabIndex = 6;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.separatorControl2;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(311, 35);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // frmCambioEstado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 149);
            this.Name = "frmCambioEstado";
            this.Text = "frmCambioEstado";
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcBase)).EndInit();
            this.lcBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxProveedorValidador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueEstado.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciMoneda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit lueEstado;
        private DevExpress.XtraLayout.LayoutControlItem lciMoneda;
        private DevExpress.XtraEditors.SeparatorControl separatorControl2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}