using Core.Utilities.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IMailParameterService
    {
        IResult Update(MailParameter mailParameter);

        IDataResult<MailParameter> Get(int companyId);
    }
}
