using BusinessLayer.Abstract;
using BusinessLayer.Constance;
using Core.entities.Concrete;
using Core.Utilities.Abstract;
using Core.Utilities.Concrete;
using DataAccesLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserOperationClaimManager : IUserOperationClaimService
    {

        private readonly IUserOperationClaimDal _userOperatClaimDal;

        public UserOperationClaimManager(IUserOperationClaimDal userOperatClaimDal)
        {
            _userOperatClaimDal = userOperatClaimDal;
        }

        public IResult Add(UserOperationClaim UserOperationClaim)
        {
           _userOperatClaimDal.add(UserOperationClaim);
            return new SuccessResult(Constances.AddedCompany);
        }

        public IResult Delete(int id)
        {

            _userOperatClaimDal.Delete(_userOperatClaimDal.Getitem(x=>x.Id==id));
            return new SuccessResult(Constances.EntityDeleted);
        }

        public IDataResult<UserOperationClaim> getById(int id)
        {
           
            return new SuccesDataResult<UserOperationClaim>(_userOperatClaimDal.Getitem(x => x.Id == id));
        }

        public IDataResult<List<UserOperationClaim>> GetList(int userId, int companyId)
        {
           return new SuccesDataResult<List<UserOperationClaim>>(_userOperatClaimDal.GetClaims(userId, companyId));
        }

        public IResult Update(UserOperationClaim UserOperationClaim)
        {
            _userOperatClaimDal.Update(UserOperationClaim);
            return new SuccessResult(Constances.EntityUpdated);
        }
    }
}
