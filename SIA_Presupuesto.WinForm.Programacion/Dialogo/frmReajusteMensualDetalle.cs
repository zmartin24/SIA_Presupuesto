using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SIA_Presupuesto.WinForm.Programacion.Vista;
using SIA_Presupuesto.WinForm.General.Base;
using SIA_Presupuesto.WinForm.Programacion.Presentador;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Helper;
using SIA_Presupuesto.WinForm.Programacion.Recursos;

namespace SIA_Presupuesto.WinForm.Programacion.Dialogo
{
    public partial class frmReajusteMensualDetalle : frmDialogoBase, IReajusteMensualDetalleVista
    {
        private ReajusteMensualDetallePresentador reajusteMensualDetallePresentador;

        public List<Unidad> listaUnidades
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueUnidad.Properties, "idUnidad", "nomUnidad", "Unidades", value);
            }
        }

        public int idUnidad
        {
            set { lueUnidad.EditValue = value; }
            get { return (Int32)lueUnidad.EditValue; }
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
        public string justificacion
        {
            set { txtJustificacion.EditValue = value; }
            get { return txtJustificacion.Text; }
        }
        //Original
        private int idUnidadIni
        {
            set;get;
        }

        private string descripcionIni
        {
            set; get;
        }

        private decimal precioIni
        {
            set; get;
        }



        private string tipo;
        public frmReajusteMensualDetalle(string tipo, ReajusteMensualArea ReajusteMensualArea, ReajusteMensualDetalle ReajusteMensualDetalle, Form padre) : base(padre, false)
        {
            InitializeComponent();
            Text = "Detalle";
            this.tipo = tipo;
            this.esModificacion = ReajusteMensualDetalle != null;
            this.reajusteMensualDetallePresentador = new ReajusteMensualDetallePresentador(ReajusteMensualArea, ReajusteMensualDetalle, this);
        }

        protected override void InicializarValidacion()
        {
            dxProveedorValidador.SetValidationRule(lueUnidad, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(sePrecio, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(txtDescripcion, ValidacionHelper.ReglaNoDebeSerVacio);
        }

        protected override void InicializarDatos()
        {
            reajusteMensualDetallePresentador.IniciarDatos();
            if (this.esModificacion)
            {
                descripcionIni = descripcion.Trim().ToUpper();
                idUnidadIni = idUnidad;
                precioIni = precio;
            }
        }
        protected override bool ValidarDatos()
        {
            bool res = (proveedorValidacion.Validate() && reajusteMensualDetallePresentador.ValidarRegistroExistente());
            if (!res)
                EmitirMensajeResultado(true, "La descripción, unidad y precio ya existe");

            return res;
        }

        protected override void GuardarDatos()
        {
            if (reajusteMensualDetallePresentador.GuardarDatos())
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
            reajusteMensualDetallePresentador.ActualizarTotal();
        }

        private void sePrecio_EditValueChanged(object sender, EventArgs e)
        {
            reajusteMensualDetallePresentador.ActualizarTotal();
        }

        private void seDias_EditValueChanged(object sender, EventArgs e)
        {
            reajusteMensualDetallePresentador.ActualizarTotal();
        }
    }
}