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
    public partial class frmModalidad : frmDialogoBase, IModalidadVista
    {
        private ModalidadPresentador modalidadPresentador;

        public string descripcion
        {
            set { txtDescripcion.EditValue = value; }
            get { return txtDescripcion.Text; }
        }
        
        public frmModalidad(Modalidad modalidad, Form padre) : base(padre, true)
        {
            InitializeComponent();
            this.esModificacion = modalidad != null;
            modalidadPresentador = new ModalidadPresentador(modalidad, this);
            Text = modalidad != null ? "Modificación de Modalidad - " + modalidad.descripcion : "Registro de Modalidad";
        }

        protected override void InicializarValidacion()
        {
            dxProveedorValidador.SetValidationRule(txtDescripcion, ValidacionHelper.ReglaNoDebeSerVacio);
        }
        protected override void InicializarDatos()
        {
            modalidadPresentador.IniciarDatos();
        }
        protected override void GuardarDatos()
        {
            if (modalidadPresentador.GuardarDatos())
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
