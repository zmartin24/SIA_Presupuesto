namespace SIA_Presupuesto.WinForm.General.Ayuda
{
    partial class frmAyudaProductoPrecio
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
            this.grcProducto = new DevExpress.XtraGrid.GridControl();
            this.grvProducto = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcIdUnidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUnidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPrecio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcAnio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcIdCueCon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcNumCuenta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.obgsSeleccion = new SIA_Presupuesto.WinForm.General.ControlesDiversos.OpcionesBarraGridSeleccion();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtBusqueda = new DevExpress.XtraEditors.TextEdit();
            this.lciBusqueda = new DevExpress.XtraLayout.LayoutControlItem();
            this.gbCuerpo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).BeginInit();
            this.lcCuerpo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcProducto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProducto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBusqueda.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBusqueda)).BeginInit();
            this.SuspendLayout();
            // 
            // gbCuerpo
            // 
            this.gbCuerpo.Size = new System.Drawing.Size(597, 402);
            // 
            // lcCuerpo
            // 
            this.lcCuerpo.Controls.Add(this.txtBusqueda);
            this.lcCuerpo.Controls.Add(this.obgsSeleccion);
            this.lcCuerpo.Controls.Add(this.grcProducto);
            this.lcCuerpo.Size = new System.Drawing.Size(591, 382);
            // 
            // lcgCuerpo
            // 
            this.lcgCuerpo.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.lciBusqueda});
            this.lcgCuerpo.Size = new System.Drawing.Size(591, 382);
            // 
            // grcProducto
            // 
            this.grcProducto.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.grcProducto.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.grcProducto.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.grcProducto.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.grcProducto.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.grcProducto.Location = new System.Drawing.Point(12, 64);
            this.grcProducto.MainView = this.grvProducto;
            this.grcProducto.Name = "grcProducto";
            this.grcProducto.Size = new System.Drawing.Size(567, 306);
            this.grcProducto.TabIndex = 4;
            this.grcProducto.UseEmbeddedNavigator = true;
            this.grcProducto.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvProducto});
            // 
            // grvProducto
            // 
            this.grvProducto.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcCodigo,
            this.gcDescripcion,
            this.gcIdUnidad,
            this.gcUnidad,
            this.gcPrecio,
            this.gcAnio,
            this.gcIdCueCon,
            this.gcNumCuenta});
            this.grvProducto.GridControl = this.grcProducto;
            this.grvProducto.Name = "grvProducto";
            this.grvProducto.OptionsBehavior.ReadOnly = true;
            this.grvProducto.OptionsView.ColumnAutoWidth = false;
            this.grvProducto.OptionsView.ShowAutoFilterRow = true;
            this.grvProducto.OptionsView.ShowGroupPanel = false;
            // 
            // gcCodigo
            // 
            this.gcCodigo.Caption = "Código";
            this.gcCodigo.FieldName = "idProducto";
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
            // gcIdUnidad
            // 
            this.gcIdUnidad.Caption = "IdUnidad";
            this.gcIdUnidad.FieldName = "idUnidad";
            this.gcIdUnidad.Name = "gcIdUnidad";
            this.gcIdUnidad.Width = 60;
            // 
            // gcUnidad
            // 
            this.gcUnidad.Caption = "Unidad";
            this.gcUnidad.FieldName = "unidad";
            this.gcUnidad.Name = "gcUnidad";
            this.gcUnidad.Visible = true;
            this.gcUnidad.VisibleIndex = 1;
            this.gcUnidad.Width = 70;
            // 
            // gcPrecio
            // 
            this.gcPrecio.AppearanceCell.Options.UseTextOptions = true;
            this.gcPrecio.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gcPrecio.Caption = "Precio";
            this.gcPrecio.DisplayFormat.FormatString = "n2";
            this.gcPrecio.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcPrecio.FieldName = "precio";
            this.gcPrecio.Name = "gcPrecio";
            this.gcPrecio.Visible = true;
            this.gcPrecio.VisibleIndex = 2;
            this.gcPrecio.Width = 95;
            // 
            // gcAnio
            // 
            this.gcAnio.AppearanceCell.Options.UseTextOptions = true;
            this.gcAnio.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcAnio.Caption = "Año Precio";
            this.gcAnio.FieldName = "anioPrecio";
            this.gcAnio.Name = "gcAnio";
            this.gcAnio.Visible = true;
            this.gcAnio.VisibleIndex = 3;
            this.gcAnio.Width = 80;
            // 
            // gcIdCueCon
            // 
            this.gcIdCueCon.Caption = "IdCuenta";
            this.gcIdCueCon.FieldName = "idCueCon";
            this.gcIdCueCon.Name = "gcIdCueCon";
            // 
            // gcNumCuenta
            // 
            this.gcNumCuenta.Caption = "Cuenta";
            this.gcNumCuenta.FieldName = "numCuenta";
            this.gcNumCuenta.Name = "gcNumCuenta";
            this.gcNumCuenta.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.BeginsWith;
            this.gcNumCuenta.Visible = true;
            this.gcNumCuenta.VisibleIndex = 4;
            this.gcNumCuenta.Width = 100;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grcProducto;
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
            // txtBusqueda
            // 
            this.txtBusqueda.Location = new System.Drawing.Point(117, 12);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(462, 20);
            this.txtBusqueda.StyleController = this.lcCuerpo;
            this.txtBusqueda.TabIndex = 6;
            this.txtBusqueda.EditValueChanged += new System.EventHandler(this.txtBusqueda_EditValueChanged);
            // 
            // lciBusqueda
            // 
            this.lciBusqueda.Control = this.txtBusqueda;
            this.lciBusqueda.Location = new System.Drawing.Point(0, 0);
            this.lciBusqueda.Name = "lciBusqueda";
            this.lciBusqueda.Size = new System.Drawing.Size(571, 24);
            this.lciBusqueda.Text = "Ingrese descripción";
            this.lciBusqueda.TextSize = new System.Drawing.Size(93, 13);
            // 
            // frmAyudaProductoPrecio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 452);
            this.Name = "frmAyudaProductoPrecio";
            this.Text = "";
            this.gbCuerpo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).EndInit();
            this.lcCuerpo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcProducto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProducto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBusqueda.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBusqueda)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grcProducto;
        private DevExpress.XtraGrid.Views.Grid.GridView grvProducto;
        private DevExpress.XtraGrid.Columns.GridColumn gcCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn gcDescripcion;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private ControlesDiversos.OpcionesBarraGridSeleccion obgsSeleccion;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.TextEdit txtBusqueda;
        private DevExpress.XtraLayout.LayoutControlItem lciBusqueda;
        private DevExpress.XtraGrid.Columns.GridColumn gcIdUnidad;
        private DevExpress.XtraGrid.Columns.GridColumn gcUnidad;
        private DevExpress.XtraGrid.Columns.GridColumn gcPrecio;
        private DevExpress.XtraGrid.Columns.GridColumn gcIdCueCon;
        private DevExpress.XtraGrid.Columns.GridColumn gcNumCuenta;
        private DevExpress.XtraGrid.Columns.GridColumn gcAnio;
    }
}