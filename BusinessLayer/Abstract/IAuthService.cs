using Core.entities.Concrete;
using Core.Utilities.Abstract;
using Core.Utilities.Security.JWT;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IAuthService
    {
        IDataResult<UserwithCompanyDto> Register(UserRegisterModel model,string Password,Companies company);
        IDataResult<User> RegisterAccount(UserRegisterModel model,string Password,int companyId);
        IDataResult<User> Login(UserLoginModel model);
        IResult UserExists(string email);
        IResult CompanyExists(Companies company);
        IDataResult<AccessToken> CreateAccesToken(User user,int companyId);
        IResult SendConfirm(User user);
    }

  
}
