namespace SIA_Presupuesto.WinForm.General.Ayuda
{
    partial class frmAyudaPresupuesto
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
            this.grcPresupuesto = new DevExpress.XtraGrid.GridControl();
            this.grvPresupuesto = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.obgsSeleccion = new SIA_Presupuesto.WinForm.General.ControlesDiversos.OpcionesBarraGridSeleccion();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gbCuerpo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).BeginInit();
            this.lcCuerpo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcPresupuesto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPresupuesto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // gbCuerpo
            // 
            this.gbCuerpo.Size = new System.Drawing.Size(607, 305);
            // 
            // lcCuerpo
            // 
            this.lcCuerpo.Controls.Add(this.obgsSeleccion);
            this.lcCuerpo.Controls.Add(this.grcPresupuesto);
            this.lcCuerpo.Size = new System.Drawing.Size(601, 285);
            // 
            // lcgCuerpo
            // 
            this.lcgCuerpo.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.lcgCuerpo.Size = new System.Drawing.Size(601, 285);
            // 
            // grcPresupuesto
            // 
            this.grcPresupuesto.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.grcPresupuesto.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.grcPresupuesto.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.grcPresupuesto.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.grcPresupuesto.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.grcPresupuesto.Location = new System.Drawing.Point(12, 40);
            this.grcPresupuesto.MainView = this.grvPresupuesto;
            this.grcPresupuesto.Name = "grcPresupuesto";
            this.grcPresupuesto.Size = new System.Drawing.Size(577, 233);
            this.grcPresupuesto.TabIndex = 4;
            this.grcPresupuesto.UseEmbeddedNavigator = true;
            this.grcPresupuesto.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvPresupuesto});
            // 
            // grvPresupuesto
            // 
            this.grvPresupuesto.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcCodigo,
            this.gcDescripcion});
            this.grvPresupuesto.GridControl = this.grcPresupuesto;
            this.grvPresupuesto.Name = "grvPresupuesto";
            this.grvPresupuesto.OptionsBehavior.Editable = false;
            this.grvPresupuesto.OptionsView.ColumnAutoWidth = false;
            this.grvPresupuesto.OptionsView.ShowAutoFilterRow = true;
            this.grvPresupuesto.OptionsView.ShowGroupPanel = false;
            // 
            // gcCodigo
            // 
            this.gcCodigo.Caption = "Código";
            this.gcCodigo.Name = "gcCodigo";
            this.gcCodigo.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Like;
            this.gcCodigo.Visible = true;
            this.gcCodigo.VisibleIndex = 1;
            this.gcCodigo.Width = 100;
            // 
            // gcDescripcion
            // 
            this.gcDescripcion.Caption = "Descripción";
            this.gcDescripcion.Name = "gcDescripcion";
            this.gcDescripcion.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcDescripcion.Visible = true;
            this.gcDescripcion.VisibleIndex = 0;
            this.gcDescripcion.Width = 459;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grcPresupuesto;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 28);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(581, 237);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // obgsSeleccion
            // 
            this.obgsSeleccion.Location = new System.Drawing.Point(12, 12);
            this.obgsSeleccion.Name = "obgsSeleccion";
            this.obgsSeleccion.Size = new System.Drawing.Size(577, 24);
            this.obgsSeleccion.TabIndex = 5;
            this.obgsSeleccion.SeleccionarRegistro += new System.EventHandler(this.obgsSeleccion_SeleccionarRegistro);
            this.obgsSeleccion.SiguienteRegistro += new System.EventHandler(this.obgsSeleccion_SiguienteRegistro);
            this.obgsSeleccion.AnteriorRegistro += new System.EventHandler(this.obgsSeleccion_AnteriorRegistro);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.obgsSeleccion;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(581, 28);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // frmAyudaPresupuesto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 355);
            this.Name = "frmAyudaPresupuesto";
            this.Text = "Ayuda Presupuesto";
            this.gbCuerpo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).EndInit();
            this.lcCuerpo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcPresupuesto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPresupuesto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grcPresupuesto;
        private DevExpress.XtraGrid.Views.Grid.GridView grvPresupuesto;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gcDescripcion;
        private ControlesDiversos.OpcionesBarraGridSeleccion obgsSeleccion;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.Columns.GridColumn gcCodigo;
    }
}