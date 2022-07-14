using Core.DataAcces.Concrete;
using Core.entities.Concrete;
using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete.EntityFramework.Context;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Concrete.EntityFramework
{
    public class EfCompanyRepository : EfGenericRepository<Companies, ApplicationDbContext>, ICompanyDal
    {
        public void UserCompanyAdd(int companyid, int userId)
        {
            using (var context= new ApplicationDbContext())
            {
                var userCompany = new UserCompany
                {
                    CompanyId = companyid,
                    UserId = userId,
                    AddedTime = DateTime.Now,
                    IsActive = true
                };
                context.UserCompany.Add(userCompany);
                context.SaveChanges();
            }
            
            
        }
    }
}
