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
    public partial class frmImprimirPorDireccionReajusteMensual : frmDialogoBase, IImprimirPorDireccionReajusteMensualVista
    {
        private ImprimirPorDireccionReajusteMensualPresentador imprimirPorDireccionReajusteMensualPresentador;

        public List<Direccion> listaDirecciones
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueDireccion.Properties, "idDireccion", "desDireccion", "Direcciones", value);
            }
        }

        public List<GrupoPresupuesto> listaGrupoPresupuesto
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueGruPre.Properties, "idGruPre", "descripcion", "Grupo Presupuesto", value);
            }
        }

        public int idDireccion
        {
            set
            {
                lueDireccion.EditValue = value;
            }
            get { return lueDireccion.EditValue!=null ? Convert.ToInt32(lueDireccion.EditValue) : 0; }
        }

        public int idGruPre
        {
            set
            {
                lueGruPre.EditValue = value;
            }
            get { return lueGruPre.EditValue != null ?  Convert.ToInt32(lueGruPre.EditValue) : 0; }
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

        public List<Mes> listaMeses
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueMes.Properties, "indice", "nombre", "Meses", value);
            }
        }

        public int mesReporte
        {
            set { lueMes.EditValue = value; }
            get { return Convert.ToInt32(lueMes.EditValue); }
        }

        public List<Mes> listaMesesEva
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueMesEva.Properties, "indice", "nombre", "Meses", value);
            }
        }

        public int mesReporteEva
        {
            set { lueMesEva.EditValue = value; }
            get { return Convert.ToInt32(lueMesEva.EditValue); }
        }

        public string codReporte
        {
            set
            {
                lueReporte.EditValue = value;
            }
            get { return Convert.ToString(lueReporte.EditValue); }
        }

        public frmImprimirPorDireccionReajusteMensual()
        {
            InitializeComponent();
            this.imprimirPorDireccionReajusteMensualPresentador = new ImprimirPorDireccionReajusteMensualPresentador(this);
            Text = "Reajuste Mensual Por Dirección y Subdirecciones";
        }

        protected override void InicializarValidacion()
        {
            dxProveedorValidador.SetValidationRule(lueGruPre, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(lueReporte, ValidacionHelper.ReglaNoDebeSerVacio);
        }

        protected override void InicializarDatos()
        {
            imprimirPorDireccionReajusteMensualPresentador.Inicializar();
        }

        protected override bool ValidarDatos()
        {
            return proveedorValidacion.Validate();
        }

        protected override void GuardarDatos()
        {
            imprimirPorDireccionReajusteMensualPresentador.ReajustePorDireccion();
            this.DialogResult = DialogResult.No;
        }

        private void lueMesEva_EditValueChanged(object sender, EventArgs e)
        {
            imprimirPorDireccionReajusteMensualPresentador.SeleccionarReajuste();
        }
    }
}