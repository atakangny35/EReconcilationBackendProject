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
  public class EfOperationClaimRepository:EfGenericRepository<OperationClaim,ApplicationDbContext>, IOperationClaimDal
    {

    }
}
