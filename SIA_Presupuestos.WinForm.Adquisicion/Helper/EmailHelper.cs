using DevExpress.XtraReports.UI;
using SIA_Presupuesto.Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SIA_Presupuesto.WinForm.Adquisicion.Helper
{
    public class EmailHelperResultado
    {
        public bool error { get; set; }
        public string mensaje { get; set; }
    }
    public class EmailHelper
    {
        public static EmailHelperResultado Enviar(string correoOrigen, string NombreRemitente, IDictionary<string, string> correosDestinos, string asunto, string contenido,
            string usuariocredencial, string claveCredencial,
            string nombreArchivo, XtraReport reporte, bool esConClavePDF, string clavePDF)
        {
            EmailHelperResultado resultados = new EmailHelperResultado();

            SmtpClient smtp = new SmtpClient("mail.corahperu.org", 587);
            MailMessage mail = new MailMessage();
            MemoryStream mem = new MemoryStream();
            try
            {
                // crea nueva memoria para la exportación a PDF.

                //Permite termino de envios de correos anteriores
                System.Threading.Thread.Sleep(5000);
                if (esConClavePDF)
                {
                    reporte.ExportOptions.Pdf.PasswordSecurityOptions.PermissionsOptions.EnableCopying = false;
                    reporte.ExportOptions.Pdf.PasswordSecurityOptions.PermissionsOptions.ChangingPermissions = DevExpress.XtraPrinting.ChangingPermissions.None;
                    reporte.ExportOptions.Pdf.PasswordSecurityOptions.PermissionsPassword = clavePDF;
                    reporte.ExportOptions.Pdf.PasswordSecurityOptions.OpenPassword = clavePDF;
                }

                reporte.ExportToPdf(mem);

                // Exportar reporte a PDF
                //reporte.ExportToPdf(nombreArchivo);

                // Create a new attachment and put the PDF report into it.
                mem.Seek(0, System.IO.SeekOrigin.Begin);
                Attachment att = new Attachment(mem, nombreArchivo + ".pdf", "application/pdf");

                // Create second attachment and put the exported PDF report into it.
                //var currentFolder = Path.GetDirectoryName(this.GetType().Assembly.Location);
                //Attachment att2 = new Attachment(Path.Combine(currentFolder, "exportedFile.pdf"), "application/pdf");

                // Creamos el mail y adjuntamos los pdfs

                mail.Attachments.Add(att);
                //mail.Attachments.Add(att2);

                // Especificamos datos del remitente
                mail.From = new MailAddress(correoOrigen, NombreRemitente);

                // Especificamos datos de los destinatarios
                foreach (var par in correosDestinos)
                    mail.To.Add(new MailAddress(par.Value, par.Key));

                // Llenamos datos del correo
                mail.Subject = asunto;
                mail.Body = contenido;

                // Especificamos datos del servidor para enviar el mail

                smtp.Credentials = new System.Net.NetworkCredential(usuariocredencial, claveCredencial);
                smtp.Send(mail);



                resultados.mensaje = "Enviado correctamente";
                resultados.error = false;
            }
            catch (SmtpFailedRecipientsException ex)
            {
                for (int i = 0; i < ex.InnerExceptions.Length; i++)
                {
                    SmtpStatusCode status = ex.InnerExceptions[i].StatusCode;
                    if (status == SmtpStatusCode.MailboxBusy ||
                        status == SmtpStatusCode.MailboxUnavailable)
                    {
                        resultados.error = true;
                        resultados.mensaje = "Error en la entrega. Reintento en 5 segundos.";
                        System.Threading.Thread.Sleep(5000);
                        try
                        {
                            smtp.Send(mail);
                        }
                        catch (Exception ex1)
                        {
                            resultados.error = true;
                            resultados.mensaje = "Error al enviar correo";
                        }
                    }
                    else
                    {
                        resultados.error = true;
                        resultados.mensaje = string.Format("No se pudo entregar el mensaje a {0}", ex.InnerExceptions[i].FailedRecipient);
                    }
                }
            }
            catch (Exception ex)
            {
                resultados.error = true;
                resultados.mensaje = "Error al enviar correo";
            }
            finally
            {
                // Cerramos la memoria
                mem.Close();
                mem.Flush();
            }
            return resultados;
        }

        public static EmailHelperResultado Enviar(string correoOrigen, string NombreRemitente, IDictionary<string, string> correosDestinos, string asunto, string contenido,
            string usuariocredencial, string claveCredencial,
            List<XtraReport> listaReporte, bool esConClavePDF, string clavePDF)
        {
            EmailHelperResultado resultados = new EmailHelperResultado();

            SmtpClient smtp = new SmtpClient("mail.corahperu.org", 587);
            MailMessage mail = new MailMessage();
            MemoryStream mem = null;// new MemoryStream();
            try
            {
                // crea nueva memoria para la exportación a PDF.

                //Permite termino de envios de correos anteriores
                System.Threading.Thread.Sleep(5000);
                foreach (XtraReport reporte in listaReporte)
                {
                    mem = new MemoryStream();
                    List<ReporteCertificacionPresupuestalPres> lista = reporte.DataSource as List<ReporteCertificacionPresupuestalPres>;
                    ReporteCertificacionPresupuestalPres obj = lista.FirstOrDefault();
                    if (esConClavePDF)
                    {
                        reporte.ExportOptions.Pdf.PasswordSecurityOptions.PermissionsOptions.EnableCopying = false;
                        reporte.ExportOptions.Pdf.PasswordSecurityOptions.PermissionsOptions.ChangingPermissions = DevExpress.XtraPrinting.ChangingPermissions.None;
                        reporte.ExportOptions.Pdf.PasswordSecurityOptions.PermissionsPassword = clavePDF;
                        reporte.ExportOptions.Pdf.PasswordSecurityOptions.OpenPassword = clavePDF;
                    }

                    // Exportar reporte a PDF
                    reporte.ExportToPdf(mem);
                    
                    // Create a new attachment and put the PDF report into it.
                    mem.Seek(0, System.IO.SeekOrigin.Begin);
                    Attachment att = new Attachment(mem, obj != null ? (bool)obj.esAmpliacion ? "Ampliacion_" + obj.sigla : obj.sigla : "ArchivoCertificacion" + ".pdf", "application/pdf");

                    // Creamos el mail y adjuntamos los pdfs
                    mail.Attachments.Add(att);
                }

                // Especificamos datos del remitente
                mail.From = new MailAddress(correoOrigen, NombreRemitente);

                // Especificamos datos de los destinatarios
                foreach (var par in correosDestinos)
                    mail.To.Add(new MailAddress(par.Value, par.Key));

                // Llenamos datos del correo
                mail.Subject = asunto;
                mail.Body = contenido;

                // Especificamos datos del servidor para enviar el mail

                smtp.Credentials = new System.Net.NetworkCredential(usuariocredencial, claveCredencial);
                smtp.Send(mail);

                resultados.mensaje = "Enviado correctamente";
                resultados.error = false;
            }
            catch (SmtpFailedRecipientsException ex)
            {
                for (int i = 0; i < ex.InnerExceptions.Length; i++)
                {
                    SmtpStatusCode status = ex.InnerExceptions[i].StatusCode;
                    if (status == SmtpStatusCode.MailboxBusy ||
                        status == SmtpStatusCode.MailboxUnavailable)
                    {
                        resultados.error = true;
                        resultados.mensaje = "Error en la entrega. Reintento en 5 segundos.";
                        System.Threading.Thread.Sleep(5000);
                        try
                        {
                            smtp.Send(mail);
                        }
                        catch (Exception ex1)
                        {
                            resultados.error = true;
                            resultados.mensaje = "Error al enviar correo";
                        }
                    }
                    else
                    {
                        resultados.error = true;
                        resultados.mensaje = string.Format("No se pudo entregar el mensaje a {0}", ex.InnerExceptions[i].FailedRecipient);
                    }
                }
            }
            catch (Exception ex)
            {
                resultados.error = true;
                resultados.mensaje = "Error al enviar correo";
            }
            finally
            {
                // Cerramos la memoria
                mem.Close();
                mem.Flush();
            }
            return resultados;
        }

        public static EmailHelperResultado Enviar(string correoOrigen, string NombreRemitente, IDictionary<string, string> correosDestinos, string asunto,
            string contenido, string nombreArchivo, XtraReport reporte, bool esConClavePDF, string clavePDF)
        {
            EmailHelperResultado resultados = new EmailHelperResultado();
            // Especificamos datos del servidor para enviar el mail
            SmtpClient smtp = new SmtpClient("mail.corahperu.org", 587);
            // crea nueva memoria para la exportación a PDF.
            MailMessage mail = new MailMessage();
            MemoryStream mem = new MemoryStream();
            try
            {
                //Permite termino de envios de correos anteriores
                System.Threading.Thread.Sleep(5000);
                if (esConClavePDF)
                {
                    reporte.ExportOptions.Pdf.PasswordSecurityOptions.PermissionsOptions.EnableCopying = false;
                    reporte.ExportOptions.Pdf.PasswordSecurityOptions.PermissionsOptions.ChangingPermissions = DevExpress.XtraPrinting.ChangingPermissions.None;
                    reporte.ExportOptions.Pdf.PasswordSecurityOptions.PermissionsPassword = clavePDF;
                    reporte.ExportOptions.Pdf.PasswordSecurityOptions.OpenPassword = clavePDF;
                }

                reporte.ExportToPdf(mem);

                // Exportar reporte a PDF
                //reporte.ExportToPdf(nombreArchivo);

                // Create a new attachment and put the PDF report into it.
                mem.Seek(0, System.IO.SeekOrigin.Begin);
                Attachment att = new Attachment(mem, nombreArchivo + ".pdf", "application/pdf");

                // Creamos el mail y adjuntamos los pdfs
                mail.Attachments.Add(att);

                // Especificamos datos de los destinatarios
                foreach (var par in correosDestinos)
                    mail.To.Add(new MailAddress(par.Value, par.Key));

                // Especificamos datos del remitente
                mail.From = new MailAddress(correoOrigen, NombreRemitente);

                // Llenamos datos del correo
                mail.Subject = asunto;
                mail.Body = contenido;


                smtp.Credentials = CredentialCache.DefaultNetworkCredentials; //new System.Net.NetworkCredential(usuariocredencial, claveCredencial);
                smtp.Send(mail);

                // Cerramos la memoria
                mem.Close();
                mem.Flush();
            }
            catch (SmtpFailedRecipientsException ex)
            {
                for (int i = 0; i < ex.InnerExceptions.Length; i++)
                {
                    SmtpStatusCode status = ex.InnerExceptions[i].StatusCode;
                    if (status == SmtpStatusCode.MailboxBusy ||
                        status == SmtpStatusCode.MailboxUnavailable)
                    {
                        resultados.error = true;
                        resultados.mensaje = "Error en la entrega. Reintento en 5 segundos.";
                        System.Threading.Thread.Sleep(5000);
                        try
                        {
                            smtp.Send(mail);
                        }
                        catch (Exception ex1)
                        {
                            resultados.error = true;
                            resultados.mensaje = "Error al enviar correo";
                        }
                    }
                    else
                    {
                        resultados.error = true;
                        resultados.mensaje = string.Format("No se pudo entregar el mensaje a {0}", ex.InnerExceptions[i].FailedRecipient);
                    }
                }
            }
            catch (Exception ex)
            {
                resultados.error = true;
                resultados.mensaje = "Error al enviar correo";
            }
            finally
            {
                // Cerramos la memoria
                mem.Close();
                mem.Flush();
            }
            return resultados;
        }
    }
}
