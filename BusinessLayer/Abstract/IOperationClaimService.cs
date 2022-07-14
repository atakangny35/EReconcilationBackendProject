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
    public interface IOperationClaimService
    {
        IResult Add(OperationClaimsAddDto operationClaim);    
        IResult Update(OperationClaimsUpdateDto operationClaim);
        IResult Delete(int id);
        IDataResult<OperationClaim> getById(int id);

        IDataResult<List<OperationClaim>> GetList();
    }
}
