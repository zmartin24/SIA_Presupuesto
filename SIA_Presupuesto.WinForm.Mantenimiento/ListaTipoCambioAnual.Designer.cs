namespace SIA_Presupuesto.WinForm.Mantenimiento
{
    partial class ListaTipoCambioAnual
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
            this.grcTipoCambioAnual = new DevExpress.XtraGrid.GridControl();
            this.grvTipoCambioAnual = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcAnio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcValor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUsuCrea = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFechaCrea = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUsuEdita = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFechaEdita = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcGeneral)).BeginInit();
            this.lcGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgGeneral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcTipoCambioAnual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTipoCambioAnual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // lcGeneral
            // 
            this.lcGeneral.Controls.Add(this.grcTipoCambioAnual);
            // 
            // lcgGeneral
            // 
            this.lcgGeneral.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            // 
            // grcTipoCambioAnual
            // 
            this.grcTipoCambioAnual.Location = new System.Drawing.Point(12, 12);
            this.grcTipoCambioAnual.MainView = this.grvTipoCambioAnual;
            this.grcTipoCambioAnual.Name = "grcTipoCambioAnual";
            this.grcTipoCambioAnual.Size = new System.Drawing.Size(832, 560);
            this.grcTipoCambioAnual.TabIndex = 4;
            this.grcTipoCambioAnual.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvTipoCambioAnual});
            // 
            // grvTipoCambioAnual
            // 
            this.grvTipoCambioAnual.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcCodigo,
            this.gcAnio,
            this.gcValor,
            this.gcUsuCrea,
            this.gcFechaCrea,
            this.gcUsuEdita,
            this.gcFechaEdita});
            this.grvTipoCambioAnual.GridControl = this.grcTipoCambioAnual;
            this.grvTipoCambioAnual.Name = "grvTipoCambioAnual";
            this.grvTipoCambioAnual.OptionsBehavior.Editable = false;
            this.grvTipoCambioAnual.OptionsView.ColumnAutoWidth = false;
            this.grvTipoCambioAnual.OptionsView.EnableAppearanceEvenRow = true;
            this.grvTipoCambioAnual.OptionsView.RowAutoHeight = true;
            this.grvTipoCambioAnual.OptionsView.ShowAutoFilterRow = true;
            this.grvTipoCambioAnual.OptionsView.ShowFooter = true;
            // 
            // gcCodigo
            // 
            this.gcCodigo.Caption = "Item";
            this.gcCodigo.FieldName = "idTipCamPres";
            this.gcCodigo.Name = "gcCodigo";
            this.gcCodigo.Width = 50;
            // 
            // gcAnio
            // 
            this.gcAnio.Caption = "Anio";
            this.gcAnio.FieldName = "anio";
            this.gcAnio.Name = "gcAnio";
            this.gcAnio.Visible = true;
            this.gcAnio.VisibleIndex = 0;
            this.gcAnio.Width = 60;
            // 
            // gcValor
            // 
            this.gcValor.AppearanceCell.Options.UseTextOptions = true;
            this.gcValor.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gcValor.Caption = "Valor";
            this.gcValor.DisplayFormat.FormatString = "n3";
            this.gcValor.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcValor.FieldName = "valor";
            this.gcValor.Name = "gcValor";
            this.gcValor.Visible = true;
            this.gcValor.VisibleIndex = 1;
            this.gcValor.Width = 100;
            // 
            // gcUsuCrea
            // 
            this.gcUsuCrea.Caption = "Usuario Crea";
            this.gcUsuCrea.FieldName = "usuCrea";
            this.gcUsuCrea.Name = "gcUsuCrea";
            this.gcUsuCrea.Visible = true;
            this.gcUsuCrea.VisibleIndex = 2;
            this.gcUsuCrea.Width = 100;
            // 
            // gcFechaCrea
            // 
            this.gcFechaCrea.Caption = "Fecha Crea";
            this.gcFechaCrea.DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss";
            this.gcFechaCrea.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcFechaCrea.FieldName = "fechaCrea";
            this.gcFechaCrea.Name = "gcFechaCrea";
            this.gcFechaCrea.Visible = true;
            this.gcFechaCrea.VisibleIndex = 3;
            this.gcFechaCrea.Width = 120;
            // 
            // gcUsuEdita
            // 
            this.gcUsuEdita.Caption = "Usuario Edita";
            this.gcUsuEdita.FieldName = "usuEdita";
            this.gcUsuEdita.Name = "gcUsuEdita";
            this.gcUsuEdita.Visible = true;
            this.gcUsuEdita.VisibleIndex = 4;
            this.gcUsuEdita.Width = 100;
            // 
            // gcFechaEdita
            // 
            this.gcFechaEdita.Caption = "Fecha Edita";
            this.gcFechaEdita.DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss";
            this.gcFechaEdita.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcFechaEdita.FieldName = "fechaEdita";
            this.gcFechaEdita.Name = "gcFechaEdita";
            this.gcFechaEdita.Visible = true;
            this.gcFechaEdita.VisibleIndex = 5;
            this.gcFechaEdita.Width = 120;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grcTipoCambioAnual;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(836, 564);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // ListaTipoCambioAnual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ListaTipoCambioAnual";
            ((System.ComponentModel.ISupportInitialize)(this.lcGeneral)).EndInit();
            this.lcGeneral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgGeneral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcTipoCambioAnual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTipoCambioAnual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grcTipoCambioAnual;
        private DevExpress.XtraGrid.Views.Grid.GridView grvTipoCambioAnual;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gcCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn gcFechaCrea;
        private DevExpress.XtraGrid.Columns.GridColumn gcFechaEdita;
        private DevExpress.XtraGrid.Columns.GridColumn gcValor;
        private DevExpress.XtraGrid.Columns.GridColumn gcAnio;
        private DevExpress.XtraGrid.Columns.GridColumn gcUsuCrea;
        private DevExpress.XtraGrid.Columns.GridColumn gcUsuEdita;
    }
}
