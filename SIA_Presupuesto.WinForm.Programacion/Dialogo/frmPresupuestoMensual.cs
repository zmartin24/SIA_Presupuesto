using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SIA_Presupuesto.WinForm.Programacion.Vista;
using SIA_Presupuesto.WinForm.General.Base;
using SIA_Presupuesto.WinForm.Programacion.Presentador;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Helper;
using SIA_Presupuesto.WinForm.Programacion.Recursos;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;

namespace SIA_Presupuesto.WinForm.Programacion.Dialogo
{
    public partial class frmPresupuestoMensual : frmDialogoBase, IPresupuestoMensualVista
    {
        private PresupuestoMensualPresentador presupuestoMensualPresentador;

 
        public frmPresupuestoMensual(SubPresupuestoPoco SubPresupuesto, Form padre) : base(padre, true)
        {
            InitializeComponent();
            this.esModificacion = SubPresupuesto != null;
            presupuestoMensualPresentador = new PresupuestoMensualPresentador(SubPresupuesto, this);
            Text = (SubPresupuesto == null)?"Nuevo Presupuesto Mensual" : "Editar Presupuesto Mensual";
        }

        protected override void InicializarDatos()
        {
            presupuestoMensualPresentador.IniciarDatos();
        }
        protected override bool ValidarDatos()
        {
            bool validar = presupuestoMensualPresentador.ValidarRegistroExistente();
            if (!validar)
            {
                EmitirMensajeResultado(true, "Ya existe el nombre para este presupuesto mensual");
            }

            return proveedorValidacion.Validate() && validar;
        }

        protected override void InicializarValidacion()
        {
            dxProveedorValidador.SetValidationRule(cboGrupoPresupuesto, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(cboPresupuesto, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(txtPresupuestoMensual, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(cboAnio, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(cboMes, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(cboGrupoPresupuesto, ValidacionHelper.ReglaNoDebeSerVacio);
            if(chkEsObra.Checked) dxProveedorValidador.SetValidationRule(cboGrupoPresupuesto, ValidacionHelper.ReglaNoDebeSerVacio);
        }

        protected override void GuardarDatos()
        {
            if (presupuestoMensualPresentador.GuardarDatos())
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

        private void cboGrupoPresupuesto_EditValueChanged(object sender, EventArgs e)
        {
            presupuestoMensualPresentador.LlenarComboPresupuesto(idGruPre);
        }

        private void cboPresupuesto_EditValueChanged(object sender, EventArgs e)
        {
            if(idProAnual!=0)
                presupuestoMensualPresentador.SeleccionarAnio(idProAnual);
        }

        public int anio
        {
            set { cboAnio.EditValue = value; }
            get { return (Int32)cboAnio.EditValue; }
        }

        public string descripcion
        {
            set { txtPresupuestoMensual.EditValue = value; }
            get { return txtPresupuestoMensual.Text; }
        }

        public bool esActividadCampo
        {
            set { chkEsActividadCampo.Checked = value; }
            get { return Convert.ToBoolean(chkEsActividadCampo.EditValue); }
        }

        public bool esEncargo
        {
            set { chkEsEncargo.Checked = value; }
            get { return Convert.ToBoolean(chkEsEncargo.EditValue); }
        }

        public bool esErradicacion
        {
            set { chkEsErradicacion.Checked = value; }
            get { return Convert.ToBoolean(chkEsErradicacion.EditValue); }
        }

        public bool esObra
        {
            set { chkEsObra.Checked = value; }
            get { return Convert.ToBoolean(chkEsObra.EditValue); }
        }

        public int estado
        {
            set { cboEstado.EditValue = value; }
            get { return Convert.ToInt32(cboEstado.EditValue); }
        }

        public int idGruPre
        {
            set { cboGrupoPresupuesto.EditValue = value; }
            get { return Convert.ToInt32(cboGrupoPresupuesto.EditValue); }
        }

        public decimal importe
        {
            set { seImporte.EditValue = value; }
            get { return Convert.ToDecimal(seImporte.EditValue); }
        }

        public List<GrupoPresupuestoPoco> ListaGrupoPresupuesto
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(cboGrupoPresupuesto.Properties, "idGrupoPresupuesto", "descripcion", "Grupo Presupuesto", value);
            }
        }

        public List<ProgramacionAnual> ListaProgramacion
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(cboPresupuesto.Properties, "idProAnu", "descripcion", "Presupuesto", value);
            }
        }

        public int mes
        {
            set { cboMes.EditValue = value; }
            get { return (Int32)cboMes.EditValue; }
        }

        public string nombreCortoPpto
        {
            set { txtAbreviatura.EditValue = value; }
            get { return txtAbreviatura.Text; }
        }

        public List<ItemPoco> ListaAnios
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(cboAnio.Properties, "id", "nombre", "Año", value);
            }
        }

        public List<ItemPoco> ListaMes
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(cboMes.Properties, "id", "nombre", "Mes", value);
            }
        }

        public List<ItemPoco> ListaEstados
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(cboEstado.Properties, "id", "nombre", "Estado", value);
            }
        }

        public int idSubPresupuesto
        {
            get;set;
        }

        public string abreviatura
        {
            set { txtAbreviatura.EditValue = value; }
            get
            {
                return txtAbreviatura.Text;
            }
        }
        public string nroProyecto
        {
            set { txtNroProyecto.EditValue = value; }
            get
            {
                return txtNroProyecto.Text;
            }
        }

        public int idProAnual
        {
            set { cboPresupuesto.EditValue = value; }
            get { return (Int32)cboPresupuesto.EditValue; }
        }

        private void chkEsObra_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEsObra.Checked)
            {
                lciImporte.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lciNroProyecto.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else
            {
                nroProyecto = string.Empty;
                importe = 0;
                lciNroProyecto.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                lciImporte.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }
    }
}
