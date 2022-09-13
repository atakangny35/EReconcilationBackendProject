using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.DTOs.CurrencyAccount;
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
    public class CurrencyAccountController : ControllerBase
    {
        private readonly ICurrencyAccountService currencyAccountService;
        public CurrencyAccountController(ICurrencyAccountService _currencyAccountService)
        {
            currencyAccountService = _currencyAccountService;
        }

        [HttpPost("addFromExcel")]
        public IActionResult AddFromExcel(IFormFile file,int Companyid)
        {
            if (file.Length>0)
            {
                var fileName = Guid.NewGuid().ToString() + ".xlsx";

                var FilePath = $"{ Directory.GetCurrentDirectory()}/Content/{fileName}";

                using(FileStream stream = System.IO.File.Create(FilePath))
                {
                    file.CopyTo(stream);
                    stream.Flush();
                }

                var result = currencyAccountService.AddToExcel(FilePath, Companyid);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result.Message );
            }
            return BadRequest("Dosya Seçimi yapmadınız");
        }


        [HttpPost("add")]
        public IActionResult Add(CurrencyAccoundAddDto  currencyAccoundAddDto)
        {
            var result = currencyAccountService.Add(currencyAccoundAddDto);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPut("update")]
        public IActionResult Update(CurrencyAccount currencyAccount)
        {
            var result = currencyAccountService.Update(currencyAccount);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var result = currencyAccountService.Delete(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = currencyAccountService.Get(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getList")]
        public IActionResult GetList(int companyid)
        {
            var result = currencyAccountService.GeList(companyid);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
