namespace SIA_Presupuesto.WinForm.Adquisicion
{
    partial class ListaCertificacionMaster
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
            this.grcCertificacionMaster = new DevExpress.XtraGrid.GridControl();
            this.grvCertificacionMaster = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTipo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcNumeroReq = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcEstadoReq = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcEsTotalDetallado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rick = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gcEsAnual = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcObservacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcNumReq = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDesPresupuesto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTotalSoles = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTotalDolares = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcNumOrden = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUsuCrea = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFechaCrea = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUsuEdita = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFechaEdita = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lueAnio = new DevExpress.XtraEditors.LookUpEdit();
            this.lciAnio = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcGeneral)).BeginInit();
            this.lcGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgGeneral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcCertificacionMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCertificacionMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rick)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueAnio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciAnio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // lcGeneral
            // 
            this.lcGeneral.Controls.Add(this.lueAnio);
            this.lcGeneral.Controls.Add(this.grcCertificacionMaster);
            // 
            // lcgGeneral
            // 
            this.lcgGeneral.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.lciAnio,
            this.emptySpaceItem1});
            // 
            // grcCertificacionMaster
            // 
            this.grcCertificacionMaster.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.grcCertificacionMaster.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.grcCertificacionMaster.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.grcCertificacionMaster.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.grcCertificacionMaster.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.grcCertificacionMaster.Location = new System.Drawing.Point(12, 36);
            this.grcCertificacionMaster.MainView = this.grvCertificacionMaster;
            this.grcCertificacionMaster.Name = "grcCertificacionMaster";
            this.grcCertificacionMaster.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rick});
            this.grcCertificacionMaster.Size = new System.Drawing.Size(832, 536);
            this.grcCertificacionMaster.TabIndex = 4;
            this.grcCertificacionMaster.UseEmbeddedNavigator = true;
            this.grcCertificacionMaster.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvCertificacionMaster});
            // 
            // grvCertificacionMaster
            // 
            this.grvCertificacionMaster.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcCodigo,
            this.gcTipo,
            this.gcNumeroReq,
            this.gcEstadoReq,
            this.gcEsTotalDetallado,
            this.gcEsAnual,
            this.gcObservacion,
            this.gcNumReq,
            this.gcDesPresupuesto,
            this.gcTotalSoles,
            this.gcTotalDolares,
            this.gcNumOrden,
            this.gcUsuCrea,
            this.gcFechaCrea,
            this.gcUsuEdita,
            this.gcFechaEdita});
            this.grvCertificacionMaster.GridControl = this.grcCertificacionMaster;
            this.grvCertificacionMaster.Name = "grvCertificacionMaster";
            this.grvCertificacionMaster.OptionsBehavior.ReadOnly = true;
            this.grvCertificacionMaster.OptionsSelection.MultiSelect = true;
            this.grvCertificacionMaster.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.grvCertificacionMaster.OptionsSelection.UseIndicatorForSelection = false;
            this.grvCertificacionMaster.OptionsView.ColumnAutoWidth = false;
            this.grvCertificacionMaster.OptionsView.ShowAutoFilterRow = true;
            this.grvCertificacionMaster.OptionsView.ShowFooter = true;
            this.grvCertificacionMaster.OptionsView.ShowGroupPanel = false;
            // 
            // gcCodigo
            // 
            this.gcCodigo.Caption = "Código";
            this.gcCodigo.FieldName = "idCerMas";
            this.gcCodigo.Name = "gcCodigo";
            this.gcCodigo.OptionsColumn.ReadOnly = true;
            this.gcCodigo.Visible = true;
            this.gcCodigo.VisibleIndex = 1;
            this.gcCodigo.Width = 60;
            // 
            // gcTipo
            // 
            this.gcTipo.AppearanceCell.Options.UseTextOptions = true;
            this.gcTipo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcTipo.Caption = "Tipo";
            this.gcTipo.FieldName = "descripcionTipoReq";
            this.gcTipo.Name = "gcTipo";
            this.gcTipo.OptionsColumn.ReadOnly = true;
            this.gcTipo.Visible = true;
            this.gcTipo.VisibleIndex = 2;
            this.gcTipo.Width = 90;
            // 
            // gcNumeroReq
            // 
            this.gcNumeroReq.AppearanceCell.Options.UseTextOptions = true;
            this.gcNumeroReq.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcNumeroReq.Caption = "Nro. Req.";
            this.gcNumeroReq.FieldName = "numeroReq";
            this.gcNumeroReq.Name = "gcNumeroReq";
            this.gcNumeroReq.OptionsColumn.ReadOnly = true;
            this.gcNumeroReq.Visible = true;
            this.gcNumeroReq.VisibleIndex = 3;
            this.gcNumeroReq.Width = 90;
            // 
            // gcEstadoReq
            // 
            this.gcEstadoReq.Caption = "Estado Req. (Forebi/Forese)";
            this.gcEstadoReq.FieldName = "estadoReq";
            this.gcEstadoReq.Name = "gcEstadoReq";
            this.gcEstadoReq.Visible = true;
            this.gcEstadoReq.VisibleIndex = 4;
            this.gcEstadoReq.Width = 150;
            // 
            // gcEsTotalDetallado
            // 
            this.gcEsTotalDetallado.Caption = "¿Es Detallado?";
            this.gcEsTotalDetallado.ColumnEdit = this.rick;
            this.gcEsTotalDetallado.FieldName = "esTotalDetallado";
            this.gcEsTotalDetallado.Name = "gcEsTotalDetallado";
            this.gcEsTotalDetallado.Visible = true;
            this.gcEsTotalDetallado.VisibleIndex = 6;
            this.gcEsTotalDetallado.Width = 80;
            // 
            // rick
            // 
            this.rick.AutoHeight = false;
            this.rick.Name = "rick";
            // 
            // gcEsAnual
            // 
            this.gcEsAnual.Caption = "¿Es Anual?";
            this.gcEsAnual.ColumnEdit = this.rick;
            this.gcEsAnual.FieldName = "esAnual";
            this.gcEsAnual.Name = "gcEsAnual";
            this.gcEsAnual.Visible = true;
            this.gcEsAnual.VisibleIndex = 5;
            this.gcEsAnual.Width = 80;
            // 
            // gcObservacion
            // 
            this.gcObservacion.Caption = "Observación";
            this.gcObservacion.FieldName = "observacion";
            this.gcObservacion.Name = "gcObservacion";
            this.gcObservacion.OptionsColumn.ReadOnly = true;
            this.gcObservacion.Width = 250;
            // 
            // gcNumReq
            // 
            this.gcNumReq.Caption = "Nro Certificación";
            this.gcNumReq.FieldName = "numCertificacion";
            this.gcNumReq.Name = "gcNumReq";
            this.gcNumReq.OptionsColumn.ReadOnly = true;
            this.gcNumReq.Visible = true;
            this.gcNumReq.VisibleIndex = 7;
            this.gcNumReq.Width = 240;
            // 
            // gcDesPresupuesto
            // 
            this.gcDesPresupuesto.Caption = "Presupuesto";
            this.gcDesPresupuesto.FieldName = "desPresupuesto";
            this.gcDesPresupuesto.Name = "gcDesPresupuesto";
            this.gcDesPresupuesto.Visible = true;
            this.gcDesPresupuesto.VisibleIndex = 8;
            this.gcDesPresupuesto.Width = 380;
            // 
            // gcTotalSoles
            // 
            this.gcTotalSoles.Caption = "Total S/";
            this.gcTotalSoles.DisplayFormat.FormatString = "n2";
            this.gcTotalSoles.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcTotalSoles.FieldName = "totalSoles";
            this.gcTotalSoles.Name = "gcTotalSoles";
            this.gcTotalSoles.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "totalSoles", "{0:n2}")});
            this.gcTotalSoles.Visible = true;
            this.gcTotalSoles.VisibleIndex = 9;
            this.gcTotalSoles.Width = 110;
            // 
            // gcTotalDolares
            // 
            this.gcTotalDolares.Caption = "Total $";
            this.gcTotalDolares.DisplayFormat.FormatString = "n2";
            this.gcTotalDolares.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcTotalDolares.FieldName = "totalDolares";
            this.gcTotalDolares.Name = "gcTotalDolares";
            this.gcTotalDolares.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "totalDolares", "{0:n2}")});
            this.gcTotalDolares.Visible = true;
            this.gcTotalDolares.VisibleIndex = 10;
            this.gcTotalDolares.Width = 110;
            // 
            // gcNumOrden
            // 
            this.gcNumOrden.Caption = "Orden C/S";
            this.gcNumOrden.FieldName = "numOrden";
            this.gcNumOrden.Name = "gcNumOrden";
            this.gcNumOrden.Visible = true;
            this.gcNumOrden.VisibleIndex = 11;
            this.gcNumOrden.Width = 250;
            // 
            // gcUsuCrea
            // 
            this.gcUsuCrea.Caption = "Usuario Crea";
            this.gcUsuCrea.FieldName = "usuCrea";
            this.gcUsuCrea.Name = "gcUsuCrea";
            this.gcUsuCrea.OptionsColumn.ReadOnly = true;
            this.gcUsuCrea.Visible = true;
            this.gcUsuCrea.VisibleIndex = 12;
            this.gcUsuCrea.Width = 110;
            // 
            // gcFechaCrea
            // 
            this.gcFechaCrea.Caption = "Fecha Crea";
            this.gcFechaCrea.DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss";
            this.gcFechaCrea.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcFechaCrea.FieldName = "fechaCrea";
            this.gcFechaCrea.Name = "gcFechaCrea";
            this.gcFechaCrea.OptionsColumn.ReadOnly = true;
            this.gcFechaCrea.Visible = true;
            this.gcFechaCrea.VisibleIndex = 13;
            this.gcFechaCrea.Width = 110;
            // 
            // gcUsuEdita
            // 
            this.gcUsuEdita.Caption = "Usuario Edita";
            this.gcUsuEdita.FieldName = "usuEdita";
            this.gcUsuEdita.Name = "gcUsuEdita";
            this.gcUsuEdita.Visible = true;
            this.gcUsuEdita.VisibleIndex = 14;
            this.gcUsuEdita.Width = 110;
            // 
            // gcFechaEdita
            // 
            this.gcFechaEdita.Caption = "Fecha Edita";
            this.gcFechaEdita.DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss";
            this.gcFechaEdita.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcFechaEdita.FieldName = "fechaEdita";
            this.gcFechaEdita.Name = "gcFechaEdita";
            this.gcFechaEdita.Visible = true;
            this.gcFechaEdita.VisibleIndex = 15;
            this.gcFechaEdita.Width = 110;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grcCertificacionMaster;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(836, 540);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // lueAnio
            // 
            this.lueAnio.Location = new System.Drawing.Point(43, 12);
            this.lueAnio.Name = "lueAnio";
            this.lueAnio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueAnio.Size = new System.Drawing.Size(78, 20);
            this.lueAnio.StyleController = this.lcGeneral;
            this.lueAnio.TabIndex = 5;
            this.lueAnio.EditValueChanged += new System.EventHandler(this.lueAnio_EditValueChanged);
            // 
            // lciAnio
            // 
            this.lciAnio.Control = this.lueAnio;
            this.lciAnio.Location = new System.Drawing.Point(0, 0);
            this.lciAnio.Name = "lciAnio";
            this.lciAnio.Size = new System.Drawing.Size(113, 24);
            this.lciAnio.Text = "Año";
            this.lciAnio.TextSize = new System.Drawing.Size(19, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(113, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(723, 24);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // ListaCertificacionMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ListaCertificacionMaster";
            ((System.ComponentModel.ISupportInitialize)(this.lcGeneral)).EndInit();
            this.lcGeneral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgGeneral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcCertificacionMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCertificacionMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rick)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueAnio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciAnio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grcCertificacionMaster;
        private DevExpress.XtraGrid.Views.Grid.GridView grvCertificacionMaster;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gcCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn gcTipo;
        private DevExpress.XtraGrid.Columns.GridColumn gcObservacion;
        private DevExpress.XtraGrid.Columns.GridColumn gcUsuCrea;
        private DevExpress.XtraGrid.Columns.GridColumn gcFechaCrea;
        private DevExpress.XtraEditors.LookUpEdit lueAnio;
        private DevExpress.XtraLayout.LayoutControlItem lciAnio;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gcNumeroReq;
        private DevExpress.XtraGrid.Columns.GridColumn gcUsuEdita;
        private DevExpress.XtraGrid.Columns.GridColumn gcFechaEdita;
        private DevExpress.XtraGrid.Columns.GridColumn gcNumReq;
        private DevExpress.XtraGrid.Columns.GridColumn gcEsTotalDetallado;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rick;
        private DevExpress.XtraGrid.Columns.GridColumn gcEstadoReq;
        private DevExpress.XtraGrid.Columns.GridColumn gcNumOrden;
        private DevExpress.XtraGrid.Columns.GridColumn gcEsAnual;
        private DevExpress.XtraGrid.Columns.GridColumn gcTotalSoles;
        private DevExpress.XtraGrid.Columns.GridColumn gcTotalDolares;
        private DevExpress.XtraGrid.Columns.GridColumn gcDesPresupuesto;
    }
}
