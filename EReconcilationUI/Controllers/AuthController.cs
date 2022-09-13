using BusinessLayer.Abstract;
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
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;
        private readonly IUserService userService;
        private readonly ICompanyService companyService;

        public AuthController(IAuthService _authService, IUserService _userService, ICompanyService _companyService)
        {
            authService = _authService;
            userService = _userService;
            companyService = _companyService;
        }
        [HttpPost]
        public IActionResult Register(UserRegisterModelWithCompanyDto modelWithCompanyDto)
          
        {
            

            var registerModel = modelWithCompanyDto.UserRegisterModel;
            var company = modelWithCompanyDto.company;
            var userExists = authService.UserExists(registerModel.Email);
            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }
            var CompanyExists = authService.CompanyExists(company);
            if (!CompanyExists.Success)
            {
                return BadRequest(CompanyExists.Message);
            }
            var registerResult = authService.Register(registerModel, registerModel.Password,company);
            var token = authService.CreateAccesToken(registerResult.Data,registerResult.Data.Companyid,company.Name);
            if (registerResult.Success)
            {
                return Ok(token);
            }
            return BadRequest(registerResult.Message);
        }
        [HttpPost("RegisterAccount")]
        public IActionResult RegisterAccount(UserRegisterModelWithCompanyId userRegisterModel)
        {
            var userExists = authService.UserExists(userRegisterModel.Email);
            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }
            UserRegisterModel registerModel = new UserRegisterModel { Email = userRegisterModel.Email, Name = userRegisterModel.Name, Password = userRegisterModel.Password };
            var company = companyService.GetById(userRegisterModel.companyId);
            var registerResult = authService.RegisterAccount(registerModel, userRegisterModel.Password,userRegisterModel.companyId);
            var token = authService.CreateAccesToken(registerResult.Data, userRegisterModel.companyId,company.Data.Name);
            if (registerResult.Success)
            {
                return Ok(token);
            }
            return BadRequest(registerResult.Message);
        }
        [HttpPost("Login")]
        public IActionResult Login(UserLoginModel loginModel)
        {
            var user = authService.Login(loginModel);

            if(!user.Success)
            {
                return BadRequest(user.Message);
            }          
            else if (user.Data.IsActive == false)
            {
                return BadRequest("Kullanıcı onayı gerçekleştirilmeli yöneticinize başvurunuz");
            }
            var userCompanywithCompanyId = companyService.GetUserCompanywithcompanyName(user.Data.Id);
            var tokenResult = authService.CreateAccesToken(user.Data, userCompanywithCompanyId.Data.userCompany.CompanyId,userCompanywithCompanyId.Data.CompanyName);

            if (tokenResult.Success)
            {
                return Ok(tokenResult.Data);
            }
            return BadRequest(user.Message);
        }

        [HttpGet("userConfirm")]
        public IActionResult UserConfirm(string value)
        { var result = userService.GetByMailConfirmValue(value);
            result.MailConfirm = true;
            result.MailCOnfirmDate = DateTime.Now;
           var dataResult= userService.Update(result);
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult.Message);
        }

        [HttpPost("sendconfirmmail")]
        public IActionResult SendConfirmEmail(string emaillll)
        {
            var user = userService.GetByMail(emaillll);
            var resultuser = userService.GetById(user.Id);

            if (!resultuser.Success)
            {
                return BadRequest(resultuser.Message);
            }
            var dataResult = authService.SendConfirm(resultuser.Data);
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult.Message);
        }
    }

}
