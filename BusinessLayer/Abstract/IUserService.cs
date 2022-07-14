using Core.entities.Concrete;
using Core.Utilities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IUserService
    {
        List<OperationClaim> GetClaims(User user,int companyId);
        void Add(User user);
        IResult Update(User user);
        User GetByMail(string email);
        User GetByMailConfirmValue(string value);
        IDataResult<User>  GetById(int id);
    }
}
