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
using SIA_Presupuesto.WinForm.Programacion.Vista;
using SIA_Presupuesto.WinForm.Programacion.Presentador;
using SIA_Presupuesto.WinForm.General.Helper;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.Programacion.Helper;
using Utilitario.Util;

namespace SIA_Presupuesto.WinForm.Programacion.Dialogo
{
    public partial class frmImprimirSaldoEvaluacionReajusteAnual : frmDialogoBase, IImprimirSaldoEvaluacionReajusteAnualVista
    {
        private ImprimirSaldoEvaluacionReajustePresentador imprimirSaldoEvaluacionReajustePresentador;

        public List<Anio> listaAnios
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueAnio.Properties, "indice", "nombre", "Años", value);
            }
        }

        public int anioReporte
        {
            set
            {
                lueAnio.EditValue = value;
            }
            get { return Convert.ToInt32(lueAnio.EditValue); }
        }

        public List<Mes> listaMeses
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueMesEvaluacion.Properties, "indice", "nombre", "Meses", value);
            }
        }

        public int mesReporte
        {
            set
            {
                lueMesEvaluacion.EditValue = value;
            }
            get { return Convert.ToInt32(lueMesEvaluacion.EditValue); }
        }

        public List<Mes> listaMesesRea
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueMesReajuste.Properties, "indice", "nombre", "Meses", value);
            }
        }

        public int mesReporteRea
        {
            set
            {
                lueMesReajuste.EditValue = value;
            }
            get { return Convert.ToInt32(lueMesReajuste.EditValue); }
        }

        public frmImprimirSaldoEvaluacionReajusteAnual()
        {
            InitializeComponent();
            this.imprimirSaldoEvaluacionReajustePresentador = new ImprimirSaldoEvaluacionReajustePresentador(this);
            Text = "Imprimir Saldos";
        }

        protected override void InicializarValidacion()
        {
            dxProveedorValidador.SetValidationRule(lueAnio, ValidacionHelper.ReglaNoDebeSerVacio);
            //dxProveedorValidador.SetValidationRule(luePresAnu, ValidacionHelper.ReglaNoDebeSerVacio);
            //dxProveedorValidador.SetValidationRule(lueFueFin, ValidacionHelper.ReglaNoDebeSerVacio);
        }

        protected override void InicializarDatos()
        {
            imprimirSaldoEvaluacionReajustePresentador.Inicializar();
        }

        protected override bool ValidarDatos()
        {
            return proveedorValidacion.Validate();
        }

        protected override void GuardarDatos()
        {
            imprimirSaldoEvaluacionReajustePresentador.ImprimirCalenarios();
            this.DialogResult = DialogResult.No;
        }

        private void lueMesEvaluacion_EditValueChanged(object sender, EventArgs e)
        {
            if (lueMesEvaluacion.EditValue != null)
                imprimirSaldoEvaluacionReajustePresentador.AsignarMesReajuste();
        }
    }
}