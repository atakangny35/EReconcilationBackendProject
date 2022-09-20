using Core.DataAcces.Concrete;
using Core.entities.Concrete;
using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete.EntityFramework.Context;
using EntityLayer.DTOs.UserCompany;
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

        public List<UserCompanyListDto> GetUserCompanyList(int company)
        {
            using(var context =new ApplicationDbContext())
            {
                var result = from uc in context.UserCompany.Where(p => p.CompanyId == company && p.IsActive == true)
                             join u in context.Users
                             on uc.UserId equals u.Id
                             select new UserCompanyListDto
                             {
                                 UserAddedTime = u.AddedTime,
                                 CompanyId = company,
                                 Email = u.Email,
                                 UserIsActive = u.IsActive,
                                 Name = u.Name,
                                 Id = uc.Id,
                                 UserId = u.Id,
                             };
                return result.OrderBy(x=>x.Name).ToList();
                              
            }
        }
    }
}
