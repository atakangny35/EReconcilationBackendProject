using BusinessLayer.Abstract;
using BusinessLayer.Aspect;
using BusinessLayer.Constance;
using Core.Aspect.Caching.Concrete;
using Core.Aspect.Transaction;
using Core.Utilities.Abstract;
using Core.Utilities.Concrete;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.DTOs.BaBsReconculation;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
   public  class BabsReconcilationManager: IBabsReconcilationService
    {
        private readonly IBabsReconcilationDal babsReconcilationDal;
        private readonly ICurrencyAccountService  currencyAccountService;
        public BabsReconcilationManager(IBabsReconcilationDal _babsReconcilationDal, ICurrencyAccountService _currencyAccountService)
        {
            babsReconcilationDal = _babsReconcilationDal;
            currencyAccountService = _currencyAccountService;
        }
        [RemoveCacheAspect("IBabsReconcilationService.Get")]
        [SecuredOperations("BabsReconcilation.crud,Admin")]
        public IResult Add(BabsReconcilationAddDto  reconcilationAddDto)
        {
            BabsReconcilation babsReconcilation  = new BabsReconcilation()
            {
              Companyid=reconcilationAddDto.Companyid,
              CurrencyAccountId=reconcilationAddDto.CurrencyAccountId,
              Month=reconcilationAddDto.Month,
              Ouantity=reconcilationAddDto.Ouantity,
              Total=reconcilationAddDto.Total,
              Year=reconcilationAddDto.Year,
              Type=reconcilationAddDto.Type
              
            };
            babsReconcilationDal.add(babsReconcilation);
            return new SuccessResult(Constances.AddedCompany);
        }

        [RemoveCacheAspect("IBabsReconcilationService.Get")]
        [TransactionScopeAspect]
        public IResult AddToExcel(string FilePath, int companyId)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            using (var stream = System.IO.File.Open(FilePath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while (reader.Read())
                    {
                        string code = reader.GetString(0);
                       

                        // buraya çözüm üretmeliyim!!!!!!!
                        if (code != "Cari Kodu" && code is not null)
                        {
                            string type = reader.GetString(1);
                            double Mounth = reader.GetDouble(2);
                            double year = reader.GetDouble(3);
                            double quantity = reader.GetDouble(4);
                            double total= reader.GetDouble(5);
                            int id;
                            try
                            {
                                 id = currencyAccountService.GetByCode(code, companyId).Data.Id;
                            }
                            catch (Exception)
                            {
                                continue;
                                
                            }
                            

                            BabsReconcilation babsReconcilation = new BabsReconcilation()
                            {
                                Companyid = companyId,
                                Month = Convert.ToInt32(Mounth),
                                CurrencyAccountId = id,
                                Ouantity=Convert.ToInt32(quantity),
                                Year=Convert.ToInt32(year),
                                Total=Convert.ToInt32(total),
                                Type=type
                            };
                            babsReconcilationDal.add(babsReconcilation);
                        }
                    }
                }
            }
            System.IO.File.Delete(FilePath);
            return new SuccessResult(Constances.AddedCompany);
        }
        [SecuredOperations("BabsReconcilation.crud,Admin")]
        [RemoveCacheAspect("IBabsReconcilationService.Get")]
        public IResult Delete(int id)
        {
            babsReconcilationDal.Delete(babsReconcilationDal.Getitem(x => x.Id == id));
            return new SuccessResult(Constances.EntityDeleted);
        }
        [CacheAspect(60)]
        public IDataResult<BabsReconcilation> getById(int id)
        {
            return new SuccesDataResult<BabsReconcilation>(babsReconcilationDal.Getitem(x => x.Id == id));
        }

        public int Getcount(int currencyaccountid)
        {
            return babsReconcilationDal.GetCount(x=>x.CurrencyAccountId==currencyaccountid);
        }

        [CacheAspect(60)]
        public IDataResult<List<BabsReconcilation>> GetList(int companyid)
        {
            return new SuccesDataResult<List<BabsReconcilation>>(babsReconcilationDal.GetList(x => x.Companyid == companyid));
        }
        [SecuredOperations("BabsReconcilation.crud,Admin")]
        [RemoveCacheAspect("IBabsReconcilationService.Get")]
        public IResult Update(BabsReconcilationUpdateDto  babsReconcilationUpdateDto)
        {
            var babsReconcilation = babsReconcilationDal.Getitem(x => x.Id == babsReconcilationUpdateDto.Id);

            babsReconcilation.Year = babsReconcilationUpdateDto.Year;
            babsReconcilation.Companyid = babsReconcilationUpdateDto.Companyid;
            babsReconcilation.CurrencyAccountId = babsReconcilationUpdateDto.CurrencyAccountId;
            babsReconcilation.Total = babsReconcilationUpdateDto.Total;
            babsReconcilation.Ouantity = babsReconcilationUpdateDto.Ouantity;
            babsReconcilation.Month = babsReconcilationUpdateDto.Month;
            babsReconcilation.ResultNote = babsReconcilationUpdateDto.ResultNote;
            babsReconcilation.Type = babsReconcilationUpdateDto.Type;
            

            babsReconcilationDal.Update(babsReconcilation);
            return new SuccessResult(Constances.EntityUpdated);
        }
    }
}
