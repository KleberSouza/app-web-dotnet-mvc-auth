using Coravel.Queuing.Interfaces;
using Microsoft.Extensions.Options;
using app_web_dotnet_mvc_auth.Models;
using System.Collections.Generic;

namespace app_web_dotnet_mvc_auth.Services
{
    public class MailerService : IMailerService
    {
        private readonly IQueue _queue;

        public MailerService(IQueue queue)
        {
            _queue = queue;
        }

        public void SendEmail(string name, string email, EmailType type, string content = null, object contentData = null)
        {
            var maill = new Mail
            {
                Name = name,
                EmailTo = email,
                EmailFrom = "seuEmail@gmail.com",
                EmailCc = new List<string>(),
            };

            switch (type)
            {
                case EmailType.ForgotPassword:
                    maill.Subject = "PUC Minas - Redefinição de senha";
                    maill.View = "~/Views/Mail/ForgotPassword.cshtml";
                    maill.Content = content;
                    break;
               
            }

           _queue.QueueInvocableWithPayload<SendEmailInvocable, Mail>(maill);
        }
    }
}
