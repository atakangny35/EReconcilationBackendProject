using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EReconcilationUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailParameterController : ControllerBase
    {
        private IMailParameterService mailParameterService;

        public MailParameterController(IMailParameterService _mailParameterService)
        {
            mailParameterService = _mailParameterService;
        }
        [HttpPost("update")]
        public IActionResult MailParameter(MailParameter mailParameter)
        {
            var result = mailParameterService.Update(mailParameter);

            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
