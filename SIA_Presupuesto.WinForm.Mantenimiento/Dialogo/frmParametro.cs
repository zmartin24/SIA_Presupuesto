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
using SIA_Presupuesto.WinForm.Mantenimiento.Vista;
using SIA_Presupuesto.WinForm.Mantenimiento.Presentador;
using SIA_Presupuesto.WinForm.General.Helper;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.Mantenimiento.Recursos;


namespace SIA_Presupuesto.WinForm.Mantenimiento.Dialogo
{
    public partial class frmParametro : frmDialogoBase, IParametroVista
    {
        private ParametroPresentador parametroPresentador;

        public List<ConceptoPresupuestoRemuneracion> listaConceptos
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueConcepto.Properties, "idConPreRem", "descripcion", "Conceptos", value);
            }
        }

        public List<Moneda> listaMonedas
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueMoneda.Properties, "idMoneda", "descripcion", "Monedas", value);
            }
        }

        public int idMoneda
        {
            set { lueMoneda.EditValue = value; }
            get { return Convert.ToInt32(lueMoneda.EditValue); }
        }

        public int idConPreRem
        {
            set { lueConcepto.EditValue = value; }
            get { return Convert.ToInt32(lueConcepto.EditValue); }
        }

        public decimal importe
        {
            set { seImporte.EditValue = value; }
            get { return Convert.ToDecimal(seImporte.EditValue); }
        }

        public frmParametro(ParametroPresupuestoRemuneracion parametro, Form padre) : base(padre, true)
        {
            InitializeComponent();
            this.esModificacion = parametro != null;
            parametroPresentador = new ParametroPresentador(parametro, this);
            Text = parametro != null ? "Modificación de Parametro ": "Registro de Parametro";
        }

        protected override void InicializarValidacion()
        {
            dxProveedorValidador.SetValidationRule(lueConcepto, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(seImporte, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(lueMoneda, ValidacionHelper.ReglaNoDebeSerVacio);
        }
        protected override void InicializarDatos()
        {
            parametroPresentador.IniciarDatos();
        }
        protected override void GuardarDatos()
        {
            if (parametroPresentador.GuardarDatos())
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
    }
}
