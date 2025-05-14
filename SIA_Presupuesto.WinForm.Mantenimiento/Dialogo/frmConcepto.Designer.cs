namespace SIA_Presupuesto.WinForm.Mantenimiento.Dialogo
{
    partial class frmConcepto
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
            this.lueTipo = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lueOrigen = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtAbreviatura = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcBase)).BeginInit();
            this.lcBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxProveedorValidador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTipo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueOrigen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAbreviatura.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // lcCuerpo
            // 
            this.lcCuerpo.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(803, 132, 386, 350);
            this.lcCuerpo.Size = new System.Drawing.Size(484, 200);
            // 
            // lcgCuerpo
            // 
            this.lcgCuerpo.Size = new System.Drawing.Size(484, 200);
            // 
            // lcBase
            // 
            this.lcBase.Controls.Add(this.txtAbreviatura);
            this.lcBase.Controls.Add(this.lueOrigen);
            this.lcBase.Controls.Add(this.lueTipo);
            this.lcBase.Controls.Add(this.txtDescripcion);
            this.lcBase.Size = new System.Drawing.Size(454, 130);
            // 
            // lcgBase
            // 
            this.lcgBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem4,
            this.emptySpaceItem1,
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3});
            this.lcgBase.Size = new System.Drawing.Size(454, 130);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 96);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(434, 14);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(81, 60);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcion.Properties.MaxLength = 200;
            this.txtDescripcion.Size = new System.Drawing.Size(361, 20);
            this.txtDescripcion.StyleController = this.lcBase;
            this.txtDescripcion.TabIndex = 7;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtDescripcion;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(434, 24);
            this.layoutControlItem4.Text = "Descripción";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(57, 13);
            // 
            // lueTipo
            // 
            this.lueTipo.Location = new System.Drawing.Point(81, 36);
            this.lueTipo.Name = "lueTipo";
            this.lueTipo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueTipo.Size = new System.Drawing.Size(361, 20);
            this.lueTipo.StyleController = this.lcBase;
            this.lueTipo.TabIndex = 8;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.lueTipo;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(434, 24);
            this.layoutControlItem1.Text = "Tipo";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(57, 13);
            // 
            // lueOrigen
            // 
            this.lueOrigen.Location = new System.Drawing.Point(81, 12);
            this.lueOrigen.Name = "lueOrigen";
            this.lueOrigen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueOrigen.Size = new System.Drawing.Size(361, 20);
            this.lueOrigen.StyleController = this.lcBase;
            this.lueOrigen.TabIndex = 9;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.lueOrigen;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(434, 24);
            this.layoutControlItem2.Text = "Origen";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(57, 13);
            // 
            // txtAbreviatura
            // 
            this.txtAbreviatura.Location = new System.Drawing.Point(81, 84);
            this.txtAbreviatura.Name = "txtAbreviatura";
            this.txtAbreviatura.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAbreviatura.Size = new System.Drawing.Size(361, 20);
            this.txtAbreviatura.StyleController = this.lcBase;
            this.txtAbreviatura.TabIndex = 10;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtAbreviatura;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(434, 24);
            this.layoutControlItem3.Text = "Abreviatura";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(57, 13);
            // 
            // frmConcepto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 200);
            this.Name = "frmConcepto";
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
            ((System.ComponentModel.ISupportInitialize)(this.lueTipo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueOrigen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAbreviatura.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.TextEdit txtDescripcion;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.LookUpEdit lueOrigen;
        private DevExpress.XtraEditors.LookUpEdit lueTipo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.TextEdit txtAbreviatura;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}