using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SIA_Presupuesto.WinForm.General.Base;
using SIA_Presupuesto.WinForm.Programacion.Vista;
using SIA_Presupuesto.WinForm.Programacion.Presentador;
using SIA_Presupuesto.WinForm.General.Helper;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.Programacion.Recursos;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using DevExpress.XtraEditors;

namespace SIA_Presupuesto.WinForm.Programacion.Dialogo
{
    public partial class frmProgramacionAnualGeneral : frmDialogoBase, IProgramacionAnualGeneralVista
    {
        private ProgramacionAnualGeneralPresentador programacionAnualGeneralPresentador;

        public List<GrupoPresupuesto> listaGrupoPresupuesto
        {
            set
            {
                glueGruPre.Properties.DataSource = value;
            }
        }
        public List<Moneda> listaMonedas
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueMoneda.Properties, "idMoneda", "descripcion", "Monedas", value);
            }
        }
        public List<FuenteFinanciamiento> listaFuenteFinan
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueFuenteFinan.Properties, "idFueFin", "fuente", "Fuente de Financiamiento", value);
            }
        }
        public List<Predeterminado> listaTipos
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueTipo.Properties, "codigo", "descripcion", "Tipos", value);
            }
        }
        public List<Predeterminado> listaNroTransferencia
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueNroTransferencia.Properties, "codigo", "descripcion", "Nro. Transferencia", value);
            }
        }        
        public List<TipoActividad> listaTipoActividad
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueTipoActividad.Properties, "idTipoActividad", "nombre", "Tipo Actividad", value);
            }
        }
        public List<PoaVersionPoco> listaPoa
        {
            set
            {
                gluePoa.Properties.DataSource = value;
            }
        }


        public int idGruPre
        {
            set { glueGruPre.EditValue = value; }
            get { return glueGruPre.EditValue != null ? Convert.ToInt32(glueGruPre.EditValue) : 0; }
        }
        public int idFueFin
        {
            set { lueFuenteFinan.EditValue = value; }
            get { return Convert.ToInt32(lueFuenteFinan.EditValue); }
        }
        public int idMoneda
        {
            set { lueMoneda.EditValue = value; }
            get { return Convert.ToInt32(lueMoneda.EditValue); }
        }
        public string codTipo
        {
            set { lueTipo.EditValue = value; }
            get { return Convert.ToString(lueTipo.EditValue); }
        }
        public int anio
        {
            set { seAnio.EditValue = value; }
            get { return Convert.ToInt32(seAnio.EditValue); }
        }
        public string descripcion
        {
            set { txtDescripcion.EditValue = value; }
            get { return txtDescripcion.Text; }
        }
        public string titulo
        {
            set { txtTitulo.EditValue = value; }
            get { return txtTitulo.Text; }
        }
        public bool esSaldo
        {
            set { chkEsSaldo.EditValue = value; }
            get { return Convert.ToBoolean(chkEsSaldo.EditValue); }
        }
        public DateTime fechaEmision
        {
            set { deFechaEmision.EditValue = value; }
            get { return Convert.ToDateTime(deFechaEmision.EditValue); }
        }

        //Operativos de erradicación
        public Nullable<int> idPoaVersion
        {
            set { gluePoa.EditValue = value; }
            get
            {
                Nullable<int> i = null;
                return gluePoa.EditValue != null ? Convert.ToInt32(gluePoa.EditValue) : i;
            }
        }
        public Nullable<int> idNroTransferencia
        {
            set { lueNroTransferencia.EditValue = value.ToString(); }
            get
            {
                Nullable<int> i = null;
                return lueNroTransferencia.EditValue != null ? Convert.ToInt32(lueNroTransferencia.EditValue) : i;
            }
        }

        public Nullable<int> idTipoActividad
        {
            set { lueTipoActividad.EditValue = value; }
            get
            {
                Nullable<int> i = null;
                return lueTipoActividad.EditValue != null ? Convert.ToInt32(lueTipoActividad.EditValue) : i;
            }
        }

        public Nullable<int> metaHa
        {
            set { seMetaHa.EditValue = value; }
            get { return Convert.ToInt32(seMetaHa.EditValue); }
        }

        public Nullable<decimal> costoHa
        {
            set { seCostoHa.EditValue = value; }
            get { return Convert.ToDecimal(seCostoHa.EditValue); }
        }

        public string denominacion
        {
            set { txtDenominacion.EditValue = value; }
            get { return txtDenominacion.Text; }
        }

        public string observacion
        {
            set { txtObservacion.EditValue = value; }
            get { return txtObservacion.Text; }
        }

        private List<ProgramacionSedeLaboralPoco> lista;
        public List<ProgramacionSedeLaboralPoco> listaSedes
        {
            set { lista = value; }
            get { return lista; }
        }

        private List<ProgramacionEjeOperativoPoco> listaEje;
        public List<ProgramacionEjeOperativoPoco> listaEjeOperativos
        {
            set { listaEje = value; }
            get { return listaEje; }
        }

        private ProgramacionAnual programacionAnual;
        public frmProgramacionAnualGeneral(ProgramacionAnual ProgramacionAnual, Form padre) : base(padre, true)
        {
            InitializeComponent();
            this.esModificacion = ProgramacionAnual != null;
            this.programacionAnual = ProgramacionAnual;
            programacionAnualGeneralPresentador = new ProgramacionAnualGeneralPresentador(ProgramacionAnual, this);
            Text = "Presupuesto Anual";
        }

        protected override void InicializarValidacion()
        {
            dxProveedorValidador.SetValidationRule(lueMoneda, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(txtDescripcion, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(deFechaEmision, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(seAnio, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(glueGruPre, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(lueFuenteFinan, ValidacionHelper.ReglaNoDebeSerVacio);
        }

        protected override void InicializarDatos()
        {
            programacionAnualGeneralPresentador.IniciarDatos();
            if (esModificacion) lueMoneda.Enabled = false;
        }

        protected override void GuardarDatos()
        {
            if (programacionAnualGeneralPresentador.GuardarDatos())
            {
                if(this.esModificacion)
                    EmitirMensajeResultado(true, Mensajes.MensajeModificacionSatisfactoria);
                else
                    EmitirMensajeResultado(true, Mensajes.MensajeRegistroSatisfactorio);

                this.DialogResult = DialogResult.OK;
            }
            else
                EmitirMensajeResultado(false, Mensajes.MensajeErrorRegistro);
        }

        private void sbSedes_Click(object sender, EventArgs e)
        {
            int id = programacionAnual != null ? programacionAnual.idProAnu : 0;
            using (frmProgramacionAnualSede frm = new frmProgramacionAnualSede(id, listaSedes))
            {
                frm.ShowDialog();
            }
        }

        private void lueTipo_EditValueChanged(object sender, EventArgs e)
        {
            if (lueTipo.EditValue != null)
            {
                string tipo = lueTipo.EditValue.ToString();
                bool bloquea = tipo.Equals("ER");
                sbEjeOperativo.Enabled = bloquea;
                lueTipoActividad.ReadOnly = !bloquea;
                gluePoa.ReadOnly = !bloquea;
                lueNroTransferencia.ReadOnly = !bloquea;
                txtDenominacion.ReadOnly = !bloquea;
                seMetaHa.ReadOnly = !bloquea;
                seCostoHa.ReadOnly = !bloquea;
                sbSedes.Enabled = bloquea;
            }
        }

        private void sbEjeOperativo_Click(object sender, EventArgs e)
        {
            int id = programacionAnual != null ? programacionAnual.idProAnu : 0;
            using (frmProgramacionAnualEjeOperativo frm = new frmProgramacionAnualEjeOperativo(id, listaEjeOperativos))
            {
                frm.ShowDialog();
            }
        }

        private void seAnio_EditValueChanged(object sender, EventArgs e)
        {
            // 1. Obtener el valor del control
            var control = sender as SpinEdit; // Ajusta según tu tipo de control (SpinEdit, etc.)
            if (control == null) return;

            // 2. Validar que no esté vacío
            if (control.EditValue == null || string.IsNullOrWhiteSpace(control.Text))
            {
                //MessageBox.Show("El año no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EmitirMensajeResultado(true, "El año no puede estar vacío.");
                control.Focus();
                return;
            }

            // 3. Intentar convertir a número (si es TextEdit)
            if (!int.TryParse(control.Text, out int anio))
            {
                //MessageBox.Show("Ingrese un año válido (número).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EmitirMensajeResultado(true, "Ingrese un año válido (número).");
                control.Focus();
                return;
            }

            // 4. Validar rango del año (ej: entre 1900 y 2100)
            int anioPeriodoActivo = programacionAnualGeneralPresentador.anioPeridoAcitvo();
            if (anio < anioPeriodoActivo || anio > 2100)
            {
                EmitirMensajeResultado(true, "El año debe estar entre "+ programacionAnualGeneralPresentador.anioPeridoAcitvo().ToString() + " y 2100.");
                control.Focus();
                return;
            }

            // Si pasa todas las validaciones, el año es válido
            programacionAnualGeneralPresentador.llenarComboPoa();
        }
    }
}