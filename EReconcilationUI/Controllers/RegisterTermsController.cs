using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EReconcilationUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterTermsController : ControllerBase
    {
        private readonly IRegisterTermsService _registerTermsService;

        public RegisterTermsController(IRegisterTermsService registerTermsService)
        {
            _registerTermsService = registerTermsService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var result = _registerTermsService.GetData();
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }
        [HttpPut]
        public IActionResult Update(RegisterTerms registerTerms)
        {
            var result = _registerTermsService.Update(registerTerms);
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }
    }
}
