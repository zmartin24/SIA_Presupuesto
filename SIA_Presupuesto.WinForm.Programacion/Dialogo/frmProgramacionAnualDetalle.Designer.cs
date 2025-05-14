namespace SIA_Presupuesto.WinForm.Programacion.Dialogo
{
    partial class frmProgramacionAnualDetalle
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
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lueUnidad = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.sePrecio = new DevExpress.XtraEditors.SpinEdit();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.sbAyudaProducto = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.txtJustificacion = new DevExpress.XtraEditors.MemoEdit();
            this.lciJustificacion = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcBase)).BeginInit();
            this.lcBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxProveedorValidador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueUnidad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sePrecio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtJustificacion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciJustificacion)).BeginInit();
            this.SuspendLayout();
            // 
            // lcCuerpo
            // 
            this.lcCuerpo.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(803, 132, 386, 350);
            this.lcCuerpo.Size = new System.Drawing.Size(588, 347);
            // 
            // lcgCuerpo
            // 
            this.lcgCuerpo.Size = new System.Drawing.Size(588, 347);
            // 
            // lcBase
            // 
            this.lcBase.Controls.Add(this.sbAyudaProducto);
            this.lcBase.Controls.Add(this.sePrecio);
            this.lcBase.Controls.Add(this.lueUnidad);
            this.lcBase.Controls.Add(this.txtDescripcion);
            this.lcBase.Controls.Add(this.txtJustificacion);
            this.lcBase.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(679, 299, 450, 400);
            this.lcBase.Size = new System.Drawing.Size(558, 277);
            // 
            // lcgBase
            // 
            this.lcgBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem4,
            this.lciJustificacion,
            this.layoutControlItem3,
            this.emptySpaceItem1});
            this.lcgBase.Name = "Root";
            this.lcgBase.Size = new System.Drawing.Size(558, 277);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(82, 12);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcion.Size = new System.Drawing.Size(464, 77);
            this.txtDescripcion.StyleController = this.lcBase;
            this.txtDescripcion.TabIndex = 4;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtDescripcion;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(538, 81);
            this.layoutControlItem1.Text = "Descripción";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(58, 13);
            // 
            // lueUnidad
            // 
            this.lueUnidad.Location = new System.Drawing.Point(82, 119);
            this.lueUnidad.Name = "lueUnidad";
            this.lueUnidad.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueUnidad.Size = new System.Drawing.Size(464, 20);
            this.lueUnidad.StyleController = this.lcBase;
            this.lueUnidad.TabIndex = 5;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.lueUnidad;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 107);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(538, 24);
            this.layoutControlItem2.Text = "Unidad";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(58, 13);
            // 
            // sePrecio
            // 
            this.sePrecio.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.sePrecio.Location = new System.Drawing.Point(82, 143);
            this.sePrecio.Name = "sePrecio";
            this.sePrecio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.sePrecio.Size = new System.Drawing.Size(464, 20);
            this.sePrecio.StyleController = this.lcBase;
            this.sePrecio.TabIndex = 7;
            this.sePrecio.EditValueChanged += new System.EventHandler(this.sePrecio_EditValueChanged);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.sePrecio;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 131);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(538, 24);
            this.layoutControlItem4.Text = "Precio";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(58, 13);
            // 
            // sbAyudaProducto
            // 
            this.sbAyudaProducto.Location = new System.Drawing.Point(470, 93);
            this.sbAyudaProducto.Name = "sbAyudaProducto";
            this.sbAyudaProducto.Size = new System.Drawing.Size(76, 22);
            this.sbAyudaProducto.StyleController = this.lcBase;
            this.sbAyudaProducto.TabIndex = 8;
            this.sbAyudaProducto.Text = "Buscar Bien";
            this.sbAyudaProducto.Click += new System.EventHandler(this.sbAyudaProducto_Click);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.sbAyudaProducto;
            this.layoutControlItem3.Location = new System.Drawing.Point(458, 81);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(80, 26);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 81);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(458, 26);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // txtJustificacion
            // 
            this.txtJustificacion.Location = new System.Drawing.Point(82, 167);
            this.txtJustificacion.Name = "txtJustificacion";
            this.txtJustificacion.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtJustificacion.Size = new System.Drawing.Size(464, 98);
            this.txtJustificacion.StyleController = this.lcBase;
            this.txtJustificacion.TabIndex = 4;
            // 
            // lciJustificacion
            // 
            this.lciJustificacion.Control = this.txtJustificacion;
            this.lciJustificacion.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lciJustificacion.CustomizationFormText = "Descripción";
            this.lciJustificacion.Location = new System.Drawing.Point(0, 155);
            this.lciJustificacion.Name = "lciJustificacion";
            this.lciJustificacion.Size = new System.Drawing.Size(538, 102);
            this.lciJustificacion.Text = "Justificación";
            this.lciJustificacion.TextSize = new System.Drawing.Size(58, 13);
            // 
            // frmProgramacionAnualDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 347);
            this.Name = "frmProgramacionAnualDetalle";
            this.Text = "frmProgramacionAnualDetalle";
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcBase)).EndInit();
            this.lcBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxProveedorValidador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueUnidad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sePrecio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtJustificacion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciJustificacion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.MemoEdit txtDescripcion;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.SpinEdit sePrecio;
        private DevExpress.XtraEditors.LookUpEdit lueUnidad;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.SimpleButton sbAyudaProducto;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.MemoEdit txtJustificacion;
        private DevExpress.XtraLayout.LayoutControlItem lciJustificacion;
    }
}