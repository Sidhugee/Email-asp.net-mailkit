using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace SimpleEmailApp.Models
{
    public class GernalFunction
    {
                public static bool EmailSent(string EmailBody, string Subject, string ToEmail = null,  List<string> CCEmail = null, List<string> BCCEmail = null)
        {
            bool Status = false;
            
            string From = "sallalhaider18@gmail.com";
            string Password = "Imsumiya18;";

            
            string Host = "smtp.gmail.com";
            int Port = 587;
            try
            {
                var message = new MailMessage();
                //message.To.Add(ToEmail);
                if (ToEmail != null)
                {
                    //foreach (var to in ToEmail)
                    //{
                       message.To.Add(new MailAddress("sallalhaider8@gmail.com"));
                    //}
                }
                if (CCEmail != null)
                {
                    foreach (var CC in CCEmail)
                    {
                        message.CC.Add(new MailAddress(CC));
                    }
                }
                if (BCCEmail != null)
                {
                    foreach (var BCC in BCCEmail)
                    {
                        message.Bcc.Add(new MailAddress(BCC));
                    }
                }
                message.From = new MailAddress(From, "goseek");  // replace with valid value
                message.Headers.Add("Content-Type", "multipart/mixed;");
                message.Subject = Subject;
                message.Body = EmailBody;
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.SubjectEncoding = System.Text.Encoding.Default;
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient(Host, Port))
                {
                    var credential = new NetworkCredential
                    {
                        UserName = From,
                        Password = Password
                    };
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = credential;
                    //smtp.Host = Host;
                    //smtp.Port = Port;

                    smtp.EnableSsl = true;
                    smtp.Send(message);
                    Status = true;
                }
            }
            catch (Exception ex)
            {
                Status = false;
                throw ex;
            }
            return Status;
        }
    }
}