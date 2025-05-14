namespace SIA_Presupuesto.WinForm.Mantenimiento
{
    partial class ListaPartidaPresupuestalCuenta
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
            this.grcPartidaPresupuestal = new DevExpress.XtraGrid.GridControl();
            this.grvPartidoPresupuestalCuenta = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCuenta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcAnio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUsuCrea = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFechaCrea = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtDescripcion = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtUnidad = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.sePrecio = new DevExpress.XtraEditors.SpinEdit();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.txtTipo = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcPrincipal)).BeginInit();
            this.lcPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgPrincipal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxProveedorValidacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcPartidaPresupuestal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPartidoPresupuestalCuenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnidad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sePrecio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // lcPrincipal
            // 
            this.lcPrincipal.Controls.Add(this.sePrecio);
            this.lcPrincipal.Controls.Add(this.txtUnidad);
            this.lcPrincipal.Controls.Add(this.txtDescripcion);
            this.lcPrincipal.Controls.Add(this.grcPartidaPresupuestal);
            this.lcPrincipal.Controls.Add(this.txtTipo);
            // 
            // lcgPrincipal
            // 
            this.lcgPrincipal.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.emptySpaceItem1,
            this.layoutControlItem4,
            this.emptySpaceItem2,
            this.layoutControlItem5,
            this.emptySpaceItem3});
            this.lcgPrincipal.Name = "Root";
            this.lcgPrincipal.Size = new System.Drawing.Size(733, 404);
            // 
            // grcPartidaPresupuestal
            // 
            this.grcPartidaPresupuestal.Location = new System.Drawing.Point(12, 84);
            this.grcPartidaPresupuestal.MainView = this.grvPartidoPresupuestalCuenta;
            this.grcPartidaPresupuestal.Name = "grcPartidaPresupuestal";
            this.grcPartidaPresupuestal.Size = new System.Drawing.Size(709, 308);
            this.grcPartidaPresupuestal.TabIndex = 5;
            this.grcPartidaPresupuestal.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvPartidoPresupuestalCuenta});
            // 
            // grvPartidoPresupuestalCuenta
            // 
            this.grvPartidoPresupuestalCuenta.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcCodigo,
            this.gcCuenta,
            this.gcDescripcion,
            this.gcAnio,
            this.gcUsuCrea,
            this.gcFechaCrea});
            this.grvPartidoPresupuestalCuenta.GridControl = this.grcPartidaPresupuestal;
            this.grvPartidoPresupuestalCuenta.Name = "grvPartidoPresupuestalCuenta";
            this.grvPartidoPresupuestalCuenta.OptionsBehavior.ReadOnly = true;
            this.grvPartidoPresupuestalCuenta.OptionsView.ColumnAutoWidth = false;
            this.grvPartidoPresupuestalCuenta.OptionsView.ShowAutoFilterRow = true;
            this.grvPartidoPresupuestalCuenta.OptionsView.ShowGroupPanel = false;
            // 
            // gcCodigo
            // 
            this.gcCodigo.Caption = "Id";
            this.gcCodigo.FieldName = "idParPreCue";
            this.gcCodigo.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.gcCodigo.Name = "gcCodigo";
            this.gcCodigo.Width = 50;
            // 
            // gcCuenta
            // 
            this.gcCuenta.Caption = "Cuenta";
            this.gcCuenta.FieldName = "numCuenta";
            this.gcCuenta.Name = "gcCuenta";
            this.gcCuenta.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.BeginsWith;
            this.gcCuenta.Visible = true;
            this.gcCuenta.VisibleIndex = 0;
            // 
            // gcDescripcion
            // 
            this.gcDescripcion.Caption = "Descripción";
            this.gcDescripcion.FieldName = "desCuenta";
            this.gcDescripcion.Name = "gcDescripcion";
            this.gcDescripcion.Visible = true;
            this.gcDescripcion.VisibleIndex = 1;
            this.gcDescripcion.Width = 400;
            // 
            // gcAnio
            // 
            this.gcAnio.AppearanceCell.Options.UseTextOptions = true;
            this.gcAnio.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcAnio.Caption = "Año";
            this.gcAnio.FieldName = "anio";
            this.gcAnio.Name = "gcAnio";
            this.gcAnio.Visible = true;
            this.gcAnio.VisibleIndex = 2;
            // 
            // gcUsuCrea
            // 
            this.gcUsuCrea.Caption = "Usuario Crea";
            this.gcUsuCrea.FieldName = "usuCrea";
            this.gcUsuCrea.Name = "gcUsuCrea";
            this.gcUsuCrea.Visible = true;
            this.gcUsuCrea.VisibleIndex = 3;
            this.gcUsuCrea.Width = 128;
            // 
            // gcFechaCrea
            // 
            this.gcFechaCrea.Caption = "Fecha Crea";
            this.gcFechaCrea.FieldName = "fechaCrea";
            this.gcFechaCrea.Name = "gcFechaCrea";
            this.gcFechaCrea.Visible = true;
            this.gcFechaCrea.VisibleIndex = 4;
            this.gcFechaCrea.Width = 113;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grcPartidaPresupuestal;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(713, 312);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(78, 36);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Properties.ReadOnly = true;
            this.txtDescripcion.Size = new System.Drawing.Size(633, 20);
            this.txtDescripcion.StyleController = this.lcPrincipal;
            this.txtDescripcion.TabIndex = 6;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtDescripcion;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(703, 24);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(703, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(703, 24);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Text = "Descripción";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(54, 13);
            // 
            // txtUnidad
            // 
            this.txtUnidad.Location = new System.Drawing.Point(78, 60);
            this.txtUnidad.Name = "txtUnidad";
            this.txtUnidad.Properties.ReadOnly = true;
            this.txtUnidad.Size = new System.Drawing.Size(195, 20);
            this.txtUnidad.StyleController = this.lcPrincipal;
            this.txtUnidad.TabIndex = 7;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtUnidad;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(265, 24);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(265, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(265, 24);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Text = "Unidad";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(54, 13);
            // 
            // sePrecio
            // 
            this.sePrecio.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.sePrecio.Location = new System.Drawing.Point(343, 60);
            this.sePrecio.Name = "sePrecio";
            this.sePrecio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.sePrecio.Properties.EditFormat.FormatString = "n2";
            this.sePrecio.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.sePrecio.Properties.ReadOnly = true;
            this.sePrecio.Size = new System.Drawing.Size(98, 20);
            this.sePrecio.StyleController = this.lcPrincipal;
            this.sePrecio.TabIndex = 8;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.sePrecio;
            this.layoutControlItem4.Location = new System.Drawing.Point(265, 48);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(168, 24);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(168, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(168, 24);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.Text = "Precio";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(54, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(703, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(10, 72);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(433, 48);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(270, 24);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // txtTipo
            // 
            this.txtTipo.Location = new System.Drawing.Point(78, 12);
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.Properties.ReadOnly = true;
            this.txtTipo.Size = new System.Drawing.Size(195, 20);
            this.txtTipo.StyleController = this.lcPrincipal;
            this.txtTipo.TabIndex = 6;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtTipo;
            this.layoutControlItem5.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.layoutControlItem5.CustomizationFormText = "Descripción";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem5.MaxSize = new System.Drawing.Size(265, 24);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(265, 24);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(265, 24);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.Text = "Tipo";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(54, 13);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(265, 0);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(438, 24);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // ListaPartidaPresupuestalCuenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ListaPartidaPresupuestalCuenta";
            ((System.ComponentModel.ISupportInitialize)(this.lcPrincipal)).EndInit();
            this.lcPrincipal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgPrincipal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxProveedorValidacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcPartidaPresupuestal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPartidoPresupuestalCuenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnidad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sePrecio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grcPartidaPresupuestal;
        private DevExpress.XtraGrid.Views.Grid.GridView grvPartidoPresupuestalCuenta;
        private DevExpress.XtraGrid.Columns.GridColumn gcCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn gcDescripcion;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gcUsuCrea;
        private DevExpress.XtraGrid.Columns.GridColumn gcFechaCrea;
        private DevExpress.XtraGrid.Columns.GridColumn gcAnio;
        private DevExpress.XtraGrid.Columns.GridColumn gcCuenta;
        private DevExpress.XtraEditors.TextEdit txtUnidad;
        private DevExpress.XtraEditors.TextEdit txtDescripcion;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.SpinEdit sePrecio;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraEditors.TextEdit txtTipo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
    }
}