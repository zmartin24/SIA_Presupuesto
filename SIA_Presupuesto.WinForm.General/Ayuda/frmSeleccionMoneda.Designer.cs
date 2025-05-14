namespace SIA_Presupuesto.WinForm.General.Ayuda
{
    partial class frmSeleccionMoneda
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
            this.lueMoneda = new DevExpress.XtraEditors.LookUpEdit();
            this.lciMoneda = new DevExpress.XtraLayout.LayoutControlItem();
            this.separatorControl2 = new DevExpress.XtraEditors.SeparatorControl();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.tePresupuesto = new DevExpress.XtraEditors.TextEdit();
            this.lciPresupuesto = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.teSubPresupuesto = new DevExpress.XtraEditors.TextEdit();
            this.lciSubpresupuesto = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcBase)).BeginInit();
            this.lcBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxProveedorValidador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMoneda.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciMoneda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tePresupuesto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPresupuesto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teSubPresupuesto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSubpresupuesto)).BeginInit();
            this.SuspendLayout();
            // 
            // lcCuerpo
            // 
            this.lcCuerpo.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(803, 132, 386, 350);
            this.lcCuerpo.Size = new System.Drawing.Size(584, 188);
            // 
            // lcgCuerpo
            // 
            this.lcgCuerpo.Size = new System.Drawing.Size(584, 213);
            // 
            // lcBase
            // 
            this.lcBase.Controls.Add(this.teSubPresupuesto);
            this.lcBase.Controls.Add(this.tePresupuesto);
            this.lcBase.Controls.Add(this.separatorControl2);
            this.lcBase.Controls.Add(this.lueMoneda);
            this.lcBase.Size = new System.Drawing.Size(554, 118);
            // 
            // lcgBase
            // 
            this.lcgBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciMoneda,
            this.layoutControlItem3,
            this.lciPresupuesto,
            this.emptySpaceItem1,
            this.lciSubpresupuesto});
            this.lcgBase.Size = new System.Drawing.Size(554, 118);
            // 
            // lueMoneda
            // 
            this.lueMoneda.Location = new System.Drawing.Point(54, 86);
            this.lueMoneda.Name = "lueMoneda";
            this.lueMoneda.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueMoneda.Size = new System.Drawing.Size(134, 20);
            this.lueMoneda.StyleController = this.lcBase;
            this.lueMoneda.TabIndex = 4;
            // 
            // lciMoneda
            // 
            this.lciMoneda.Control = this.lueMoneda;
            this.lciMoneda.Location = new System.Drawing.Point(0, 74);
            this.lciMoneda.MaxSize = new System.Drawing.Size(180, 24);
            this.lciMoneda.MinSize = new System.Drawing.Size(180, 24);
            this.lciMoneda.Name = "lciMoneda";
            this.lciMoneda.Size = new System.Drawing.Size(180, 24);
            this.lciMoneda.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciMoneda.Text = "Moneda";
            this.lciMoneda.TextSize = new System.Drawing.Size(38, 13);
            // 
            // separatorControl2
            // 
            this.separatorControl2.Location = new System.Drawing.Point(12, 60);
            this.separatorControl2.Name = "separatorControl2";
            this.separatorControl2.Size = new System.Drawing.Size(530, 22);
            this.separatorControl2.TabIndex = 6;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.separatorControl2;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(534, 26);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // tePresupuesto
            // 
            this.tePresupuesto.Location = new System.Drawing.Point(12, 12);
            this.tePresupuesto.Name = "tePresupuesto";
            this.tePresupuesto.Properties.ReadOnly = true;
            this.tePresupuesto.Size = new System.Drawing.Size(530, 20);
            this.tePresupuesto.StyleController = this.lcBase;
            this.tePresupuesto.TabIndex = 7;
            // 
            // lciPresupuesto
            // 
            this.lciPresupuesto.Control = this.tePresupuesto;
            this.lciPresupuesto.Location = new System.Drawing.Point(0, 0);
            this.lciPresupuesto.Name = "lciPresupuesto";
            this.lciPresupuesto.Size = new System.Drawing.Size(534, 24);
            this.lciPresupuesto.TextSize = new System.Drawing.Size(0, 0);
            this.lciPresupuesto.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(180, 74);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(354, 24);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // teSubPresupuesto
            // 
            this.teSubPresupuesto.Location = new System.Drawing.Point(12, 36);
            this.teSubPresupuesto.Name = "teSubPresupuesto";
            this.teSubPresupuesto.Properties.ReadOnly = true;
            this.teSubPresupuesto.Size = new System.Drawing.Size(530, 20);
            this.teSubPresupuesto.StyleController = this.lcBase;
            this.teSubPresupuesto.TabIndex = 8;
            // 
            // lciSubpresupuesto
            // 
            this.lciSubpresupuesto.Control = this.teSubPresupuesto;
            this.lciSubpresupuesto.Location = new System.Drawing.Point(0, 24);
            this.lciSubpresupuesto.Name = "lciSubpresupuesto";
            this.lciSubpresupuesto.Size = new System.Drawing.Size(534, 24);
            this.lciSubpresupuesto.TextSize = new System.Drawing.Size(0, 0);
            this.lciSubpresupuesto.TextVisible = false;
            // 
            // frmSeleccionMoneda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 188);
            this.Name = "frmSeleccionMoneda";
            this.Text = "frmSeleccionMoneda";
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcBase)).EndInit();
            this.lcBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxProveedorValidador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMoneda.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciMoneda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tePresupuesto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPresupuesto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teSubPresupuesto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSubpresupuesto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit lueMoneda;
        private DevExpress.XtraLayout.LayoutControlItem lciMoneda;
        private DevExpress.XtraEditors.SeparatorControl separatorControl2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.TextEdit tePresupuesto;
        private DevExpress.XtraLayout.LayoutControlItem lciPresupuesto;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.TextEdit teSubPresupuesto;
        private DevExpress.XtraLayout.LayoutControlItem lciSubpresupuesto;
    }
}