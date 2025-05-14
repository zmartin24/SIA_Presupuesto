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
using SIA_Presupuesto.WinForm.Adquisicion.Helper;

namespace SIA_Presupuesto.WinForm.Adquisicion.Dialogo
{
    public partial class frmRequerimientoRecursoHumano : frmDialogoBase, IRequerimientoRecursoHumanoVista
    {
        private RequerimientoRecursoHumanoPresentador requerimientoRecursoHumanoPresentador;

        public List<Moneda> listaMonedas
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueMoneda.Properties, "idMoneda", "descripcion", "Monedas", value);
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

        public int idMoneda
        {
            set { lueMoneda.EditValue = value; }
            get { return Convert.ToInt32(lueMoneda.EditValue); }
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

        public DateTime fechaEmision
        {
            set { deFechaEmision.EditValue = value; }
            get { return Convert.ToDateTime(deFechaEmision.EditValue); }
        }

        public frmRequerimientoRecursoHumano(RequerimientoRecursoHumano requerimientoRecursoHumano, Form padre) : base(padre, true)
        {
            InitializeComponent();
            this.esModificacion = requerimientoRecursoHumano != null;
            requerimientoRecursoHumanoPresentador = new RequerimientoRecursoHumanoPresentador(requerimientoRecursoHumano, this);
            Text = "Requerimiento Recurso Humano";
        }

        protected override void InicializarValidacion()
        {
            dxProveedorValidador.SetValidationRule(lueMoneda, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(txtDescripcion, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(deFechaEmision, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(lueArea, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(seAnio, ValidacionHelper.ReglaNoDebeSerVacio);
        }

        protected override void InicializarDatos()
        {
            requerimientoRecursoHumanoPresentador.IniciarDatos();
        }

        protected override void GuardarDatos()
        {
            if (requerimientoRecursoHumanoPresentador.GuardarDatos())
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

        private void lueDireccion_EditValueChanged(object sender, EventArgs e)
        {
            if (lueDireccion.EditValue != null)
            {
                this.requerimientoRecursoHumanoPresentador.LlenarCombosSubdireccion(Convert.ToInt32(lueDireccion.EditValue));
                lueSubdireccion.EditValue = null;
                lueArea.EditValue = null;
            }
        }

        private void lueSubdireccion_EditValueChanged(object sender, EventArgs e)
        {
            if (lueSubdireccion.EditValue != null)
            {
                this.requerimientoRecursoHumanoPresentador.LlenarCombosAreas(Convert.ToInt32(lueSubdireccion.EditValue));
                lueArea.EditValue = null;
            }
        }
    }
}