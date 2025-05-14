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
    public partial class frmProgramacionAnualDetalle : frmDialogoBase, IProgramacionAnualDetalleVista
    {
        private ProgramacionAnualDetallePresentador programacionAnualDetallePresentador;

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

        private string numCuenta;
        private string tipo;
        public frmProgramacionAnualDetalle(string tipo, string numCuenta, ProgramacionAnualArea ProgramacionAnualArea, ProgramacionAnualDetalle ProgramacionAnualDetalle, Form padre) : base(padre, false)
        {
            InitializeComponent();
            Text = "Detalle";
            this.tipo = tipo;
            this.numCuenta = numCuenta;
            this.esModificacion = ProgramacionAnualDetalle != null;
            this.programacionAnualDetallePresentador = new ProgramacionAnualDetallePresentador(ProgramacionAnualArea, ProgramacionAnualDetalle, this);
        }

        protected override void InicializarValidacion()
        {
            dxProveedorValidador.SetValidationRule(lueUnidad, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(sePrecio, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(txtDescripcion, ValidacionHelper.ReglaNoDebeSerVacio);
        }

        protected override void InicializarDatos()
        {
            programacionAnualDetallePresentador.IniciarDatos();
        }
        protected override bool ValidarDatos()
        {
            bool res = (proveedorValidacion.Validate() && programacionAnualDetallePresentador.ValidarRegistroExistente());
            if (!res)
                EmitirMensajeResultado(true, "La descripción, unidad y precio ya existe");

            return res;
        }

        protected override void GuardarDatos()
        {
            if (programacionAnualDetallePresentador.GuardarDatos())
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
            programacionAnualDetallePresentador.ActualizarTotal();
        }

        private void sePrecio_EditValueChanged(object sender, EventArgs e)
        {
            programacionAnualDetallePresentador.ActualizarTotal();
        }

        private void seDias_EditValueChanged(object sender, EventArgs e)
        {
            programacionAnualDetallePresentador.ActualizarTotal();
        }

        private void sbAyudaProducto_Click(object sender, EventArgs e)
        {
            using (frmAyudaProducto frm = new frmAyudaProducto(this.numCuenta))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    programacionAnualDetallePresentador.AsignarProducto(frm.Tag as Producto);
                }
            }
        }
    }
}