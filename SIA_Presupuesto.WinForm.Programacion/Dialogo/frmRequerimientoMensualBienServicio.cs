using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SIA_Presupuesto.WinForm.General.Base;
using SIA_Presupuesto.WinForm.Programacion.Vista;
using SIA_Presupuesto.WinForm.Programacion.Presentador;
using SIA_Presupuesto.WinForm.General.Helper;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.Programacion.Recursos;
using Utilitario.Util;
using System.Linq;

namespace SIA_Presupuesto.WinForm.Programacion.Dialogo
{
    public partial class frmRequerimientoMensualBienServicio : frmDialogoBase, IRequerimientoMensualBienServicioVista
    {
        private RequerimientoMensualBienServicioPresentador requerimientoMensualBienServicioPresentador;

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
        
        public List<Predeterminado> listaTipo
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueTipo.Properties, "codigo", "descripcion", "Tipo", value);
            }
        }
        public List<Moneda> listaMonedas
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueMoneda.Properties, "idMoneda", "descripcion", "Monedas", value);
            }
        }
        public List<Anio> listaAnio
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueAnio.Properties, "indice", "nombre", "Años", value);
            }
        }
        public List<Mes> listaMes
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueMes.Properties, "indice", "nombre", "Meses", value);
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
            set { lueArea.EditValue = value; }
            get { return Convert.ToInt32(lueArea.EditValue); }
        }

        public int tipo
        {
            set { lueTipo.EditValue = value; }
            get { return Convert.ToInt32(lueTipo.EditValue); }
        }
        public string descripcion
        {
            set { txtDescripcion.EditValue = value; }
            get { return txtDescripcion.Text; }
        }
        public int idMoneda
        {
            set { lueMoneda.EditValue = value; }
            get { return Convert.ToInt32(lueMoneda.EditValue); }
        }
        public int anio
        {
            set { lueAnio.EditValue = value; }
            get { return lueAnio.EditValue != null ? Convert.ToInt32(lueAnio.EditValue) : 0; }
        }
        public int mes
        {
            set { lueMes.EditValue = value; }
            get { return Convert.ToInt32(lueMes.EditValue); }
        }

        public DateTime fechaEmision
        {
            set { deFechaEmision.EditValue = value; }
            get { return Convert.ToDateTime(deFechaEmision.EditValue); }
        }
        RequerimientoMensualBienServicio requerimientoMensualBienServicio;
        public frmRequerimientoMensualBienServicio(RequerimientoMensualBienServicio requerimientoMensualBienServicio, Form padre) : base(padre, true)
        {
            InitializeComponent();
            this.esModificacion = requerimientoMensualBienServicio != null;
            requerimientoMensualBienServicioPresentador = new RequerimientoMensualBienServicioPresentador(requerimientoMensualBienServicio, this);
            Text = requerimientoMensualBienServicio == null ? "Registro de Requerimiento Mensual " : "Editar Requerimiento Mensual "+ "(Bien - Servicio)";
            this.requerimientoMensualBienServicio = requerimientoMensualBienServicio;
        }

        protected override void InicializarValidacion()
        {
            dxProveedorValidador.SetValidationRule(lueMoneda, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(txtDescripcion, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(deFechaEmision, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(lueArea, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(lueAnio, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(lueMes, ValidacionHelper.ReglaNoDebeSerVacio);
        }

        protected override void InicializarDatos()
        {
            requerimientoMensualBienServicioPresentador.IniciarDatos();
            if (this.requerimientoMensualBienServicioPresentador.TraerListarDetallesTodos(this.requerimientoMensualBienServicio != null ? this.requerimientoMensualBienServicio.idReqMenBieSer : 0).Count > 0)
            {
                lueTipo.ReadOnly = true;
                lueMoneda.ReadOnly = true;
            }
        }

        protected override void GuardarDatos()
        {
            if (requerimientoMensualBienServicioPresentador.GuardarDatos())
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
                this.requerimientoMensualBienServicioPresentador.LlenarCombosSubdireccion(Convert.ToInt32(lueDireccion.EditValue));
                lueSubdireccion.EditValue = null;
                lueArea.EditValue = null;
            }
        }

        private void lueSubdireccion_EditValueChanged(object sender, EventArgs e)
        {
            if (lueSubdireccion.EditValue != null)
            {
                this.requerimientoMensualBienServicioPresentador.LlenarCombosAreas(Convert.ToInt32(lueSubdireccion.EditValue));
                lueArea.EditValue = null;
            }
        }
    }
}