namespace SIA_Presupuesto.WinForm.Adquisicion.Ayuda
{
    partial class frmAyudaSubPresupuestoDetalle
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
            this.grcSubPresupuestoDet = new DevExpress.XtraGrid.GridControl();
            this.bgrvSubPresupuesto = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gbPrincipal = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumn2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn3 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gbSoles = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bgcImportePreSoles = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bgcImporteEjeSoles = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bgcSaldoSoles = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gbDolares = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bgcImportePreDolares = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bgcImporteEjeDolares = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn7 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.obgsSeleccion = new SIA_Presupuesto.WinForm.General.ControlesDiversos.OpcionesBarraGridSeleccion();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtGruPre = new DevExpress.XtraEditors.TextEdit();
            this.lciGruPre = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtPresupuesto = new DevExpress.XtraEditors.TextEdit();
            this.lciPresupuesto = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtSubPresupuesto = new DevExpress.XtraEditors.TextEdit();
            this.lciSubPresupuesto = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtDireccion = new DevExpress.XtraEditors.TextEdit();
            this.lciDireccion = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcgPresupuesto = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciTipoCambio = new DevExpress.XtraLayout.LayoutControlItem();
            this.seTipCam = new DevExpress.XtraEditors.SpinEdit();
            this.gbCuerpo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).BeginInit();
            this.lcCuerpo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcSubPresupuestoDet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgrvSubPresupuesto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGruPre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciGruPre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPresupuesto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPresupuesto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubPresupuesto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSubPresupuesto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDireccion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDireccion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgPresupuesto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTipoCambio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seTipCam.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gbCuerpo
            // 
            this.gbCuerpo.Size = new System.Drawing.Size(874, 518);
            // 
            // lcCuerpo
            // 
            this.lcCuerpo.Controls.Add(this.seTipCam);
            this.lcCuerpo.Controls.Add(this.obgsSeleccion);
            this.lcCuerpo.Controls.Add(this.grcSubPresupuestoDet);
            this.lcCuerpo.Controls.Add(this.txtGruPre);
            this.lcCuerpo.Controls.Add(this.txtPresupuesto);
            this.lcCuerpo.Controls.Add(this.txtSubPresupuesto);
            this.lcCuerpo.Controls.Add(this.txtDireccion);
            this.lcCuerpo.Size = new System.Drawing.Size(868, 498);
            // 
            // lcgCuerpo
            // 
            this.lcgCuerpo.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.lcgPresupuesto});
            this.lcgCuerpo.Name = "Root";
            this.lcgCuerpo.Size = new System.Drawing.Size(868, 498);
            // 
            // grcSubPresupuestoDet
            // 
            this.grcSubPresupuestoDet.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.grcSubPresupuestoDet.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.grcSubPresupuestoDet.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.grcSubPresupuestoDet.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.grcSubPresupuestoDet.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.grcSubPresupuestoDet.Location = new System.Drawing.Point(12, 181);
            this.grcSubPresupuestoDet.MainView = this.bgrvSubPresupuesto;
            this.grcSubPresupuestoDet.Name = "grcSubPresupuestoDet";
            this.grcSubPresupuestoDet.Size = new System.Drawing.Size(844, 305);
            this.grcSubPresupuestoDet.TabIndex = 4;
            this.grcSubPresupuestoDet.UseEmbeddedNavigator = true;
            this.grcSubPresupuestoDet.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.bgrvSubPresupuesto});
            // 
            // bgrvSubPresupuesto
            // 
            this.bgrvSubPresupuesto.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gbPrincipal,
            this.gbSoles,
            this.gbDolares});
            this.bgrvSubPresupuesto.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.bandedGridColumn2,
            this.bandedGridColumn3,
            this.bgcImportePreSoles,
            this.bgcImporteEjeSoles,
            this.bgcSaldoSoles,
            this.bgcImportePreDolares,
            this.bgcImporteEjeDolares,
            this.bandedGridColumn7});
            this.bgrvSubPresupuesto.GridControl = this.grcSubPresupuestoDet;
            this.bgrvSubPresupuesto.Name = "bgrvSubPresupuesto";
            this.bgrvSubPresupuesto.OptionsBehavior.ReadOnly = true;
            this.bgrvSubPresupuesto.OptionsView.ColumnAutoWidth = false;
            this.bgrvSubPresupuesto.OptionsView.ShowAutoFilterRow = true;
            this.bgrvSubPresupuesto.OptionsView.ShowFooter = true;
            this.bgrvSubPresupuesto.OptionsView.ShowGroupPanel = false;
            // 
            // gbPrincipal
            // 
            this.gbPrincipal.Caption = "Principal";
            this.gbPrincipal.Columns.Add(this.bandedGridColumn2);
            this.gbPrincipal.Columns.Add(this.bandedGridColumn3);
            this.gbPrincipal.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gbPrincipal.Name = "gbPrincipal";
            this.gbPrincipal.VisibleIndex = 0;
            this.gbPrincipal.Width = 340;
            // 
            // bandedGridColumn2
            // 
            this.bandedGridColumn2.Caption = "Cuenta";
            this.bandedGridColumn2.FieldName = "numCuenta";
            this.bandedGridColumn2.Name = "bandedGridColumn2";
            this.bandedGridColumn2.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.BeginsWith;
            this.bandedGridColumn2.Visible = true;
            this.bandedGridColumn2.Width = 60;
            // 
            // bandedGridColumn3
            // 
            this.bandedGridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.bandedGridColumn3.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.bandedGridColumn3.Caption = "Descripción";
            this.bandedGridColumn3.FieldName = "desCuenta";
            this.bandedGridColumn3.Name = "bandedGridColumn3";
            this.bandedGridColumn3.Visible = true;
            this.bandedGridColumn3.Width = 280;
            // 
            // gbSoles
            // 
            this.gbSoles.Caption = "Importe Soles";
            this.gbSoles.Columns.Add(this.bgcImportePreSoles);
            this.gbSoles.Columns.Add(this.bgcImporteEjeSoles);
            this.gbSoles.Columns.Add(this.bgcSaldoSoles);
            this.gbSoles.Name = "gbSoles";
            this.gbSoles.VisibleIndex = 1;
            this.gbSoles.Width = 270;
            // 
            // bgcImportePreSoles
            // 
            this.bgcImportePreSoles.AppearanceCell.Options.UseTextOptions = true;
            this.bgcImportePreSoles.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.bgcImportePreSoles.Caption = "Importe Pre Soles";
            this.bgcImportePreSoles.DisplayFormat.FormatString = "{0:n}";
            this.bgcImportePreSoles.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.bgcImportePreSoles.FieldName = "importePreSoles";
            this.bgcImportePreSoles.Name = "bgcImportePreSoles";
            this.bgcImportePreSoles.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "importePreSoles", "{0:n}")});
            this.bgcImportePreSoles.Visible = true;
            this.bgcImportePreSoles.Width = 90;
            // 
            // bgcImporteEjeSoles
            // 
            this.bgcImporteEjeSoles.AppearanceCell.Options.UseTextOptions = true;
            this.bgcImporteEjeSoles.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.bgcImporteEjeSoles.Caption = "Importe Eje Soles";
            this.bgcImporteEjeSoles.DisplayFormat.FormatString = "{0:n}";
            this.bgcImporteEjeSoles.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.bgcImporteEjeSoles.FieldName = "importeEjeSoles";
            this.bgcImporteEjeSoles.Name = "bgcImporteEjeSoles";
            this.bgcImporteEjeSoles.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "importeEjeSoles", "{0:n}")});
            this.bgcImporteEjeSoles.Visible = true;
            this.bgcImporteEjeSoles.Width = 90;
            // 
            // bgcSaldoSoles
            // 
            this.bgcSaldoSoles.AppearanceCell.Options.UseTextOptions = true;
            this.bgcSaldoSoles.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.bgcSaldoSoles.Caption = "Saldo Soles";
            this.bgcSaldoSoles.DisplayFormat.FormatString = "{0:n}";
            this.bgcSaldoSoles.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.bgcSaldoSoles.FieldName = "saldoSoles";
            this.bgcSaldoSoles.Name = "bgcSaldoSoles";
            this.bgcSaldoSoles.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "saldoSoles", "{0:n}")});
            this.bgcSaldoSoles.Visible = true;
            this.bgcSaldoSoles.Width = 90;
            // 
            // gbDolares
            // 
            this.gbDolares.Caption = "Importe Dolares";
            this.gbDolares.Columns.Add(this.bgcImportePreDolares);
            this.gbDolares.Columns.Add(this.bgcImporteEjeDolares);
            this.gbDolares.Columns.Add(this.bandedGridColumn7);
            this.gbDolares.Name = "gbDolares";
            this.gbDolares.VisibleIndex = 2;
            this.gbDolares.Width = 270;
            // 
            // bgcImportePreDolares
            // 
            this.bgcImportePreDolares.AppearanceCell.Options.UseTextOptions = true;
            this.bgcImportePreDolares.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.bgcImportePreDolares.Caption = "Presupuestado";
            this.bgcImportePreDolares.DisplayFormat.FormatString = "{0:n}";
            this.bgcImportePreDolares.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.bgcImportePreDolares.FieldName = "importePreDolares";
            this.bgcImportePreDolares.Name = "bgcImportePreDolares";
            this.bgcImportePreDolares.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "importePreDolares", "{0:n}")});
            this.bgcImportePreDolares.Visible = true;
            this.bgcImportePreDolares.Width = 90;
            // 
            // bgcImporteEjeDolares
            // 
            this.bgcImporteEjeDolares.AppearanceCell.Options.UseTextOptions = true;
            this.bgcImporteEjeDolares.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.bgcImporteEjeDolares.Caption = "Ejecutado";
            this.bgcImporteEjeDolares.DisplayFormat.FormatString = "{0:n}";
            this.bgcImporteEjeDolares.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.bgcImporteEjeDolares.FieldName = "importeEjeDolares";
            this.bgcImporteEjeDolares.Name = "bgcImporteEjeDolares";
            this.bgcImporteEjeDolares.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "importeEjeDolares", "{0:n}")});
            this.bgcImporteEjeDolares.Visible = true;
            this.bgcImporteEjeDolares.Width = 90;
            // 
            // bandedGridColumn7
            // 
            this.bandedGridColumn7.AppearanceCell.Options.UseTextOptions = true;
            this.bandedGridColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.bandedGridColumn7.Caption = "Saldo";
            this.bandedGridColumn7.DisplayFormat.FormatString = "{0:n}";
            this.bandedGridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.bandedGridColumn7.FieldName = "saldoDolares";
            this.bandedGridColumn7.Name = "bandedGridColumn7";
            this.bandedGridColumn7.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "saldoDolares", "{0:n}")});
            this.bandedGridColumn7.Visible = true;
            this.bandedGridColumn7.Width = 90;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grcSubPresupuestoDet;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 169);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(848, 309);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // obgsSeleccion
            // 
            this.obgsSeleccion.Location = new System.Drawing.Point(12, 153);
            this.obgsSeleccion.Name = "obgsSeleccion";
            this.obgsSeleccion.Size = new System.Drawing.Size(844, 24);
            this.obgsSeleccion.TabIndex = 5;
            this.obgsSeleccion.SeleccionarRegistro += new System.EventHandler(this.obgsSeleccion_SeleccionarRegistro);
            this.obgsSeleccion.SiguienteRegistro += new System.EventHandler(this.obgsSeleccion_SiguienteRegistro);
            this.obgsSeleccion.AnteriorRegistro += new System.EventHandler(this.obgsSeleccion_AnteriorRegistro);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.obgsSeleccion;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 141);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(848, 28);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // txtGruPre
            // 
            this.txtGruPre.Location = new System.Drawing.Point(128, 45);
            this.txtGruPre.Name = "txtGruPre";
            this.txtGruPre.Properties.ReadOnly = true;
            this.txtGruPre.Size = new System.Drawing.Size(716, 20);
            this.txtGruPre.StyleController = this.lcCuerpo;
            this.txtGruPre.TabIndex = 7;
            // 
            // lciGruPre
            // 
            this.lciGruPre.Control = this.txtGruPre;
            this.lciGruPre.Location = new System.Drawing.Point(0, 0);
            this.lciGruPre.Name = "lciGruPre";
            this.lciGruPre.Size = new System.Drawing.Size(824, 24);
            this.lciGruPre.Text = "Grupo Presupuesto";
            this.lciGruPre.TextSize = new System.Drawing.Size(92, 13);
            // 
            // txtPresupuesto
            // 
            this.txtPresupuesto.Location = new System.Drawing.Point(128, 69);
            this.txtPresupuesto.Name = "txtPresupuesto";
            this.txtPresupuesto.Properties.ReadOnly = true;
            this.txtPresupuesto.Size = new System.Drawing.Size(716, 20);
            this.txtPresupuesto.StyleController = this.lcCuerpo;
            this.txtPresupuesto.TabIndex = 7;
            // 
            // lciPresupuesto
            // 
            this.lciPresupuesto.Control = this.txtPresupuesto;
            this.lciPresupuesto.Location = new System.Drawing.Point(0, 24);
            this.lciPresupuesto.Name = "lciPresupuesto";
            this.lciPresupuesto.Size = new System.Drawing.Size(824, 24);
            this.lciPresupuesto.Text = "Presupuesto";
            this.lciPresupuesto.TextSize = new System.Drawing.Size(92, 13);
            // 
            // txtSubPresupuesto
            // 
            this.txtSubPresupuesto.Location = new System.Drawing.Point(128, 93);
            this.txtSubPresupuesto.Name = "txtSubPresupuesto";
            this.txtSubPresupuesto.Properties.ReadOnly = true;
            this.txtSubPresupuesto.Size = new System.Drawing.Size(716, 20);
            this.txtSubPresupuesto.StyleController = this.lcCuerpo;
            this.txtSubPresupuesto.TabIndex = 7;
            // 
            // lciSubPresupuesto
            // 
            this.lciSubPresupuesto.Control = this.txtSubPresupuesto;
            this.lciSubPresupuesto.CustomizationFormText = "Presupuesto";
            this.lciSubPresupuesto.Location = new System.Drawing.Point(0, 48);
            this.lciSubPresupuesto.Name = "lciSubPresupuesto";
            this.lciSubPresupuesto.Size = new System.Drawing.Size(824, 24);
            this.lciSubPresupuesto.Text = "Sub Presupuesto";
            this.lciSubPresupuesto.TextSize = new System.Drawing.Size(92, 13);
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(128, 117);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Properties.ReadOnly = true;
            this.txtDireccion.Size = new System.Drawing.Size(512, 20);
            this.txtDireccion.StyleController = this.lcCuerpo;
            this.txtDireccion.TabIndex = 7;
            // 
            // lciDireccion
            // 
            this.lciDireccion.Control = this.txtDireccion;
            this.lciDireccion.CustomizationFormText = "Presupuesto";
            this.lciDireccion.Location = new System.Drawing.Point(0, 72);
            this.lciDireccion.Name = "lciDireccion";
            this.lciDireccion.Size = new System.Drawing.Size(620, 24);
            this.lciDireccion.Text = "Dirección";
            this.lciDireccion.TextSize = new System.Drawing.Size(92, 13);
            // 
            // lcgPresupuesto
            // 
            this.lcgPresupuesto.ExpandButtonVisible = true;
            this.lcgPresupuesto.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciGruPre,
            this.lciPresupuesto,
            this.lciSubPresupuesto,
            this.lciDireccion,
            this.lciTipoCambio});
            this.lcgPresupuesto.Location = new System.Drawing.Point(0, 0);
            this.lcgPresupuesto.Name = "lcgPresupuesto";
            this.lcgPresupuesto.Size = new System.Drawing.Size(848, 141);
            this.lcgPresupuesto.Text = "Presupuesto";
            // 
            // lciTipoCambio
            // 
            this.lciTipoCambio.Control = this.seTipCam;
            this.lciTipoCambio.Location = new System.Drawing.Point(620, 72);
            this.lciTipoCambio.Name = "lciTipoCambio";
            this.lciTipoCambio.Size = new System.Drawing.Size(204, 24);
            this.lciTipoCambio.Text = "Tipo Cambio";
            this.lciTipoCambio.TextSize = new System.Drawing.Size(92, 13);
            // 
            // seTipCam
            // 
            this.seTipCam.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seTipCam.Location = new System.Drawing.Point(748, 117);
            this.seTipCam.Name = "seTipCam";
            this.seTipCam.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.seTipCam.Properties.ReadOnly = true;
            this.seTipCam.Size = new System.Drawing.Size(96, 20);
            this.seTipCam.StyleController = this.lcCuerpo;
            this.seTipCam.TabIndex = 9;
            // 
            // frmAyudaSubPresupuestoDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 568);
            this.Name = "frmAyudaSubPresupuestoDetalle";
            this.Text = "frmAyudaSubPresupuestoDetalle";
            this.gbCuerpo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).EndInit();
            this.lcCuerpo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcSubPresupuestoDet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgrvSubPresupuesto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGruPre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciGruPre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPresupuesto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPresupuesto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubPresupuesto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSubPresupuesto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDireccion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDireccion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgPresupuesto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTipoCambio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seTipCam.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grcSubPresupuestoDet;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private General.ControlesDiversos.OpcionesBarraGridSeleccion obgsSeleccion;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.TextEdit txtGruPre;
        private DevExpress.XtraLayout.LayoutControlItem lciGruPre;
        private DevExpress.XtraEditors.TextEdit txtPresupuesto;
        private DevExpress.XtraLayout.LayoutControlItem lciPresupuesto;
        private DevExpress.XtraEditors.TextEdit txtSubPresupuesto;
        private DevExpress.XtraLayout.LayoutControlItem lciSubPresupuesto;
        private DevExpress.XtraEditors.TextEdit txtDireccion;
        private DevExpress.XtraLayout.LayoutControlItem lciDireccion;
        private DevExpress.XtraLayout.LayoutControlGroup lcgPresupuesto;
        private DevExpress.XtraEditors.SpinEdit seTipCam;
        private DevExpress.XtraLayout.LayoutControlItem lciTipoCambio;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bgrvSubPresupuesto;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gbPrincipal;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn3;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gbSoles;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bgcImportePreSoles;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bgcImporteEjeSoles;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bgcSaldoSoles;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gbDolares;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bgcImportePreDolares;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bgcImporteEjeDolares;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn7;
    }
}