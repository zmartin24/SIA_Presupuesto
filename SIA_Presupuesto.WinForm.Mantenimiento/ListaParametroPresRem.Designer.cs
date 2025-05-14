namespace SIA_Presupuesto.WinForm.Mantenimiento
{
    partial class ListaParametroPresRem
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
            this.grcParametro = new DevExpress.XtraGrid.GridControl();
            this.grvParametro = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcConcepto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcMonto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcGeneral)).BeginInit();
            this.lcGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgGeneral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcParametro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvParametro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // lcGeneral
            // 
            this.lcGeneral.Controls.Add(this.grcParametro);
            // 
            // lcgGeneral
            // 
            this.lcgGeneral.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            // 
            // grcParametro
            // 
            this.grcParametro.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.grcParametro.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.grcParametro.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.grcParametro.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.grcParametro.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.grcParametro.Location = new System.Drawing.Point(12, 12);
            this.grcParametro.MainView = this.grvParametro;
            this.grcParametro.Name = "grcParametro";
            this.grcParametro.Size = new System.Drawing.Size(832, 560);
            this.grcParametro.TabIndex = 4;
            this.grcParametro.UseEmbeddedNavigator = true;
            this.grcParametro.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvParametro});
            // 
            // grvParametro
            // 
            this.grvParametro.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcCodigo,
            this.gcDescripcion,
            this.gcConcepto,
            this.gcMonto});
            this.grvParametro.GridControl = this.grcParametro;
            this.grvParametro.Name = "grvParametro";
            this.grvParametro.OptionsBehavior.Editable = false;
            this.grvParametro.OptionsView.ShowAutoFilterRow = true;
            this.grvParametro.OptionsView.ShowGroupPanel = false;
            // 
            // gcCodigo
            // 
            this.gcCodigo.Caption = "Código";
            this.gcCodigo.FieldName = "idConPreRem";
            this.gcCodigo.Name = "gcCodigo";
            this.gcCodigo.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.BeginsWith;
            this.gcCodigo.Visible = true;
            this.gcCodigo.VisibleIndex = 0;
            this.gcCodigo.Width = 100;
            // 
            // gcDescripcion
            // 
            this.gcDescripcion.Caption = "Código Concepto";
            this.gcDescripcion.FieldName = "codigo";
            this.gcDescripcion.Name = "gcDescripcion";
            this.gcDescripcion.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcDescripcion.Visible = true;
            this.gcDescripcion.VisibleIndex = 1;
            this.gcDescripcion.Width = 150;
            // 
            // gcConcepto
            // 
            this.gcConcepto.Caption = "Concepto";
            this.gcConcepto.FieldName = "concepto";
            this.gcConcepto.Name = "gcConcepto";
            this.gcConcepto.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcConcepto.Visible = true;
            this.gcConcepto.VisibleIndex = 2;
            this.gcConcepto.Width = 280;
            // 
            // gcMonto
            // 
            this.gcMonto.Caption = "Monto";
            this.gcMonto.FieldName = "importe";
            this.gcMonto.Name = "gcMonto";
            this.gcMonto.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.BeginsWith;
            this.gcMonto.Visible = true;
            this.gcMonto.VisibleIndex = 3;
            this.gcMonto.Width = 284;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grcParametro;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(836, 564);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // ListaParametroPresRem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ListaParametroPresRem";
            ((System.ComponentModel.ISupportInitialize)(this.lcGeneral)).EndInit();
            this.lcGeneral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgGeneral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcParametro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvParametro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grcParametro;
        private DevExpress.XtraGrid.Views.Grid.GridView grvParametro;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gcCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn gcDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn gcConcepto;
        private DevExpress.XtraGrid.Columns.GridColumn gcMonto;
    }
}
