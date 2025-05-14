namespace SIA_Presupuesto.WinForm.General.ControlesDiversos
{
    partial class OpcionesBarraGridMarcar
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.BarraPrincipal = new DevExpress.XtraBars.Bar();
            this.bbiMarcarTodos = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDesmarcarTodos = new DevExpress.XtraBars.BarButtonItem();
            this.bbiMarcar = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDesmarcar = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSiguiente = new DevExpress.XtraBars.BarButtonItem();
            this.bbiAnterior = new DevExpress.XtraBars.BarButtonItem();
            this.beiCantidad = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.bciPermitirEditar = new DevExpress.XtraBars.BarCheckItem();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.AllowCustomization = false;
            this.barManager1.AllowQuickCustomization = false;
            this.barManager1.AllowShowToolbarsPopup = false;
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.BarraPrincipal});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bciPermitirEditar,
            this.bbiMarcarTodos,
            this.bbiMarcar,
            this.bbiDesmarcarTodos,
            this.bbiDesmarcar,
            this.bbiSiguiente,
            this.bbiAnterior,
            this.beiCantidad});
            this.barManager1.MaxItemId = 10;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1});
            // 
            // BarraPrincipal
            // 
            this.BarraPrincipal.BarName = "Menu Principal";
            this.BarraPrincipal.DockCol = 0;
            this.BarraPrincipal.DockRow = 0;
            this.BarraPrincipal.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.BarraPrincipal.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiMarcarTodos, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiDesmarcarTodos, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiMarcar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiDesmarcar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiSiguiente, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiAnterior, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.beiCantidad)});
            this.BarraPrincipal.OptionsBar.AllowQuickCustomization = false;
            this.BarraPrincipal.OptionsBar.DrawDragBorder = false;
            this.BarraPrincipal.OptionsBar.UseWholeRow = true;
            this.BarraPrincipal.Text = "Menu Principal";
            // 
            // bbiMarcarTodos
            // 
            this.bbiMarcarTodos.Caption = "Marcar Todos";
            this.bbiMarcarTodos.Hint = "Marca todos los registros";
            this.bbiMarcarTodos.Id = 1;
            this.bbiMarcarTodos.Name = "bbiMarcarTodos";
            this.bbiMarcarTodos.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiMarcarTodos_ItemClick);
            // 
            // bbiDesmarcarTodos
            // 
            this.bbiDesmarcarTodos.Caption = "Desmarcar Todos";
            this.bbiDesmarcarTodos.Hint = "Desmarca todos los registros seleccionados";
            this.bbiDesmarcarTodos.Id = 4;
            this.bbiDesmarcarTodos.Name = "bbiDesmarcarTodos";
            this.bbiDesmarcarTodos.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiDesmarcarTodos_ItemClick);
            // 
            // bbiMarcar
            // 
            this.bbiMarcar.Caption = "Marcar";
            this.bbiMarcar.Hint = "Desmarca el registro actual";
            this.bbiMarcar.Id = 2;
            this.bbiMarcar.Name = "bbiMarcar";
            this.bbiMarcar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiMarcar_ItemClick);
            // 
            // bbiDesmarcar
            // 
            this.bbiDesmarcar.Caption = "Desmarcar";
            this.bbiDesmarcar.Hint = "Desmarca el registro actual";
            this.bbiDesmarcar.Id = 6;
            this.bbiDesmarcar.Name = "bbiDesmarcar";
            this.bbiDesmarcar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiDesmarcar_ItemClick);
            // 
            // bbiSiguiente
            // 
            this.bbiSiguiente.Caption = "Siguiente";
            this.bbiSiguiente.Hint = "Desplaza al siguiente registro";
            this.bbiSiguiente.Id = 7;
            this.bbiSiguiente.Name = "bbiSiguiente";
            this.bbiSiguiente.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSiguiente_ItemClick);
            // 
            // bbiAnterior
            // 
            this.bbiAnterior.Caption = "Anterior";
            this.bbiAnterior.Hint = "Desplaza al anterior registro";
            this.bbiAnterior.Id = 8;
            this.bbiAnterior.Name = "bbiAnterior";
            this.bbiAnterior.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiAnterior_ItemClick);
            // 
            // beiCantidad
            // 
            this.beiCantidad.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.beiCantidad.Edit = this.repositoryItemTextEdit1;
            this.beiCantidad.EditValue = "0";
            this.beiCantidad.Id = 9;
            this.beiCantidad.Name = "beiCantidad";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            this.repositoryItemTextEdit1.ReadOnly = true;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(513, 29);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 25);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(513, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 29);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 0);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(513, 29);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 0);
            // 
            // bciPermitirEditar
            // 
            this.bciPermitirEditar.Caption = "Permitir Editar";
            this.bciPermitirEditar.Hint = "Permitir Editar";
            this.bciPermitirEditar.Id = 0;
            this.bciPermitirEditar.Name = "bciPermitirEditar";
            this.bciPermitirEditar.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // OpcionesBarraGridMarcar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "OpcionesBarraGridMarcar";
            this.Size = new System.Drawing.Size(513, 25);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar BarraPrincipal;
        private DevExpress.XtraBars.BarCheckItem bciPermitirEditar;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem bbiMarcarTodos;
        private DevExpress.XtraBars.BarButtonItem bbiMarcar;
        private DevExpress.XtraBars.BarButtonItem bbiDesmarcarTodos;
        private DevExpress.XtraBars.BarButtonItem bbiDesmarcar;
        private DevExpress.XtraBars.BarButtonItem bbiSiguiente;
        private DevExpress.XtraBars.BarButtonItem bbiAnterior;
        private DevExpress.XtraBars.BarEditItem beiCantidad;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
    }
}
