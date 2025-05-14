using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SIA_Presupuesto.WinForm.Programacion.Vista;
using SIA_Presupuesto.WinForm.General.Base;
using SIA_Presupuesto.WinForm.Programacion.Presentador;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Helper;
using SIA_Presupuesto.WinForm.Programacion.Recursos;
using SIA_Presupuesto.WinForm.General.Ayuda;

namespace SIA_Presupuesto.WinForm.Programacion.Dialogo
{
    public partial class frmRequerimientoMensualDetalle : frmDialogoBase, IRequerimientoMensualDetalleVista
    {
        private RequerimientoMensualDetallePresentador requerimientoMensualDetallePresentador;

        public List<Unidad> listaUnidades
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueUnidad.Properties, "idUnidad", "nomUnidad", "Unidades", value);
            }
        }
        public PartidaPresupuestalPrecioPres partidaPresupuestalPrecioPres
        {
            set; get;
        }
        public ProductoPrecioPres productoPrecioPres
        {
            set;get;
        }
        
        public int idUnidad
        {
            set { lueUnidad.EditValue = value; }
            get { return (Int32)lueUnidad.EditValue; }
        }
        public int? idParPre
        {
            set; get;
        }
        public string desParPre 
        {
            set { bteParPre.Text = value; }
            get { return bteParPre.Text; }
        }
        public int? idProducto
        {
            set; get;
        }
        public string desProducto
        {
            set { bteProducto.Text = value; }
            get { return bteProducto.Text; }
        }

        public int idCueCon
        {
            set;get;
        }
        public string desCuenta
        {
            set { txtDesCuenta.EditValue = value; }
            get { return txtDesCuenta.Text; }
        }

        public string descripcion
        {
            set { txtDescripcion.EditValue = value; }
            get { return txtDescripcion.Text; }
        }

        public string justificacion
        {
            set { txtJustificacion.EditValue = value; }
            get { return txtJustificacion.Text; }
        }
        public decimal cantidad
        {
            set { seCantidad.EditValue = value; }
            get { return (decimal)seCantidad.EditValue; }
        }
        public decimal precio
        {
            set { sePrecio.EditValue = value; }
            get { return (decimal)sePrecio.EditValue; }
        }
        public decimal importe
        {
            set { seImporte.EditValue = value; }
            get { return (decimal)seImporte.EditValue; }
        }

        private bool esPrimeraCarga = true;//primera carga al modificar
        private string tipoProceso;

        private RequerimientoMensualBienServicioPres requerimientoMensualBienServicioPres;
        public frmRequerimientoMensualDetalle(RequerimientoMensualDetalle requerimientoMensualDetalle, RequerimientoMensualBienServicioPres requerimientoMensualBienServicioPres, string tipoProceso, Form padre) : base(padre, false)
        {
            InitializeComponent();
            
            this.esModificacion = requerimientoMensualDetalle != null;
            Text = this.esModificacion ? "Editar Detalle de Requerimiento" : "Agregar Detalle de Requerimiento";
            this.requerimientoMensualBienServicioPres = requerimientoMensualBienServicioPres;
            this.requerimientoMensualDetallePresentador = new RequerimientoMensualDetallePresentador(requerimientoMensualDetalle, requerimientoMensualBienServicioPres, tipoProceso, this);
            this.tipoProceso = tipoProceso;
        }

        protected override void InicializarValidacion()
        {
            dxProveedorValidador.SetValidationRule(lueUnidad, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(txtDesCuenta, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(sePrecio, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(seCantidad, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(seImporte, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(txtDescripcion, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(txtJustificacion, ValidacionHelper.ReglaNoDebeSerVacio);
        }

        protected override void InicializarDatos()
        {
            this.requerimientoMensualDetallePresentador.IniciarDatos();

            if(this.esModificacion)
            {
                
                chkConParPre.Checked = idParPre != null;
                chkConParPre.ReadOnly = this.requerimientoMensualBienServicioPres.tipo == 2;
                lciParPre.Visibility = idParPre != null ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                lciProducto.Visibility = idProducto != null ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                if (idParPre != null) bteParPre.Focus();
                if (idProducto != null) bteProducto.Focus();

                if (tipoProceso.Equals("EDITA_APRUEBA"))
                {
                    chkConParPre.ReadOnly = true;
                    bteParPre.ReadOnly = true;
                    bteParPre.Enabled = false;
                    bteProducto.ReadOnly = true;
                    bteProducto.Enabled = false;
                    txtDescripcion.ReadOnly = true;
                    sePrecio.ReadOnly = true;
                }

                esPrimeraCarga = false;
                return;
            }

            if (this.requerimientoMensualBienServicioPres.tipo.Equals(2))
            {
                chkConParPre.Checked = true;
                chkConParPre.ReadOnly = true;
                lciParPre.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lciProducto.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                bteParPre.Focus();
            }
        }

        protected override void GuardarDatos()
        {
            if (requerimientoMensualDetallePresentador.GuardarDatos())
            {
                if (!esModificacion)
                    EmitirMensajeResultado(true, Mensajes.MensajeRegistroSatisfactorio);
                else
                    EmitirMensajeResultado(true, Mensajes.MensajeModificacionSatisfactoria);
                this.DialogResult = DialogResult.OK;
            }
            else
                EmitirMensajeResultado(false, Mensajes.MensajeErrorRegistro);
        }

        private void bteProducto_Click(object sender, EventArgs e)
        {
            using (frmAyudaProductoPrecio frm = new frmAyudaProductoPrecio((Int32)this.requerimientoMensualBienServicioPres.idMoneda))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    requerimientoMensualDetallePresentador.AsignarProducto(frm.Tag as ProductoPrecioPres);
                }
            }
        }

        private void bteParPre_Click(object sender, EventArgs e)
        {
            using (frmAyudaPartidaPresupuestalPrecio frm = new frmAyudaPartidaPresupuestalPrecio(this.requerimientoMensualBienServicioPres))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    requerimientoMensualDetallePresentador.AsignarPartidaPresupuestal(frm.Tag as PartidaPresupuestalPrecioPres);
                }
            }
        }

        private void chkConParPre_CheckedChanged(object sender, EventArgs e)
        {
            chkConParPre.Focus();
            if (chkConParPre.Checked)
            {
                lciParPre.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lciProducto.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                bteProducto.Text = String.Empty;
                idProducto = null;
                bteParPre.Focus();
            }
            else
            {
                lciParPre.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                bteParPre.Text = String.Empty;
                idParPre = null;
                lciProducto.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                bteParPre.Focus();
            }
            
            if(esPrimeraCarga) return;

            idCueCon = 0;
            idUnidad = 4;
            desCuenta = String.Empty;
            descripcion = String.Empty;
            precio = 0;
            cantidad = 0;
            importe = 0;
        }

        private void sePrecio_EditValueChanged(object sender, EventArgs e)
        {
            importe = Math.Round(precio * cantidad, 2, MidpointRounding.AwayFromZero);
        }

        private void seCantidad_EditValueChanged(object sender, EventArgs e)
        {
            importe = Math.Round(precio * cantidad, 2, MidpointRounding.AwayFromZero);
        }
    }
}