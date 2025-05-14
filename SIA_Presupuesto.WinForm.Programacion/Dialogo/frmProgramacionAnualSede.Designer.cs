namespace SIA_Presupuesto.WinForm.Programacion.Dialogo
{
    partial class frmProgramacionAnualSede
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
            this.grcSede = new DevExpress.XtraGrid.GridControl();
            this.grvSede = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcSede = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcObservacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lueSede = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.sbAgregar = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.sbQuitar = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gbCuerpo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).BeginInit();
            this.lcCuerpo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcSede)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSede)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSede.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // gbCuerpo
            // 
            this.gbCuerpo.Size = new System.Drawing.Size(684, 417);
            // 
            // lcCuerpo
            // 
            this.lcCuerpo.Controls.Add(this.sbQuitar);
            this.lcCuerpo.Controls.Add(this.sbAgregar);
            this.lcCuerpo.Controls.Add(this.lueSede);
            this.lcCuerpo.Controls.Add(this.grcSede);
            this.lcCuerpo.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(803, 132, 386, 350);
            this.lcCuerpo.Size = new System.Drawing.Size(678, 397);
            // 
            // lcgCuerpo
            // 
            this.lcgCuerpo.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4});
            this.lcgCuerpo.Size = new System.Drawing.Size(678, 397);
            // 
            // grcSede
            // 
            this.grcSede.Location = new System.Drawing.Point(12, 38);
            this.grcSede.MainView = this.grvSede;
            this.grcSede.Name = "grcSede";
            this.grcSede.Size = new System.Drawing.Size(654, 347);
            this.grcSede.TabIndex = 4;
            this.grcSede.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvSede});
            // 
            // grvSede
            // 
            this.grvSede.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcSede,
            this.gcObservacion});
            this.grvSede.GridControl = this.grcSede;
            this.grvSede.Name = "grvSede";
            this.grvSede.OptionsView.ShowGroupPanel = false;
            this.grvSede.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvSede_CellValueChanged);
            // 
            // gcSede
            // 
            this.gcSede.Caption = "Sede";
            this.gcSede.FieldName = "desSede";
            this.gcSede.Name = "gcSede";
            this.gcSede.OptionsColumn.AllowEdit = false;
            this.gcSede.Visible = true;
            this.gcSede.VisibleIndex = 0;
            // 
            // gcObservacion
            // 
            this.gcObservacion.Caption = "Observación";
            this.gcObservacion.FieldName = "observacion";
            this.gcObservacion.Name = "gcObservacion";
            this.gcObservacion.Visible = true;
            this.gcObservacion.VisibleIndex = 1;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grcSede;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(658, 351);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // lueSede
            // 
            this.lueSede.Location = new System.Drawing.Point(40, 12);
            this.lueSede.Name = "lueSede";
            this.lueSede.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueSede.Size = new System.Drawing.Size(297, 20);
            this.lueSede.StyleController = this.lcCuerpo;
            this.lueSede.TabIndex = 5;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.lueSede;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(329, 26);
            this.layoutControlItem2.Text = "Sede";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(24, 13);
            // 
            // sbAgregar
            // 
            this.sbAgregar.Location = new System.Drawing.Point(341, 12);
            this.sbAgregar.Name = "sbAgregar";
            this.sbAgregar.Size = new System.Drawing.Size(160, 22);
            this.sbAgregar.StyleController = this.lcCuerpo;
            this.sbAgregar.TabIndex = 6;
            this.sbAgregar.Text = "&Agregar";
            this.sbAgregar.Click += new System.EventHandler(this.sbAgregar_Click);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.sbAgregar;
            this.layoutControlItem3.Location = new System.Drawing.Point(329, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(164, 26);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // sbQuitar
            // 
            this.sbQuitar.Location = new System.Drawing.Point(505, 12);
            this.sbQuitar.Name = "sbQuitar";
            this.sbQuitar.Size = new System.Drawing.Size(161, 22);
            this.sbQuitar.StyleController = this.lcCuerpo;
            this.sbQuitar.TabIndex = 7;
            this.sbQuitar.Text = "Quitar";
            this.sbQuitar.Click += new System.EventHandler(this.sbQuitar_Click);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.sbQuitar;
            this.layoutControlItem4.Location = new System.Drawing.Point(493, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(165, 26);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // frmProgramacionAnualSede
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 467);
            this.Name = "frmProgramacionAnualSede";
            this.Text = "frmProgramacionAnualSede";
            this.gbCuerpo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).EndInit();
            this.lcCuerpo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcSede)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSede)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSede.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton sbAgregar;
        private DevExpress.XtraEditors.LookUpEdit lueSede;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraGrid.GridControl grcSede;
        private DevExpress.XtraGrid.Views.Grid.GridView grvSede;
        private DevExpress.XtraGrid.Columns.GridColumn gcSede;
        private DevExpress.XtraGrid.Columns.GridColumn gcObservacion;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.SimpleButton sbQuitar;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}