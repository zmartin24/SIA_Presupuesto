namespace SIA_Presupuesto.WinForm.Adquisicion.Dialogo
{
    partial class frmCertificacionRequerimientoSubpresupuesto
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
            this.lueGruPre = new DevExpress.XtraEditors.LookUpEdit();
            this.lciGruPre = new DevExpress.XtraLayout.LayoutControlItem();
            this.lueSubPresupuesto = new DevExpress.XtraEditors.LookUpEdit();
            this.lciPresupuestoMensual = new DevExpress.XtraLayout.LayoutControlItem();
            this.luePresupuesto = new DevExpress.XtraEditors.LookUpEdit();
            this.lciPresupuesto = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtReq = new DevExpress.XtraEditors.TextEdit();
            this.lciForebise = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtSigla = new DevExpress.XtraEditors.TextEdit();
            this.lciNro = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.gcSubpresupuesto = new DevExpress.XtraGrid.GridControl();
            this.gvSubpresupuesto = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcSeleccionar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riceSeleccionar = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gcCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.obgDetalle = new SIA_Presupuesto.WinForm.General.ControlesDiversos.OpcionesBarraGrid();
            this.lciGridRequerimiento = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciOpcionDetalle = new DevExpress.XtraLayout.LayoutControlItem();
            this.sbAgregar = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.gbCuerpo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).BeginInit();
            this.lcCuerpo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueGruPre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciGruPre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSubPresupuesto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPresupuestoMensual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luePresupuesto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPresupuesto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReq.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciForebise)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSigla.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciNro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSubpresupuesto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSubpresupuesto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riceSeleccionar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciGridRequerimiento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciOpcionDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // gbCuerpo
            // 
            this.gbCuerpo.Size = new System.Drawing.Size(774, 418);
            // 
            // lcCuerpo
            // 
            this.lcCuerpo.Controls.Add(this.sbAgregar);
            this.lcCuerpo.Controls.Add(this.txtReq);
            this.lcCuerpo.Controls.Add(this.luePresupuesto);
            this.lcCuerpo.Controls.Add(this.lueSubPresupuesto);
            this.lcCuerpo.Controls.Add(this.lueGruPre);
            this.lcCuerpo.Controls.Add(this.txtSigla);
            this.lcCuerpo.Controls.Add(this.gcSubpresupuesto);
            this.lcCuerpo.Controls.Add(this.obgDetalle);
            this.lcCuerpo.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(803, 132, 386, 350);
            this.lcCuerpo.Size = new System.Drawing.Size(768, 398);
            // 
            // lcgCuerpo
            // 
            this.lcgCuerpo.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciGruPre,
            this.lciPresupuestoMensual,
            this.lciPresupuesto,
            this.lciForebise,
            this.lciNro,
            this.emptySpaceItem1,
            this.lciGridRequerimiento,
            this.lciOpcionDetalle,
            this.layoutControlItem1,
            this.emptySpaceItem2});
            this.lcgCuerpo.Name = "Root";
            this.lcgCuerpo.Size = new System.Drawing.Size(768, 398);
            // 
            // lueGruPre
            // 
            this.lueGruPre.Location = new System.Drawing.Point(126, 36);
            this.lueGruPre.Name = "lueGruPre";
            this.lueGruPre.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueGruPre.Properties.ReadOnly = true;
            this.lueGruPre.Size = new System.Drawing.Size(630, 20);
            this.lueGruPre.StyleController = this.lcCuerpo;
            this.lueGruPre.TabIndex = 13;
            this.lueGruPre.EditValueChanged += new System.EventHandler(this.lueGruPre_EditValueChanged);
            // 
            // lciGruPre
            // 
            this.lciGruPre.Control = this.lueGruPre;
            this.lciGruPre.Location = new System.Drawing.Point(0, 24);
            this.lciGruPre.Name = "lciGruPre";
            this.lciGruPre.Size = new System.Drawing.Size(748, 24);
            this.lciGruPre.Text = "Grupo Pres.";
            this.lciGruPre.TextSize = new System.Drawing.Size(102, 13);
            // 
            // lueSubPresupuesto
            // 
            this.lueSubPresupuesto.Location = new System.Drawing.Point(126, 84);
            this.lueSubPresupuesto.Name = "lueSubPresupuesto";
            this.lueSubPresupuesto.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueSubPresupuesto.Size = new System.Drawing.Size(630, 20);
            this.lueSubPresupuesto.StyleController = this.lcCuerpo;
            this.lueSubPresupuesto.TabIndex = 14;
            // 
            // lciPresupuestoMensual
            // 
            this.lciPresupuestoMensual.Control = this.lueSubPresupuesto;
            this.lciPresupuestoMensual.Location = new System.Drawing.Point(0, 72);
            this.lciPresupuestoMensual.Name = "lciPresupuestoMensual";
            this.lciPresupuestoMensual.Size = new System.Drawing.Size(748, 24);
            this.lciPresupuestoMensual.Text = "Presupuesto Mensual";
            this.lciPresupuestoMensual.TextSize = new System.Drawing.Size(102, 13);
            // 
            // luePresupuesto
            // 
            this.luePresupuesto.Location = new System.Drawing.Point(126, 60);
            this.luePresupuesto.Name = "luePresupuesto";
            this.luePresupuesto.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luePresupuesto.Properties.ReadOnly = true;
            this.luePresupuesto.Size = new System.Drawing.Size(630, 20);
            this.luePresupuesto.StyleController = this.lcCuerpo;
            this.luePresupuesto.TabIndex = 15;
            this.luePresupuesto.EditValueChanged += new System.EventHandler(this.luePresupuesto_EditValueChanged);
            // 
            // lciPresupuesto
            // 
            this.lciPresupuesto.Control = this.luePresupuesto;
            this.lciPresupuesto.Location = new System.Drawing.Point(0, 48);
            this.lciPresupuesto.Name = "lciPresupuesto";
            this.lciPresupuesto.Size = new System.Drawing.Size(748, 24);
            this.lciPresupuesto.Text = "Presupuesto";
            this.lciPresupuesto.TextSize = new System.Drawing.Size(102, 13);
            // 
            // txtReq
            // 
            this.txtReq.Location = new System.Drawing.Point(126, 12);
            this.txtReq.Name = "txtReq";
            this.txtReq.Properties.ReadOnly = true;
            this.txtReq.Size = new System.Drawing.Size(255, 20);
            this.txtReq.StyleController = this.lcCuerpo;
            this.txtReq.TabIndex = 16;
            // 
            // lciForebise
            // 
            this.lciForebise.Control = this.txtReq;
            this.lciForebise.Location = new System.Drawing.Point(0, 0);
            this.lciForebise.Name = "lciForebise";
            this.lciForebise.Size = new System.Drawing.Size(373, 24);
            this.lciForebise.Text = "Nro. Req.";
            this.lciForebise.TextSize = new System.Drawing.Size(102, 13);
            // 
            // txtSigla
            // 
            this.txtSigla.Location = new System.Drawing.Point(499, 12);
            this.txtSigla.Name = "txtSigla";
            this.txtSigla.Properties.ReadOnly = true;
            this.txtSigla.Size = new System.Drawing.Size(257, 20);
            this.txtSigla.StyleController = this.lcCuerpo;
            this.txtSigla.TabIndex = 16;
            // 
            // lciNro
            // 
            this.lciNro.Control = this.txtSigla;
            this.lciNro.CustomizationFormText = "Nro. Req.";
            this.lciNro.Location = new System.Drawing.Point(373, 0);
            this.lciNro.Name = "lciNro";
            this.lciNro.Size = new System.Drawing.Size(375, 24);
            this.lciNro.Text = "Nro. Certificación.";
            this.lciNro.TextSize = new System.Drawing.Size(102, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(213, 96);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(535, 26);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // gcSubpresupuesto
            // 
            this.gcSubpresupuesto.EmbeddedNavigator.Buttons.Append.Enabled = false;
            this.gcSubpresupuesto.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcSubpresupuesto.EmbeddedNavigator.Buttons.CancelEdit.Enabled = false;
            this.gcSubpresupuesto.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcSubpresupuesto.EmbeddedNavigator.Buttons.Edit.Enabled = false;
            this.gcSubpresupuesto.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcSubpresupuesto.EmbeddedNavigator.Buttons.EndEdit.Enabled = false;
            this.gcSubpresupuesto.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gcSubpresupuesto.EmbeddedNavigator.Buttons.Remove.Enabled = false;
            this.gcSubpresupuesto.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcSubpresupuesto.Location = new System.Drawing.Point(12, 162);
            this.gcSubpresupuesto.MainView = this.gvSubpresupuesto;
            this.gcSubpresupuesto.Name = "gcSubpresupuesto";
            this.gcSubpresupuesto.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riceSeleccionar});
            this.gcSubpresupuesto.Size = new System.Drawing.Size(744, 224);
            this.gcSubpresupuesto.TabIndex = 19;
            this.gcSubpresupuesto.UseEmbeddedNavigator = true;
            this.gcSubpresupuesto.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSubpresupuesto});
            // 
            // gvSubpresupuesto
            // 
            this.gvSubpresupuesto.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcSeleccionar,
            this.gcCodigo,
            this.gcDesc});
            this.gvSubpresupuesto.GridControl = this.gcSubpresupuesto;
            this.gvSubpresupuesto.Name = "gvSubpresupuesto";
            this.gvSubpresupuesto.OptionsBehavior.SummariesIgnoreNullValues = true;
            this.gvSubpresupuesto.OptionsPrint.PrintSelectedRowsOnly = true;
            this.gvSubpresupuesto.OptionsView.ColumnAutoWidth = false;
            this.gvSubpresupuesto.OptionsView.ShowAutoFilterRow = true;
            this.gvSubpresupuesto.OptionsView.ShowFooter = true;
            this.gvSubpresupuesto.OptionsView.ShowGroupPanel = false;
            this.gvSubpresupuesto.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gvSubpresupuesto_CustomUnboundColumnData);
            // 
            // gcSeleccionar
            // 
            this.gcSeleccionar.Caption = "Seleccion";
            this.gcSeleccionar.ColumnEdit = this.riceSeleccionar;
            this.gcSeleccionar.FieldName = "retornar";
            this.gcSeleccionar.Name = "gcSeleccionar";
            this.gcSeleccionar.OptionsColumn.AllowMove = false;
            this.gcSeleccionar.OptionsColumn.AllowSize = false;
            this.gcSeleccionar.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gcSeleccionar.OptionsColumn.FixedWidth = true;
            this.gcSeleccionar.OptionsColumn.ShowCaption = false;
            this.gcSeleccionar.OptionsFilter.AllowAutoFilter = false;
            this.gcSeleccionar.OptionsFilter.AllowFilter = false;
            this.gcSeleccionar.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            this.gcSeleccionar.Visible = true;
            this.gcSeleccionar.VisibleIndex = 0;
            this.gcSeleccionar.Width = 30;
            // 
            // riceSeleccionar
            // 
            this.riceSeleccionar.Name = "riceSeleccionar";
            this.riceSeleccionar.CheckedChanged += new System.EventHandler(this.riceSeleccionar_CheckedChanged);
            this.riceSeleccionar.CheckStateChanged += new System.EventHandler(this.riceSeleccionar_CheckStateChanged);
            // 
            // gcCodigo
            // 
            this.gcCodigo.Caption = "Codigo";
            this.gcCodigo.FieldName = "idSubPresupuesto";
            this.gcCodigo.Name = "gcCodigo";
            this.gcCodigo.OptionsColumn.ReadOnly = true;
            this.gcCodigo.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcCodigo.Visible = true;
            this.gcCodigo.VisibleIndex = 1;
            this.gcCodigo.Width = 80;
            // 
            // gcDesc
            // 
            this.gcDesc.Caption = "Descripción";
            this.gcDesc.FieldName = "desSubPresupuesto";
            this.gcDesc.Name = "gcDesc";
            this.gcDesc.OptionsColumn.ReadOnly = true;
            this.gcDesc.Visible = true;
            this.gcDesc.VisibleIndex = 2;
            this.gcDesc.Width = 600;
            // 
            // obgDetalle
            // 
            this.obgDetalle.ConAgregar = false;
            this.obgDetalle.ConDesMarcarTodos = true;
            this.obgDetalle.ConMarcarTodos = true;
            this.obgDetalle.ConModificar = false;
            this.obgDetalle.ConNuevoDetalle = false;
            this.obgDetalle.ConOtros = false;
            this.obgDetalle.ConQuitar = true;
            this.obgDetalle.ConVisualizar = false;
            this.obgDetalle.Location = new System.Drawing.Point(12, 134);
            this.obgDetalle.Name = "obgDetalle";
            this.obgDetalle.NombreAgregar = "Agregar";
            this.obgDetalle.NombreModificar = "";
            this.obgDetalle.NombreNuevoDetalleRegistro = "Nuevo 2";
            this.obgDetalle.NombreOtros = "";
            this.obgDetalle.NombreQuitar = "Quitar";
            this.obgDetalle.NombreVisualizar = "Ver Precio";
            this.obgDetalle.Size = new System.Drawing.Size(744, 24);
            this.obgDetalle.TabIndex = 22;
            this.obgDetalle.QuitarRegistro += new System.EventHandler(this.obgDetalle_QuitarRegistro);
            this.obgDetalle.MarcarTodos += new System.EventHandler(this.obgDetalle_MarcarTodos);
            this.obgDetalle.DesMarcarTodos += new System.EventHandler(this.obgDetalle_DesMarcarTodos);
            // 
            // lciGridRequerimiento
            // 
            this.lciGridRequerimiento.Control = this.gcSubpresupuesto;
            this.lciGridRequerimiento.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lciGridRequerimiento.CustomizationFormText = "lciGridRequerimiento";
            this.lciGridRequerimiento.Location = new System.Drawing.Point(0, 150);
            this.lciGridRequerimiento.Name = "lciGridRequerimiento";
            this.lciGridRequerimiento.Size = new System.Drawing.Size(748, 228);
            this.lciGridRequerimiento.TextSize = new System.Drawing.Size(0, 0);
            this.lciGridRequerimiento.TextVisible = false;
            // 
            // lciOpcionDetalle
            // 
            this.lciOpcionDetalle.Control = this.obgDetalle;
            this.lciOpcionDetalle.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lciOpcionDetalle.CustomizationFormText = "layoutControlItem9";
            this.lciOpcionDetalle.Location = new System.Drawing.Point(0, 122);
            this.lciOpcionDetalle.Name = "lciOpcionDetalle";
            this.lciOpcionDetalle.Size = new System.Drawing.Size(748, 28);
            this.lciOpcionDetalle.TextSize = new System.Drawing.Size(0, 0);
            this.lciOpcionDetalle.TextVisible = false;
            // 
            // sbAgregar
            // 
            this.sbAgregar.Location = new System.Drawing.Point(121, 108);
            this.sbAgregar.MaximumSize = new System.Drawing.Size(100, 0);
            this.sbAgregar.MinimumSize = new System.Drawing.Size(100, 0);
            this.sbAgregar.Name = "sbAgregar";
            this.sbAgregar.Size = new System.Drawing.Size(100, 22);
            this.sbAgregar.StyleController = this.lcCuerpo;
            this.sbAgregar.TabIndex = 23;
            this.sbAgregar.Text = "Agregar";
            this.sbAgregar.Click += new System.EventHandler(this.sbAgregar_Click);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.sbAgregar;
            this.layoutControlItem1.Location = new System.Drawing.Point(109, 96);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(104, 26);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 96);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(109, 26);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frmCertificacionRequerimientoSubpresupuesto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 468);
            this.Name = "frmCertificacionRequerimientoSubpresupuesto";
            this.Text = "";
            this.gbCuerpo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).EndInit();
            this.lcCuerpo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueGruPre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciGruPre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSubPresupuesto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPresupuestoMensual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luePresupuesto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPresupuesto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReq.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciForebise)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSigla.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciNro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSubpresupuesto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSubpresupuesto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riceSeleccionar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciGridRequerimiento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciOpcionDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.LookUpEdit luePresupuesto;
        private DevExpress.XtraEditors.LookUpEdit lueSubPresupuesto;
        private DevExpress.XtraEditors.LookUpEdit lueGruPre;
        private DevExpress.XtraLayout.LayoutControlItem lciGruPre;
        private DevExpress.XtraLayout.LayoutControlItem lciPresupuestoMensual;
        private DevExpress.XtraLayout.LayoutControlItem lciPresupuesto;
        private DevExpress.XtraEditors.TextEdit txtReq;
        private DevExpress.XtraLayout.LayoutControlItem lciForebise;
        private DevExpress.XtraEditors.TextEdit txtSigla;
        private DevExpress.XtraLayout.LayoutControlItem lciNro;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraGrid.GridControl gcSubpresupuesto;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSubpresupuesto;
        private DevExpress.XtraGrid.Columns.GridColumn gcSeleccionar;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit riceSeleccionar;
        private DevExpress.XtraGrid.Columns.GridColumn gcCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn gcDesc;
        private General.ControlesDiversos.OpcionesBarraGrid obgDetalle;
        private DevExpress.XtraLayout.LayoutControlItem lciGridRequerimiento;
        private DevExpress.XtraLayout.LayoutControlItem lciOpcionDetalle;
        private DevExpress.XtraEditors.SimpleButton sbAgregar;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
    }
}