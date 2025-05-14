namespace SIA_Presupuesto.WinForm.Mantenimiento.Dialogo
{
    partial class ListaConceptoCuenta
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
            this.grcConcepto = new DevExpress.XtraGrid.GridControl();
            this.grvConcepto = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcNumCuenta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcRegLab = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCatLab = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcConLab = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.obgOperaciones = new SIA_Presupuesto.WinForm.General.ControlesDiversos.OpcionesBarraGrid();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gbCuerpo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).BeginInit();
            this.lcCuerpo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcConcepto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvConcepto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // gbCuerpo
            // 
            this.gbCuerpo.Size = new System.Drawing.Size(751, 384);
            // 
            // lcCuerpo
            // 
            this.lcCuerpo.Controls.Add(this.obgOperaciones);
            this.lcCuerpo.Controls.Add(this.grcConcepto);
            this.lcCuerpo.Size = new System.Drawing.Size(745, 364);
            // 
            // lcgCuerpo
            // 
            this.lcgCuerpo.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.lcgCuerpo.Size = new System.Drawing.Size(745, 364);
            // 
            // grcConcepto
            // 
            this.grcConcepto.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.grcConcepto.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.grcConcepto.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.grcConcepto.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.grcConcepto.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.grcConcepto.Location = new System.Drawing.Point(12, 47);
            this.grcConcepto.MainView = this.grvConcepto;
            this.grcConcepto.Name = "grcConcepto";
            this.grcConcepto.Size = new System.Drawing.Size(721, 305);
            this.grcConcepto.TabIndex = 4;
            this.grcConcepto.UseEmbeddedNavigator = true;
            this.grcConcepto.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvConcepto});
            // 
            // grvConcepto
            // 
            this.grvConcepto.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcNumCuenta,
            this.gcRegLab,
            this.gcCatLab,
            this.gcConLab});
            this.grvConcepto.GridControl = this.grcConcepto;
            this.grvConcepto.Name = "grvConcepto";
            this.grvConcepto.OptionsBehavior.Editable = false;
            this.grvConcepto.OptionsView.ShowAutoFilterRow = true;
            this.grvConcepto.OptionsView.ShowGroupPanel = false;
            // 
            // gcNumCuenta
            // 
            this.gcNumCuenta.Caption = "Cuenta Contable";
            this.gcNumCuenta.FieldName = "numcuenta";
            this.gcNumCuenta.Name = "gcNumCuenta";
            this.gcNumCuenta.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.BeginsWith;
            this.gcNumCuenta.Visible = true;
            this.gcNumCuenta.VisibleIndex = 0;
            this.gcNumCuenta.Width = 100;
            // 
            // gcRegLab
            // 
            this.gcRegLab.Caption = "Reg. Laboral";
            this.gcRegLab.FieldName = "regimen";
            this.gcRegLab.Name = "gcRegLab";
            this.gcRegLab.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcRegLab.Visible = true;
            this.gcRegLab.VisibleIndex = 1;
            this.gcRegLab.Width = 187;
            // 
            // gcCatLab
            // 
            this.gcCatLab.Caption = "Cat. Laboral";
            this.gcCatLab.FieldName = "categoria";
            this.gcCatLab.Name = "gcCatLab";
            this.gcCatLab.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcCatLab.Visible = true;
            this.gcCatLab.VisibleIndex = 2;
            this.gcCatLab.Width = 187;
            // 
            // gcConLab
            // 
            this.gcConLab.Caption = "Con. Laboral";
            this.gcConLab.FieldName = "condicion";
            this.gcConLab.Name = "gcConLab";
            this.gcConLab.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcConLab.Visible = true;
            this.gcConLab.VisibleIndex = 3;
            this.gcConLab.Width = 192;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grcConcepto;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 35);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(725, 309);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // obgOperaciones
            // 
            this.obgOperaciones.ConAgregar = true;
            this.obgOperaciones.ConDesMarcarTodos = false;
            this.obgOperaciones.ConMarcarTodos = false;
            this.obgOperaciones.ConModificar = false;
            this.obgOperaciones.ConNuevoDetalle = false;
            this.obgOperaciones.ConOtros = false;
            this.obgOperaciones.ConQuitar = true;
            this.obgOperaciones.ConVisualizar = false;
            this.obgOperaciones.Location = new System.Drawing.Point(12, 12);
            this.obgOperaciones.Name = "obgOperaciones";
            this.obgOperaciones.NombreAgregar = "Agregar";
            this.obgOperaciones.NombreModificar = null;
            this.obgOperaciones.NombreNuevoDetalleRegistro = null;
            this.obgOperaciones.NombreOtros = null;
            this.obgOperaciones.NombreQuitar = "Quitar";
            this.obgOperaciones.NombreVisualizar = null;
            this.obgOperaciones.Size = new System.Drawing.Size(721, 31);
            this.obgOperaciones.TabIndex = 5;
            this.obgOperaciones.AgregarRegistro += new System.EventHandler(this.obgOperaciones_AgregarRegistro);
            this.obgOperaciones.QuitarRegistro += new System.EventHandler(this.obgOperaciones_QuitarRegistro);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.obgOperaciones;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(725, 35);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // ListaConceptoCuenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 434);
            this.Name = "ListaConceptoCuenta";
            this.Text = "ListaConceptoCuenta";
            this.gbCuerpo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).EndInit();
            this.lcCuerpo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcConcepto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvConcepto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grcConcepto;
        private DevExpress.XtraGrid.Views.Grid.GridView grvConcepto;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gcNumCuenta;
        private DevExpress.XtraGrid.Columns.GridColumn gcRegLab;
        private DevExpress.XtraGrid.Columns.GridColumn gcCatLab;
        private DevExpress.XtraGrid.Columns.GridColumn gcConLab;
        private General.ControlesDiversos.OpcionesBarraGrid obgOperaciones;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
    }
}