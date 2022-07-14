using BusinessLayer.Abstract;
using EntityLayer.DTOs.AccountReconcillation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EReconcilationUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountReconcilationController : ControllerBase
    {
        private readonly IAccountReconcillationService accountReconcillationService;

        public AccountReconcilationController(IAccountReconcillationService _accountReconcillationService)
        {
            accountReconcillationService = _accountReconcillationService;
        }
        [HttpPost("addFromExcel")]
        public IActionResult AddFromExcel(IFormFile file, int Companyid)
        {
            if (file.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + ".xlsx";

                var FilePath = $"{ Directory.GetCurrentDirectory()}/Content/{fileName}";

                using (FileStream stream = System.IO.File.Create(FilePath))
                {
                    file.CopyTo(stream);
                    stream.Flush();
                }

                var result = accountReconcillationService.AddToExcel(FilePath, Companyid);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result.Message);
            }
            return BadRequest("Dosya Seçimi yapmadınız");
        }

        [HttpPost("add")]
        public IActionResult Add(AccountReconcillationAddDto accountReconcillationAddDto)
        {
           var result= accountReconcillationService.Add(accountReconcillationAddDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPut("update")]
        public IActionResult Update(AccountReconcillationUpdateDto accountReconcillationUpdateDto)
        {
            var result = accountReconcillationService.Update(accountReconcillationUpdateDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("delete")]
        public IActionResult Update(int  id)
        {
            var result = accountReconcillationService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = accountReconcillationService.getById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getlist")]
        public IActionResult GetList(int companyid)
        {
            var result = accountReconcillationService.GetList(companyid);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
