namespace SIA_Presupuesto.WinForm.Programacion
{
    partial class ListaRequerimientoMensualBienServicio
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListaRequerimientoMensualBienServicio));
            this.grcRequerimiento = new DevExpress.XtraGrid.GridControl();
            this.grvRequerimiento = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTipo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcArea = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSubdireccion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDireccion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFechaEmision = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcMoneda = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDesEstado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repCboEstado = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.svgImageCollection1 = new DevExpress.Utils.SvgImageCollection(this.components);
            this.gcFechaAprobacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lueAnio = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lueMes = new DevExpress.XtraEditors.LookUpEdit();
            this.lciMes = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcGeneral)).BeginInit();
            this.lcGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgGeneral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcRequerimiento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvRequerimiento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCboEstado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueAnio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciMes)).BeginInit();
            this.SuspendLayout();
            // 
            // lcGeneral
            // 
            this.lcGeneral.Controls.Add(this.lueAnio);
            this.lcGeneral.Controls.Add(this.grcRequerimiento);
            this.lcGeneral.Controls.Add(this.lueMes);
            this.lcGeneral.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(744, 305, 450, 400);
            // 
            // lcgGeneral
            // 
            this.lcgGeneral.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.emptySpaceItem1,
            this.lciMes});
            this.lcgGeneral.Name = "Root";
            // 
            // grcRequerimiento
            // 
            this.grcRequerimiento.EmbeddedNavigator.Buttons.Append.Enabled = false;
            this.grcRequerimiento.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.grcRequerimiento.EmbeddedNavigator.Buttons.CancelEdit.Enabled = false;
            this.grcRequerimiento.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.grcRequerimiento.EmbeddedNavigator.Buttons.Edit.Enabled = false;
            this.grcRequerimiento.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.grcRequerimiento.EmbeddedNavigator.Buttons.EndEdit.Enabled = false;
            this.grcRequerimiento.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.grcRequerimiento.EmbeddedNavigator.Buttons.Remove.Enabled = false;
            this.grcRequerimiento.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.grcRequerimiento.Location = new System.Drawing.Point(12, 36);
            this.grcRequerimiento.MainView = this.grvRequerimiento;
            this.grcRequerimiento.Name = "grcRequerimiento";
            this.grcRequerimiento.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repCboEstado});
            this.grcRequerimiento.Size = new System.Drawing.Size(832, 536);
            this.grcRequerimiento.TabIndex = 4;
            this.grcRequerimiento.UseEmbeddedNavigator = true;
            this.grcRequerimiento.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvRequerimiento});
            // 
            // grvRequerimiento
            // 
            this.grvRequerimiento.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcCodigo,
            this.gcTipo,
            this.gcDescripcion,
            this.gcArea,
            this.gcSubdireccion,
            this.gcDireccion,
            this.gcFechaEmision,
            this.gcMoneda,
            this.gcTotal,
            this.gcDesEstado,
            this.gcFechaAprobacion});
            this.grvRequerimiento.GridControl = this.grcRequerimiento;
            this.grvRequerimiento.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total", null, "(Total = {0:n2})")});
            this.grvRequerimiento.Name = "grvRequerimiento";
            this.grvRequerimiento.OptionsBehavior.ReadOnly = true;
            this.grvRequerimiento.OptionsView.ColumnAutoWidth = false;
            this.grvRequerimiento.OptionsView.ShowAutoFilterRow = true;
            this.grvRequerimiento.FilterPopupExcelData += new DevExpress.XtraGrid.Views.Grid.FilterPopupExcelDataEventHandler(this.grvRequerimiento_FilterPopupExcelData);
            // 
            // gcCodigo
            // 
            this.gcCodigo.Caption = "Código";
            this.gcCodigo.FieldName = "idReqMenBieSer";
            this.gcCodigo.Name = "gcCodigo";
            this.gcCodigo.Visible = true;
            this.gcCodigo.VisibleIndex = 0;
            this.gcCodigo.Width = 50;
            // 
            // gcTipo
            // 
            this.gcTipo.Caption = "Tipo";
            this.gcTipo.FieldName = "desTipo";
            this.gcTipo.Name = "gcTipo";
            this.gcTipo.Visible = true;
            this.gcTipo.VisibleIndex = 1;
            this.gcTipo.Width = 80;
            // 
            // gcDescripcion
            // 
            this.gcDescripcion.Caption = "Descripción";
            this.gcDescripcion.FieldName = "descripcion";
            this.gcDescripcion.Name = "gcDescripcion";
            this.gcDescripcion.Visible = true;
            this.gcDescripcion.VisibleIndex = 2;
            this.gcDescripcion.Width = 400;
            // 
            // gcArea
            // 
            this.gcArea.Caption = "Area";
            this.gcArea.FieldName = "desArea";
            this.gcArea.Name = "gcArea";
            this.gcArea.Visible = true;
            this.gcArea.VisibleIndex = 3;
            this.gcArea.Width = 150;
            // 
            // gcSubdireccion
            // 
            this.gcSubdireccion.Caption = "Subdirección";
            this.gcSubdireccion.FieldName = "desSubdireccion";
            this.gcSubdireccion.Name = "gcSubdireccion";
            this.gcSubdireccion.Visible = true;
            this.gcSubdireccion.VisibleIndex = 4;
            this.gcSubdireccion.Width = 150;
            // 
            // gcDireccion
            // 
            this.gcDireccion.Caption = "Dirección";
            this.gcDireccion.FieldName = "desDireccion";
            this.gcDireccion.Name = "gcDireccion";
            this.gcDireccion.Visible = true;
            this.gcDireccion.VisibleIndex = 5;
            this.gcDireccion.Width = 150;
            // 
            // gcFechaEmision
            // 
            this.gcFechaEmision.Caption = "Fecha Emisión";
            this.gcFechaEmision.FieldName = "fechaEmision";
            this.gcFechaEmision.Name = "gcFechaEmision";
            this.gcFechaEmision.Visible = true;
            this.gcFechaEmision.VisibleIndex = 6;
            this.gcFechaEmision.Width = 100;
            // 
            // gcMoneda
            // 
            this.gcMoneda.Caption = "Moneda";
            this.gcMoneda.FieldName = "moneda";
            this.gcMoneda.Name = "gcMoneda";
            this.gcMoneda.Visible = true;
            this.gcMoneda.VisibleIndex = 7;
            this.gcMoneda.Width = 80;
            // 
            // gcTotal
            // 
            this.gcTotal.AppearanceCell.Options.UseTextOptions = true;
            this.gcTotal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gcTotal.Caption = "Total";
            this.gcTotal.DisplayFormat.FormatString = "n2";
            this.gcTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcTotal.FieldName = "total";
            this.gcTotal.Name = "gcTotal";
            this.gcTotal.Visible = true;
            this.gcTotal.VisibleIndex = 8;
            // 
            // gcDesEstado
            // 
            this.gcDesEstado.Caption = "Estado";
            this.gcDesEstado.ColumnEdit = this.repCboEstado;
            this.gcDesEstado.FieldName = "estado";
            this.gcDesEstado.Name = "gcDesEstado";
            this.gcDesEstado.Visible = true;
            this.gcDesEstado.VisibleIndex = 9;
            this.gcDesEstado.Width = 100;
            // 
            // repCboEstado
            // 
            this.repCboEstado.AutoHeight = false;
            this.repCboEstado.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repCboEstado.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Registrado", 2, 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Aprobado", 10, 1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Pres. Asig.", 59, 7),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Anulado", 1, 2)});
            this.repCboEstado.Name = "repCboEstado";
            this.repCboEstado.SmallImages = this.svgImageCollection1;
            // 
            // svgImageCollection1
            // 
            this.svgImageCollection1.Add("new", ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("svgImageCollection1.new"))));
            this.svgImageCollection1.Add("fixed", ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("svgImageCollection1.fixed"))));
            this.svgImageCollection1.Add("rejected", ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("svgImageCollection1.rejected"))));
            this.svgImageCollection1.Add("postponed", ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("svgImageCollection1.postponed"))));
            this.svgImageCollection1.Add("low", ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("svgImageCollection1.low"))));
            this.svgImageCollection1.Add("medium", ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("svgImageCollection1.medium"))));
            this.svgImageCollection1.Add("high", ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("svgImageCollection1.high"))));
            this.svgImageCollection1.Add("bo_invoice", "image://svgimages/business objects/bo_invoice.svg");
            // 
            // gcFechaAprobacion
            // 
            this.gcFechaAprobacion.Caption = "Fecha Aprobación";
            this.gcFechaAprobacion.FieldName = "fechaAprobacion";
            this.gcFechaAprobacion.Name = "gcFechaAprobacion";
            this.gcFechaAprobacion.Width = 100;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grcRequerimiento;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(836, 540);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // lueAnio
            // 
            this.lueAnio.Location = new System.Drawing.Point(43, 12);
            this.lueAnio.MaximumSize = new System.Drawing.Size(100, 0);
            this.lueAnio.Name = "lueAnio";
            this.lueAnio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueAnio.Size = new System.Drawing.Size(94, 20);
            this.lueAnio.StyleController = this.lcGeneral;
            this.lueAnio.TabIndex = 5;
            this.lueAnio.EditValueChanged += new System.EventHandler(this.lueAnio_EditValueChanged);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.lueAnio;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(129, 24);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(129, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(129, 24);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Text = "Año";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(19, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(264, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(572, 24);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lueMes
            // 
            this.lueMes.Location = new System.Drawing.Point(172, 12);
            this.lueMes.MaximumSize = new System.Drawing.Size(100, 0);
            this.lueMes.Name = "lueMes";
            this.lueMes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueMes.Size = new System.Drawing.Size(100, 20);
            this.lueMes.StyleController = this.lcGeneral;
            this.lueMes.TabIndex = 5;
            this.lueMes.EditValueChanged += new System.EventHandler(this.lueMes_EditValueChanged);
            // 
            // lciMes
            // 
            this.lciMes.Control = this.lueMes;
            this.lciMes.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lciMes.CustomizationFormText = "Mes";
            this.lciMes.Location = new System.Drawing.Point(129, 0);
            this.lciMes.MaxSize = new System.Drawing.Size(135, 24);
            this.lciMes.MinSize = new System.Drawing.Size(135, 24);
            this.lciMes.Name = "lciMes";
            this.lciMes.Size = new System.Drawing.Size(135, 24);
            this.lciMes.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciMes.Text = "Mes";
            this.lciMes.TextSize = new System.Drawing.Size(19, 13);
            // 
            // ListaRequerimientoMensualBienServicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ListaRequerimientoMensualBienServicio";
            ((System.ComponentModel.ISupportInitialize)(this.lcGeneral)).EndInit();
            this.lcGeneral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgGeneral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcRequerimiento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvRequerimiento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCboEstado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueAnio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciMes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grcRequerimiento;
        private DevExpress.XtraGrid.Views.Grid.GridView grvRequerimiento;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gcCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn gcFechaEmision;
        private DevExpress.XtraGrid.Columns.GridColumn gcFechaAprobacion;
        private DevExpress.XtraGrid.Columns.GridColumn gcMoneda;
        private DevExpress.XtraGrid.Columns.GridColumn gcDescripcion;
        private DevExpress.XtraEditors.LookUpEdit lueAnio;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gcArea;
        private DevExpress.XtraGrid.Columns.GridColumn gcSubdireccion;
        private DevExpress.XtraGrid.Columns.GridColumn gcDireccion;
        private DevExpress.XtraGrid.Columns.GridColumn gcTotal;
        private DevExpress.XtraGrid.Columns.GridColumn gcTipo;
        private DevExpress.XtraEditors.LookUpEdit lueMes;
        private DevExpress.XtraLayout.LayoutControlItem lciMes;
        private DevExpress.XtraGrid.Columns.GridColumn gcDesEstado;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repCboEstado;
        private DevExpress.Utils.SvgImageCollection svgImageCollection1;
    }
}
