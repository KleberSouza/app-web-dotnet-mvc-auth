using app_web_dotnet_mvc_auth.Models;

namespace app_web_dotnet_mvc_auth.Services
{
    public interface IMailerService
    {
        void SendEmail(string name, string email, EmailType type, string content = null, object contentData = null);
    }
}
