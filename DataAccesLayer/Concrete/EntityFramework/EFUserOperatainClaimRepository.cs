using Core.DataAcces.Concrete;
using Core.entities.Concrete;
using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete.EntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Concrete.EntityFramework
{
    public class EFUserOperatainClaimRepository : EfGenericRepository<UserOperationClaim, ApplicationDbContext>, IUserOperationClaimDal
    {

        public List<UserOperationClaim> GetClaims(int userId, int companyId)
        {
            using (var context = new ApplicationDbContext())
            {
                var result = from opc in context.OperationClaim
                             join uopc in context.UserOperationClaim
                             on opc.Id equals uopc.OperationClaimId
                             join u in context.Users
                             on uopc.Userid equals u.Id
                             where uopc.CompanyId == companyId && u.Id == userId
                             select uopc;

                return result.ToList();
            }
        }
    }
}
