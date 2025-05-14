namespace SIA_Presupuesto.WinForm.Adquisicion
{
    partial class ListaCertificacionRequerimiento
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
            this.grcCertificacionReq = new DevExpress.XtraGrid.GridControl();
            this.grvCertificacionReq = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSigla = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcNumeroReq = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFechaEmision = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTipo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTipoCambio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTotalSoles = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTotalDolares = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSubPresupuesto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPresupuesto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUsuCrea = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFechaCrea = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lueAnio = new DevExpress.XtraEditors.LookUpEdit();
            this.lciAnio = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcGeneral)).BeginInit();
            this.lcGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgGeneral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcCertificacionReq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCertificacionReq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueAnio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciAnio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // lcGeneral
            // 
            this.lcGeneral.Controls.Add(this.lueAnio);
            this.lcGeneral.Controls.Add(this.grcCertificacionReq);
            // 
            // lcgGeneral
            // 
            this.lcgGeneral.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.lciAnio,
            this.emptySpaceItem1});
            // 
            // grcCertificacionReq
            // 
            this.grcCertificacionReq.Location = new System.Drawing.Point(12, 36);
            this.grcCertificacionReq.MainView = this.grvCertificacionReq;
            this.grcCertificacionReq.Name = "grcCertificacionReq";
            this.grcCertificacionReq.Size = new System.Drawing.Size(832, 536);
            this.grcCertificacionReq.TabIndex = 4;
            this.grcCertificacionReq.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvCertificacionReq});
            // 
            // grvCertificacionReq
            // 
            this.grvCertificacionReq.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcCodigo,
            this.gcSigla,
            this.gcNumeroReq,
            this.gcFechaEmision,
            this.gcTipo,
            this.gcTipoCambio,
            this.gcTotalSoles,
            this.gcTotalDolares,
            this.gcSubPresupuesto,
            this.gcPresupuesto,
            this.gcUsuCrea,
            this.gcFechaCrea});
            this.grvCertificacionReq.GridControl = this.grcCertificacionReq;
            this.grvCertificacionReq.Name = "grvCertificacionReq";
            this.grvCertificacionReq.OptionsBehavior.Editable = false;
            this.grvCertificacionReq.OptionsView.ColumnAutoWidth = false;
            this.grvCertificacionReq.OptionsView.ShowAutoFilterRow = true;
            this.grvCertificacionReq.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.grvCertificacionReq_CustomColumnDisplayText);
            // 
            // gcCodigo
            // 
            this.gcCodigo.Caption = "Código";
            this.gcCodigo.FieldName = "idCerReq";
            this.gcCodigo.Name = "gcCodigo";
            this.gcCodigo.OptionsColumn.ReadOnly = true;
            this.gcCodigo.Visible = true;
            this.gcCodigo.VisibleIndex = 0;
            this.gcCodigo.Width = 50;
            // 
            // gcSigla
            // 
            this.gcSigla.Caption = "Número";
            this.gcSigla.FieldName = "sigla";
            this.gcSigla.Name = "gcSigla";
            this.gcSigla.OptionsColumn.ReadOnly = true;
            this.gcSigla.Visible = true;
            this.gcSigla.VisibleIndex = 1;
            this.gcSigla.Width = 120;
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
            this.gcNumeroReq.VisibleIndex = 2;
            this.gcNumeroReq.Width = 100;
            // 
            // gcFechaEmision
            // 
            this.gcFechaEmision.AppearanceCell.Options.UseTextOptions = true;
            this.gcFechaEmision.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcFechaEmision.Caption = "Fecha Emisión";
            this.gcFechaEmision.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.gcFechaEmision.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcFechaEmision.FieldName = "fechaEmision";
            this.gcFechaEmision.Name = "gcFechaEmision";
            this.gcFechaEmision.OptionsColumn.ReadOnly = true;
            this.gcFechaEmision.Visible = true;
            this.gcFechaEmision.VisibleIndex = 3;
            this.gcFechaEmision.Width = 100;
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
            this.gcTipo.VisibleIndex = 4;
            this.gcTipo.Width = 80;
            // 
            // gcTipoCambio
            // 
            this.gcTipoCambio.AppearanceCell.Options.UseTextOptions = true;
            this.gcTipoCambio.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gcTipoCambio.Caption = "T. Cambio";
            this.gcTipoCambio.DisplayFormat.FormatString = "n3";
            this.gcTipoCambio.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcTipoCambio.FieldName = "tipoCambio";
            this.gcTipoCambio.Name = "gcTipoCambio";
            this.gcTipoCambio.OptionsColumn.ReadOnly = true;
            this.gcTipoCambio.Visible = true;
            this.gcTipoCambio.VisibleIndex = 5;
            this.gcTipoCambio.Width = 70;
            // 
            // gcTotalSoles
            // 
            this.gcTotalSoles.AppearanceCell.Options.UseTextOptions = true;
            this.gcTotalSoles.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gcTotalSoles.Caption = "Importe S/";
            this.gcTotalSoles.DisplayFormat.FormatString = "n2";
            this.gcTotalSoles.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcTotalSoles.FieldName = "totalSoles";
            this.gcTotalSoles.Name = "gcTotalSoles";
            this.gcTotalSoles.OptionsColumn.ReadOnly = true;
            this.gcTotalSoles.Visible = true;
            this.gcTotalSoles.VisibleIndex = 6;
            this.gcTotalSoles.Width = 100;
            // 
            // gcTotalDolares
            // 
            this.gcTotalDolares.AppearanceCell.Options.UseTextOptions = true;
            this.gcTotalDolares.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gcTotalDolares.Caption = "Importe $";
            this.gcTotalDolares.FieldName = "totalDolares";
            this.gcTotalDolares.Name = "gcTotalDolares";
            this.gcTotalDolares.OptionsColumn.ReadOnly = true;
            this.gcTotalDolares.Visible = true;
            this.gcTotalDolares.VisibleIndex = 7;
            this.gcTotalDolares.Width = 100;
            // 
            // gcSubPresupuesto
            // 
            this.gcSubPresupuesto.Caption = "SubPresupuesto / Obra";
            this.gcSubPresupuesto.FieldName = "desSubpresupuesto";
            this.gcSubPresupuesto.Name = "gcSubPresupuesto";
            this.gcSubPresupuesto.OptionsColumn.ReadOnly = true;
            this.gcSubPresupuesto.Visible = true;
            this.gcSubPresupuesto.VisibleIndex = 8;
            this.gcSubPresupuesto.Width = 300;
            // 
            // gcPresupuesto
            // 
            this.gcPresupuesto.Caption = "Presupuesto";
            this.gcPresupuesto.FieldName = "desPresupuesto";
            this.gcPresupuesto.Name = "gcPresupuesto";
            this.gcPresupuesto.OptionsColumn.ReadOnly = true;
            this.gcPresupuesto.Visible = true;
            this.gcPresupuesto.VisibleIndex = 9;
            this.gcPresupuesto.Width = 200;
            // 
            // gcUsuCrea
            // 
            this.gcUsuCrea.Caption = "Usuario Crea";
            this.gcUsuCrea.FieldName = "usuCrea";
            this.gcUsuCrea.Name = "gcUsuCrea";
            this.gcUsuCrea.OptionsColumn.ReadOnly = true;
            this.gcUsuCrea.Visible = true;
            this.gcUsuCrea.VisibleIndex = 10;
            this.gcUsuCrea.Width = 100;
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
            this.gcFechaCrea.VisibleIndex = 11;
            this.gcFechaCrea.Width = 110;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grcCertificacionReq;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(836, 540);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // lueAnio
            // 
            this.lueAnio.Location = new System.Drawing.Point(35, 12);
            this.lueAnio.Name = "lueAnio";
            this.lueAnio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueAnio.Size = new System.Drawing.Size(86, 20);
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
            // ListaCertificacionRequerimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ListaCertificacionRequerimiento";
            ((System.ComponentModel.ISupportInitialize)(this.lcGeneral)).EndInit();
            this.lcGeneral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgGeneral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcCertificacionReq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCertificacionReq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueAnio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciAnio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grcCertificacionReq;
        private DevExpress.XtraGrid.Views.Grid.GridView grvCertificacionReq;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gcCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn gcFechaEmision;
        private DevExpress.XtraGrid.Columns.GridColumn gcTipo;
        private DevExpress.XtraGrid.Columns.GridColumn gcUsuCrea;
        private DevExpress.XtraGrid.Columns.GridColumn gcFechaCrea;
        private DevExpress.XtraGrid.Columns.GridColumn gcSigla;
        private DevExpress.XtraEditors.LookUpEdit lueAnio;
        private DevExpress.XtraLayout.LayoutControlItem lciAnio;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gcNumeroReq;
        private DevExpress.XtraGrid.Columns.GridColumn gcTotalSoles;
        private DevExpress.XtraGrid.Columns.GridColumn gcTotalDolares;
        private DevExpress.XtraGrid.Columns.GridColumn gcPresupuesto;
        private DevExpress.XtraGrid.Columns.GridColumn gcTipoCambio;
        private DevExpress.XtraGrid.Columns.GridColumn gcSubPresupuesto;
    }
}
