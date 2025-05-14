namespace SIA_Presupuesto.WinForm.Mantenimiento.Dialogo
{
    partial class frmPartidaPresupuestal
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
            this.lueTipo = new DevExpress.XtraEditors.LookUpEdit();
            this.lueUnidad = new DevExpress.XtraEditors.LookUpEdit();
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
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciUnidad = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciPrecio = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciCuenta = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcBase)).BeginInit();
            this.lcBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxProveedorValidador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTipo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueUnidad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sePrecio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slueCuenta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slueView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciUnidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPrecio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCuenta)).BeginInit();
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
            this.lcBase.Controls.Add(this.lueUnidad);
            this.lcBase.Controls.Add(this.lueTipo);
            this.lcBase.Controls.Add(this.txtDescripcion);
            this.lcBase.Size = new System.Drawing.Size(576, 169);
            // 
            // lcgBase
            // 
            this.lcgBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem4,
            this.layoutControlItem1,
            this.lciUnidad,
            this.lciPrecio,
            this.emptySpaceItem2,
            this.emptySpaceItem3,
            this.lciCuenta,
            this.emptySpaceItem1});
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
            this.txtDescripcion.Size = new System.Drawing.Size(486, 20);
            this.txtDescripcion.StyleController = this.lcBase;
            this.txtDescripcion.TabIndex = 7;
            // 
            // lueTipo
            // 
            this.lueTipo.Location = new System.Drawing.Point(78, 12);
            this.lueTipo.Name = "lueTipo";
            this.lueTipo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueTipo.Size = new System.Drawing.Size(90, 20);
            this.lueTipo.StyleController = this.lcBase;
            this.lueTipo.TabIndex = 8;
            // 
            // lueUnidad
            // 
            this.lueUnidad.Location = new System.Drawing.Point(78, 60);
            this.lueUnidad.Name = "lueUnidad";
            this.lueUnidad.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueUnidad.Size = new System.Drawing.Size(486, 20);
            this.lueUnidad.StyleController = this.lcBase;
            this.lueUnidad.TabIndex = 9;
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
            this.sePrecio.Size = new System.Drawing.Size(90, 20);
            this.sePrecio.StyleController = this.lcBase;
            this.sePrecio.TabIndex = 11;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(160, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(396, 24);
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
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.lueTipo;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(160, 24);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(160, 24);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(160, 24);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.Text = "Tipo";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(54, 13);
            // 
            // lciUnidad
            // 
            this.lciUnidad.Control = this.lueUnidad;
            this.lciUnidad.Location = new System.Drawing.Point(0, 48);
            this.lciUnidad.Name = "lciUnidad";
            this.lciUnidad.Size = new System.Drawing.Size(556, 24);
            this.lciUnidad.Text = "Unidad";
            this.lciUnidad.TextSize = new System.Drawing.Size(54, 13);
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
            // frmPartidaPresupuestal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 239);
            this.Name = "frmPartidaPresupuestal";
            this.Text = "";
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcBase)).EndInit();
            this.lcBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxProveedorValidador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTipo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueUnidad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sePrecio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slueCuenta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slueView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciUnidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPrecio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCuenta)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.TextEdit txtDescripcion;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.LookUpEdit lueTipo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.LookUpEdit lueUnidad;
        private DevExpress.XtraLayout.LayoutControlItem lciUnidad;
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
    }
}