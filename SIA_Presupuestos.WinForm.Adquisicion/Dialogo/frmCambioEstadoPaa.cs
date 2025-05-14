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
using SIA_Presupuesto.WinForm.Programacion.Helper;
using SIA_Presupuesto.WinForm.General.Helper;
using SIA_Presupuesto.WinForm.Adquisicion.Presentador;
using SIA_Presupuesto.WinForm.Adquisicion.Vista;
using SIA_Presupuesto.Negocio.Entidades;

namespace SIA_Presupuesto.WinForm.Adquisicion.Dialogo
{
    public partial class frmCambioEstadoPaa : frmDialogoBase, ICambioEstadoPaaVista
    {
        private CambioEstadoPaaPresentador cambioEstadoPaaPresentador;
        public List<Predeterminado> listaReporte
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueEstado.Properties, "codigo", "descripcion", "Direcciones", value);
            }
        }

        public int codEstado
        {
            set
            {
                lueEstado.EditValue = value.ToString();
            }
            get { return Convert.ToInt32(lueEstado.EditValue); }
        }

        public frmCambioEstadoPaa(PlanAnualAdquisicion planAnualAdquisicion, Form padre):
            base(padre, false)
        {
            InitializeComponent();
            this.cambioEstadoPaaPresentador = new CambioEstadoPaaPresentador(planAnualAdquisicion, this);
            Text = "Cambiar Estado";
        }

        protected override void InicializarValidacion()
        {
            dxProveedorValidador.SetValidationRule(lueEstado, ValidacionHelper.ReglaNoDebeSerVacio);
        }

        protected override void InicializarDatos()
        {
            cambioEstadoPaaPresentador.Inicializar();
        }

        protected override bool ValidarDatos()
        {
            return proveedorValidacion.Validate();
        }

        protected override void GuardarDatos()
        {
            if (cambioEstadoPaaPresentador.Guardar())
            {
                this.DialogResult = DialogResult.OK;
                EmitirMensajeResultado(true, "Se cambió el estado correctamente");
            }
            else
            {
                this.DialogResult = DialogResult.No;
                EmitirMensajeResultado(true, "No se pudo cambiar el estado");
            }

        }
    }
}