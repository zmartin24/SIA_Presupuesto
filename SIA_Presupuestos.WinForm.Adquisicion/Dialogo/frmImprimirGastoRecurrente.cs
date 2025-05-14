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
//using SIA_Presupuesto.WinForm.Adquisicion.Helper;

namespace SIA_Presupuesto.WinForm.Adquisicion.Dialogo
{
    public partial class frmImprimirGastoRecurrente : frmDialogoBase, IImprimirGastoRecurrenteVista
    {
        private ImprimirGastoRecurrentePresentador imprimirPorDireccionPresentador;

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

        public string codReporte
        {
            set
            {
                lueReporte.EditValue = value;
            }
            get { return Convert.ToString(lueReporte.EditValue); }
        }

        public frmImprimirGastoRecurrente(GastoRecurrente gastoRecurrente)
        {
            InitializeComponent();
            this.imprimirPorDireccionPresentador = new ImprimirGastoRecurrentePresentador(gastoRecurrente, this);
            Text = "Gastos Recurrente General";
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