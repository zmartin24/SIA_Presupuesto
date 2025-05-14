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
using SIA_Presupuesto.WinForm.Mantenimiento.Vista;
using SIA_Presupuesto.WinForm.Mantenimiento.Presentador;
using SIA_Presupuesto.WinForm.General.Helper;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.Mantenimiento.Recursos;


namespace SIA_Presupuesto.WinForm.Mantenimiento.Dialogo
{
    public partial class frmFuenteFinanciamiento : frmDialogoBase, IFuenteFinanciamientoVista
    {
        private FuenteFinanciamientoPresentador fuenteFinanciamientoPresentador;

        public string fuente
        {
            set { txtFuente.EditValue = value; }
            get { return txtFuente.Text; }
        }
        public string codigo
        {
            set { txtCodigo.EditValue = value; }
            get { return txtCodigo.Text; }
        }
        public string rubro
        {
            set { txtRubro.EditValue = value; }
            get { return txtRubro.Text; }
        }
        public string desRubro
        {
            set { txtDesRubro.EditValue = value; }
            get { return txtDesRubro.Text; }
        }
       
        public frmFuenteFinanciamiento(FuenteFinanciamiento fuenteFinanciamiento, Form padre) : base(padre, true)
        {
            InitializeComponent();
            this.esModificacion = fuenteFinanciamiento != null;
            fuenteFinanciamientoPresentador = new FuenteFinanciamientoPresentador(fuenteFinanciamiento, this);
            Text = fuenteFinanciamiento != null ? "Modificación de Fuente Financiamiento - " + fuenteFinanciamiento.desRubro : "Registro de Fuente Financiamiento";
        }

        protected override void InicializarValidacion()
        {
            dxProveedorValidador.SetValidationRule(txtFuente, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(txtCodigo, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(txtRubro, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(txtDesRubro, ValidacionHelper.ReglaNoDebeSerVacio);
        }
        protected override void InicializarDatos()
        {
            fuenteFinanciamientoPresentador.IniciarDatos();
        }
        protected override void GuardarDatos()
        {
            if (fuenteFinanciamientoPresentador.GuardarDatos())
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
    }
}
