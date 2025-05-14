namespace SIA_Presupuesto.WinForm
{
    partial class Principal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.nbcMenuPrincipal = new DevExpress.XtraNavBar.NavBarControl();
            this.dmFormulario = new DevExpress.XtraBars.Docking.DockManager();
            this.badcOpciones = new DevExpress.XtraBars.BarAndDockingController();
            this.dmDocumentos = new DevExpress.XtraBars.Docking2010.DocumentManager();
            this.tvVista = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView();
            this.pmExportacion = new DevExpress.XtraBars.PopupMenu();
            this.ssDatos = new System.Windows.Forms.StatusStrip();
            this.tsslPeriodoActivo = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssbPeriodo = new System.Windows.Forms.ToolStripSplitButton();
            ((System.ComponentModel.ISupportInitialize)(this.nbcMenuPrincipal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dmFormulario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.badcOpciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dmDocumentos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tvVista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmExportacion)).BeginInit();
            this.ssDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // nbcMenuPrincipal
            // 
            this.nbcMenuPrincipal.ActiveGroup = null;
            this.nbcMenuPrincipal.Dock = System.Windows.Forms.DockStyle.Left;
            this.nbcMenuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.nbcMenuPrincipal.Name = "nbcMenuPrincipal";
            this.nbcMenuPrincipal.OptionsNavPane.ExpandedWidth = 186;
            this.nbcMenuPrincipal.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.nbcMenuPrincipal.Size = new System.Drawing.Size(186, 580);
            this.nbcMenuPrincipal.TabIndex = 0;
            this.nbcMenuPrincipal.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbcMenuPrincipal_LinkClicked);
            // 
            // dmFormulario
            // 
            this.dmFormulario.Controller = this.badcOpciones;
            this.dmFormulario.Form = this;
            this.dmFormulario.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane",
            "DevExpress.XtraBars.TabFormControl"});
            // 
            // badcOpciones
            // 
            this.badcOpciones.PropertiesBar.DefaultGlyphSize = new System.Drawing.Size(16, 16);
            this.badcOpciones.PropertiesBar.DefaultLargeGlyphSize = new System.Drawing.Size(32, 32);
            // 
            // dmDocumentos
            // 
            this.dmDocumentos.BarAndDockingController = this.badcOpciones;
            this.dmDocumentos.MdiParent = this;
            this.dmDocumentos.ShowThumbnailsInTaskBar = DevExpress.Utils.DefaultBoolean.False;
            this.dmDocumentos.ShowToolTips = DevExpress.Utils.DefaultBoolean.False;
            this.dmDocumentos.View = this.tvVista;
            this.dmDocumentos.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.tvVista});
            // 
            // tvVista
            // 
            this.tvVista.RootContainer.Element = null;
            // 
            // pmExportacion
            // 
            this.pmExportacion.Name = "pmExportacion";
            // 
            // ssDatos
            // 
            this.ssDatos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslPeriodoActivo,
            this.tsslUsuario,
            this.tssbPeriodo});
            this.ssDatos.Location = new System.Drawing.Point(186, 558);
            this.ssDatos.Name = "ssDatos";
            this.ssDatos.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ssDatos.Size = new System.Drawing.Size(694, 22);
            this.ssDatos.TabIndex = 2;
            this.ssDatos.Text = "statusStrip1";
            // 
            // tsslPeriodoActivo
            // 
            this.tsslPeriodoActivo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.tsslPeriodoActivo.Name = "tsslPeriodoActivo";
            this.tsslPeriodoActivo.Size = new System.Drawing.Size(105, 17);
            this.tsslPeriodoActivo.Text = "<Periodo Activo>";
            // 
            // tsslUsuario
            // 
            this.tsslUsuario.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.tsslUsuario.Name = "tsslUsuario";
            this.tsslUsuario.Size = new System.Drawing.Size(65, 17);
            this.tsslUsuario.Text = "<Usuario>";
            // 
            // tssbPeriodo
            // 
            this.tssbPeriodo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.tssbPeriodo.Image = ((System.Drawing.Image)(resources.GetObject("tssbPeriodo.Image")));
            this.tssbPeriodo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tssbPeriodo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tssbPeriodo.Name = "tssbPeriodo";
            this.tssbPeriodo.RightToLeftAutoMirrorImage = true;
            this.tssbPeriodo.Size = new System.Drawing.Size(98, 20);
            this.tssbPeriodo.Text = "<Periodo>";
            this.tssbPeriodo.ButtonClick += new System.EventHandler(this.tssbPeriodo_ButtonClick);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 580);
            this.Controls.Add(this.ssDatos);
            this.Controls.Add(this.nbcMenuPrincipal);
            this.IsMdiContainer = true;
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SUBSISTEMA DE PRESUPUESTO";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.nbcMenuPrincipal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dmFormulario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.badcOpciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dmDocumentos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tvVista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmExportacion)).EndInit();
            this.ssDatos.ResumeLayout(false);
            this.ssDatos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraNavBar.NavBarControl nbcMenuPrincipal;
        private DevExpress.XtraBars.Docking.DockManager dmFormulario;
        private DevExpress.XtraBars.BarAndDockingController badcOpciones;
        private System.Windows.Forms.StatusStrip ssDatos;
        private DevExpress.XtraBars.Docking2010.DocumentManager dmDocumentos;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tvVista;
        private DevExpress.XtraBars.PopupMenu pmExportacion;
        private System.Windows.Forms.ToolStripStatusLabel tsslPeriodoActivo;
        private System.Windows.Forms.ToolStripStatusLabel tsslUsuario;
        private System.Windows.Forms.ToolStripSplitButton tssbPeriodo;
    }
}