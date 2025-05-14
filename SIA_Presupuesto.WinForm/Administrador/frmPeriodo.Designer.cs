namespace SIA_Presupuesto.WinForm.Administrador
{
    partial class frmPeriodo
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
            this.components = new System.ComponentModel.Container();
            this.lcPeriodo = new DevExpress.XtraLayout.LayoutControl();
            this.sbCambioPeriodo = new DevExpress.XtraEditors.SimpleButton();
            this.sbAceptar = new DevExpress.XtraEditors.SimpleButton();
            this.lueAnio = new DevExpress.XtraEditors.LookUpEdit();
            this.lueMes = new DevExpress.XtraEditors.LookUpEdit();
            this.lcgPeriodo = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.dxProveedorValidacion = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.lcPeriodo)).BeginInit();
            this.lcPeriodo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueAnio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgPeriodo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxProveedorValidacion)).BeginInit();
            this.SuspendLayout();
            // 
            // lcPeriodo
            // 
            this.lcPeriodo.Controls.Add(this.sbCambioPeriodo);
            this.lcPeriodo.Controls.Add(this.sbAceptar);
            this.lcPeriodo.Controls.Add(this.lueAnio);
            this.lcPeriodo.Controls.Add(this.lueMes);
            this.lcPeriodo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcPeriodo.Location = new System.Drawing.Point(0, 0);
            this.lcPeriodo.Name = "lcPeriodo";
            this.lcPeriodo.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(706, 9, 250, 350);
            this.lcPeriodo.Root = this.lcgPeriodo;
            this.lcPeriodo.Size = new System.Drawing.Size(365, 81);
            this.lcPeriodo.TabIndex = 0;
            this.lcPeriodo.Text = "layoutControl1";
            // 
            // sbCambioPeriodo
            // 
            this.sbCambioPeriodo.Location = new System.Drawing.Point(331, 12);
            this.sbCambioPeriodo.Name = "sbCambioPeriodo";
            this.sbCambioPeriodo.Size = new System.Drawing.Size(22, 20);
            this.sbCambioPeriodo.StyleController = this.lcPeriodo;
            this.sbCambioPeriodo.TabIndex = 7;
            this.sbCambioPeriodo.Click += new System.EventHandler(this.sbCambioPeriodo_Click);
            // 
            // sbAceptar
            // 
            this.sbAceptar.Location = new System.Drawing.Point(173, 36);
            this.sbAceptar.Name = "sbAceptar";
            this.sbAceptar.Size = new System.Drawing.Size(180, 22);
            this.sbAceptar.StyleController = this.lcPeriodo;
            this.sbAceptar.TabIndex = 6;
            this.sbAceptar.Text = "&Aceptar";
            this.sbAceptar.Click += new System.EventHandler(this.sbAceptar_Click);
            // 
            // lueAnio
            // 
            this.lueAnio.Location = new System.Drawing.Point(34, 12);
            this.lueAnio.Name = "lueAnio";
            this.lueAnio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueAnio.Size = new System.Drawing.Size(135, 20);
            this.lueAnio.StyleController = this.lcPeriodo;
            this.lueAnio.TabIndex = 5;
            // 
            // lueMes
            // 
            this.lueMes.Location = new System.Drawing.Point(195, 12);
            this.lueMes.Name = "lueMes";
            this.lueMes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueMes.Size = new System.Drawing.Size(132, 20);
            this.lueMes.StyleController = this.lcPeriodo;
            this.lueMes.TabIndex = 4;
            // 
            // lcgPeriodo
            // 
            this.lcgPeriodo.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcgPeriodo.GroupBordersVisible = false;
            this.lcgPeriodo.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.emptySpaceItem1,
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem4});
            this.lcgPeriodo.Location = new System.Drawing.Point(0, 0);
            this.lcgPeriodo.Name = "Root";
            this.lcgPeriodo.Size = new System.Drawing.Size(365, 81);
            this.lcgPeriodo.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.sbAceptar;
            this.layoutControlItem3.Location = new System.Drawing.Point(161, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(184, 37);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 24);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(161, 37);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.lueMes;
            this.layoutControlItem1.Location = new System.Drawing.Point(161, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(158, 24);
            this.layoutControlItem1.Text = "Mes";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(19, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.lueAnio;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(161, 24);
            this.layoutControlItem2.Text = "Año";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(19, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.sbCambioPeriodo;
            this.layoutControlItem4.Location = new System.Drawing.Point(319, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(26, 24);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // frmPeriodo
            // 
            this.AcceptButton = this.sbAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 81);
            this.Controls.Add(this.lcPeriodo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPeriodo";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selección de periodo";
            ((System.ComponentModel.ISupportInitialize)(this.lcPeriodo)).EndInit();
            this.lcPeriodo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lueAnio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgPeriodo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxProveedorValidacion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl lcPeriodo;
        private DevExpress.XtraLayout.LayoutControlGroup lcgPeriodo;
        private DevExpress.XtraEditors.SimpleButton sbAceptar;
        private DevExpress.XtraEditors.LookUpEdit lueAnio;
        private DevExpress.XtraEditors.LookUpEdit lueMes;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxProveedorValidacion;
        private DevExpress.XtraEditors.SimpleButton sbCambioPeriodo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}