using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
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
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService companyService;
        public CompanyController(ICompanyService _companyService, ICompanyDal companyDal)
        {
            companyService = _companyService;

        }
        [HttpGet]
       public IActionResult GetCompanyList()
        {
           var result = companyService.GetList();
           if (result.Success)
            {
               return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("GetCompany")]
        public IActionResult GetCompany(int id)
        {
            var result = companyService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("addcompanyandusercompany")]
        public IActionResult addcompanyandusercompany(CompaniesWithUserDto companyDTo)
        {
            var result = companyService.AddCompanyAndUserCompany(companyDTo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost]
        public IActionResult addcompany(Companies company)
        {
            var result = companyService.Add(company);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPut]
        public IActionResult Update(UpdateCompanyDto company)
        {
            var result = companyService.Update(company);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }
}
