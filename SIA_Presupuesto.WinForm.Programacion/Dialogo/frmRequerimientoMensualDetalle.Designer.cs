namespace SIA_Presupuesto.WinForm.Programacion.Dialogo
{
    partial class frmRequerimientoMensualDetalle
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
            this.txtDescripcion = new DevExpress.XtraEditors.MemoEdit();
            this.lueUnidad = new DevExpress.XtraEditors.LookUpEdit();
            this.seCantidad = new DevExpress.XtraEditors.SpinEdit();
            this.txtJustificacion = new DevExpress.XtraEditors.MemoEdit();
            this.seImporte = new DevExpress.XtraEditors.SpinEdit();
            this.sePrecio = new DevExpress.XtraEditors.SpinEdit();
            this.chkConParPre = new DevExpress.XtraEditors.CheckEdit();
            this.bteParPre = new DevExpress.XtraEditors.ButtonEdit();
            this.bteProducto = new DevExpress.XtraEditors.ButtonEdit();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciCantidad = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciSubTotal = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciPrecio = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciParPre = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciProducto = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtDesCuenta = new DevExpress.XtraEditors.TextEdit();
            this.lciDesCuenta = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcBase)).BeginInit();
            this.lcBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxProveedorValidador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueUnidad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seCantidad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtJustificacion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seImporte.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sePrecio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkConParPre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteParPre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteProducto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSubTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPrecio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciParPre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciProducto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesCuenta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDesCuenta)).BeginInit();
            this.SuspendLayout();
            // 
            // lcCuerpo
            // 
            this.lcCuerpo.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(803, 132, 386, 350);
            this.lcCuerpo.Size = new System.Drawing.Size(498, 344);
            // 
            // lcgCuerpo
            // 
            this.lcgCuerpo.Size = new System.Drawing.Size(498, 344);
            // 
            // lcBase
            // 
            this.lcBase.Controls.Add(this.txtDesCuenta);
            this.lcBase.Controls.Add(this.bteParPre);
            this.lcBase.Controls.Add(this.chkConParPre);
            this.lcBase.Controls.Add(this.txtJustificacion);
            this.lcBase.Controls.Add(this.seCantidad);
            this.lcBase.Controls.Add(this.lueUnidad);
            this.lcBase.Controls.Add(this.txtDescripcion);
            this.lcBase.Controls.Add(this.seImporte);
            this.lcBase.Controls.Add(this.sePrecio);
            this.lcBase.Controls.Add(this.bteProducto);
            this.lcBase.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(792, 36, 450, 400);
            this.lcBase.Size = new System.Drawing.Size(468, 274);
            // 
            // lcgBase
            // 
            this.lcgBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.lciCantidad,
            this.layoutControlItem5,
            this.lciSubTotal,
            this.lciPrecio,
            this.layoutControlItem3,
            this.lciParPre,
            this.lciProducto,
            this.emptySpaceItem1,
            this.lciDesCuenta});
            this.lcgBase.Name = "Root";
            this.lcgBase.Size = new System.Drawing.Size(468, 274);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(82, 108);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcion.Size = new System.Drawing.Size(374, 46);
            this.txtDescripcion.StyleController = this.lcBase;
            this.txtDescripcion.TabIndex = 4;
            // 
            // lueUnidad
            // 
            this.lueUnidad.Location = new System.Drawing.Point(82, 208);
            this.lueUnidad.Name = "lueUnidad";
            this.lueUnidad.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueUnidad.Size = new System.Drawing.Size(150, 20);
            this.lueUnidad.StyleController = this.lcBase;
            this.lueUnidad.TabIndex = 5;
            // 
            // seCantidad
            // 
            this.seCantidad.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seCantidad.Location = new System.Drawing.Point(82, 232);
            this.seCantidad.Name = "seCantidad";
            this.seCantidad.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.seCantidad.Size = new System.Drawing.Size(150, 20);
            this.seCantidad.StyleController = this.lcBase;
            this.seCantidad.TabIndex = 7;
            this.seCantidad.EditValueChanged += new System.EventHandler(this.seCantidad_EditValueChanged);
            // 
            // txtJustificacion
            // 
            this.txtJustificacion.Location = new System.Drawing.Point(82, 158);
            this.txtJustificacion.Name = "txtJustificacion";
            this.txtJustificacion.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtJustificacion.Size = new System.Drawing.Size(374, 46);
            this.txtJustificacion.StyleController = this.lcBase;
            this.txtJustificacion.TabIndex = 9;
            // 
            // seImporte
            // 
            this.seImporte.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seImporte.Location = new System.Drawing.Point(306, 232);
            this.seImporte.Name = "seImporte";
            this.seImporte.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.seImporte.Properties.ReadOnly = true;
            this.seImporte.Size = new System.Drawing.Size(150, 20);
            this.seImporte.StyleController = this.lcBase;
            this.seImporte.TabIndex = 7;
            // 
            // sePrecio
            // 
            this.sePrecio.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.sePrecio.Location = new System.Drawing.Point(306, 208);
            this.sePrecio.Name = "sePrecio";
            this.sePrecio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.sePrecio.Size = new System.Drawing.Size(150, 20);
            this.sePrecio.StyleController = this.lcBase;
            this.sePrecio.TabIndex = 7;
            this.sePrecio.EditValueChanged += new System.EventHandler(this.sePrecio_EditValueChanged);
            // 
            // chkConParPre
            // 
            this.chkConParPre.Location = new System.Drawing.Point(12, 12);
            this.chkConParPre.Name = "chkConParPre";
            this.chkConParPre.Properties.Caption = "Con Partida Pre.";
            this.chkConParPre.Size = new System.Drawing.Size(444, 20);
            this.chkConParPre.StyleController = this.lcBase;
            this.chkConParPre.TabIndex = 12;
            this.chkConParPre.CheckedChanged += new System.EventHandler(this.chkConParPre_CheckedChanged);
            // 
            // bteParPre
            // 
            this.bteParPre.Location = new System.Drawing.Point(82, 36);
            this.bteParPre.Name = "bteParPre";
            this.bteParPre.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.bteParPre.Properties.ReadOnly = true;
            this.bteParPre.Size = new System.Drawing.Size(374, 20);
            this.bteParPre.StyleController = this.lcBase;
            this.bteParPre.TabIndex = 14;
            this.bteParPre.Click += new System.EventHandler(this.bteParPre_Click);
            // 
            // bteProducto
            // 
            this.bteProducto.Location = new System.Drawing.Point(82, 60);
            this.bteProducto.Name = "bteProducto";
            this.bteProducto.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.bteProducto.Properties.ReadOnly = true;
            this.bteProducto.Size = new System.Drawing.Size(374, 20);
            this.bteProducto.StyleController = this.lcBase;
            this.bteProducto.TabIndex = 14;
            this.bteProducto.Click += new System.EventHandler(this.bteProducto_Click);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 244);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(448, 10);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtDescripcion;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 96);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(448, 50);
            this.layoutControlItem1.Text = "Descripción";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(58, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.lueUnidad;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 196);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(224, 24);
            this.layoutControlItem2.Text = "Unidad";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(58, 13);
            // 
            // lciCantidad
            // 
            this.lciCantidad.Control = this.seCantidad;
            this.lciCantidad.Location = new System.Drawing.Point(0, 220);
            this.lciCantidad.MaxSize = new System.Drawing.Size(224, 24);
            this.lciCantidad.MinSize = new System.Drawing.Size(224, 24);
            this.lciCantidad.Name = "lciCantidad";
            this.lciCantidad.Size = new System.Drawing.Size(224, 24);
            this.lciCantidad.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciCantidad.Text = "Cantidad";
            this.lciCantidad.TextSize = new System.Drawing.Size(58, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtJustificacion;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 146);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(448, 50);
            this.layoutControlItem5.Text = "Justificación";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(58, 13);
            // 
            // lciSubTotal
            // 
            this.lciSubTotal.Control = this.seImporte;
            this.lciSubTotal.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lciSubTotal.CustomizationFormText = "Precio";
            this.lciSubTotal.Location = new System.Drawing.Point(224, 220);
            this.lciSubTotal.MinSize = new System.Drawing.Size(124, 24);
            this.lciSubTotal.Name = "lciSubTotal";
            this.lciSubTotal.Size = new System.Drawing.Size(224, 24);
            this.lciSubTotal.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciSubTotal.Text = "Subtotal";
            this.lciSubTotal.TextSize = new System.Drawing.Size(58, 13);
            // 
            // lciPrecio
            // 
            this.lciPrecio.Control = this.sePrecio;
            this.lciPrecio.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lciPrecio.CustomizationFormText = "Precio";
            this.lciPrecio.Location = new System.Drawing.Point(224, 196);
            this.lciPrecio.Name = "lciPrecio";
            this.lciPrecio.Size = new System.Drawing.Size(224, 24);
            this.lciPrecio.Text = "Precio";
            this.lciPrecio.TextSize = new System.Drawing.Size(58, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.chkConParPre;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(448, 24);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // lciParPre
            // 
            this.lciParPre.Control = this.bteParPre;
            this.lciParPre.Location = new System.Drawing.Point(0, 24);
            this.lciParPre.Name = "lciParPre";
            this.lciParPre.Size = new System.Drawing.Size(448, 24);
            this.lciParPre.Text = "Partida Pre.";
            this.lciParPre.TextSize = new System.Drawing.Size(58, 13);
            this.lciParPre.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // lciProducto
            // 
            this.lciProducto.Control = this.bteProducto;
            this.lciProducto.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lciProducto.CustomizationFormText = "Partida Pre.";
            this.lciProducto.Location = new System.Drawing.Point(0, 48);
            this.lciProducto.Name = "lciProducto";
            this.lciProducto.Size = new System.Drawing.Size(448, 24);
            this.lciProducto.Text = "Producto";
            this.lciProducto.TextSize = new System.Drawing.Size(58, 13);
            // 
            // txtDesCuenta
            // 
            this.txtDesCuenta.Location = new System.Drawing.Point(82, 84);
            this.txtDesCuenta.Name = "txtDesCuenta";
            this.txtDesCuenta.Properties.ReadOnly = true;
            this.txtDesCuenta.Size = new System.Drawing.Size(374, 20);
            this.txtDesCuenta.StyleController = this.lcBase;
            this.txtDesCuenta.TabIndex = 15;
            // 
            // lciDesCuenta
            // 
            this.lciDesCuenta.Control = this.txtDesCuenta;
            this.lciDesCuenta.Location = new System.Drawing.Point(0, 72);
            this.lciDesCuenta.Name = "lciDesCuenta";
            this.lciDesCuenta.Size = new System.Drawing.Size(448, 24);
            this.lciDesCuenta.Text = "Cuenta";
            this.lciDesCuenta.TextSize = new System.Drawing.Size(58, 13);
            // 
            // frmRequerimientoMensualDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 344);
            this.Name = "frmRequerimientoMensualDetalle";
            this.Text = "frmProgramacionAnualDetalle";
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcBase)).EndInit();
            this.lcBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxProveedorValidador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueUnidad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seCantidad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtJustificacion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seImporte.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sePrecio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkConParPre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteParPre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteProducto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSubTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPrecio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciParPre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciProducto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesCuenta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDesCuenta)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.MemoEdit txtDescripcion;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.SpinEdit seCantidad;
        private DevExpress.XtraEditors.LookUpEdit lueUnidad;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem lciCantidad;
        private DevExpress.XtraEditors.MemoEdit txtJustificacion;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.SpinEdit seImporte;
        private DevExpress.XtraLayout.LayoutControlItem lciSubTotal;
        private DevExpress.XtraEditors.SpinEdit sePrecio;
        private DevExpress.XtraLayout.LayoutControlItem lciPrecio;
        private DevExpress.XtraEditors.CheckEdit chkConParPre;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.ButtonEdit bteParPre;
        private DevExpress.XtraLayout.LayoutControlItem lciParPre;
        private DevExpress.XtraEditors.ButtonEdit bteProducto;
        private DevExpress.XtraLayout.LayoutControlItem lciProducto;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.TextEdit txtDesCuenta;
        private DevExpress.XtraLayout.LayoutControlItem lciDesCuenta;
    }
}