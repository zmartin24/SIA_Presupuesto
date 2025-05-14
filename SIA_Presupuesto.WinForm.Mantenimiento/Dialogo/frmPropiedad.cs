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
using SIA_Presupuesto.WinForm.General.Helper;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.Mantenimiento.Recursos;
using SIA_Presupuesto.WinForm.Mantenimiento.Presentador;

namespace SIA_Presupuesto.WinForm.Mantenimiento.Dialogo
{
    public partial class frmPropiedad : frmDialogoBase, IPropiedadVista
    {
        private PropiedadPresentador PropiedadPresentador;
        public List<ConceptoPresupuestoRemuneracion> listaConceptos
        {
            set
            {
                glueConcepto.Properties.DisplayMember = "descripcion";
                glueConcepto.Properties.ValueMember = "idConPreRem";
                glueConcepto.Properties.NullText = string.Empty;
                glueConcepto.Properties.DataSource = value;
            }
        }

        public List<Predeterminado> listaTipoValor
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueTipoValor.Properties, "codigo", "descripcion", "Origenes", value);
            }
        }

        public int idConPreRem
        {
            set { glueConcepto.EditValue = value; }
            get { return Convert.ToInt32(glueConcepto.EditValue); }
        }

        public string tipoValor
        {
            set { lueTipoValor.EditValue = value; }
            get { return Convert.ToString(lueTipoValor.EditValue); }
        }

        public string valor
        {
            set { txtValor.EditValue = value; }
            get { return Convert.ToString(txtValor.EditValue); }
        }

        public string visualiza
        {
            set { rgVisualiza.EditValue = value; }
            get { return Convert.ToString(rgVisualiza.EditValue); }
        }

        public int orden
        {
            set { seOrden.EditValue = value; }
            get { return Convert.ToInt32(seOrden.EditValue); }
        }

        private PropiedadPresupuestoRemuneracion propiedad;
        public frmPropiedad(PropiedadPresupuestoRemuneracion propiedad, EstructuraPresupuestoRemuneracion estructura, Form form) : base(form, true)
        {
            InitializeComponent();
            Text = "Propiedades";
            this.esModificacion = propiedad != null;
            this.propiedad = propiedad;
            this.PropiedadPresentador = new PropiedadPresentador(this.propiedad, estructura, this);
        }

        protected override void InicializarValidacion()
        {
            dxProveedorValidador.SetValidationRule(glueConcepto, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(lueTipoValor, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(txtValor, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(seOrden, ValidacionHelper.ReglaNoDebeSerVacio);
        }

        protected override void InicializarDatos()
        {
            PropiedadPresentador.IniciarDatos();
            if (this.esModificacion)
            {
                glueConcepto.ReadOnly = true;
                lueTipoValor.ReadOnly = true;
            }
        }
        protected override void GuardarDatos()
        {
            if (PropiedadPresentador.GuardarDatos())
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

        private void sbAyudaFormula_Click(object sender, EventArgs e)
        {
            var propiedad = PropiedadPresentador.TraerPropiedad();
            using (frmFormula frm = new frmFormula(propiedad))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                    valor = propiedad.valor;
            }
        }

        private void glueConcepto_EditValueChanged(object sender, EventArgs e)
        {
            if(glueConcepto.EditValue!=null)
            {
                var concepto = glueConcepto.GetSelectedDataRow() as ConceptoPresupuestoRemuneracion;
                if(concepto != null)
                {
                    lueTipoValor.EditValue = "FI";
                    txtValor.Text = "0";
                    sbAyudaFormula.Enabled = true;
                    if (concepto.idOriCon != 1)
                    {
                        lueTipoValor.ReadOnly = true;
                    }
                    else
                    {
                        lueTipoValor.ReadOnly = false;
                        txtValor.Text = "";
                    }
                    
                }
                else
                    sbAyudaFormula.Enabled = false;
            }
        }
    }
}