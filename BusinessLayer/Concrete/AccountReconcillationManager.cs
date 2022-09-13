using BusinessLayer.Abstract;
using BusinessLayer.Aspect;
using BusinessLayer.Constance;
using Core.Aspect.Caching;
using Core.Aspect.Caching.Concrete;
using Core.Aspect.Transaction;
using Core.Utilities.Abstract;
using Core.Utilities.Concrete;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.DTOs.AccountReconcillation;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AccountReconcillationManager: IAccountReconcillationService
    {
        private readonly IAccountReconcillationDal accountReconcillationDal;
        private readonly ICurrencyAccountService currencyAccountService;
        private readonly ICacheManager cacheManager;
        public AccountReconcillationManager(IAccountReconcillationDal _accountReconcillationDal, 
            ICurrencyAccountService _currencyAccountService,
            ICacheManager _cacheManager
            )
        {
            accountReconcillationDal = _accountReconcillationDal;
            currencyAccountService = _currencyAccountService;
            cacheManager = _cacheManager;
        }

        [SecuredOperations("IAccountReconcillationService.crud,Admin")]
        [RemoveCacheAspect("IAccountReconcillationService.Get")]
        public IResult Add(AccountReconcillationAddDto accountReconcillationAddDto)
        {
            AccountReconcillation accountReconcillation = new AccountReconcillation()
            {
                //SendEmailDate = accountReconcillationAddDto.SendEmailDate,
                StartinDate = accountReconcillationAddDto.StartinDate,
                Companyid = accountReconcillationAddDto.Companyid,
                CurrencyId = accountReconcillationAddDto.CurrencyId,
                CuurencyAccountId = accountReconcillationAddDto.CuurencyAccountId,
                CurrencyCredit = accountReconcillationAddDto.CurrencyCredit,
                IsSendEmail = false,
                IsResultSucceed = false,
                EndingDate = accountReconcillationAddDto.EndingDate,
                ResutltDate = accountReconcillationAddDto.ResutltDate,
               // EmailReadDate = accountReconcillationAddDto.EmailReadDate,
                IsEmailRead = false,
                CurrencyDebit = accountReconcillationAddDto.CurrencyDebit,
                ResultNote = accountReconcillationAddDto.ResultNote
            };
            accountReconcillationDal.add(accountReconcillation);
            return new SuccessResult(Constances.AddedCompany);
        }
        [RemoveCacheAspect("IAccountReconcillationService.Get")]
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
                        string startingDate = reader.GetString(1);
                        string endDate =reader.GetString(2);
                        string currencyId = reader.GetString(3);
                        string debit = reader.GetString(4);
                        string credit = reader.GetString(5);

                        // buraya çözüm üretmeliyim!!!!!!!
                        if (code != "Cari Kodu" && code is not null)
                        {

                            int id = currencyAccountService.GetByCode(code, companyId).Data.Id;                                                    
                            
                            AccountReconcillation accountReconcillation = new AccountReconcillation()
                            {
                                StartinDate=Convert.ToDateTime(startingDate),
                                EndingDate=Convert.ToDateTime(endDate),
                                CurrencyId=Convert.ToInt16(currencyId),
                                Companyid=companyId,
                                CurrencyCredit=Convert.ToDecimal(credit),
                                CurrencyDebit=Convert.ToDecimal(debit),
                                CuurencyAccountId=id
                            };
                            accountReconcillationDal.add(accountReconcillation);
                        }
                    }
                }
            }
            System.IO.File.Delete(FilePath);
            return new SuccessResult(Constances.AddedCompany);
        }
        [RemoveCacheAspect("IAccountReconcillationService.Get")]
        [SecuredOperations("IAccountReconcillationService.crud,Admin")]
        public IResult Delete(int id)
        {
            accountReconcillationDal.Delete(accountReconcillationDal.Getitem(x => x.Id == id));
            return new SuccessResult(Constances.EntityDeleted);
        }

        public IDataResult<AccountReconcillation> getById(int id)
        {
            return new SuccesDataResult<AccountReconcillation>(accountReconcillationDal.Getitem(x => x.Id == id));
        }

        public int Getcount(int currencyaccountid)
        {
           return accountReconcillationDal.GetCount(x=>x.CuurencyAccountId == currencyaccountid);
        }

        [CacheAspect(60)]
        [SecuredOperations("IAccountReconcillationService.Get,Admin")]
        public IDataResult<List<AccountReconcillation>> GetList(int companyid)
        {
            return new SuccesDataResult<List<AccountReconcillation>>(accountReconcillationDal.GetList(x => x.Companyid == companyid));
        }
        [CacheAspect(60)]
        [SecuredOperations("IAccountReconcillationService.Get,Admin")]
        public IDataResult<List<AccountReconcillation>> GetListByCurrencyAcoountId(int currencyaccountid)
        {
            return new SuccesDataResult<List<AccountReconcillation>>(accountReconcillationDal.GetList(x => x.CuurencyAccountId == currencyaccountid));
        }

        [SecuredOperations("IAccountReconcillationService.crud,Admin")]
        [RemoveCacheAspect("IAccountReconcillationService.Get")]
        public IResult Update(AccountReconcillationUpdateDto accountReconcillationUpdateDto)
        {
          var accountReconcillation=  accountReconcillationDal.Getitem(x => x.Id == accountReconcillationUpdateDto.Id);
            accountReconcillation.SendEmailDate = accountReconcillationUpdateDto.SendEmailDate;
            accountReconcillation.StartinDate = accountReconcillationUpdateDto.StartinDate;
            accountReconcillation.Companyid = accountReconcillationUpdateDto.Companyid;
            accountReconcillation.CurrencyId = accountReconcillationUpdateDto.CurrencyId;
            accountReconcillation.CuurencyAccountId = accountReconcillationUpdateDto.CuurencyAccountId;
            accountReconcillation.CurrencyCredit = accountReconcillationUpdateDto.CurrencyCredit;
            accountReconcillation.IsSendEmail = accountReconcillationUpdateDto.IsSendEmail;
            accountReconcillation.IsResultSucceed = accountReconcillationUpdateDto.IsResultSucceed;
            accountReconcillation.EndingDate = accountReconcillationUpdateDto.EndingDate;
            accountReconcillation.ResutltDate = accountReconcillationUpdateDto.ResutltDate;
            accountReconcillation.EmailReadDate = accountReconcillationUpdateDto.EmailReadDate;
            accountReconcillation.IsEmailRead = accountReconcillationUpdateDto.IsEmailRead;
            accountReconcillation.CurrencyDebit = accountReconcillationUpdateDto.CurrencyDebit;
            accountReconcillation.ResultNote = accountReconcillationUpdateDto.ResultNote;
            accountReconcillationDal.Update(accountReconcillation);
            return new SuccessResult(Constances.EntityUpdated);
        }
    }
}
