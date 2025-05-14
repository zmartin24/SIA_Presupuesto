using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SIA_Presupuesto.WinForm.General.Base;
using SIA_Presupuesto.WinForm.Adquisicion.Vista;
using SIA_Presupuesto.WinForm.Adquisicion.Presentador;
using SIA_Presupuesto.WinForm.General.Helper;
using SIA_Presupuesto.Negocio.Entidades;
using System.IO;
using SIA_Presupuesto.WinForm.Adquisicion.Helper;
using Utilitario.Util;

namespace SIA_Presupuesto.WinForm.Adquisicion.Dialogo
{
    public partial class frmCertificacionRequerimientoReporte : frmDialogoBase, ICertificacionRequerimientoReporteVista
    {
        private CertificacionRequerimientoReportePresentador certificacionRequerimientoReportePresentador;

        public List<Anio> listaAnio
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueAnio.Properties, "indice", "nombre", "Año", value);
            }
        }
        public int anio
        {
            set
            {
                lueAnio.EditValue = value;
            }
            get { return Convert.ToInt32(lueAnio.EditValue); }
        }

        public List<Predeterminado> listaReporte
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueReporte.Properties, "codigo", "descripcion", "Reporte", value);
            }
        }

        public int codReporte
        {
            set
            {
                lueReporte.EditValue = value.ToString();
            }
            get { return Convert.ToInt32(lueReporte.EditValue); }
        }

        public frmCertificacionRequerimientoReporte()
        {
            InitializeComponent();
            this.certificacionRequerimientoReportePresentador = new CertificacionRequerimientoReportePresentador(this);
            Text = "Reporte - Certificación Requerimiento";
        }

        protected override void InicializarValidacion()
        {
            dxProveedorValidador.SetValidationRule(lueAnio, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(lueReporte, ValidacionHelper.ReglaNoDebeSerVacio);
        }
        protected override void InicializarDatos()
        {
            certificacionRequerimientoReportePresentador.IniciarDatos();
        }
        protected override bool ValidarDatos()
        {
            return proveedorValidacion.Validate();
        }
        protected override void GuardarDatos()
        {
            List<CertificacionRequerimientoExportaPres> lista = certificacionRequerimientoReportePresentador.TraerListaCertificacionRequerimientoExporta();
            if (lista.Count > 0)
            {
                ExportarCertificacionRequerimiento(lista);
                this.DialogResult = DialogResult.No;
            }
            else
                EmitirMensajeResultado(true, "No existen datos para esta consulta");
            
        }
        private void ExportarCertificacionRequerimiento(List<CertificacionRequerimientoExportaPres> lista)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel XLSX|*.xlsx";
                sfd.Title = "Guardar el siguiente archivo";

                string ruta = Path.GetTempPath() + "CertificacionRequerimiento_" + Path.GetRandomFileName() + ".xlsx";

                ExportarHelperAdquisicion.ExportarCertificacionRequerimiento(ruta, lista, this.codReporte);
                ExportarHelper.AbrirArchivoExcel(ruta);
            }
        }
    }
}