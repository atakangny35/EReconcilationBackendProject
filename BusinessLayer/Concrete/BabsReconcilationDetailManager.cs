using BusinessLayer.Abstract;
using BusinessLayer.Aspect;
using BusinessLayer.Constance;
using Core.Aspect.Caching.Concrete;
using Core.Aspect.Transaction;
using Core.Utilities.Abstract;
using Core.Utilities.Concrete;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.DTOs.AccountReconcilationDetail;
using EntityLayer.DTOs.BabsReconcilationDetail;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BabsReconcilationDetailManager: IBabsReconcilationDetailService
    {
        private readonly IBabsReconcilationDetailDal babsReconcilationDetailDal;
        public BabsReconcilationDetailManager(IBabsReconcilationDetailDal _babsReconcilationDetailDal)
        {
            babsReconcilationDetailDal = _babsReconcilationDetailDal;
        }
        [RemoveCacheAspect("IBabsReconcilationDetailService.Get")]
        [SecuredOperations("BabsReconcilationDetail.crud,Admin")]
        public IResult Add(BabsReconcilationDetailAddDto babsReconcilationDetailAddDto)
        {
            BabsReconcilationDetail babsReconcilationDetail = new BabsReconcilationDetail()
            {
                Amount=babsReconcilationDetailAddDto.Amount,
                BabsReconcilationId=babsReconcilationDetailAddDto.BabsReconcilationId,
                Date=babsReconcilationDetailAddDto.Date,
                Description=babsReconcilationDetailAddDto.Description
            };

            babsReconcilationDetailDal.add(babsReconcilationDetail);
            return new SuccessResult(Constances.AddedCompany);
        }
        [RemoveCacheAspect("IBabsReconcilationDetailService.Get")]
        [TransactionScopeAspect]
        public IResult AddToExcel(string FilePath, int masterseq)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            using (var stream = System.IO.File.Open(FilePath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while (reader.Read())
                    {
                        string aciklama = reader.GetString(1);


                        // buraya çözüm üretmeliyim!!!!!!!
                        if (aciklama != "Açıklama" && aciklama is not null)
                        {
                            DateTime Date = reader.GetDateTime(0);
                            double Amount = reader.GetDouble(2);
                            //  int id = currencyAccountService.GetByCode(code, companyId).Data.Id;

                            BabsReconcilationDetail babsReconcilation = new BabsReconcilationDetail()
                            {
                                Date=Date,
                                Amount=Convert.ToDecimal(Amount),
                                BabsReconcilationId=masterseq,
                                Description=aciklama
                            };
                            babsReconcilationDetailDal.add(babsReconcilation);
                        }
                    }
                }
            }
            System.IO.File.Delete(FilePath);
            return new SuccessResult(Constances.AddedCompany);
        }

        [SecuredOperations("BabsReconcilationDetail.crud,Admin")]
        [RemoveCacheAspect("IBabsReconcilationDetailService.Get")]
        public IResult Delete(int id)
        {
            babsReconcilationDetailDal.Delete(babsReconcilationDetailDal.Getitem(x => x.Id == id));
            return new SuccessResult(Constances.EntityDeleted);
        }

        [CacheAspect(60)]
        public IDataResult<BabsReconcilationDetail> GetById(int id)
        {
            return new SuccesDataResult<BabsReconcilationDetail>(babsReconcilationDetailDal.Getitem(x => x.Id == id));
        }
        [CacheAspect(60)]
        public IDataResult<List<BabsReconcilationDetail>> GetList(int masterseq)
        {
            return new SuccesDataResult<List<BabsReconcilationDetail>>(babsReconcilationDetailDal.GetList(x => x.BabsReconcilationId == masterseq));
        }
        [SecuredOperations("BabsReconcilationDetail.crud,Admin")]
        [RemoveCacheAspect("IBabsReconcilationDetailService.Get")]
        public IResult Update(BabsReconcilationDetailUpdateDto  babsReconcilationDetailUpdateDto)
        {
            var babsReconcilationDetail = babsReconcilationDetailDal.Getitem(x => x.Id == babsReconcilationDetailUpdateDto.Id);

            babsReconcilationDetail.BabsReconcilationId = babsReconcilationDetailUpdateDto.BabsReconcilationId;
            babsReconcilationDetail.Amount = babsReconcilationDetailUpdateDto.Amount;
            babsReconcilationDetail.Date = babsReconcilationDetailUpdateDto.Date;
            babsReconcilationDetail.Description = babsReconcilationDetailUpdateDto.Description;
            babsReconcilationDetailDal.Update(babsReconcilationDetail);
            return new SuccessResult(Constances.EntityUpdated);
        }
    }
}
