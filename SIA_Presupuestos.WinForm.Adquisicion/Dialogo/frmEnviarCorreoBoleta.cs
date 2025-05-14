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
using System.DirectoryServices.AccountManagement;
using System.Text.RegularExpressions;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraReports.UI;
using System.Collections.Specialized;

//using Pllas2012.WinForm.Basico;
//using Pllas2012.WinForm.Helpers;
//using Pllas2012.WinForm.Formularios;
//using Pllas2012.Negocio.Contratos.Servicios;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Base;

namespace SIA_Presupuesto.WinForm.Adquisicion.Dialogo
{
    public partial class frmEnviarCorreoBoleta : frmDialogoBase
    {
        //private List<TrabajadorCorreo> listaCorreos;
        //private List<ImpresionBoletaRemunPres> listBoleta;
        //private IHistorialEnvioCorreoServicio historicoEnvioCorreoServicio;
        //private int idPlanilla;

        string nombreReporte;
        //public frmEnviarCorreoBoleta(int idPlanilla, string nombreReporte, List<TrabajadorCorreo> listaCorreos, List<ImpresionBoletaRemunPres> listBoleta, IHistorialEnvioCorreoServicio historicoEnvioCorreoServicio)
        public frmEnviarCorreoBoleta()
        {
            InitializeComponent();
            this.Text = "Enviar Correos";
            //this.listaCorreos = listaCorreos;
            //this.nombreReporte = nombreReporte;
            //this.listBoleta = listBoleta;
            //this.idPlanilla = idPlanilla;
            //this.historicoEnvioCorreoServicio = historicoEnvioCorreoServicio;
        }

        public ColumnView ColumnaActual { get { return grcDetalle.MainView as ColumnView; } }
        protected ColumnView VistaActual { get { return ColumnaActual; } }

        //private TrabajadorCorreo MovimientoActual
        //{
        //    get
        //    {
        //        if (ColumnaActual == null || ColumnaActual.FocusedRowHandle < 0) return null;
        //        return ColumnaActual.GetRow(ColumnaActual.FocusedRowHandle) as TrabajadorCorreo;
        //    }
        //}

        protected override void InicializarValidacion()
        {
            //proveedorValidacion.SetValidationRule(txtAsunto, ValidacionHelper.ReglaNoDebeSerVacio);
            //proveedorValidacion.SetValidationRule(txtDescripcion, ValidacionHelper.ReglaNoDebeSerVacio);
        }

        protected override bool ValidarDatos() {
            bool validarOtros = false;

            if (!ceUsarCred.Checked)
            {
                if (!string.IsNullOrEmpty(txtUsuario.Text) && !string.IsNullOrEmpty(txtClave.Text)
                    && !string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtCorreo.Text))
                    validarOtros = true;
                else
                    EmitirMensajeResultado(true, "Es necesarios ingresar datos de credenciales");
            }
            else
                validarOtros = true;

            return proveedorValidacion.Validate() && validarOtros;
        }
        private bool EsCorreoValido(string correo)
        {
            // Return true if strIn is in valid e-mail format.
            return Regex.IsMatch(correo, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-ZñÑ]{2,4}|[0-9]{1,3})(\]?)$");
        }


        protected override void GuardarDatos()
        {
            //List<TrabajadorCorreo> listaCorreosEnviados = new List<TrabajadorCorreo>();
            //DateTime fecha = DateTime.Now;

            //BarraProgresoDos form = new BarraProgresoDos();
            
            //form.Show();
            //EmailHelperResultado enviado = new EmailHelperResultado();
            //Dictionary<String, String> correosNoValidos = new Dictionary<string, string>();

            //bool resultadoRegistro = false;

            //try
            //{
            //    form.pbcProgreso.Properties.Step = 1;
            //    form.pbcProgreso.Properties.PercentView = true;
            //    form.pbcProgreso.Properties.Maximum = listaCorreos.Count;
            //    form.pbcProgreso.Properties.Minimum = 0;
            //    Dictionary<String, String> correos = null;

            //    List<HistorialEnvioCorreoDetalle> detalle = new List<HistorialEnvioCorreoDetalle>();
            //    foreach (TrabajadorCorreo correo in listaCorreos)
            //    {
            //        if (!string.IsNullOrEmpty(correo.email) && !string.IsNullOrWhiteSpace(correo.email))
            //        {
            //            XtraReport reporte = ReporteHelper.TraerReporte(nombreReporte);
            //            correos = new Dictionary<string, string>();
            //            string[] listaOtrosCorreos = correo.email.Trim().Replace(" ", "").Split(';', '/');
            //            int i = 0;
            //            foreach (var cor in listaOtrosCorreos)
            //                if (EsCorreoValido(cor))
            //                    correos.Add(string.Format("{0}_{1}", correo.nombres, ++i), cor);
            //                else
            //                    correosNoValidos.Add(string.Format("{0}_{1}", correo.nombres, ++i), cor);

            //            if (correos.Count > 0)
            //            {
            //                reporte.DataSource = listBoleta.FindAll(f => f.idContrato == correo.idContrato);
            //                string nombreArchivo = correo.nombres.Replace(" ", "_");
            //                if (!ceUsarCred.Checked)
            //                    enviado = EmailHelper.Enviar(txtCorreo.Text, txtNombre.Text, correos, txtAsunto.Text.ToUpper(), txtDescripcion.Text, txtUsuario.Text, txtClave.Text, nombreArchivo, reporte, ceConClavePDF.Checked, correo.nroDocIdentidad);
            //                else
            //                    enviado = EmailHelper.Enviar(txtCorreo.Text, txtNombre.Text, correos, txtAsunto.Text.ToUpper(), txtDescripcion.Text, nombreArchivo, reporte, ceConClavePDF.Checked, correo.nroDocIdentidad);

            //                if (enviado.error)
            //                {
            //                    foreach (var par in correos)
            //                        correosNoValidos.Add(par.Key, par.Value);
            //                }
            //                else
            //                    listaCorreosEnviados.Add(correo);
            //                //throw new Exception("Error al enviar correos. Valide los correos.");
            //            }
            //        }
            //        else
            //            correosNoValidos.Add(correo.nombres, correo.email);


            //        detalle.Add(new HistorialEnvioCorreoDetalle
            //        {
            //            idContrato = correo.idContrato,
            //            confirmado = false,
            //            fechaEnviado = DateTime.Now,
            //            enviado = !enviado.error,
            //            correo = correo.email,
            //            estado = true,
            //            mensaje = enviado.mensaje,
            //            fechaCrea = DateTime.Now,
            //            usuCrea = txtUsuario.Text,
            //        });

            //        form.pbcProgreso.PerformStep();
            //        form.pbcProgreso.Update();
            //    }

            //    HistorialEnvioCorreo historico = new HistorialEnvioCorreo
            //    {
            //        correo = txtCorreo.Text,
            //        asunto = txtAsunto.Text,
            //        descripcion = txtDescripcion.Text,
            //        fechaEnvio = DateTime.Now,
            //        estado = true,
            //        observacion = string.Empty,
            //        idPlanilla = this.idPlanilla,
            //        fechaCrea = DateTime.Now,
            //        usuCrea = this.txtUsuario.Text
            //    };

            //    if (!historicoEnvioCorreoServicio.Nuevo(historico, detalle))
            //    {
            //        resultadoRegistro = false;
            //    }
            //    else
            //        resultadoRegistro = true;

            //}
            //catch(Exception ex)
            //{
            //    enviado.error = true;
            //}
            //finally
            //{
            //    form.Close();
            //    form.Dispose();
            //}

            //if (resultadoRegistro)
            //{
            //    if (correosNoValidos.Count == 0)
            //    {
            //        EmitirMensajeResultado(true, "Se enviaron los correos correctamente");
            //    }
            //    else
            //    {
            //        EmitirMensajeResultado(false, "Error al enviar correos. Algunos correos son invalidos");
            //        using (frmCorreoNoValidos frm = new frmCorreoNoValidos(correosNoValidos))
            //        {
            //            frm.ShowDialog();
            //        }
            //    }
            //}
            //else
            //{
            //    EmitirMensajeResultado(false, "Error. No se puedo registrar el envio");
            //}

            //XtraReport report = new rptConstanciaCorreosEnviados();
            //report.Parameters["Fecha"].Value = fecha;
            //report.Parameters["Usuario"].Value = this.txtUsuario.Text;
            //report.DataSource = listaCorreosEnviados;
            //report.ShowPrintMarginsWarning = false;

            //ReportPrintTool tool = new ReportPrintTool(report);
            //tool.ShowPreview();

        }

        private void LlenarGrid()
        {
            //grcDetalle.DataSource = listaCorreos;
            //grcDetalle.RefreshDataSource();
        }

        protected override void InicializarDatos()
        {
            LlenarGrid();
            ObtenerDatosCuentaActual();
        }

        private void ObtenerDatosCuentaActual()
        { 
            UserPrincipal test = UserPrincipal.Current;
            txtCorreo.Text = test.EmailAddress;
            txtNombre.Text = test.Name.ToUpper();
            txtUsuario.Text = test.SamAccountName;
            //txtNombre.Text = test.ac
        }

        private void ceUsarCred_CheckedChanged(object sender, EventArgs e)
        {
            txtNombre.Enabled = !ceUsarCred.Checked;
            txtUsuario.Enabled = !ceUsarCred.Checked;
            txtClave.Enabled = !ceUsarCred.Checked;
            txtCorreo.Enabled = !ceUsarCred.Checked;
            if (ceUsarCred.Checked)
                ObtenerDatosCuentaActual();
        }
    }
}