using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace ReportesIncidentes.BL
{
    public static class Utilitarios
    {
        /// <summary>
        /// Método que genera los códigos de actctivación 
        /// </summary>
        /// <returns></returns>
        public static int GenerarCodigoActivacion()
        {
            Random rdn = new Random();
            return rdn.Next(999999);
        }

        public static void EnviarEmail(string correo, string nombre, string apellidos, int codigoActivacion)
        {
            var fromAddress = new MailAddress(CifradoAES.DescifrarAES(Configuracion.Leer("EmailApp")), Configuracion.Leer("NombreApp"));
            StringBuilder nombreCompleto = new StringBuilder();
            nombreCompleto.Append(nombre);
            nombreCompleto.Append(" ");
            nombreCompleto.Append(apellidos);
            var toAddress = new MailAddress(correo, nombreCompleto.ToString());
            string fromPassword = CifradoAES.DescifrarAES(Configuracion.Leer("Contrasena"));
            byte[] bytesSubject= Encoding.UTF8.GetBytes(Configuracion.Leer("AsuntoCorreo"));
            string subject = Encoding.UTF8.GetString(bytesSubject);
            byte[] bytesMensaje = Encoding.UTF8.GetBytes(Configuracion.Leer("MensajeCorreo"));
            string body = string.Format(Encoding.UTF8.GetString(bytesMensaje),nombreCompleto.ToString(),codigoActivacion);
            

            var smtp = new SmtpClient
            {
                Host = Configuracion.Leer("ServidorCorreo"),
                Port = Convert.ToInt32(Configuracion.Leer("Puerto")),
                EnableSsl = Convert.ToBoolean(Configuracion.Leer("Ssl")),
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = Convert.ToBoolean(Configuracion.Leer("CredencialesDefecto")),
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                SubjectEncoding = System.Text.Encoding.UTF8,
                Body = body,
                BodyEncoding=System.Text.Encoding.UTF8
            })
            {
                smtp.Send(message);
            }
        }
    }
}
