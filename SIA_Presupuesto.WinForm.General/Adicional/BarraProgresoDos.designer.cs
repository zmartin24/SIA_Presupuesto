namespace SIA_Presupuesto.WinForm.General.Adicional
{
    partial class BarraProgresoDos
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
            this.pbcProgreso = new DevExpress.XtraEditors.ProgressBarControl();
            ((System.ComponentModel.ISupportInitialize)(this.pbcProgreso.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pbcProgreso
            // 
            this.pbcProgreso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbcProgreso.Location = new System.Drawing.Point(0, 0);
            this.pbcProgreso.Name = "pbcProgreso";
            this.pbcProgreso.Size = new System.Drawing.Size(300, 25);
            this.pbcProgreso.TabIndex = 0;
            // 
            // BarraProgresoDos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 25);
            this.Controls.Add(this.pbcProgreso);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BarraProgresoDos";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BarraProgresoDos";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pbcProgreso.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.ProgressBarControl pbcProgreso;
    }
}