namespace SIA_Presupuesto.WinForm.Adquisicion
{
    partial class ListaPlanAnualAdquisicion
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
            this.grcPlanAnualAdquisicion = new DevExpress.XtraGrid.GridControl();
            this.grvPlanAnualAdquisicion = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFechaEmision = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFechaAprobacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcAnio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcGeneral)).BeginInit();
            this.lcGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgGeneral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcPlanAnualAdquisicion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPlanAnualAdquisicion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // lcGeneral
            // 
            this.lcGeneral.Controls.Add(this.grcPlanAnualAdquisicion);
            // 
            // lcgGeneral
            // 
            this.lcgGeneral.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            // 
            // grcPlanAnualAdquisicion
            // 
            this.grcPlanAnualAdquisicion.Location = new System.Drawing.Point(12, 12);
            this.grcPlanAnualAdquisicion.MainView = this.grvPlanAnualAdquisicion;
            this.grcPlanAnualAdquisicion.Name = "grcPlanAnualAdquisicion";
            this.grcPlanAnualAdquisicion.Size = new System.Drawing.Size(832, 560);
            this.grcPlanAnualAdquisicion.TabIndex = 4;
            this.grcPlanAnualAdquisicion.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvPlanAnualAdquisicion});
            // 
            // grvPlanAnualAdquisicion
            // 
            this.grvPlanAnualAdquisicion.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcCodigo,
            this.gcDescripcion,
            this.gcFechaEmision,
            this.gcFechaAprobacion,
            this.gcAnio});
            this.grvPlanAnualAdquisicion.GridControl = this.grcPlanAnualAdquisicion;
            this.grvPlanAnualAdquisicion.Name = "grvPlanAnualAdquisicion";
            this.grvPlanAnualAdquisicion.OptionsBehavior.Editable = false;
            this.grvPlanAnualAdquisicion.OptionsView.ColumnAutoWidth = false;
            this.grvPlanAnualAdquisicion.OptionsView.ShowAutoFilterRow = true;
            // 
            // gcCodigo
            // 
            this.gcCodigo.Caption = "Código";
            this.gcCodigo.FieldName = "idPaa";
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
            this.gcDescripcion.Width = 800;
            // 
            // gcFechaEmision
            // 
            this.gcFechaEmision.Caption = "Fecha Emisión";
            this.gcFechaEmision.FieldName = "fechaEmision";
            this.gcFechaEmision.Name = "gcFechaEmision";
            this.gcFechaEmision.Visible = true;
            this.gcFechaEmision.VisibleIndex = 2;
            this.gcFechaEmision.Width = 100;
            // 
            // gcFechaAprobacion
            // 
            this.gcFechaAprobacion.Caption = "Fecha Aprobación";
            this.gcFechaAprobacion.FieldName = "fechaAprobacion";
            this.gcFechaAprobacion.Name = "gcFechaAprobacion";
            this.gcFechaAprobacion.Visible = true;
            this.gcFechaAprobacion.VisibleIndex = 3;
            this.gcFechaAprobacion.Width = 100;
            // 
            // gcAnio
            // 
            this.gcAnio.Caption = "Año";
            this.gcAnio.FieldName = "anio";
            this.gcAnio.Name = "gcAnio";
            this.gcAnio.Visible = true;
            this.gcAnio.VisibleIndex = 4;
            this.gcAnio.Width = 80;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grcPlanAnualAdquisicion;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(836, 564);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // ListaPlanAnualAdquisicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ListaPlanAnualAdquisicion";
            ((System.ComponentModel.ISupportInitialize)(this.lcGeneral)).EndInit();
            this.lcGeneral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgGeneral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcPlanAnualAdquisicion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPlanAnualAdquisicion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grcPlanAnualAdquisicion;
        private DevExpress.XtraGrid.Views.Grid.GridView grvPlanAnualAdquisicion;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gcCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn gcFechaEmision;
        private DevExpress.XtraGrid.Columns.GridColumn gcFechaAprobacion;
        private DevExpress.XtraGrid.Columns.GridColumn gcAnio;
        private DevExpress.XtraGrid.Columns.GridColumn gcDescripcion;
    }
}
