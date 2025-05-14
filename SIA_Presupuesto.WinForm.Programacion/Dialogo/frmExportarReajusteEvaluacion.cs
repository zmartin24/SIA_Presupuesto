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
using System.IO;
using System.Globalization;

namespace SIA_Presupuesto.WinForm.Programacion.Dialogo
{
    public partial class frmExportarReajusteEvaluacion : frmDialogoBase, IExportarReajusteEvaluacionVista
    {
        private ExportarReajusteEvaluacionPresentador exportarReajusteEvaluacionPresentador;

        public List<Anio> listaAnios
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueAnio.Properties, "indice", "nombre", "Años", value);
            }
        }
        public List<Moneda> listaMoneda
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueMoneda.Properties, "idMoneda", "descripcion", "Moneda", value);
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

        public int idProAnu
        {
            set
            {
                luePresupuesto.EditValue = value;
            }
            get { return Convert.ToInt32(luePresupuesto.EditValue); }
        }

        public List<ProgramacionAnualPres> listaProgramacionAnual
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(luePresupuesto.Properties, "idProAnu", "descripcion", "Programación Anual", value);
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
        public int idMoneda
        {
            set { lueMoneda.EditValue = value; }
            get { return lueMoneda.EditValue != null ? Convert.ToInt32(lueMoneda.EditValue) : 0; }
        }

        public frmExportarReajusteEvaluacion()
        {
            InitializeComponent();
            this.exportarReajusteEvaluacionPresentador = new ExportarReajusteEvaluacionPresentador(this);
            Text = "Exportar Evaluación -  Reajuste";
        }

        protected override void InicializarValidacion()
        {
            dxProveedorValidador.SetValidationRule(lueAnio, ValidacionHelper.ReglaNoDebeSerVacio);
        }

        protected override void InicializarDatos()
        {
            exportarReajusteEvaluacionPresentador.Inicializar();
        }

        protected override bool ValidarDatos()
        {
            return proveedorValidacion.Validate();
        }

        protected override void GuardarDatos()
        {
            //exportarReajusteEvaluacionPresentador.Exportar();
            ExportarEvaluacionReajuste(this.exportarReajusteEvaluacionPresentador.TraerReporteEvaluacionReajusteMensualExporta());
            this.DialogResult = DialogResult.No;
        }

        private void lueMes_EditValueChanged(object sender, EventArgs e)
        {
            if (lueMes.EditValue != null)
                exportarReajusteEvaluacionPresentador.AsignarMesReajuste();
        }

        private void lueAnio_EditValueChanged(object sender, EventArgs e)
        {
            if (lueAnio.EditValue != null)
                exportarReajusteEvaluacionPresentador.CargarProgramacionAnual();
        }
        
        private void ExportarEvaluacionReajuste(List<ReporteEvaluacionReajusteMensualExportaPres> lista)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                string format = "yyyy-MM-dd_hh.mm.ss.tt";
                sfd.Filter = "Excel XLSX|*.xlsx";
                sfd.Title = "Guardar el siguiente archivo";

                string ruta = Path.GetTempPath() + "EvaluacionReajuste_" + DateTime.Now.ToString(format, CultureInfo.InvariantCulture).ToLower() + ".xlsx";

                ExportarProHelper.ExportarEvaluacionReajusteMensualConCantidad(ruta, lista, mesReporteRea);
                ExportarHelper.AbrirArchivoExcel(ruta);
            }
        }
    }
}