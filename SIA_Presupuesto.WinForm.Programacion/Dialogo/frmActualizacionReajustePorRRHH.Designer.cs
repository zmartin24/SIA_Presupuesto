namespace SIA_Presupuesto.WinForm.Programacion.Dialogo
{
    partial class frmActualizacionReajustePorRRHH
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
            this.trvAreas = new System.Windows.Forms.TreeView();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ceElimina = new DevExpress.XtraEditors.CheckEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ceSoloReajuste = new DevExpress.XtraEditors.CheckEdit();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcBase)).BeginInit();
            this.lcBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxProveedorValidador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceElimina.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceSoloReajuste.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // lcCuerpo
            // 
            this.lcCuerpo.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(803, 132, 386, 350);
            // 
            // lcBase
            // 
            this.lcBase.Controls.Add(this.ceSoloReajuste);
            this.lcBase.Controls.Add(this.ceElimina);
            this.lcBase.Controls.Add(this.trvAreas);
            this.lcBase.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(777, 36, 450, 400);
            // 
            // lcgBase
            // 
            this.lcgBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem2});
            this.lcgBase.Name = "Root";
            // 
            // trvAreas
            // 
            this.trvAreas.CheckBoxes = true;
            this.trvAreas.Enabled = false;
            this.trvAreas.Location = new System.Drawing.Point(12, 35);
            this.trvAreas.Name = "trvAreas";
            this.trvAreas.Size = new System.Drawing.Size(381, 208);
            this.trvAreas.TabIndex = 4;
            this.trvAreas.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.trvAreas_AfterCheck);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.trvAreas;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 23);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(385, 212);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // ceElimina
            // 
            this.ceElimina.EditValue = true;
            this.ceElimina.Location = new System.Drawing.Point(333, 12);
            this.ceElimina.Name = "ceElimina";
            this.ceElimina.Properties.Caption = "";
            this.ceElimina.Size = new System.Drawing.Size(60, 19);
            this.ceElimina.StyleController = this.lcBase;
            this.ceElimina.TabIndex = 5;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.ceElimina;
            this.layoutControlItem2.Location = new System.Drawing.Point(192, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(193, 23);
            this.layoutControlItem2.Text = "Eliminar todos sus detalles";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(125, 13);
            // 
            // ceSoloReajuste
            // 
            this.ceSoloReajuste.EditValue = true;
            this.ceSoloReajuste.Location = new System.Drawing.Point(141, 12);
            this.ceSoloReajuste.Name = "ceSoloReajuste";
            this.ceSoloReajuste.Properties.Caption = "(Si)";
            this.ceSoloReajuste.Size = new System.Drawing.Size(59, 19);
            this.ceSoloReajuste.StyleController = this.lcBase;
            this.ceSoloReajuste.TabIndex = 6;
            this.ceSoloReajuste.CheckedChanged += new System.EventHandler(this.ceSoloReajuste_CheckedChanged);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.ceSoloReajuste;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(192, 23);
            this.layoutControlItem3.Text = "Solo por Reajuste Actual";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(125, 13);
            // 
            // frmActualizacionReajustePorRRHH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 325);
            this.Name = "frmActualizacionReajustePorRRHH";
            this.Text = "frmActualizacionPorPAC";
            ((System.ComponentModel.ISupportInitialize)(this.lcCuerpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCuerpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcBase)).EndInit();
            this.lcBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxProveedorValidador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceElimina.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceSoloReajuste.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView trvAreas;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.CheckEdit ceElimina;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.CheckEdit ceSoloReajuste;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}