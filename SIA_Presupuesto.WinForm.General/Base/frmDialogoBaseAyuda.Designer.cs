namespace SIA_Presupuesto.WinForm.General.Base
{
    partial class frmDialogoBaseAyuda
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
            this.lcGeneral = new DevExpress.XtraLayout.LayoutControl();
            this.sbSalir = new DevExpress.XtraEditors.SimpleButton();
            this.gbCuerpo = new System.Windows.Forms.GroupBox();
            this.lcCuerpo = new DevExpress.XtraLayout.LayoutControl();
            this.lcgCuerpo = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lcgGeneral = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcGeneral)).BeginInit();
            this.lcGeneral.SuspendLayout();
            this.gbCuerpo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgGeneral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // lcGeneral
            // 
            this.lcGeneral.Controls.Add(this.sbSalir);
            this.lcGeneral.Controls.Add(this.gbCuerpo);
            this.lcGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcGeneral.Location = new System.Drawing.Point(0, 0);
            this.lcGeneral.Name = "lcGeneral";
            this.lcGeneral.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(572, 76, 250, 350);
            this.lcGeneral.Root = this.lcgGeneral;
            this.lcGeneral.Size = new System.Drawing.Size(493, 212);
            this.lcGeneral.TabIndex = 0;
            this.lcGeneral.Text = "layoutControl1";
            // 
            // sbSalir
            // 
            this.sbSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.sbSalir.Location = new System.Drawing.Point(427, 178);
            this.sbSalir.Name = "sbSalir";
            this.sbSalir.Size = new System.Drawing.Size(54, 22);
            this.sbSalir.StyleController = this.lcGeneral;
            this.sbSalir.TabIndex = 5;
            this.sbSalir.Text = "&Salir";
            // 
            // gbCuerpo
            // 
            this.gbCuerpo.Controls.Add(this.lcCuerpo);
            this.gbCuerpo.Location = new System.Drawing.Point(12, 12);
            this.gbCuerpo.Name = "gbCuerpo";
            this.gbCuerpo.Size = new System.Drawing.Size(469, 162);
            this.gbCuerpo.TabIndex = 4;
            this.gbCuerpo.TabStop = false;
            // 
            // lcCuerpo
            // 
            this.lcCuerpo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcCuerpo.Location = new System.Drawing.Point(3, 17);
            this.lcCuerpo.Name = "lcCuerpo";
            this.lcCuerpo.Root = this.lcgCuerpo;
            this.lcCuerpo.Size = new System.Drawing.Size(463, 142);
            this.lcCuerpo.TabIndex = 0;
            this.lcCuerpo.Text = "layoutControl1";
            // 
            // lcgCuerpo
            // 
            this.lcgCuerpo.CustomizationFormText = "lcgCuerpo";
            this.lcgCuerpo.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcgCuerpo.GroupBordersVisible = false;
            this.lcgCuerpo.Location = new System.Drawing.Point(0, 0);
            this.lcgCuerpo.Name = "lcgCuerpo";
            this.lcgCuerpo.Size = new System.Drawing.Size(463, 142);
            this.lcgCuerpo.TextVisible = false;
            // 
            // lcgGeneral
            // 
            this.lcgGeneral.CustomizationFormText = "layoutControlGroup1";
            this.lcgGeneral.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcgGeneral.GroupBordersVisible = false;
            this.lcgGeneral.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem2});
            this.lcgGeneral.Location = new System.Drawing.Point(0, 0);
            this.lcgGeneral.Name = "Root";
            this.lcgGeneral.Size = new System.Drawing.Size(493, 212);
            this.lcgGeneral.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gbCuerpo;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(473, 166);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 166);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(415, 26);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.sbSalir;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(415, 166);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(58, 26);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // frmDialogoBaseAyuda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.sbSalir;
            this.ClientSize = new System.Drawing.Size(493, 212);
            this.Controls.Add(this.lcGeneral);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDialogoBaseAyuda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDialogoBaseAyuda";
            ((System.ComponentModel.ISupportInitialize)(this.lcGeneral)).EndInit();
            this.lcGeneral.ResumeLayout(false);
            this.gbCuerpo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgGeneral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl lcGeneral;
        private DevExpress.XtraLayout.LayoutControlGroup lcgGeneral;
        private DevExpress.XtraEditors.SimpleButton sbSalir;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        protected System.Windows.Forms.GroupBox gbCuerpo;
        protected DevExpress.XtraLayout.LayoutControl lcCuerpo;
        protected DevExpress.XtraLayout.LayoutControlGroup lcgCuerpo;
    }
}