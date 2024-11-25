using Coravel.Mailer.Mail;
using app_web_dotnet_mvc_auth.Models;


namespace app_web_dotnet_mvc_auth.Services
{
    public class NewMailable : Mailable<Mail>
    {
        private readonly Mail _email;

        public NewMailable(Mail email)
        {
            _email = email;
        } 

        public override void Build()
        {            
            this.To(new MailRecipient(_email.EmailTo, _email.Name))
                .From(new MailRecipient(_email.EmailFrom, "PUC Minas"))
                .Cc(_email.EmailCc)
                .Subject(_email.Subject)
                .View(_email.View, this._email);
        }
    }
}
