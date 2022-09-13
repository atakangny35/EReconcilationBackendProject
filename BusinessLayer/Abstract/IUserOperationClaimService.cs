using Core.entities.Concrete;
using Core.Utilities.Abstract;
using EntityLayer.DTOs.OperationClaims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IUserOperationClaimService
    {
        IResult Add(UserOperationClaim UserOperationClaim);
        IResult Update(UserOperationClaim UserOperationClaim);
        IResult Delete(int id);
        IDataResult<UserOperationClaim> getById(int id);
        IDataResult<List<UserOperationClaim>> GetList( int currencyAccoundId,int companyId);
        IDataResult<List<UserOperationClaimDto>> GetListDto(int userid, int companyId);
    }
}
