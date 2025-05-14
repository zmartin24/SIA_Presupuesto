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
    public partial class frmTipoCambioAnual : frmDialogoBase, ITipoCambioAnualVista
    {
        private TipoCambioAnualPresentador tipoCambioAnualPresentador;
        public List<Moneda> listaMoneda
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueMoneda.Properties, "idMoneda", "descripcion", "Moneda", value);
            }
        }
        
        public int idMoneda
        {
            set { lueMoneda.EditValue = value; }
            get { return lueMoneda.EditValue != null ? Convert.ToInt32(lueMoneda.EditValue) : 64; }
        }
        public int anio
        {
            set { seAnio.EditValue = value; }
            get { return seAnio.EditValue != null ? Convert.ToInt32(seAnio.EditValue) : 1; }
        }
        
        public decimal valor
        {
            set { seValor.EditValue = value; }
            get { return Convert.ToDecimal(seValor.EditValue); }
        }
       
        public frmTipoCambioAnual(TipoCambioAnual tipoCambioAnual, Form padre) : base(padre, true)
        {
            InitializeComponent();
            this.esModificacion = tipoCambioAnual != null;
            tipoCambioAnualPresentador = new TipoCambioAnualPresentador(tipoCambioAnual, this);
            Text = tipoCambioAnual != null ? "Modificación de Tipo de Cambio del - " + tipoCambioAnual.anio.ToString() : "Registro de Tipo de Cambio Anual";
            lciAnio.Enabled = !this.esModificacion;
        }

        protected override void InicializarValidacion()
        {
            dxProveedorValidador.SetValidationRule(lueMoneda, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(seAnio, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(seValor, ValidacionHelper.ReglaNoDebeSerVacio);
        }
        protected override void InicializarDatos()
        {
            tipoCambioAnualPresentador.IniciarDatos();
        }
        protected override void GuardarDatos()
        {
            //int count = lueMes.Properties.DataSource == null ? 0 : ((IList)lueMes.Properties.DataSource).Count;
            
            //if (count>0)
            //{
                if (tipoCambioAnualPresentador.GuardarDatos())
                {
                    if (this.esModificacion)
                        EmitirMensajeResultado(true, Mensajes.MensajeModificacionSatisfactoria);
                    else
                        EmitirMensajeResultado(true, Mensajes.MensajeRegistroSatisfactorio);

                    this.DialogResult = DialogResult.OK;
                }
                else
                    EmitirMensajeResultado(false, Mensajes.MensajeErrorRegistro);
            //}
            //else
            //    EmitirMensajeResultado(false, "Ningún mes seleccionado");
        }
        private void seAnio_EditValueChanged(object sender, EventArgs e)
        {
            //if (seAnio != null)
            //    tipoCambioPresupuestoPresentador.llenarComboMeses();
        }
    }
}
