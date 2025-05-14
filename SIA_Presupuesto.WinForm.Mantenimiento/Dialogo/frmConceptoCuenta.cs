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
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;

namespace SIA_Presupuesto.WinForm.Mantenimiento.Dialogo
{
    public partial class frmConceptoCuenta : frmDialogoBase, IConceptoCuentaVista
    {
        private ConceptoCuentaPresentador conceptoCuentaPresentador;

        public List<DatoRegimenLaboral> listaRegimen
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueRegLab.Properties, "idRegLab", "descripcion", "Regimen Laboral", value);
            }
        }

        public List<DatoCategoriaLaboral> listaCategoria
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueCatLab.Properties, "idCatLab", "descripcion", "Categoria Laboral", value);
            }
        }

        public List<DatoCondicionLaboral> listaCondicion
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueConLab.Properties, "idConLab", "descripcion", "Condición Laboral", value);
            }
        }

        public List<ConceptoPresupuestoRemuneracion> listaConceptos
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueConcepto.Properties, "idConPreRem", "descripcion", "Concepto", value);
            }
        }

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

        public int idConPreRem
        {
            set { lueConcepto.EditValue = value; }
            get { return Convert.ToInt32(lueConcepto.EditValue); }
        }

        public string numCuenta
        {
            get { return glueCuenta.Text; }
        }

        public int idRegLab
        {
            set { lueRegLab.EditValue = value; }
            get { return Convert.ToInt32(lueRegLab.EditValue); }
        }

        public int idConLab
        {
            set { lueConLab.EditValue = value; }
            get { return Convert.ToInt32(lueConLab.EditValue); }
        }

        public int idCatLab
        {
            set { lueCatLab.EditValue = value; }
            get { return Convert.ToInt32(lueCatLab.EditValue); }
        }

        public int idCueCon
        {
            set { glueCuenta.EditValue = value; }
            get { return Convert.ToInt32(glueCuenta.EditValue); }
        }

        public frmConceptoCuenta(ConceptoPresupuestoRemuneracion concepto, ConceptoCuentaContable cuenta, UsuarioOperacion UsuarioOperacion, Form padre) 
            : base(padre, true)
        {
            InitializeComponent();
            this.esModificacion = cuenta != null;
            this.conceptoCuentaPresentador = new ConceptoCuentaPresentador(concepto, cuenta, UsuarioOperacion, this);
            Text = cuenta != null ? "Modificación de Cuenta - " + cuenta.numCuenta : "Registro de Cuenta";
        }

        protected override void InicializarValidacion()
        {
            dxProveedorValidador.SetValidationRule(lueConcepto, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(lueCatLab, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(lueConLab, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(lueRegLab, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(glueCuenta, ValidacionHelper.ReglaNoDebeSerVacio);
        }
        protected override void InicializarDatos()
        {
            conceptoCuentaPresentador.IniciarDatos();
            lueConcepto.ReadOnly = true;
            //if (this.esModificacion)
            //{
            //    lueTipo.ReadOnly = true;
            //}
        }
        protected override void GuardarDatos()
        {
            if (conceptoCuentaPresentador.GuardarDatos())
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