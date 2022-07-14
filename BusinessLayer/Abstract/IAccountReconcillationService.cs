using Core.Utilities.Abstract;
using EntityLayer.Concrete;
using EntityLayer.DTOs.AccountReconcillation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IAccountReconcillationService
    {
        IResult Add(AccountReconcillationAddDto accountReconcillationAddDto);
        IResult AddToExcel( string FilePath,int companyId);
        IResult Update(AccountReconcillationUpdateDto accountReconcillationUpdateDto);
        IResult Delete(int id);
        IDataResult<AccountReconcillation> getById(int id);
        
        IDataResult<List<AccountReconcillation>> GetList(int companyid);
    }
}
 