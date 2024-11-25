using System.Collections.Generic;

namespace app_web_dotnet_mvc_auth.Models
{
    public class Mail
    {
        public string Name { get; set; }
        public string EmailTo { get; set; }
        public string EmailFrom { get; set; }
        public List<string> EmailCc { get; set; }
        public string Subject { get; set; }
        public string View { get; set; }
        public string Content { get; set; }
        public string URL { get; set; }
        public object ContentData { get; set; }
    }
}
