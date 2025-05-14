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
    public partial class frmImprimirPorDireccionPresupuestoAnual : frmDialogoBase, IImprimirPorDireccionPresupuestoAnualVista
    {
        private ImprimirPorDireccionPresupuestoAnualPresentador imprimirPorDireccionPresentador;

        public List<Direccion> listaDirecciones
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueDireccion.Properties, "idDireccion", "desDireccion", "Direcciones", value);
            }
        }

        public int idDireccion
        {
            set
            {
                lueDireccion.EditValue = value;
            }
            get { return Convert.ToInt32(lueDireccion.EditValue); }
        }

        public List<Predeterminado> listaReporte
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueReporte.Properties, "codigo", "descripcion", "Direcciones", value);
            }
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
            set { lueAnio.EditValue = value; }
            get { return Convert.ToInt32(lueAnio.EditValue); }
        }

        public string codReporte
        {
            set
            {
                lueReporte.EditValue = value;
            }
            get { return Convert.ToString(lueReporte.EditValue); }
        }

        public frmImprimirPorDireccionPresupuestoAnual()
        {
            InitializeComponent();
            this.imprimirPorDireccionPresentador = new ImprimirPorDireccionPresupuestoAnualPresentador(this);
            Text = "Presupuesto Anual Por Dirección y Subdirecciones";
        }

        protected override void InicializarValidacion()
        {
            dxProveedorValidador.SetValidationRule(lueDireccion, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(lueReporte, ValidacionHelper.ReglaNoDebeSerVacio);
        }

        protected override void InicializarDatos()
        {
            imprimirPorDireccionPresentador.Inicializar();
        }

        protected override bool ValidarDatos()
        {
            return proveedorValidacion.Validate();
        }

        protected override void GuardarDatos()
        {
            imprimirPorDireccionPresentador.RequerimientoPorDireccion();
            this.DialogResult = DialogResult.No;
        }
    }
}