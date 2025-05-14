namespace SIA_Presupuesto.WinForm.Adquisicion
{
    partial class ListaRequerimientoRecursoHumanoDetalle
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
            this.pgPuesto = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pgCargo = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pgGrado = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pgCantVac = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pgConcepto = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pgMes = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pgImporte = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pgEsRemDiaria = new DevExpress.XtraPivotGrid.PivotGridField();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lueMesDesde = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lueMesHasta = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.grcReqTrabajador = new DevExpress.XtraGrid.GridControl();
            this.grvReqTrabajador = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDNI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTrabajador = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcGrado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCargo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUsuCrea = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFechaCrea = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUsuEdita = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFechaEdita = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcPrincipal)).BeginInit();
            this.lcPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgPrincipal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxProveedorValidacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMesDesde.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMesHasta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcReqTrabajador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvReqTrabajador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // lcPrincipal
            // 
            this.lcPrincipal.Controls.Add(this.grcReqTrabajador);
            this.lcPrincipal.Controls.Add(this.lueMesHasta);
            this.lcPrincipal.Controls.Add(this.lueMesDesde);
            this.lcPrincipal.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(551, 289, 450, 400);
            this.lcPrincipal.Size = new System.Drawing.Size(1049, 568);
            // 
            // lcgPrincipal
            // 
            this.lcgPrincipal.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem1,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem1});
            this.lcgPrincipal.Name = "Root";
            this.lcgPrincipal.Size = new System.Drawing.Size(1049, 568);
            // 
            // pgPuesto
            // 
            this.pgPuesto.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pgPuesto.AreaIndex = 0;
            this.pgPuesto.Caption = "Trabajador";
            this.pgPuesto.FieldName = "trabajador";
            this.pgPuesto.Name = "pgPuesto";
            this.pgPuesto.Width = 250;
            // 
            // pgCargo
            // 
            this.pgCargo.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pgCargo.AreaIndex = 1;
            this.pgCargo.Caption = "Cargo";
            this.pgCargo.FieldName = "cargo";
            this.pgCargo.Name = "pgCargo";
            this.pgCargo.Width = 200;
            // 
            // pgGrado
            // 
            this.pgGrado.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pgGrado.AreaIndex = 2;
            this.pgGrado.Caption = "Grado";
            this.pgGrado.FieldName = "grado";
            this.pgGrado.Name = "pgGrado";
            // 
            // pgCantVac
            // 
            this.pgCantVac.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pgCantVac.AreaIndex = 3;
            this.pgCantVac.Caption = "Cant. Vacantes";
            this.pgCantVac.FieldName = "cantVacante";
            this.pgCantVac.Name = "pgCantVac";
            this.pgCantVac.Width = 110;
            // 
            // pgConcepto
            // 
            this.pgConcepto.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.pgConcepto.AreaIndex = 1;
            this.pgConcepto.FieldName = "abrConcepto";
            this.pgConcepto.Name = "pgConcepto";
            // 
            // pgMes
            // 
            this.pgMes.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.pgMes.AreaIndex = 0;
            this.pgMes.FieldName = "nomMes";
            this.pgMes.Name = "pgMes";
            // 
            // pgImporte
            // 
            this.pgImporte.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.pgImporte.AreaIndex = 0;
            this.pgImporte.CellFormat.FormatString = "#,##0.00";
            this.pgImporte.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pgImporte.FieldName = "importe";
            this.pgImporte.Name = "pgImporte";
            // 
            // pgEsRemDiaria
            // 
            this.pgEsRemDiaria.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pgEsRemDiaria.AreaIndex = 4;
            this.pgEsRemDiaria.FieldName = "esRemDiaria";
            this.pgEsRemDiaria.Name = "pgEsRemDiaria";
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(320, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(709, 24);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lueMesDesde
            // 
            this.lueMesDesde.Location = new System.Drawing.Point(68, 12);
            this.lueMesDesde.Name = "lueMesDesde";
            this.lueMesDesde.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueMesDesde.Size = new System.Drawing.Size(100, 20);
            this.lueMesDesde.StyleController = this.lcPrincipal;
            this.lueMesDesde.TabIndex = 6;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.lueMesDesde;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(160, 24);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(160, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(160, 24);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Text = "Mes Desde";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(52, 13);
            // 
            // lueMesHasta
            // 
            this.lueMesHasta.Location = new System.Drawing.Point(228, 12);
            this.lueMesHasta.Name = "lueMesHasta";
            this.lueMesHasta.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueMesHasta.Size = new System.Drawing.Size(100, 20);
            this.lueMesHasta.StyleController = this.lcPrincipal;
            this.lueMesHasta.TabIndex = 7;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.lueMesHasta;
            this.layoutControlItem4.Location = new System.Drawing.Point(160, 0);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(160, 24);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(160, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(160, 24);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.Text = "Mes Hasta";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(52, 13);
            // 
            // grcReqTrabajador
            // 
            this.grcReqTrabajador.Location = new System.Drawing.Point(12, 36);
            this.grcReqTrabajador.MainView = this.grvReqTrabajador;
            this.grcReqTrabajador.Name = "grcReqTrabajador";
            this.grcReqTrabajador.Size = new System.Drawing.Size(1025, 520);
            this.grcReqTrabajador.TabIndex = 8;
            this.grcReqTrabajador.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvReqTrabajador});
            // 
            // grvReqTrabajador
            // 
            this.grvReqTrabajador.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcCodigo,
            this.gcDNI,
            this.gcTrabajador,
            this.gcGrado,
            this.gcCargo,
            this.gcUsuCrea,
            this.gcFechaCrea,
            this.gcUsuEdita,
            this.gcFechaEdita});
            this.grvReqTrabajador.GridControl = this.grcReqTrabajador;
            this.grvReqTrabajador.Name = "grvReqTrabajador";
            this.grvReqTrabajador.OptionsBehavior.ReadOnly = true;
            this.grvReqTrabajador.OptionsView.ColumnAutoWidth = false;
            this.grvReqTrabajador.OptionsView.ShowAutoFilterRow = true;
            this.grvReqTrabajador.OptionsView.ShowGroupPanel = false;
            // 
            // gcCodigo
            // 
            this.gcCodigo.Caption = "Código";
            this.gcCodigo.FieldName = "idPueReq";
            this.gcCodigo.Name = "gcCodigo";
            this.gcCodigo.Visible = true;
            this.gcCodigo.VisibleIndex = 0;
            this.gcCodigo.Width = 50;
            // 
            // gcDNI
            // 
            this.gcDNI.Caption = "DNI";
            this.gcDNI.FieldName = "dni";
            this.gcDNI.Name = "gcDNI";
            this.gcDNI.Visible = true;
            this.gcDNI.VisibleIndex = 1;
            this.gcDNI.Width = 100;
            // 
            // gcTrabajador
            // 
            this.gcTrabajador.Caption = "Trabajador";
            this.gcTrabajador.FieldName = "trabajador";
            this.gcTrabajador.Name = "gcTrabajador";
            this.gcTrabajador.Visible = true;
            this.gcTrabajador.VisibleIndex = 2;
            this.gcTrabajador.Width = 250;
            // 
            // gcGrado
            // 
            this.gcGrado.Caption = "Grado";
            this.gcGrado.FieldName = "grado";
            this.gcGrado.Name = "gcGrado";
            this.gcGrado.Visible = true;
            this.gcGrado.VisibleIndex = 3;
            this.gcGrado.Width = 80;
            // 
            // gcCargo
            // 
            this.gcCargo.Caption = "Cargo";
            this.gcCargo.FieldName = "cargo";
            this.gcCargo.Name = "gcCargo";
            this.gcCargo.Visible = true;
            this.gcCargo.VisibleIndex = 4;
            this.gcCargo.Width = 150;
            // 
            // gcUsuCrea
            // 
            this.gcUsuCrea.Caption = "Usu. Crea";
            this.gcUsuCrea.FieldName = "usuCrea";
            this.gcUsuCrea.Name = "gcUsuCrea";
            this.gcUsuCrea.Visible = true;
            this.gcUsuCrea.VisibleIndex = 5;
            this.gcUsuCrea.Width = 100;
            // 
            // gcFechaCrea
            // 
            this.gcFechaCrea.AppearanceCell.Options.UseTextOptions = true;
            this.gcFechaCrea.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcFechaCrea.Caption = "Fecha Crea";
            this.gcFechaCrea.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.gcFechaCrea.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcFechaCrea.FieldName = "fechaCrea";
            this.gcFechaCrea.Name = "gcFechaCrea";
            this.gcFechaCrea.Visible = true;
            this.gcFechaCrea.VisibleIndex = 6;
            this.gcFechaCrea.Width = 90;
            // 
            // gcUsuEdita
            // 
            this.gcUsuEdita.Caption = "Usu. Edita";
            this.gcUsuEdita.FieldName = "usuEdita";
            this.gcUsuEdita.Name = "gcUsuEdita";
            this.gcUsuEdita.Visible = true;
            this.gcUsuEdita.VisibleIndex = 7;
            this.gcUsuEdita.Width = 100;
            // 
            // gcFechaEdita
            // 
            this.gcFechaEdita.AppearanceCell.Options.UseTextOptions = true;
            this.gcFechaEdita.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcFechaEdita.Caption = "Fecha Edita";
            this.gcFechaEdita.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.gcFechaEdita.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcFechaEdita.Name = "gcFechaEdita";
            this.gcFechaEdita.Visible = true;
            this.gcFechaEdita.VisibleIndex = 8;
            this.gcFechaEdita.Width = 90;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grcReqTrabajador;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1029, 524);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // ListaRequerimientoRecursoHumanoDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ListaRequerimientoRecursoHumanoDetalle";
            this.Size = new System.Drawing.Size(1049, 568);
            ((System.ComponentModel.ISupportInitialize)(this.lcPrincipal)).EndInit();
            this.lcPrincipal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgPrincipal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxProveedorValidacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMesDesde.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMesHasta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcReqTrabajador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvReqTrabajador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraPivotGrid.PivotGridField pgPuesto;
        private DevExpress.XtraPivotGrid.PivotGridField pgCargo;
        private DevExpress.XtraPivotGrid.PivotGridField pgGrado;
        private DevExpress.XtraPivotGrid.PivotGridField pgCantVac;
        private DevExpress.XtraPivotGrid.PivotGridField pgConcepto;
        private DevExpress.XtraPivotGrid.PivotGridField pgMes;
        private DevExpress.XtraPivotGrid.PivotGridField pgImporte;
        private DevExpress.XtraPivotGrid.PivotGridField pgEsRemDiaria;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.LookUpEdit lueMesHasta;
        private DevExpress.XtraEditors.LookUpEdit lueMesDesde;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraGrid.GridControl grcReqTrabajador;
        private DevExpress.XtraGrid.Views.Grid.GridView grvReqTrabajador;
        private DevExpress.XtraGrid.Columns.GridColumn gcCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn gcDNI;
        private DevExpress.XtraGrid.Columns.GridColumn gcTrabajador;
        private DevExpress.XtraGrid.Columns.GridColumn gcGrado;
        private DevExpress.XtraGrid.Columns.GridColumn gcCargo;
        private DevExpress.XtraGrid.Columns.GridColumn gcUsuCrea;
        private DevExpress.XtraGrid.Columns.GridColumn gcFechaCrea;
        private DevExpress.XtraGrid.Columns.GridColumn gcUsuEdita;
        private DevExpress.XtraGrid.Columns.GridColumn gcFechaEdita;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}
