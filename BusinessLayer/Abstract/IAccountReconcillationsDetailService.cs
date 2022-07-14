using Core.Utilities.Abstract;
using EntityLayer.Concrete;
using EntityLayer.DTOs.AccountReconcilationDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAccountReconcillationsDetailService
    {
        IResult Add(AccountReconcilationDetailAddDto accountReconcilationDetailAddDto);
        IResult AddToExcel(string FilePath, int masterseq);
        IResult Update(AccountReconcilationDetailUpdateDto accountReconcilationDetailUpdateDto);
        IResult Delete(int id);
        IDataResult<AccountReconcillationsDetail> GetById(int id);
        IDataResult<List<AccountReconcillationsDetail>> GetList(int masterseq);
    }
}
