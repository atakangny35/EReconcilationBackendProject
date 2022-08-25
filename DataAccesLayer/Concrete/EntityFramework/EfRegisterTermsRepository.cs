using Core.DataAcces.Concrete;
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
    public class EfRegisterTermsRepository: EfGenericRepository<RegisterTerms, ApplicationDbContext>,IRegisterTermsDal
    {
    }
}
