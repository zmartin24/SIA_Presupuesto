namespace SIA_Presupuesto.WinForm.Programacion
{
    partial class ListaRequerimientoMensualAsignacion
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
            this.gcRequerimiento = new DevExpress.XtraGrid.GridControl();
            this.grvRequerimiento = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTipo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcArea = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSubdireccion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDireccion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFechaEmision = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFechaAprobacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcMoneda = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lueMes = new DevExpress.XtraEditors.LookUpEdit();
            this.lciMes = new DevExpress.XtraLayout.LayoutControlItem();
            this.gcRequeAsig = new DevExpress.XtraGrid.GridControl();
            this.grvRequeAsig = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            this.btnQuitarPresupuesto = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnAsignarPresupuesto = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lueAnio = new DevExpress.XtraEditors.LookUpEdit();
            this.gluePresupuesto = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcIdProAnu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDesProgramacionAnual = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lciPresupuestoAnual = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcGeneral)).BeginInit();
            this.lcGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgGeneral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcRequerimiento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvRequerimiento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciMes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcRequeAsig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvRequeAsig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueAnio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gluePresupuesto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPresupuestoAnual)).BeginInit();
            this.SuspendLayout();
            // 
            // lcGeneral
            // 
            this.lcGeneral.Controls.Add(this.gluePresupuesto);
            this.lcGeneral.Controls.Add(this.btnAsignarPresupuesto);
            this.lcGeneral.Controls.Add(this.btnQuitarPresupuesto);
            this.lcGeneral.Controls.Add(this.gcRequeAsig);
            this.lcGeneral.Controls.Add(this.lueAnio);
            this.lcGeneral.Controls.Add(this.gcRequerimiento);
            this.lcGeneral.Controls.Add(this.lueMes);
            this.lcGeneral.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(744, 305, 450, 400);
            // 
            // lcgGeneral
            // 
            this.lcgGeneral.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.emptySpaceItem1,
            this.lciMes,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.emptySpaceItem2,
            this.emptySpaceItem3,
            this.lciPresupuestoAnual});
            this.lcgGeneral.Name = "Root";
            // 
            // gcRequerimiento
            // 
            this.gcRequerimiento.EmbeddedNavigator.Buttons.Append.Enabled = false;
            this.gcRequerimiento.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcRequerimiento.EmbeddedNavigator.Buttons.CancelEdit.Enabled = false;
            this.gcRequerimiento.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcRequerimiento.EmbeddedNavigator.Buttons.Edit.Enabled = false;
            this.gcRequerimiento.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcRequerimiento.EmbeddedNavigator.Buttons.EndEdit.Enabled = false;
            this.gcRequerimiento.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gcRequerimiento.EmbeddedNavigator.Buttons.Remove.Enabled = false;
            this.gcRequerimiento.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcRequerimiento.Location = new System.Drawing.Point(12, 36);
            this.gcRequerimiento.MainView = this.grvRequerimiento;
            this.gcRequerimiento.Name = "gcRequerimiento";
            this.gcRequerimiento.Size = new System.Drawing.Size(407, 536);
            this.gcRequerimiento.TabIndex = 4;
            this.gcRequerimiento.UseEmbeddedNavigator = true;
            this.gcRequerimiento.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvRequerimiento});
            // 
            // grvRequerimiento
            // 
            this.grvRequerimiento.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcCodigo,
            this.gcTipo,
            this.gcDescripcion,
            this.gcTotal,
            this.gcArea,
            this.gcSubdireccion,
            this.gcDireccion,
            this.gcFechaEmision,
            this.gcFechaAprobacion,
            this.gcMoneda});
            this.grvRequerimiento.GridControl = this.gcRequerimiento;
            this.grvRequerimiento.Name = "grvRequerimiento";
            this.grvRequerimiento.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.grvRequerimiento.OptionsBehavior.ReadOnly = true;
            this.grvRequerimiento.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.grvRequerimiento.OptionsClipboard.AllowHtmlFormat = DevExpress.Utils.DefaultBoolean.True;
            this.grvRequerimiento.OptionsClipboard.ClipboardMode = DevExpress.Export.ClipboardMode.Formatted;
            this.grvRequerimiento.OptionsClipboard.CopyCollapsedData = DevExpress.Utils.DefaultBoolean.True;
            this.grvRequerimiento.OptionsClipboard.PasteMode = DevExpress.Export.PasteMode.Append;
            this.grvRequerimiento.OptionsMenu.ShowConditionalFormattingItem = true;
            this.grvRequerimiento.OptionsSelection.MultiSelect = true;
            this.grvRequerimiento.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.grvRequerimiento.OptionsView.ColumnAutoWidth = false;
            this.grvRequerimiento.OptionsView.EnableAppearanceOddRow = true;
            this.grvRequerimiento.OptionsView.ShowAutoFilterRow = true;
            this.grvRequerimiento.OptionsView.ShowFooter = true;
            this.grvRequerimiento.OptionsView.ShowGroupPanel = false;
            this.grvRequerimiento.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.grvRequerimiento_SelectionChanged);
            // 
            // gcCodigo
            // 
            this.gcCodigo.Caption = "Código";
            this.gcCodigo.FieldName = "idReqMenBieSer";
            this.gcCodigo.Name = "gcCodigo";
            this.gcCodigo.Visible = true;
            this.gcCodigo.VisibleIndex = 1;
            this.gcCodigo.Width = 50;
            // 
            // gcTipo
            // 
            this.gcTipo.Caption = "Tipo";
            this.gcTipo.FieldName = "desTipo";
            this.gcTipo.Name = "gcTipo";
            this.gcTipo.Visible = true;
            this.gcTipo.VisibleIndex = 2;
            this.gcTipo.Width = 80;
            // 
            // gcDescripcion
            // 
            this.gcDescripcion.Caption = "Descripción";
            this.gcDescripcion.FieldName = "descripcion";
            this.gcDescripcion.ImageOptions.SvgImage = global::SIA_Presupuesto.WinForm.Programacion.Properties.Resources.list;
            this.gcDescripcion.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.gcDescripcion.Name = "gcDescripcion";
            this.gcDescripcion.Visible = true;
            this.gcDescripcion.VisibleIndex = 3;
            this.gcDescripcion.Width = 400;
            // 
            // gcTotal
            // 
            this.gcTotal.AppearanceCell.Options.UseTextOptions = true;
            this.gcTotal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gcTotal.Caption = "Total";
            this.gcTotal.DisplayFormat.FormatString = "n2";
            this.gcTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcTotal.FieldName = "total";
            this.gcTotal.ImageOptions.SvgImage = global::SIA_Presupuesto.WinForm.Programacion.Properties.Resources.currency;
            this.gcTotal.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.gcTotal.Name = "gcTotal";
            this.gcTotal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total", "{0:n2}")});
            this.gcTotal.Visible = true;
            this.gcTotal.VisibleIndex = 4;
            this.gcTotal.Width = 90;
            // 
            // gcArea
            // 
            this.gcArea.Caption = "Area";
            this.gcArea.FieldName = "desArea";
            this.gcArea.Name = "gcArea";
            this.gcArea.Visible = true;
            this.gcArea.VisibleIndex = 5;
            this.gcArea.Width = 150;
            // 
            // gcSubdireccion
            // 
            this.gcSubdireccion.Caption = "Subdirección";
            this.gcSubdireccion.FieldName = "desSubdireccion";
            this.gcSubdireccion.Name = "gcSubdireccion";
            this.gcSubdireccion.Visible = true;
            this.gcSubdireccion.VisibleIndex = 6;
            this.gcSubdireccion.Width = 150;
            // 
            // gcDireccion
            // 
            this.gcDireccion.Caption = "Dirección";
            this.gcDireccion.FieldName = "desDireccion";
            this.gcDireccion.Name = "gcDireccion";
            this.gcDireccion.Visible = true;
            this.gcDireccion.VisibleIndex = 7;
            this.gcDireccion.Width = 150;
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
            this.gcFechaEmision.Visible = true;
            this.gcFechaEmision.VisibleIndex = 8;
            this.gcFechaEmision.Width = 100;
            // 
            // gcFechaAprobacion
            // 
            this.gcFechaAprobacion.AppearanceCell.Options.UseTextOptions = true;
            this.gcFechaAprobacion.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcFechaAprobacion.Caption = "Fecha Aprobación";
            this.gcFechaAprobacion.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.gcFechaAprobacion.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcFechaAprobacion.FieldName = "fechaAprobacion";
            this.gcFechaAprobacion.Name = "gcFechaAprobacion";
            this.gcFechaAprobacion.Visible = true;
            this.gcFechaAprobacion.VisibleIndex = 9;
            this.gcFechaAprobacion.Width = 100;
            // 
            // gcMoneda
            // 
            this.gcMoneda.Caption = "Moneda";
            this.gcMoneda.FieldName = "moneda";
            this.gcMoneda.Name = "gcMoneda";
            this.gcMoneda.Visible = true;
            this.gcMoneda.VisibleIndex = 10;
            this.gcMoneda.Width = 80;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gcRequerimiento;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(411, 540);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(411, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(44, 224);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lueMes
            // 
            this.lueMes.Location = new System.Drawing.Point(300, 12);
            this.lueMes.MaximumSize = new System.Drawing.Size(80, 0);
            this.lueMes.MinimumSize = new System.Drawing.Size(80, 0);
            this.lueMes.Name = "lueMes";
            this.lueMes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueMes.Size = new System.Drawing.Size(80, 20);
            this.lueMes.StyleController = this.lcGeneral;
            this.lueMes.TabIndex = 5;
            this.lueMes.EditValueChanged += new System.EventHandler(this.lueMes_EditValueChanged);
            // 
            // lciMes
            // 
            this.lciMes.Control = this.lueMes;
            this.lciMes.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lciMes.CustomizationFormText = "Mes";
            this.lciMes.Location = new System.Drawing.Point(186, 0);
            this.lciMes.Name = "lciMes";
            this.lciMes.Size = new System.Drawing.Size(186, 24);
            this.lciMes.Text = "Mes";
            this.lciMes.TextSize = new System.Drawing.Size(90, 13);
            // 
            // gcRequeAsig
            // 
            this.gcRequeAsig.EmbeddedNavigator.Buttons.Append.Enabled = false;
            this.gcRequeAsig.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcRequeAsig.EmbeddedNavigator.Buttons.CancelEdit.Enabled = false;
            this.gcRequeAsig.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcRequeAsig.EmbeddedNavigator.Buttons.Edit.Enabled = false;
            this.gcRequeAsig.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcRequeAsig.EmbeddedNavigator.Buttons.EndEdit.Enabled = false;
            this.gcRequeAsig.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gcRequeAsig.EmbeddedNavigator.Buttons.Remove.Enabled = false;
            this.gcRequeAsig.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcRequeAsig.Location = new System.Drawing.Point(467, 36);
            this.gcRequeAsig.MainView = this.grvRequeAsig;
            this.gcRequeAsig.Name = "gcRequeAsig";
            this.gcRequeAsig.Size = new System.Drawing.Size(377, 536);
            this.gcRequeAsig.TabIndex = 6;
            this.gcRequeAsig.UseEmbeddedNavigator = true;
            this.gcRequeAsig.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvRequeAsig});
            // 
            // grvRequeAsig
            // 
            this.grvRequeAsig.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn9,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn10,
            this.gridColumn8});
            this.grvRequeAsig.GridControl = this.gcRequeAsig;
            this.grvRequeAsig.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total", null, "(Total = {0:n2})")});
            this.grvRequeAsig.Name = "grvRequeAsig";
            this.grvRequeAsig.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.grvRequeAsig.OptionsBehavior.ReadOnly = true;
            this.grvRequeAsig.OptionsClipboard.AllowHtmlFormat = DevExpress.Utils.DefaultBoolean.True;
            this.grvRequeAsig.OptionsClipboard.ClipboardMode = DevExpress.Export.ClipboardMode.Formatted;
            this.grvRequeAsig.OptionsClipboard.CopyCollapsedData = DevExpress.Utils.DefaultBoolean.True;
            this.grvRequeAsig.OptionsClipboard.PasteMode = DevExpress.Export.PasteMode.Append;
            this.grvRequeAsig.OptionsMenu.ShowConditionalFormattingItem = true;
            this.grvRequeAsig.OptionsSelection.MultiSelect = true;
            this.grvRequeAsig.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.grvRequeAsig.OptionsView.ColumnAutoWidth = false;
            this.grvRequeAsig.OptionsView.EnableAppearanceOddRow = true;
            this.grvRequeAsig.OptionsView.ShowAutoFilterRow = true;
            this.grvRequeAsig.OptionsView.ShowFooter = true;
            this.grvRequeAsig.OptionsView.ShowGroupPanel = false;
            this.grvRequeAsig.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.grvRequeAsig_SelectionChanged);
            this.grvRequeAsig.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.grvRequeAsig_ShowingEditor);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Código";
            this.gridColumn1.FieldName = "idReqMenBieSer";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 50;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Tipo";
            this.gridColumn2.FieldName = "desTipo";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 80;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Descripción";
            this.gridColumn3.FieldName = "descripcion";
            this.gridColumn3.ImageOptions.SvgImage = global::SIA_Presupuesto.WinForm.Programacion.Properties.Resources.list;
            this.gridColumn3.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            this.gridColumn3.Width = 400;
            // 
            // gridColumn9
            // 
            this.gridColumn9.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn9.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn9.Caption = "Total";
            this.gridColumn9.DisplayFormat.FormatString = "n2";
            this.gridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn9.FieldName = "total";
            this.gridColumn9.ImageOptions.SvgImage = global::SIA_Presupuesto.WinForm.Programacion.Properties.Resources.currency;
            this.gridColumn9.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total", "{0:n2}")});
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 4;
            this.gridColumn9.Width = 90;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Area";
            this.gridColumn4.FieldName = "desArea";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 5;
            this.gridColumn4.Width = 150;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Subdirección";
            this.gridColumn5.FieldName = "desSubdireccion";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 6;
            this.gridColumn5.Width = 150;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Dirección";
            this.gridColumn6.FieldName = "desDireccion";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 7;
            this.gridColumn6.Width = 150;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn7.Caption = "Fecha Emisión";
            this.gridColumn7.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn7.FieldName = "fechaEmision";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 8;
            this.gridColumn7.Width = 100;
            // 
            // gridColumn10
            // 
            this.gridColumn10.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn10.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn10.Caption = "Fecha Aprobación";
            this.gridColumn10.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.gridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn10.FieldName = "fechaAprobacion";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 9;
            this.gridColumn10.Width = 100;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Moneda";
            this.gridColumn8.FieldName = "moneda";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 10;
            this.gridColumn8.Width = 80;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.gcRequeAsig;
            this.layoutControlItem3.Location = new System.Drawing.Point(455, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(381, 540);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(411, 276);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(44, 288);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // btnQuitarPresupuesto
            // 
            this.btnQuitarPresupuesto.Location = new System.Drawing.Point(423, 262);
            this.btnQuitarPresupuesto.Name = "btnQuitarPresupuesto";
            this.btnQuitarPresupuesto.Size = new System.Drawing.Size(40, 22);
            this.btnQuitarPresupuesto.StyleController = this.lcGeneral;
            this.btnQuitarPresupuesto.TabIndex = 9;
            this.btnQuitarPresupuesto.Text = "<<";
            this.btnQuitarPresupuesto.Click += new System.EventHandler(this.btnQuitarPresupuesto_Click);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnQuitarPresupuesto;
            this.layoutControlItem4.Location = new System.Drawing.Point(411, 250);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(44, 26);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // btnAsignarPresupuesto
            // 
            this.btnAsignarPresupuesto.Location = new System.Drawing.Point(423, 236);
            this.btnAsignarPresupuesto.MaximumSize = new System.Drawing.Size(40, 0);
            this.btnAsignarPresupuesto.MinimumSize = new System.Drawing.Size(40, 0);
            this.btnAsignarPresupuesto.Name = "btnAsignarPresupuesto";
            this.btnAsignarPresupuesto.Size = new System.Drawing.Size(40, 22);
            this.btnAsignarPresupuesto.StyleController = this.lcGeneral;
            this.btnAsignarPresupuesto.TabIndex = 10;
            this.btnAsignarPresupuesto.Text = ">>";
            this.btnAsignarPresupuesto.Click += new System.EventHandler(this.btnAsignarPresupuesto_Click);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btnAsignarPresupuesto;
            this.layoutControlItem5.Location = new System.Drawing.Point(411, 224);
            this.layoutControlItem5.MaxSize = new System.Drawing.Size(44, 26);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(44, 26);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(44, 26);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(372, 0);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(39, 24);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.lueAnio;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(186, 24);
            this.layoutControlItem2.Text = "Año";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(90, 13);
            // 
            // lueAnio
            // 
            this.lueAnio.Location = new System.Drawing.Point(114, 12);
            this.lueAnio.MaximumSize = new System.Drawing.Size(80, 0);
            this.lueAnio.MinimumSize = new System.Drawing.Size(80, 0);
            this.lueAnio.Name = "lueAnio";
            this.lueAnio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueAnio.Size = new System.Drawing.Size(80, 20);
            this.lueAnio.StyleController = this.lcGeneral;
            this.lueAnio.TabIndex = 5;
            this.lueAnio.EditValueChanged += new System.EventHandler(this.lueAnio_EditValueChanged);
            // 
            // gluePresupuesto
            // 
            this.gluePresupuesto.Location = new System.Drawing.Point(569, 12);
            this.gluePresupuesto.Name = "gluePresupuesto";
            this.gluePresupuesto.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gluePresupuesto.Properties.DisplayMember = "descripcion";
            this.gluePresupuesto.Properties.NullText = "[Seleccione un Presupuesto Anual]";
            this.gluePresupuesto.Properties.PopupView = this.gridLookUpEdit1View;
            this.gluePresupuesto.Properties.ValueMember = "idProAnu";
            this.gluePresupuesto.Size = new System.Drawing.Size(275, 20);
            this.gluePresupuesto.StyleController = this.lcGeneral;
            this.gluePresupuesto.TabIndex = 11;
            this.gluePresupuesto.EditValueChanged += new System.EventHandler(this.gluePresupuesto_EditValueChanged);
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcIdProAnu,
            this.gcDesProgramacionAnual});
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsBehavior.ReadOnly = true;
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ColumnAutoWidth = false;
            this.gridLookUpEdit1View.OptionsView.ShowAutoFilterRow = true;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gcIdProAnu
            // 
            this.gcIdProAnu.Caption = "Codigo";
            this.gcIdProAnu.FieldName = "idProAnu";
            this.gcIdProAnu.Name = "gcIdProAnu";
            this.gcIdProAnu.Visible = true;
            this.gcIdProAnu.VisibleIndex = 0;
            this.gcIdProAnu.Width = 60;
            // 
            // gcDesProgramacionAnual
            // 
            this.gcDesProgramacionAnual.Caption = "Descripción";
            this.gcDesProgramacionAnual.FieldName = "descripcion";
            this.gcDesProgramacionAnual.Name = "gcDesProgramacionAnual";
            this.gcDesProgramacionAnual.Visible = true;
            this.gcDesProgramacionAnual.VisibleIndex = 1;
            this.gcDesProgramacionAnual.Width = 700;
            // 
            // lciPresupuestoAnual
            // 
            this.lciPresupuestoAnual.Control = this.gluePresupuesto;
            this.lciPresupuestoAnual.Location = new System.Drawing.Point(455, 0);
            this.lciPresupuestoAnual.Name = "lciPresupuestoAnual";
            this.lciPresupuestoAnual.Size = new System.Drawing.Size(381, 24);
            this.lciPresupuestoAnual.Text = "Presupuesto Anual";
            this.lciPresupuestoAnual.TextSize = new System.Drawing.Size(90, 13);
            // 
            // ListaRequerimientoMensualAsignacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ListaRequerimientoMensualAsignacion";
            ((System.ComponentModel.ISupportInitialize)(this.lcGeneral)).EndInit();
            this.lcGeneral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgGeneral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcRequerimiento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvRequerimiento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciMes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcRequeAsig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvRequeAsig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueAnio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gluePresupuesto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPresupuestoAnual)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcRequerimiento;
        private DevExpress.XtraGrid.Views.Grid.GridView grvRequerimiento;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gcCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn gcFechaEmision;
        private DevExpress.XtraGrid.Columns.GridColumn gcFechaAprobacion;
        private DevExpress.XtraGrid.Columns.GridColumn gcMoneda;
        private DevExpress.XtraGrid.Columns.GridColumn gcDescripcion;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gcArea;
        private DevExpress.XtraGrid.Columns.GridColumn gcSubdireccion;
        private DevExpress.XtraGrid.Columns.GridColumn gcDireccion;
        private DevExpress.XtraGrid.Columns.GridColumn gcTotal;
        private DevExpress.XtraGrid.Columns.GridColumn gcTipo;
        private DevExpress.XtraEditors.LookUpEdit lueMes;
        private DevExpress.XtraLayout.LayoutControlItem lciMes;
        private DevExpress.XtraGrid.GridControl gcRequeAsig;
        private DevExpress.XtraGrid.Views.Grid.GridView grvRequeAsig;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private DevExpress.XtraEditors.SimpleButton btnAsignarPresupuesto;
        private DevExpress.XtraEditors.SimpleButton btnQuitarPresupuesto;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.LookUpEdit lueAnio;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraEditors.GridLookUpEdit gluePresupuesto;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraLayout.LayoutControlItem lciPresupuestoAnual;
        private DevExpress.XtraGrid.Columns.GridColumn gcIdProAnu;
        private DevExpress.XtraGrid.Columns.GridColumn gcDesProgramacionAnual;
    }
}
