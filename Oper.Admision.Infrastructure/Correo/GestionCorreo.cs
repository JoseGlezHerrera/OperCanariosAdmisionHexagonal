
using Oper.Admision.Domain.Correo;
using Oper.Admision.Domain.Models;
using System.Net.Mail;

namespace Oper.Admision.Infrastructure.Correo
{
    public class GestionCorreo : IGestionCorreo
    {
        private string usuario;
        private SmtpClient gestorEmail;

        public string[] Destinatarios { get; set; }

        public GestionCorreo(IConfigCorreo configuracion)
        {
            if (configuracion != null)
            {
                try
                {

                    this.gestorEmail = new SmtpClient(configuracion.Servidor);
                    this.gestorEmail.DeliveryMethod = SmtpDeliveryMethod.Network;
                    this.gestorEmail.UseDefaultCredentials = false;
                    this.gestorEmail.EnableSsl = true;
                    this.gestorEmail.Port = configuracion.Puerto;
                    this.gestorEmail.Credentials = new System.Net.NetworkCredential(configuracion.Usuario, configuracion.Password);
                    this.Destinatarios = this.ObtenerDestinatarios(configuracion); //configCorreo.Destinatarios.Split(',');                                        
                    this.usuario = configuracion.Usuario;
                }
                catch (Exception error)
                {
                    throw new Exception("El correo no está configurado.", error);
                }
            }
            else
            {
                throw new Exception("El correo no está configurado.");
            }
        }

        private string[] ObtenerDestinatarios(IConfigCorreo configuracion)
        {
            var destinatariosResponsables = configuracion.Destinatarios.Split(',');
            var destinatarios = configuracion.Destinatarios.Split(',');
            return destinatariosResponsables.Concat(destinatarios).ToArray();
        }

        public string Enviar(string cabecera, string mensaje)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(this.usuario);
                mail.IsBodyHtml = true;
                foreach (string destinario in this.Destinatarios)
                {
                    mail.To.Add(destinario);
                }
                mail.Subject = cabecera;
                mail.Body = mensaje;
                this.gestorEmail.Send(mail);
                return string.Empty;
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }

        public string Enviar(string cabecera, string mensaje,string destinatario)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(this.usuario);
                mail.IsBodyHtml = true;
                mail.To.Add(destinatario);

                mail.Subject = cabecera;
                mail.Body = mensaje;
                this.gestorEmail.Send(mail);
                return string.Empty;
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }
    }

}

