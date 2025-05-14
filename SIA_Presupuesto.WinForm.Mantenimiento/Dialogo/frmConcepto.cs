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
    public partial class frmConcepto : frmDialogoBase, IConceptoVista
    {
        private ConceptoPresentador conceptoPresentador;

        public string descripcion
        {
            set { txtDescripcion.EditValue = value; }
            get { return txtDescripcion.Text; }
        }

        public List<OrigenConcepto> listaOrigenes
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueOrigen.Properties, "idOriCon", "descripcion", "Origenes", value);
            }
        }

        public List<Predeterminado> listaTipo
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueTipo.Properties, "codigo", "descripcion", "Tipos", value);
            }
        }

        public int idOriCon
        {
            set { lueOrigen.EditValue = value; }
            get { return Convert.ToInt32(lueOrigen.EditValue); }
        }

        public string tipo
        {
            set { lueTipo.EditValue = value; }
            get { return Convert.ToString(lueTipo.EditValue); }
        }

        public string abreviatura
        {
            set { txtAbreviatura.EditValue = value; }
            get { return txtAbreviatura.Text; }
        }

        public frmConcepto(ConceptoPresupuestoRemuneracion conceptoPresupuestoRemuneracion, Form padre) : base(padre, true)
        {
            InitializeComponent();
            this.esModificacion = conceptoPresupuestoRemuneracion != null;
            conceptoPresentador = new ConceptoPresentador(conceptoPresupuestoRemuneracion, this);
            Text = conceptoPresupuestoRemuneracion != null ? "Modificación de Concepto - " + conceptoPresupuestoRemuneracion.descripcion : "Registro de Concepto";
        }

        protected override void InicializarValidacion()
        {
            dxProveedorValidador.SetValidationRule(txtDescripcion, ValidacionHelper.ReglaNoDebeSerVacio);
        }
        protected override void InicializarDatos()
        {
            conceptoPresentador.IniciarDatos();
            if(this.esModificacion)
            {
                lueTipo.ReadOnly = true;
            }
        }
        protected override void GuardarDatos()
        {
            if (conceptoPresentador.GuardarDatos())
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
