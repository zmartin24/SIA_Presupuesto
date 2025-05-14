namespace SIA_Presupuesto.WinForm.Programacion
{
    partial class ListaReajusteMensualPresupuesto
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
            this.grcReajusteMensual = new DevExpress.XtraGrid.GridControl();
            this.grvReajusteMensual = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPresupuestoAnual = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcMesDesde = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFechaEmision = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFechaAprobacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcMoneda = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcImporte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcAnio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lueAnio = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lueMes = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcGeneral)).BeginInit();
            this.lcGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgGeneral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcReajusteMensual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvReajusteMensual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueAnio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // lcGeneral
            // 
            this.lcGeneral.Controls.Add(this.lueMes);
            this.lcGeneral.Controls.Add(this.lueAnio);
            this.lcGeneral.Controls.Add(this.grcReajusteMensual);
            this.lcGeneral.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(744, 305, 450, 400);
            // 
            // lcgGeneral
            // 
            this.lcgGeneral.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.emptySpaceItem1,
            this.layoutControlItem3});
            this.lcgGeneral.Name = "Root";
            // 
            // grcReajusteMensual
            // 
            this.grcReajusteMensual.Location = new System.Drawing.Point(12, 36);
            this.grcReajusteMensual.MainView = this.grvReajusteMensual;
            this.grcReajusteMensual.Name = "grcReajusteMensual";
            this.grcReajusteMensual.Size = new System.Drawing.Size(832, 536);
            this.grcReajusteMensual.TabIndex = 4;
            this.grcReajusteMensual.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvReajusteMensual});
            // 
            // grvReajusteMensual
            // 
            this.grvReajusteMensual.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcCodigo,
            this.gcPresupuestoAnual,
            this.gcDescripcion,
            this.gcMesDesde,
            this.gcFechaEmision,
            this.gcFechaAprobacion,
            this.gcMoneda,
            this.gcImporte,
            this.gcAnio});
            this.grvReajusteMensual.GridControl = this.grcReajusteMensual;
            this.grvReajusteMensual.Name = "grvReajusteMensual";
            this.grvReajusteMensual.OptionsBehavior.Editable = false;
            this.grvReajusteMensual.OptionsView.ColumnAutoWidth = false;
            this.grvReajusteMensual.OptionsView.ShowAutoFilterRow = true;
            // 
            // gcCodigo
            // 
            this.gcCodigo.Caption = "Código";
            this.gcCodigo.FieldName = "idReaMenPro";
            this.gcCodigo.Name = "gcCodigo";
            this.gcCodigo.Visible = true;
            this.gcCodigo.VisibleIndex = 0;
            this.gcCodigo.Width = 100;
            // 
            // gcPresupuestoAnual
            // 
            this.gcPresupuestoAnual.Caption = "Presupuesto Anual";
            this.gcPresupuestoAnual.FieldName = "presupuestoAnual";
            this.gcPresupuestoAnual.Name = "gcPresupuestoAnual";
            this.gcPresupuestoAnual.Visible = true;
            this.gcPresupuestoAnual.VisibleIndex = 1;
            this.gcPresupuestoAnual.Width = 600;
            // 
            // gcDescripcion
            // 
            this.gcDescripcion.Caption = "Descripción";
            this.gcDescripcion.FieldName = "descripcion";
            this.gcDescripcion.Name = "gcDescripcion";
            this.gcDescripcion.Visible = true;
            this.gcDescripcion.VisibleIndex = 2;
            this.gcDescripcion.Width = 500;
            // 
            // gcMesDesde
            // 
            this.gcMesDesde.Caption = "Mes Reajuste";
            this.gcMesDesde.FieldName = "mesReajuste";
            this.gcMesDesde.Name = "gcMesDesde";
            this.gcMesDesde.Visible = true;
            this.gcMesDesde.VisibleIndex = 3;
            // 
            // gcFechaEmision
            // 
            this.gcFechaEmision.AppearanceCell.Options.UseTextOptions = true;
            this.gcFechaEmision.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcFechaEmision.Caption = "Fecha Emisión";
            this.gcFechaEmision.FieldName = "fechaEmision";
            this.gcFechaEmision.Name = "gcFechaEmision";
            this.gcFechaEmision.Visible = true;
            this.gcFechaEmision.VisibleIndex = 4;
            this.gcFechaEmision.Width = 100;
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
            this.gcMoneda.VisibleIndex = 5;
            this.gcMoneda.Width = 90;
            // 
            // gcImporte
            // 
            this.gcImporte.AppearanceCell.Options.UseTextOptions = true;
            this.gcImporte.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gcImporte.Caption = "Importe";
            this.gcImporte.DisplayFormat.FormatString = "n2";
            this.gcImporte.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcImporte.FieldName = "total";
            this.gcImporte.Name = "gcImporte";
            this.gcImporte.Visible = true;
            this.gcImporte.VisibleIndex = 6;
            this.gcImporte.Width = 110;
            // 
            // gcAnio
            // 
            this.gcAnio.AppearanceCell.Options.UseTextOptions = true;
            this.gcAnio.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcAnio.Caption = "Año";
            this.gcAnio.FieldName = "anio";
            this.gcAnio.Name = "gcAnio";
            this.gcAnio.Visible = true;
            this.gcAnio.VisibleIndex = 7;
            this.gcAnio.Width = 80;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grcReajusteMensual;
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
            this.lueAnio.Size = new System.Drawing.Size(106, 20);
            this.lueAnio.StyleController = this.lcGeneral;
            this.lueAnio.TabIndex = 5;
            this.lueAnio.EditValueChanged += new System.EventHandler(this.lueAnio_EditValueChanged);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.lueAnio;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(141, 24);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(141, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(141, 24);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Text = "Año";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(19, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(310, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(526, 24);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lueMes
            // 
            this.lueMes.Location = new System.Drawing.Point(184, 12);
            this.lueMes.Name = "lueMes";
            this.lueMes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueMes.Size = new System.Drawing.Size(134, 20);
            this.lueMes.StyleController = this.lcGeneral;
            this.lueMes.TabIndex = 6;
            this.lueMes.EditValueChanged += new System.EventHandler(this.lueMes_EditValueChanged);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.lueMes;
            this.layoutControlItem3.Location = new System.Drawing.Point(141, 0);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(169, 24);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(169, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(169, 24);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Text = "Mes";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(19, 13);
            // 
            // ListaReajusteMensualPresupuesto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ListaReajusteMensualPresupuesto";
            ((System.ComponentModel.ISupportInitialize)(this.lcGeneral)).EndInit();
            this.lcGeneral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgGeneral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcReajusteMensual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvReajusteMensual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueAnio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grcReajusteMensual;
        private DevExpress.XtraGrid.Views.Grid.GridView grvReajusteMensual;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gcCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn gcFechaEmision;
        private DevExpress.XtraGrid.Columns.GridColumn gcFechaAprobacion;
        private DevExpress.XtraGrid.Columns.GridColumn gcMoneda;
        private DevExpress.XtraGrid.Columns.GridColumn gcAnio;
        private DevExpress.XtraGrid.Columns.GridColumn gcDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn gcMesDesde;
        private DevExpress.XtraEditors.LookUpEdit lueAnio;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.LookUpEdit lueMes;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraGrid.Columns.GridColumn gcPresupuestoAnual;
        private DevExpress.XtraGrid.Columns.GridColumn gcImporte;
    }
}
