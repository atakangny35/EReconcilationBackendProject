using BusinessLayer.Abstract;
using EntityLayer.DTOs.AccountReconcilationDetail;
using EntityLayer.DTOs.BabsReconcilationDetail;
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
    public class BabsReconcilationDetailController : ControllerBase
    {
        private readonly IBabsReconcilationDetailService  babsReconcilationDetailService;

        public BabsReconcilationDetailController(IBabsReconcilationDetailService _babsReconcilationDetailService)
        {
            babsReconcilationDetailService = _babsReconcilationDetailService;
        }

        [HttpPost("add")]
        public IActionResult Add(BabsReconcilationDetailAddDto  babsReconcilationDetailAddDto)
        {
            var result = babsReconcilationDetailService.Add(babsReconcilationDetailAddDto);

            if (result.Success)
            {
                return Ok();
            }
            return BadRequest(result.Message);
        }
        [HttpPut("update")]
        public IActionResult Update(BabsReconcilationDetailUpdateDto  babsReconcilationDetailUpdateDto)
        {
            var result = babsReconcilationDetailService.Update(babsReconcilationDetailUpdateDto);

            if (result.Success)
            {
                return Ok();
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = babsReconcilationDetailService.GetById(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getlist")]
        public IActionResult GetList(int masterseq)
        {
            var result = babsReconcilationDetailService.GetList(masterseq);

            if (result.Success)
            {
                return Ok(result);
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

                var result = babsReconcilationDetailService.AddToExcel(FilePath, masterseq);
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
