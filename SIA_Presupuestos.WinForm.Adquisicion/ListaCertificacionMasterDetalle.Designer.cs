namespace SIA_Presupuesto.WinForm.Adquisicion
{
    partial class ListaCertificacionMasterDetalle
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.grvDetalle = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gbcDescripcion = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bgcUnidad = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bgcPrecio = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.riseImp = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.bgcCantidad = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bgcSubtotal = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bgcCuentaPresupuesto = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bgcIdDetalle = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bgcDesAmpliacion = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.grcCertificacion = new DevExpress.XtraGrid.GridControl();
            this.grvCertificacionReq = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSiga = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTipo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcNumReq = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPresupuesto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSubpresupuesto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSoles = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDolares = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUsuCrea = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFechaCrea = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUsuEdita = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFechaEdita = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDesEstado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcPrincipal)).BeginInit();
            this.lcPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgPrincipal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxProveedorValidacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riseImp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcCertificacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCertificacionReq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // lcPrincipal
            // 
            this.lcPrincipal.Controls.Add(this.grcCertificacion);
            this.lcPrincipal.Size = new System.Drawing.Size(820, 552);
            // 
            // lcgPrincipal
            // 
            this.lcgPrincipal.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.lcgPrincipal.Size = new System.Drawing.Size(820, 552);
            // 
            // grvDetalle
            // 
            this.grvDetalle.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1,
            this.gridBand2,
            this.gridBand3});
            this.grvDetalle.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.bgcIdDetalle,
            this.bgcDesAmpliacion,
            this.gbcDescripcion,
            this.bgcUnidad,
            this.bgcCantidad,
            this.bgcPrecio,
            this.bgcSubtotal,
            this.bgcCuentaPresupuesto});
            this.grvDetalle.DetailHeight = 600;
            this.grvDetalle.GridControl = this.grcCertificacion;
            this.grvDetalle.GroupCount = 1;
            this.grvDetalle.Name = "grvDetalle";
            this.grvDetalle.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvDetalle.OptionsBehavior.ReadOnly = true;
            this.grvDetalle.OptionsView.ColumnAutoWidth = false;
            this.grvDetalle.OptionsView.ShowAutoFilterRow = true;
            this.grvDetalle.OptionsView.ShowGroupPanel = false;
            this.grvDetalle.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.bgcDesAmpliacion, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridBand1
            // 
            this.gridBand1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand1.Caption = "Principal";
            this.gridBand1.Columns.Add(this.gbcDescripcion);
            this.gridBand1.Columns.Add(this.bgcUnidad);
            this.gridBand1.Columns.Add(this.bgcPrecio);
            this.gridBand1.Columns.Add(this.bgcCantidad);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.VisibleIndex = 0;
            this.gridBand1.Width = 580;
            // 
            // gbcDescripcion
            // 
            this.gbcDescripcion.Caption = "Descripción";
            this.gbcDescripcion.FieldName = "descripcion";
            this.gbcDescripcion.Name = "gbcDescripcion";
            this.gbcDescripcion.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.True;
            this.gbcDescripcion.Visible = true;
            this.gbcDescripcion.Width = 300;
            // 
            // bgcUnidad
            // 
            this.bgcUnidad.Caption = "Unidad";
            this.bgcUnidad.FieldName = "unidad";
            this.bgcUnidad.Name = "bgcUnidad";
            this.bgcUnidad.Visible = true;
            this.bgcUnidad.Width = 100;
            // 
            // bgcPrecio
            // 
            this.bgcPrecio.Caption = "Precio";
            this.bgcPrecio.ColumnEdit = this.riseImp;
            this.bgcPrecio.FieldName = "precio";
            this.bgcPrecio.Name = "bgcPrecio";
            this.bgcPrecio.Visible = true;
            this.bgcPrecio.Width = 120;
            // 
            // riseImp
            // 
            this.riseImp.AutoHeight = false;
            this.riseImp.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.riseImp.Name = "riseImp";
            // 
            // bgcCantidad
            // 
            this.bgcCantidad.Caption = "Cantidad";
            this.bgcCantidad.FieldName = "cantidad";
            this.bgcCantidad.Name = "bgcCantidad";
            this.bgcCantidad.Visible = true;
            this.bgcCantidad.Width = 110;
            // 
            // gridBand2
            // 
            this.gridBand2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand2.Caption = "Total";
            this.gridBand2.Columns.Add(this.bgcSubtotal);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.VisibleIndex = 1;
            this.gridBand2.Width = 80;
            // 
            // bgcSubtotal
            // 
            this.bgcSubtotal.Caption = "Sub. Total";
            this.bgcSubtotal.DisplayFormat.FormatString = "n2";
            this.bgcSubtotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.bgcSubtotal.FieldName = "subTotal";
            this.bgcSubtotal.Name = "bgcSubtotal";
            this.bgcSubtotal.Visible = true;
            this.bgcSubtotal.Width = 120;
            // 
            // gridBand3
            // 
            this.gridBand3.Caption = "Presupuesto";
            this.gridBand3.Columns.Add(this.bgcCuentaPresupuesto);
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.VisibleIndex = 2;
            this.gridBand3.Width = 250;
            // 
            // bgcCuentaPresupuesto
            // 
            this.bgcCuentaPresupuesto.Caption = "Det. Presupuesto";
            this.bgcCuentaPresupuesto.FieldName = "desPresupuesto";
            this.bgcCuentaPresupuesto.Name = "bgcCuentaPresupuesto";
            this.bgcCuentaPresupuesto.Visible = true;
            this.bgcCuentaPresupuesto.Width = 300;
            // 
            // bgcIdDetalle
            // 
            this.bgcIdDetalle.Caption = "Codigo";
            this.bgcIdDetalle.FieldName = "idCerDet";
            this.bgcIdDetalle.Name = "bgcIdDetalle";
            // 
            // bgcDesAmpliacion
            // 
            this.bgcDesAmpliacion.Caption = "Tipo";
            this.bgcDesAmpliacion.FieldName = "desAmpliacion";
            this.bgcDesAmpliacion.Name = "bgcDesAmpliacion";
            this.bgcDesAmpliacion.Visible = true;
            this.bgcDesAmpliacion.Width = 150;
            // 
            // grcCertificacion
            // 
            this.grcCertificacion.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.grcCertificacion.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.grcCertificacion.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.grcCertificacion.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.grcCertificacion.EmbeddedNavigator.Buttons.Remove.Visible = false;
            gridLevelNode1.LevelTemplate = this.grvDetalle;
            gridLevelNode1.RelationName = "CertificacionDetallePres";
            this.grcCertificacion.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.grcCertificacion.Location = new System.Drawing.Point(12, 12);
            this.grcCertificacion.MainView = this.grvCertificacionReq;
            this.grcCertificacion.Name = "grcCertificacion";
            this.grcCertificacion.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riseImp});
            this.grcCertificacion.Size = new System.Drawing.Size(796, 528);
            this.grcCertificacion.TabIndex = 4;
            this.grcCertificacion.UseEmbeddedNavigator = true;
            this.grcCertificacion.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvCertificacionReq,
            this.grvDetalle});
            // 
            // grvCertificacionReq
            // 
            this.grvCertificacionReq.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.grvCertificacionReq.Appearance.GroupRow.Options.UseFont = true;
            this.grvCertificacionReq.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcCodigo,
            this.gcFecha,
            this.gcSiga,
            this.gcTipo,
            this.gcNumReq,
            this.gcPresupuesto,
            this.gcSubpresupuesto,
            this.gcTC,
            this.gcSoles,
            this.gcDolares,
            this.gcUsuCrea,
            this.gcDesEstado,
            this.gcFechaCrea,
            this.gcUsuEdita,
            this.gcFechaEdita});
            this.grvCertificacionReq.GridControl = this.grcCertificacion;
            this.grvCertificacionReq.GroupCount = 1;
            this.grvCertificacionReq.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "totalSoles", null, "Total: {0:n}")});
            this.grvCertificacionReq.Name = "grvCertificacionReq";
            this.grvCertificacionReq.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvCertificacionReq.OptionsBehavior.ReadOnly = true;
            this.grvCertificacionReq.OptionsDetail.AllowOnlyOneMasterRowExpanded = true;
            this.grvCertificacionReq.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Classic;
            this.grvCertificacionReq.OptionsDetail.ShowDetailTabs = false;
            this.grvCertificacionReq.OptionsPrint.ExpandAllDetails = true;
            this.grvCertificacionReq.OptionsPrint.PrintDetails = true;
            this.grvCertificacionReq.OptionsView.ColumnAutoWidth = false;
            this.grvCertificacionReq.OptionsView.ShowAutoFilterRow = true;
            this.grvCertificacionReq.OptionsView.ShowFooter = true;
            this.grvCertificacionReq.OptionsView.ShowGroupPanel = false;
            this.grvCertificacionReq.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gcSiga, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.grvCertificacionReq.MasterRowExpanded += new DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventHandler(this.grvCertificacionReq_MasterRowExpanded);
            // 
            // gcCodigo
            // 
            this.gcCodigo.AppearanceCell.BackColor = System.Drawing.Color.LightBlue;
            this.gcCodigo.AppearanceCell.Options.UseBackColor = true;
            this.gcCodigo.Caption = "Codigo";
            this.gcCodigo.FieldName = "idCerReq";
            this.gcCodigo.Name = "gcCodigo";
            this.gcCodigo.Visible = true;
            this.gcCodigo.VisibleIndex = 0;
            this.gcCodigo.Width = 80;
            // 
            // gcFecha
            // 
            this.gcFecha.AppearanceCell.Options.UseTextOptions = true;
            this.gcFecha.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcFecha.Caption = "Fecha Emisión";
            this.gcFecha.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.gcFecha.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcFecha.FieldName = "fechaEmision";
            this.gcFecha.Name = "gcFecha";
            this.gcFecha.Visible = true;
            this.gcFecha.VisibleIndex = 1;
            this.gcFecha.Width = 80;
            // 
            // gcSiga
            // 
            this.gcSiga.Caption = "Nro";
            this.gcSiga.FieldName = "sigla";
            this.gcSiga.Name = "gcSiga";
            this.gcSiga.Visible = true;
            this.gcSiga.VisibleIndex = 1;
            // 
            // gcTipo
            // 
            this.gcTipo.Caption = "Tipo";
            this.gcTipo.FieldName = "descripcionTipoReq";
            this.gcTipo.Name = "gcTipo";
            this.gcTipo.OptionsColumn.AllowEdit = false;
            this.gcTipo.Visible = true;
            this.gcTipo.VisibleIndex = 2;
            this.gcTipo.Width = 80;
            // 
            // gcNumReq
            // 
            this.gcNumReq.AppearanceCell.Options.UseTextOptions = true;
            this.gcNumReq.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcNumReq.Caption = "Nro. Req.";
            this.gcNumReq.FieldName = "numeroReq";
            this.gcNumReq.Name = "gcNumReq";
            this.gcNumReq.Visible = true;
            this.gcNumReq.VisibleIndex = 3;
            this.gcNumReq.Width = 100;
            // 
            // gcPresupuesto
            // 
            this.gcPresupuesto.Caption = "Presupuesto";
            this.gcPresupuesto.FieldName = "desPresupuesto";
            this.gcPresupuesto.Name = "gcPresupuesto";
            this.gcPresupuesto.Visible = true;
            this.gcPresupuesto.VisibleIndex = 4;
            this.gcPresupuesto.Width = 350;
            // 
            // gcSubpresupuesto
            // 
            this.gcSubpresupuesto.Caption = "Presupuesto Mensual";
            this.gcSubpresupuesto.FieldName = "desSubpresupuesto";
            this.gcSubpresupuesto.Name = "gcSubpresupuesto";
            this.gcSubpresupuesto.Visible = true;
            this.gcSubpresupuesto.VisibleIndex = 5;
            this.gcSubpresupuesto.Width = 250;
            // 
            // gcTC
            // 
            this.gcTC.AppearanceCell.Options.UseTextOptions = true;
            this.gcTC.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gcTC.Caption = "Tipo Cambio";
            this.gcTC.DisplayFormat.FormatString = "n3";
            this.gcTC.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcTC.FieldName = "tipoCambio";
            this.gcTC.Name = "gcTC";
            this.gcTC.Visible = true;
            this.gcTC.VisibleIndex = 6;
            // 
            // gcSoles
            // 
            this.gcSoles.Caption = "T. Soles";
            this.gcSoles.DisplayFormat.FormatString = "{0:n}";
            this.gcSoles.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcSoles.FieldName = "totalSoles";
            this.gcSoles.Name = "gcSoles";
            this.gcSoles.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "totalSoles", "{0:n}")});
            this.gcSoles.Visible = true;
            this.gcSoles.VisibleIndex = 7;
            this.gcSoles.Width = 100;
            // 
            // gcDolares
            // 
            this.gcDolares.Caption = "T.Dolares";
            this.gcDolares.DisplayFormat.FormatString = "{0:n}";
            this.gcDolares.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcDolares.FieldName = "totalDolares";
            this.gcDolares.Name = "gcDolares";
            this.gcDolares.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "totalDolares", "{0:n}")});
            this.gcDolares.Visible = true;
            this.gcDolares.VisibleIndex = 8;
            this.gcDolares.Width = 100;
            // 
            // gcUsuCrea
            // 
            this.gcUsuCrea.Caption = "Usuario Crea";
            this.gcUsuCrea.FieldName = "usuCrea";
            this.gcUsuCrea.Name = "gcUsuCrea";
            this.gcUsuCrea.Visible = true;
            this.gcUsuCrea.VisibleIndex = 9;
            // 
            // gcFechaCrea
            // 
            this.gcFechaCrea.Caption = "Fecha Crea ";
            this.gcFechaCrea.DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss tt";
            this.gcFechaCrea.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcFechaCrea.FieldName = "fechaCrea";
            this.gcFechaCrea.Name = "gcFechaCrea";
            this.gcFechaCrea.Visible = true;
            this.gcFechaCrea.VisibleIndex = 11;
            this.gcFechaCrea.Width = 140;
            // 
            // gcUsuEdita
            // 
            this.gcUsuEdita.Caption = "Usuario Edita";
            this.gcUsuEdita.FieldName = "usuEdita";
            this.gcUsuEdita.Name = "gcUsuEdita";
            this.gcUsuEdita.Visible = true;
            this.gcUsuEdita.VisibleIndex = 12;
            // 
            // gcFechaEdita
            // 
            this.gcFechaEdita.Caption = "Fecha Edita";
            this.gcFechaEdita.DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss tt";
            this.gcFechaEdita.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcFechaEdita.FieldName = "fechaEdita";
            this.gcFechaEdita.Name = "gcFechaEdita";
            this.gcFechaEdita.Visible = true;
            this.gcFechaEdita.VisibleIndex = 13;
            this.gcFechaEdita.Width = 140;
            // 
            // gcDesEstado
            // 
            this.gcDesEstado.Caption = "Estado";
            this.gcDesEstado.FieldName = "desEstado";
            this.gcDesEstado.Name = "gcDesEstado";
            this.gcDesEstado.Visible = true;
            this.gcDesEstado.VisibleIndex = 10;
            this.gcDesEstado.Width = 90;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grcCertificacion;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(800, 532);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // ListaCertificacionMasterDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ListaCertificacionMasterDetalle";
            this.Size = new System.Drawing.Size(820, 552);
            ((System.ComponentModel.ISupportInitialize)(this.lcPrincipal)).EndInit();
            this.lcPrincipal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgPrincipal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxProveedorValidacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riseImp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcCertificacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCertificacionReq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grcCertificacion;
        private DevExpress.XtraGrid.Views.Grid.GridView grvCertificacionReq;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gcCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn gcTipo;
        private DevExpress.XtraGrid.Columns.GridColumn gcPresupuesto;
        private DevExpress.XtraGrid.Columns.GridColumn gcNumReq;
        private DevExpress.XtraGrid.Columns.GridColumn gcSoles;
        private DevExpress.XtraGrid.Columns.GridColumn gcDolares;
        private DevExpress.XtraGrid.Columns.GridColumn gcSubpresupuesto;
        private DevExpress.XtraGrid.Columns.GridColumn gcSiga;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit riseImp;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView grvDetalle;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gbcDescripcion;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bgcUnidad;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bgcCantidad;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bgcPrecio;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bgcSubtotal;
        private DevExpress.XtraGrid.Columns.GridColumn gcTC;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bgcCuentaPresupuesto;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bgcIdDetalle;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bgcDesAmpliacion;
        private DevExpress.XtraGrid.Columns.GridColumn gcFecha;
        private DevExpress.XtraGrid.Columns.GridColumn gcUsuCrea;
        private DevExpress.XtraGrid.Columns.GridColumn gcFechaCrea;
        private DevExpress.XtraGrid.Columns.GridColumn gcUsuEdita;
        private DevExpress.XtraGrid.Columns.GridColumn gcFechaEdita;
        private DevExpress.XtraGrid.Columns.GridColumn gcDesEstado;
    }
}
