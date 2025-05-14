namespace SIA_Presupuesto.WinForm.Mantenimiento
{
    partial class ListaModalidad
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
            this.grcEjeOperativo = new DevExpress.XtraGrid.GridControl();
            this.grvEjeOperativo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUsuCrea = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFechaCrea = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUsuEdita = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFechaEdita = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcGeneral)).BeginInit();
            this.lcGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgGeneral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcEjeOperativo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEjeOperativo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // lcGeneral
            // 
            this.lcGeneral.Controls.Add(this.grcEjeOperativo);
            // 
            // lcgGeneral
            // 
            this.lcgGeneral.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            // 
            // grcEjeOperativo
            // 
            this.grcEjeOperativo.Location = new System.Drawing.Point(12, 12);
            this.grcEjeOperativo.MainView = this.grvEjeOperativo;
            this.grcEjeOperativo.Name = "grcEjeOperativo";
            this.grcEjeOperativo.Size = new System.Drawing.Size(832, 560);
            this.grcEjeOperativo.TabIndex = 4;
            this.grcEjeOperativo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvEjeOperativo});
            // 
            // grvEjeOperativo
            // 
            this.grvEjeOperativo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcCodigo,
            this.gcDescripcion,
            this.gcUsuCrea,
            this.gcFechaCrea,
            this.gcUsuEdita,
            this.gcFechaEdita});
            this.grvEjeOperativo.GridControl = this.grcEjeOperativo;
            this.grvEjeOperativo.Name = "grvEjeOperativo";
            this.grvEjeOperativo.OptionsBehavior.Editable = false;
            this.grvEjeOperativo.OptionsView.ColumnAutoWidth = false;
            this.grvEjeOperativo.OptionsView.ShowAutoFilterRow = true;
            // 
            // gcCodigo
            // 
            this.gcCodigo.Caption = "Item";
            this.gcCodigo.FieldName = "idEjeOpe";
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
            this.gcDescripcion.Width = 500;
            // 
            // gcUsuCrea
            // 
            this.gcUsuCrea.Caption = "Usuario Crea";
            this.gcUsuCrea.FieldName = "usuCrea";
            this.gcUsuCrea.Name = "gcUsuCrea";
            this.gcUsuCrea.Visible = true;
            this.gcUsuCrea.VisibleIndex = 1;
            this.gcUsuCrea.Width = 100;
            // 
            // gcFechaCrea
            // 
            this.gcFechaCrea.Caption = "Fecha Crea";
            this.gcFechaCrea.DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss";
            this.gcFechaCrea.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcFechaCrea.FieldName = "fechaMod";
            this.gcFechaCrea.Name = "gcFechaCrea";
            this.gcFechaCrea.Visible = true;
            this.gcFechaCrea.VisibleIndex = 2;
            this.gcFechaCrea.Width = 120;
            // 
            // gcUsuEdita
            // 
            this.gcUsuEdita.Caption = "Usuario Edita";
            this.gcUsuEdita.FieldName = "usuMod";
            this.gcUsuEdita.Name = "gcUsuEdita";
            this.gcUsuEdita.Visible = true;
            this.gcUsuEdita.VisibleIndex = 3;
            this.gcUsuEdita.Width = 100;
            // 
            // gcFechaEdita
            // 
            this.gcFechaEdita.Caption = "Fecha Edita";
            this.gcFechaEdita.DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss";
            this.gcFechaEdita.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcFechaEdita.FieldName = "fechaMod";
            this.gcFechaEdita.Name = "gcFechaEdita";
            this.gcFechaEdita.Visible = true;
            this.gcFechaEdita.VisibleIndex = 4;
            this.gcFechaEdita.Width = 120;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grcEjeOperativo;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(836, 564);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // ListaEjeOperativo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ListaEjeOperativo";
            ((System.ComponentModel.ISupportInitialize)(this.lcGeneral)).EndInit();
            this.lcGeneral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgGeneral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcEjeOperativo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEjeOperativo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grcEjeOperativo;
        private DevExpress.XtraGrid.Views.Grid.GridView grvEjeOperativo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gcCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn gcFechaCrea;
        private DevExpress.XtraGrid.Columns.GridColumn gcFechaEdita;
        private DevExpress.XtraGrid.Columns.GridColumn gcDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn gcUsuCrea;
        private DevExpress.XtraGrid.Columns.GridColumn gcUsuEdita;
    }
}
