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
using SIA_Presupuesto.WinForm.Programacion.Helper;

namespace SIA_Presupuesto.WinForm.Programacion.Dialogo
{
    public partial class frmGrupoPresupuesto : frmDialogoBase, IGrupoPresupuestoVista
    {
        private GrupoPresupuestoPresentador grupoPresupuestoPresentador;
        private GrupoPresupuestoPoco GrupoPresupuesto;

        public frmGrupoPresupuesto(GrupoPresupuestoPoco GrupoPresupuesto, Form padre) : base(padre, true)
        {
            InitializeComponent();
            this.GrupoPresupuesto = GrupoPresupuesto;
            this.Text = (GrupoPresupuesto != null) ? "Editar Grupo Presupuesto" : "Registrar Grupo Presupuesto";
            this.grupoPresupuestoPresentador = new GrupoPresupuestoPresentador(GrupoPresupuesto, this);
            this.esModificacion = GrupoPresupuesto != null;
            txtCodigo.Properties.MaxLength = 2;
        }

        protected override void InicializarValidacion()
        {
            dxProveedorValidador.SetValidationRule(lueAgrupamiento, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(cboFuenteFinanciamiento, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(txtCodigo, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(txtDescripcion, ValidacionHelper.ReglaNoDebeSerVacio);
        }

        public string abreviatura
        {
            set { txtAbreviatura.EditValue = value; }
            get { return txtAbreviatura.Text; }
        }

        public string codigo
        {
            set { txtCodigo.EditValue = value; }
            get { return txtCodigo.Text; }
        }

        public string descripcion
        {
            set { txtDescripcion.EditValue = value; }
            get { return txtDescripcion.Text; }
        }

        public bool esEncargo
        {
            set { chkEsEncargo.EditValue = value; }
            get { return Convert.ToBoolean(chkEsEncargo.EditValue); }
        }

        public string agrupamiento
        {
            set { lueAgrupamiento.EditValue = value; }
            get { return Convert.ToString(lueAgrupamiento.EditValue); }
        }

        public List<Predeterminado> listaAgrupamiento
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueAgrupamiento.Properties, "codigo", "descripcion", "Agrupamiento CORAH", value);
            }
        }

        public int estado
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

        public DateTime fechaCrea
        {
            get; set;
        }

        public DateTime fechaEdita
        {
            get; set;
        }

        public int idGruPre
        {
            get; set;
        }

        public string observacion
        {
            set { txtObservacion.EditValue = value; }
            get { return txtObservacion.Text; }
        }

        public string usuCrea
        {
            get;set;
        }

        public string usuEdita
        {
            get; set;
        }

        public List<FuenteFinanciamiento> listaFuente
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(cboFuenteFinanciamiento.Properties, "idFueFin", "fuente", "Fuente Financiamiento", value);
            }
        }

        public int idFuenteFinanciamiento
        {
            set { cboFuenteFinanciamiento.EditValue = value; }
            get { return (Int32)cboFuenteFinanciamiento.EditValue; }
        }

        protected override void InicializarDatos()
        {
            grupoPresupuestoPresentador.IniciarDatos();
        }

        protected override void GuardarDatos()
        {
            if (grupoPresupuestoPresentador.GuardarDatos())
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
