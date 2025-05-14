namespace SIA_Presupuesto.WinForm.Mantenimiento
{
    partial class ListaEstructuraPresRem
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
            this.grcEstructura = new DevExpress.XtraGrid.GridControl();
            this.grvEstructura = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gcCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.lcGeneral)).BeginInit();
            this.lcGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgGeneral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcEstructura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEstructura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // lcGeneral
            // 
            this.lcGeneral.Controls.Add(this.grcEstructura);
            // 
            // lcgGeneral
            // 
            this.lcgGeneral.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            // 
            // grcEstructura
            // 
            this.grcEstructura.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.grcEstructura.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.grcEstructura.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.grcEstructura.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.grcEstructura.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.grcEstructura.Location = new System.Drawing.Point(12, 12);
            this.grcEstructura.MainView = this.grvEstructura;
            this.grcEstructura.Name = "grcEstructura";
            this.grcEstructura.Size = new System.Drawing.Size(832, 560);
            this.grcEstructura.TabIndex = 4;
            this.grcEstructura.UseEmbeddedNavigator = true;
            this.grcEstructura.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvEstructura});
            // 
            // grvEstructura
            // 
            this.grvEstructura.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcCodigo,
            this.gcDescripcion});
            this.grvEstructura.GridControl = this.grcEstructura;
            this.grvEstructura.Name = "grvEstructura";
            this.grvEstructura.OptionsBehavior.Editable = false;
            this.grvEstructura.OptionsView.ShowAutoFilterRow = true;
            this.grvEstructura.OptionsView.ShowGroupPanel = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grcEstructura;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(836, 564);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // gcCodigo
            // 
            this.gcCodigo.Caption = "Código";
            this.gcCodigo.FieldName = "idEstPreRem";
            this.gcCodigo.Name = "gcCodigo";
            this.gcCodigo.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcCodigo.Visible = true;
            this.gcCodigo.VisibleIndex = 0;
            this.gcCodigo.Width = 120;
            // 
            // gcDescripcion
            // 
            this.gcDescripcion.Caption = "Descripción";
            this.gcDescripcion.FieldName = "descripcion";
            this.gcDescripcion.Name = "gcDescripcion";
            this.gcDescripcion.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcDescripcion.Visible = true;
            this.gcDescripcion.VisibleIndex = 1;
            this.gcDescripcion.Width = 694;
            // 
            // ListaEstructuraPresRem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ListaEstructuraPresRem";
            ((System.ComponentModel.ISupportInitialize)(this.lcGeneral)).EndInit();
            this.lcGeneral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgGeneral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcEstructura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEstructura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grcEstructura;
        private DevExpress.XtraGrid.Views.Grid.GridView grvEstructura;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gcCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn gcDescripcion;
    }
}
