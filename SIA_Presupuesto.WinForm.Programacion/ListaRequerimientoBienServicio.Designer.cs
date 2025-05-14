namespace SIA_Presupuesto.WinForm.Programacion
{
    partial class ListaRequerimientoBienServicio
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
            this.grcProgramacionAnual = new DevExpress.XtraGrid.GridControl();
            this.grvProgramacionAnual = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcArea = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSubdireccion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDireccion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFechaEmision = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPeriodo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFechaAprobacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcMoneda = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcAnio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lueAnio = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcGeneral)).BeginInit();
            this.lcGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgGeneral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcProgramacionAnual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProgramacionAnual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueAnio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // lcGeneral
            // 
            this.lcGeneral.Controls.Add(this.lueAnio);
            this.lcGeneral.Controls.Add(this.grcProgramacionAnual);
            this.lcGeneral.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(744, 305, 450, 400);
            // 
            // lcgGeneral
            // 
            this.lcgGeneral.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.emptySpaceItem1});
            this.lcgGeneral.Name = "Root";
            // 
            // grcProgramacionAnual
            // 
            this.grcProgramacionAnual.Location = new System.Drawing.Point(12, 36);
            this.grcProgramacionAnual.MainView = this.grvProgramacionAnual;
            this.grcProgramacionAnual.Name = "grcProgramacionAnual";
            this.grcProgramacionAnual.Size = new System.Drawing.Size(832, 536);
            this.grcProgramacionAnual.TabIndex = 4;
            this.grcProgramacionAnual.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvProgramacionAnual});
            // 
            // grvProgramacionAnual
            // 
            this.grvProgramacionAnual.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcCodigo,
            this.gcDescripcion,
            this.gcArea,
            this.gcSubdireccion,
            this.gcDireccion,
            this.gcFechaEmision,
            this.gcPeriodo,
            this.gcTotal,
            this.gcFechaAprobacion,
            this.gcMoneda,
            this.gcAnio});
            this.grvProgramacionAnual.GridControl = this.grcProgramacionAnual;
            this.grvProgramacionAnual.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total", null, "(Total = {0:n2})")});
            this.grvProgramacionAnual.Name = "grvProgramacionAnual";
            this.grvProgramacionAnual.OptionsBehavior.Editable = false;
            this.grvProgramacionAnual.OptionsView.ColumnAutoWidth = false;
            this.grvProgramacionAnual.OptionsView.ShowAutoFilterRow = true;
            // 
            // gcCodigo
            // 
            this.gcCodigo.Caption = "Código";
            this.gcCodigo.FieldName = "idReqBieSer";
            this.gcCodigo.Name = "gcCodigo";
            this.gcCodigo.Visible = true;
            this.gcCodigo.VisibleIndex = 0;
            this.gcCodigo.Width = 50;
            // 
            // gcDescripcion
            // 
            this.gcDescripcion.Caption = "Descripción";
            this.gcDescripcion.FieldName = "descripcion";
            this.gcDescripcion.Name = "gcDescripcion";
            this.gcDescripcion.Visible = true;
            this.gcDescripcion.VisibleIndex = 1;
            this.gcDescripcion.Width = 400;
            // 
            // gcArea
            // 
            this.gcArea.Caption = "Area";
            this.gcArea.FieldName = "desArea";
            this.gcArea.Name = "gcArea";
            this.gcArea.Visible = true;
            this.gcArea.VisibleIndex = 2;
            this.gcArea.Width = 150;
            // 
            // gcSubdireccion
            // 
            this.gcSubdireccion.Caption = "Subdirección";
            this.gcSubdireccion.FieldName = "desSubdireccion";
            this.gcSubdireccion.Name = "gcSubdireccion";
            this.gcSubdireccion.Visible = true;
            this.gcSubdireccion.VisibleIndex = 3;
            this.gcSubdireccion.Width = 150;
            // 
            // gcDireccion
            // 
            this.gcDireccion.Caption = "Dirección";
            this.gcDireccion.FieldName = "desDireccion";
            this.gcDireccion.Name = "gcDireccion";
            this.gcDireccion.Visible = true;
            this.gcDireccion.VisibleIndex = 4;
            this.gcDireccion.Width = 150;
            // 
            // gcFechaEmision
            // 
            this.gcFechaEmision.Caption = "Fecha Emisión";
            this.gcFechaEmision.FieldName = "fechaEmision";
            this.gcFechaEmision.Name = "gcFechaEmision";
            this.gcFechaEmision.Visible = true;
            this.gcFechaEmision.VisibleIndex = 5;
            this.gcFechaEmision.Width = 100;
            // 
            // gcPeriodo
            // 
            this.gcPeriodo.Caption = "Periodo";
            this.gcPeriodo.FieldName = "nomMes";
            this.gcPeriodo.Name = "gcPeriodo";
            // 
            // gcTotal
            // 
            this.gcTotal.AppearanceCell.Options.UseTextOptions = true;
            this.gcTotal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gcTotal.Caption = "Total";
            this.gcTotal.DisplayFormat.FormatString = "n2";
            this.gcTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcTotal.FieldName = "total";
            this.gcTotal.Name = "gcTotal";
            this.gcTotal.Visible = true;
            this.gcTotal.VisibleIndex = 6;
            // 
            // gcFechaAprobacion
            // 
            this.gcFechaAprobacion.Caption = "Fecha Aprobación";
            this.gcFechaAprobacion.FieldName = "fechaAprobacion";
            this.gcFechaAprobacion.Name = "gcFechaAprobacion";
            this.gcFechaAprobacion.Width = 100;
            // 
            // gcMoneda
            // 
            this.gcMoneda.Caption = "Moneda";
            this.gcMoneda.FieldName = "moneda";
            this.gcMoneda.Name = "gcMoneda";
            this.gcMoneda.Visible = true;
            this.gcMoneda.VisibleIndex = 7;
            this.gcMoneda.Width = 80;
            // 
            // gcAnio
            // 
            this.gcAnio.Caption = "Año";
            this.gcAnio.FieldName = "anio";
            this.gcAnio.Name = "gcAnio";
            this.gcAnio.Visible = true;
            this.gcAnio.VisibleIndex = 8;
            this.gcAnio.Width = 80;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grcProgramacionAnual;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(836, 540);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // lueAnio
            // 
            this.lueAnio.Location = new System.Drawing.Point(43, 12);
            this.lueAnio.Name = "lueAnio";
            this.lueAnio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueAnio.Size = new System.Drawing.Size(188, 20);
            this.lueAnio.StyleController = this.lcGeneral;
            this.lueAnio.TabIndex = 5;
            this.lueAnio.EditValueChanged += new System.EventHandler(this.lueAnio_EditValueChanged);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.lueAnio;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(223, 24);
            this.layoutControlItem2.Text = "Año";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(19, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(223, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(613, 24);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // ListaRequerimientoBienServicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ListaRequerimientoBienServicio";
            ((System.ComponentModel.ISupportInitialize)(this.lcGeneral)).EndInit();
            this.lcGeneral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgGeneral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcProgramacionAnual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProgramacionAnual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueAnio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grcProgramacionAnual;
        private DevExpress.XtraGrid.Views.Grid.GridView grvProgramacionAnual;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gcCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn gcFechaEmision;
        private DevExpress.XtraGrid.Columns.GridColumn gcFechaAprobacion;
        private DevExpress.XtraGrid.Columns.GridColumn gcMoneda;
        private DevExpress.XtraGrid.Columns.GridColumn gcAnio;
        private DevExpress.XtraGrid.Columns.GridColumn gcDescripcion;
        private DevExpress.XtraEditors.LookUpEdit lueAnio;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gcArea;
        private DevExpress.XtraGrid.Columns.GridColumn gcSubdireccion;
        private DevExpress.XtraGrid.Columns.GridColumn gcDireccion;
        private DevExpress.XtraGrid.Columns.GridColumn gcPeriodo;
        private DevExpress.XtraGrid.Columns.GridColumn gcTotal;
    }
}
