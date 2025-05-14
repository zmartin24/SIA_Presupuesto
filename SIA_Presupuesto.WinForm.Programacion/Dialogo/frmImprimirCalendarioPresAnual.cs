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
    public partial class frmImprimirCalendarioPresAnual : frmDialogoBase, IImprimirCalendarioPresAnualVista
    {
        private ImprimirCalendarioPresAnualPresentador imprimirCalendarioPresAnualPresentador;

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

        public frmImprimirCalendarioPresAnual()
        {
            InitializeComponent();
            this.imprimirCalendarioPresAnualPresentador = new ImprimirCalendarioPresAnualPresentador(this);
            Text = "Imprimir Calendario Presupuesto Anual";
        }

        protected override void InicializarValidacion()
        {
            dxProveedorValidador.SetValidationRule(lueAnio, ValidacionHelper.ReglaNoDebeSerVacio);
            //dxProveedorValidador.SetValidationRule(luePresAnu, ValidacionHelper.ReglaNoDebeSerVacio);
            //dxProveedorValidador.SetValidationRule(lueFueFin, ValidacionHelper.ReglaNoDebeSerVacio);
        }

        protected override void InicializarDatos()
        {
            imprimirCalendarioPresAnualPresentador.Inicializar();
        }

        protected override bool ValidarDatos()
        {
            return proveedorValidacion.Validate();
        }

        protected override void GuardarDatos()
        {
            imprimirCalendarioPresAnualPresentador.ImprimirCalenarios();
            this.DialogResult = DialogResult.No;
        }
    }
}