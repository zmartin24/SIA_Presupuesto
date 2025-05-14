using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SIA_Presupuesto.WinForm.Adquisicion.Vista;
using SIA_Presupuesto.WinForm.General.Base;
using SIA_Presupuesto.WinForm.Adquisicion.Presentador;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Helper;
using SIA_Presupuesto.WinForm.Adquisicion.Recursos;
using Utilitario.Util;
using SIA_Presupuesto.WinForm.General.Ayuda;

namespace SIA_Presupuesto.WinForm.Adquisicion.Dialogo
{
    public partial class frmGastoRecurrenteDetalle : frmDialogoBase, IGastoRecurrenteDetalleVista
    {
        private GastoRecurrenteDetallePresentador gastoRecurrenteDetallePresentador;

        #region interface
        public List<Unidad> listaUnidades
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueUnidad.Properties, "idUnidad", "nomUnidad", "Unidades", value);
            }
        }
        public List<CuentaContable> listaCuentaContable
        {
            set
            {
                glueCuenta.Properties.DisplayMember = "numCuenta";
                glueCuenta.Properties.ValueMember = "idCueCon";
                glueCuenta.Properties.NullText = string.Empty;
                glueCuenta.Properties.DataSource = value;
            }
        }

        public int idUnidad
        {
            set { lueUnidad.EditValue = value; }
            get { return (Int32)lueUnidad.EditValue; }
        }
        public int idCueCon
        {
            set { glueCuenta.EditValue = value; }
            get { return Convert.ToInt32(glueCuenta.EditValue); }
        }
        
        public string descripcion
        {
            set { txtDescripcion.EditValue = value; }
            get { return txtDescripcion.Text; }
        }

        public decimal precio
        {
            set { sePrecio.EditValue = value; }
            get { return (decimal)sePrecio.EditValue; }
        }

        
        public string codBieSer
        {
            set { txtCodBieSer.EditValue = value; }
            get { return txtCodBieSer.Text; }
        }

        
        private string numCuenta;
        private string tipo;

        #endregion
        public frmGastoRecurrenteDetalle(string tipo, string numCuenta, GastoRecurrenteRequerimiento gastoRecurrenteRequerimiento, GastoRecurrenteDetalle gastoRecurrenteDetalle, Form padre) : base(padre, false)
        {
            InitializeComponent();
            Text = "Detalle - Gastos Recurrentes";
            this.tipo = tipo;
            this.numCuenta = numCuenta;
            this.esModificacion = gastoRecurrenteDetalle != null;
            this.gastoRecurrenteDetallePresentador = new GastoRecurrenteDetallePresentador(gastoRecurrenteRequerimiento, gastoRecurrenteDetalle, this);
        }

        protected override void InicializarValidacion()
        {
            dxProveedorValidador.SetValidationRule(lueUnidad, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(txtDescripcion, ValidacionHelper.ReglaNoDebeSerVacio);
        }

        protected override void InicializarDatos()
        {
            this.gastoRecurrenteDetallePresentador.IniciarDatos();
        }

        protected override void GuardarDatos()
        {
            if (gastoRecurrenteDetallePresentador.GuardarDatos())
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

        
        private void seCantidad_EditValueChanged(object sender, EventArgs e)
        {
            gastoRecurrenteDetallePresentador.ActualizarTotal();
        }

        private void sePrecio_EditValueChanged(object sender, EventArgs e)
        {
            gastoRecurrenteDetallePresentador.ActualizarTotal();
        }

        private void seDias_EditValueChanged(object sender, EventArgs e)
        {
            gastoRecurrenteDetallePresentador.ActualizarTotal();
        }

        private void sbAyudaProducto_Click(object sender, EventArgs e)
        {
            using (frmAyudaProducto frm = new frmAyudaProducto(this.numCuenta))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    gastoRecurrenteDetallePresentador.AsignarProducto(frm.Tag as Producto);
                }
            }
        }
    }
}