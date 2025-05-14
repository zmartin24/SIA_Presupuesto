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
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;

namespace SIA_Presupuesto.WinForm.Adquisicion.Dialogo
{
    public partial class frmAgregarCtaGasto : frmDialogoBase, IRubroBienServicioCuentaVista
    {
        private RubroBienServicioCuentaPresentador gastoRecurrentePresentador;
        private int _idCuentaAnterior = 0;

        public frmAgregarCtaGasto(RubroBienServicioCuentaPoco rubroBienServicio, Form padre,int idPlanCuenta) : base(padre, true)
        {
            InitializeComponent();
            this.esModificacion = rubroBienServicio != null;
            _idCuentaAnterior = (rubroBienServicio != null) ? rubroBienServicio.idCueCon : 0;
            gastoRecurrentePresentador = new RubroBienServicioCuentaPresentador(rubroBienServicio, idPlanCuenta, this);
            Text = (rubroBienServicio != null) ? "Modificar Cuenta Contable Gasto Recurrente" : "Nueva Cuenta Contable Gasto Recurrente";
        }

        protected override void InicializarDatos()
        {
            gastoRecurrentePresentador.IniciarDatos();
        }

        protected override void InicializarValidacion()
        {
            dxProveedorValidador.SetValidationRule(cboTipoGasto, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(cboCtaGenerica, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(cboSubCta, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(cboCta, ValidacionHelper.ReglaNoDebeSerVacio);
        }

        protected override void GuardarDatos()
        {
            
            //if (gastoRecurrentePresentador.ValidarExisteCta(idCuentaNivel3) == null)
            //{
                if (gastoRecurrentePresentador.GuardarDatos())
                {
                    if (this.esModificacion)
                        EmitirMensajeResultado(true, Mensajes.MensajeModificacionSatisfactoria);
                    else
                        EmitirMensajeResultado(true, Mensajes.MensajeRegistroSatisfactorio);

                    this.DialogResult = DialogResult.OK;
                }
                else
                    EmitirMensajeResultado(false, Mensajes.MensajeErrorRegistro);
            //}
            //else
            //{
            //    EmitirMensajeResultado(false, "La Cuenta ya se encuentra registrada.");
            //}
        }

        public int idRubBieSer
        {
            set { cboTipoGasto.EditValue = value; }
            get { return (Int32)cboTipoGasto.EditValue; }
        }

        public int idRubBieSerCue
        {
            get; set;
        }

        public List<CuentaContablePoco> listaCuentasNivel1
        {
            set
            {
                cboCtaGenerica.Properties.DisplayMember = "descripcion2";
                cboCtaGenerica.Properties.ValueMember = "idCueCon";
                cboCtaGenerica.Properties.NullText = string.Empty;
                cboCtaGenerica.Properties.DataSource = value;
            }
        }

        public List<CuentaContablePoco> listaCuentasNivel2
        {
            set
            {
                cboSubCta.Properties.DisplayMember = "descripcion2";
                cboSubCta.Properties.ValueMember = "idCueCon";
                cboSubCta.Properties.NullText = string.Empty;
                cboSubCta.Properties.DataSource = value;
            }
        }

        public List<CuentaContablePoco> listaCuentasNivel3
        {
            set
            {
                cboCta.Properties.DisplayMember = "descripcion2";
                cboCta.Properties.ValueMember = "idCueCon";
                cboCta.Properties.NullText = string.Empty;
                cboCta.Properties.DataSource = value;
            }
        }

        public List<RubroBienServicioPoco> listaTipoGastos
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(cboTipoGasto.Properties, "idRubBieSer", "descripcion", "Gasto", value);
            }
        }

        public int idCuentaNivel1
        {
            set { cboCtaGenerica.EditValue = value; }
            get { return (Int32)((cboCtaGenerica.EditValue.ToString() == "") ? 0 : cboCtaGenerica.EditValue); }
        }

        public int idCuentaNivel2
        {
            set { cboSubCta.EditValue = value; }
            get { return (Int32)((cboSubCta.EditValue.ToString() == "")?0: cboSubCta.EditValue); }
        }

        public int idCuentaNivel3
        {
            set { cboCta.EditValue = value; }
            get { return (Int32)((cboCta.EditValue.ToString() == "") ? 0 : cboCta.EditValue); }
        }

        private void cboCtaGenerica_EditValueChanged(object sender, EventArgs e)
        {
            gastoRecurrentePresentador.ActualizarCombo(2);
            cboSubCta.EditValue = string.Empty;
            cboCta.EditValue = string.Empty;
        }

        private void cboSubCta_EditValueChanged(object sender, EventArgs e)
        {
            gastoRecurrentePresentador.ActualizarCombo(3);
            cboCta.EditValue = string.Empty;
        }
    }
}
