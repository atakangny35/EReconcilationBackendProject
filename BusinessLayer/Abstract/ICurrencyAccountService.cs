using Core.Utilities.Abstract;
using EntityLayer.Concrete;
using EntityLayer.DTOs.CurrencyAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICurrencyAccountService
    {
        IResult Add(CurrencyAccoundAddDto  currencyAccoundAddDto);
        IResult AddToExcel(string FilePath,int companyId);
        IResult Update(CurrencyAccount currencyAccount);
        IResult Delete(int id);
        IDataResult<CurrencyAccount> Get(int id);
        IDataResult<CurrencyAccount> GetByCode(string code, int companyid);
        IDataResult<List<CurrencyAccount>> GeList(int companyid);

    }
}
