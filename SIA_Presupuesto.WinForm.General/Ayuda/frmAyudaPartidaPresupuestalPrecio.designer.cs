namespace SIA_Presupuesto.WinForm.General.Ayuda
{
    partial class frmAyudaPartidaPresupuestalPrecio
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
            this.grcParPre = new DevExpress.XtraGrid.GridControl();
            this.grvParPre = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.obgsSeleccion = new SIA_Presupuesto.WinForm.General.ControlesDiversos.OpcionesBarraGridSeleccion();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtDesBusqueda = new DevExpress.XtraEditors.TextEdit();
            this.lciDesBusqueda = new DevExpress.XtraLayout.LayoutControlItem();
            this.gcIdUnidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUnidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPrecio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcidCueCon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcNumCuenta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gbCuerpo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).BeginInit();
            this.lcCuerpo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcParPre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvParPre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesBusqueda.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDesBusqueda)).BeginInit();
            this.SuspendLayout();
            // 
            // gbCuerpo
            // 
            this.gbCuerpo.Size = new System.Drawing.Size(597, 402);
            // 
            // lcCuerpo
            // 
            this.lcCuerpo.Controls.Add(this.txtDesBusqueda);
            this.lcCuerpo.Controls.Add(this.obgsSeleccion);
            this.lcCuerpo.Controls.Add(this.grcParPre);
            this.lcCuerpo.Size = new System.Drawing.Size(591, 382);
            // 
            // lcgCuerpo
            // 
            this.lcgCuerpo.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.lciDesBusqueda});
            this.lcgCuerpo.Size = new System.Drawing.Size(591, 382);
            // 
            // grcParPre
            // 
            this.grcParPre.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.grcParPre.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.grcParPre.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.grcParPre.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.grcParPre.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.grcParPre.Location = new System.Drawing.Point(12, 64);
            this.grcParPre.MainView = this.grvParPre;
            this.grcParPre.Name = "grcParPre";
            this.grcParPre.Size = new System.Drawing.Size(567, 306);
            this.grcParPre.TabIndex = 4;
            this.grcParPre.UseEmbeddedNavigator = true;
            this.grcParPre.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvParPre});
            // 
            // grvParPre
            // 
            this.grvParPre.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcCodigo,
            this.gcDescripcion,
            this.gcIdUnidad,
            this.gcUnidad,
            this.gcPrecio,
            this.gcidCueCon,
            this.gcNumCuenta});
            this.grvParPre.GridControl = this.grcParPre;
            this.grvParPre.Name = "grvParPre";
            this.grvParPre.OptionsBehavior.ReadOnly = true;
            this.grvParPre.OptionsView.ColumnAutoWidth = false;
            this.grvParPre.OptionsView.ShowAutoFilterRow = true;
            this.grvParPre.OptionsView.ShowGroupPanel = false;
            // 
            // gcCodigo
            // 
            this.gcCodigo.Caption = "Código";
            this.gcCodigo.FieldName = "idParPre";
            this.gcCodigo.Name = "gcCodigo";
            this.gcCodigo.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Like;
            this.gcCodigo.Width = 100;
            // 
            // gcDescripcion
            // 
            this.gcDescripcion.Caption = "Descripción";
            this.gcDescripcion.FieldName = "descripcion";
            this.gcDescripcion.Name = "gcDescripcion";
            this.gcDescripcion.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcDescripcion.Visible = true;
            this.gcDescripcion.VisibleIndex = 0;
            this.gcDescripcion.Width = 320;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grcParPre;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 52);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(571, 310);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // obgsSeleccion
            // 
            this.obgsSeleccion.Location = new System.Drawing.Point(12, 36);
            this.obgsSeleccion.Name = "obgsSeleccion";
            this.obgsSeleccion.Size = new System.Drawing.Size(567, 24);
            this.obgsSeleccion.TabIndex = 5;
            this.obgsSeleccion.SeleccionarRegistro += new System.EventHandler(this.obgsSeleccion_SeleccionarRegistro);
            this.obgsSeleccion.SiguienteRegistro += new System.EventHandler(this.obgsSeleccion_SiguienteRegistro);
            this.obgsSeleccion.AnteriorRegistro += new System.EventHandler(this.obgsSeleccion_AnteriorRegistro);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.obgsSeleccion;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(571, 28);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // txtDesBusqueda
            // 
            this.txtDesBusqueda.Location = new System.Drawing.Point(118, 12);
            this.txtDesBusqueda.Name = "txtDesBusqueda";
            this.txtDesBusqueda.Size = new System.Drawing.Size(461, 20);
            this.txtDesBusqueda.StyleController = this.lcCuerpo;
            this.txtDesBusqueda.TabIndex = 6;
            this.txtDesBusqueda.EditValueChanged += new System.EventHandler(this.txtDesBusqueda_EditValueChanged);
            // 
            // lciDesBusqueda
            // 
            this.lciDesBusqueda.Control = this.txtDesBusqueda;
            this.lciDesBusqueda.Location = new System.Drawing.Point(0, 0);
            this.lciDesBusqueda.Name = "lciDesBusqueda";
            this.lciDesBusqueda.Size = new System.Drawing.Size(571, 24);
            this.lciDesBusqueda.Text = "Ingrese Descripción";
            this.lciDesBusqueda.TextSize = new System.Drawing.Size(94, 13);
            // 
            // gcIdUnidad
            // 
            this.gcIdUnidad.Caption = "IdUnidad";
            this.gcIdUnidad.FieldName = "idUnidad";
            this.gcIdUnidad.Name = "gcIdUnidad";
            // 
            // gcUnidad
            // 
            this.gcUnidad.Caption = "Unidad";
            this.gcUnidad.FieldName = "unidad";
            this.gcUnidad.Name = "gcUnidad";
            this.gcUnidad.Visible = true;
            this.gcUnidad.VisibleIndex = 1;
            this.gcUnidad.Width = 80;
            // 
            // gcPrecio
            // 
            this.gcPrecio.AppearanceCell.Options.UseTextOptions = true;
            this.gcPrecio.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gcPrecio.Caption = "Precio";
            this.gcPrecio.FieldName = "precio";
            this.gcPrecio.Name = "gcPrecio";
            this.gcPrecio.Visible = true;
            this.gcPrecio.VisibleIndex = 2;
            this.gcPrecio.Width = 95;
            // 
            // gcidCueCon
            // 
            this.gcidCueCon.Caption = "IdCueCon";
            this.gcidCueCon.FieldName = "idCueCon";
            this.gcidCueCon.Name = "gcidCueCon";
            // 
            // gcNumCuenta
            // 
            this.gcNumCuenta.Caption = "Cuenta";
            this.gcNumCuenta.FieldName = "numCuenta";
            this.gcNumCuenta.Name = "gcNumCuenta";
            this.gcNumCuenta.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.BeginsWith;
            this.gcNumCuenta.Visible = true;
            this.gcNumCuenta.VisibleIndex = 3;
            this.gcNumCuenta.Width = 80;
            // 
            // frmAyudaPartidaPresupuestalPrecio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 452);
            this.Name = "frmAyudaPartidaPresupuestalPrecio";
            this.Text = "";
            this.gbCuerpo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).EndInit();
            this.lcCuerpo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcParPre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvParPre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesBusqueda.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDesBusqueda)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grcParPre;
        private DevExpress.XtraGrid.Views.Grid.GridView grvParPre;
        private DevExpress.XtraGrid.Columns.GridColumn gcCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn gcDescripcion;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private ControlesDiversos.OpcionesBarraGridSeleccion obgsSeleccion;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.TextEdit txtDesBusqueda;
        private DevExpress.XtraLayout.LayoutControlItem lciDesBusqueda;
        private DevExpress.XtraGrid.Columns.GridColumn gcIdUnidad;
        private DevExpress.XtraGrid.Columns.GridColumn gcUnidad;
        private DevExpress.XtraGrid.Columns.GridColumn gcPrecio;
        private DevExpress.XtraGrid.Columns.GridColumn gcidCueCon;
        private DevExpress.XtraGrid.Columns.GridColumn gcNumCuenta;
    }
}