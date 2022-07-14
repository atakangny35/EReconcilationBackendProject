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
    public class EfUserRepository : EfGenericRepository<User, ApplicationDbContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user, int company)
        {
            using (var context =new ApplicationDbContext())
            {
                var result = from opc in context.OperationClaim
                             join uopc in context.UserOperationClaim
                             on opc.Id equals uopc.OperationClaimId
                             where uopc.CompanyId == company && uopc.Userid == user.Id
                             select new OperationClaim
                             {
                                 Id = opc.Id,
                                 Name = opc.Name
                             };

                return result.ToList();             
            }
        }
    }
}
