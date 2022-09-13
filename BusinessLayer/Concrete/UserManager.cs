using BusinessLayer.Abstract;
using BusinessLayer.Aspect;
using BusinessLayer.Constance;
using BusinessLayer.Validation_rules.FluentValidation;
using Core.Aspect.Validation;
using Core.entities.Concrete;
using Core.Utilities.Abstract;
using Core.Utilities.Concrete;
using DataAccesLayer.Abstract;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal userDal;

        public UserManager(IUserDal _userDal)
        {
            userDal = _userDal;
        }

        [ValidationAspect(typeof(UserValidator))]
        public void Add(User user)
        {
           
            userDal.add(user);
        }

        public IDataResult<User> GetById(int id)
        {
            var user= userDal.Getitem(x => x.Id == id);
            return  user is not null ? new SuccesDataResult<User>(user) : new ErrorDataResult<User>(Constances.UserNotFOund);
        }

        public User GetByMail(string email)
        {
            var user = userDal.Getitem(x => x.Email == email);
            return user;
            
        }

        public User GetByMailConfirmValue(string value)
        {
            return userDal.Getitem(x => x.MailConfirmValue == value);
        }

        public List<OperationClaim> GetClaims(User user,int companyId)
        {
            return userDal.GetClaims(user, companyId);
        }
        [SecuredOperations("User.crud")]
        public IResult Update(User user)
        {
            userDal.Update(user);
            return new SuccessResult(Constances.MailConfirmed);
        }   
    }
}
