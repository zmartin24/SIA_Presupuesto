namespace SIA_Presupuesto.WinForm.Programacion.Dialogo
{
    partial class frmEvaluacionMensualGeneral
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
            this.txtDescripcion = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.luePresAnu = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lueMesDesde = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lueMesHasta = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.trvPresupuesto = new System.Windows.Forms.TreeView();
            this.lciPresupuesto = new DevExpress.XtraLayout.LayoutControlItem();
            this.seTipoCambio = new DevExpress.XtraEditors.SpinEdit();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.sbAyudaTipoCambio = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lueAnio = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcBase)).BeginInit();
            this.lcBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxProveedorValidador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaEmision.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaEmision.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luePresAnu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMesDesde.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMesHasta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPresupuesto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seTipoCambio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueAnio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            this.SuspendLayout();
            // 
            // lcCuerpo
            // 
            this.lcCuerpo.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(803, 132, 386, 350);
            this.lcCuerpo.Size = new System.Drawing.Size(583, 246);
            // 
            // lcgCuerpo
            // 
            this.lcgCuerpo.Size = new System.Drawing.Size(583, 246);
            // 
            // lcBase
            // 
            this.lcBase.Controls.Add(this.lueAnio);
            this.lcBase.Controls.Add(this.sbAyudaTipoCambio);
            this.lcBase.Controls.Add(this.seTipoCambio);
            this.lcBase.Controls.Add(this.trvPresupuesto);
            this.lcBase.Controls.Add(this.lueMesHasta);
            this.lcBase.Controls.Add(this.lueMesDesde);
            this.lcBase.Controls.Add(this.luePresAnu);
            this.lcBase.Controls.Add(this.txtDescripcion);
            this.lcBase.Controls.Add(this.deFechaEmision);
            this.lcBase.Size = new System.Drawing.Size(553, 176);
            // 
            // lcgBase
            // 
            this.lcgBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem5,
            this.lciPresupuesto,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.layoutControlItem6,
            this.layoutControlItem4});
            this.lcgBase.Size = new System.Drawing.Size(536, 188);
            // 
            // deFechaEmision
            // 
            this.deFechaEmision.EditValue = null;
            this.deFechaEmision.Location = new System.Drawing.Point(151, 132);
            this.deFechaEmision.Name = "deFechaEmision";
            this.deFechaEmision.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaEmision.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaEmision.Size = new System.Drawing.Size(115, 20);
            this.deFechaEmision.StyleController = this.lcBase;
            this.deFechaEmision.TabIndex = 4;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.deFechaEmision;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 120);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(258, 24);
            this.layoutControlItem1.Text = "Fecha Emisión";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(127, 13);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(151, 108);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(373, 20);
            this.txtDescripcion.StyleController = this.lcBase;
            this.txtDescripcion.TabIndex = 7;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtDescripcion;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 96);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(516, 24);
            this.layoutControlItem4.Text = "Descripción";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(127, 13);
            // 
            // luePresAnu
            // 
            this.luePresAnu.Location = new System.Drawing.Point(151, 36);
            this.luePresAnu.Name = "luePresAnu";
            this.luePresAnu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luePresAnu.Properties.PopupWidth = 800;
            this.luePresAnu.Size = new System.Drawing.Size(373, 20);
            this.luePresAnu.StyleController = this.lcBase;
            this.luePresAnu.TabIndex = 10;
            this.luePresAnu.EditValueChanged += new System.EventHandler(this.luePresAnu_EditValueChanged);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.luePresAnu;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(516, 24);
            this.layoutControlItem2.Text = "Presu. Anual";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(127, 13);
            // 
            // lueMesDesde
            // 
            this.lueMesDesde.Location = new System.Drawing.Point(151, 60);
            this.lueMesDesde.Name = "lueMesDesde";
            this.lueMesDesde.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueMesDesde.Properties.ReadOnly = true;
            this.lueMesDesde.Size = new System.Drawing.Size(373, 20);
            this.lueMesDesde.StyleController = this.lcBase;
            this.lueMesDesde.TabIndex = 11;
            this.lueMesDesde.EditValueChanged += new System.EventHandler(this.lueMesDesde_EditValueChanged);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.lueMesDesde;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(516, 24);
            this.layoutControlItem3.Text = "Mes Desde";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(127, 13);
            // 
            // lueMesHasta
            // 
            this.lueMesHasta.Location = new System.Drawing.Point(151, 84);
            this.lueMesHasta.Name = "lueMesHasta";
            this.lueMesHasta.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueMesHasta.Size = new System.Drawing.Size(373, 20);
            this.lueMesHasta.StyleController = this.lcBase;
            this.lueMesHasta.TabIndex = 12;
            this.lueMesHasta.EditValueChanged += new System.EventHandler(this.lueMesHasta_EditValueChanged);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.lueMesHasta;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(516, 24);
            this.layoutControlItem5.Text = "Mes Hasta";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(127, 13);
            // 
            // trvPresupuesto
            // 
            this.trvPresupuesto.CheckBoxes = true;
            this.trvPresupuesto.Location = new System.Drawing.Point(151, 156);
            this.trvPresupuesto.Name = "trvPresupuesto";
            this.trvPresupuesto.Size = new System.Drawing.Size(373, 20);
            this.trvPresupuesto.TabIndex = 13;
            this.trvPresupuesto.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.trvPresupuesto_AfterCheck);
            // 
            // lciPresupuesto
            // 
            this.lciPresupuesto.Control = this.trvPresupuesto;
            this.lciPresupuesto.Location = new System.Drawing.Point(0, 144);
            this.lciPresupuesto.Name = "lciPresupuesto";
            this.lciPresupuesto.Size = new System.Drawing.Size(516, 24);
            this.lciPresupuesto.Text = "Selección de Presupuestos";
            this.lciPresupuesto.TextSize = new System.Drawing.Size(127, 13);
            this.lciPresupuesto.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // seTipoCambio
            // 
            this.seTipoCambio.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seTipoCambio.Location = new System.Drawing.Point(409, 132);
            this.seTipoCambio.Name = "seTipoCambio";
            this.seTipoCambio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.seTipoCambio.Properties.ReadOnly = true;
            this.seTipoCambio.Size = new System.Drawing.Size(90, 20);
            this.seTipoCambio.StyleController = this.lcBase;
            this.seTipoCambio.TabIndex = 14;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.seTipoCambio;
            this.layoutControlItem7.Location = new System.Drawing.Point(258, 120);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(233, 24);
            this.layoutControlItem7.Text = "Tipo de Cambio";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(127, 13);
            // 
            // sbAyudaTipoCambio
            // 
            this.sbAyudaTipoCambio.Location = new System.Drawing.Point(503, 132);
            this.sbAyudaTipoCambio.Name = "sbAyudaTipoCambio";
            this.sbAyudaTipoCambio.Size = new System.Drawing.Size(21, 20);
            this.sbAyudaTipoCambio.StyleController = this.lcBase;
            this.sbAyudaTipoCambio.TabIndex = 15;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.sbAyudaTipoCambio;
            this.layoutControlItem8.Location = new System.Drawing.Point(491, 120);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(25, 24);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // lueAnio
            // 
            this.lueAnio.Location = new System.Drawing.Point(151, 12);
            this.lueAnio.Name = "lueAnio";
            this.lueAnio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueAnio.Size = new System.Drawing.Size(373, 20);
            this.lueAnio.StyleController = this.lcBase;
            this.lueAnio.TabIndex = 16;
            this.lueAnio.EditValueChanged += new System.EventHandler(this.lueAnio_EditValueChanged);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.lueAnio;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(516, 24);
            this.layoutControlItem6.Text = "Año";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(127, 13);
            // 
            // frmEvaluacionMensualGeneral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 246);
            this.Name = "frmEvaluacionMensualGeneral";
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
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luePresAnu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMesDesde.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMesHasta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPresupuesto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seTipoCambio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueAnio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.DateEdit deFechaEmision;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.TextEdit txtDescripcion;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.LookUpEdit luePresAnu;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.LookUpEdit lueMesDesde;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.LookUpEdit lueMesHasta;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private System.Windows.Forms.TreeView trvPresupuesto;
        private DevExpress.XtraLayout.LayoutControlItem lciPresupuesto;
        private DevExpress.XtraEditors.SimpleButton sbAyudaTipoCambio;
        private DevExpress.XtraEditors.SpinEdit seTipoCambio;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraEditors.LookUpEdit lueAnio;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
    }
}