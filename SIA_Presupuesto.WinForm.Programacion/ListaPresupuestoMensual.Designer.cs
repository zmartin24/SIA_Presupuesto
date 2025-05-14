namespace SIA_Presupuesto.WinForm.Programacion
{
    partial class ListaPresupuestoMensual
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
            this.gcSubPresupuesto = new DevExpress.XtraGrid.GridControl();
            this.gvSubPresupuesto = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcGruPre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTipoCambio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUsuCre = new DevExpress.XtraGrid.Columns.GridColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.gcSubPresupuesto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSubPresupuesto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueAnio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciAnio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // lcGeneral
            // 
            this.lcGeneral.Controls.Add(this.lueAnio);
            this.lcGeneral.Controls.Add(this.gcSubPresupuesto);
            this.lcGeneral.Size = new System.Drawing.Size(643, 403);
            // 
            // lcgGeneral
            // 
            this.lcgGeneral.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.lciAnio,
            this.emptySpaceItem1});
            this.lcgGeneral.Size = new System.Drawing.Size(643, 403);
            // 
            // gcSubPresupuesto
            // 
            this.gcSubPresupuesto.Location = new System.Drawing.Point(12, 36);
            this.gcSubPresupuesto.MainView = this.gvSubPresupuesto;
            this.gcSubPresupuesto.Name = "gcSubPresupuesto";
            this.gcSubPresupuesto.Size = new System.Drawing.Size(619, 355);
            this.gcSubPresupuesto.TabIndex = 4;
            this.gcSubPresupuesto.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSubPresupuesto});
            // 
            // gvSubPresupuesto
            // 
            this.gvSubPresupuesto.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcCodigo,
            this.gcGruPre,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gcTipoCambio,
            this.gridColumn6,
            this.gcUsuCre,
            this.gcFechaCrea,
            this.gcUsuEdita,
            this.gcFechaEdita});
            this.gvSubPresupuesto.GridControl = this.gcSubPresupuesto;
            this.gvSubPresupuesto.GroupCount = 2;
            this.gvSubPresupuesto.Name = "gvSubPresupuesto";
            this.gvSubPresupuesto.OptionsBehavior.Editable = false;
            this.gvSubPresupuesto.OptionsPrint.PrintDetails = true;
            this.gvSubPresupuesto.OptionsView.ColumnAutoWidth = false;
            this.gvSubPresupuesto.OptionsView.ShowAutoFilterRow = true;
            this.gvSubPresupuesto.OptionsView.ShowFooter = true;
            this.gvSubPresupuesto.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gcGruPre, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn1, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gcCodigo
            // 
            this.gcCodigo.Caption = "Código";
            this.gcCodigo.FieldName = "idSubPresupuesto";
            this.gcCodigo.Name = "gcCodigo";
            this.gcCodigo.Visible = true;
            this.gcCodigo.VisibleIndex = 0;
            this.gcCodigo.Width = 80;
            // 
            // gcGruPre
            // 
            this.gcGruPre.Caption = "Grupo Pre.";
            this.gcGruPre.FieldName = "desGrupoPresupuesto";
            this.gcGruPre.Name = "gcGruPre";
            this.gcGruPre.Visible = true;
            this.gcGruPre.VisibleIndex = 0;
            this.gcGruPre.Width = 150;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Presupuesto";
            this.gridColumn1.FieldName = "desPresupuesto";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 140;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn2.Caption = "Sub Presupuesto";
            this.gridColumn2.FieldName = "desSubPresupuesto";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 400;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "Es Obra";
            this.gridColumn3.FieldName = "esObra";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 40;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Proyecto";
            this.gridColumn4.FieldName = "proyecto";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 60;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Estado";
            this.gridColumn5.FieldName = "nombreEstado";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 100;
            // 
            // gcTipoCambio
            // 
            this.gcTipoCambio.AppearanceCell.Options.UseTextOptions = true;
            this.gcTipoCambio.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gcTipoCambio.Caption = "Tipo Cambio";
            this.gcTipoCambio.DisplayFormat.FormatString = "n3";
            this.gcTipoCambio.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcTipoCambio.FieldName = "tipoCambio";
            this.gcTipoCambio.Name = "gcTipoCambio";
            this.gcTipoCambio.Visible = true;
            this.gcTipoCambio.VisibleIndex = 7;
            this.gcTipoCambio.Width = 60;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "gridColumn6";
            this.gridColumn6.FieldName = "mes";
            this.gridColumn6.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            // 
            // gcUsuCre
            // 
            this.gcUsuCre.Caption = "Usuario Crea";
            this.gcUsuCre.FieldName = "usuCrea";
            this.gcUsuCre.Name = "gcUsuCre";
            this.gcUsuCre.Visible = true;
            this.gcUsuCre.VisibleIndex = 5;
            this.gcUsuCre.Width = 100;
            // 
            // gcFechaCrea
            // 
            this.gcFechaCrea.AppearanceCell.Options.UseTextOptions = true;
            this.gcFechaCrea.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcFechaCrea.Caption = "Fecha Crea";
            this.gcFechaCrea.DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss";
            this.gcFechaCrea.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcFechaCrea.FieldName = "fechaCrea";
            this.gcFechaCrea.Name = "gcFechaCrea";
            this.gcFechaCrea.Visible = true;
            this.gcFechaCrea.VisibleIndex = 6;
            this.gcFechaCrea.Width = 120;
            // 
            // gcUsuEdita
            // 
            this.gcUsuEdita.Caption = "Usuario Edita";
            this.gcUsuEdita.FieldName = "usuEdita";
            this.gcUsuEdita.Name = "gcUsuEdita";
            this.gcUsuEdita.Visible = true;
            this.gcUsuEdita.VisibleIndex = 8;
            this.gcUsuEdita.Width = 100;
            // 
            // gcFechaEdita
            // 
            this.gcFechaEdita.AppearanceCell.Options.UseTextOptions = true;
            this.gcFechaEdita.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcFechaEdita.Caption = "Fecha Edita";
            this.gcFechaEdita.DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss";
            this.gcFechaEdita.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcFechaEdita.FieldName = "fechaEdita";
            this.gcFechaEdita.Name = "gcFechaEdita";
            this.gcFechaEdita.Visible = true;
            this.gcFechaEdita.VisibleIndex = 9;
            this.gcFechaEdita.Width = 120;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gcSubPresupuesto;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(623, 359);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // lueAnio
            // 
            this.lueAnio.Location = new System.Drawing.Point(35, 12);
            this.lueAnio.Name = "lueAnio";
            this.lueAnio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueAnio.Size = new System.Drawing.Size(109, 20);
            this.lueAnio.StyleController = this.lcGeneral;
            this.lueAnio.TabIndex = 5;
            this.lueAnio.EditValueChanged += new System.EventHandler(this.lueAnio_EditValueChanged);
            // 
            // lciAnio
            // 
            this.lciAnio.Control = this.lueAnio;
            this.lciAnio.Location = new System.Drawing.Point(0, 0);
            this.lciAnio.Name = "lciAnio";
            this.lciAnio.Size = new System.Drawing.Size(136, 24);
            this.lciAnio.Text = "Año";
            this.lciAnio.TextSize = new System.Drawing.Size(19, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(136, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(487, 24);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // ListaPresupuestoMensual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ListaPresupuestoMensual";
            this.Size = new System.Drawing.Size(643, 403);
            ((System.ComponentModel.ISupportInitialize)(this.lcGeneral)).EndInit();
            this.lcGeneral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgGeneral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSubPresupuesto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSubPresupuesto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueAnio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciAnio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcSubPresupuesto;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSubPresupuesto;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gcGruPre;
        private DevExpress.XtraGrid.Columns.GridColumn gcUsuCre;
        private DevExpress.XtraGrid.Columns.GridColumn gcFechaCrea;
        private DevExpress.XtraGrid.Columns.GridColumn gcUsuEdita;
        private DevExpress.XtraGrid.Columns.GridColumn gcFechaEdita;
        private DevExpress.XtraEditors.LookUpEdit lueAnio;
        private DevExpress.XtraLayout.LayoutControlItem lciAnio;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gcTipoCambio;
        private DevExpress.XtraGrid.Columns.GridColumn gcCodigo;
    }
}