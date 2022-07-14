using BusinessLayer.Abstract;
using EntityLayer.DTOs.AccountReconcilationDetail;
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
    public class AccountReconcillationsDetailController : ControllerBase
    {
        private readonly IAccountReconcillationsDetailService accountReconcillationsDetailService;

        public AccountReconcillationsDetailController(IAccountReconcillationsDetailService _accountReconcillationsDetailService)
        {
            accountReconcillationsDetailService = _accountReconcillationsDetailService;
        }

        [HttpPost("add")]
        public IActionResult Add(AccountReconcilationDetailAddDto accountReconcilationDetailAddDto)
        {
           var result= accountReconcillationsDetailService.Add(accountReconcilationDetailAddDto);

            if (result.Success)
            {
                return Ok();
            }
            return BadRequest(result.Message);
        }
        [HttpPut("update")]
        public IActionResult Update(AccountReconcilationDetailUpdateDto  accountReconcilationDetailUpdateDto)
        {
            var result = accountReconcillationsDetailService.Update(accountReconcilationDetailUpdateDto);

            if (result.Success)
            {
                return Ok();
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = accountReconcillationsDetailService.GetById(id);

            if (result.Success)
            {
                return Ok();
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getlist")]
        public IActionResult GetList(int masterseq)
        {
            var result = accountReconcillationsDetailService.GetList(masterseq);

            if (result.Success)
            {
                return Ok();
            }
            return BadRequest(result.Message);
        }
        [HttpPost("addFromExcel")]
        public IActionResult AddFromExcel(IFormFile file, int masterseq)
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

                var result = accountReconcillationsDetailService.AddToExcel(FilePath, masterseq);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result.Message);
            }
            return BadRequest("Dosya Seçimi yapmadınız");
        }

    }
}

