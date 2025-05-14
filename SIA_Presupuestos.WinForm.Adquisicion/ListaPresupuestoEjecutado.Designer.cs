namespace SIA_Presupuesto.WinForm.Adquisicion
{
    partial class ListaPresupuestoEjecutado
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
            this.pivotGridField7 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.lueAnio = new DevExpress.XtraEditors.LookUpEdit();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.pivotGridControl1 = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.pivotGridField1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField2 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField5 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField4 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField3 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField10 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField6 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField9 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField12 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField11 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField8 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lueMoneda = new DevExpress.XtraEditors.LookUpEdit();
            this.lueMes = new DevExpress.XtraEditors.LookUpEdit();
            this.sbConsulta = new DevExpress.XtraEditors.SimpleButton();
            this.sbConsultaDetalles = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcGeneral)).BeginInit();
            this.lcGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgGeneral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueAnio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMoneda.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // lcGeneral
            // 
            this.lcGeneral.Controls.Add(this.sbConsultaDetalles);
            this.lcGeneral.Controls.Add(this.sbConsulta);
            this.lcGeneral.Controls.Add(this.lueMes);
            this.lcGeneral.Controls.Add(this.pivotGridControl1);
            this.lcGeneral.Controls.Add(this.lueAnio);
            this.lcGeneral.Controls.Add(this.lueMoneda);
            // 
            // lcgGeneral
            // 
            this.lcgGeneral.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem1,
            this.layoutControlItem3,
            this.layoutControlItem1,
            this.layoutControlItem5,
            this.layoutControlItem2,
            this.layoutControlItem4,
            this.layoutControlItem6,
            this.emptySpaceItem2,
            this.emptySpaceItem3});
            this.lcgGeneral.Name = "Root";
            // 
            // pivotGridField7
            // 
            this.pivotGridField7.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.pivotGridField7.AreaIndex = 0;
            this.pivotGridField7.Caption = "Monto Eje.";
            this.pivotGridField7.CellFormat.FormatString = "{0:n2}";
            this.pivotGridField7.CellFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.pivotGridField7.FieldName = "importe";
            this.pivotGridField7.Name = "pivotGridField7";
            // 
            // lueAnio
            // 
            this.lueAnio.Location = new System.Drawing.Point(62, 12);
            this.lueAnio.MinimumSize = new System.Drawing.Size(80, 0);
            this.lueAnio.Name = "lueAnio";
            this.lueAnio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueAnio.Size = new System.Drawing.Size(80, 20);
            this.lueAnio.StyleController = this.lcGeneral;
            this.lueAnio.TabIndex = 4;
            this.lueAnio.EditValueChanged += new System.EventHandler(this.lueAnio_EditValueChanged);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 528);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(836, 36);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // pivotGridControl1
            // 
            this.pivotGridControl1.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.pivotGridField1,
            this.pivotGridField2,
            this.pivotGridField5,
            this.pivotGridField4,
            this.pivotGridField3,
            this.pivotGridField10,
            this.pivotGridField6,
            this.pivotGridField9,
            this.pivotGridField7,
            this.pivotGridField12,
            this.pivotGridField11,
            this.pivotGridField8});
            this.pivotGridControl1.Location = new System.Drawing.Point(12, 62);
            this.pivotGridControl1.Name = "pivotGridControl1";
            this.pivotGridControl1.OptionsPrint.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.pivotGridControl1.OptionsPrint.PrintColumnAreaOnEveryPage = true;
            this.pivotGridControl1.OptionsPrint.PrintColumnHeaders = DevExpress.Utils.DefaultBoolean.True;
            this.pivotGridControl1.OptionsPrint.PrintDataHeaders = DevExpress.Utils.DefaultBoolean.True;
            this.pivotGridControl1.OptionsPrint.PrintFilterHeaders = DevExpress.Utils.DefaultBoolean.True;
            this.pivotGridControl1.OptionsPrint.PrintHorzLines = DevExpress.Utils.DefaultBoolean.True;
            this.pivotGridControl1.OptionsPrint.PrintRowHeaders = DevExpress.Utils.DefaultBoolean.True;
            this.pivotGridControl1.OptionsPrint.PrintVertLines = DevExpress.Utils.DefaultBoolean.True;
            this.pivotGridControl1.OptionsPrint.UsePrintAppearance = true;
            this.pivotGridControl1.Size = new System.Drawing.Size(832, 474);
            this.pivotGridControl1.TabIndex = 9;
            // 
            // pivotGridField1
            // 
            this.pivotGridField1.AreaIndex = 0;
            this.pivotGridField1.Caption = "Grupo Gasto";
            this.pivotGridField1.FieldName = "desGenerica";
            this.pivotGridField1.Name = "pivotGridField1";
            this.pivotGridField1.Width = 150;
            // 
            // pivotGridField2
            // 
            this.pivotGridField2.AreaIndex = 1;
            this.pivotGridField2.Caption = "Fondo";
            this.pivotGridField2.FieldName = "tipoOperacion";
            this.pivotGridField2.Name = "pivotGridField2";
            this.pivotGridField2.Width = 300;
            // 
            // pivotGridField5
            // 
            this.pivotGridField5.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField5.AreaIndex = 2;
            this.pivotGridField5.Caption = "Cuenta";
            this.pivotGridField5.FieldName = "desClase";
            this.pivotGridField5.Name = "pivotGridField5";
            // 
            // pivotGridField4
            // 
            this.pivotGridField4.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField4.AreaIndex = 3;
            this.pivotGridField4.Caption = "SubCuenta";
            this.pivotGridField4.FieldName = "desDivisionaria";
            this.pivotGridField4.Name = "pivotGridField4";
            // 
            // pivotGridField3
            // 
            this.pivotGridField3.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField3.AreaIndex = 4;
            this.pivotGridField3.Caption = "Divisionaria";
            this.pivotGridField3.FieldName = "desCuenta";
            this.pivotGridField3.Name = "pivotGridField3";
            // 
            // pivotGridField10
            // 
            this.pivotGridField10.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField10.AreaIndex = 0;
            this.pivotGridField10.Caption = "Grupo P.";
            this.pivotGridField10.FieldName = "desGruPresupuesto";
            this.pivotGridField10.Name = "pivotGridField10";
            // 
            // pivotGridField6
            // 
            this.pivotGridField6.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField6.AreaIndex = 1;
            this.pivotGridField6.Caption = "Presupuesto";
            this.pivotGridField6.FieldName = "desPresupuesto";
            this.pivotGridField6.Name = "pivotGridField6";
            // 
            // pivotGridField9
            // 
            this.pivotGridField9.AreaIndex = 2;
            this.pivotGridField9.Caption = "SubPresupuesto";
            this.pivotGridField9.FieldName = "desSubpresupuesto";
            this.pivotGridField9.Name = "pivotGridField9";
            // 
            // pivotGridField12
            // 
            this.pivotGridField12.AreaIndex = 3;
            this.pivotGridField12.Caption = "TipoEgreso";
            this.pivotGridField12.FieldName = "tipoEgreso";
            this.pivotGridField12.Name = "pivotGridField12";
            // 
            // pivotGridField11
            // 
            this.pivotGridField11.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.pivotGridField11.AreaIndex = 0;
            this.pivotGridField11.Caption = "MesPresupuesto";
            this.pivotGridField11.FieldName = "desMesPresupuesto";
            this.pivotGridField11.Name = "pivotGridField11";
            // 
            // pivotGridField8
            // 
            this.pivotGridField8.AreaIndex = 4;
            this.pivotGridField8.Caption = "Mes Emisión";
            this.pivotGridField8.FieldName = "desMesEmision";
            this.pivotGridField8.Name = "pivotGridField8";
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.pivotGridControl1;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 50);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(836, 478);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // lueMoneda
            // 
            this.lueMoneda.Location = new System.Drawing.Point(330, 12);
            this.lueMoneda.MinimumSize = new System.Drawing.Size(80, 0);
            this.lueMoneda.Name = "lueMoneda";
            this.lueMoneda.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueMoneda.Size = new System.Drawing.Size(80, 20);
            this.lueMoneda.StyleController = this.lcGeneral;
            this.lueMoneda.TabIndex = 4;
            this.lueMoneda.EditValueChanged += new System.EventHandler(this.lueMoneda_EditValueChanged);
            // 
            // lueMes
            // 
            this.lueMes.Location = new System.Drawing.Point(196, 12);
            this.lueMes.MinimumSize = new System.Drawing.Size(80, 0);
            this.lueMes.Name = "lueMes";
            this.lueMes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueMes.Size = new System.Drawing.Size(80, 20);
            this.lueMes.StyleController = this.lcGeneral;
            this.lueMes.TabIndex = 10;
            this.lueMes.EditValueChanged += new System.EventHandler(this.lueMes_EditValueChanged);
            // 
            // sbConsulta
            // 
            this.sbConsulta.Location = new System.Drawing.Point(12, 36);
            this.sbConsulta.Name = "sbConsulta";
            this.sbConsulta.Size = new System.Drawing.Size(122, 22);
            this.sbConsulta.StyleController = this.lcGeneral;
            this.sbConsulta.TabIndex = 11;
            this.sbConsulta.Text = "Consultar";
            this.sbConsulta.Click += new System.EventHandler(this.sbConsulta_Click);
            // 
            // sbConsultaDetalles
            // 
            this.sbConsultaDetalles.Location = new System.Drawing.Point(146, 36);
            this.sbConsultaDetalles.Name = "sbConsultaDetalles";
            this.sbConsultaDetalles.Size = new System.Drawing.Size(122, 22);
            this.sbConsultaDetalles.StyleController = this.lcGeneral;
            this.sbConsultaDetalles.TabIndex = 12;
            this.sbConsultaDetalles.Text = "Consultar Detalles";
            this.sbConsultaDetalles.Click += new System.EventHandler(this.sbConsultaDetalles_Click);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.lueAnio;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(134, 24);
            this.layoutControlItem1.Text = "Año";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(38, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.lueMes;
            this.layoutControlItem5.Location = new System.Drawing.Point(134, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(134, 24);
            this.layoutControlItem5.Text = "Mes";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(38, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.sbConsulta;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(126, 26);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(126, 26);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(134, 26);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.lueMoneda;
            this.layoutControlItem4.CustomizationFormText = "Año";
            this.layoutControlItem4.Location = new System.Drawing.Point(268, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(134, 24);
            this.layoutControlItem4.Text = "Moneda";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(38, 13);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.sbConsultaDetalles;
            this.layoutControlItem6.Location = new System.Drawing.Point(134, 24);
            this.layoutControlItem6.MaxSize = new System.Drawing.Size(126, 26);
            this.layoutControlItem6.MinSize = new System.Drawing.Size(126, 26);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(134, 26);
            this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(402, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(434, 24);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(268, 24);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(568, 26);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // ListaPresupuestoEjecutado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ListaPresupuestoEjecutado";
            ((System.ComponentModel.ISupportInitialize)(this.lcGeneral)).EndInit();
            this.lcGeneral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgGeneral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueAnio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMoneda.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit lueAnio;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraPivotGrid.PivotGridControl pivotGridControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField1;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField2;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField7;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField8;
        private DevExpress.XtraEditors.LookUpEdit lueMoneda;
        private DevExpress.XtraEditors.LookUpEdit lueMes;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField5;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField4;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField3;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField6;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField10;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField9;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField12;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField11;
        private DevExpress.XtraEditors.SimpleButton sbConsultaDetalles;
        private DevExpress.XtraEditors.SimpleButton sbConsulta;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
    }
}
