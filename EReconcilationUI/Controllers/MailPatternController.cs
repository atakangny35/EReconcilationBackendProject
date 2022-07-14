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
    public class MailPatternController : ControllerBase
    {
        private readonly IMailPatternService mailPatternService;

        public MailPatternController(IMailPatternService _mailPatternService)
        {
            mailPatternService = _mailPatternService;
        }

        [HttpPost]
        public IActionResult Add(MailPattern mailPattern)
        {
            var result = mailPatternService.add(mailPattern);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
