namespace SIA_Presupuesto.WinForm.Mantenimiento
{
    partial class ListaPartidaPresupuestal
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
            this.grvPartidoPresupuestal = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTipo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUnidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPrecio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcAnio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCuenta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUsuCrea = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFechaCrea = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcGeneral)).BeginInit();
            this.lcGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgGeneral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcPartidaPresupuestal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPartidoPresupuestal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // lcGeneral
            // 
            this.lcGeneral.Controls.Add(this.grcPartidaPresupuestal);
            // 
            // lcgGeneral
            // 
            this.lcgGeneral.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            // 
            // grcPartidaPresupuestal
            // 
            this.grcPartidaPresupuestal.Location = new System.Drawing.Point(12, 12);
            this.grcPartidaPresupuestal.MainView = this.grvPartidoPresupuestal;
            this.grcPartidaPresupuestal.Name = "grcPartidaPresupuestal";
            this.grcPartidaPresupuestal.Size = new System.Drawing.Size(832, 560);
            this.grcPartidaPresupuestal.TabIndex = 5;
            this.grcPartidaPresupuestal.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvPartidoPresupuestal});
            // 
            // grvPartidoPresupuestal
            // 
            this.grvPartidoPresupuestal.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcCodigo,
            this.gcTipo,
            this.gcDescripcion,
            this.gcUnidad,
            this.gcPrecio,
            this.gcCuenta,
            this.gcAnio,
            this.gcUsuCrea,
            this.gcFechaCrea});
            this.grvPartidoPresupuestal.GridControl = this.grcPartidaPresupuestal;
            this.grvPartidoPresupuestal.GroupCount = 1;
            this.grvPartidoPresupuestal.Name = "grvPartidoPresupuestal";
            this.grvPartidoPresupuestal.OptionsBehavior.Editable = false;
            this.grvPartidoPresupuestal.OptionsView.ColumnAutoWidth = false;
            this.grvPartidoPresupuestal.OptionsView.ShowAutoFilterRow = true;
            this.grvPartidoPresupuestal.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gcTipo, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gcCodigo
            // 
            this.gcCodigo.Caption = "Id";
            this.gcCodigo.FieldName = "idParPre";
            this.gcCodigo.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.gcCodigo.Name = "gcCodigo";
            this.gcCodigo.Width = 50;
            // 
            // gcTipo
            // 
            this.gcTipo.Caption = "Tipo";
            this.gcTipo.FieldName = "tipo";
            this.gcTipo.Name = "gcTipo";
            this.gcTipo.Visible = true;
            this.gcTipo.VisibleIndex = 0;
            this.gcTipo.Width = 80;
            // 
            // gcDescripcion
            // 
            this.gcDescripcion.Caption = "Descripción";
            this.gcDescripcion.FieldName = "descripcion";
            this.gcDescripcion.Name = "gcDescripcion";
            this.gcDescripcion.Visible = true;
            this.gcDescripcion.VisibleIndex = 0;
            this.gcDescripcion.Width = 500;
            // 
            // gcUnidad
            // 
            this.gcUnidad.AppearanceCell.Options.UseTextOptions = true;
            this.gcUnidad.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcUnidad.Caption = "Unidad";
            this.gcUnidad.FieldName = "und";
            this.gcUnidad.Name = "gcUnidad";
            this.gcUnidad.Visible = true;
            this.gcUnidad.VisibleIndex = 1;
            this.gcUnidad.Width = 70;
            // 
            // gcPrecio
            // 
            this.gcPrecio.Caption = "Precio";
            this.gcPrecio.DisplayFormat.FormatString = "n2";
            this.gcPrecio.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcPrecio.FieldName = "precio";
            this.gcPrecio.Name = "gcPrecio";
            this.gcPrecio.Visible = true;
            this.gcPrecio.VisibleIndex = 2;
            this.gcPrecio.Width = 100;
            // 
            // gcAnio
            // 
            this.gcAnio.AppearanceCell.Options.UseTextOptions = true;
            this.gcAnio.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcAnio.Caption = "Año Cuenta";
            this.gcAnio.FieldName = "anio";
            this.gcAnio.Name = "gcAnio";
            this.gcAnio.Visible = true;
            this.gcAnio.VisibleIndex = 4;
            // 
            // gcCuenta
            // 
            this.gcCuenta.Caption = "Cuenta";
            this.gcCuenta.FieldName = "numCuenta";
            this.gcCuenta.Name = "gcCuenta";
            this.gcCuenta.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.BeginsWith;
            this.gcCuenta.Visible = true;
            this.gcCuenta.VisibleIndex = 3;
            // 
            // gcUsuCrea
            // 
            this.gcUsuCrea.Caption = "Usuario Crea";
            this.gcUsuCrea.FieldName = "usuCrea";
            this.gcUsuCrea.Name = "gcUsuCrea";
            this.gcUsuCrea.Visible = true;
            this.gcUsuCrea.VisibleIndex = 5;
            this.gcUsuCrea.Width = 128;
            // 
            // gcFechaCrea
            // 
            this.gcFechaCrea.Caption = "Fecha Crea";
            this.gcFechaCrea.FieldName = "fechaCrea";
            this.gcFechaCrea.Name = "gcFechaCrea";
            this.gcFechaCrea.Visible = true;
            this.gcFechaCrea.VisibleIndex = 6;
            this.gcFechaCrea.Width = 113;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grcPartidaPresupuestal;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(836, 564);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // ListaPartidaPresupuestal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ListaPartidaPresupuestal";
            ((System.ComponentModel.ISupportInitialize)(this.lcGeneral)).EndInit();
            this.lcGeneral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgGeneral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcPartidaPresupuestal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPartidoPresupuestal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grcPartidaPresupuestal;
        private DevExpress.XtraGrid.Views.Grid.GridView grvPartidoPresupuestal;
        private DevExpress.XtraGrid.Columns.GridColumn gcCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn gcDescripcion;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gcUsuCrea;
        private DevExpress.XtraGrid.Columns.GridColumn gcFechaCrea;
        private DevExpress.XtraGrid.Columns.GridColumn gcTipo;
        private DevExpress.XtraGrid.Columns.GridColumn gcUnidad;
        private DevExpress.XtraGrid.Columns.GridColumn gcPrecio;
        private DevExpress.XtraGrid.Columns.GridColumn gcAnio;
        private DevExpress.XtraGrid.Columns.GridColumn gcCuenta;
    }
}