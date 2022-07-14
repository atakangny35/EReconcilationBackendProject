using BusinessLayer.Abstract;
using BusinessLayer.Constance;
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
   public class MailParameterManager:IMailParameterService
    {
        private readonly IMailParameterDal mailParameterDal;

        public MailParameterManager(IMailParameterDal _mailParameterDal)
        {
            mailParameterDal = _mailParameterDal;
        }

        public IDataResult<MailParameter> Get(int companyId)
        {
            var result = mailParameterDal.Getitem(x => x.CompanyId == companyId);

            return new SuccesDataResult<MailParameter>(result);
        }

        public IResult Update(MailParameter mailParameter)
        {
            var result = Get(mailParameter.CompanyId);
            if (result.Data is null)
            {
                mailParameterDal.add(mailParameter);
            }
            else
            {
                result.Data.SMTP = mailParameter.SMTP;
                result.Data.SSL = mailParameter.SSL;
                result.Data.Port = mailParameter.Port;
                result.Data.Email = mailParameter.Email;
                result.Data.Password = mailParameter.Password;
                mailParameterDal.Update(result.Data);
            }
            return new SuccessResult(Constances.MailParameterUpdated);
        }
    }
}
