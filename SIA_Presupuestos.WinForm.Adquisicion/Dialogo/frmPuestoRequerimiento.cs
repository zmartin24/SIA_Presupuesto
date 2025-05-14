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

namespace SIA_Presupuesto.WinForm.Adquisicion.Dialogo
{
    public partial class frmPuestoRequerimiento : frmDialogoBase, IPuestoRequerimientoVista
    {
        private PuestoRequerimientoPresentador puestoRequerimientoPresentador;

        public List<TrabajadorPres> listaTrabajador
        {
            set
            {
                glueTrabajador.Properties.DisplayMember = "trabajador";
                glueTrabajador.Properties.ValueMember = "idTrabajador";
                glueTrabajador.Properties.NullText = string.Empty;
                glueTrabajador.Properties.DataSource = value;
            }
        }

        public List<CargoPres> listaCargos
        {
            set
            {
                glueCargo.Properties.DisplayMember = "desCargo";
                glueCargo.Properties.ValueMember = "idCargo";
                glueCargo.Properties.NullText = string.Empty;
                glueCargo.Properties.DataSource = value;
            }
        }

        public List<SedeLaboral> listaSedes
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueSede.Properties, "idSede", "desSede", "Sede", value);
            }
        }

        public List<Moneda> listaMonedas
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueMoneda.Properties, "idMoneda", "descripcion", "Moneda", value);
            }
        }

        public List<DatoRegimenLaboral> listaRegimelLaboral
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueRegLab.Properties, "idRegLab", "descripcion", "Sede", value);
            }
        }

        public List<DatoCategoriaLaboral> listaCategoriaLaboral
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueCatLab.Properties, "idCatLab", "descripcion", "Sede", value);
            }
        }

        public List<DatoCondicionLaboral> listaCondicionLaboral
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueConLab.Properties, "idConLab", "descripcion", "Sede", value);
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
                ElementoHelper.LlenarLookUpEdit(lueAreaLaboral.Properties, "idArea", "desArea", "Areas", value);
            }
        }

        public int idDireccion
        {
            set { lueDireccion.EditValue = value; }
            get { return Convert.ToInt32(lueDireccion.EditValue); }
        }

        public int idSubdireccion
        {
            set { lueSubdireccion.EditValue = value; }
            get { return Convert.ToInt32(lueSubdireccion.EditValue); }
        }

        public int idArea
        {
            set { lueAreaLaboral.EditValue = value; }
            get { return Convert.ToInt32(lueAreaLaboral.EditValue); }
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

        public int idTrabajador
        {
            set { glueTrabajador.EditValue = value; }
            get { return Convert.ToInt32(glueTrabajador.EditValue); }
        }

        public int idCargo
        {
            set { glueCargo.EditValue = value; }
            get { return Convert.ToInt32(glueCargo.EditValue); }
        }

        public int idSede
        {
            set { lueSede.EditValue = value; }
            get { return Convert.ToInt32(lueSede.EditValue); }
        }

        public int idMoneda
        {
            set { lueMoneda.EditValue = value; }
            get { return Convert.ToInt32(lueMoneda.EditValue); }
        }

        public int cantVacante
        {
            set { seCantVac.EditValue = value; }
            get { return Convert.ToInt32(seCantVac.EditValue); }
        }

        public decimal remuneracion
        {
            set { seRemuneracion.EditValue = value; }
            get { return Convert.ToDecimal(seRemuneracion.EditValue); }
        }

        public int grado
        {
            set { seGrado.EditValue = value; }
            get { return Convert.ToInt32(seGrado.EditValue); }
        }

        public bool esVacante
        {
            set { ceEsVacante.Checked = value; }
            get { return ceEsVacante.Checked; }
        }

        public bool esRemDiaria
        {
            set { ceEsRemDiaria.Checked = value; }
            get { return ceEsRemDiaria.Checked; }
        }

        public bool conBonoAlimento
        {
            set { ceBonoAlimento.Checked = value; }
            get { return ceBonoAlimento.Checked; }
        }

        public bool conBonoAlimentoEsp
        {
            set { ceBonoAlimentoEsp.Checked = value; }
            get { return ceBonoAlimentoEsp.Checked; }
        }

        public bool conBonoMovilidad
        {
            set { ceBonoMovilidad.Checked = value; }
            get { return ceBonoMovilidad.Checked; }
        }

        public bool conBonoProductividad
        {
            set { ceBonoProductividad.Checked = value; }
            get { return ceBonoProductividad.Checked; }
        }

        public DateTime fechaInicio
        {
            set { deFechaInicio.EditValue = value; }
            get { return Convert.ToDateTime(deFechaInicio.EditValue); }
        }

        public DateTime fechaTermino
        {
            set { deFechaTermino.EditValue = value; }
            get { return Convert.ToDateTime(deFechaTermino.EditValue); }
        }

        public DateTime fechaMin
        {
            set {
                deFechaInicio.Properties.MinValue = value;
                deFechaTermino.Properties.MinValue = value;
            }
        }

        public DateTime fechaMax
        {
            set
            {
                deFechaInicio.Properties.MaxValue = value;
                deFechaTermino.Properties.MaxValue = value;
            }
        }

        private string vmensaje = string.Empty;

        public frmPuestoRequerimiento(RequerimientoRecursoHumano requerimientoRecursoHumano,  PuestoRequerimiento puestoRequerimiento, Form padre)
            :base(padre, true)
        {
            InitializeComponent();
            Text = "Registro de Puesto Laboral";
            this.puestoRequerimientoPresentador = new PuestoRequerimientoPresentador(requerimientoRecursoHumano, puestoRequerimiento, this);
        }
        

        protected override void InicializarValidacion()
        {
            dxProveedorValidador.SetValidationRule(glueCargo, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(lueMoneda, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(lueSede, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(seGrado, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(seCantVac, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(seRemuneracion, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(lueAreaLaboral, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(deFechaInicio, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(deFechaTermino, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(lueCatLab, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(lueConLab, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(lueRegLab, ValidacionHelper.ReglaNoDebeSerVacio);
            
        }

        protected override bool ValidarDatos()
        {
            bool valida = proveedorValidacion.Validate();
            if (fechaTermino < fechaInicio)
            {
                EmitirMensajeResultado(true, "La fecha de termino debe ser superior a la fecha de inicio");
                valida = false;
            }
            return valida;
        }

        protected override void InicializarDatos()
        {
            puestoRequerimientoPresentador.IniciarDatos();
            if (this.esModificacion)
            {
                //glue.ReadOnly = true;
                //lueTipoValor.ReadOnly = true;
            }
        }
        protected override void GuardarDatos()
        {
            if (validar())
            {
                if (puestoRequerimientoPresentador.GuardarDatos())
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
                EmitirMensajeResultado(true, vmensaje);
                this.DialogResult = DialogResult.No;
            }
        }

        private void ceEsVacante_CheckedChanged(object sender, EventArgs e)
        {
            if(ceEsVacante.Checked)
            {
                glueTrabajador.EditValue = null;
                glueTrabajador.Enabled = false;
                seCantVac.Enabled = true;
                seCantVac.EditValue = 1;
            }
            else
            {
                glueTrabajador.Enabled = true;
                seCantVac.Enabled = false;
                seCantVac.EditValue = 0;
            }
        }

        private void lueDireccion_EditValueChanged(object sender, EventArgs e)
        {
            if(lueDireccion.EditValue != null)
            {
                puestoRequerimientoPresentador.CargarSubdirecciones();
            }
        }

        private void lueSubdireccion_EditValueChanged(object sender, EventArgs e)
        {
            if (lueSubdireccion.EditValue != null)
            {
                puestoRequerimientoPresentador.CargarAreas();
            }
        }

        private bool validar()
        {
            bool res = true;
            if (puestoRequerimientoPresentador.BuscarPorTrabajador() != null)
            {
                res = false;
                vmensaje += "Trabajador ya existe en este requerimiento\n";
            }
            return res;
        }
    }
}