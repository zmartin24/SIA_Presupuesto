namespace SIA_Presupuesto.WinForm.Adquisicion
{
    partial class ListaCertificacionDetalle
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
            this.riseImp = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.grcCertificacionDetalle = new DevExpress.XtraGrid.GridControl();
            this.grvCertificacionDetalle = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcReq = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDireccion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSubDireccion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCantidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPrecio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSubTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDesPresupuesto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcPrincipal)).BeginInit();
            this.lcPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgPrincipal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxProveedorValidacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riseImp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcCertificacionDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCertificacionDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // lcPrincipal
            // 
            this.lcPrincipal.Controls.Add(this.grcCertificacionDetalle);
            this.lcPrincipal.Size = new System.Drawing.Size(820, 552);
            // 
            // lcgPrincipal
            // 
            this.lcgPrincipal.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.lcgPrincipal.Size = new System.Drawing.Size(820, 552);
            // 
            // riseImp
            // 
            this.riseImp.AutoHeight = false;
            this.riseImp.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.riseImp.Name = "riseImp";
            // 
            // grcCertificacionDetalle
            // 
            this.grcCertificacionDetalle.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.grcCertificacionDetalle.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.grcCertificacionDetalle.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.grcCertificacionDetalle.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.grcCertificacionDetalle.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.grcCertificacionDetalle.Location = new System.Drawing.Point(12, 12);
            this.grcCertificacionDetalle.MainView = this.grvCertificacionDetalle;
            this.grcCertificacionDetalle.Name = "grcCertificacionDetalle";
            this.grcCertificacionDetalle.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riseImp});
            this.grcCertificacionDetalle.Size = new System.Drawing.Size(796, 528);
            this.grcCertificacionDetalle.TabIndex = 4;
            this.grcCertificacionDetalle.UseEmbeddedNavigator = true;
            this.grcCertificacionDetalle.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvCertificacionDetalle});
            // 
            // grvCertificacionDetalle
            // 
            this.grvCertificacionDetalle.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.grvCertificacionDetalle.Appearance.GroupRow.Options.UseFont = true;
            this.grvCertificacionDetalle.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcCodigo,
            this.gcReq,
            this.gcDescripcion,
            this.gcDireccion,
            this.gcSubDireccion,
            this.gcCantidad,
            this.gcPrecio,
            this.gcSubTotal,
            this.gcDesPresupuesto});
            this.grvCertificacionDetalle.GridControl = this.grcCertificacionDetalle;
            this.grvCertificacionDetalle.Name = "grvCertificacionDetalle";
            this.grvCertificacionDetalle.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvCertificacionDetalle.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Classic;
            this.grvCertificacionDetalle.OptionsPrint.ExpandAllDetails = true;
            this.grvCertificacionDetalle.OptionsPrint.PrintDetails = true;
            this.grvCertificacionDetalle.OptionsView.ColumnAutoWidth = false;
            this.grvCertificacionDetalle.OptionsView.ShowAutoFilterRow = true;
            this.grvCertificacionDetalle.OptionsView.ShowFooter = true;
            this.grvCertificacionDetalle.OptionsView.ShowGroupPanel = false;
            // 
            // gcCodigo
            // 
            this.gcCodigo.AppearanceCell.BackColor = System.Drawing.Color.Transparent;
            this.gcCodigo.AppearanceCell.Options.UseBackColor = true;
            this.gcCodigo.Caption = "Codigo";
            this.gcCodigo.FieldName = "idCerDet";
            this.gcCodigo.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gcCodigo.Name = "gcCodigo";
            this.gcCodigo.OptionsColumn.AllowEdit = false;
            this.gcCodigo.Visible = true;
            this.gcCodigo.VisibleIndex = 0;
            this.gcCodigo.Width = 50;
            // 
            // gcReq
            // 
            this.gcReq.Caption = "Requerimiento";
            this.gcReq.FieldName = "numero";
            this.gcReq.Name = "gcReq";
            this.gcReq.Visible = true;
            this.gcReq.VisibleIndex = 1;
            this.gcReq.Width = 80;
            // 
            // gcDescripcion
            // 
            this.gcDescripcion.AppearanceCell.BackColor = System.Drawing.Color.Transparent;
            this.gcDescripcion.AppearanceCell.Options.UseBackColor = true;
            this.gcDescripcion.Caption = "Descripción";
            this.gcDescripcion.FieldName = "descripcion";
            this.gcDescripcion.Name = "gcDescripcion";
            this.gcDescripcion.OptionsColumn.AllowEdit = false;
            this.gcDescripcion.Visible = true;
            this.gcDescripcion.VisibleIndex = 2;
            this.gcDescripcion.Width = 200;
            // 
            // gcDireccion
            // 
            this.gcDireccion.Caption = "Dirección";
            this.gcDireccion.FieldName = "direccion";
            this.gcDireccion.Name = "gcDireccion";
            this.gcDireccion.OptionsColumn.AllowEdit = false;
            this.gcDireccion.Visible = true;
            this.gcDireccion.VisibleIndex = 3;
            this.gcDireccion.Width = 150;
            // 
            // gcSubDireccion
            // 
            this.gcSubDireccion.Caption = "Subdirección";
            this.gcSubDireccion.FieldName = "subdireccion";
            this.gcSubDireccion.Name = "gcSubDireccion";
            this.gcSubDireccion.OptionsColumn.AllowEdit = false;
            this.gcSubDireccion.Visible = true;
            this.gcSubDireccion.VisibleIndex = 4;
            this.gcSubDireccion.Width = 150;
            // 
            // gcCantidad
            // 
            this.gcCantidad.AppearanceCell.Options.UseTextOptions = true;
            this.gcCantidad.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gcCantidad.Caption = "Cantidad";
            this.gcCantidad.DisplayFormat.FormatString = "n2";
            this.gcCantidad.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcCantidad.FieldName = "cantidad";
            this.gcCantidad.Name = "gcCantidad";
            this.gcCantidad.Visible = true;
            this.gcCantidad.VisibleIndex = 6;
            this.gcCantidad.Width = 60;
            // 
            // gcPrecio
            // 
            this.gcPrecio.AppearanceCell.Options.UseTextOptions = true;
            this.gcPrecio.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gcPrecio.Caption = "Precio";
            this.gcPrecio.DisplayFormat.FormatString = "n2";
            this.gcPrecio.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcPrecio.FieldName = "precio";
            this.gcPrecio.Name = "gcPrecio";
            this.gcPrecio.Visible = true;
            this.gcPrecio.VisibleIndex = 5;
            this.gcPrecio.Width = 60;
            // 
            // gcSubTotal
            // 
            this.gcSubTotal.AppearanceCell.Options.UseTextOptions = true;
            this.gcSubTotal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gcSubTotal.Caption = "Sub Total";
            this.gcSubTotal.DisplayFormat.FormatString = "n2";
            this.gcSubTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcSubTotal.FieldName = "subTotal";
            this.gcSubTotal.Name = "gcSubTotal";
            this.gcSubTotal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "subTotal", "Total = {0:n2}")});
            this.gcSubTotal.Visible = true;
            this.gcSubTotal.VisibleIndex = 7;
            this.gcSubTotal.Width = 150;
            // 
            // gcDesPresupuesto
            // 
            this.gcDesPresupuesto.Caption = "Det. Presupuesto";
            this.gcDesPresupuesto.FieldName = "desPresupuesto";
            this.gcDesPresupuesto.Name = "gcDesPresupuesto";
            this.gcDesPresupuesto.Visible = true;
            this.gcDesPresupuesto.VisibleIndex = 8;
            this.gcDesPresupuesto.Width = 200;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grcCertificacionDetalle;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(800, 532);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // ListaCertificacionDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ListaCertificacionDetalle";
            this.Size = new System.Drawing.Size(820, 552);
            ((System.ComponentModel.ISupportInitialize)(this.lcPrincipal)).EndInit();
            this.lcPrincipal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgPrincipal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxProveedorValidacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riseImp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcCertificacionDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCertificacionDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grcCertificacionDetalle;
        private DevExpress.XtraGrid.Views.Grid.GridView grvCertificacionDetalle;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gcCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn gcDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn gcDireccion;
        private DevExpress.XtraGrid.Columns.GridColumn gcSubDireccion;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit riseImp;
        private DevExpress.XtraGrid.Columns.GridColumn gcReq;
        private DevExpress.XtraGrid.Columns.GridColumn gcCantidad;
        private DevExpress.XtraGrid.Columns.GridColumn gcDesPresupuesto;
        private DevExpress.XtraGrid.Columns.GridColumn gcPrecio;
        private DevExpress.XtraGrid.Columns.GridColumn gcSubTotal;
    }
}
