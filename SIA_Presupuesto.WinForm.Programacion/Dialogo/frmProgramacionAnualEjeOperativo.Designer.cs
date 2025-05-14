namespace SIA_Presupuesto.WinForm.Programacion.Dialogo
{
    partial class frmProgramacionAnualEjeOperativo
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
            this.grcEjeOpe = new DevExpress.XtraGrid.GridControl();
            this.grvEjeOpe = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcEje = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcObservacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lueEjeOpe = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.sbAgregar = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.sbQuitar = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gbCuerpo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).BeginInit();
            this.lcCuerpo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcEjeOpe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEjeOpe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueEjeOpe.Properties)).BeginInit();
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
            this.lcCuerpo.Controls.Add(this.lueEjeOpe);
            this.lcCuerpo.Controls.Add(this.grcEjeOpe);
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
            // grcEjeOpe
            // 
            this.grcEjeOpe.Location = new System.Drawing.Point(12, 38);
            this.grcEjeOpe.MainView = this.grvEjeOpe;
            this.grcEjeOpe.Name = "grcEjeOpe";
            this.grcEjeOpe.Size = new System.Drawing.Size(654, 347);
            this.grcEjeOpe.TabIndex = 4;
            this.grcEjeOpe.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvEjeOpe});
            // 
            // grvEjeOpe
            // 
            this.grvEjeOpe.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcEje,
            this.gcObservacion});
            this.grvEjeOpe.GridControl = this.grcEjeOpe;
            this.grvEjeOpe.Name = "grvEjeOpe";
            this.grvEjeOpe.OptionsView.ShowGroupPanel = false;
            this.grvEjeOpe.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvEjeOpe_CellValueChanged);
            // 
            // gcEje
            // 
            this.gcEje.Caption = "Eje Operativo";
            this.gcEje.FieldName = "ejeOperativo";
            this.gcEje.Name = "gcEje";
            this.gcEje.OptionsColumn.AllowEdit = false;
            this.gcEje.Visible = true;
            this.gcEje.VisibleIndex = 0;
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
            this.layoutControlItem1.Control = this.grcEjeOpe;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(658, 351);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // lueEjeOpe
            // 
            this.lueEjeOpe.Location = new System.Drawing.Point(82, 12);
            this.lueEjeOpe.Name = "lueEjeOpe";
            this.lueEjeOpe.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueEjeOpe.Size = new System.Drawing.Size(255, 20);
            this.lueEjeOpe.StyleController = this.lcCuerpo;
            this.lueEjeOpe.TabIndex = 5;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.lueEjeOpe;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(329, 26);
            this.layoutControlItem2.Text = "Eje Operativo";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(66, 13);
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
            // frmProgramacionAnualEjeOperativo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 467);
            this.Name = "frmProgramacionAnualEjeOperativo";
            this.Text = "frmProgramacionAnualSede";
            this.gbCuerpo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).EndInit();
            this.lcCuerpo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcEjeOpe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEjeOpe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueEjeOpe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton sbAgregar;
        private DevExpress.XtraEditors.LookUpEdit lueEjeOpe;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraGrid.GridControl grcEjeOpe;
        private DevExpress.XtraGrid.Views.Grid.GridView grvEjeOpe;
        private DevExpress.XtraGrid.Columns.GridColumn gcEje;
        private DevExpress.XtraGrid.Columns.GridColumn gcObservacion;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.SimpleButton sbQuitar;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}