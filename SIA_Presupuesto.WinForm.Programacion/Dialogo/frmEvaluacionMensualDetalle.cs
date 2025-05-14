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
    public partial class frmEvaluacionMensualDetalle : frmDialogoBase, IEvaluacionMensualDetalleVista
    {
        private EvaluacionMensualDetallePresentador evaluacionMensualDetallePresentador;

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



        private string tipo;
        public frmEvaluacionMensualDetalle(string tipo, EvaluacionMensualArea EvaluacionMensualArea, EvaluacionMensualDetalle EvaluacionMensualDetalle, Form padre) : base(padre, false)
        {
            InitializeComponent();
            Text = "Detalle";
            this.tipo = tipo;
            this.esModificacion = EvaluacionMensualDetalle != null;
            this.evaluacionMensualDetallePresentador = new EvaluacionMensualDetallePresentador(EvaluacionMensualArea, EvaluacionMensualDetalle, this);
        }

        protected override void InicializarValidacion()
        {
            dxProveedorValidador.SetValidationRule(lueUnidad, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(sePrecio, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(txtDescripcion, ValidacionHelper.ReglaNoDebeSerVacio);
        }

        protected override void InicializarDatos()
        {
            evaluacionMensualDetallePresentador.IniciarDatos();
        }
        protected override bool ValidarDatos()
        {
            bool res = (proveedorValidacion.Validate() && evaluacionMensualDetallePresentador.ValidarRegistroExistente());
            if (!res)
                EmitirMensajeResultado(true, "No se registro, detalle con unidad y precio ya existe");

            return res;
        }
        protected override void GuardarDatos()
        {
            //EvaluacionMensualDetalle objDet = evaluacionMensualDetallePresentador.BuscarEvaluacionMensualDetalle();
            //if (objDet == null)
            //{
                if (evaluacionMensualDetallePresentador.GuardarDatos())
                {
                    if (!esModificacion)
                        EmitirMensajeResultado(true, Mensajes.MensajeRegistroSatisfactorio);
                    else
                        EmitirMensajeResultado(true, Mensajes.MensajeModificacionSatisfactoria);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    EmitirMensajeResultado(false, Mensajes.MensajeErrorRegistro);
                    this.DialogResult = DialogResult.No;
                }
            //}
            //else
            //{
            //    EmitirMensajeResultado(true, "No se registro, detalle con unidad y precio ya existe");
            //    this.DialogResult = DialogResult.No;
            //}
        }

    }
}