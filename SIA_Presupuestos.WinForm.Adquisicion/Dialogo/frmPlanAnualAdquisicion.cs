using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SIA_Presupuesto.WinForm.General.Base;
using SIA_Presupuesto.WinForm.Adquisicion.Vista;
using SIA_Presupuesto.WinForm.Adquisicion.Presentador;
using SIA_Presupuesto.WinForm.General.Helper;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.Adquisicion.Recursos;
//using SIA_Presupuesto.WinForm.Programacion.Helper;

namespace SIA_Presupuesto.WinForm.Adquisicion.Dialogo
{
    public partial class frmPlanAnualAdquisicion : frmDialogoBase, IPlanAnualAdquisicionVista
    {
        private PlanAnualAdquisicionPresentador planAnualAdquisicionPresentador;

        public List<Moneda> listaMoneda
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueMoneda.Properties, "idMoneda", "descripcion", "Moneda", value);
            }
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
        public string siglas
        {
            set { txtSiglas.EditValue = value; }
            get { return txtSiglas.Text; }
        }
        public string uniEje
        {
            set { txtUndEje.EditValue = value; }
            get { return txtUndEje.Text; }
        }
        public string pliego
        {
            set { txtPliego.EditValue = value; }
            get { return txtPliego.Text; }
        }
        public int idTipMon
        {
            set { lueMoneda.EditValue = value; }
            get { return (Int32)lueMoneda.EditValue; }
        }
        public decimal tipCam
        {
            set { seTipCam.EditValue = value; }
            get { return (decimal)seTipCam.EditValue; }
        }

        public frmPlanAnualAdquisicion(PlanAnualAdquisicion planAnualAdquisicion, Form padre) : base(padre, true)
        {
            InitializeComponent();
            this.esModificacion = planAnualAdquisicion != null;
            planAnualAdquisicionPresentador = new PlanAnualAdquisicionPresentador(planAnualAdquisicion, this);
            Text = "Plan Anual de Aquisiciones y Contrataciones";
        }

        protected override void InicializarValidacion()
        {
            dxProveedorValidador.SetValidationRule(txtDescripcion, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(deFechaEmision, ValidacionHelper.ReglaNoDebeSerVacio);
            
            dxProveedorValidador.SetValidationRule(seAnio, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(txtSiglas, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(txtUndEje, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(txtPliego, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(lueMoneda, ValidacionHelper.ReglaNoDebeSerVacio);
        }

        protected override void InicializarDatos()
        {
            planAnualAdquisicionPresentador.IniciarDatos();
        }

        protected override void GuardarDatos()
        {
            if (planAnualAdquisicionPresentador.GuardarDatos())
            {
                if (this.esModificacion)
                    EmitirMensajeResultado(true, Mensajes.MensajeModificacionSatisfactoria);
                else
                    EmitirMensajeResultado(true, Mensajes.MensajeRegistroSatisfactorio);

                this.DialogResult = DialogResult.OK;
            }
            else
                EmitirMensajeResultado(false, Mensajes.MensajeErrorRegistro);
        }

        private void lueMoneda_EditValueChanged(object sender, EventArgs e)
        {
            if (idTipMon > 0 && idTipMon == 63)
            {
                seTipCam.ReadOnly = true;
                seTipCam.EditValue = 1;
            }
            else
            {

                seTipCam.ReadOnly = false;
            }
        }
    }
}
