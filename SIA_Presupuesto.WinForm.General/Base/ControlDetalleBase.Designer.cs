namespace SIA_Presupuesto.WinForm.General.Base
{
    partial class ControlDetalleBase
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dxProveedorValidacion = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.lcPrincipal = new DevExpress.XtraLayout.LayoutControl();
            this.lcgPrincipal = new DevExpress.XtraLayout.LayoutControlGroup();
            ((System.ComponentModel.ISupportInitialize)(this.dxProveedorValidacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcPrincipal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgPrincipal)).BeginInit();
            this.SuspendLayout();
            // 
            // lcPrincipal
            // 
            this.lcPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcPrincipal.Location = new System.Drawing.Point(0, 0);
            this.lcPrincipal.Name = "lcPrincipal";
            this.lcPrincipal.Root = this.lcgPrincipal;
            this.lcPrincipal.Size = new System.Drawing.Size(532, 421);
            this.lcPrincipal.TabIndex = 0;
            this.lcPrincipal.Text = "layoutControl1";
            // 
            // lcgPrincipal
            // 
            this.lcgPrincipal.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcgPrincipal.GroupBordersVisible = false;
            this.lcgPrincipal.Location = new System.Drawing.Point(0, 0);
            this.lcgPrincipal.Name = "lcgPrincipal";
            this.lcgPrincipal.Size = new System.Drawing.Size(532, 421);
            this.lcgPrincipal.TextVisible = false;
            // 
            // ControlDetalleBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lcPrincipal);
            this.Name = "ControlDetalleBase";
            this.Size = new System.Drawing.Size(532, 421);
            ((System.ComponentModel.ISupportInitialize)(this.dxProveedorValidacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcPrincipal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgPrincipal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        protected DevExpress.XtraLayout.LayoutControl lcPrincipal;
        protected DevExpress.XtraLayout.LayoutControlGroup lcgPrincipal;
        protected DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxProveedorValidacion;
    }
}
