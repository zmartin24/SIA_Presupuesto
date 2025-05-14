namespace SIA_Presupuesto.WinForm.General.Ayuda
{
    partial class frmAyudaFore
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
            this.grcReq = new DevExpress.XtraGrid.GridControl();
            this.grvReq = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcNumero = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcJustificacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.obgsSeleccion = new SIA_Presupuesto.WinForm.General.ControlesDiversos.OpcionesBarraGridSeleccion();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gbCuerpo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).BeginInit();
            this.lcCuerpo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcReq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvReq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // gbCuerpo
            // 
            this.gbCuerpo.Size = new System.Drawing.Size(607, 305);
            // 
            // lcCuerpo
            // 
            this.lcCuerpo.Controls.Add(this.obgsSeleccion);
            this.lcCuerpo.Controls.Add(this.grcReq);
            this.lcCuerpo.Size = new System.Drawing.Size(601, 285);
            // 
            // lcgCuerpo
            // 
            this.lcgCuerpo.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.lcgCuerpo.Size = new System.Drawing.Size(601, 285);
            // 
            // grcReq
            // 
            this.grcReq.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.grcReq.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.grcReq.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.grcReq.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.grcReq.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.grcReq.Location = new System.Drawing.Point(12, 47);
            this.grcReq.MainView = this.grvReq;
            this.grcReq.Name = "grcReq";
            this.grcReq.Size = new System.Drawing.Size(577, 226);
            this.grcReq.TabIndex = 4;
            this.grcReq.UseEmbeddedNavigator = true;
            this.grcReq.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvReq});
            // 
            // grvReq
            // 
            this.grvReq.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcCodigo,
            this.gcNumero,
            this.gcJustificacion});
            this.grvReq.GridControl = this.grcReq;
            this.grvReq.Name = "grvReq";
            this.grvReq.OptionsBehavior.Editable = false;
            this.grvReq.OptionsView.ColumnAutoWidth = false;
            this.grvReq.OptionsView.ShowAutoFilterRow = true;
            this.grvReq.OptionsView.ShowGroupPanel = false;
            // 
            // gcCodigo
            // 
            this.gcCodigo.Caption = "Codigo";
            this.gcCodigo.Name = "gcCodigo";
            this.gcCodigo.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Like;
            this.gcCodigo.Visible = true;
            this.gcCodigo.VisibleIndex = 0;
            this.gcCodigo.Width = 80;
            // 
            // gcNumero
            // 
            this.gcNumero.Caption = "Número";
            this.gcNumero.FieldName = "numero";
            this.gcNumero.Name = "gcNumero";
            this.gcNumero.Visible = true;
            this.gcNumero.VisibleIndex = 1;
            this.gcNumero.Width = 100;
            // 
            // gcJustificacion
            // 
            this.gcJustificacion.Caption = "Justificación";
            this.gcJustificacion.FieldName = "justificacion";
            this.gcJustificacion.Name = "gcJustificacion";
            this.gcJustificacion.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcJustificacion.Visible = true;
            this.gcJustificacion.VisibleIndex = 2;
            this.gcJustificacion.Width = 459;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grcReq;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 35);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(581, 230);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // obgsSeleccion
            // 
            this.obgsSeleccion.Location = new System.Drawing.Point(12, 12);
            this.obgsSeleccion.Name = "obgsSeleccion";
            this.obgsSeleccion.Size = new System.Drawing.Size(577, 31);
            this.obgsSeleccion.TabIndex = 5;
            this.obgsSeleccion.SeleccionarRegistro += new System.EventHandler(this.obgsSeleccion_SeleccionarRegistro);
            this.obgsSeleccion.SiguienteRegistro += new System.EventHandler(this.obgsSeleccion_SiguienteRegistro);
            this.obgsSeleccion.AnteriorRegistro += new System.EventHandler(this.obgsSeleccion_AnteriorRegistro);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.obgsSeleccion;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(581, 35);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // frmAyudaFore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 355);
            this.Name = "frmAyudaFore";
            this.Text = "frmAyudaForebi";
            this.gbCuerpo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).EndInit();
            this.lcCuerpo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcReq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvReq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grcReq;
        private DevExpress.XtraGrid.Views.Grid.GridView grvReq;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gcJustificacion;
        private ControlesDiversos.OpcionesBarraGridSeleccion obgsSeleccion;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.Columns.GridColumn gcCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn gcNumero;
    }
}