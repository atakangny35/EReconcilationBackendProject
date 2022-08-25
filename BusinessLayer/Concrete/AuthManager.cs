using BusinessLayer.Abstract;
using BusinessLayer.Constance;
using BusinessLayer.Validation_rules.FluentValidation;
using Core.Aspect.Transaction;
using Core.entities.Concrete;
using Core.Utilities.Abstract;
using Core.Utilities.Concrete;
using Core.Utilities.Hashing;
using Core.Utilities.Security.JWT;
using Core.Validations.FluentValidation;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService userService;
        private readonly ITokenHelper  tokenHelper;
        private readonly ICompanyService  companyService;
        private readonly IMailParameterService   mailParameterService;
        private readonly IMailService   mailService;
        private readonly IMailPatternService mailPatternService;
        public AuthManager(IUserService _userService, ITokenHelper _tokenHelper, ICompanyService _companyService, 
            IMailParameterService _mailParameterService, IMailService _mailService, IMailPatternService _mailPatternService)
        {
            userService = _userService;
            tokenHelper = _tokenHelper;
            companyService = _companyService;
            mailParameterService = _mailParameterService;
            mailService = _mailService;
            mailPatternService = _mailPatternService;

        }

        public IResult CompanyExists(Companies company)
        {
            var result = companyService.CompanyExists(company);
            return result.Success ==false ? new ErrorResult(Constances.CompanyExists) : new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccesToken(User user,int companyId)
        {
            var claims = userService.GetClaims(user, companyId);
            var accessToken = tokenHelper.CreateToken(user, claims, companyId);
            return new SuccesDataResult<AccessToken>(accessToken);
        }

        public IDataResult<User> Login(UserLoginModel model)
        {
            var userCheck = userService.GetByMail(model.Email);
            if (userCheck is null)
            {
                return new ErrorDataResult<User>(Constances.UserNotFOund);
                
            }
            if (!HashingHelper.VerifyPasswordHash(model.Password, userCheck.PasswordHash, userCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Constances.WrongPassword);
            }
            //var token = CreateAccesToken(userCheck,)
            return new SuccesDataResult<User>(userCheck, Constances.SuccessLogin);
        }
        [TransactionScopeAspect]
        
        public IDataResult<UserwithCompanyDto> Register(UserRegisterModel model, string Password, Companies company)
        {
            


            byte[] passwordSalt, passwordHash;
            HashingHelper.CreatePasswordHash(Password, out passwordHash, out passwordSalt);
            User user = new User()
            {
                Email = model.Email,
                AddedTime = DateTime.Now,
                IsActive = true,
                MailConfirm = false,
                MailCOnfirmDate = DateTime.Now,
                MailConfirmValue = Guid.NewGuid().ToString(),
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Name = model.Name

            };
            //ValidationTool.Validate(user,new UserValidator());
            userService.Add(user);
            companyService.Add(company);
            companyService.UserCompanyAdd(company.Id, user.Id);
            var usercompanydto = new UserwithCompanyDto ()
            {
                Id=user.Id,
                MailCOnfirmDate=user.MailCOnfirmDate,
                AddedTime=user.AddedTime,
                Email=user.Email,
                IsActive=user.IsActive,
                MailConfirm=user.MailConfirm,
                MailConfirmValue=user.MailConfirmValue,
                Name=user.Name,
                PasswordHash=user.PasswordHash,
                PasswordSalt=user.PasswordSalt,               
                Companyid=company.Id
            };

            //SendConfirmEmail(user);
            return new SuccesDataResult<UserwithCompanyDto>(usercompanydto, Constances.UserRegistered);
        }

        void SendConfirmEmail(User user)
        {
            string Link = "https://localhost:44319/api/Auth/userconfirm?value=" + user.MailConfirmValue;
            string LinkDescription = "Kayıt onayı için tıklayınız";
            var mailTemplate = mailPatternService.GetitembyName("register", 1);
            string body = mailTemplate.Data.Value;
            body = body.Replace("{{title}}", "Kullanıcı Onayı");
            body = body.Replace("{{titleMessage}}", "Kayıt işlemini tamamlamak içi aşağıdaki adımları takip ediniz");
            body = body.Replace("{{message}}", "Sayın " + user.Name + " Sistem kaydı başarılı,Kaydını onaylamak için aşağıdaki linke tıklayınız.");
            body = body.Replace("{{linkDescription}}", LinkDescription);
            body = body.Replace("{{link}}", Link);
            var mailParameter = mailParameterService.Get(1);
            SendMailDto sendMailDto = new SendMailDto()
            {
                mailParameter = mailParameter.Data,
                email = user.Email,
                subject = "Kullanıcı Kayıt Onayı",
                body = body
            };
            mailService.SendMail(sendMailDto);
            user.MailCOnfirmDate = DateTime.Now;
            userService.Update(user);
        }

        public IDataResult<User> RegisterAccount(UserRegisterModel model, string Password,int companyId)
        {
            byte[] passwordSalt, passwordHash;
            HashingHelper.CreatePasswordHash(Password, out passwordHash, out passwordSalt);
            User user = new User()
            {
                Email = model.Email,
                AddedTime = DateTime.Now,
                IsActive = true,
                MailConfirm = false,
                MailCOnfirmDate = DateTime.Now,
                MailConfirmValue = Guid.NewGuid().ToString(),
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Name = model.Name

            };
            userService.Add(user);
            companyService.UserCompanyAdd(companyId, user.Id);
            SendConfirmEmail(user);
            return new SuccesDataResult<User>(user, Constances.UserRegistered);
        }

        public IResult UserExists(string email)
        {
            if(userService.GetByMail(email)is not null)
            {
                return new ErrorResult(Constances.UserExists);
            }
            
            return new SuccessResult();
        }

        public IResult SendConfirm(User user)
        {
            if (user.MailConfirm==true)
            {
                return new ErrorResult(Constances.UserAlreadyConfirmed);
            }
            if (user.MailCOnfirmDate.ToShortDateString()==DateTime.Now.ToShortDateString())
            {
                if (user.MailCOnfirmDate.Hour==DateTime.Now.Hour&& user.MailCOnfirmDate.AddMinutes(5).Minute<=DateTime.Now.Minute)
                {
                    SendConfirmEmail(user);
                    return new SuccessResult(Constances.MailConfirmEmailSend);
                }
                return new ErrorResult(Constances.MailJustSended);
            }
            else
            {
                SendConfirmEmail(user);
                return new SuccessResult(Constances.MailConfirmEmailSend);
            }
        }
    }
}
