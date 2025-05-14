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
    public partial class frmReporteEvaluacion : frmDialogoBase, IReporteEvaluacionVista
    {
        private ReporteEvaluacionPresentador reporteEvaluacionPresentador;

        public List<Anio> listaAnios
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueAnio.Properties, "indice", "nombre", "Año", value);
            }
        }

        public List<Mes> listaMeses
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueMes.Properties, "indice", "nombre", "Meses", value);
            }
        }

        public int mes
        {
            set
            {
                lueMes.EditValue = value;
            }
            get { return Convert.ToInt32(lueMes.EditValue); }
        }

        public int anio
        {
            set
            {
                lueAnio.EditValue = value;
            }
            get { return Convert.ToInt32(lueAnio.EditValue); }
        }

        public int idTipRep
        {
            set
            {
                lueReporte.EditValue = value;
            }
            get { return Convert.ToInt32(lueReporte.EditValue); }
        }

        public List<TipoReporte> listaReporte
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueReporte.Properties, "idTipRep", "descripcion", "Tipo de Reporte", value);
            }
        }

        public frmReporteEvaluacion()
        {
            InitializeComponent();
            this.reporteEvaluacionPresentador = new ReporteEvaluacionPresentador(this);
            Text = "Reporte Por Evaluación";
        }

        protected override void InicializarValidacion()
        {
            dxProveedorValidador.SetValidationRule(lueAnio, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(lueMes, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(lueReporte, ValidacionHelper.ReglaNoDebeSerVacio);
        }

        protected override void InicializarDatos()
        {
            reporteEvaluacionPresentador.Inicializar();
        }

        protected override bool ValidarDatos()
        {
            return proveedorValidacion.Validate();
        }

        protected override void GuardarDatos()
        {
            reporteEvaluacionPresentador.Imprimir();
            this.DialogResult = DialogResult.No;
        }
    }
}