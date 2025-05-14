namespace SIA_Presupuesto.WinForm.Mantenimiento.Dialogo
{
    partial class frmFuenteFinanciamiento
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
            this.txtFuente = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtCodigo = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtRubro = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtDesRubro = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcBase)).BeginInit();
            this.lcBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxProveedorValidador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFuente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRubro.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesRubro.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // lcCuerpo
            // 
            this.lcCuerpo.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(803, 132, 386, 350);
            this.lcCuerpo.Size = new System.Drawing.Size(484, 209);
            // 
            // lcgCuerpo
            // 
            this.lcgCuerpo.Size = new System.Drawing.Size(484, 209);
            // 
            // lcBase
            // 
            this.lcBase.Controls.Add(this.txtDesRubro);
            this.lcBase.Controls.Add(this.txtRubro);
            this.lcBase.Controls.Add(this.txtCodigo);
            this.lcBase.Controls.Add(this.txtFuente);
            this.lcBase.Size = new System.Drawing.Size(454, 139);
            // 
            // lcgBase
            // 
            this.lcgBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem4,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.emptySpaceItem1,
            this.layoutControlItem8});
            this.lcgBase.Size = new System.Drawing.Size(454, 139);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 72);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(434, 47);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // txtFuente
            // 
            this.txtFuente.Location = new System.Drawing.Point(102, 12);
            this.txtFuente.Name = "txtFuente";
            this.txtFuente.Properties.Mask.EditMask = "[A-Z0-9%@:*\"ÑÁÉÍÓÚ_.- -]{0,150}";
            this.txtFuente.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtFuente.Properties.Mask.ShowPlaceHolders = false;
            this.txtFuente.Size = new System.Drawing.Size(196, 20);
            this.txtFuente.StyleController = this.lcBase;
            this.txtFuente.TabIndex = 7;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtFuente;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(290, 24);
            this.layoutControlItem4.Text = "Fuente";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(86, 13);
            // 
            // txtCodigo
            // 
            this.txtCodigo.EditValue = "";
            this.txtCodigo.Location = new System.Drawing.Point(392, 12);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Properties.Mask.EditMask = "[A-Z0-9%@:*\"ÑÁÉÍÓÚ_- -]{2,2}";
            this.txtCodigo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtCodigo.Properties.Mask.ShowPlaceHolders = false;
            this.txtCodigo.Size = new System.Drawing.Size(50, 20);
            this.txtCodigo.StyleController = this.lcBase;
            this.txtCodigo.TabIndex = 13;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.txtCodigo;
            this.layoutControlItem8.Location = new System.Drawing.Point(290, 0);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(144, 24);
            this.layoutControlItem8.Text = "Código";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(86, 13);
            // 
            // txtRubro
            // 
            this.txtRubro.Location = new System.Drawing.Point(102, 36);
            this.txtRubro.Name = "txtRubro";
            this.txtRubro.Properties.Mask.EditMask = "[A-Z0-9%@:*\"ÑÁÉÍÓÚ_.- -]{2,150}";
            this.txtRubro.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtRubro.Properties.Mask.ShowPlaceHolders = false;
            this.txtRubro.Size = new System.Drawing.Size(340, 20);
            this.txtRubro.StyleController = this.lcBase;
            this.txtRubro.TabIndex = 14;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtRubro;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(434, 24);
            this.layoutControlItem2.Text = "Rubro";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(86, 13);
            // 
            // txtDesRubro
            // 
            this.txtDesRubro.Location = new System.Drawing.Point(102, 60);
            this.txtDesRubro.Name = "txtDesRubro";
            this.txtDesRubro.Properties.Mask.EditMask = "[A-Z0-9%@:*\"ÑÁÉÍÓÚ_.- -]{2,200}";
            this.txtDesRubro.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtDesRubro.Properties.Mask.ShowPlaceHolders = false;
            this.txtDesRubro.Size = new System.Drawing.Size(340, 20);
            this.txtDesRubro.StyleController = this.lcBase;
            this.txtDesRubro.TabIndex = 15;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtDesRubro;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(434, 24);
            this.layoutControlItem3.Text = "Descripción Rubro";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(86, 13);
            // 
            // frmFuenteFinanciamiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 209);
            this.Name = "frmFuenteFinanciamiento";
            this.Text = "";
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcBase)).EndInit();
            this.lcBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxProveedorValidador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFuente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRubro.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesRubro.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.TextEdit txtFuente;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.TextEdit txtCodigo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraEditors.TextEdit txtDesRubro;
        private DevExpress.XtraEditors.TextEdit txtRubro;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}