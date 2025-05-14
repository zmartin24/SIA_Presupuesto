namespace SIA_Presupuesto.WinForm.General.Base
{
    partial class FormBase
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
            this.rcOpcion = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.pnlControl = new DevExpress.XtraEditors.PanelControl();
            this.pmExportacion = new DevExpress.XtraBars.PopupMenu();
            ((System.ComponentModel.ISupportInitialize)(this.rcOpcion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmExportacion)).BeginInit();
            this.SuspendLayout();
            // 
            // rcOpcion
            // 
            this.rcOpcion.ExpandCollapseItem.Id = 0;
            this.rcOpcion.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.rcOpcion.ExpandCollapseItem});
            this.rcOpcion.Location = new System.Drawing.Point(0, 0);
            this.rcOpcion.MaxItemId = 1;
            this.rcOpcion.Name = "rcOpcion";
            this.rcOpcion.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.rcOpcion.ShowCategoryInCaption = false;
            this.rcOpcion.ShowToolbarCustomizeItem = false;
            this.rcOpcion.Size = new System.Drawing.Size(692, 49);
            this.rcOpcion.StatusBar = this.ribbonStatusBar;
            this.rcOpcion.Toolbar.ShowCustomizeItem = false;
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 418);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.rcOpcion;
            this.ribbonStatusBar.Size = new System.Drawing.Size(692, 31);
            // 
            // pnlControl
            // 
            this.pnlControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlControl.Location = new System.Drawing.Point(0, 49);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(692, 369);
            this.pnlControl.TabIndex = 2;
            // 
            // pmExportacion
            // 
            this.pmExportacion.Name = "pmExportacion";
            this.pmExportacion.Ribbon = this.rcOpcion;
            // 
            // FormBase
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.False;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 449);
            this.Controls.Add(this.pnlControl);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.rcOpcion);
            this.KeyPreview = true;
            this.Name = "FormBase";
            this.Ribbon = this.rcOpcion;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Base";
            ((System.ComponentModel.ISupportInitialize)(this.rcOpcion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmExportacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl rcOpcion;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        protected DevExpress.XtraEditors.PanelControl pnlControl;
        private DevExpress.XtraBars.PopupMenu pmExportacion;
    }
}