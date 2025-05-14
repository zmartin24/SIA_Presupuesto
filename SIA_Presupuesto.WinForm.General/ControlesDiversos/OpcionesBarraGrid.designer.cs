namespace SIA_Presupuesto.WinForm.General.ControlesDiversos
{
    partial class OpcionesBarraGrid
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
            this.barManager1 = new DevExpress.XtraBars.BarManager();
            this.BarraPrincipal = new DevExpress.XtraBars.Bar();
            this.bbiMarcarTodos = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDesmarcarTodos = new DevExpress.XtraBars.BarButtonItem();
            this.bciPermitirEditar = new DevExpress.XtraBars.BarCheckItem();
            this.bbiAgregar = new DevExpress.XtraBars.BarButtonItem();
            this.bbiModificar = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEliminar = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDetalleAdicional = new DevExpress.XtraBars.BarButtonItem();
            this.bbiVisualizar = new DevExpress.XtraBars.BarButtonItem();
            this.bbNuevoDetalle = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
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
            this.bbiAgregar,
            this.bbiEliminar,
            this.bbiModificar,
            this.bbiDetalleAdicional,
            this.bbiVisualizar,
            this.bbiMarcarTodos,
            this.bbiDesmarcarTodos,
            this.bbNuevoDetalle});
            this.barManager1.MaxItemId = 15;
            // 
            // BarraPrincipal
            // 
            this.BarraPrincipal.BarName = "Menu Principal";
            this.BarraPrincipal.DockCol = 0;
            this.BarraPrincipal.DockRow = 0;
            this.BarraPrincipal.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.BarraPrincipal.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiMarcarTodos, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(((DevExpress.XtraBars.BarLinkUserDefines)((DevExpress.XtraBars.BarLinkUserDefines.Caption | DevExpress.XtraBars.BarLinkUserDefines.PaintStyle))), this.bbiDesmarcarTodos, "Desmarcar Todos", false, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.bciPermitirEditar),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiAgregar, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiModificar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiEliminar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiDetalleAdicional, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiVisualizar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbNuevoDetalle, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.BarraPrincipal.OptionsBar.AllowQuickCustomization = false;
            this.BarraPrincipal.OptionsBar.DrawDragBorder = false;
            this.BarraPrincipal.OptionsBar.UseWholeRow = true;
            this.BarraPrincipal.Text = "Menu Principal";
            // 
            // bbiMarcarTodos
            // 
            this.bbiMarcarTodos.Caption = "Marcar Todos";
            this.bbiMarcarTodos.Id = 12;
            this.bbiMarcarTodos.Name = "bbiMarcarTodos";
            this.bbiMarcarTodos.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbiMarcarTodos.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiMarcarTodos_ItemClick);
            // 
            // bbiDesmarcarTodos
            // 
            this.bbiDesmarcarTodos.Caption = "barButtonItem2";
            this.bbiDesmarcarTodos.Id = 13;
            this.bbiDesmarcarTodos.Name = "bbiDesmarcarTodos";
            this.bbiDesmarcarTodos.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbiDesmarcarTodos.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiDesmarcarTodos_ItemClick);
            // 
            // bciPermitirEditar
            // 
            this.bciPermitirEditar.Caption = "Permitir Editar";
            this.bciPermitirEditar.Hint = "Permitir Editar";
            this.bciPermitirEditar.Id = 0;
            this.bciPermitirEditar.Name = "bciPermitirEditar";
            this.bciPermitirEditar.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bciPermitirEditar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bciPermitirEditar.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.bciPermitirEditar_CheckedChanged);
            // 
            // bbiAgregar
            // 
            this.bbiAgregar.Caption = "Agregar";
            this.bbiAgregar.Hint = "Agregar nuevo registro";
            this.bbiAgregar.Id = 1;
            this.bbiAgregar.Name = "bbiAgregar";
            this.bbiAgregar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbiAgregar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiAgregar_ItemClick);
            // 
            // bbiModificar
            // 
            this.bbiModificar.Caption = "Modificar";
            this.bbiModificar.Hint = "Modifica el registro seleccionado";
            this.bbiModificar.Id = 4;
            this.bbiModificar.Name = "bbiModificar";
            this.bbiModificar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbiModificar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiModificar_ItemClick);
            // 
            // bbiEliminar
            // 
            this.bbiEliminar.Caption = "Quitar";
            this.bbiEliminar.Hint = "Quita el registro seleccionado";
            this.bbiEliminar.Id = 2;
            this.bbiEliminar.Name = "bbiEliminar";
            this.bbiEliminar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbiEliminar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiEliminar_ItemClick);
            // 
            // bbiDetalleAdicional
            // 
            this.bbiDetalleAdicional.Caption = "Otros";
            this.bbiDetalleAdicional.Id = 6;
            this.bbiDetalleAdicional.Name = "bbiDetalleAdicional";
            this.bbiDetalleAdicional.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbiDetalleAdicional.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiDetalleAdicional_ItemClick);
            // 
            // bbiVisualizar
            // 
            this.bbiVisualizar.Caption = "Visualizar";
            this.bbiVisualizar.Id = 7;
            this.bbiVisualizar.Name = "bbiVisualizar";
            this.bbiVisualizar.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbiVisualizar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbiVisualizar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiVisualizar_ItemClick);
            // 
            // bbNuevoDetalle
            // 
            this.bbNuevoDetalle.Caption = "Nuevo Detalle";
            this.bbNuevoDetalle.Id = 14;
            this.bbNuevoDetalle.Name = "bbNuevoDetalle";
            this.bbNuevoDetalle.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbNuevoDetalle_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(649, 29);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 30);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(649, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 29);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 1);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(649, 29);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 1);
            // 
            // OpcionesBarraGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "OpcionesBarraGrid";
            this.Size = new System.Drawing.Size(649, 30);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarCheckItem bciPermitirEditar;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem bbiAgregar;
        private DevExpress.XtraBars.BarButtonItem bbiEliminar;
        private DevExpress.XtraBars.BarButtonItem bbiModificar;
        private DevExpress.XtraBars.BarButtonItem bbiDetalleAdicional;
        private DevExpress.XtraBars.BarButtonItem bbiVisualizar;
        protected internal DevExpress.XtraBars.Bar BarraPrincipal;
        private DevExpress.XtraBars.BarButtonItem bbiMarcarTodos;
        private DevExpress.XtraBars.BarButtonItem bbiDesmarcarTodos;
        private DevExpress.XtraBars.BarButtonItem bbNuevoDetalle;
    }
}
