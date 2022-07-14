using Core.Utilities.Abstract;
using EntityLayer.Concrete;
using EntityLayer.DTOs.BaBsReconculation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public  interface IBabsReconcilationService
    {
        IResult Add(BabsReconcilationAddDto babsReconcilationAddDto);
        IResult AddToExcel(string FilePath, int companyId);
        IResult Update(BabsReconcilationUpdateDto  babsReconcilationUpdateDto);
        IResult Delete(int id);
        IDataResult<BabsReconcilation> getById(int id);

        IDataResult<List<BabsReconcilation>> GetList(int companyid);
    }
}
