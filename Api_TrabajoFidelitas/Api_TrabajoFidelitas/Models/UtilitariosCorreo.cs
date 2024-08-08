﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace Api_TrabajoFidelitas.Models
{
    public class UtilitariosCorreo
    {
        public void EnviarCorreo(string destino, string asunto, string contenido)
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress(ConfigurationManager.AppSettings["correoElec"]);
            message.To.Add(new MailAddress(destino));
            message.Subject = asunto;
            message.Body = contenido;
            message.Priority = MailPriority.Normal;
            message.IsBodyHtml = true;

            SmtpClient client = new SmtpClient("smtp.office365.com", 587);
            client.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["correoElec"],
                                                                  ConfigurationManager.AppSettings["passElec"]);
            client.EnableSsl = true;

            client.Send(message);
        }
    }
}