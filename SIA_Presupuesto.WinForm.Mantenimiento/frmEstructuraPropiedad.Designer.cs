namespace SIA_Presupuesto.WinForm.Mantenimiento
{
    partial class frmEstructuraPropiedad
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
            this.grcPropiedad = new DevExpress.XtraGrid.GridControl();
            this.grvPropiedad = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gcCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcConcepto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTipo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcOrigen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTipoValor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcValor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcOrden = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcVisualiza = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.lcPrincipal)).BeginInit();
            this.lcPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgPrincipal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxProveedorValidacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcPropiedad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPropiedad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // lcPrincipal
            // 
            this.lcPrincipal.Controls.Add(this.grcPropiedad);
            this.lcPrincipal.Size = new System.Drawing.Size(894, 587);
            // 
            // lcgPrincipal
            // 
            this.lcgPrincipal.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.lcgPrincipal.Size = new System.Drawing.Size(894, 587);
            // 
            // grcPropiedad
            // 
            this.grcPropiedad.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.grcPropiedad.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.grcPropiedad.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.grcPropiedad.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.grcPropiedad.Location = new System.Drawing.Point(12, 12);
            this.grcPropiedad.MainView = this.grvPropiedad;
            this.grcPropiedad.Name = "grcPropiedad";
            this.grcPropiedad.Size = new System.Drawing.Size(870, 563);
            this.grcPropiedad.TabIndex = 4;
            this.grcPropiedad.UseEmbeddedNavigator = true;
            this.grcPropiedad.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvPropiedad});
            // 
            // grvPropiedad
            // 
            this.grvPropiedad.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcCodigo,
            this.gcConcepto,
            this.gcTipo,
            this.gcOrigen,
            this.gcTipoValor,
            this.gcValor,
            this.gcOrden,
            this.gcVisualiza});
            this.grvPropiedad.GridControl = this.grcPropiedad;
            this.grvPropiedad.Name = "grvPropiedad";
            this.grvPropiedad.OptionsBehavior.ReadOnly = true;
            this.grvPropiedad.OptionsView.ShowAutoFilterRow = true;
            this.grvPropiedad.OptionsView.ShowGroupPanel = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grcPropiedad;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(874, 567);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // gcCodigo
            // 
            this.gcCodigo.Caption = "Código";
            this.gcCodigo.FieldName = "codigo";
            this.gcCodigo.Name = "gcCodigo";
            this.gcCodigo.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcCodigo.Visible = true;
            this.gcCodigo.VisibleIndex = 0;
            this.gcCodigo.Width = 80;
            // 
            // gcConcepto
            // 
            this.gcConcepto.Caption = "Concepto";
            this.gcConcepto.FieldName = "concepto";
            this.gcConcepto.Name = "gcConcepto";
            this.gcConcepto.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcConcepto.Visible = true;
            this.gcConcepto.VisibleIndex = 1;
            this.gcConcepto.Width = 200;
            // 
            // gcTipo
            // 
            this.gcTipo.Caption = "Tipo";
            this.gcTipo.FieldName = "tipo";
            this.gcTipo.Name = "gcTipo";
            this.gcTipo.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcTipo.Visible = true;
            this.gcTipo.VisibleIndex = 2;
            this.gcTipo.Width = 100;
            // 
            // gcOrigen
            // 
            this.gcOrigen.Caption = "Origen";
            this.gcOrigen.FieldName = "origen";
            this.gcOrigen.Name = "gcOrigen";
            this.gcOrigen.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcOrigen.Visible = true;
            this.gcOrigen.VisibleIndex = 3;
            this.gcOrigen.Width = 92;
            // 
            // gcTipoValor
            // 
            this.gcTipoValor.Caption = "Tipo Valor";
            this.gcTipoValor.FieldName = "tipoValor";
            this.gcTipoValor.Name = "gcTipoValor";
            this.gcTipoValor.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcTipoValor.Visible = true;
            this.gcTipoValor.VisibleIndex = 4;
            this.gcTipoValor.Width = 92;
            // 
            // gcValor
            // 
            this.gcValor.Caption = "Valor";
            this.gcValor.FieldName = "valor";
            this.gcValor.Name = "gcValor";
            this.gcValor.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcValor.Visible = true;
            this.gcValor.VisibleIndex = 5;
            this.gcValor.Width = 92;
            // 
            // gcOrden
            // 
            this.gcOrden.Caption = "Orden";
            this.gcOrden.FieldName = "orden";
            this.gcOrden.Name = "gcOrden";
            this.gcOrden.Visible = true;
            this.gcOrden.VisibleIndex = 6;
            this.gcOrden.Width = 92;
            // 
            // gcVisualiza
            // 
            this.gcVisualiza.Caption = "Visualiza";
            this.gcVisualiza.FieldName = "visualiza";
            this.gcVisualiza.Name = "gcVisualiza";
            this.gcVisualiza.Visible = true;
            this.gcVisualiza.VisibleIndex = 7;
            this.gcVisualiza.Width = 104;
            // 
            // frmEstructuraPropiedad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "frmEstructuraPropiedad";
            this.Size = new System.Drawing.Size(894, 587);
            ((System.ComponentModel.ISupportInitialize)(this.lcPrincipal)).EndInit();
            this.lcPrincipal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgPrincipal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxProveedorValidacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcPropiedad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPropiedad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grcPropiedad;
        private DevExpress.XtraGrid.Views.Grid.GridView grvPropiedad;
        private DevExpress.XtraGrid.Columns.GridColumn gcCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn gcConcepto;
        private DevExpress.XtraGrid.Columns.GridColumn gcTipo;
        private DevExpress.XtraGrid.Columns.GridColumn gcOrigen;
        private DevExpress.XtraGrid.Columns.GridColumn gcTipoValor;
        private DevExpress.XtraGrid.Columns.GridColumn gcValor;
        private DevExpress.XtraGrid.Columns.GridColumn gcOrden;
        private DevExpress.XtraGrid.Columns.GridColumn gcVisualiza;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}
