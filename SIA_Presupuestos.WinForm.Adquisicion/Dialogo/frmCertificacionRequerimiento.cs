using System;
using System.Collections.Generic;
using System.Windows.Forms;

using SIA_Presupuesto.WinForm.General.Base;
using SIA_Presupuesto.WinForm.Adquisicion.Vista;
using SIA_Presupuesto.WinForm.Adquisicion.Presentador;
using SIA_Presupuesto.WinForm.General.Helper;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.Adquisicion.Recursos;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.General.Ayuda;
using SIA_Presupuesto.WinForm.Adquisicion.Controles;
using SIA_Presupuesto.Negocio.Servicios;
using Seguridad.Modelo;
using System.Text.RegularExpressions;

namespace SIA_Presupuesto.WinForm.Adquisicion.Dialogo
{
    public partial class frmCertificacionRequerimiento : frmDialogoBase, ICertificacionRequerimientoVista
    {
        private CertificacionRequerimientoPresentador certificacionRequerimientoPresentador;

        private CertificacionMasterPres certificacionMasterPres;
        private CertificacionRequerimiento certificacionRequerimiento;
        private SeleccionRequerimientoDetalle frmSeleccionReq;

        public List<Predeterminado> listaTipoRequerimiento
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueTipo.Properties, "codigo", "descripcion", "Tipo Requerimiento", value);
            }
        }
        public List<GrupoPresupuestoPoco> ListaGrupoPresupuesto
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueGruPre.Properties, "idGrupoPresupuesto", "descripcion", "Grupo Presupuesto", value);
            }
        }
        public List<ProgramacionAnual> ListaProgramacion
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(luePresupuesto.Properties, "idProAnu", "descripcion", "Presupuesto", value);
            }
        }
        public List<Subpresupuesto> ListaSubpresupuesto
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueSubPresupuesto.Properties, "idSubpresupuesto", "descripcion", "Presupuesto Mensual", value);
            }
        }
        public List<CertificacionDetallePres> ListaDetalle
        {
            set; get;
        }
        public int idTipoReq
        {
            set { lueTipo.EditValue = value.ToString(); }
            get { return Convert.ToInt32(lueTipo.EditValue); }
        }
        public int idGruPre
        {
            set { lueGruPre.EditValue = value; }
            get { return Convert.ToInt32(lueGruPre.EditValue); }
        }
        public int idPresupuesto
        {
            set { luePresupuesto.EditValue = value; }
            get { return Convert.ToInt32(luePresupuesto.EditValue); }
        }
        public int idSubPresupuesto
        {
            set { lueSubPresupuesto.EditValue = value; }
            get { return Convert.ToInt32(lueSubPresupuesto.EditValue); }
        }
        public DateTime fechaEmision
        {
            set { deFecha.EditValue = value; }
            get { return Convert.ToDateTime(deFecha.EditValue); }
        }
        public decimal tipoCambio
        {
            set { seTipoCambio.EditValue = value; }
            get { return Convert.ToDecimal(seTipoCambio.Value); }
        }
        public decimal total
        {
            set;
            get;
        }
        public string detalle
        {
            set { txtDetalle.EditValue = value; }
            get { return txtDetalle.Text; }
        }
        public string observacion
        {
            set { txtObservacion.EditValue = value; }
            get { return txtObservacion.Text; }
        }
        public bool esTotalDetallado
        {
            set { chkEsTotalDetallado.Checked = value; }
            get { return chkEsTotalDetallado.Checked; }
        }
        public SubPresupuestoImporteCertificacion_Pres SubPresupuestoImporteCertificacion
        {
            set;get;
        }
        private tipoAyudaFore tipo;
        
        public CertificacionMasterPres CertificacionMasterPres
        {
            get { return certificacionMasterPres; }
            set
            {
                certificacionMasterPres = value;
                if (value != null)
                {
                    txtReq.Text = value.numeroReq;

                }
                else
                {
                    txtReq.Text = string.Empty;

                }
            }
        }
        public CertificacionRequerimiento CertificacionRequerimiento
        {
            get { return certificacionRequerimiento; }
            set { certificacionRequerimiento = value; }
        }

        public List<ForeDetallePoco> ListaDetallesSeleccionados
        {
            get; set;
        }
        
        public decimal importeMinCer
        {
            set;get;
        }

        public string vmensaje { set; get; }
        public bool esAnual { set; get; }

        public frmCertificacionRequerimiento(CertificacionMasterPres certificacionMasterPres, CertificacionRequerimiento certificacionRequerimiento, Form padre) : base(padre, true)
        {
            InitializeComponent();
            this.esAnual = certificacionMasterPres.tipoReq == 1 ? (bool)certificacionMasterPres.forebi.esAnual : (bool)certificacionMasterPres.forese.esAnual;
            this.esModificacion = certificacionRequerimiento != null;
            certificacionRequerimientoPresentador = new CertificacionRequerimientoPresentador(certificacionMasterPres, certificacionRequerimiento, this);
            ListaDetallesSeleccionados = new List<ForeDetallePoco>();
            if (this.esModificacion)
            {
                this.Root.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                this.Height = 450;
            }
        }

        protected override void InicializarValidacion()
        {
            dxProveedorValidador.SetValidationRule(lueTipo, ValidacionHelper.ReglaNoDebeSerVacio);
            //dxProveedorValidador.SetValidationRule(lueSubPresupuesto, ValidacionHelper.ReglaNoDebeSerVacio);
        }
        protected override void InicializarDatos()
        {
            certificacionRequerimientoPresentador.IniciarDatos();
            //bloquearPresupuesto(!(certificacionMasterPres.tipoReq == 1 ? (bool)this.certificacionMasterPres.forebi.esAnual : (bool)this.certificacionMasterPres.forese.esAnual));
            
            if (this.esModificacion)
            {
                Text = "Modificación - Certificación de Requerimiento";
                var lista = ListaDetalle.Count;
                if (ListaDetalle.Count > 0)
                {
                    bloquearPresupuesto(true);
                }
                //deFecha.ReadOnly = true;
            }
            else
            {
                Text = "Registro - Certificación de Requerimiento";
                this.ListaDetallesSeleccionados.Clear();

                certificacionRequerimientoPresentador.TraerTipoCambio();
                CertificacionRequerimiento.idPresupuesto = this.esAnual ? idPresupuesto : idSubPresupuesto;
                CertificacionRequerimiento.nivelPresupuesto = this.esAnual ? 2 : 3;
                //this.lciPresupuestoMensual.Visibility = this.esAnual ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                this.lueSubPresupuesto.ReadOnly = this.esAnual ? false : true;
                frmSeleccionReq = new SeleccionRequerimientoDetalle(CertificacionMasterPres, CertificacionRequerimiento, null, true);
                frmSeleccionReq.Bounds = lciBaseReq.DisplayRectangle;
                frmSeleccionReq.Visible = true;
                lciBaseReq.Controls.Add(frmSeleccionReq);
                frmSeleccionReq.Dock = DockStyle.Fill;
                frmSeleccionReq.Visible = true;
                frmSeleccionReq.BringToFront();
            }
            
        }
        
        protected override void GuardarDatos()
        {
            ListaDetallesSeleccionados = frmSeleccionReq == null ? null : frmSeleccionReq.ListaDetallesSeleccionados;
            string desRequerimiento = this.certificacionMasterPres.tipoReq == 1 ? "Forebi" : "Forese";
            sumaDetalles();

            if (validar())
            {
                if (certificacionRequerimientoPresentador.GuardarDatos())
                {
                    if (this.esModificacion)
                        EmitirMensajeResultado(true, Mensajes.MensajeModificacionSatisfactoria);
                    else
                        EmitirMensajeResultado(true, Mensajes.MensajeRegistroSatisfactorio);

                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    this.DialogResult = DialogResult.No;
                    EmitirMensajeResultado(false, Mensajes.MensajeErrorRegistro + this.vmensaje != "" ? vmensaje : "");
                }
            }
            else
            {
                this.DialogResult = DialogResult.No;
                EmitirMensajeResultado(true, vmensaje);
            }
        }
        private void lueTipo_EditValueChanged(object sender, EventArgs e)
        {
            this.tipo = idTipoReq == 1 ? tipoAyudaFore.bien : tipoAyudaFore.servicio;
        }
        private void lueGruPre_EditValueChanged(object sender, EventArgs e)
        {
            certificacionRequerimientoPresentador.LlenarComboPresupuesto(this.idGruPre);
        }
        private void luePresupuesto_EditValueChanged(object sender, EventArgs e)
        {
            certificacionRequerimientoPresentador.LlenarComboSubPresupuesto(this.idPresupuesto);
        }
        private void lueSubPresupuesto_EditValueChanged(object sender, EventArgs e)
        {
            //if (lueSubPresupuesto.EditValue != null || idSubPresupuesto > 0)
            //{
            //    if (!this.esModificacion)
            //    {
                    
            //    }
            //}
        }

        /*Metodos*/
        private bool validar()
        {
            bool res = true;
            vmensaje = string.Empty;
            
            if (esModificacion)
            {
                Resultado resValidaFechaCertificacion = this.certificacionRequerimientoPresentador.ValidaFechaCertificacion(fechaEmision, certificacionRequerimiento.numero, "M", certificacionRequerimiento.idCerReq);
                if (!resValidaFechaCertificacion.esCorrecto)
                {
                    res = false;
                    vmensaje = vmensaje + resValidaFechaCertificacion.mensajeMostrar;
                }
            }
            else
            {
                //if ((bool)SubPresupuestoImporteCertificacion.esObra && (decimal)SubPresupuestoImporteCertificacion.certificacionSoles >= (decimal)SubPresupuestoImporteCertificacion.importeObra)
                //{
                //    res = false;
                //    vmensaje = "\nLa certificación ya se completo el monto de la obra";
                //}
                if (total == 0)
                {
                    res = false;
                    vmensaje = vmensaje + "\nTotal de certificación debe ser mayor a 0";
                }
                if (ListaDetallesSeleccionados.Count == 0)
                {
                    res = false;
                    vmensaje = vmensaje + "\nDebe seleccionar al menos un detalle";
                }
                if (!verificaCuenta())
                {
                    res = false;
                    vmensaje = vmensaje + "\nUno ó mas detalles no tiene asignado una cuenta";
                }
                if (tipoCambio.Equals(0))
                {
                    res = false;
                    vmensaje = vmensaje + "\nTipo de cambio para presupuesto mensual no existe";
                }
            }
            
            return res;
        }
        private void bloquearPresupuesto(bool opcion)
        {
            lueGruPre.ReadOnly = opcion;
            luePresupuesto.ReadOnly = opcion;
            lueSubPresupuesto.ReadOnly = opcion;
        }
        private void sumaDetalles()
        {
            if (!this.esModificacion)
            {
                this.total = 0;
                if (ListaDetallesSeleccionados.Count > 0)
                {
                    foreach (ForeDetallePoco det in ListaDetallesSeleccionados)
                    {
                        if (det != null)
                        {
                            this.total = this.total + (decimal)det.subTotal;
                        }
                    }
                }
            }
        }
        private bool verificaCuenta()
        {
            bool res = true;
            if (!this.esModificacion)
            {
                if (ListaDetallesSeleccionados.Count > 0)
                {
                    foreach (ForeDetallePoco det in ListaDetallesSeleccionados)
                    {
                        if (det != null)
                        {
                            res = (det.idCueCon == null || det.idCueCon == 0) ? false : true;
                            if (!res) break;
                        }
                    }
                }
            }
            return res;   
        }

        private void txtDetalle_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string input = txtDetalle.Text;
            string pattern = @"^[a-zA-Z0-9\s\-]+$";

            //if (!Regex.IsMatch(input, pattern))
            //{
            //    MessageBox.Show("Solo se permiten letras, números, espacios, guiones y saltos de línea.");
            //    e.Cancel = true; // Evita que se pierda el foco si la validación falla
            //}
        }
    }
}
