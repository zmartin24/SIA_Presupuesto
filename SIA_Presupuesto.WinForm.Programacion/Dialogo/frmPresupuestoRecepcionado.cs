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
using DevExpress.XtraGrid.Views.Base;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;

namespace SIA_Presupuesto.WinForm.Programacion.Dialogo
{
    public partial class frmPresupuestoRecepcionado :  frmDialogoBase, IPresupuestoRecepcionadoVista
    {
        private PresupuestoRecepcionadoPresentador presupuestoRecepcionadoPresentador;

        public frmPresupuestoRecepcionado(PresupuestoRecepcionadoPoco SubPresupuesto, Form padre) : base(padre, true)
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
            dxProveedorValidador.SetValidationRule(cboGrupoPresupuesto, ValidacionHelper.ReglaNoDebeSerVacio);
           
        }

        protected override void GuardarDatos()
        {
            int anio = Convert.ToInt32(spnAnio.EditValue);

            if (anio == 0)
            {
                EmitirMensajeResultado(false, "El Año debe ser mayor a cero.");
                return;
            }

            PresupuestoRecepcionadoPoco oPresupuestoRecepcionado = presupuestoRecepcionadoPresentador.ObtenerGrupoxRegistro(idGrupoPresupuesto, Convert.ToInt32(spnAnio.EditValue));

            if(oPresupuestoRecepcionado == null)
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
            else
            {
                EmitirMensajeResultado(false, "Ya se encuentra registrado el Grupo y el Año correspondiente.");
            }
        }

        public int anio
        {
            set { spnAnio.EditValue = value; }
            get { return Convert.ToInt32(spnAnio.EditValue); }
        }

        public string fuenteFinanciamiento
        {
            set { txtFuenteFinanciamiento.EditValue = value; }
            get { return txtFuenteFinanciamiento.Text; }
        }

        public int idGrupoPresupuesto
        {
            set { cboGrupoPresupuesto.EditValue = value; }
            get { return (Int32)cboGrupoPresupuesto.EditValue; }
        }

        public List<GrupoPresupuestoPoco> listaGrupoPresupuesto
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(cboGrupoPresupuesto.Properties, "idGrupoPresupuesto", "descripcion", "Grupo Presupuesto", value);
            }
        }

        public string nombreMes
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public decimal importe
        {
            get;set;
        }

        public int idPreRec
        {
            get;set;
        }

        private void cboGrupoPresupuesto_EditValueChanged(object sender, EventArgs e)
        {
            presupuestoRecepcionadoPresentador.AsignarFuenteFinanciamiento();
        }
    }
}
