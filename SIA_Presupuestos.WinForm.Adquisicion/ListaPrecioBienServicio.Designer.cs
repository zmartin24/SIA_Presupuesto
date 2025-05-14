namespace SIA_Presupuesto.WinForm.Adquisicion
{
    partial class ListaPrecioBienServicio
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lueAnio = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.pivotGridControl1 = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.pgfDireccion = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pgfSubdireccion = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pgfCuenta = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pgfSubCuenta = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pgfDivisionaria = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pgfSubpresupuesto = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pgfDescripcion = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pgfUnidad = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pgfMes = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pgfNomMes = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pgfDia = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pgfPrecio = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pgfCantidad = new DevExpress.XtraPivotGrid.PivotGridField();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lueMoneda = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lueMes = new DevExpress.XtraEditors.LookUpEdit();
            this.lciGruPre = new DevExpress.XtraLayout.LayoutControlItem();
            this.lueGruPre = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.sbConsultar = new DevExpress.XtraEditors.SimpleButton();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.pgfSubTotal = new DevExpress.XtraPivotGrid.PivotGridField();
            ((System.ComponentModel.ISupportInitialize)(this.lcGeneral)).BeginInit();
            this.lcGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgGeneral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueAnio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMoneda.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciGruPre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueGruPre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // lcGeneral
            // 
            this.lcGeneral.Controls.Add(this.sbConsultar);
            this.lcGeneral.Controls.Add(this.lueGruPre);
            this.lcGeneral.Controls.Add(this.lueMes);
            this.lcGeneral.Controls.Add(this.pivotGridControl1);
            this.lcGeneral.Controls.Add(this.lueAnio);
            this.lcGeneral.Controls.Add(this.lueMoneda);
            this.lcGeneral.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(744, 331, 450, 400);
            // 
            // lcgGeneral
            // 
            this.lcgGeneral.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem1,
            this.layoutControlItem3,
            this.layoutControlGroup1});
            this.lcgGeneral.Name = "Root";
            // 
            // lueAnio
            // 
            this.lueAnio.Location = new System.Drawing.Point(120, 42);
            this.lueAnio.Name = "lueAnio";
            this.lueAnio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueAnio.Size = new System.Drawing.Size(117, 20);
            this.lueAnio.StyleController = this.lcGeneral;
            this.lueAnio.TabIndex = 4;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.lueAnio;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(217, 24);
            this.layoutControlItem1.Text = "Año";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(92, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 554);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(836, 10);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // pivotGridControl1
            // 
            this.pivotGridControl1.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.pgfDireccion,
            this.pgfSubdireccion,
            this.pgfCuenta,
            this.pgfSubCuenta,
            this.pgfDivisionaria,
            this.pgfSubpresupuesto,
            this.pgfDescripcion,
            this.pgfUnidad,
            this.pgfMes,
            this.pgfNomMes,
            this.pgfDia,
            this.pgfPrecio,
            this.pgfCantidad,
            this.pgfSubTotal});
            this.pivotGridControl1.Location = new System.Drawing.Point(12, 104);
            this.pivotGridControl1.Name = "pivotGridControl1";
            this.pivotGridControl1.OptionsPrint.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.pivotGridControl1.OptionsPrint.PrintColumnHeaders = DevExpress.Utils.DefaultBoolean.True;
            this.pivotGridControl1.OptionsPrint.PrintDataHeaders = DevExpress.Utils.DefaultBoolean.True;
            this.pivotGridControl1.OptionsPrint.PrintFilterHeaders = DevExpress.Utils.DefaultBoolean.True;
            this.pivotGridControl1.OptionsPrint.PrintHeadersOnEveryPage = true;
            this.pivotGridControl1.OptionsPrint.PrintHorzLines = DevExpress.Utils.DefaultBoolean.True;
            this.pivotGridControl1.OptionsPrint.PrintRowHeaders = DevExpress.Utils.DefaultBoolean.True;
            this.pivotGridControl1.OptionsPrint.PrintVertLines = DevExpress.Utils.DefaultBoolean.True;
            this.pivotGridControl1.OptionsPrint.UsePrintAppearance = true;
            this.pivotGridControl1.Size = new System.Drawing.Size(832, 458);
            this.pivotGridControl1.TabIndex = 9;
            // 
            // pgfDireccion
            // 
            this.pgfDireccion.AreaIndex = 0;
            this.pgfDireccion.Caption = "Dirección";
            this.pgfDireccion.FieldName = "desDireccion";
            this.pgfDireccion.Name = "pgfDireccion";
            // 
            // pgfSubdireccion
            // 
            this.pgfSubdireccion.AreaIndex = 1;
            this.pgfSubdireccion.Caption = "Subdirección";
            this.pgfSubdireccion.FieldName = "desSubdireccion";
            this.pgfSubdireccion.Name = "pgfSubdireccion";
            // 
            // pgfCuenta
            // 
            this.pgfCuenta.AreaIndex = 3;
            this.pgfCuenta.Caption = "Cuenta";
            this.pgfCuenta.FieldName = "cuenta";
            this.pgfCuenta.Name = "pgfCuenta";
            // 
            // pgfSubCuenta
            // 
            this.pgfSubCuenta.AreaIndex = 4;
            this.pgfSubCuenta.Caption = "SubCuenta";
            this.pgfSubCuenta.FieldName = "subcuenta";
            this.pgfSubCuenta.Name = "pgfSubCuenta";
            // 
            // pgfDivisionaria
            // 
            this.pgfDivisionaria.AreaIndex = 5;
            this.pgfDivisionaria.Caption = "Divisionaria";
            this.pgfDivisionaria.FieldName = "divisionaria";
            this.pgfDivisionaria.Name = "pgfDivisionaria";
            // 
            // pgfSubpresupuesto
            // 
            this.pgfSubpresupuesto.AreaIndex = 2;
            this.pgfSubpresupuesto.Caption = "SubPresupuesto";
            this.pgfSubpresupuesto.FieldName = "desSubpresupuesto";
            this.pgfSubpresupuesto.Name = "pgfSubpresupuesto";
            // 
            // pgfDescripcion
            // 
            this.pgfDescripcion.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pgfDescripcion.AreaIndex = 0;
            this.pgfDescripcion.Caption = "Descripción";
            this.pgfDescripcion.FieldName = "prodServ";
            this.pgfDescripcion.Name = "pgfDescripcion";
            this.pgfDescripcion.Width = 400;
            // 
            // pgfUnidad
            // 
            this.pgfUnidad.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pgfUnidad.AreaIndex = 1;
            this.pgfUnidad.Caption = "Unidad";
            this.pgfUnidad.FieldName = "umedida";
            this.pgfUnidad.Name = "pgfUnidad";
            // 
            // pgfMes
            // 
            this.pgfMes.AreaIndex = 6;
            this.pgfMes.Caption = "Mes";
            this.pgfMes.FieldName = "mes";
            this.pgfMes.Name = "pgfMes";
            // 
            // pgfNomMes
            // 
            this.pgfNomMes.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.pgfNomMes.AreaIndex = 0;
            this.pgfNomMes.Caption = "Nom. Mes";
            this.pgfNomMes.FieldName = "nomMes";
            this.pgfNomMes.Name = "pgfNomMes";
            // 
            // pgfDia
            // 
            this.pgfDia.AreaIndex = 7;
            this.pgfDia.Caption = "Día";
            this.pgfDia.FieldName = "dia";
            this.pgfDia.Name = "pgfDia";
            // 
            // pgfPrecio
            // 
            this.pgfPrecio.Appearance.Cell.Options.UseTextOptions = true;
            this.pgfPrecio.Appearance.Cell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.pgfPrecio.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pgfPrecio.AreaIndex = 2;
            this.pgfPrecio.Caption = "Precio";
            this.pgfPrecio.CellFormat.FormatString = "n2";
            this.pgfPrecio.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pgfPrecio.FieldName = "precio";
            this.pgfPrecio.Name = "pgfPrecio";
            // 
            // pgfCantidad
            // 
            this.pgfCantidad.Appearance.Cell.Options.UseTextOptions = true;
            this.pgfCantidad.Appearance.Cell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.pgfCantidad.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.pgfCantidad.AreaIndex = 0;
            this.pgfCantidad.Caption = "Cant.";
            this.pgfCantidad.CellFormat.FormatString = "n2";
            this.pgfCantidad.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pgfCantidad.FieldName = "cantidad";
            this.pgfCantidad.Name = "pgfCantidad";
            this.pgfCantidad.Width = 60;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.pivotGridControl1;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 92);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(836, 462);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // lueMoneda
            // 
            this.lueMoneda.Location = new System.Drawing.Point(572, 42);
            this.lueMoneda.Name = "lueMoneda";
            this.lueMoneda.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueMoneda.Size = new System.Drawing.Size(100, 20);
            this.lueMoneda.StyleController = this.lcGeneral;
            this.lueMoneda.TabIndex = 4;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.lueMoneda;
            this.layoutControlItem4.CustomizationFormText = "Año";
            this.layoutControlItem4.Location = new System.Drawing.Point(452, 0);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(200, 24);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(200, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(200, 24);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.Text = "Moneda";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(92, 13);
            // 
            // emptySpaceItem5
            // 
            this.emptySpaceItem5.AllowHotTrack = false;
            this.emptySpaceItem5.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem5.Location = new System.Drawing.Point(652, 0);
            this.emptySpaceItem5.Name = "emptySpaceItem5";
            this.emptySpaceItem5.Size = new System.Drawing.Size(160, 24);
            this.emptySpaceItem5.Text = "emptySpaceItem1";
            this.emptySpaceItem5.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem5,
            this.layoutControlItem5,
            this.layoutControlItem4,
            this.lciGruPre,
            this.layoutControlItem2,
            this.emptySpaceItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(836, 92);
            this.layoutControlGroup1.Text = "Búsqueda";
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.lueMes;
            this.layoutControlItem5.Location = new System.Drawing.Point(217, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(235, 24);
            this.layoutControlItem5.Text = "Mes";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(92, 13);
            // 
            // lueMes
            // 
            this.lueMes.Location = new System.Drawing.Point(337, 42);
            this.lueMes.Name = "lueMes";
            this.lueMes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueMes.Size = new System.Drawing.Size(135, 20);
            this.lueMes.StyleController = this.lcGeneral;
            this.lueMes.TabIndex = 10;
            // 
            // lciGruPre
            // 
            this.lciGruPre.Control = this.lueGruPre;
            this.lciGruPre.Location = new System.Drawing.Point(0, 24);
            this.lciGruPre.MaxSize = new System.Drawing.Size(452, 26);
            this.lciGruPre.MinSize = new System.Drawing.Size(452, 26);
            this.lciGruPre.Name = "lciGruPre";
            this.lciGruPre.Size = new System.Drawing.Size(452, 26);
            this.lciGruPre.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciGruPre.Text = "Grupo Presupuesto";
            this.lciGruPre.TextSize = new System.Drawing.Size(92, 13);
            // 
            // lueGruPre
            // 
            this.lueGruPre.Location = new System.Drawing.Point(120, 66);
            this.lueGruPre.Name = "lueGruPre";
            this.lueGruPre.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueGruPre.Size = new System.Drawing.Size(352, 20);
            this.lueGruPre.StyleController = this.lcGeneral;
            this.lueGruPre.TabIndex = 11;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.sbConsultar;
            this.layoutControlItem2.Location = new System.Drawing.Point(452, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(200, 26);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // sbConsultar
            // 
            this.sbConsultar.Location = new System.Drawing.Point(476, 66);
            this.sbConsultar.Name = "sbConsultar";
            this.sbConsultar.Size = new System.Drawing.Size(196, 22);
            this.sbConsultar.StyleController = this.lcGeneral;
            this.sbConsultar.TabIndex = 12;
            this.sbConsultar.Text = "Contultar";
            this.sbConsultar.Click += new System.EventHandler(this.sbConsultar_Click);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(652, 24);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(160, 26);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // pgfSubTotal
            // 
            this.pgfSubTotal.Appearance.Cell.Options.UseTextOptions = true;
            this.pgfSubTotal.Appearance.Cell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.pgfSubTotal.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.pgfSubTotal.AreaIndex = 1;
            this.pgfSubTotal.Caption = "SubTotal";
            this.pgfSubTotal.CellFormat.FormatString = "n2";
            this.pgfSubTotal.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pgfSubTotal.FieldName = "subTotal";
            this.pgfSubTotal.Name = "pgfSubTotal";
            // 
            // ListaPrecioBienServicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ListaPrecioBienServicio";
            ((System.ComponentModel.ISupportInitialize)(this.lcGeneral)).EndInit();
            this.lcGeneral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgGeneral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueAnio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMoneda.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciGruPre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueGruPre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit lueAnio;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraPivotGrid.PivotGridControl pivotGridControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraPivotGrid.PivotGridField pgfDia;
        private DevExpress.XtraEditors.LookUpEdit lueMoneda;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem5;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.LookUpEdit lueMes;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraPivotGrid.PivotGridField pgfCuenta;
        private DevExpress.XtraPivotGrid.PivotGridField pgfSubCuenta;
        private DevExpress.XtraPivotGrid.PivotGridField pgfDivisionaria;
        private DevExpress.XtraPivotGrid.PivotGridField pgfSubpresupuesto;
        private DevExpress.XtraPivotGrid.PivotGridField pgfMes;
        private DevExpress.XtraEditors.SimpleButton sbConsultar;
        private DevExpress.XtraEditors.LookUpEdit lueGruPre;
        private DevExpress.XtraLayout.LayoutControlItem lciGruPre;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraPivotGrid.PivotGridField pgfDireccion;
        private DevExpress.XtraPivotGrid.PivotGridField pgfSubdireccion;
        private DevExpress.XtraPivotGrid.PivotGridField pgfDescripcion;
        private DevExpress.XtraPivotGrid.PivotGridField pgfUnidad;
        private DevExpress.XtraPivotGrid.PivotGridField pgfPrecio;
        private DevExpress.XtraPivotGrid.PivotGridField pgfCantidad;
        private DevExpress.XtraPivotGrid.PivotGridField pgfNomMes;
        private DevExpress.XtraPivotGrid.PivotGridField pgfSubTotal;
    }
}
