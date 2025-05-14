using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SIA_Presupuesto.WinForm.General.Base;
using SIA_Presupuesto.WinForm.Programacion.Vista;
using SIA_Presupuesto.WinForm.Programacion.Presentador;
using SIA_Presupuesto.WinForm.General.Helper;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.Programacion.Recursos;
using Utilitario.Util;
using System.Threading;
using SIA_Presupuesto.WinForm.General.Adicional;

namespace SIA_Presupuesto.WinForm.Programacion.Dialogo
{
    public partial class frmReajusteMensualGeneral : frmDialogoBase, IReajusteMensualGeneralVista
    {
        private ReajusteMensualGeneralPresentador reajusteMensualGeneralPresentador;

        public List<Mes> listaMesesReajustes
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueMesReajuste.Properties, "indice", "nombre", "Mes", value);
            }
        }

        public List<ProgramacionAnual> listaProgramacionAnual
        {
            set
            {
                gluePresupuesto.Properties.DataSource = value;
            }
        }

        public List<Anio> listaAnios
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueAnio.Properties, "indice", "nombre", "Años", value);
            }
        }

        public int mesReajuste
        {
            set { lueMesReajuste.EditValue = value; }
            get { return Convert.ToInt32(lueMesReajuste.EditValue); }
        }

        public int idPresAnu
        {
            set { gluePresupuesto.EditValue = value; }
            get { return gluePresupuesto.EditValue != null ? Convert.ToInt32(gluePresupuesto.EditValue) : 0; }
        }
        public int anioPres
        {
            set { lueAnio.EditValue = value; }
            get { return Convert.ToInt32(lueAnio.EditValue); }
        }


        public string descripcion
        {
            set { txtDescripcion.EditValue = value; }
            get { return txtDescripcion.Text; }
        }

        public DateTime fechaEmision
        {
            set { deFechaEmision.EditValue = value; }
            get { return Convert.ToDateTime(deFechaEmision.EditValue); }
        }

        public decimal tipoCambio
        {
            set { seTipoCambio.EditValue = value; }
            get { return Convert.ToDecimal(seTipoCambio.EditValue); }
        }

        public frmReajusteMensualGeneral(ReajusteMensualProgramacion ReajusteMensualProgramacion, Form padre) : base(padre, true)
        {
            InitializeComponent();
            this.esModificacion = ReajusteMensualProgramacion != null;
            reajusteMensualGeneralPresentador = new ReajusteMensualGeneralPresentador(ReajusteMensualProgramacion, this);
            Text = "Modificación (Reajuste) Mensual";
        }

        protected override void InicializarValidacion()
        {
            dxProveedorValidador.SetValidationRule(lueAnio, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(gluePresupuesto, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(txtDescripcion, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(deFechaEmision, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(lueMesReajuste, ValidacionHelper.ReglaNoDebeSerVacio);
        }

        protected override void InicializarDatos()
        {
            reajusteMensualGeneralPresentador.IniciarDatos();
        }

        protected void Guardar()
        {
            if (reajusteMensualGeneralPresentador.GuardarDatos())
            {
                barra.ProgresoCalculo = barra.Cantidad;
                if (this.esModificacion)
                    XtraMessageBox.Show(Mensajes.MensajeModificacionSatisfactoria, Mensajes.Informacion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    XtraMessageBox.Show(Mensajes.MensajeRegistroSatisfactorio, Mensajes.Informacion, MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
            }
            else
            {
                barra.ProgresoCalculo = barra.Cantidad;
                XtraMessageBox.Show(Mensajes.MensajeErrorRegistro, Mensajes.Error, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        BarraProgresoBarHelper barra;
        protected override void GuardarDatos()
        {
            Thread hilo = new Thread(new ThreadStart(this.Guardar));
            hilo.Start();

            while (!hilo.IsAlive) ;

            barra = new BarraProgresoBarHelper
            {
                Mensaje = "Espere mientras se obtienen los datos y se registran...",
                Cantidad = 600 * mesReajuste,
            };

            BarraProgreso BarraProgreso = new BarraProgreso(hilo, barra);
            BarraProgreso.ShowDialog();
            BarraProgreso.Dispose();
        }

        private void lueAnio_EditValueChanged(object sender, EventArgs e)
        {
            reajusteMensualGeneralPresentador.LlenarComboPresupuesto();
        }

        private void NombreEvaluacion()
        {
            if (gluePresupuesto.EditValue != null && lueMesReajuste.EditValue != null)
            {
                descripcion = string.Format("{0} ({1} - {2})", gluePresupuesto.Text, lueMesReajuste.Text.ToUpper(), "DICIEMBRE");
            }
        }

        private void lueMesReajuste_EditValueChanged(object sender, EventArgs e)
        {
            NombreEvaluacion();
        }

        private void luePresAnu_EditValueChanged(object sender, EventArgs e)
        {
            NombreEvaluacion();
        }
    }
}