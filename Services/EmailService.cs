using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Services
{
    public class EmailService
    {
        public async Task<bool> SendEmailAsync(Email _emailData)
        {
            if (_emailData is null)
                return false;
            try
            {
                using (var message = new MailMessage())
                {
                    message.To.Add(new MailAddress(_emailData.ToEmail));

                    if (!string.IsNullOrEmpty(_emailData.SenderEmail))
                    {
                        message.From = new MailAddress(_emailData.SenderEmail, "Admin");
                    }
                    else
                    {
                        // If fromEmail is not provided, use the default SMTP credentials.
                       // message.From = new MailAddress(_username, fromName);
                    }

                    message.Subject = _emailData.Subject;
                    message.Body = _emailData.Body;
                    message.IsBodyHtml = true;

                    using (var smtpClient = new SmtpClient(_emailData.SmtpHost, _emailData.SmtPort))
                    {
                        smtpClient.UseDefaultCredentials = false;
                        smtpClient.Credentials = new NetworkCredential(_emailData.SenderEmail,
                            _emailData.Password);
                        smtpClient.EnableSsl = true;
                        await smtpClient.SendMailAsync(message);
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending email: " + ex.Message);
                return false;
            }



        }

    }
}
