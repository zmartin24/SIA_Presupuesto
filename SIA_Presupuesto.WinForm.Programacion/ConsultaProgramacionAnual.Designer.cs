namespace SIA_Presupuesto.WinForm.Programacion
{
    partial class ConsultaProgramacionAnual
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
            this.gcFechaEmision = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFechaAprobacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFechaLiqui = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcMoneda = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcAnio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gcGrupoPresupuesto = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.lcGeneral)).BeginInit();
            this.lcGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgGeneral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcProgramacionAnual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProgramacionAnual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // lcGeneral
            // 
            this.lcGeneral.Controls.Add(this.grcProgramacionAnual);
            // 
            // lcgGeneral
            // 
            this.lcgGeneral.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            // 
            // grcProgramacionAnual
            // 
            this.grcProgramacionAnual.Location = new System.Drawing.Point(12, 12);
            this.grcProgramacionAnual.MainView = this.grvProgramacionAnual;
            this.grcProgramacionAnual.Name = "grcProgramacionAnual";
            this.grcProgramacionAnual.Size = new System.Drawing.Size(832, 560);
            this.grcProgramacionAnual.TabIndex = 4;
            this.grcProgramacionAnual.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvProgramacionAnual});
            // 
            // grvProgramacionAnual
            // 
            this.grvProgramacionAnual.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcCodigo,
            this.gcGrupoPresupuesto,
            this.gcDescripcion,
            this.gcFechaEmision,
            this.gcFechaAprobacion,
            this.gcFechaLiqui,
            this.gcMoneda,
            this.gcAnio});
            this.grvProgramacionAnual.GridControl = this.grcProgramacionAnual;
            this.grvProgramacionAnual.Name = "grvProgramacionAnual";
            this.grvProgramacionAnual.OptionsBehavior.Editable = false;
            this.grvProgramacionAnual.OptionsView.ColumnAutoWidth = false;
            this.grvProgramacionAnual.OptionsView.ShowAutoFilterRow = true;
            // 
            // gcCodigo
            // 
            this.gcCodigo.Caption = "Código";
            this.gcCodigo.FieldName = "idProAnu";
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
            this.gcDescripcion.VisibleIndex = 2;
            this.gcDescripcion.Width = 600;
            // 
            // gcFechaEmision
            // 
            this.gcFechaEmision.Caption = "Fecha Emisión";
            this.gcFechaEmision.FieldName = "fechaEmision";
            this.gcFechaEmision.Name = "gcFechaEmision";
            this.gcFechaEmision.Visible = true;
            this.gcFechaEmision.VisibleIndex = 3;
            this.gcFechaEmision.Width = 100;
            // 
            // gcFechaAprobacion
            // 
            this.gcFechaAprobacion.Caption = "Fecha Aprobación";
            this.gcFechaAprobacion.FieldName = "fechaAprobacion";
            this.gcFechaAprobacion.Name = "gcFechaAprobacion";
            this.gcFechaAprobacion.Visible = true;
            this.gcFechaAprobacion.VisibleIndex = 4;
            this.gcFechaAprobacion.Width = 100;
            // 
            // gcFechaLiqui
            // 
            this.gcFechaLiqui.Caption = "Fecha Liqui.";
            this.gcFechaLiqui.FieldName = "fechaLiquidacion";
            this.gcFechaLiqui.Name = "gcFechaLiqui";
            this.gcFechaLiqui.Visible = true;
            this.gcFechaLiqui.VisibleIndex = 5;
            this.gcFechaLiqui.Width = 100;
            // 
            // gcMoneda
            // 
            this.gcMoneda.Caption = "Moneda";
            this.gcMoneda.FieldName = "moneda";
            this.gcMoneda.Name = "gcMoneda";
            this.gcMoneda.Visible = true;
            this.gcMoneda.VisibleIndex = 6;
            this.gcMoneda.Width = 80;
            // 
            // gcAnio
            // 
            this.gcAnio.Caption = "Año";
            this.gcAnio.FieldName = "anio";
            this.gcAnio.Name = "gcAnio";
            this.gcAnio.Visible = true;
            this.gcAnio.VisibleIndex = 7;
            this.gcAnio.Width = 80;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grcProgramacionAnual;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(836, 564);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // gcGrupoPresupuesto
            // 
            this.gcGrupoPresupuesto.Caption = "Grupo Presupuesto";
            this.gcGrupoPresupuesto.FieldName = "grupo";
            this.gcGrupoPresupuesto.Name = "gcGrupoPresupuesto";
            this.gcGrupoPresupuesto.Visible = true;
            this.gcGrupoPresupuesto.VisibleIndex = 1;
            this.gcGrupoPresupuesto.Width = 300;
            // 
            // ConsultaProgramacionAnual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ConsultaProgramacionAnual";
            ((System.ComponentModel.ISupportInitialize)(this.lcGeneral)).EndInit();
            this.lcGeneral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgGeneral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcProgramacionAnual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProgramacionAnual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grcProgramacionAnual;
        private DevExpress.XtraGrid.Views.Grid.GridView grvProgramacionAnual;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gcCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn gcFechaEmision;
        private DevExpress.XtraGrid.Columns.GridColumn gcFechaAprobacion;
        private DevExpress.XtraGrid.Columns.GridColumn gcFechaLiqui;
        private DevExpress.XtraGrid.Columns.GridColumn gcMoneda;
        private DevExpress.XtraGrid.Columns.GridColumn gcAnio;
        private DevExpress.XtraGrid.Columns.GridColumn gcDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn gcGrupoPresupuesto;
    }
}
