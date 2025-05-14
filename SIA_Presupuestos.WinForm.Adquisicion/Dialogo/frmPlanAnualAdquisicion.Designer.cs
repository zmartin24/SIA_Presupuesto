namespace SIA_Presupuesto.WinForm.Adquisicion.Dialogo
{
    partial class frmPlanAnualAdquisicion
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
            this.deFechaEmision = new DevExpress.XtraEditors.DateEdit();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.txtDescripcion = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.seAnio = new DevExpress.XtraEditors.SpinEdit();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtSiglas = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtUndEje = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtPliego = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.seTipCam = new DevExpress.XtraEditors.SpinEdit();
            this.lueMoneda = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcBase)).BeginInit();
            this.lcBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxProveedorValidador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaEmision.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaEmision.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seAnio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSiglas.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUndEje.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPliego.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seTipCam.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMoneda.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).BeginInit();
            this.SuspendLayout();
            // 
            // lcCuerpo
            // 
            this.lcCuerpo.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(803, 132, 386, 350);
            this.lcCuerpo.Size = new System.Drawing.Size(484, 261);
            // 
            // lcgCuerpo
            // 
            this.lcgCuerpo.Size = new System.Drawing.Size(484, 261);
            // 
            // lcBase
            // 
            this.lcBase.Controls.Add(this.txtPliego);
            this.lcBase.Controls.Add(this.txtUndEje);
            this.lcBase.Controls.Add(this.txtSiglas);
            this.lcBase.Controls.Add(this.seAnio);
            this.lcBase.Controls.Add(this.txtDescripcion);
            this.lcBase.Controls.Add(this.deFechaEmision);
            this.lcBase.Controls.Add(this.lueMoneda);
            this.lcBase.Controls.Add(this.seTipCam);
            this.lcBase.Size = new System.Drawing.Size(454, 191);
            // 
            // lcgBase
            // 
            this.lcgBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem5,
            this.layoutControlItem4,
            this.layoutControlItem8,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem11,
            this.layoutControlItem13,
            this.emptySpaceItem1});
            this.lcgBase.Size = new System.Drawing.Size(454, 191);
            // 
            // deFechaEmision
            // 
            this.deFechaEmision.EditValue = null;
            this.deFechaEmision.Location = new System.Drawing.Point(315, 36);
            this.deFechaEmision.Name = "deFechaEmision";
            this.deFechaEmision.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaEmision.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaEmision.Size = new System.Drawing.Size(127, 20);
            this.deFechaEmision.StyleController = this.lcBase;
            this.deFechaEmision.TabIndex = 4;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.deFechaEmision;
            this.layoutControlItem1.Location = new System.Drawing.Point(217, 24);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(217, 24);
            this.layoutControlItem1.Text = "Fecha Emisión";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(82, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 144);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(434, 27);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(98, 12);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(344, 20);
            this.txtDescripcion.StyleController = this.lcBase;
            this.txtDescripcion.TabIndex = 7;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtDescripcion;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(434, 24);
            this.layoutControlItem4.Text = "Descripción";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(82, 13);
            // 
            // seAnio
            // 
            this.seAnio.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seAnio.Location = new System.Drawing.Point(98, 36);
            this.seAnio.Name = "seAnio";
            this.seAnio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.seAnio.Properties.DisplayFormat.FormatString = "{0:0000}";
            this.seAnio.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.seAnio.Properties.EditFormat.FormatString = "{0:0000}";
            this.seAnio.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.seAnio.Size = new System.Drawing.Size(127, 20);
            this.seAnio.StyleController = this.lcBase;
            this.seAnio.TabIndex = 9;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.seAnio;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(217, 24);
            this.layoutControlItem5.Text = "Año";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(82, 13);
            // 
            // txtSiglas
            // 
            this.txtSiglas.EditValue = "P. E. C.";
            this.txtSiglas.Location = new System.Drawing.Point(98, 60);
            this.txtSiglas.Name = "txtSiglas";
            this.txtSiglas.Size = new System.Drawing.Size(344, 20);
            this.txtSiglas.StyleController = this.lcBase;
            this.txtSiglas.TabIndex = 13;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.txtSiglas;
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(434, 24);
            this.layoutControlItem8.Text = "Siglas";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(82, 13);
            // 
            // txtUndEje
            // 
            this.txtUndEje.Location = new System.Drawing.Point(98, 84);
            this.txtUndEje.Name = "txtUndEje";
            this.txtUndEje.Size = new System.Drawing.Size(344, 20);
            this.txtUndEje.StyleController = this.lcBase;
            this.txtUndEje.TabIndex = 14;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtUndEje;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(434, 24);
            this.layoutControlItem2.Text = "Unidad Ejecutora";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(82, 13);
            // 
            // txtPliego
            // 
            this.txtPliego.Location = new System.Drawing.Point(98, 108);
            this.txtPliego.Name = "txtPliego";
            this.txtPliego.Size = new System.Drawing.Size(344, 20);
            this.txtPliego.StyleController = this.lcBase;
            this.txtPliego.TabIndex = 15;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtPliego;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 96);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(434, 24);
            this.layoutControlItem3.Text = "Pliego";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(82, 13);
            // 
            // seTipCam
            // 
            this.seTipCam.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.seTipCam.Location = new System.Drawing.Point(315, 132);
            this.seTipCam.Name = "seTipCam";
            this.seTipCam.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.seTipCam.Properties.Mask.EditMask = "n3";
            this.seTipCam.Properties.ReadOnly = true;
            this.seTipCam.Size = new System.Drawing.Size(127, 20);
            this.seTipCam.StyleController = this.lcBase;
            this.seTipCam.TabIndex = 15;
            // 
            // lueMoneda
            // 
            this.lueMoneda.Location = new System.Drawing.Point(98, 132);
            this.lueMoneda.Name = "lueMoneda";
            this.lueMoneda.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueMoneda.Size = new System.Drawing.Size(127, 20);
            this.lueMoneda.StyleController = this.lcBase;
            this.lueMoneda.TabIndex = 5;
            this.lueMoneda.EditValueChanged += new System.EventHandler(this.lueMoneda_EditValueChanged);
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.lueMoneda;
            this.layoutControlItem11.CustomizationFormText = "Unidad";
            this.layoutControlItem11.Location = new System.Drawing.Point(0, 120);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(217, 24);
            this.layoutControlItem11.Text = "Moneda";
            this.layoutControlItem11.TextSize = new System.Drawing.Size(82, 13);
            // 
            // layoutControlItem13
            // 
            this.layoutControlItem13.Control = this.seTipCam;
            this.layoutControlItem13.CustomizationFormText = "T.C.";
            this.layoutControlItem13.Location = new System.Drawing.Point(217, 120);
            this.layoutControlItem13.Name = "layoutControlItem13";
            this.layoutControlItem13.Size = new System.Drawing.Size(217, 24);
            this.layoutControlItem13.Text = "T.C.";
            this.layoutControlItem13.TextSize = new System.Drawing.Size(82, 13);
            // 
            // frmPlanAnualAdquisicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Name = "frmPlanAnualAdquisicion";
            this.Text = "";
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcBase)).EndInit();
            this.lcBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxProveedorValidador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaEmision.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaEmision.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seAnio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSiglas.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUndEje.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPliego.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seTipCam.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMoneda.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.DateEdit deFechaEmision;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.SpinEdit seAnio;
        private DevExpress.XtraEditors.TextEdit txtDescripcion;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.TextEdit txtSiglas;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraEditors.TextEdit txtPliego;
        private DevExpress.XtraEditors.TextEdit txtUndEje;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.LookUpEdit lueMoneda;
        private DevExpress.XtraEditors.SpinEdit seTipCam;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem13;
    }
}