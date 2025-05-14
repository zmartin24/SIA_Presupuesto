namespace SIA_Presupuesto.WinForm.Adquisicion.Dialogo
{
    partial class frmCertificacionMaster
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
            this.lueTipo = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtObservacion = new DevExpress.XtraEditors.MemoEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtReq = new DevExpress.XtraEditors.TextEdit();
            this.lciForebise = new DevExpress.XtraLayout.LayoutControlItem();
            this.sbReq = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.chkEsTotalDetallado = new DevExpress.XtraEditors.CheckEdit();
            this.lciChekTotalDetallado = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcBase)).BeginInit();
            this.lcBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxProveedorValidador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTipo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtObservacion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReq.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciForebise)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEsTotalDetallado.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciChekTotalDetallado)).BeginInit();
            this.SuspendLayout();
            // 
            // lcCuerpo
            // 
            this.lcCuerpo.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(803, 132, 386, 350);
            this.lcCuerpo.Size = new System.Drawing.Size(634, 350);
            // 
            // lcgCuerpo
            // 
            this.lcgCuerpo.Size = new System.Drawing.Size(634, 350);
            // 
            // lcBase
            // 
            this.lcBase.Controls.Add(this.chkEsTotalDetallado);
            this.lcBase.Controls.Add(this.sbReq);
            this.lcBase.Controls.Add(this.txtReq);
            this.lcBase.Controls.Add(this.txtObservacion);
            this.lcBase.Controls.Add(this.lueTipo);
            this.lcBase.Size = new System.Drawing.Size(604, 280);
            // 
            // lcgBase
            // 
            this.lcgBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem11,
            this.layoutControlItem2,
            this.lciForebise,
            this.layoutControlItem5,
            this.lciChekTotalDetallado});
            this.lcgBase.Name = "Root";
            this.lcgBase.Size = new System.Drawing.Size(604, 280);
            // 
            // lueTipo
            // 
            this.lueTipo.Location = new System.Drawing.Point(113, 12);
            this.lueTipo.Name = "lueTipo";
            this.lueTipo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueTipo.Size = new System.Drawing.Size(479, 20);
            this.lueTipo.StyleController = this.lcBase;
            this.lueTipo.TabIndex = 5;
            this.lueTipo.EditValueChanged += new System.EventHandler(this.lueTipo_EditValueChanged);
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.lueTipo;
            this.layoutControlItem11.CustomizationFormText = "Unidad";
            this.layoutControlItem11.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(584, 24);
            this.layoutControlItem11.Text = "Tipo";
            this.layoutControlItem11.TextSize = new System.Drawing.Size(97, 13);
            // 
            // txtObservacion
            // 
            this.txtObservacion.Location = new System.Drawing.Point(113, 85);
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtObservacion.Properties.MaxLength = 500;
            this.txtObservacion.Size = new System.Drawing.Size(479, 183);
            this.txtObservacion.StyleController = this.lcBase;
            this.txtObservacion.TabIndex = 8;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtObservacion;
            this.layoutControlItem2.CustomizationFormText = "Proyecto / Actividad";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 73);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(584, 187);
            this.layoutControlItem2.Text = "Proyecto / Actividad";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(97, 13);
            // 
            // txtReq
            // 
            this.txtReq.Location = new System.Drawing.Point(113, 36);
            this.txtReq.Name = "txtReq";
            this.txtReq.Properties.ReadOnly = true;
            this.txtReq.Size = new System.Drawing.Size(441, 20);
            this.txtReq.StyleController = this.lcBase;
            this.txtReq.TabIndex = 16;
            // 
            // lciForebise
            // 
            this.lciForebise.Control = this.txtReq;
            this.lciForebise.Location = new System.Drawing.Point(0, 24);
            this.lciForebise.Name = "lciForebise";
            this.lciForebise.Size = new System.Drawing.Size(546, 26);
            this.lciForebise.Text = "Requerimiento";
            this.lciForebise.TextSize = new System.Drawing.Size(97, 13);
            // 
            // sbReq
            // 
            this.sbReq.Location = new System.Drawing.Point(558, 36);
            this.sbReq.Name = "sbReq";
            this.sbReq.Size = new System.Drawing.Size(34, 22);
            this.sbReq.StyleController = this.lcBase;
            this.sbReq.TabIndex = 17;
            this.sbReq.Text = "...";
            this.sbReq.Click += new System.EventHandler(this.sbReq_Click);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.sbReq;
            this.layoutControlItem5.Location = new System.Drawing.Point(546, 24);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(38, 26);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // chkEsTotalDetallado
            // 
            this.chkEsTotalDetallado.EditValue = true;
            this.chkEsTotalDetallado.Location = new System.Drawing.Point(12, 62);
            this.chkEsTotalDetallado.Name = "chkEsTotalDetallado";
            this.chkEsTotalDetallado.Properties.Caption = "Total Detallado";
            this.chkEsTotalDetallado.Size = new System.Drawing.Size(580, 19);
            this.chkEsTotalDetallado.StyleController = this.lcBase;
            this.chkEsTotalDetallado.TabIndex = 18;
            // 
            // lciChekTotalDetallado
            // 
            this.lciChekTotalDetallado.Control = this.chkEsTotalDetallado;
            this.lciChekTotalDetallado.Location = new System.Drawing.Point(0, 50);
            this.lciChekTotalDetallado.Name = "lciChekTotalDetallado";
            this.lciChekTotalDetallado.Size = new System.Drawing.Size(584, 23);
            this.lciChekTotalDetallado.TextSize = new System.Drawing.Size(0, 0);
            this.lciChekTotalDetallado.TextVisible = false;
            // 
            // frmCertificacionMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 350);
            this.Name = "frmCertificacionMaster";
            this.Text = "";
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcBase)).EndInit();
            this.lcBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxProveedorValidador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTipo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtObservacion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReq.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciForebise)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEsTotalDetallado.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciChekTotalDetallado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.LookUpEdit lueTipo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraEditors.MemoEdit txtObservacion;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.SimpleButton sbReq;
        private DevExpress.XtraEditors.TextEdit txtReq;
        private DevExpress.XtraLayout.LayoutControlItem lciForebise;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.CheckEdit chkEsTotalDetallado;
        private DevExpress.XtraLayout.LayoutControlItem lciChekTotalDetallado;
    }
}