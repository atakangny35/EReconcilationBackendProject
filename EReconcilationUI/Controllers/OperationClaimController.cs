using BusinessLayer.Abstract;
using BusinessLayer.Constance;
using Core.entities.Concrete;
using Core.Utilities.Abstract;
using Core.Utilities.Concrete;
using EntityLayer.DTOs.OperationClaims;
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
    public class OperationClaimController : ControllerBase
    {
        private readonly IOperationClaimService operationClaimService;

        public OperationClaimController(IOperationClaimService _operationClaimService)
        {
            operationClaimService = _operationClaimService;
        }
        [HttpPost("add")]
        public IActionResult Add(OperationClaimsAddDto  operationClaimsAddDto)
        {
            var result = operationClaimService.Add(operationClaimsAddDto);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPut("update")]
        public IActionResult Update(OperationClaimsUpdateDto  operationClaimsUpdateDto)
        {
            var result = operationClaimService.Update(operationClaimsUpdateDto);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("delete")]
        public IActionResult Delete(int id)
        {
            var result = operationClaimService.Delete(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = operationClaimService.getById(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getList")]
        public IActionResult GetList()
        {
            var result = operationClaimService.GetList();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }
}
