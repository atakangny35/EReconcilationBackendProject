using Core.Utilities.Abstract;
using EntityLayer.Concrete;
using EntityLayer.DTOs.AccountReconcilationDetail;
using EntityLayer.DTOs.BabsReconcilationDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IBabsReconcilationDetailService
    {
        IResult Add(BabsReconcilationDetailAddDto  babsReconcilationDetailAddDto);
        IResult AddToExcel(string FilePath, int masterseq);
        IResult Update(BabsReconcilationDetailUpdateDto  babsReconcilationDetailUpdateDto);
        IResult Delete(int id);
        IDataResult<BabsReconcilationDetail> GetById(int id);
        IDataResult<List<BabsReconcilationDetail>> GetList(int masterseq);
    }
}
