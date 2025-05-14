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
using SIA_Presupuesto.WinForm.Adquisicion.Recursos;


namespace SIA_Presupuesto.WinForm.Adquisicion.Dialogo
{
    public partial class frmGastoRecurrente : frmDialogoBase, IGastoRecurrenteVista
    {
        private GastoRecurrentePresentador gastoRecurrentePresentador;

        public List<Moneda> listaMoneda
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueMoneda.Properties, "idMoneda", "descripcion", "Moneda", value);
            }
        }
        public int anio
        {
            set { seAnio.EditValue = value; }
            get { return Convert.ToInt32(seAnio.EditValue); }
        }

        public string descripcion
        {
            set { txtDescripcion.EditValue = value; }
            get { return txtDescripcion.Text; }
        }

        public int idTipMon
        {
            set { lueMoneda.EditValue = value; }
            get { return (Int32)lueMoneda.EditValue; }
        }
        public decimal tipCam
        {
            set { seTipCam.EditValue = value; }
            get { return (decimal)seTipCam.EditValue; }
        }

        public frmGastoRecurrente(GastoRecurrente gastoRecurrente, Form padre) : base(padre, true)
        {
            InitializeComponent();
            this.esModificacion = gastoRecurrente != null;
            gastoRecurrentePresentador = new GastoRecurrentePresentador(gastoRecurrente, this);
            Text = "Gasto Recurrente";
        }

        protected override void InicializarValidacion()
        {
            dxProveedorValidador.SetValidationRule(txtDescripcion, ValidacionHelper.ReglaNoDebeSerVacio);
           
            dxProveedorValidador.SetValidationRule(seAnio, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(lueMoneda, ValidacionHelper.ReglaNoDebeSerVacio);
        }

        protected override void InicializarDatos()
        {
            gastoRecurrentePresentador.IniciarDatos();
        }

        protected override void GuardarDatos()
        {
            if (gastoRecurrentePresentador.GuardarDatos())
            {
                if (this.esModificacion)
                    EmitirMensajeResultado(true, Mensajes.MensajeModificacionSatisfactoria);
                else
                    EmitirMensajeResultado(true, Mensajes.MensajeRegistroSatisfactorio);

                this.DialogResult = DialogResult.OK;
            }
            else
                EmitirMensajeResultado(false, Mensajes.MensajeErrorRegistro);
        }

        private void lueMoneda_EditValueChanged(object sender, EventArgs e)
        {
            if (idTipMon > 0 && idTipMon == 63)
            {
                seTipCam.ReadOnly = true;
                seTipCam.EditValue = 1;
            }
            else
            {

                seTipCam.ReadOnly = false;
            }
        }
    }
}
