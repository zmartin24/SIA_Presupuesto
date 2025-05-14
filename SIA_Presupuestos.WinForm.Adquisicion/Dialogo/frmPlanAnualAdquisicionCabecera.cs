using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SIA_Presupuesto.WinForm.General.Base;
using SIA_Presupuesto.WinForm.Adquisicion.Vista;
using SIA_Presupuesto.WinForm.Adquisicion.Presentador;
using SIA_Presupuesto.WinForm.General.Helper;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.Adquisicion.Recursos;

namespace SIA_Presupuesto.WinForm.Adquisicion.Dialogo
{
    public partial class frmPlanAnualAdquisicionCabecera : frmDialogoBase, IPlanAnualAdquisicionRequerimientoCabeceraVista
    {
        private PlanAnualAdquisicionRequerimientoCabeceraPresentador planAnualAdquisicionRequerimientoCabeceraPresentador;

        public List<Moneda> listaMonedas
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueMoneda.Properties, "idMoneda", "descripcion", "Monedas", value);
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
        public int idMoneda
        {
            set { lueMoneda.EditValue = value; }
            get { return Convert.ToInt32(lueMoneda.EditValue); }
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
            get { return Convert.ToInt32(lueArea.EditValue); }
        }
        public int anio
        {
            set { seAnio.EditValue = value; }
            get { return Convert.ToInt32(seAnio.EditValue); }
        }
        public string descripcion
        {
            set { txtDescripcion.EditValue = value; }
            get { return txtDescripcion.Text; }
        }

        public DateTime fechaEmision
        {
            set { deFechaEmision.EditValue = value; }
            get { return Convert.ToDateTime(deFechaEmision.EditValue); }
        }

        public frmPlanAnualAdquisicionCabecera(PlanAnualAdquisicion planAnualAdquisicion, PlanAnualAdquisicionRequerimiento planAnualAdquisicionRequerimiento, Form padre) : base(padre, true)
        {
            InitializeComponent();
            this.esModificacion = planAnualAdquisicionRequerimiento != null;
            planAnualAdquisicionRequerimientoCabeceraPresentador = new PlanAnualAdquisicionRequerimientoCabeceraPresentador(planAnualAdquisicion, planAnualAdquisicionRequerimiento, this);
            Text = "Requerimiento Bien & Servicio - Plan Anual de Adquisición y Contrataciones";
        }

        protected override void InicializarValidacion()
        {
            dxProveedorValidador.SetValidationRule(lueMoneda, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(txtDescripcion, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(deFechaEmision, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(lueArea, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(seAnio, ValidacionHelper.ReglaNoDebeSerVacio);
        }

        protected override void InicializarDatos()
        {
            planAnualAdquisicionRequerimientoCabeceraPresentador.IniciarDatos();
        }
        protected override bool ValidarDatos()
        {
            bool validar = planAnualAdquisicionRequerimientoCabeceraPresentador.ValidarRegistroExistente();
            if (!validar)
            {
                EmitirMensajeResultado(true, "Ya existe descripción de requerimiento para la misma área");
            }

            return proveedorValidacion.Validate() && validar;
        }

        protected override void GuardarDatos()
        {
            if (planAnualAdquisicionRequerimientoCabeceraPresentador.GuardarDatos())
            {
                if(this.esModificacion)
                    EmitirMensajeResultado(true, Mensajes.MensajeModificacionSatisfactoria);
                else
                    EmitirMensajeResultado(true, Mensajes.MensajeRegistroSatisfactorio);

                this.DialogResult = DialogResult.OK;
            }
            else
                EmitirMensajeResultado(false, Mensajes.MensajeErrorRegistro);
        }

        private void lueDireccion_EditValueChanged(object sender, EventArgs e)
        {
            if (lueDireccion.EditValue != null)
            {
                this.planAnualAdquisicionRequerimientoCabeceraPresentador.LlenarCombosSubdireccion(Convert.ToInt32(lueDireccion.EditValue));
                lueSubdireccion.EditValue = null;
                lueArea.EditValue = null;
            }
        }

        private void lueSubdireccion_EditValueChanged(object sender, EventArgs e)
        {
            if (lueSubdireccion.EditValue != null)
            {
                this.planAnualAdquisicionRequerimientoCabeceraPresentador.LlenarCombosAreas(Convert.ToInt32(lueSubdireccion.EditValue));
                lueArea.EditValue = null;
            }
        }
    }
}