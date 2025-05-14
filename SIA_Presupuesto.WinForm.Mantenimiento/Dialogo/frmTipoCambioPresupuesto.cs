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
using Utilitario.Util;
using System.Collections;

namespace SIA_Presupuesto.WinForm.Mantenimiento.Dialogo
{
    public partial class frmTipoCambioPresupuesto : frmDialogoBase, ITipoCambioPresupuestoVista
    {
        private TipoCambioPresupuestoPresentador tipoCambioPresupuestoPresentador;
        public List<Moneda> listaMoneda
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueMoneda.Properties, "idMoneda", "descripcion", "Moneda", value);
            }
        }
        public List<Mes> listaMes
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueMes.Properties, "indice", "nombre", "Meses", value);
            }
        }

        public int idMoneda
        {
            //set { lueMoneda.EditValue = value.ToString(); }
            //get { return (Int32)lueMoneda.EditValue; }

            set { lueMoneda.EditValue = value; }
            get { return lueMoneda.EditValue != null ? Convert.ToInt32(lueMoneda.EditValue) : 64; }
        }
        public int anio
        {
            //set { seAnio.EditValue = value.ToString(); }
            //get { return Convert.ToInt32(seAnio.EditValue); }

            set { seAnio.EditValue = value; }
            get { return seAnio.EditValue != null ? Convert.ToInt32(seAnio.EditValue) : 1; }
            
        }
        public int mes
        {
            set { lueMes.EditValue = value; }
            get { return (Int32)lueMes.EditValue; }
        }
        public decimal valor
        {
            set { seValor.EditValue = value; }
            get { return Convert.ToDecimal(seValor.EditValue); }
        }
       
        public frmTipoCambioPresupuesto(TipoCambioPresupuesto tipoCambioPresupuesto, Form padre) : base(padre, true)
        {
            InitializeComponent();
            this.esModificacion = tipoCambioPresupuesto != null;
            tipoCambioPresupuestoPresentador = new TipoCambioPresupuestoPresentador(tipoCambioPresupuesto, this);
            Text = tipoCambioPresupuesto != null ? "Modificación de Tipo de Cambio - " + tipoCambioPresupuesto.anio.ToString() : "Registro de Tipo de Cambio";
            lciAnio.Enabled = !this.esModificacion;
        }

        protected override void InicializarValidacion()
        {
            dxProveedorValidador.SetValidationRule(lueMoneda, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(seAnio, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(lueMes, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(seValor, ValidacionHelper.ReglaNoDebeSerVacio);
        }
        protected override void InicializarDatos()
        {
            tipoCambioPresupuestoPresentador.IniciarDatos();
        }
        protected override void GuardarDatos()
        {
            //int count = lueMes.Properties.DropDownRows;
            int count = lueMes.Properties.DataSource == null ? 0 : ((IList)lueMes.Properties.DataSource).Count;
            
            if (count>0)
            {
                if (tipoCambioPresupuestoPresentador.GuardarDatos())
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
            else
                EmitirMensajeResultado(false, "Ningún mes seleccionado");
        }
        private void seAnio_EditValueChanged(object sender, EventArgs e)
        {
            if (seAnio != null)
                tipoCambioPresupuestoPresentador.llenarComboMeses();
        }
    }
}
