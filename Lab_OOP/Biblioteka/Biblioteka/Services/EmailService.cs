using System.Net;
using System.Net.Mail;

namespace Biblioteka.Services
{
    public class EmailService : IEmailService
    {
        private readonly SmtpClient _smtpClient;

        public EmailService()
        {
            _smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("anastasiia.havrylchyk@oa.edu.ua", "szjd jwrr hxhb sfnx"),
                EnableSsl = true
            };
        }

        public void Send(string to, string subject, string body)
        {
            try
            {
                var mailMessage = new MailMessage
                {
                    From = new MailAddress("anastasiia.havrylchyk@oa.edu.ua"),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };

                mailMessage.To.Add(to);

                Console.WriteLine("Attempting to send email...");
                _smtpClient.Send(mailMessage);
                Console.WriteLine("Email sent successfully.");
            }
            catch (SmtpException ex)
            {
                Console.WriteLine($"SMTP error: {ex.StatusCode} - {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                throw;
            }
            }
        }
}