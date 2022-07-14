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
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
   public class AccountReconcillationsDetailManager: IAccountReconcillationsDetailService
    {
        private readonly IAccountReconcillationsDetailDal accountReconcillationsDetailDal;
        public AccountReconcillationsDetailManager(IAccountReconcillationsDetailDal _accountReconcillationsDetailDal)
        {
            accountReconcillationsDetailDal = _accountReconcillationsDetailDal;
        }

        [SecuredOperations("IAccountReconcillationsDetailService.crud,Admin")]
        [RemoveCacheAspect("IAccountReconcillationsDetailService.Get")]
        public IResult Add(AccountReconcilationDetailAddDto accountReconcilationDetailAddDto)
        {
            AccountReconcillationsDetail accountReconcillation = new AccountReconcillationsDetail()
            {
                AccountReconcillationsId = accountReconcilationDetailAddDto.AccountReconcillationsId,
                CurrencyCredit = accountReconcilationDetailAddDto.CurrencyCredit,
                CurrencyDebit = accountReconcilationDetailAddDto.CurrencyDebit,
                Date = accountReconcilationDetailAddDto.Date,
                Description = accountReconcilationDetailAddDto.Description,
            };

             accountReconcillationsDetailDal.add(accountReconcillation);
            return new SuccessResult(Constances.AddedCompany);
        }
        [SecuredOperations("IAccountReconcillationsDetailService.crud,Admin")]
        [RemoveCacheAspect("IAccountReconcillationsDetailService.Get")]
        [SecuredOperations("IAccountReconcillationsDetailService.crud,Admin")]
        public IResult Update(AccountReconcilationDetailUpdateDto accountReconcilationDetailUpdateDto)
        {
            var accountReconcillationsDetail= accountReconcillationsDetailDal.Getitem(x=>x.Id==accountReconcilationDetailUpdateDto.Id);

            if (accountReconcillationsDetail is null)
            {
                return new ErrorResult(Constances.AccountReconcilationDetailNotFound);
            }

            accountReconcillationsDetail.Description = accountReconcilationDetailUpdateDto.Description;
            accountReconcillationsDetail.Date = accountReconcilationDetailUpdateDto.Date;
            accountReconcillationsDetail.CurrencyDebit = accountReconcilationDetailUpdateDto.CurrencyDebit;
            accountReconcillationsDetail.CurrencyCredit = accountReconcilationDetailUpdateDto.CurrencyCredit;
            accountReconcillationsDetail.AccountReconcillationsId = accountReconcilationDetailUpdateDto.AccountReconcillationsId;

            accountReconcillationsDetailDal.Update(accountReconcillationsDetail);
            return new SuccessResult(Constances.EntityUpdated);


        }
        [RemoveCacheAspect("IAccountReconcillationsDetailService.Get")]
        [SecuredOperations("IAccountReconcillationsDetailService.crud,Admin")]
        public IResult Delete(int id)
        {
            accountReconcillationsDetailDal.Delete(accountReconcillationsDetailDal.Getitem(x => x.Id == id));

            return new SuccessResult(Constances.EntityDeleted);
        }

        public IDataResult<AccountReconcillationsDetail> GetById(int id)
        {   
            return new SuccesDataResult<AccountReconcillationsDetail>(accountReconcillationsDetailDal.Getitem(x=>x.Id==id));
        }

        [CacheAspect(60)]
        public IDataResult<List<AccountReconcillationsDetail>> GetList(int masterseq)
        {
            return new SuccesDataResult<List<AccountReconcillationsDetail>>(accountReconcillationsDetailDal.GetList(x => x.AccountReconcillationsId == masterseq));
        }
        [SecuredOperations("IAccountReconcillationsDetailService.crud,Admin")]
        [RemoveCacheAspect("IAccountReconcillationsDetailService.Get")]
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
                            double currencyId = reader.GetDouble(2);
                            double debit = reader.GetDouble(3);
                            double credit = reader.GetDouble(4);



                            AccountReconcillationsDetail accountReconcillation = new AccountReconcillationsDetail()
                            {
                                    AccountReconcillationsId=masterseq,
                                    CurrencyCredit=Convert.ToDecimal(credit),
                                    CurrencyDebit=Convert.ToDecimal(debit),
                                    Description=aciklama,
                                    Date=Date,
                                    CurrencyId=Convert.ToInt32(currencyId)
                                    
                                    


                            };
                            accountReconcillationsDetailDal.add(accountReconcillation);
                        }
                    }
                }
            }
            System.IO.File.Delete(FilePath);
            return new SuccessResult(Constances.AddedCompany);
        }
    }
}
