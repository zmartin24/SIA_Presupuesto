namespace SIA_Presupuesto.WinForm.Adquisicion.Dialogo
{ 
    partial class frmEnviarCorreoBoleta
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
            this.grcDetalle = new DevExpress.XtraGrid.GridControl();
            this.grvDetalle = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grcTrabajador = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCorreo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtCorreo = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtUsuario = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtClave = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtNombre = new DevExpress.XtraEditors.TextEdit();
            this.txtDescripcion = new DevExpress.XtraEditors.MemoEdit();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtAsunto = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ceUsarCred = new DevExpress.XtraEditors.CheckEdit();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ceConClavePDF = new DevExpress.XtraEditors.CheckEdit();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgPrincipal)).BeginInit();
            this.gbDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).BeginInit();
            this.lcCuerpo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCorreo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsuario.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtClave.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAsunto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceUsarCred.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceConClavePDF.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            this.SuspendLayout();
            // 
            // lcgCuerpo
            // 
            this.lcgCuerpo.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlGroup1,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem9,
            this.layoutControlItem10});
            this.lcgCuerpo.Size = new System.Drawing.Size(598, 452);
            // 
            // lcgPrincipal
            // 
            this.lcgPrincipal.Size = new System.Drawing.Size(628, 522);
            // 
            // gbDatos
            // 
            this.gbDatos.Size = new System.Drawing.Size(604, 472);
            // 
            // lcCuerpo
            // 
            this.lcCuerpo.Controls.Add(this.ceConClavePDF);
            this.lcCuerpo.Controls.Add(this.ceUsarCred);
            this.lcCuerpo.Controls.Add(this.txtNombre);
            this.lcCuerpo.Controls.Add(this.txtAsunto);
            this.lcCuerpo.Controls.Add(this.txtDescripcion);
            this.lcCuerpo.Controls.Add(this.txtClave);
            this.lcCuerpo.Controls.Add(this.txtUsuario);
            this.lcCuerpo.Controls.Add(this.txtCorreo);
            this.lcCuerpo.Controls.Add(this.grcDetalle);
            this.lcCuerpo.Size = new System.Drawing.Size(598, 452);
            // 
            // layoutControl1
            // 
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(929, 271, 250, 350);
            this.layoutControl1.Size = new System.Drawing.Size(628, 522);
            this.layoutControl1.Controls.SetChildIndex(this.gbDatos, 0);
            this.layoutControl1.Controls.SetChildIndex(this.sbAceptar, 0);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Size = new System.Drawing.Size(608, 476);
            // 
            // sbAceptar
            // 
            this.sbAceptar.Location = new System.Drawing.Point(449, 488);
            // 
            // grcDetalle
            // 
            this.grcDetalle.Location = new System.Drawing.Point(12, 227);
            this.grcDetalle.MainView = this.grvDetalle;
            this.grcDetalle.Name = "grcDetalle";
            this.grcDetalle.Size = new System.Drawing.Size(574, 213);
            this.grcDetalle.TabIndex = 4;
            this.grcDetalle.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDetalle});
            // 
            // grvDetalle
            // 
            this.grvDetalle.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grcTrabajador,
            this.grcCorreo});
            this.grvDetalle.GridControl = this.grcDetalle;
            this.grvDetalle.Name = "grvDetalle";
            this.grvDetalle.OptionsBehavior.Editable = false;
            this.grvDetalle.OptionsView.ColumnAutoWidth = false;
            this.grvDetalle.OptionsView.ShowGroupPanel = false;
            // 
            // grcTrabajador
            // 
            this.grcTrabajador.Caption = "Trabajador";
            this.grcTrabajador.FieldName = "nombres";
            this.grcTrabajador.Name = "grcTrabajador";
            this.grcTrabajador.Visible = true;
            this.grcTrabajador.VisibleIndex = 0;
            this.grcTrabajador.Width = 250;
            // 
            // grcCorreo
            // 
            this.grcCorreo.Caption = "Correo";
            this.grcCorreo.FieldName = "email";
            this.grcCorreo.Name = "grcCorreo";
            this.grcCorreo.Visible = true;
            this.grcCorreo.VisibleIndex = 1;
            this.grcCorreo.Width = 300;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.grcDetalle;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 215);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(578, 217);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // txtCorreo
            // 
            this.txtCorreo.Location = new System.Drawing.Point(158, 167);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Properties.Mask.EditMask = "((([0-9a-zA-Z_%-])+[.])+|([0-9a-zA-Z_%-])+)+@((([0-9a-zA-Z_-])+[.])+|([0-9a-zA-Z_" +
    "-])+)+";
            this.txtCorreo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtCorreo.Size = new System.Drawing.Size(139, 20);
            this.txtCorreo.StyleController = this.lcCuerpo;
            this.txtCorreo.TabIndex = 5;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtCorreo;
            this.layoutControlItem3.Enabled = false;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(277, 24);
            this.layoutControlItem3.Text = "Correo:";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(130, 13);
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(158, 191);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(139, 20);
            this.txtUsuario.StyleController = this.lcCuerpo;
            this.txtUsuario.TabIndex = 6;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtUsuario;
            this.layoutControlItem4.Enabled = false;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(277, 24);
            this.layoutControlItem4.Text = "Usuario:";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(130, 13);
            // 
            // txtClave
            // 
            this.txtClave.Location = new System.Drawing.Point(435, 191);
            this.txtClave.Name = "txtClave";
            this.txtClave.Properties.UseSystemPasswordChar = true;
            this.txtClave.Size = new System.Drawing.Size(139, 20);
            this.txtClave.StyleController = this.lcCuerpo;
            this.txtClave.TabIndex = 7;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtClave;
            this.layoutControlItem5.Enabled = false;
            this.layoutControlItem5.Location = new System.Drawing.Point(277, 24);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(277, 24);
            this.layoutControlItem5.Text = "Clave:";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(130, 13);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem3,
            this.layoutControlItem8});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 125);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(578, 90);
            this.layoutControlGroup1.Text = "Credenciales Correo";
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.txtNombre;
            this.layoutControlItem8.Enabled = false;
            this.layoutControlItem8.Location = new System.Drawing.Point(277, 0);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(277, 24);
            this.layoutControlItem8.Text = "Nombre";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(130, 13);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(435, 167);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(139, 20);
            this.txtNombre.StyleController = this.lcCuerpo;
            this.txtNombre.TabIndex = 10;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(146, 36);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(440, 74);
            this.txtDescripcion.StyleController = this.lcCuerpo;
            this.txtDescripcion.TabIndex = 8;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.txtDescripcion;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(578, 78);
            this.layoutControlItem6.Text = "Descripción";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(130, 13);
            // 
            // txtAsunto
            // 
            this.txtAsunto.Location = new System.Drawing.Point(146, 12);
            this.txtAsunto.Name = "txtAsunto";
            this.txtAsunto.Size = new System.Drawing.Size(440, 20);
            this.txtAsunto.StyleController = this.lcCuerpo;
            this.txtAsunto.TabIndex = 9;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.txtAsunto;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(578, 24);
            this.layoutControlItem7.Text = "Asunto:";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(130, 13);
            // 
            // ceUsarCred
            // 
            this.ceUsarCred.EditValue = true;
            this.ceUsarCred.Location = new System.Drawing.Point(146, 114);
            this.ceUsarCred.Name = "ceUsarCred";
            this.ceUsarCred.Properties.Caption = "";
            this.ceUsarCred.Size = new System.Drawing.Size(151, 19);
            this.ceUsarCred.StyleController = this.lcCuerpo;
            this.ceUsarCred.TabIndex = 11;
            this.ceUsarCred.CheckedChanged += new System.EventHandler(this.ceUsarCred_CheckedChanged);
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.ceUsarCred;
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 102);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(289, 23);
            this.layoutControlItem9.Text = "Usar Credenciales Actuales";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(130, 13);
            // 
            // ceConClavePDF
            // 
            this.ceConClavePDF.Location = new System.Drawing.Point(435, 114);
            this.ceConClavePDF.Name = "ceConClavePDF";
            this.ceConClavePDF.Properties.Caption = "(La clave es el DNI)";
            this.ceConClavePDF.Size = new System.Drawing.Size(151, 19);
            this.ceConClavePDF.StyleController = this.lcCuerpo;
            this.ceConClavePDF.TabIndex = 12;
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.ceConClavePDF;
            this.layoutControlItem10.Location = new System.Drawing.Point(289, 102);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(289, 23);
            this.layoutControlItem10.Text = "PDF con Clave";
            this.layoutControlItem10.TextSize = new System.Drawing.Size(130, 13);
            // 
            // frmEnviarCorreoBoleta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 522);
            this.Name = "frmEnviarCorreoBoleta";
            this.Text = "frmEnviarCorreoBoleta";
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgPrincipal)).EndInit();
            this.gbDatos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).EndInit();
            this.lcCuerpo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCorreo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsuario.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtClave.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAsunto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceUsarCred.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceConClavePDF.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.GridControl grcDetalle;
        private DevExpress.XtraGrid.Views.Grid.GridView grvDetalle;
        private DevExpress.XtraGrid.Columns.GridColumn grcTrabajador;
        private DevExpress.XtraGrid.Columns.GridColumn grcCorreo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.TextEdit txtCorreo;
        private DevExpress.XtraEditors.TextEdit txtAsunto;
        private DevExpress.XtraEditors.MemoEdit txtDescripcion;
        private DevExpress.XtraEditors.TextEdit txtClave;
        private DevExpress.XtraEditors.TextEdit txtUsuario;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraEditors.TextEdit txtNombre;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraEditors.CheckEdit ceUsarCred;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraEditors.CheckEdit ceConClavePDF;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
    }
}