using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SIA_Presupuesto.WinForm.General.Base;
using SIA_Presupuesto.WinForm.Programacion.Vista;
using SIA_Presupuesto.WinForm.Programacion.Presentador;
using SIA_Presupuesto.WinForm.Programacion.Recursos;
using SIA_Presupuesto.WinForm.General.Helper;
using SIA_Presupuesto.Negocio.Entidades;

namespace SIA_Presupuesto.WinForm.Programacion.Dialogo
{
    public partial class frmEvaluacionMensualArea : frmDialogoBase, IEvaluacionMensualAreaVista
    {
        private EvaluacionMensualAreaPresentador evaluacionMensualAreaPresentador;

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
        public List<Direccion> listaDirecciones
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueDireccion.Properties, "idDireccion", "desDireccion", "Direcciones", value);
            }
        }

        public List<Subdireccion> listaSubdirecciones
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueSubdireccion.Properties, "idSubdireccion", "desSubdireccion", "Subdirecciones", value);
            }
        }

        public List<Area> listaAreas
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueArea.Properties, "idArea", "desArea", "Areas", value);
            }
        }

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

        public int idCueCon
        {
            set { glueCuenta.EditValue = value; }
            get { return Convert.ToInt32(glueCuenta.EditValue); }
        }

        public int idDireccion
        {
            set
            {
                lueDireccion.EditValue = value;
            }
            get { return Convert.ToInt32(lueDireccion.EditValue); }
        }

        public int idSubdireccion
        {
            set
            {
                lueSubdireccion.EditValue = value;
            }
            get { return Convert.ToInt32(lueSubdireccion.EditValue); }
        }

        public int idArea
        {
            set { lueArea.EditValue = value; }
            get { return lueArea.EditValue != null ? Convert.ToInt32(lueArea.EditValue) : 0; }
        }

        private bool esModificacion;
        public frmEvaluacionMensualArea(EvaluacionMensualProgramacion EvaluacionMensualProgramacion, EvaluacionMensualArea EvaluacionMensualArea, Form padre) : base(padre, false)
        {
            InitializeComponent();
            this.esModificacion = EvaluacionMensualArea != null;
            this.evaluacionMensualAreaPresentador = new EvaluacionMensualAreaPresentador(EvaluacionMensualProgramacion, EvaluacionMensualArea, this);

            Text = this.esModificacion ? "Editar Evaluación mensual por área" : "Evaluación mensual por área";
            glueCuenta.ReadOnly = this.esModificacion;
        }

        protected override void InicializarValidacion()
        {
            dxProveedorValidador.SetValidationRule(glueCuenta, ValidacionHelper.ReglaNoDebeSerVacio);
        }

        protected override void InicializarDatos()
        {
            evaluacionMensualAreaPresentador.IniciarDatos();
        }

        protected override bool ValidarDatos()
        {
            bool res = (proveedorValidacion.Validate() && evaluacionMensualAreaPresentador.ValidarRegistroExistente());
            if (!res)
                EmitirMensajeResultado(true, "No se registro, cuenta ya existe!");

            return res;
        }

        protected override void GuardarDatos()
        {
            //EvaluacionMensualArea objEma = evaluacionMensualAreaPresentador.BuscarEvaluacionMensualAreaPorCuenta();
            //if (objEma == null)
            //{
                if (evaluacionMensualAreaPresentador.GuardarDatos())
                {
                    if (this.esModificacion)
                        EmitirMensajeResultado(true, Mensajes.MensajeModificacionSatisfactoria);
                    else
                        EmitirMensajeResultado(true, Mensajes.MensajeRegistroSatisfactorio);
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
            //    EmitirMensajeResultado(true, "No se registro, cuenta ya existe!");
            //    this.DialogResult = DialogResult.No;
            //}
        }

        private void lueDireccion_EditValueChanged(object sender, EventArgs e)
        {
            if (lueDireccion.EditValue != null)
            {
                this.evaluacionMensualAreaPresentador.LlenarCombosSubdireccion(Convert.ToInt32(lueDireccion.EditValue));
                lueSubdireccion.EditValue = null;
                lueArea.EditValue = null;
            }
        }

        private void lueSubdireccion_EditValueChanged(object sender, EventArgs e)
        {
            if (lueSubdireccion.EditValue != null)
            {
                this.evaluacionMensualAreaPresentador.LlenarCombosAreas(Convert.ToInt32(lueSubdireccion.EditValue));
                lueArea.EditValue = null;
            }
        }
    }
}