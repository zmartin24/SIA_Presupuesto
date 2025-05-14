namespace SIA_Presupuesto.WinForm.Programacion
{
    partial class frmPresupuestoRemuneracion
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
            this.pgcResultado = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.pgPuesto = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pgCargo = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pgGrado = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pgCantVac = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pgConcepto = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pgMes = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pgImporte = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pgEsRemDiaria = new DevExpress.XtraPivotGrid.PivotGridField();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lueEstructura = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lueMesDesde = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lueMesHasta = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcPrincipal)).BeginInit();
            this.lcPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgPrincipal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxProveedorValidacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pgcResultado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueEstructura.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMesDesde.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMesHasta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // lcPrincipal
            // 
            this.lcPrincipal.Controls.Add(this.lueMesHasta);
            this.lcPrincipal.Controls.Add(this.lueMesDesde);
            this.lcPrincipal.Controls.Add(this.lueEstructura);
            this.lcPrincipal.Controls.Add(this.pgcResultado);
            this.lcPrincipal.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(551, 289, 450, 400);
            this.lcPrincipal.Size = new System.Drawing.Size(1049, 568);
            // 
            // lcgPrincipal
            // 
            this.lcgPrincipal.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.emptySpaceItem1,
            this.layoutControlItem3,
            this.layoutControlItem4});
            this.lcgPrincipal.Name = "Root";
            this.lcgPrincipal.Size = new System.Drawing.Size(1049, 568);
            // 
            // pgcResultado
            // 
            this.pgcResultado.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.pgPuesto,
            this.pgCargo,
            this.pgGrado,
            this.pgCantVac,
            this.pgConcepto,
            this.pgMes,
            this.pgImporte,
            this.pgEsRemDiaria});
            this.pgcResultado.Location = new System.Drawing.Point(12, 36);
            this.pgcResultado.Name = "pgcResultado";
            this.pgcResultado.OptionsData.DataProcessingEngine = DevExpress.XtraPivotGrid.PivotDataProcessingEngine.LegacyOptimized;
            this.pgcResultado.OptionsView.ShowColumnHeaders = false;
            this.pgcResultado.OptionsView.ShowDataHeaders = false;
            this.pgcResultado.OptionsView.ShowFilterHeaders = false;
            this.pgcResultado.Size = new System.Drawing.Size(1025, 520);
            this.pgcResultado.TabIndex = 4;
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
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.pgcResultado;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1029, 524);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // lueEstructura
            // 
            this.lueEstructura.Location = new System.Drawing.Point(103, 12);
            this.lueEstructura.Name = "lueEstructura";
            this.lueEstructura.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueEstructura.Size = new System.Drawing.Size(151, 20);
            this.lueEstructura.StyleController = this.lcPrincipal;
            this.lueEstructura.TabIndex = 5;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.lueEstructura;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(246, 24);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(246, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(246, 24);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Text = "Estructura Cálculo";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(87, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(622, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(407, 24);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lueMesDesde
            // 
            this.lueMesDesde.Location = new System.Drawing.Point(349, 12);
            this.lueMesDesde.Name = "lueMesDesde";
            this.lueMesDesde.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueMesDesde.Size = new System.Drawing.Size(91, 20);
            this.lueMesDesde.StyleController = this.lcPrincipal;
            this.lueMesDesde.TabIndex = 6;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.lueMesDesde;
            this.layoutControlItem3.Location = new System.Drawing.Point(246, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(186, 24);
            this.layoutControlItem3.Text = "Mes Desde";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(87, 13);
            // 
            // lueMesHasta
            // 
            this.lueMesHasta.Location = new System.Drawing.Point(535, 12);
            this.lueMesHasta.Name = "lueMesHasta";
            this.lueMesHasta.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueMesHasta.Size = new System.Drawing.Size(95, 20);
            this.lueMesHasta.StyleController = this.lcPrincipal;
            this.lueMesHasta.TabIndex = 7;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.lueMesHasta;
            this.layoutControlItem4.Location = new System.Drawing.Point(432, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(190, 24);
            this.layoutControlItem4.Text = "Mes Hasta";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(87, 13);
            // 
            // frmPresupuestoRemuneracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "frmPresupuestoRemuneracion";
            this.Size = new System.Drawing.Size(1049, 568);
            ((System.ComponentModel.ISupportInitialize)(this.lcPrincipal)).EndInit();
            this.lcPrincipal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgPrincipal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxProveedorValidacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pgcResultado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueEstructura.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMesDesde.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMesHasta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraPivotGrid.PivotGridControl pgcResultado;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraPivotGrid.PivotGridField pgPuesto;
        private DevExpress.XtraPivotGrid.PivotGridField pgCargo;
        private DevExpress.XtraPivotGrid.PivotGridField pgGrado;
        private DevExpress.XtraPivotGrid.PivotGridField pgCantVac;
        private DevExpress.XtraPivotGrid.PivotGridField pgConcepto;
        private DevExpress.XtraPivotGrid.PivotGridField pgMes;
        private DevExpress.XtraPivotGrid.PivotGridField pgImporte;
        private DevExpress.XtraPivotGrid.PivotGridField pgEsRemDiaria;
        private DevExpress.XtraEditors.LookUpEdit lueEstructura;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.LookUpEdit lueMesHasta;
        private DevExpress.XtraEditors.LookUpEdit lueMesDesde;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}
