namespace SIA_Presupuesto.WinForm.Programacion.Dialogo
{
    partial class frmTransferencia
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
            this.cboGrupoPresupuesto = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.cboMes = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.opcionesBarraGrid1 = new SIA_Presupuesto.WinForm.General.ControlesDiversos.OpcionesBarraGrid();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.grcTransferencia = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtImporte = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtTransferido = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtRestante = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.cboAnio = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcBase)).BeginInit();
            this.lcBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxProveedorValidador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboGrupoPresupuesto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcTransferencia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtImporte.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTransferido.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRestante.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAnio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            this.SuspendLayout();
            // 
            // lcCuerpo
            // 
            this.lcCuerpo.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(803, 132, 386, 350);
            this.lcCuerpo.Size = new System.Drawing.Size(784, 472);
            // 
            // lcgCuerpo
            // 
            this.lcgCuerpo.Size = new System.Drawing.Size(784, 472);
            // 
            // lcBase
            // 
            this.lcBase.Controls.Add(this.cboAnio);
            this.lcBase.Controls.Add(this.grcTransferencia);
            this.lcBase.Controls.Add(this.opcionesBarraGrid1);
            this.lcBase.Controls.Add(this.cboMes);
            this.lcBase.Controls.Add(this.cboGrupoPresupuesto);
            this.lcBase.Controls.Add(this.txtImporte);
            this.lcBase.Controls.Add(this.txtTransferido);
            this.lcBase.Controls.Add(this.txtRestante);
            this.lcBase.Size = new System.Drawing.Size(754, 402);
            // 
            // lcgBase
            // 
            this.lcgBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem2,
            this.layoutControlItem8,
            this.layoutControlGroup1});
            this.lcgBase.Size = new System.Drawing.Size(754, 402);
            // 
            // cboGrupoPresupuesto
            // 
            this.cboGrupoPresupuesto.Enabled = false;
            this.cboGrupoPresupuesto.Location = new System.Drawing.Point(110, 12);
            this.cboGrupoPresupuesto.Name = "cboGrupoPresupuesto";
            this.cboGrupoPresupuesto.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboGrupoPresupuesto.Size = new System.Drawing.Size(632, 20);
            this.cboGrupoPresupuesto.StyleController = this.lcBase;
            this.cboGrupoPresupuesto.TabIndex = 4;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.cboGrupoPresupuesto;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(734, 24);
            this.layoutControlItem1.Text = "Grupo Presupuestal";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(94, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 287);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(734, 95);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // cboMes
            // 
            this.cboMes.Location = new System.Drawing.Point(494, 36);
            this.cboMes.Name = "cboMes";
            this.cboMes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboMes.Size = new System.Drawing.Size(248, 20);
            this.cboMes.StyleController = this.lcBase;
            this.cboMes.TabIndex = 5;
            this.cboMes.EditValueChanged += new System.EventHandler(this.cboMes_EditValueChanged);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.cboMes;
            this.layoutControlItem2.Location = new System.Drawing.Point(384, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(350, 24);
            this.layoutControlItem2.Text = "Mes";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(94, 13);
            // 
            // opcionesBarraGrid1
            // 
            this.opcionesBarraGrid1.ConAgregar = true;
            this.opcionesBarraGrid1.ConDesMarcarTodos = false;
            this.opcionesBarraGrid1.ConMarcarTodos = false;
            this.opcionesBarraGrid1.ConModificar = true;
            this.opcionesBarraGrid1.ConNuevoDetalle = false;
            this.opcionesBarraGrid1.ConOtros = false;
            this.opcionesBarraGrid1.ConQuitar = true;
            this.opcionesBarraGrid1.ConVisualizar = false;
            this.opcionesBarraGrid1.Location = new System.Drawing.Point(24, 114);
            this.opcionesBarraGrid1.Name = "opcionesBarraGrid1";
            this.opcionesBarraGrid1.NombreAgregar = "Agregar";
            this.opcionesBarraGrid1.NombreModificar = "Editar";
            this.opcionesBarraGrid1.NombreNuevoDetalleRegistro = null;
            this.opcionesBarraGrid1.NombreOtros = null;
            this.opcionesBarraGrid1.NombreQuitar = "Quitar";
            this.opcionesBarraGrid1.Size = new System.Drawing.Size(706, 31);
            this.opcionesBarraGrid1.TabIndex = 6;
            this.opcionesBarraGrid1.AgregarRegistro += new System.EventHandler(this.opcionesBarraGrid1_AgregarRegistro);
            this.opcionesBarraGrid1.ModificarRegistro += new System.EventHandler(this.opcionesBarraGrid1_ModificarRegistro);
            this.opcionesBarraGrid1.QuitarRegistro += new System.EventHandler(this.opcionesBarraGrid1_QuitarRegistro);
            this.opcionesBarraGrid1.NuevoDetalleRegistro += new System.EventHandler(this.opcionesBarraGrid1_NuevoDetalleRegistro);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.opcionesBarraGrid1;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(710, 35);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // grcTransferencia
            // 
            this.grcTransferencia.Location = new System.Drawing.Point(24, 149);
            this.grcTransferencia.MainView = this.gridView1;
            this.grcTransferencia.Name = "grcTransferencia";
            this.grcTransferencia.Size = new System.Drawing.Size(706, 134);
            this.grcTransferencia.TabIndex = 7;
            this.grcTransferencia.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn5,
            this.gridColumn3,
            this.gridColumn4});
            this.gridView1.GridControl = this.grcTransferencia;
            this.gridView1.Name = "gridView1";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "gridColumn1";
            this.gridColumn1.FieldName = "idGruPre";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Grupo Presupuesto";
            this.gridColumn2.FieldName = "nombreGruPre";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 753;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Mes";
            this.gridColumn5.FieldName = "nombreMes";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 2;
            this.gridColumn5.Width = 165;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Año";
            this.gridColumn3.FieldName = "anio";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 217;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Importe";
            this.gridColumn4.FieldName = "importe";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 177;
            // 
            // txtImporte
            // 
            this.txtImporte.Enabled = false;
            this.txtImporte.Location = new System.Drawing.Point(110, 60);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Properties.Mask.EditMask = "n2";
            this.txtImporte.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtImporte.Size = new System.Drawing.Size(155, 20);
            this.txtImporte.StyleController = this.lcBase;
            this.txtImporte.TabIndex = 8;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtImporte;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(257, 24);
            this.layoutControlItem5.Text = "Importe ";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(94, 13);
            // 
            // txtTransferido
            // 
            this.txtTransferido.Enabled = false;
            this.txtTransferido.Location = new System.Drawing.Point(367, 60);
            this.txtTransferido.Name = "txtTransferido";
            this.txtTransferido.Properties.Mask.EditMask = "n2";
            this.txtTransferido.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTransferido.Size = new System.Drawing.Size(139, 20);
            this.txtTransferido.StyleController = this.lcBase;
            this.txtTransferido.TabIndex = 9;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.txtTransferido;
            this.layoutControlItem6.Location = new System.Drawing.Point(257, 48);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(241, 24);
            this.layoutControlItem6.Text = "Importe transferido";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(94, 13);
            // 
            // txtRestante
            // 
            this.txtRestante.Enabled = false;
            this.txtRestante.Location = new System.Drawing.Point(608, 60);
            this.txtRestante.Name = "txtRestante";
            this.txtRestante.Properties.Mask.EditMask = "n2";
            this.txtRestante.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtRestante.Size = new System.Drawing.Size(134, 20);
            this.txtRestante.StyleController = this.lcBase;
            this.txtRestante.TabIndex = 10;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.txtRestante;
            this.layoutControlItem7.Location = new System.Drawing.Point(498, 48);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(236, 24);
            this.layoutControlItem7.Text = "Importe restante";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(94, 13);
            // 
            // cboAnio
            // 
            this.cboAnio.Location = new System.Drawing.Point(110, 36);
            this.cboAnio.Name = "cboAnio";
            this.cboAnio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboAnio.Size = new System.Drawing.Size(282, 20);
            this.cboAnio.StyleController = this.lcBase;
            this.cboAnio.TabIndex = 11;
            this.cboAnio.EditValueChanged += new System.EventHandler(this.cboAnio_EditValueChanged);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.cboAnio;
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(384, 24);
            this.layoutControlItem8.Text = "Año";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(94, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.grcTransferencia;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 35);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(710, 138);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem4});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 72);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(734, 215);
            this.layoutControlGroup1.Text = "Lista de Grupos Presupuestales a Transferir";
            // 
            // frmTransferencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 472);
            this.Name = "frmTransferencia";
            this.Text = "frmTransferencia";
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcBase)).EndInit();
            this.lcBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxProveedorValidador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboGrupoPresupuesto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcTransferencia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtImporte.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTransferido.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRestante.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAnio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit cboGrupoPresupuesto;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.LookUpEdit cboMes;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private General.ControlesDiversos.OpcionesBarraGrid opcionesBarraGrid1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraGrid.GridControl grcTransferencia;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.TextEdit txtImporte;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.TextEdit txtTransferido;
        private DevExpress.XtraEditors.TextEdit txtRestante;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraEditors.LookUpEdit cboAnio;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
    }
}