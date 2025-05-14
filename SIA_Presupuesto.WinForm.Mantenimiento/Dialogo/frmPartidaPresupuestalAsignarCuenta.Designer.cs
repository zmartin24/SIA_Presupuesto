namespace SIA_Presupuesto.WinForm.Mantenimiento.Dialogo
{
    partial class frmPartidaPresupuestalAsignarCuenta
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
            this.txtDescripcion = new DevExpress.XtraEditors.TextEdit();
            this.sePrecio = new DevExpress.XtraEditors.SpinEdit();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.slueCuenta = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.slueView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcsIdCueCon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcsNumCuenta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcsDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciPrecio = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciCuenta = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtTipo = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtUnidad = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcBase)).BeginInit();
            this.lcBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxProveedorValidador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sePrecio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slueCuenta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slueView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPrecio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCuenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnidad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // lcCuerpo
            // 
            this.lcCuerpo.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(803, 132, 386, 350);
            this.lcCuerpo.Size = new System.Drawing.Size(606, 239);
            // 
            // lcgCuerpo
            // 
            this.lcgCuerpo.Size = new System.Drawing.Size(606, 239);
            // 
            // lcBase
            // 
            this.lcBase.Controls.Add(this.slueCuenta);
            this.lcBase.Controls.Add(this.sePrecio);
            this.lcBase.Controls.Add(this.txtDescripcion);
            this.lcBase.Controls.Add(this.txtTipo);
            this.lcBase.Controls.Add(this.txtUnidad);
            this.lcBase.Size = new System.Drawing.Size(576, 169);
            // 
            // lcgBase
            // 
            this.lcgBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem4,
            this.lciPrecio,
            this.emptySpaceItem2,
            this.emptySpaceItem3,
            this.lciCuenta,
            this.emptySpaceItem1,
            this.layoutControlItem2,
            this.layoutControlItem3});
            this.lcgBase.Name = "Root";
            this.lcgBase.Size = new System.Drawing.Size(576, 169);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(78, 36);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcion.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.RegExpMaskManager));
            this.txtDescripcion.Properties.MaskSettings.Set("allowBlankInput", true);
            this.txtDescripcion.Properties.MaskSettings.Set("mask", "[A-Z0-9%@:*\"ÑÁÉÍÓÚ_., - -]{0,500}");
            this.txtDescripcion.Properties.MaskSettings.Set("showPlaceholders", false);
            this.txtDescripcion.Properties.ReadOnly = true;
            this.txtDescripcion.Size = new System.Drawing.Size(486, 20);
            this.txtDescripcion.StyleController = this.lcBase;
            this.txtDescripcion.TabIndex = 7;
            // 
            // sePrecio
            // 
            this.sePrecio.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.sePrecio.Location = new System.Drawing.Point(78, 84);
            this.sePrecio.Name = "sePrecio";
            this.sePrecio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.sePrecio.Properties.MaskSettings.Set("mask", "n");
            this.sePrecio.Properties.ReadOnly = true;
            this.sePrecio.Size = new System.Drawing.Size(90, 20);
            this.sePrecio.StyleController = this.lcBase;
            this.sePrecio.TabIndex = 11;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(165, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(391, 24);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(160, 72);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(396, 24);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // slueCuenta
            // 
            this.slueCuenta.Location = new System.Drawing.Point(78, 108);
            this.slueCuenta.Name = "slueCuenta";
            this.slueCuenta.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.slueCuenta.Properties.NullText = "Seleccionar cuenta";
            this.slueCuenta.Properties.PopupView = this.slueView;
            this.slueCuenta.Properties.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(this.slueCuenta_Properties_CustomDisplayText);
            this.slueCuenta.Size = new System.Drawing.Size(486, 20);
            this.slueCuenta.StyleController = this.lcBase;
            this.slueCuenta.TabIndex = 12;
            this.slueCuenta.Popup += new System.EventHandler(this.slueCuenta_Popup);
            // 
            // slueView
            // 
            this.slueView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcsIdCueCon,
            this.gcsNumCuenta,
            this.gcsDescripcion});
            this.slueView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.slueView.Name = "slueView";
            this.slueView.OptionsFind.FindNullPrompt = "Ingrese cuenta a buscar";
            this.slueView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.slueView.OptionsView.ColumnAutoWidth = false;
            this.slueView.OptionsView.ShowAutoFilterRow = true;
            this.slueView.OptionsView.ShowGroupPanel = false;
            this.slueView.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.slueView_SelectionChanged);
            // 
            // gcsIdCueCon
            // 
            this.gcsIdCueCon.Caption = "Id";
            this.gcsIdCueCon.FieldName = "idCueCon";
            this.gcsIdCueCon.Name = "gcsIdCueCon";
            this.gcsIdCueCon.Width = 206;
            // 
            // gcsNumCuenta
            // 
            this.gcsNumCuenta.Caption = "Cuenta";
            this.gcsNumCuenta.FieldName = "numCuenta";
            this.gcsNumCuenta.Name = "gcsNumCuenta";
            this.gcsNumCuenta.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.BeginsWith;
            this.gcsNumCuenta.Visible = true;
            this.gcsNumCuenta.VisibleIndex = 0;
            this.gcsNumCuenta.Width = 60;
            // 
            // gcsDescripcion
            // 
            this.gcsDescripcion.Caption = "Descripción";
            this.gcsDescripcion.FieldName = "descripcion";
            this.gcsDescripcion.Name = "gcsDescripcion";
            this.gcsDescripcion.Visible = true;
            this.gcsDescripcion.VisibleIndex = 1;
            this.gcsDescripcion.Width = 300;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 120);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(556, 29);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtDescripcion;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(556, 24);
            this.layoutControlItem4.Text = "Descripción";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(54, 13);
            // 
            // lciPrecio
            // 
            this.lciPrecio.Control = this.sePrecio;
            this.lciPrecio.Location = new System.Drawing.Point(0, 72);
            this.lciPrecio.MaxSize = new System.Drawing.Size(160, 24);
            this.lciPrecio.MinSize = new System.Drawing.Size(160, 24);
            this.lciPrecio.Name = "lciPrecio";
            this.lciPrecio.Size = new System.Drawing.Size(160, 24);
            this.lciPrecio.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciPrecio.Text = "Precio";
            this.lciPrecio.TextSize = new System.Drawing.Size(54, 13);
            // 
            // lciCuenta
            // 
            this.lciCuenta.Control = this.slueCuenta;
            this.lciCuenta.Location = new System.Drawing.Point(0, 96);
            this.lciCuenta.Name = "lciCuenta";
            this.lciCuenta.Size = new System.Drawing.Size(556, 24);
            this.lciCuenta.Text = "Cuenta";
            this.lciCuenta.TextSize = new System.Drawing.Size(54, 13);
            // 
            // txtTipo
            // 
            this.txtTipo.Location = new System.Drawing.Point(78, 12);
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTipo.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.RegExpMaskManager));
            this.txtTipo.Properties.MaskSettings.Set("allowBlankInput", true);
            this.txtTipo.Properties.MaskSettings.Set("mask", "[A-Z0-9%@:*\"ÑÁÉÍÓÚ_., - -]{0,500}");
            this.txtTipo.Properties.MaskSettings.Set("showPlaceholders", false);
            this.txtTipo.Properties.ReadOnly = true;
            this.txtTipo.Size = new System.Drawing.Size(95, 20);
            this.txtTipo.StyleController = this.lcBase;
            this.txtTipo.TabIndex = 7;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtTipo;
            this.layoutControlItem2.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.layoutControlItem2.CustomizationFormText = "Descripción";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(165, 24);
            this.layoutControlItem2.Text = "Tipo";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(54, 13);
            // 
            // txtUnidad
            // 
            this.txtUnidad.Location = new System.Drawing.Point(78, 60);
            this.txtUnidad.Name = "txtUnidad";
            this.txtUnidad.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUnidad.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.RegExpMaskManager));
            this.txtUnidad.Properties.MaskSettings.Set("allowBlankInput", true);
            this.txtUnidad.Properties.MaskSettings.Set("mask", "[A-Z0-9%@:*\"ÑÁÉÍÓÚ_., - -]{0,500}");
            this.txtUnidad.Properties.MaskSettings.Set("showPlaceholders", false);
            this.txtUnidad.Properties.ReadOnly = true;
            this.txtUnidad.Size = new System.Drawing.Size(486, 20);
            this.txtUnidad.StyleController = this.lcBase;
            this.txtUnidad.TabIndex = 7;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtUnidad;
            this.layoutControlItem3.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.layoutControlItem3.CustomizationFormText = "Descripción";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(556, 24);
            this.layoutControlItem3.Text = "Unidad";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(54, 13);
            // 
            // frmPartidaPresupuestalAsignarCuenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 239);
            this.Name = "frmPartidaPresupuestalAsignarCuenta";
            this.Text = "";
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcBase)).EndInit();
            this.lcBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxProveedorValidador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sePrecio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slueCuenta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slueView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPrecio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCuenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnidad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.TextEdit txtDescripcion;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.SpinEdit sePrecio;
        private DevExpress.XtraLayout.LayoutControlItem lciPrecio;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraEditors.SearchLookUpEdit slueCuenta;
        private DevExpress.XtraGrid.Views.Grid.GridView slueView;
        private DevExpress.XtraLayout.LayoutControlItem lciCuenta;
        private DevExpress.XtraGrid.Columns.GridColumn gcsIdCueCon;
        private DevExpress.XtraGrid.Columns.GridColumn gcsNumCuenta;
        private DevExpress.XtraGrid.Columns.GridColumn gcsDescripcion;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.TextEdit txtTipo;
        private DevExpress.XtraEditors.TextEdit txtUnidad;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}