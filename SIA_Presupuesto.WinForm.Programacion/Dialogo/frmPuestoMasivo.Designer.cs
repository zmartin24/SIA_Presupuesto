namespace SIA_Presupuesto.WinForm.Programacion.Dialogo
{
    partial class frmPuestoMasivo
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
            this.grcTrabajador = new DevExpress.XtraGrid.GridControl();
            this.grvTrabajador = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcSeleccion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riceSelect = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gcNroDocIdentidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTrabajador = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcGrado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcRemuneracion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lueDireccion = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lueSubdireccion = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lueGruPre = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.luePresupuesto = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ceSoloActivos = new DevExpress.XtraEditors.CheckEdit();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.sbBuscar = new DevExpress.XtraEditors.SimpleButton();
            this.obgmTrabajador = new SIA_Presupuesto.WinForm.General.ControlesDiversos.OpcionesBarraGridMarcar();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcBase)).BeginInit();
            this.lcBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxProveedorValidador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcTrabajador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTrabajador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riceSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDireccion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSubdireccion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueGruPre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luePresupuesto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceSoloActivos.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            this.SuspendLayout();
            // 
            // lcCuerpo
            // 
            this.lcCuerpo.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(803, 132, 386, 350);
            this.lcCuerpo.Size = new System.Drawing.Size(688, 582);
            // 
            // lcgCuerpo
            // 
            this.lcgCuerpo.Size = new System.Drawing.Size(688, 582);
            // 
            // lcBase
            // 
            this.lcBase.Controls.Add(this.sbBuscar);
            this.lcBase.Controls.Add(this.ceSoloActivos);
            this.lcBase.Controls.Add(this.obgmTrabajador);
            this.lcBase.Controls.Add(this.luePresupuesto);
            this.lcBase.Controls.Add(this.lueGruPre);
            this.lcBase.Controls.Add(this.lueSubdireccion);
            this.lcBase.Controls.Add(this.lueDireccion);
            this.lcBase.Controls.Add(this.grcTrabajador);
            this.lcBase.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(939, 293, 450, 400);
            this.lcBase.Size = new System.Drawing.Size(658, 512);
            // 
            // lcgBase
            // 
            this.lcgBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlGroup1,
            this.layoutControlItem6});
            this.lcgBase.Name = "Root";
            this.lcgBase.Size = new System.Drawing.Size(658, 512);
            // 
            // grcTrabajador
            // 
            this.grcTrabajador.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.grcTrabajador.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.grcTrabajador.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.grcTrabajador.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.grcTrabajador.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.grcTrabajador.Location = new System.Drawing.Point(12, 163);
            this.grcTrabajador.MainView = this.grvTrabajador;
            this.grcTrabajador.Name = "grcTrabajador";
            this.grcTrabajador.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riceSelect});
            this.grcTrabajador.Size = new System.Drawing.Size(634, 337);
            this.grcTrabajador.TabIndex = 4;
            this.grcTrabajador.UseEmbeddedNavigator = true;
            this.grcTrabajador.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvTrabajador});
            // 
            // grvTrabajador
            // 
            this.grvTrabajador.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcSeleccion,
            this.gcNroDocIdentidad,
            this.gcTrabajador,
            this.gcGrado,
            this.gcRemuneracion});
            this.grvTrabajador.GridControl = this.grcTrabajador;
            this.grvTrabajador.Name = "grvTrabajador";
            this.grvTrabajador.OptionsView.ShowAutoFilterRow = true;
            this.grvTrabajador.OptionsView.ShowGroupPanel = false;
            this.grvTrabajador.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.grvTrabajador_CustomUnboundColumnData);
            // 
            // gcSeleccion
            // 
            this.gcSeleccion.Caption = "gridColumn1";
            this.gcSeleccion.ColumnEdit = this.riceSelect;
            this.gcSeleccion.FieldName = "gcSeleccion";
            this.gcSeleccion.Name = "gcSeleccion";
            this.gcSeleccion.OptionsColumn.AllowMove = false;
            this.gcSeleccion.OptionsColumn.AllowSize = false;
            this.gcSeleccion.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gcSeleccion.OptionsColumn.FixedWidth = true;
            this.gcSeleccion.OptionsColumn.ShowCaption = false;
            this.gcSeleccion.OptionsFilter.AllowAutoFilter = false;
            this.gcSeleccion.OptionsFilter.AllowFilter = false;
            this.gcSeleccion.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            this.gcSeleccion.Visible = true;
            this.gcSeleccion.VisibleIndex = 0;
            this.gcSeleccion.Width = 40;
            // 
            // riceSelect
            // 
            this.riceSelect.AutoHeight = false;
            this.riceSelect.Name = "riceSelect";
            this.riceSelect.CheckStateChanged += new System.EventHandler(this.riceSelect_CheckStateChanged);
            // 
            // gcNroDocIdentidad
            // 
            this.gcNroDocIdentidad.Caption = "DNI";
            this.gcNroDocIdentidad.FieldName = "nroDocIdentidad";
            this.gcNroDocIdentidad.Name = "gcNroDocIdentidad";
            this.gcNroDocIdentidad.OptionsColumn.AllowEdit = false;
            this.gcNroDocIdentidad.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.BeginsWith;
            this.gcNroDocIdentidad.Visible = true;
            this.gcNroDocIdentidad.VisibleIndex = 1;
            this.gcNroDocIdentidad.Width = 106;
            // 
            // gcTrabajador
            // 
            this.gcTrabajador.Caption = "Trabajador";
            this.gcTrabajador.FieldName = "trabajador";
            this.gcTrabajador.Name = "gcTrabajador";
            this.gcTrabajador.OptionsColumn.AllowEdit = false;
            this.gcTrabajador.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcTrabajador.Visible = true;
            this.gcTrabajador.VisibleIndex = 2;
            this.gcTrabajador.Width = 238;
            // 
            // gcGrado
            // 
            this.gcGrado.Caption = "Grado";
            this.gcGrado.FieldName = "grado";
            this.gcGrado.Name = "gcGrado";
            this.gcGrado.OptionsColumn.AllowEdit = false;
            this.gcGrado.Visible = true;
            this.gcGrado.VisibleIndex = 3;
            this.gcGrado.Width = 100;
            // 
            // gcRemuneracion
            // 
            this.gcRemuneracion.Caption = "Remuneracion";
            this.gcRemuneracion.FieldName = "remuneracion";
            this.gcRemuneracion.Name = "gcRemuneracion";
            this.gcRemuneracion.OptionsColumn.AllowEdit = false;
            this.gcRemuneracion.Visible = true;
            this.gcRemuneracion.VisibleIndex = 4;
            this.gcRemuneracion.Width = 102;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grcTrabajador;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 151);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(638, 341);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // lueDireccion
            // 
            this.lueDireccion.Location = new System.Drawing.Point(120, 42);
            this.lueDireccion.Name = "lueDireccion";
            this.lueDireccion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueDireccion.Size = new System.Drawing.Size(207, 20);
            this.lueDireccion.StyleController = this.lcBase;
            this.lueDireccion.TabIndex = 5;
            this.lueDireccion.EditValueChanged += new System.EventHandler(this.lueDireccion_EditValueChanged);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.lueDireccion;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(307, 24);
            this.layoutControlItem2.Text = "Dirección";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(92, 13);
            // 
            // lueSubdireccion
            // 
            this.lueSubdireccion.Location = new System.Drawing.Point(427, 42);
            this.lueSubdireccion.Name = "lueSubdireccion";
            this.lueSubdireccion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueSubdireccion.Size = new System.Drawing.Size(207, 20);
            this.lueSubdireccion.StyleController = this.lcBase;
            this.lueSubdireccion.TabIndex = 6;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.lueSubdireccion;
            this.layoutControlItem3.Location = new System.Drawing.Point(307, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(307, 24);
            this.layoutControlItem3.Text = "Subdirección";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(92, 13);
            // 
            // lueGruPre
            // 
            this.lueGruPre.Location = new System.Drawing.Point(120, 66);
            this.lueGruPre.Name = "lueGruPre";
            this.lueGruPre.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueGruPre.Size = new System.Drawing.Size(207, 20);
            this.lueGruPre.StyleController = this.lcBase;
            this.lueGruPre.TabIndex = 7;
            this.lueGruPre.EditValueChanged += new System.EventHandler(this.lueGruPre_EditValueChanged);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.lueGruPre;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(307, 24);
            this.layoutControlItem4.Text = "Grupo Presupuesto";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(92, 13);
            // 
            // luePresupuesto
            // 
            this.luePresupuesto.Location = new System.Drawing.Point(427, 66);
            this.luePresupuesto.Name = "luePresupuesto";
            this.luePresupuesto.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luePresupuesto.Size = new System.Drawing.Size(207, 20);
            this.luePresupuesto.StyleController = this.lcBase;
            this.luePresupuesto.TabIndex = 8;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.luePresupuesto;
            this.layoutControlItem5.Location = new System.Drawing.Point(307, 24);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(307, 24);
            this.layoutControlItem5.Text = "Presupuesto";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(92, 13);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem4,
            this.layoutControlItem3,
            this.layoutControlItem5,
            this.layoutControlItem7,
            this.emptySpaceItem1,
            this.layoutControlItem8});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(638, 116);
            this.layoutControlGroup1.Text = "Filtros";
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.ceSoloActivos;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(307, 26);
            this.layoutControlItem7.Text = "Solo Activos";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(92, 13);
            // 
            // ceSoloActivos
            // 
            this.ceSoloActivos.EditValue = true;
            this.ceSoloActivos.Location = new System.Drawing.Point(120, 90);
            this.ceSoloActivos.Name = "ceSoloActivos";
            this.ceSoloActivos.Properties.Caption = "";
            this.ceSoloActivos.Size = new System.Drawing.Size(207, 19);
            this.ceSoloActivos.StyleController = this.lcBase;
            this.ceSoloActivos.TabIndex = 10;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(307, 48);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(153, 26);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.sbBuscar;
            this.layoutControlItem8.Location = new System.Drawing.Point(460, 48);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(154, 26);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // sbBuscar
            // 
            this.sbBuscar.Location = new System.Drawing.Point(484, 90);
            this.sbBuscar.Name = "sbBuscar";
            this.sbBuscar.Size = new System.Drawing.Size(150, 22);
            this.sbBuscar.StyleController = this.lcBase;
            this.sbBuscar.TabIndex = 11;
            this.sbBuscar.Text = "Buscar";
            this.sbBuscar.Click += new System.EventHandler(this.sbBuscar_Click);
            // 
            // obgmTrabajador
            // 
            this.obgmTrabajador.Location = new System.Drawing.Point(12, 128);
            this.obgmTrabajador.Name = "obgmTrabajador";
            this.obgmTrabajador.Size = new System.Drawing.Size(634, 31);
            this.obgmTrabajador.TabIndex = 9;
            this.obgmTrabajador.MarcarRegistro += new System.EventHandler(this.obgmTrabajador_MarcarRegistro);
            this.obgmTrabajador.DesmarcarRegistro += new System.EventHandler(this.obgmTrabajador_DesmarcarRegistro);
            this.obgmTrabajador.MarcarTodosRegistro += new System.EventHandler(this.obgmTrabajador_MarcarTodosRegistro);
            this.obgmTrabajador.DesmarcarTodosRegistro += new System.EventHandler(this.obgmTrabajador_DesmarcarTodosRegistro);
            this.obgmTrabajador.SiguienteRegistro += new System.EventHandler(this.obgmTrabajador_SiguienteRegistro);
            this.obgmTrabajador.AnteriorRegistro += new System.EventHandler(this.obgmTrabajador_AnteriorRegistro);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.obgmTrabajador;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 116);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(638, 35);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // frmPuestoMasivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 582);
            this.Name = "frmPuestoMasivo";
            this.Text = "frmPuestoMasivo";
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcBase)).EndInit();
            this.lcBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxProveedorValidador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcTrabajador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTrabajador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riceSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDireccion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSubdireccion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueGruPre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luePresupuesto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceSoloActivos.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grcTrabajador;
        private DevExpress.XtraGrid.Views.Grid.GridView grvTrabajador;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.LookUpEdit luePresupuesto;
        private DevExpress.XtraEditors.LookUpEdit lueGruPre;
        private DevExpress.XtraEditors.LookUpEdit lueSubdireccion;
        private DevExpress.XtraEditors.LookUpEdit lueDireccion;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private General.ControlesDiversos.OpcionesBarraGridMarcar obgmTrabajador;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraGrid.Columns.GridColumn gcNroDocIdentidad;
        private DevExpress.XtraGrid.Columns.GridColumn gcTrabajador;
        private DevExpress.XtraGrid.Columns.GridColumn gcGrado;
        private DevExpress.XtraGrid.Columns.GridColumn gcRemuneracion;
        private DevExpress.XtraGrid.Columns.GridColumn gcSeleccion;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit riceSelect;
        private DevExpress.XtraEditors.SimpleButton sbBuscar;
        private DevExpress.XtraEditors.CheckEdit ceSoloActivos;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
    }
}