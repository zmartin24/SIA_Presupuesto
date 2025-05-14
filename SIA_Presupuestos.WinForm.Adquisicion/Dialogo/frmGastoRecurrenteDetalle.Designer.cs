namespace SIA_Presupuesto.WinForm.Adquisicion.Dialogo
{
    partial class frmGastoRecurrenteDetalle
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtDescripcion = new DevExpress.XtraEditors.MemoEdit();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lueUnidad = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.sePrecio = new DevExpress.XtraEditors.SpinEdit();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.sbAyudaProducto = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.glueCuenta = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem18 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lcgDetalle = new DevExpress.XtraLayout.LayoutControlGroup();
            this.simpleSeparator1 = new DevExpress.XtraLayout.SimpleSeparator();
            this.layoutControlItem22 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtCodBieSer = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcBase)).BeginInit();
            this.lcBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxProveedorValidador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueUnidad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sePrecio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.glueCuenta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodBieSer.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lcCuerpo
            // 
            this.lcCuerpo.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(803, 132, 386, 350);
            this.lcCuerpo.Size = new System.Drawing.Size(584, 361);
            // 
            // lcgCuerpo
            // 
            this.lcgCuerpo.Size = new System.Drawing.Size(584, 361);
            // 
            // lcBase
            // 
            this.lcBase.Controls.Add(this.txtCodBieSer);
            this.lcBase.Controls.Add(this.sbAyudaProducto);
            this.lcBase.Controls.Add(this.sePrecio);
            this.lcBase.Controls.Add(this.lueUnidad);
            this.lcBase.Controls.Add(this.txtDescripcion);
            this.lcBase.Controls.Add(this.glueCuenta);
            this.lcBase.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(679, 299, 450, 400);
            this.lcBase.Size = new System.Drawing.Size(554, 291);
            // 
            // lcgBase
            // 
            this.lcgBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcgDetalle});
            this.lcgBase.Name = "Root";
            this.lcgBase.Size = new System.Drawing.Size(554, 291);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(82, 90);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcion.Size = new System.Drawing.Size(416, 151);
            this.txtDescripcion.StyleController = this.lcBase;
            this.txtDescripcion.TabIndex = 4;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtDescripcion;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(72, 20);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(478, 155);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.Text = "Descripción";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(54, 13);
            // 
            // lueUnidad
            // 
            this.lueUnidad.Location = new System.Drawing.Point(82, 245);
            this.lueUnidad.Name = "lueUnidad";
            this.lueUnidad.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueUnidad.Size = new System.Drawing.Size(203, 20);
            this.lueUnidad.StyleController = this.lcBase;
            this.lueUnidad.TabIndex = 5;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.lueUnidad;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 203);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(265, 24);
            this.layoutControlItem2.Text = "Unidad";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(54, 13);
            // 
            // sePrecio
            // 
            this.sePrecio.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.sePrecio.Location = new System.Drawing.Point(347, 245);
            this.sePrecio.Name = "sePrecio";
            this.sePrecio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.sePrecio.Properties.DisplayFormat.FormatString = "n2";
            this.sePrecio.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.sePrecio.Properties.Mask.EditMask = "n2";
            this.sePrecio.Size = new System.Drawing.Size(183, 20);
            this.sePrecio.StyleController = this.lcBase;
            this.sePrecio.TabIndex = 7;
            this.sePrecio.EditValueChanged += new System.EventHandler(this.sePrecio_EditValueChanged);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.sePrecio;
            this.layoutControlItem4.Location = new System.Drawing.Point(265, 203);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(245, 24);
            this.layoutControlItem4.Text = "Precio";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(54, 13);
            // 
            // sbAyudaProducto
            // 
            this.sbAyudaProducto.Location = new System.Drawing.Point(502, 219);
            this.sbAyudaProducto.Name = "sbAyudaProducto";
            this.sbAyudaProducto.Size = new System.Drawing.Size(28, 22);
            this.sbAyudaProducto.StyleController = this.lcBase;
            this.sbAyudaProducto.TabIndex = 8;
            this.sbAyudaProducto.Text = "...";
            this.sbAyudaProducto.Click += new System.EventHandler(this.sbAyudaProducto_Click);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.sbAyudaProducto;
            this.layoutControlItem3.Location = new System.Drawing.Point(478, 177);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(32, 26);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // glueCuenta
            // 
            this.glueCuenta.Location = new System.Drawing.Point(82, 42);
            this.glueCuenta.Name = "glueCuenta";
            this.glueCuenta.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.glueCuenta.Properties.PopupFormSize = new System.Drawing.Size(600, 0);
            this.glueCuenta.Properties.View = this.gridView1;
            this.glueCuenta.Size = new System.Drawing.Size(448, 20);
            this.glueCuenta.StyleController = this.lcBase;
            this.glueCuenta.TabIndex = 8;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Cuenta";
            this.gridColumn1.FieldName = "numCuenta";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Like;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 100;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Descripción";
            this.gridColumn2.FieldName = "descripcion";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 284;
            // 
            // layoutControlItem18
            // 
            this.layoutControlItem18.Control = this.glueCuenta;
            this.layoutControlItem18.CustomizationFormText = "Cuenta";
            this.layoutControlItem18.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem18.Name = "layoutControlItem18";
            this.layoutControlItem18.Size = new System.Drawing.Size(510, 24);
            this.layoutControlItem18.Text = "Cuenta";
            this.layoutControlItem18.TextSize = new System.Drawing.Size(54, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(478, 48);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(32, 129);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lcgDetalle
            // 
            this.lcgDetalle.CustomizationFormText = "Programa";
            this.lcgDetalle.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.simpleSeparator1,
            this.layoutControlItem18,
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.emptySpaceItem1,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem22});
            this.lcgDetalle.Location = new System.Drawing.Point(0, 0);
            this.lcgDetalle.Name = "lcgDetalle";
            this.lcgDetalle.OptionsTableLayoutItem.RowIndex = 1;
            this.lcgDetalle.Size = new System.Drawing.Size(534, 271);
            this.lcgDetalle.Text = "Bien / Servicio";
            // 
            // simpleSeparator1
            // 
            this.simpleSeparator1.AllowHotTrack = false;
            this.simpleSeparator1.CustomizationFormText = "simpleSeparator2";
            this.simpleSeparator1.Location = new System.Drawing.Point(0, 227);
            this.simpleSeparator1.Name = "simpleSeparator1";
            this.simpleSeparator1.Size = new System.Drawing.Size(510, 2);
            this.simpleSeparator1.Text = "simpleSeparator2";
            // 
            // layoutControlItem22
            // 
            this.layoutControlItem22.Control = this.txtCodBieSer;
            this.layoutControlItem22.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem22.Name = "layoutControlItem22";
            this.layoutControlItem22.Size = new System.Drawing.Size(510, 24);
            this.layoutControlItem22.Text = "Codigo B/S";
            this.layoutControlItem22.TextSize = new System.Drawing.Size(54, 13);
            // 
            // txtCodBieSer
            // 
            this.txtCodBieSer.Location = new System.Drawing.Point(82, 66);
            this.txtCodBieSer.Name = "txtCodBieSer";
            this.txtCodBieSer.Properties.ReadOnly = true;
            this.txtCodBieSer.Size = new System.Drawing.Size(448, 20);
            this.txtCodBieSer.StyleController = this.lcBase;
            this.txtCodBieSer.TabIndex = 17;
            // 
            // frmGastoRecurrenteDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Name = "frmGastoRecurrenteDetalle";
            this.Text = "frmGastoRecurrenteDetalle";
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcBase)).EndInit();
            this.lcBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxProveedorValidador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueUnidad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sePrecio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.glueCuenta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodBieSer.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.MemoEdit txtDescripcion;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.SpinEdit sePrecio;
        private DevExpress.XtraEditors.LookUpEdit lueUnidad;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.SimpleButton sbAyudaProducto;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.GridLookUpEdit glueCuenta;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem18;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlGroup lcgDetalle;
        private DevExpress.XtraLayout.SimpleSeparator simpleSeparator1;
        private DevExpress.XtraEditors.TextEdit txtCodBieSer;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem22;
    }
}