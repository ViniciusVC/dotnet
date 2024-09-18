using Microsoft.AspNetCore.Mvc;
using VVCDotNetMail.API.Infra.Services;
using VVCDotNetMail.API.ViewModels;

namespace VVCDotNetMail.API.Controllers
{
    [ApiController]
    [Route("api/mails")]
    public class MailController : ControllerBase
    {
        private readonly IMailService _mailService;

        public MailController(IMailService mailService)
        {
            _mailService = mailService;
        }

        [HttpPost]
        public IActionResult SendMail([FromBody] SendMailViewModels sendMailViewModels)
        {
            _mailService.SendMail(sendMailViewModels.Emails, sendMailViewModels.Subject, sendMailViewModels.Body, sendMailViewModels.IsHtml);
            return Ok();
        }
    }
}
