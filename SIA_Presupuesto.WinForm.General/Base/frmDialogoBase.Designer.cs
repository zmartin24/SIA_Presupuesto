namespace SIA_Presupuesto.WinForm.General.Base
{
    partial class frmDialogoBase
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
            this.lcCuerpo = new DevExpress.XtraLayout.LayoutControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lcBase = new DevExpress.XtraLayout.LayoutControl();
            this.lcgBase = new DevExpress.XtraLayout.LayoutControlGroup();
            this.sbAceptar = new DevExpress.XtraEditors.SimpleButton();
            this.sbCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.lcgCuerpo = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.dxProveedorValidador = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider();
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).BeginInit();
            this.lcCuerpo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxProveedorValidador)).BeginInit();
            this.SuspendLayout();
            // 
            // lcCuerpo
            // 
            this.lcCuerpo.Controls.Add(this.groupBox1);
            this.lcCuerpo.Controls.Add(this.sbAceptar);
            this.lcCuerpo.Controls.Add(this.sbCancelar);
            this.lcCuerpo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcCuerpo.Location = new System.Drawing.Point(0, 0);
            this.lcCuerpo.Name = "lcCuerpo";
            this.lcCuerpo.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(803, 132, 386, 350);
            this.lcCuerpo.Root = this.lcgCuerpo;
            this.lcCuerpo.Size = new System.Drawing.Size(435, 325);
            this.lcCuerpo.TabIndex = 0;
            this.lcCuerpo.Text = "layoutControl1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lcBase);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(411, 275);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // lcBase
            // 
            this.lcBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcBase.Location = new System.Drawing.Point(3, 17);
            this.lcBase.Name = "lcBase";
            this.lcBase.Root = this.lcgBase;
            this.lcBase.Size = new System.Drawing.Size(405, 255);
            this.lcBase.TabIndex = 0;
            // 
            // lcgBase
            // 
            this.lcgBase.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcgBase.GroupBordersVisible = false;
            this.lcgBase.Location = new System.Drawing.Point(0, 0);
            this.lcgBase.Name = "lcgBase";
            this.lcgBase.Size = new System.Drawing.Size(405, 255);
            this.lcgBase.TextVisible = false;
            // 
            // sbAceptar
            // 
            this.sbAceptar.Location = new System.Drawing.Point(267, 291);
            this.sbAceptar.Name = "sbAceptar";
            this.sbAceptar.Size = new System.Drawing.Size(76, 22);
            this.sbAceptar.StyleController = this.lcCuerpo;
            this.sbAceptar.TabIndex = 5;
            this.sbAceptar.Text = "&Aceptar";
            this.sbAceptar.Click += new System.EventHandler(this.sbAceptar_Click);
            // 
            // sbCancelar
            // 
            this.sbCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.sbCancelar.Location = new System.Drawing.Point(347, 291);
            this.sbCancelar.Name = "sbCancelar";
            this.sbCancelar.Size = new System.Drawing.Size(76, 22);
            this.sbCancelar.StyleController = this.lcCuerpo;
            this.sbCancelar.TabIndex = 4;
            this.sbCancelar.Text = "&Cancelar";
            // 
            // lcgCuerpo
            // 
            this.lcgCuerpo.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcgCuerpo.GroupBordersVisible = false;
            this.lcgCuerpo.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.emptySpaceItem1,
            this.layoutControlItem3});
            this.lcgCuerpo.Location = new System.Drawing.Point(0, 0);
            this.lcgCuerpo.Name = "Root";
            this.lcgCuerpo.Size = new System.Drawing.Size(435, 325);
            this.lcgCuerpo.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.sbCancelar;
            this.layoutControlItem1.Location = new System.Drawing.Point(335, 279);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(80, 26);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(80, 26);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(80, 26);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.sbAceptar;
            this.layoutControlItem2.Location = new System.Drawing.Point(255, 279);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(80, 26);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(80, 26);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(80, 26);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 279);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(255, 26);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.groupBox1;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(415, 279);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // frmDialogoBase
            // 
            this.AcceptButton = this.sbAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.sbCancelar;
            this.ClientSize = new System.Drawing.Size(435, 325);
            this.Controls.Add(this.lcCuerpo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDialogoBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmDialogoBase";
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).EndInit();
            this.lcCuerpo.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxProveedorValidador)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected DevExpress.XtraLayout.LayoutControl lcCuerpo;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.SimpleButton sbAceptar;
        private DevExpress.XtraEditors.SimpleButton sbCancelar;
        protected DevExpress.XtraLayout.LayoutControlGroup lcgCuerpo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        protected DevExpress.XtraLayout.LayoutControl lcBase;
        protected DevExpress.XtraLayout.LayoutControlGroup lcgBase;
        protected DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxProveedorValidador;
    }
}