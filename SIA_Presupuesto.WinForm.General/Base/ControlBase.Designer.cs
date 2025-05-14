namespace SIA_Presupuesto.WinForm.General.Base
{
    partial class ControlBase
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lcGeneral = new DevExpress.XtraLayout.LayoutControl();
            this.lcgGeneral = new DevExpress.XtraLayout.LayoutControlGroup();
            ((System.ComponentModel.ISupportInitialize)(this.lcGeneral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgGeneral)).BeginInit();
            this.SuspendLayout();
            // 
            // lcGeneral
            // 
            this.lcGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcGeneral.Location = new System.Drawing.Point(0, 0);
            this.lcGeneral.Name = "lcGeneral";
            this.lcGeneral.Root = this.lcgGeneral;
            this.lcGeneral.Size = new System.Drawing.Size(856, 584);
            this.lcGeneral.TabIndex = 0;
            this.lcGeneral.Text = "layoutControl1";
            // 
            // lcgGeneral
            // 
            this.lcgGeneral.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcgGeneral.GroupBordersVisible = false;
            this.lcgGeneral.Location = new System.Drawing.Point(0, 0);
            this.lcgGeneral.Name = "lcgGeneral";
            this.lcgGeneral.Size = new System.Drawing.Size(856, 584);
            this.lcgGeneral.TextVisible = false;
            // 
            // ControlBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lcGeneral);
            this.Name = "ControlBase";
            this.Size = new System.Drawing.Size(856, 584);
            ((System.ComponentModel.ISupportInitialize)(this.lcGeneral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgGeneral)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected DevExpress.XtraLayout.LayoutControl lcGeneral;
        protected DevExpress.XtraLayout.LayoutControlGroup lcgGeneral;
    }
}
