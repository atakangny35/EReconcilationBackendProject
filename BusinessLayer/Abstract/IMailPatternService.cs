using Core.Utilities.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IMailPatternService
    {
        IResult add(MailPattern entity);
        IResult Update(MailPattern entity);
        IResult Delete(MailPattern entity);
        IDataResult<List<MailPattern>> GetAll(int companyId);
        IDataResult<MailPattern> Getitem(int id);
        IDataResult<MailPattern> GetitembyName(string name,int companyId);
    }
}
