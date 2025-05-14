namespace SIA_Presupuesto.WinForm.General.Base
{
    partial class frmDialogoBaseSecuencial
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
            this.components = new System.ComponentModel.Container();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.sbImprimir = new DevExpress.XtraEditors.SimpleButton();
            this.sbOperacion = new DevExpress.XtraEditors.SimpleButton();
            this.sbSalir = new DevExpress.XtraEditors.SimpleButton();
            this.sbSiguiente = new DevExpress.XtraEditors.SimpleButton();
            this.sbAnterior = new DevExpress.XtraEditors.SimpleButton();
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.lcCuerpo = new DevExpress.XtraLayout.LayoutControl();
            this.lcgCuerpo = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lcgPrincipal = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciSiguiente = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciGuardar = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciImprimir = new DevExpress.XtraLayout.LayoutControlItem();
            this.dxProveedorValidador = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            this.gbDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgPrincipal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSiguiente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciGuardar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciImprimir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxProveedorValidador)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.sbImprimir);
            this.layoutControl1.Controls.Add(this.sbOperacion);
            this.layoutControl1.Controls.Add(this.sbSalir);
            this.layoutControl1.Controls.Add(this.sbSiguiente);
            this.layoutControl1.Controls.Add(this.sbAnterior);
            this.layoutControl1.Controls.Add(this.gbDatos);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(929, 271, 250, 350);
            this.layoutControl1.Root = this.lcgPrincipal;
            this.layoutControl1.Size = new System.Drawing.Size(529, 322);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // sbImprimir
            // 
            this.sbImprimir.Location = new System.Drawing.Point(288, 288);
            this.sbImprimir.Name = "sbImprimir";
            this.sbImprimir.Size = new System.Drawing.Size(71, 22);
            this.sbImprimir.StyleController = this.layoutControl1;
            this.sbImprimir.TabIndex = 9;
            this.sbImprimir.Text = "Imprimir";
            this.sbImprimir.Click += new System.EventHandler(this.sbImprimir_Click);
            // 
            // sbOperacion
            // 
            this.sbOperacion.Location = new System.Drawing.Point(363, 288);
            this.sbOperacion.Name = "sbOperacion";
            this.sbOperacion.Size = new System.Drawing.Size(72, 22);
            this.sbOperacion.StyleController = this.layoutControl1;
            this.sbOperacion.TabIndex = 8;
            this.sbOperacion.Text = "Guardar";
            this.sbOperacion.Click += new System.EventHandler(this.sbOperacion_Click);
            // 
            // sbSalir
            // 
            this.sbSalir.Location = new System.Drawing.Point(439, 288);
            this.sbSalir.Name = "sbSalir";
            this.sbSalir.Size = new System.Drawing.Size(78, 22);
            this.sbSalir.StyleController = this.layoutControl1;
            this.sbSalir.TabIndex = 7;
            this.sbSalir.Text = "&Salir";
            this.sbSalir.Click += new System.EventHandler(this.sbSalir_Click);
            // 
            // sbSiguiente
            // 
            this.sbSiguiente.Location = new System.Drawing.Point(206, 288);
            this.sbSiguiente.Name = "sbSiguiente";
            this.sbSiguiente.Size = new System.Drawing.Size(78, 22);
            this.sbSiguiente.StyleController = this.layoutControl1;
            this.sbSiguiente.TabIndex = 6;
            this.sbSiguiente.Text = "&Siguiente>>";
            this.sbSiguiente.Click += new System.EventHandler(this.sbSiguiente_Click);
            // 
            // sbAnterior
            // 
            this.sbAnterior.Location = new System.Drawing.Point(117, 288);
            this.sbAnterior.Name = "sbAnterior";
            this.sbAnterior.Size = new System.Drawing.Size(85, 22);
            this.sbAnterior.StyleController = this.layoutControl1;
            this.sbAnterior.TabIndex = 5;
            this.sbAnterior.Text = "&<<Anterior";
            this.sbAnterior.Click += new System.EventHandler(this.sbAnterior_Click);
            // 
            // gbDatos
            // 
            this.gbDatos.Controls.Add(this.lcCuerpo);
            this.gbDatos.Location = new System.Drawing.Point(12, 12);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Size = new System.Drawing.Size(505, 272);
            this.gbDatos.TabIndex = 4;
            this.gbDatos.TabStop = false;
            // 
            // lcCuerpo
            // 
            this.lcCuerpo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcCuerpo.Location = new System.Drawing.Point(3, 17);
            this.lcCuerpo.Name = "lcCuerpo";
            this.lcCuerpo.Root = this.lcgCuerpo;
            this.lcCuerpo.Size = new System.Drawing.Size(499, 252);
            this.lcCuerpo.TabIndex = 0;
            this.lcCuerpo.Text = "layoutControl2";
            // 
            // lcgCuerpo
            // 
            this.lcgCuerpo.CustomizationFormText = "layoutControlGroup1";
            this.lcgCuerpo.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcgCuerpo.GroupBordersVisible = false;
            this.lcgCuerpo.Location = new System.Drawing.Point(0, 0);
            this.lcgCuerpo.Name = "lcgCuerpo";
            this.lcgCuerpo.Size = new System.Drawing.Size(499, 252);
            this.lcgCuerpo.Text = "lcgCuerpo";
            this.lcgCuerpo.TextVisible = false;
            // 
            // lcgPrincipal
            // 
            this.lcgPrincipal.CustomizationFormText = "layoutControlGroup1";
            this.lcgPrincipal.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcgPrincipal.GroupBordersVisible = false;
            this.lcgPrincipal.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.lciSiguiente,
            this.emptySpaceItem1,
            this.layoutControlItem4,
            this.lciGuardar,
            this.lciImprimir});
            this.lcgPrincipal.Location = new System.Drawing.Point(0, 0);
            this.lcgPrincipal.Name = "Root";
            this.lcgPrincipal.Size = new System.Drawing.Size(529, 322);
            this.lcgPrincipal.Text = "Root";
            this.lcgPrincipal.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gbDatos;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(509, 276);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.sbAnterior;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(105, 276);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(89, 26);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(89, 26);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(89, 26);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // lciSiguiente
            // 
            this.lciSiguiente.Control = this.sbSiguiente;
            this.lciSiguiente.CustomizationFormText = "layoutControlItem3";
            this.lciSiguiente.Location = new System.Drawing.Point(194, 276);
            this.lciSiguiente.MaxSize = new System.Drawing.Size(82, 26);
            this.lciSiguiente.MinSize = new System.Drawing.Size(82, 26);
            this.lciSiguiente.Name = "lciSiguiente";
            this.lciSiguiente.Size = new System.Drawing.Size(82, 26);
            this.lciSiguiente.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciSiguiente.Text = "lciSiguiente";
            this.lciSiguiente.TextSize = new System.Drawing.Size(0, 0);
            this.lciSiguiente.TextToControlDistance = 0;
            this.lciSiguiente.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 276);
            this.emptySpaceItem1.MaxSize = new System.Drawing.Size(0, 26);
            this.emptySpaceItem1.MinSize = new System.Drawing.Size(10, 26);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(105, 26);
            this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.sbSalir;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(427, 276);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(82, 26);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(82, 26);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(82, 26);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // lciGuardar
            // 
            this.lciGuardar.Control = this.sbOperacion;
            this.lciGuardar.CustomizationFormText = "lciGuardar";
            this.lciGuardar.Location = new System.Drawing.Point(351, 276);
            this.lciGuardar.MaxSize = new System.Drawing.Size(76, 26);
            this.lciGuardar.MinSize = new System.Drawing.Size(76, 26);
            this.lciGuardar.Name = "lciGuardar";
            this.lciGuardar.Size = new System.Drawing.Size(76, 26);
            this.lciGuardar.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciGuardar.Text = "lciGuardar";
            this.lciGuardar.TextSize = new System.Drawing.Size(0, 0);
            this.lciGuardar.TextToControlDistance = 0;
            this.lciGuardar.TextVisible = false;
            this.lciGuardar.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // lciImprimir
            // 
            this.lciImprimir.Control = this.sbImprimir;
            this.lciImprimir.CustomizationFormText = "lciImprimir";
            this.lciImprimir.Location = new System.Drawing.Point(276, 276);
            this.lciImprimir.MaxSize = new System.Drawing.Size(75, 26);
            this.lciImprimir.MinSize = new System.Drawing.Size(75, 26);
            this.lciImprimir.Name = "lciImprimir";
            this.lciImprimir.Size = new System.Drawing.Size(75, 26);
            this.lciImprimir.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciImprimir.Text = "lciImprimir";
            this.lciImprimir.TextSize = new System.Drawing.Size(0, 0);
            this.lciImprimir.TextToControlDistance = 0;
            this.lciImprimir.TextVisible = false;
            this.lciImprimir.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // frmDialogoBaseSecuencial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 322);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDialogoBaseSecuencial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmDialogoBase";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            this.gbDatos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgPrincipal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSiguiente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciGuardar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciImprimir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxProveedorValidador)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxProveedorValidador;
        protected DevExpress.XtraLayout.LayoutControlGroup lcgCuerpo;
        protected DevExpress.XtraLayout.LayoutControlGroup lcgPrincipal;
        protected System.Windows.Forms.GroupBox gbDatos;
        protected DevExpress.XtraLayout.LayoutControl lcCuerpo;
        protected DevExpress.XtraLayout.LayoutControl layoutControl1;
        protected DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem lciSiguiente;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.SimpleButton sbSiguiente;
        private DevExpress.XtraEditors.SimpleButton sbSalir;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.SimpleButton sbOperacion;
        private DevExpress.XtraLayout.LayoutControlItem lciGuardar;
        private DevExpress.XtraLayout.LayoutControlItem lciImprimir;
        protected DevExpress.XtraEditors.SimpleButton sbImprimir;
        protected DevExpress.XtraEditors.SimpleButton sbAnterior;
    }
}