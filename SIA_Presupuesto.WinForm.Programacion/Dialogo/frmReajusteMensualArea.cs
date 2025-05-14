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
    public partial class frmReajusteMensualArea : frmDialogoBase, IReajusteMensualAreaVista
    {
        private ReajusteMensualAreaPresentador reajusteMensualAreaPresentador;

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
        public frmReajusteMensualArea(ReajusteMensualProgramacion ReajusteMensualProgramacion, ReajusteMensualArea ReajusteMensualArea, Form padre) : base(padre, false)
        {
            InitializeComponent();
            this.esModificacion = ReajusteMensualArea != null;
            this.reajusteMensualAreaPresentador = new ReajusteMensualAreaPresentador(ReajusteMensualProgramacion, ReajusteMensualArea, this);
            Text = "Reajuste Mensual por área";
        }

        protected override void InicializarValidacion()
        {
            dxProveedorValidador.SetValidationRule(lueArea, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(lueDireccion, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(lueSubdireccion, ValidacionHelper.ReglaNoDebeSerVacio);
        }
        protected override void InicializarDatos()
        {
            reajusteMensualAreaPresentador.IniciarDatos();
            if (this.esModificacion)
            {
                glueCuenta.ReadOnly = true;
                lueDireccion.ReadOnly = true;
                lueSubdireccion.ReadOnly = true;
                lueArea.ReadOnly = true;
            }
        }

        protected override bool ValidarDatos() {
            bool res = (proveedorValidacion.Validate() && reajusteMensualAreaPresentador.ValidarRegistroExistente());
            if(!res)
                EmitirMensajeResultado(true, "Ya existe una cuenta contable asignado al área seleccionado");

            return res;
        }

        protected override void GuardarDatos()
        {
            if (reajusteMensualAreaPresentador.GuardarDatos())
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
                this.reajusteMensualAreaPresentador.LlenarCombosSubdireccion(Convert.ToInt32(lueDireccion.EditValue));
                lueSubdireccion.EditValue = null;
                lueArea.EditValue = null;
            }
        }

        private void lueSubdireccion_EditValueChanged(object sender, EventArgs e)
        {
            if (lueSubdireccion.EditValue != null)
            {
                this.reajusteMensualAreaPresentador.LlenarCombosAreas(Convert.ToInt32(lueSubdireccion.EditValue));
                lueArea.EditValue = null;
            }
        }
    }
}