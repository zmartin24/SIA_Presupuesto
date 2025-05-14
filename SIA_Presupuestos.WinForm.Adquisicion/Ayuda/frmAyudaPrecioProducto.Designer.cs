namespace SIA_Presupuesto.WinForm.Adquisicion.Ayuda
{
    partial class frmAyudaPrecioProducto
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
            this.grcSubPresupuestoDet = new DevExpress.XtraGrid.GridControl();
            this.grvSubPresupuestoDet = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUnidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFechaPrecio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPrecio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCantidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPresupuesto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.obgsSeleccion = new SIA_Presupuesto.WinForm.General.ControlesDiversos.OpcionesBarraGridSeleccion();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcgDatoFore = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciAnio = new DevExpress.XtraLayout.LayoutControlItem();
            this.lueAnio = new DevExpress.XtraEditors.LookUpEdit();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.gbCuerpo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).BeginInit();
            this.lcCuerpo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcSubPresupuestoDet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSubPresupuestoDet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgDatoFore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciAnio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueAnio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbCuerpo
            // 
            this.gbCuerpo.Size = new System.Drawing.Size(839, 511);
            // 
            // lcCuerpo
            // 
            this.lcCuerpo.Controls.Add(this.lueAnio);
            this.lcCuerpo.Controls.Add(this.obgsSeleccion);
            this.lcCuerpo.Controls.Add(this.grcSubPresupuestoDet);
            this.lcCuerpo.Size = new System.Drawing.Size(833, 491);
            // 
            // lcgCuerpo
            // 
            this.lcgCuerpo.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.lcgDatoFore});
            this.lcgCuerpo.Name = "Root";
            this.lcgCuerpo.Size = new System.Drawing.Size(833, 491);
            // 
            // grcSubPresupuestoDet
            // 
            this.grcSubPresupuestoDet.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.grcSubPresupuestoDet.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.grcSubPresupuestoDet.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.grcSubPresupuestoDet.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.grcSubPresupuestoDet.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.grcSubPresupuestoDet.Location = new System.Drawing.Point(12, 113);
            this.grcSubPresupuestoDet.MainView = this.grvSubPresupuestoDet;
            this.grcSubPresupuestoDet.Name = "grcSubPresupuestoDet";
            this.grcSubPresupuestoDet.Size = new System.Drawing.Size(809, 366);
            this.grcSubPresupuestoDet.TabIndex = 4;
            this.grcSubPresupuestoDet.UseEmbeddedNavigator = true;
            this.grcSubPresupuestoDet.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvSubPresupuestoDet});
            // 
            // grvSubPresupuestoDet
            // 
            this.grvSubPresupuestoDet.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcDescripcion,
            this.gcUnidad,
            this.gcFechaPrecio,
            this.gcPrecio,
            this.gcCantidad,
            this.gcPresupuesto});
            this.grvSubPresupuestoDet.GridControl = this.grcSubPresupuestoDet;
            this.grvSubPresupuestoDet.Name = "grvSubPresupuestoDet";
            this.grvSubPresupuestoDet.OptionsBehavior.Editable = false;
            this.grvSubPresupuestoDet.OptionsView.ColumnAutoWidth = false;
            this.grvSubPresupuestoDet.OptionsView.ShowAutoFilterRow = true;
            this.grvSubPresupuestoDet.OptionsView.ShowGroupPanel = false;
            // 
            // gcDescripcion
            // 
            this.gcDescripcion.AppearanceCell.Options.UseTextOptions = true;
            this.gcDescripcion.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gcDescripcion.Caption = "Descripción";
            this.gcDescripcion.FieldName = "descripcion";
            this.gcDescripcion.Name = "gcDescripcion";
            this.gcDescripcion.OptionsColumn.ReadOnly = true;
            this.gcDescripcion.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcDescripcion.Visible = true;
            this.gcDescripcion.VisibleIndex = 0;
            this.gcDescripcion.Width = 250;
            // 
            // gcUnidad
            // 
            this.gcUnidad.AppearanceCell.Options.UseTextOptions = true;
            this.gcUnidad.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcUnidad.Caption = "Unidad";
            this.gcUnidad.FieldName = "unidad";
            this.gcUnidad.Name = "gcUnidad";
            this.gcUnidad.OptionsColumn.ReadOnly = true;
            this.gcUnidad.Visible = true;
            this.gcUnidad.VisibleIndex = 1;
            this.gcUnidad.Width = 50;
            // 
            // gcFechaPrecio
            // 
            this.gcFechaPrecio.AppearanceCell.Options.UseTextOptions = true;
            this.gcFechaPrecio.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcFechaPrecio.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gcFechaPrecio.Caption = "Fecha Precio";
            this.gcFechaPrecio.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.gcFechaPrecio.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcFechaPrecio.FieldName = "fechaPrecio";
            this.gcFechaPrecio.Name = "gcFechaPrecio";
            this.gcFechaPrecio.OptionsColumn.ReadOnly = true;
            this.gcFechaPrecio.Visible = true;
            this.gcFechaPrecio.VisibleIndex = 2;
            this.gcFechaPrecio.Width = 100;
            // 
            // gcPrecio
            // 
            this.gcPrecio.AppearanceCell.Options.UseTextOptions = true;
            this.gcPrecio.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gcPrecio.Caption = "Precio";
            this.gcPrecio.DisplayFormat.FormatString = "{0:n}";
            this.gcPrecio.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcPrecio.FieldName = "precio";
            this.gcPrecio.Name = "gcPrecio";
            this.gcPrecio.OptionsColumn.ReadOnly = true;
            this.gcPrecio.Visible = true;
            this.gcPrecio.VisibleIndex = 3;
            this.gcPrecio.Width = 50;
            // 
            // gcCantidad
            // 
            this.gcCantidad.AppearanceCell.Options.UseTextOptions = true;
            this.gcCantidad.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gcCantidad.Caption = "Cant.";
            this.gcCantidad.DisplayFormat.FormatString = "{0:n}";
            this.gcCantidad.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcCantidad.FieldName = "cantidad";
            this.gcCantidad.Name = "gcCantidad";
            this.gcCantidad.OptionsColumn.ReadOnly = true;
            this.gcCantidad.Visible = true;
            this.gcCantidad.VisibleIndex = 4;
            this.gcCantidad.Width = 50;
            // 
            // gcPresupuesto
            // 
            this.gcPresupuesto.Caption = "Presupuesto";
            this.gcPresupuesto.FieldName = "desPresupuesto";
            this.gcPresupuesto.Name = "gcPresupuesto";
            this.gcPresupuesto.OptionsColumn.ReadOnly = true;
            this.gcPresupuesto.Visible = true;
            this.gcPresupuesto.VisibleIndex = 5;
            this.gcPresupuesto.Width = 400;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grcSubPresupuestoDet;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 101);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(813, 370);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // obgsSeleccion
            // 
            this.obgsSeleccion.Location = new System.Drawing.Point(12, 78);
            this.obgsSeleccion.Name = "obgsSeleccion";
            this.obgsSeleccion.Size = new System.Drawing.Size(809, 31);
            this.obgsSeleccion.TabIndex = 5;
            this.obgsSeleccion.SeleccionarRegistro += new System.EventHandler(this.obgsSeleccion_SeleccionarRegistro);
            this.obgsSeleccion.SiguienteRegistro += new System.EventHandler(this.obgsSeleccion_SiguienteRegistro);
            this.obgsSeleccion.AnteriorRegistro += new System.EventHandler(this.obgsSeleccion_AnteriorRegistro);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.obgsSeleccion;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 66);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(813, 35);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // lcgDatoFore
            // 
            this.lcgDatoFore.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciAnio,
            this.emptySpaceItem1});
            this.lcgDatoFore.Location = new System.Drawing.Point(0, 0);
            this.lcgDatoFore.Name = "lcgDatoFore";
            this.lcgDatoFore.Size = new System.Drawing.Size(813, 66);
            this.lcgDatoFore.Text = "Seleccione Año";
            // 
            // lciAnio
            // 
            this.lciAnio.Control = this.lueAnio;
            this.lciAnio.Location = new System.Drawing.Point(0, 0);
            this.lciAnio.Name = "lciAnio";
            this.lciAnio.Size = new System.Drawing.Size(101, 24);
            this.lciAnio.Text = "Año";
            this.lciAnio.TextSize = new System.Drawing.Size(19, 13);
            // 
            // lueAnio
            // 
            this.lueAnio.Location = new System.Drawing.Point(47, 42);
            this.lueAnio.Name = "lueAnio";
            this.lueAnio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueAnio.Size = new System.Drawing.Size(74, 20);
            this.lueAnio.StyleController = this.lcCuerpo;
            this.lueAnio.TabIndex = 7;
            this.lueAnio.EditValueChanged += new System.EventHandler(this.lueAnio_EditValueChanged);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(101, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(688, 24);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frmAyudaPrecioProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 561);
            this.Name = "frmAyudaPrecioProducto";
            this.Text = "frmAyudaSubPresupuestoDetalle";
            this.gbCuerpo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).EndInit();
            this.lcCuerpo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcSubPresupuestoDet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSubPresupuestoDet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgDatoFore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciAnio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueAnio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grcSubPresupuestoDet;
        private DevExpress.XtraGrid.Views.Grid.GridView grvSubPresupuestoDet;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gcDescripcion;
        private General.ControlesDiversos.OpcionesBarraGridSeleccion obgsSeleccion;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.Columns.GridColumn gcUnidad;
        private DevExpress.XtraGrid.Columns.GridColumn gcFechaPrecio;
        private DevExpress.XtraGrid.Columns.GridColumn gcPrecio;
        private DevExpress.XtraGrid.Columns.GridColumn gcCantidad;
        private DevExpress.XtraLayout.LayoutControlGroup lcgDatoFore;
        private DevExpress.XtraEditors.LookUpEdit lueAnio;
        private DevExpress.XtraLayout.LayoutControlItem lciAnio;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gcPresupuesto;
    }
}