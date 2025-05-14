using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SIA_Presupuesto.WinForm.General.Base;
using SIA_Presupuesto.WinForm.Programacion.Vista;
using SIA_Presupuesto.WinForm.Programacion.Presentador;
using SIA_Presupuesto.WinForm.Programacion.Recursos;
using SIA_Presupuesto.WinForm.General.Helper;
using SIA_Presupuesto.Negocio.Entidades;

namespace SIA_Presupuesto.WinForm.Programacion.Dialogo
{
    public partial class frmProgramacionAnualArea : frmDialogoBase, IProgramacionAnualAreaVista
    {
        private ProgramacionAnualAreaPresentador programacionAnualAreaPresentador;

        public List<CuentaContable> listaCuentaContable
        {
            set
            {
                glueCuenta.Properties.DisplayMember = "numCuenta";
                glueCuenta.Properties.ValueMember = "idCueCon";
                glueCuenta.Properties.NullText = string.Empty;
                glueCuenta.Properties.DataSource = value;
            }
        }

        public List<Direccion> listaDirecciones
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueDireccion.Properties, "idDireccion", "desDireccion", "Direcciones", value);
            }
        }

        public List<Subdireccion> listaSubdirecciones
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueSubdireccion.Properties, "idSubdireccion", "desSubdireccion", "Subdirecciones", value);
            }
        }

        public List<Area> listaAreas
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueArea.Properties, "idArea", "desArea", "Areas", value);
            }
        }

        public List<Unidad> listaUnidades
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueUnidad.Properties, "idUnidad", "nomUnidad", "Unidades", value);
            }
        }

        public int idUnidad
        {
            set { lueUnidad.EditValue = value; }
            get { return (Int32)lueUnidad.EditValue; }
        }

        public int idCueCon
        {
            set { glueCuenta.EditValue = value; }
            get { return Convert.ToInt32(glueCuenta.EditValue); }
        }

        public int idDireccion
        {
            set
            {
                lueDireccion.EditValue = value;
            }
            get { return Convert.ToInt32(lueDireccion.EditValue); }
        }

        public int idSubdireccion
        {
            set
            {
                lueSubdireccion.EditValue = value;
            }
            get { return Convert.ToInt32(lueSubdireccion.EditValue); }
        }

        public int idArea
        {
            set { lueArea.EditValue = value; }
            get { return Convert.ToInt32(lueArea.EditValue); }
        }

        private bool esModificacion;
        public frmProgramacionAnualArea(ProgramacionAnual ProgramacionAnual, ProgramacionAnualArea ProgramacionAnualArea, Form padre) : base(padre, false)
        {
            InitializeComponent();
            this.esModificacion = ProgramacionAnualArea != null;
            this.programacionAnualAreaPresentador = new ProgramacionAnualAreaPresentador(ProgramacionAnual, ProgramacionAnualArea, this);

            Text = "Programacion Anual por área";
        }

        protected override void InicializarValidacion()
        {
            dxProveedorValidador.SetValidationRule(lueArea, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(lueDireccion, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(lueSubdireccion, ValidacionHelper.ReglaNoDebeSerVacio);
        }

        protected override void InicializarDatos()
        {
            programacionAnualAreaPresentador.IniciarDatos();
        }

        protected override bool ValidarDatos() {
            bool validar = programacionAnualAreaPresentador.ValidarRegistroExistente();
            if(!validar)
            {
                EmitirMensajeResultado(true, "Ya existe la misma cuenta para la misma área");
            }

            return proveedorValidacion.Validate() && validar;
        }

        protected override void GuardarDatos()
        {
            if (programacionAnualAreaPresentador.GuardarDatos())
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

        private void lueDireccion_EditValueChanged(object sender, EventArgs e)
        {
            if (lueDireccion.EditValue != null)
            {
                this.programacionAnualAreaPresentador.LlenarCombosSubdireccion(Convert.ToInt32(lueDireccion.EditValue));
                lueSubdireccion.EditValue = null;
                lueArea.EditValue = null;
            }
        }

        private void lueSubdireccion_EditValueChanged(object sender, EventArgs e)
        {
            if (lueSubdireccion.EditValue != null)
            {
                this.programacionAnualAreaPresentador.LlenarCombosAreas(Convert.ToInt32(lueSubdireccion.EditValue));
                lueArea.EditValue = null;
            }
        }
    }
}