using Coravel.Invocable;
using Coravel.Mailer.Mail.Interfaces;
using app_web_dotnet_mvc_auth.Models;

namespace app_web_dotnet_mvc_auth.Services
{
    public class SendEmailInvocable : IInvocable, IInvocableWithPayload<Mail>
    {
        public Mail Payload { get; set; }
        private readonly IMailer _mailer;

        public SendEmailInvocable(IMailer mailer)
        {
            _mailer = mailer;
        }

        public async Task Invoke()
        {
            await _mailer.SendAsync(new NewMailable(
            new Mail
            {
                Name = Payload.Name,
                EmailTo = Payload.EmailTo,
                EmailFrom = Payload.EmailFrom,
                Subject = Payload.Subject,
                Content = Payload.Content,
                ContentData = Payload.ContentData,
                URL = Payload.URL,
                View = Payload.View,
                EmailCc = Payload.EmailCc,
            }
            ));
        }
    }
}
