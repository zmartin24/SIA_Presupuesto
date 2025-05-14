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
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.General.Ayuda;

namespace SIA_Presupuesto.WinForm.Adquisicion.Dialogo
{
    public partial class frmCertificacionMaster : frmDialogoBase, ICertificacionMasterVista
    {
        private CertificacionMasterPresentador certificacionMasterPresentador;

        public List<Predeterminado> listaTipoRequerimiento
        {
            set
            {
                ElementoHelper.LlenarLookUpEdit(lueTipo.Properties, "codigo", "descripcion", "Tipo Requerimiento", value);
            }
        }
        public List<CertificacionRequerimiento> ListaCertificacionRequerimiento
        {
            set; get;
        }
        public int idTipoReq
        {
            set { lueTipo.EditValue = value.ToString(); }
            get { return Convert.ToInt32(lueTipo.EditValue); }
        }
        public int idForebise
        {
            set;get;
        }
        public bool esTotalDetallado
        {
            set { chkEsTotalDetallado.Checked = value; }
            get { return chkEsTotalDetallado.Checked; }
        }
        public string observacion
        {
            set { txtObservacion.EditValue = value; }
            get { return txtObservacion.Text; }
        }
        public SubPresupuestoImporteCertificacion_Pres SubPresupuestoImporteCertificacion
        {
            set;get;
        }
        private tipoAyudaFore tipo;
        private Forebi forebi;
        private Forese forese;
        public Forebi Forebi
        {
            get { return forebi; }
            set
            {
                forebi = value;
                if (value != null)
                {
                    txtReq.Text = value.numero;
                    idForebise = value.idForebi;
                }
                else
                {
                    txtReq.Text = string.Empty;
                    idForebise = 0;
                }
            }
        }
        public Forese Forese
        {
            get { return forese; }
            set
            {
                forese = value;
                if (value != null)
                {
                    txtReq.Text = value.numero;
                    idForebise = value.idForese;
                }
                else
                {
                    txtReq.Text = string.Empty;
                    idForebise = 0;
                }
            }
        }
        public string vmensaje { set; get; }

        public frmCertificacionMaster(CertificacionMaster certificacionMaster, Form padre) : base(padre, true)
        {
            InitializeComponent();
            this.esModificacion = certificacionMaster != null;
            certificacionMasterPresentador = new CertificacionMasterPresentador(certificacionMaster, this);
            
        }
        protected override void InicializarValidacion()
        {
            dxProveedorValidador.SetValidationRule(lueTipo, ValidacionHelper.ReglaNoDebeSerVacio);
            dxProveedorValidador.SetValidationRule(txtReq, ValidacionHelper.ReglaNoDebeSerVacio);
        }
        protected override void InicializarDatos()
        {
            certificacionMasterPresentador.IniciarDatos();
            if (this.esModificacion)
            {
                Text = "Modificación - Certificación Master";
                lueTipo.ReadOnly = true;
                chkEsTotalDetallado.ReadOnly = this.ListaCertificacionRequerimiento != null && this.ListaCertificacionRequerimiento.Count > 0 ? true : false;
                sbReq.Enabled = false; 
            }
            else
                Text = "Registro - Certificación Master";
        }
        protected override void GuardarDatos()
        {
            if (certificacionMasterPresentador.GuardarDatos())
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

        private void lueTipo_EditValueChanged(object sender, EventArgs e)
        {
            this.tipo = idTipoReq == 1 ? tipoAyudaFore.bien : tipoAyudaFore.servicio;
            this.Forebi = null;
            this.Forese = null;
        }
        private void sbReq_Click(object sender, EventArgs e)
        {
            AbrirAyudaFore(this.tipo);
        }
        private void AbrirAyudaFore(tipoAyudaFore tipo)
        {
            using (frmAyudaFore frm = new frmAyudaFore(tipo))
            {
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    switch (tipo)
                    {
                        case tipoAyudaFore.bien:
                            this.Forebi = frm.Tag as Forebi;
                            //this.idForebise = this.Forebi == null ? 0 : this.Forebi.idForebi;
                            break;
                        case tipoAyudaFore.servicio:
                            this.Forese = frm.Tag as Forese;
                            //this.idForebise = this.Forese == null ? 0 : this.Forese.idForese;
                            break;
                    }
                }
            }
        }

    }
}
