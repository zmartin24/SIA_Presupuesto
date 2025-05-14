namespace SIA_Presupuesto.WinForm.Adquisicion.Dialogo
{
    partial class frmImprimirPac
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
            this.lueDireccion = new DevExpress.XtraEditors.LookUpEdit();
            this.lciDireccion = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lueReporte = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lueFueFin = new DevExpress.XtraEditors.LookUpEdit();
            this.lciFueFin = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcBase)).BeginInit();
            this.lcBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxProveedorValidador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDireccion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDireccion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueReporte.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueFueFin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciFueFin)).BeginInit();
            this.SuspendLayout();
            // 
            // lcCuerpo
            // 
            this.lcCuerpo.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(803, 132, 386, 350);
            this.lcCuerpo.Size = new System.Drawing.Size(534, 174);
            // 
            // lcgCuerpo
            // 
            this.lcgCuerpo.Size = new System.Drawing.Size(534, 174);
            // 
            // lcBase
            // 
            this.lcBase.Controls.Add(this.lueReporte);
            this.lcBase.Controls.Add(this.lueDireccion);
            this.lcBase.Controls.Add(this.lueFueFin);
            this.lcBase.Size = new System.Drawing.Size(504, 104);
            // 
            // lcgBase
            // 
            this.lcgBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciDireccion,
            this.emptySpaceItem1,
            this.layoutControlItem2,
            this.lciFueFin});
            this.lcgBase.Name = "Root";
            this.lcgBase.Size = new System.Drawing.Size(504, 104);
            // 
            // lueDireccion
            // 
            this.lueDireccion.Location = new System.Drawing.Point(124, 36);
            this.lueDireccion.Name = "lueDireccion";
            this.lueDireccion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueDireccion.Size = new System.Drawing.Size(368, 20);
            this.lueDireccion.StyleController = this.lcBase;
            this.lueDireccion.TabIndex = 4;
            // 
            // lciDireccion
            // 
            this.lciDireccion.Control = this.lueDireccion;
            this.lciDireccion.Location = new System.Drawing.Point(0, 24);
            this.lciDireccion.Name = "lciDireccion";
            this.lciDireccion.Size = new System.Drawing.Size(484, 24);
            this.lciDireccion.Text = "Dirección";
            this.lciDireccion.TextSize = new System.Drawing.Size(108, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 72);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(484, 12);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lueReporte
            // 
            this.lueReporte.Location = new System.Drawing.Point(124, 12);
            this.lueReporte.Name = "lueReporte";
            this.lueReporte.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueReporte.Size = new System.Drawing.Size(368, 20);
            this.lueReporte.StyleController = this.lcBase;
            this.lueReporte.TabIndex = 5;
            this.lueReporte.EditValueChanged += new System.EventHandler(this.lueReporte_EditValueChanged);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.lueReporte;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(484, 24);
            this.layoutControlItem2.Text = "Reporte";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(108, 13);
            // 
            // lueFueFin
            // 
            this.lueFueFin.Location = new System.Drawing.Point(124, 60);
            this.lueFueFin.Name = "lueFueFin";
            this.lueFueFin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueFueFin.Size = new System.Drawing.Size(368, 20);
            this.lueFueFin.StyleController = this.lcBase;
            this.lueFueFin.TabIndex = 4;
            // 
            // lciFueFin
            // 
            this.lciFueFin.Control = this.lueFueFin;
            this.lciFueFin.CustomizationFormText = "Dirección";
            this.lciFueFin.Location = new System.Drawing.Point(0, 48);
            this.lciFueFin.Name = "lciFueFin";
            this.lciFueFin.Size = new System.Drawing.Size(484, 24);
            this.lciFueFin.Text = "Fuente Financiamiento";
            this.lciFueFin.TextSize = new System.Drawing.Size(108, 13);
            // 
            // frmImprimirPac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 174);
            this.Name = "frmImprimirPac";
            this.Text = "frmImprimirPorDireccion";
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcBase)).EndInit();
            this.lcBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxProveedorValidador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDireccion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDireccion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueReporte.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueFueFin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciFueFin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit lueDireccion;
        private DevExpress.XtraLayout.LayoutControlItem lciDireccion;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.LookUpEdit lueReporte;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.LookUpEdit lueFueFin;
        private DevExpress.XtraLayout.LayoutControlItem lciFueFin;
    }
}