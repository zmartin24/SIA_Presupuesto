namespace SIA_Presupuesto.WinForm.Adquisicion
{
    partial class ListaCatGastosRecurrentes
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
            this.grcCatGastoRecurrente = new DevExpress.XtraGrid.GridControl();
            this.grvGastoRecurrente = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcGeneral)).BeginInit();
            this.lcGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgGeneral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcCatGastoRecurrente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvGastoRecurrente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // lcGeneral
            // 
            this.lcGeneral.Controls.Add(this.grcCatGastoRecurrente);
            // 
            // lcgGeneral
            // 
            this.lcgGeneral.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            // 
            // grcCatGastoRecurrente
            // 
            this.grcCatGastoRecurrente.Location = new System.Drawing.Point(12, 12);
            this.grcCatGastoRecurrente.MainView = this.grvGastoRecurrente;
            this.grcCatGastoRecurrente.Name = "grcCatGastoRecurrente";
            this.grcCatGastoRecurrente.Size = new System.Drawing.Size(832, 560);
            this.grcCatGastoRecurrente.TabIndex = 5;
            this.grcCatGastoRecurrente.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvGastoRecurrente});
            // 
            // grvGastoRecurrente
            // 
            this.grvGastoRecurrente.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcCodigo,
            this.gcDescripcion,
            this.gridColumn1,
            this.gridColumn2});
            this.grvGastoRecurrente.GridControl = this.grcCatGastoRecurrente;
            this.grvGastoRecurrente.Name = "grvGastoRecurrente";
            this.grvGastoRecurrente.OptionsBehavior.Editable = false;
            this.grvGastoRecurrente.OptionsView.ColumnAutoWidth = false;
            this.grvGastoRecurrente.OptionsView.ShowAutoFilterRow = true;
            // 
            // gcCodigo
            // 
            this.gcCodigo.Caption = "Id";
            this.gcCodigo.FieldName = "idRubBieSer";
            this.gcCodigo.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.gcCodigo.Name = "gcCodigo";
            this.gcCodigo.Width = 50;
            // 
            // gcDescripcion
            // 
            this.gcDescripcion.Caption = "Descripción";
            this.gcDescripcion.FieldName = "descripcion";
            this.gcDescripcion.Name = "gcDescripcion";
            this.gcDescripcion.Visible = true;
            this.gcDescripcion.VisibleIndex = 0;
            this.gcDescripcion.Width = 693;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Usuario Crea";
            this.gridColumn1.FieldName = "usuCrea";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 128;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Fecha Crea";
            this.gridColumn2.FieldName = "fechaCrea";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 113;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grcCatGastoRecurrente;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(836, 564);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // ListaCatGastosRecurrentes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ListaCatGastosRecurrentes";
            ((System.ComponentModel.ISupportInitialize)(this.lcGeneral)).EndInit();
            this.lcGeneral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgGeneral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcCatGastoRecurrente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvGastoRecurrente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grcCatGastoRecurrente;
        private DevExpress.XtraGrid.Views.Grid.GridView grvGastoRecurrente;
        private DevExpress.XtraGrid.Columns.GridColumn gcCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn gcDescripcion;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
    }
}