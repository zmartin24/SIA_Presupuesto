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
    public partial class frmImprimirCalendarioReajusteEvaluacion : frmDialogoBase, IImprimirCalendarioReajusteEvaluacionVista
    {
        private ImprimirCalendarioReajusteEvaluacionPresentador imprimirCalendarioReajusteEvaluacionPresentador;

        public List<ProgramacionAnualPres> listaProgramacion
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(luePresAnu.Properties, "idProAnu", "descripcion", "Presupuesto Anual", value);
            }
        }

        public int idProAnu
        {
            set
            {
                luePresAnu.EditValue = value;
            }
            get { return Convert.ToInt32(luePresAnu.EditValue); }
        }

        public List<FuenteFinanciamiento> listaFueFin
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueFueFin.Properties, "idFueFin", "fuente", "Fuente de Financiamiento", value);
            }
        }

        public int idFueFin
        {
            set
            {
                lueFueFin.EditValue = value;
            }
            get { return Convert.ToInt32(lueFueFin.EditValue); }
        }

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
                ElementoHelper.LlenarLookUpEdit(lueMes.Properties, "indice", "nombre", "Meses", value);
            }
        }

        public int mesReporte
        {
            set
            {
                lueMes.EditValue = value;
            }
            get { return Convert.ToInt32(lueMes.EditValue); }
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

        public frmImprimirCalendarioReajusteEvaluacion()
        {
            InitializeComponent();
            this.imprimirCalendarioReajusteEvaluacionPresentador = new ImprimirCalendarioReajusteEvaluacionPresentador(this);
            Text = "Imprimir Calendario Evaluación -  Reajuste";
        }

        protected override void InicializarValidacion()
        {
            dxProveedorValidador.SetValidationRule(lueAnio, ValidacionHelper.ReglaNoDebeSerVacio);
            //dxProveedorValidador.SetValidationRule(luePresAnu, ValidacionHelper.ReglaNoDebeSerVacio);
            //dxProveedorValidador.SetValidationRule(lueFueFin, ValidacionHelper.ReglaNoDebeSerVacio);
        }

        protected override void InicializarDatos()
        {
            imprimirCalendarioReajusteEvaluacionPresentador.Inicializar();
        }

        protected override bool ValidarDatos()
        {
            return proveedorValidacion.Validate();
        }

        protected override void GuardarDatos()
        {
            imprimirCalendarioReajusteEvaluacionPresentador.ImprimirCalenarios();
            this.DialogResult = DialogResult.No;
        }

        private void lueMes_EditValueChanged(object sender, EventArgs e)
        {
            if (lueMes.EditValue != null)
                imprimirCalendarioReajusteEvaluacionPresentador.AsignarMesReajuste();
        }
    }
}