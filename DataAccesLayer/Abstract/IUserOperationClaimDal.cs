using Core.DataAcces.Abstract;
using Core.entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Abstract
{
    public interface IUserOperationClaimDal:IGenericDal<UserOperationClaim>
    {
        List<UserOperationClaim> GetClaims(int userId, int companyId);
    }
}
