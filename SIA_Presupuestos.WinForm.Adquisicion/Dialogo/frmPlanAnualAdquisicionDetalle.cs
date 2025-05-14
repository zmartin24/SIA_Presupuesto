using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SIA_Presupuesto.WinForm.Adquisicion.Vista;
using SIA_Presupuesto.WinForm.General.Base;
using SIA_Presupuesto.WinForm.Adquisicion.Presentador;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Helper;
using SIA_Presupuesto.WinForm.Adquisicion.Recursos;
using SIA_Presupuesto.WinForm.General.Ayuda;


namespace SIA_Presupuesto.WinForm.Adquisicion.Dialogo
{
    public partial class frmPlanAnualAdquisicionDetalle : frmDialogoBase, IPlanAnualAdquisicionDetalleVista
    {
        private PlanAnualAdquisicionDetallePresentador planAnualAdquisicionDetallePresentador;

        #region interface
        public List<Unidad> listaUnidades
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueUnidad.Properties, "idUnidad", "nomUnidad", "Unidades", value);
            }
        }
        public List<ConfiguracionPAA> listaTipoCompra
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueTipCom.Properties, "codigo", "descripcion", "Tipo de Compra", value);
            }
        }
        public List<ConfiguracionPAA> listaTipoProceso
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueTipPro.Properties, "codigo", "descripcion", "Tipo de Proceso", value);
            }
        }
        public List<ConfiguracionPAA> listaObjetoProceso
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueObjCon.Properties, "codigo", "descripcion", "Objeto Proceso", value);
            }
        }
        public List<ConfiguracionPAA> listaEncargado
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueEncargado.Properties, "codigo", "descripcion", "Encargado Proceso", value);
            }
        }
        public List<FuenteFinanciamiento> listaFuenteFinanciamiento
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueFueFin.Properties, "idFueFin", "rubro", "Fuente Financiamiento", value);
            }
        }
        public List<Ubigeo> listaRegion
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueRegion.Properties, "idUbigeo", "desUbigeo", "Región", value);
            }
        }
        public List<Ubigeo> listaProvincia
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueProvincia.Properties, "idUbigeo", "desUbigeo", "Provincia", value);
            }
        }
        public List<Ubigeo> listaDistrito
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueDistrito.Properties, "idUbigeo", "desUbigeo", "Distrito", value);
            }
        }
        public List<Moneda> listaMoneda
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueMoneda.Properties, "idMoneda", "descripcion", "Moneda", value);
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
        public List<ConfiguracionPAA> listaMesPrevisto
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueFechaPre.Properties, "codigo", "descripcion", "Fecha Prevista", value);
            }
        }

        public bool itemUnico {
            set { checkItem.EditValue = value; }
            get { return (bool)checkItem.EditValue; }
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
        public int tipComSel
        {
            set { lueTipCom.EditValue = value; }
            get { return (Int32)lueTipCom.EditValue; }
        }
        public int TipPro
        {
            set { lueTipPro.EditValue = value; }
            get { return (Int32)lueTipPro.EditValue; }
        }
        public int objCon
        {
            set { lueObjCon.EditValue = value; }
            get { return (Int32)lueObjCon.EditValue; }
        }
        public bool antecedente
        {
            set { checkAntecedente.EditValue = value; }
            get { return (bool)checkAntecedente.EditValue; }
        }
        public string desAntecedente
        {
            set { txtAntecedente.EditValue = value; }
            get { return txtAntecedente.Text; }
        }
        public string descripcion
        {
            set { txtDescripcion.EditValue = value; }
            get { return txtDescripcion.Text; }
        }
        public decimal precio
        {
            set { sePrecio.EditValue = value; }
            get { return (decimal)sePrecio.EditValue; }
        }
        public int idTipMon
        {
            set { lueMoneda.EditValue = value; }
            get { return (Int32)lueMoneda.EditValue; }
        }
        public decimal tipCam
        {
            set { seTipCam.EditValue = value; }
            get { return (decimal)seTipCam.EditValue; }
        }
        public decimal valorEst
        {
            set { seValEst.EditValue = value; }
            get { return (decimal)seValEst.EditValue; }
        }
        public int idRegion
        {
            set { lueRegion.EditValue = value; }
            get { return (Int32)lueRegion.EditValue; }
        }
        public int idProvincia
        {
            set { lueProvincia.EditValue = value; }
            get { return (Int32)lueProvincia.EditValue; }
        }
        public int idUbigeo
        {
            set { lueDistrito.EditValue = value; }
            get { return (Int32)lueDistrito.EditValue; }
        }
        public int idFueFin
        {
            set { lueFueFin.EditValue = value; }
            get { return (Int32)lueFueFin.EditValue; }
        }
        public string observacion
        {
            set { txtObservacion.EditValue = value; }
            get { return txtObservacion.Text; }
        }
        public int organoEncargado
        {
            set { lueEncargado.EditValue = value; }
            get { return (Int32)lueEncargado.EditValue; }
        }
        public string codBieSer
        {
            set { txtCodBieSer.EditValue = value; }
            get { return txtCodBieSer.Text; }
        }
        public int fechaPrevista
        {
            set { lueFechaPre.EditValue = value; }
            get { return (Int32)lueFechaPre.EditValue; }
        }
        #endregion
        private string numCuenta;
        private string tipo;
        public frmPlanAnualAdquisicionDetalle(string tipo, string numCuenta, PlanAnualAdquisicionRequerimiento planAnualAdquisicionRequerimiento, PlanAnualAdquisicionDetalle planAnualAdquisicionDetalle, Form padre) : base(padre, false)
        {
            InitializeComponent();
            Text = "Detalle - PAAC";
            this.tipo = tipo;
            this.numCuenta = numCuenta;
            this.esModificacion = planAnualAdquisicionDetalle != null;
            this.planAnualAdquisicionDetallePresentador = new PlanAnualAdquisicionDetallePresentador(planAnualAdquisicionRequerimiento, planAnualAdquisicionDetalle, this);
        }

        protected override void InicializarValidacion()
        {
            dxProveedorValidador.SetValidationRule(lueUnidad, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(txtDescripcion, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(lueFueFin, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(seValEst, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(lueMoneda, ValidacionHelper.ReglaNoDebeSerVacio);
        }

        protected override void InicializarDatos()
        {
            planAnualAdquisicionDetallePresentador.IniciarDatos();
        }
        protected override bool ValidarDatos()
        {
            bool validar = planAnualAdquisicionDetallePresentador.ValidarRegistroExistente();
            if (!validar)
            {
                EmitirMensajeResultado(true, "Ya existe un detalle con esa descripción, unidad y precio en esta cuenta");
            }

            return proveedorValidacion.Validate() && validar;
        }

        protected override void GuardarDatos()
        {
            if (planAnualAdquisicionDetallePresentador.GuardarDatos())
            {
                if (!esModificacion)
                    EmitirMensajeResultado(true, Mensajes.MensajeRegistroSatisfactorio);
                else
                    EmitirMensajeResultado(true, Mensajes.MensajeModificacionSatisfactoria);
                this.DialogResult = DialogResult.OK;
            }
            else
                EmitirMensajeResultado(false, Mensajes.MensajeErrorRegistro);
        }

        
        private void seCantidad_EditValueChanged(object sender, EventArgs e)
        {
            planAnualAdquisicionDetallePresentador.ActualizarTotal();
        }

        private void sePrecio_EditValueChanged(object sender, EventArgs e)
        {
            planAnualAdquisicionDetallePresentador.ActualizarTotal();
        }

        private void seDias_EditValueChanged(object sender, EventArgs e)
        {
            planAnualAdquisicionDetallePresentador.ActualizarTotal();
        }

        private void sbAyudaProducto_Click(object sender, EventArgs e)
        {
            using (frmAyudaProducto frm = new frmAyudaProducto(this.numCuenta))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    planAnualAdquisicionDetallePresentador.AsignarProducto(frm.Tag as Producto);
                }
            }
        }

        private void checkAntecedente_CheckedChanged(object sender, EventArgs e)
        {
            if (checkAntecedente.Checked)
            {
                txtAntecedente.ReadOnly = false;
            }
            else
            {
                txtAntecedente.ReadOnly = true;
                txtAntecedente.Text = string.Empty;
            }
        }

        private void lueRegion_EditValueChanged(object sender, EventArgs e)
        {
            if (idRegion > 0 )
            {
                planAnualAdquisicionDetallePresentador.llenarComboProvincia(idRegion);
            }
        }
        private void lueProvincia_EditValueChanged(object sender, EventArgs e)
        {
            if (idProvincia > 0)
            {
                planAnualAdquisicionDetallePresentador.llenarComboDistrito(idProvincia);
            }
        }
    }
}