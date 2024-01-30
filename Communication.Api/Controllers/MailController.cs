using Communication.Api.Infra.Services;
using Communication.Api.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Communication.Api.Controllers
{

    [Route("api/mails")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IMailService _mailService;
        public MailController(IMailService mailService)
        {
            _mailService = mailService;
        }

        [HttpPost]
        public IActionResult SendMail([FromBody] UserRequest request)
        {
            try
            {
                _mailService.SendMail(request);
            }
            catch
            {
                return StatusCode(500);
            }

            return Ok();
        }
    }
}
