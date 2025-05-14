using System.Collections.Generic;
using System.Windows.Forms;

using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.Negocio.Entidades.PocosAdicionales;
using SIA_Presupuesto.WinForm.General.Base;
using SIA_Presupuesto.WinForm.Adquisicion.Vista;
using SIA_Presupuesto.WinForm.Adquisicion.Presentador;
using SIA_Presupuesto.WinForm.Adquisicion.Recursos;
using SIA_Presupuesto.WinForm.General.Ayuda;
using SIA_Presupuesto.WinForm.Adquisicion.Controles;

namespace SIA_Presupuesto.WinForm.Adquisicion.Dialogo
{
    public partial class frmBuscarForebi : frmDialogoBase, IBuscarForebiVista
    {
        private BuscarForebiPresentador buscarForebiPresentador;
        private CertificacionMasterPres certificacionMasterPres;
        private CertificacionRequerimiento certificacionRequerimiento;
        private SeleccionRequerimientoDetalle frmSeleccionReq;

        private Forebi forebi;
        private Forese forese;
        

        public List<ForeDetallePoco> ListaDetallesSeleccionados
        {
            get;set;
        }

        public Forebi Forebi
        {
            get { return forebi; }
            set
            {
                forebi = value;
                if (value != null)
                {
                    txtReq.Text = value.numero;

                }
                else
                {
                    txtReq.Text = string.Empty;

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

                }
                else
                {
                    txtReq.Text = string.Empty;

                }
            }
        }
        
        public SubPresupuestoImporteCertificacion_Pres SubPresupuestoImporteCertificacion
        {
            set; get;
        }
       
        public string vmensaje { set; get; }
        public decimal vsuma { set; get; }
        
        public bool esAnual = false;
        private decimal vtotalCertificacion = 0;
        private decimal vSubtotalDetalle = 0;


        public frmBuscarForebi(CertificacionMasterPres certificacionMasterPres, CertificacionRequerimiento certificacionRequerimiento, CertificacionDetallePres certificacionDetallePres, Form padre, tipoAyudaFore tipo) : base(padre, true)
        {
            InitializeComponent();
            this.certificacionMasterPres = certificacionMasterPres;
            this.certificacionRequerimiento = certificacionRequerimiento;
            this.esAnual = certificacionRequerimiento.nivelPresupuesto < 3 ? true : false;


            buscarForebiPresentador = new BuscarForebiPresentador(certificacionMasterPres, certificacionRequerimiento, certificacionDetallePres, this);
            
            frmSeleccionReq = new SeleccionRequerimientoDetalle(certificacionMasterPres, certificacionRequerimiento, certificacionDetallePres, false);
            frmSeleccionReq.Bounds = lciBaseReq.DisplayRectangle;
            frmSeleccionReq.Visible = true;
            lciBaseReq.Controls.Add(frmSeleccionReq);
            
            frmSeleccionReq.Dock = DockStyle.Fill;
            frmSeleccionReq.Visible = true;
            frmSeleccionReq.BringToFront();
            
            
            if (tipo.Equals(tipoAyudaFore.bien))
            {
                Text = certificacionDetallePres == null ? "Buscar Requerimientos - Bienes" : "Editar Detalle Certificación - Bienes";
                lciReq.Text = "Número de Forebi";
            }
            else
            {
                Text = certificacionDetallePres == null ? "Buscar Requerimientos - Servicio" : "Editar Detalle Certificación - Servicio";
                lciReq.Text = "Número de Forese";
            }
            vSubtotalDetalle = certificacionDetallePres != null ? (decimal)certificacionDetallePres.subTotal : 0;///Subtotal de detalle inicial

            ListaDetallesSeleccionados = new List<ForeDetallePoco>();
            
        }

        protected override void InicializarDatos()
        {
            buscarForebiPresentador.TraerSubPresupuestoImporteCertificacion(this.esAnual ? 0 : (int)certificacionRequerimiento.idPresupuesto);
            vtotalCertificacion = (decimal)SubPresupuestoImporteCertificacion.certificacionSoles - vSubtotalDetalle;
            ListaDetallesSeleccionados.Clear();

        }
        protected override void GuardarDatos()
        {
            if (frmSeleccionReq.ListaDetallesSeleccionados.Count > 0)
            {
                ListaDetallesSeleccionados = frmSeleccionReq.ListaDetallesSeleccionados;
                if (validar())
                {
                    if (buscarForebiPresentador.RegistrarDetalles())
                    {
                        if (this.esModificacion)
                            EmitirMensajeResultado(true, Mensajes.MensajeModificacionSatisfactoria);
                        else
                            EmitirMensajeResultado(true, Mensajes.MensajeRegistroSatisfactorio);

                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        EmitirMensajeResultado(false, Mensajes.MensajeErrorRegistro);
                    }
                }
                else
                {
                    EmitirMensajeResultado(false, vmensaje);
                    this.DialogResult = DialogResult.No;
                }
            }
            else
            {
                EmitirMensajeResultado(true, "No selecciono ningún detalle");
                this.DialogResult = DialogResult.No;
            }
        }
        private bool validar()
        {
            bool res = true;
            vmensaje = string.Empty;
            sumaDetalles();
            if (!(bool)this.certificacionMasterPres.esAnual && (bool)SubPresupuestoImporteCertificacion.esObra && vtotalCertificacion + vsuma > (decimal)SubPresupuestoImporteCertificacion.importeObra)
            {
                res = false;
                vmensaje = "Total certificado : " + vtotalCertificacion.ToString("n2") + " + " + vsuma.ToString("n2") + " para esta certificación, ya superan los " + SubPresupuestoImporteCertificacion.importeObra.ToString("n2") + ", importe total de la obra";
            }
            if (!verificaCuenta())
            {
                res = false;
                vmensaje = vmensaje + "\nUno ó mas detalles no tiene asignado una cuenta";
            }
            return res;
        }
        private void sumaDetalles()
        {
            vsuma = 0;
            if (ListaDetallesSeleccionados.Count > 0)
            {
                foreach (ForeDetallePoco obj in ListaDetallesSeleccionados)
                {
                    vsuma = vsuma + (decimal)obj.subTotal;
                }
            }
        }
        private bool verificaCuenta()
        {
            bool res = true;
            
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
            
            return res;
        }
    }
}