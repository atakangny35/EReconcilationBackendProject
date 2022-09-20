using BusinessLayer.Abstract;
using Core.entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EReconcilationUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOperationClaimController : ControllerBase
    {
        private readonly IUserOperationClaimService userOperationClaimService;

        public UserOperationClaimController(IUserOperationClaimService _userOperationClaimService)
        {
            userOperationClaimService = _userOperationClaimService;
        }

        [HttpPost("add")]
        public IActionResult Add(UserOperationClaim operationClaimsAddDto)
        {
            var result = userOperationClaimService.Add(operationClaimsAddDto);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPut("update")]
        public IActionResult Update(UserOperationClaim operationClaimsUpdateDto)
        {
            var result = userOperationClaimService.Update(operationClaimsUpdateDto);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("delete")]
        public IActionResult Delete(int id)
        {
            var result = userOperationClaimService.Delete(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = userOperationClaimService.getById(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getlistdto")]
        public IActionResult GetListDto(int userid,int companyid)
        {
            var result = userOperationClaimService.GetListDto(userid,companyid);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
