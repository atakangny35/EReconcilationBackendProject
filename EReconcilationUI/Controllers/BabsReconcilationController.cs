using BusinessLayer.Abstract;
using EntityLayer.DTOs.BaBsReconculation;
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
    public class BabsReconcilationController : ControllerBase
    {
        private readonly IBabsReconcilationService  babsReconcilationService;

        public BabsReconcilationController(IBabsReconcilationService _babsReconcilationService)
        {
            babsReconcilationService = _babsReconcilationService;
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

                var result = babsReconcilationService.AddToExcel(FilePath, Companyid);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result.Message);
            }
            return BadRequest("Dosya Seçimi yapmadınız");
        }

        [HttpPost("add")]
        public IActionResult Add(BabsReconcilationAddDto  babsReconcilationAddDto)
        {
            var result = babsReconcilationService.Add(babsReconcilationAddDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPut("update")]
        public IActionResult Update(BabsReconcilationUpdateDto  babsReconcilationUpdateDto)
        {
            var result = babsReconcilationService.Update(babsReconcilationUpdateDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("delete")]
        public IActionResult Update(int id)
        {
            var result = babsReconcilationService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = babsReconcilationService.getById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getlist")]
        public IActionResult GetList(int companyid)
        {
            var result = babsReconcilationService.GetList(companyid);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
