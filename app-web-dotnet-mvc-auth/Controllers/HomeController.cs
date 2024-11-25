using app_web_dotnet_mvc_auth.Models;
using app_web_dotnet_mvc_auth.Services;
using Coravel.Mailer.Mail.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace app_web_dotnet_mvc_auth.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMailerService _emailService;

        public HomeController(ILogger<HomeController> logger, IMailerService emailService)
        {
            _logger = logger;
            _emailService = emailService;
        }

        public IActionResult ForgotPassword()
        {
            try
            {
                var newPassword = Guid.NewGuid().ToString().Replace("-", "")[..10];

                // SEND EMAIL TO USER
                _emailService.SendEmail("Nome", "emailDeDetino@gmail.com", EmailType.ForgotPassword, newPassword);

                return Ok("Email enviado com sucesso!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao enviar email");
                return StatusCode(500, "Erro ao enviar email");
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
