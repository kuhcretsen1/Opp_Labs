using System.Net.Mail;

namespace Biblioteka.Services
{
    public interface IEmailService
    {
        public void Send(string to, string subject, string body);
    }
}
