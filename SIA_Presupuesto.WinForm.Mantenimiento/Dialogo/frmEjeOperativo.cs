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
    public partial class frmEjeOperativo : frmDialogoBase, IEjeOperativoVista
    {
        private EjeOperativoPresentador ejeOperativoPresentador;

        public string descripcion
        {
            set { txtDescripcion.EditValue = value; }
            get { return txtDescripcion.Text; }
        }
        
        public frmEjeOperativo(EjeOperativo ejeOperativo, Form padre) : base(padre, true)
        {
            InitializeComponent();
            this.esModificacion = ejeOperativo != null;
            ejeOperativoPresentador = new EjeOperativoPresentador(ejeOperativo, this);
            Text = ejeOperativo != null ? "Modificación de Eje Operativo - " + ejeOperativo.descripcion : "Registro de Eje Operativo";
        }

        protected override void InicializarValidacion()
        {
            dxProveedorValidador.SetValidationRule(txtDescripcion, ValidacionHelper.ReglaNoDebeSerVacio);
        }
        protected override void InicializarDatos()
        {
            ejeOperativoPresentador.IniciarDatos();
        }
        protected override void GuardarDatos()
        {
            if (ejeOperativoPresentador.GuardarDatos())
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
