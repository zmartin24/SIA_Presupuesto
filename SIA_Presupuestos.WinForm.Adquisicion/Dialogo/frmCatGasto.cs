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
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;

namespace SIA_Presupuesto.WinForm.Adquisicion.Dialogo
{
    public partial class frmCatGasto : frmDialogoBase, IRubroBienServicioVista
    {
        private RubroBienServicioPresentador gastoRecurrentePresentador;

      

        public frmCatGasto(RubroBienServicioPoco rubroBienServicio, Form padre) : base(padre, true)
        {
            InitializeComponent();
            this.esModificacion = rubroBienServicio != null;
            gastoRecurrentePresentador = new RubroBienServicioPresentador(rubroBienServicio, this);
            Text = (rubroBienServicio != null)?"Modificar Categoría Gasto Recurrente" : "Nueva Categoría Gasto Recurrente";
        }

        public string descripcion
        {
            set { txtDescripcion.EditValue = value; }
            get { return txtDescripcion.Text; }
        }

        public int idRubBieSer
        {
            get;set;
        }

        protected override void InicializarValidacion()
        {
            dxProveedorValidador.SetValidationRule(txtDescripcion, ValidacionHelper.ReglaNoDebeSerVacio);
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
    }
}
