using BusinessLayer.Abstract;
using BusinessLayer.Constance;
using Core.Aspect.Caching.Concrete;
using Core.Utilities.Abstract;
using Core.Utilities.Concrete;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MailPatternManger : IMailPatternService
    {
        private readonly IMailPatternDal mailPatternDal;

        public MailPatternManger(IMailPatternDal _mailPatternDal)
        {
            mailPatternDal = _mailPatternDal;
        }

        [RemoveCacheAspect("IMailPatternService.Get")]
        public IResult add(MailPattern entity)
        {
            mailPatternDal.add(entity);
            return new SuccessResult(Constances.GeneralSuccess);

        }
        [RemoveCacheAspect("IMailPatternService.Get")]
        public IResult Delete(MailPattern entity)
        {
            mailPatternDal.Delete(entity);
            return new SuccessResult(Constances.GeneralSuccess);
        }

        [CacheAspect(60)]
        public IDataResult<List<MailPattern>> GetAll(int companyId)
        {
            return new SuccesDataResult<List<MailPattern>>(mailPatternDal.GetList(x => x.CompaniesId == companyId));
        }

        [CacheAspect(60)]
        public IDataResult<MailPattern> Getitem(int id)
        {
            var result= new SuccesDataResult<MailPattern>(mailPatternDal.Getitem(x => x.Id == id));

            return result;
        }
        [CacheAspect(60)]
        public IDataResult<MailPattern> GetitembyName(string name, int companyId)
        {
            var result = new SuccesDataResult<MailPattern>(mailPatternDal.Getitem(x => x.Type == name && x.CompaniesId==companyId));
            return result;
        }
        [RemoveCacheAspect("IMailPatternService.Get")]
        public IResult Update(MailPattern entity)
        {
            throw new NotImplementedException();
        }
    }
}
