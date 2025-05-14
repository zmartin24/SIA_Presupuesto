namespace SIA_Presupuesto.WinForm.Programacion.Dialogo
{
    partial class frmActualizarPorRequerimientoBienServicio
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
            this.lciBaseReq = new DevExpress.XtraLayout.LayoutControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.lueAnio = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gcSeleccion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcOrigen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSuministro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSubPresupuesto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPresupuesto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcGrupoPresupuesto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcMes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSede = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSubdireccion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDireccion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcEstimado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcReal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcEstado = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcBase)).BeginInit();
            this.lcBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxProveedorValidador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBaseReq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueAnio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // lcCuerpo
            // 
            this.lcCuerpo.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(803, 132, 386, 350);
            this.lcCuerpo.Size = new System.Drawing.Size(787, 511);
            // 
            // lcgCuerpo
            // 
            this.lcgCuerpo.Size = new System.Drawing.Size(787, 511);
            // 
            // lcBase
            // 
            this.lcBase.Controls.Add(this.layoutControl1);
            this.lcBase.Controls.Add(this.lciBaseReq);
            this.lcBase.Size = new System.Drawing.Size(757, 441);
            // 
            // lcgBase
            // 
            this.lcgBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.lcgBase.Name = "Root";
            this.lcgBase.Size = new System.Drawing.Size(757, 441);
            // 
            // lciBaseReq
            // 
            this.lciBaseReq.Location = new System.Drawing.Point(12, 60);
            this.lciBaseReq.Name = "lciBaseReq";
            this.lciBaseReq.Root = this.Root;
            this.lciBaseReq.Size = new System.Drawing.Size(733, 369);
            this.lciBaseReq.TabIndex = 1;
            this.lciBaseReq.Text = "layoutControl1";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(733, 369);
            this.Root.TextVisible = false;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.lueAnio);
            this.layoutControl1.Location = new System.Drawing.Point(12, 12);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(733, 44);
            this.layoutControl1.TabIndex = 19;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // lueAnio
            // 
            this.lueAnio.Location = new System.Drawing.Point(43, 12);
            this.lueAnio.Name = "lueAnio";
            this.lueAnio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueAnio.Size = new System.Drawing.Size(139, 20);
            this.lueAnio.StyleController = this.layoutControl1;
            this.lueAnio.TabIndex = 4;
            this.lueAnio.EditValueChanged += new System.EventHandler(this.lueAnio_EditValueChanged);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(733, 44);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.lueAnio;
            this.layoutControlItem3.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.layoutControlItem3.CustomizationFormText = "Año";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(174, 24);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(174, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(174, 24);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Text = "Año";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(19, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(174, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(539, 24);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.lciBaseReq;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(737, 373);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.layoutControl1;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(737, 48);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // gcSeleccion
            // 
            this.gcSeleccion.Caption = "Seleccion";
            this.gcSeleccion.FieldName = "Seleccion";
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
            this.gcSeleccion.Width = 30;
            // 
            // gcOrigen
            // 
            this.gcOrigen.Caption = "Origen";
            this.gcOrigen.FieldName = "idOrigen";
            this.gcOrigen.Name = "gcOrigen";
            this.gcOrigen.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcOrigen.Visible = true;
            this.gcOrigen.VisibleIndex = 1;
            this.gcOrigen.Width = 30;
            // 
            // gcSuministro
            // 
            this.gcSuministro.Caption = "Suministro";
            this.gcSuministro.FieldName = "numero";
            this.gcSuministro.Name = "gcSuministro";
            this.gcSuministro.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcSuministro.Visible = true;
            this.gcSuministro.VisibleIndex = 2;
            this.gcSuministro.Width = 39;
            // 
            // gcSubPresupuesto
            // 
            this.gcSubPresupuesto.Caption = "SubPresupuesto";
            this.gcSubPresupuesto.FieldName = "nomSubPresupuesto";
            this.gcSubPresupuesto.Name = "gcSubPresupuesto";
            this.gcSubPresupuesto.Visible = true;
            this.gcSubPresupuesto.VisibleIndex = 3;
            this.gcSubPresupuesto.Width = 62;
            // 
            // gcPresupuesto
            // 
            this.gcPresupuesto.Caption = "Presupuesto";
            this.gcPresupuesto.FieldName = "nomPresupuesto";
            this.gcPresupuesto.Name = "gcPresupuesto";
            this.gcPresupuesto.Visible = true;
            this.gcPresupuesto.VisibleIndex = 5;
            this.gcPresupuesto.Width = 59;
            // 
            // gcGrupoPresupuesto
            // 
            this.gcGrupoPresupuesto.Caption = "GrupoPresupuesto";
            this.gcGrupoPresupuesto.FieldName = "nomGruPresupuesto";
            this.gcGrupoPresupuesto.Name = "gcGrupoPresupuesto";
            this.gcGrupoPresupuesto.Visible = true;
            this.gcGrupoPresupuesto.VisibleIndex = 4;
            // 
            // gcMes
            // 
            this.gcMes.Caption = "Mes";
            this.gcMes.FieldName = "mes";
            this.gcMes.Name = "gcMes";
            this.gcMes.Visible = true;
            this.gcMes.VisibleIndex = 6;
            this.gcMes.Width = 50;
            // 
            // gcDescripcion
            // 
            this.gcDescripcion.Caption = "Descripcion";
            this.gcDescripcion.FieldName = "anexo";
            this.gcDescripcion.Name = "gcDescripcion";
            this.gcDescripcion.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcDescripcion.Visible = true;
            this.gcDescripcion.VisibleIndex = 7;
            this.gcDescripcion.Width = 49;
            // 
            // gcSede
            // 
            this.gcSede.Caption = "Sede";
            this.gcSede.FieldName = "desSede";
            this.gcSede.Name = "gcSede";
            this.gcSede.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcSede.Visible = true;
            this.gcSede.VisibleIndex = 8;
            this.gcSede.Width = 49;
            // 
            // gcSubdireccion
            // 
            this.gcSubdireccion.Caption = "Subdireccion";
            this.gcSubdireccion.FieldName = "desSubdireccion";
            this.gcSubdireccion.Name = "gcSubdireccion";
            this.gcSubdireccion.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcSubdireccion.Visible = true;
            this.gcSubdireccion.VisibleIndex = 9;
            this.gcSubdireccion.Width = 49;
            // 
            // gcDireccion
            // 
            this.gcDireccion.Caption = "Direccion";
            this.gcDireccion.FieldName = "desDireccion";
            this.gcDireccion.Name = "gcDireccion";
            this.gcDireccion.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcDireccion.Visible = true;
            this.gcDireccion.VisibleIndex = 10;
            this.gcDireccion.Width = 49;
            // 
            // gcEstimado
            // 
            this.gcEstimado.Caption = "Estimado";
            this.gcEstimado.FieldName = "montoEstimado";
            this.gcEstimado.Name = "gcEstimado";
            this.gcEstimado.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcEstimado.Visible = true;
            this.gcEstimado.VisibleIndex = 11;
            this.gcEstimado.Width = 49;
            // 
            // gcReal
            // 
            this.gcReal.Caption = "Real";
            this.gcReal.FieldName = "montoReal";
            this.gcReal.Name = "gcReal";
            this.gcReal.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcReal.Visible = true;
            this.gcReal.VisibleIndex = 12;
            this.gcReal.Width = 56;
            // 
            // gcEstado
            // 
            this.gcEstado.Caption = "Estado";
            this.gcEstado.FieldName = "estado";
            this.gcEstado.Name = "gcEstado";
            // 
            // frmActualizarPorRequerimientoBienServicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 511);
            this.Name = "frmActualizarPorRequerimientoBienServicio";
            this.Text = "";
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcBase)).EndInit();
            this.lcBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxProveedorValidador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBaseReq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lueAnio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.Columns.GridColumn gcSeleccion;
        private DevExpress.XtraGrid.Columns.GridColumn gcOrigen;
        private DevExpress.XtraGrid.Columns.GridColumn gcSuministro;
        private DevExpress.XtraGrid.Columns.GridColumn gcSubPresupuesto;
        private DevExpress.XtraGrid.Columns.GridColumn gcPresupuesto;
        private DevExpress.XtraGrid.Columns.GridColumn gcGrupoPresupuesto;
        private DevExpress.XtraGrid.Columns.GridColumn gcMes;
        private DevExpress.XtraGrid.Columns.GridColumn gcDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn gcSede;
        private DevExpress.XtraGrid.Columns.GridColumn gcSubdireccion;
        private DevExpress.XtraGrid.Columns.GridColumn gcDireccion;
        private DevExpress.XtraGrid.Columns.GridColumn gcEstimado;
        private DevExpress.XtraGrid.Columns.GridColumn gcReal;
        private DevExpress.XtraGrid.Columns.GridColumn gcEstado;
        private DevExpress.XtraLayout.LayoutControl lciBaseReq;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.LookUpEdit lueAnio;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}