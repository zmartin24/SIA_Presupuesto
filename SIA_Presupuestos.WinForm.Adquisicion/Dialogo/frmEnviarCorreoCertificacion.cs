using System;
using DevExpress.XtraEditors;
using System.Collections.Generic;
using System.Linq;
using SIA_Presupuesto.Negocio.Entidades;
using SIA_Presupuesto.WinForm.General.Base;
using DevExpress.XtraGrid.Views.Grid;
using System.Text.RegularExpressions;
using System.DirectoryServices.AccountManagement;
using SIA_Presupuesto.WinForm.Adquisicion.Helper;
using SIA_Presupuesto.WinForm.General.Adicional;
using DevExpress.XtraReports.UI;
using SIA_Presupuesto.WinForm.Adquisicion.Reporte;
using System.Globalization;
using DevExpress.XtraRichEdit.API.Native;
using DevExpress.Office.Utils;
using SIA_Presupuesto.WinForm.Adquisicion.Recursos;

namespace SIA_Presupuesto.WinForm.Adquisicion.Dialogo
{
    public partial class frmEnviarCorreoCertificacion : frmDialogoBase
    {
        // Creates a TextInfo based on the "en-US" culture.
        //TextInfo myTI = new CultureInfo("es-PE", false).TextInfo;
        TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
        
        public List<UsuarioCorreoPres> listaUsuarioCorreo
        {
            set
            {
                searchLue.Properties.DataSource = value; 
            }
        }

        public List<ReporteCertificacionPresupuestalPres> listaReporteCertificacionPresupuestal
        {
            set; get;
        }

        private Dictionary<UsuarioCorreoPres, bool> listaUsuarioCorreoSeleccionados = new Dictionary<UsuarioCorreoPres, bool>();
        public List<UsuarioCorreoPres> ListaUsuarioCorreoSeleccionados
        {
            get { return listaUsuarioCorreoSeleccionados.Keys.ToList(); }
        }
        public frmEnviarCorreoCertificacion(List<UsuarioCorreoPres> listaUsuarioCorreo, List<ReporteCertificacionPresupuestalPres> listaReporteCertificacionPresupuestal)
        {
            InitializeComponent();
            this.listaUsuarioCorreoSeleccionados = new Dictionary<UsuarioCorreoPres, bool>();
            this.listaUsuarioCorreo = listaUsuarioCorreo;
            this.listaReporteCertificacionPresupuestal = listaReporteCertificacionPresupuestal;
        }

        protected override bool ValidarDatos()
        {
            bool validarOtros = false;

            if (!string.IsNullOrEmpty(txtUsuario.Text) && !string.IsNullOrEmpty(txtClave.Text)
                && !string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtCorreo.Text))
                validarOtros = true;
            else
            {
                EmitirMensajeResultado(true, "Es necesarios ingresar datos de credenciales");
                txtClave.Focus();
            }
                
            return proveedorValidacion.Validate() && validarOtros;
        }
        protected override void InicializarDatos()
        {
            string numReq = listaReporteCertificacionPresupuestal.FirstOrDefault().numero;
            string desReq = "Requerimiento ";

            ObtenerDatosCuentaActual();
            var lista = listaReporteCertificacionPresupuestal.GroupBy(x => x.numero).Select(s=>s.FirstOrDefault()).ToList();
            if (lista.Count > 1)
            {
                numReq = string.Empty;
                lista.ForEach(
                    resul => {
                        numReq = numReq + ", " + resul.numero;
                    }
                );
                numReq = numReq.Substring(1);
                desReq = "Requerimientos ";
            }
            txtAsunto.Text = "Certificación Presupuestal de " + desReq + "( "+numReq+" )";

            txtDescripcion.Document.DefaultCharacterProperties.FontName = "Calibri";
            txtDescripcion.Document.DefaultCharacterProperties.FontSize = 11;
            //The target range is the first paragraph
            DocumentRange titleParagraph = txtDescripcion.Document.Paragraphs[0].Range;

            //Provide access to the paragraph options 
            ParagraphProperties titleParagraphFormatting = txtDescripcion.Document.BeginUpdateParagraphs(titleParagraph);

            //Set the paragraph alignment
            titleParagraphFormatting.Alignment = ParagraphAlignment.Justify;

            titleParagraphFormatting.RightIndent = Units.InchesToDocumentsF(0.7f);

            txtDescripcion.Document.EndUpdateParagraphs(titleParagraphFormatting);

            txtDescripcion.BeginUpdate();
            txtDescripcion.Document.AppendText( "Estimados,\n\n" +
                                                "De mi especial consideración.\n" +
                                                "Es grato dirigirme a usted para saludarl cordialmente y al mismo tiempo informarle.........................\n\n" +
                                                "Sin otro particular hago propicia la ocasión para expresarle los sentimientos de mi consideración y estima.\n\n" +
                                                "Atentamente,\n"+ textInfo.ToTitleCase(txtNombre.Text.ToLower())+"\n" + txtCorreo.Text);
            txtDescripcion.EndUpdate();
        }

        private bool EsCorreoValido(string correo)
        {
            // Return true if strIn is in valid e-mail format.
            return Regex.IsMatch(correo, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-ZñÑ]{2,4}|[0-9]{1,3})(\]?)$");
        }

        private void ObtenerDatosCuentaActual()
        {
            UserPrincipal usuarioLocal = UserPrincipal.Current;
            txtCorreo.Text = usuarioLocal.EmailAddress;
            txtNombre.Text = usuarioLocal.Name.ToUpper();
            txtUsuario.Text = usuarioLocal.SamAccountName;
        }

        protected override void GuardarDatos()
        {
            if (ListaUsuarioCorreoSeleccionados.Count > 0)
            {
                List<XtraReport> listaReporte = new List<XtraReport>();
                DateTime fecha = DateTime.Now;
                
                BarraProgresoDos form = new BarraProgresoDos();

                form.Show();
                EmailHelperResultado enviado = new EmailHelperResultado();
                Dictionary<String, String> correosNoValidos = new Dictionary<string, string>();

                bool resultadoRegistro = false;

                try
                {
                    form.pbcProgreso.Properties.Step = 1;
                    form.pbcProgreso.Properties.PercentView = true;
                    form.pbcProgreso.Properties.Maximum = ListaUsuarioCorreoSeleccionados.Count;
                    form.pbcProgreso.Properties.Minimum = 0;
                    Dictionary<String, String> correos = null;

                    //Lista de reportes
                    foreach (ReporteCertificacionPresupuestalPres data in this.listaReporteCertificacionPresupuestal.Where(x => x.esAmpliacion == false).ToList())
                    {
                        XtraReport reporte = new rptCertificacionPresupuestal();
                        reporte.DataSource = listaReporteCertificacionPresupuestal.FindAll(x => x.idCerReq == data.idCerReq && x.esAmpliacion == false);
                        listaReporte.Add(reporte);
                    }
                    //Si existe ampliacion
                    var listaAmpliacion = this.listaReporteCertificacionPresupuestal.Where(x => x.esAmpliacion == true).ToList();
                    if (listaAmpliacion.Count > 0)
                    {
                        foreach (ReporteCertificacionPresupuestalPres rptAmpliacion in listaAmpliacion)
                        {
                            XtraReport reporte = new rptCertificacionPresupuestal();
                            reporte.DataSource = listaAmpliacion.FindAll(x => x.idCerReq == rptAmpliacion.idCerReq);
                            listaReporte.Add(reporte);
                        }
                    }

                    foreach (UsuarioCorreoPres correo in ListaUsuarioCorreoSeleccionados)
                    {
                        if (!string.IsNullOrEmpty(correo.email) && !string.IsNullOrWhiteSpace(correo.email))
                        {
                            //XtraReport reporte = ReporteHelper.TraerReporte("rptCertificacionPresupuestal");
                            correos = new Dictionary<string, string>();
                            string[] listaOtrosCorreos = correo.email.Trim().Replace(" ", "").Split(';', '/');
                            int i = 0;
                            foreach (var cor in listaOtrosCorreos)
                                if (EsCorreoValido(cor))
                                    correos.Add(string.Format("{0}_{1}", textInfo.ToTitleCase(correo.nombresCompletos.ToLower()), ++i), cor);
                                else
                                    correosNoValidos.Add(string.Format("{0}_{1}", textInfo.ToTitleCase(correo.nombresCompletos.ToLower()), ++i), cor);

                            
                            if (correos.Count > 0 && listaReporte.Count > 0)
                            {
                                enviado = EmailHelper.Enviar(txtCorreo.Text, textInfo.ToTitleCase(txtNombre.Text.ToLower()), correos, txtAsunto.Text.ToUpper(), txtDescripcion.Text, txtUsuario.Text, txtClave.Text, listaReporte, false, string.Empty);

                                //if (!ceUsarCred.Checked)
                                //    enviado = EmailHelper.Enviar(txtCorreo.Text, txtNombre.Text, correos, txtAsunto.Text.ToUpper(), txtDescripcion.Text, txtUsuario.Text, txtClave.Text, nombreArchivo, reporte, ceConClavePDF.Checked, correo.nroDocIdentidad);
                                //else
                                //    enviado = EmailHelper.Enviar(txtCorreo.Text, txtNombre.Text, correos, txtAsunto.Text.ToUpper(), txtDescripcion.Text, nombreArchivo, reporte, ceConClavePDF.Checked, correo.nroDocIdentidad);

                                if (enviado.error)
                                {
                                    foreach (var par in correos)
                                        correosNoValidos.Add(par.Key, par.Value);
                                }
                            }
                        }
                        else
                            correosNoValidos.Add(correo.nombresCompletos, correo.email);

                        form.pbcProgreso.PerformStep();
                        form.pbcProgreso.Update();
                    }

                    resultadoRegistro = true;

                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
                    enviado.error = true;
                }
                finally
                {
                    form.Close();
                    form.Dispose();
                }

                if (resultadoRegistro)
                {
                    if (correosNoValidos.Count == 0)EmitirMensajeResultado(true, "Se enviaron los correos correctamente");
                    else EmitirMensajeResultado(false, "Error al enviar correos. Algunos correos son inválidos");
                }
                else
                {
                    EmitirMensajeResultado(false, "Error. No se puedo registrar el envió");
                }
            }
            else
            {
                EmitirMensajeResultado(true, "Debe seleccionar al menos un correo");
                searchLue.Focus();
            }
            
        }

        
        private void searchLue_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            List<string> values = new List<string>();

            foreach (UsuarioCorreoPres usuarioCorreoPres in ListaUsuarioCorreoSeleccionados)
            {
                if (usuarioCorreoPres != null)
                {
                    values.Add(usuarioCorreoPres.email);
                }
            }
            string csv = String.Join(", ", values);
            e.DisplayText = csv;

            //EmitirMensajeResultado(true, "Total : "+c.ToString());
        }
        private void searchLue_Properties_Popup(object sender, EventArgs e)
        {
            SearchLookUpEdit edit = sender as SearchLookUpEdit;
            GridView view = edit.Properties.View as GridView;
            List<string> values = new List<string>();

            if (!edit.IsPopupOpen)
                edit.ShowPopup();

            foreach (UsuarioCorreoPres usuarioCorreoPres in ListaUsuarioCorreoSeleccionados)
            {
                if (usuarioCorreoPres != null)
                {
                    values.Add(usuarioCorreoPres.email);
                    view.SelectRow(view.FindRow(usuarioCorreoPres));
                }
            }
            string csv = String.Join(", ", values);
            edit.Text = csv;
        }
        private void searchLueView_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            GridView grid = sender as GridView;
            var row = e.ControllerRow;
            var accion = e.Action;

            var usuarioCorreoPres = grid.GetFocusedRow() as UsuarioCorreoPres;//popGridView.GetRow(rowHandle) as UsuarioCorreoPres;

            if (usuarioCorreoPres != null)
            {
                switch (e.Action)
                {
                    case System.ComponentModel.CollectionChangeAction.Add:
                        if (!this.ListaUsuarioCorreoSeleccionados.Contains(usuarioCorreoPres))
                            this.listaUsuarioCorreoSeleccionados.Add(usuarioCorreoPres, true);
                        break;
                    case System.ComponentModel.CollectionChangeAction.Remove:
                        if (this.ListaUsuarioCorreoSeleccionados.Contains(usuarioCorreoPres))
                            this.listaUsuarioCorreoSeleccionados.Remove(usuarioCorreoPres);
                        break;
                    case System.ComponentModel.CollectionChangeAction.Refresh:
                        if (this.ListaUsuarioCorreoSeleccionados.Contains(usuarioCorreoPres))
                            searchLueView.SelectRow(e.ControllerRow);
                        break;
                }
            }
        }

        private void searchLueView_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            GridView grid = sender as GridView;
            var row = e.Row;
            var accion = e.IsSetData;

            var usuarioCorreoPres = grid.GetFocusedRow() as UsuarioCorreoPres;//popGridView.GetRow(rowHandle) as UsuarioCorreoPres;

            //if (usuarioCorreoPres != null)
            //{
            //    switch (e.Value)
            //    {
            //        case System.ComponentModel.CollectionChangeAction.Add:
            //            if (!this.ListaUsuarioCorreoSeleccionados.Contains(usuarioCorreoPres))
            //                this.listaUsuarioCorreoSeleccionados.Add(usuarioCorreoPres, true);
            //            break;
            //        case System.ComponentModel.CollectionChangeAction.Remove:
            //            if (this.ListaUsuarioCorreoSeleccionados.Contains(usuarioCorreoPres))
            //                this.listaUsuarioCorreoSeleccionados.Remove(usuarioCorreoPres);
            //            break;
            //        case System.ComponentModel.CollectionChangeAction.Refresh:
            //            if (this.ListaUsuarioCorreoSeleccionados.Contains(usuarioCorreoPres))
            //                searchLueView.SelectRow(e.ListSourceRowIndex);
            //            break;
            //    }
            //}
        }
    }
}
