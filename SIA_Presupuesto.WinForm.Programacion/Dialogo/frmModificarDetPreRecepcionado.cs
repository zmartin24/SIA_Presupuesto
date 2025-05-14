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
using SIA_Presupuesto.WinForm.Programacion.Vista;
using SIA_Presupuesto.WinForm.General.Base;
using SIA_Presupuesto.WinForm.Programacion.Presentador;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Helper;
using SIA_Presupuesto.WinForm.Programacion.Recursos;
using Utilitario.Util;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;

namespace SIA_Presupuesto.WinForm.Programacion.Dialogo
{
    public partial class frmModificarDetPreRecepcionado : frmDialogoBase, IPresupuestoRecepcionadoVista
    {
        private PresupuestoRecepcionadoPresentador presupuestoRecepcionadoPresentador;

        public frmModificarDetPreRecepcionado(PresupuestoRecepcionadoPoco SubPresupuesto, Form padre) : base(padre, true)
        {
            InitializeComponent();
            this.esModificacion = SubPresupuesto != null;
            presupuestoRecepcionadoPresentador = new PresupuestoRecepcionadoPresentador(SubPresupuesto, this);
            Text = (SubPresupuesto == null) ? "Nuevo Presupuesto Recepcionado" : "Editar Presupuesto Recepcionado";
        }

        protected override void InicializarDatos()
        {
            presupuestoRecepcionadoPresentador.IniciarDatos();
        }

        protected override void InicializarValidacion()
        {
            //dxProveedorValidador.SetValidationRule(cboGrupoPresupuesto, ValidacionHelper.ReglaNoDebeSerVacio);
            //dxProveedorValidador.SetValidationRule(cboPresupuesto, ValidacionHelper.ReglaNoDebeSerVacio);
            //dxProveedorValidador.SetValidationRule(txtPresupuestoMensual, ValidacionHelper.ReglaNoDebeSerVacio);
            //dxProveedorValidador.SetValidationRule(cboAnio, ValidacionHelper.ReglaNoDebeSerVacio);
            //dxProveedorValidador.SetValidationRule(cboGrupoPresupuesto, ValidacionHelper.ReglaNoDebeSerVacio);
            //dxProveedorValidador.SetValidationRule(cboEstado, ValidacionHelper.ReglaNoDebeSerVacio);
        }

        protected override void GuardarDatos()
        {
            if (presupuestoRecepcionadoPresentador.GuardarDatos())
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

        public int anio
        {
            set { txtAnio.EditValue = value; }
            get { return Convert.ToInt32(txtAnio.Text); }
        }

        public string fuenteFinanciamiento
        {
            set { }
        }

        public decimal importe
        {
            set { seImporte.EditValue = value; }
            get { return (decimal)seImporte.EditValue; }
        }

        public List<GrupoPresupuestoPoco> listaGrupoPresupuesto
        {
            set { }
        }

        public string nombreMes
        {
            set { txtMes.EditValue = value; }
            get { return txtMes.Text; }
        }

        public int idPreRec
        {
            get;set;
        }

        public int idGrupoPresupuesto
        {
            get;set;
        }
    }
}
