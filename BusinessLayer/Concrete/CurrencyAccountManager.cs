using BusinessLayer.Abstract;
using BusinessLayer.Aspect;
using BusinessLayer.Constance;
using BusinessLayer.Validation_rules.FluentValidation;
using Core.Aspect.Caching.Concrete;
using Core.Aspect.Transaction;
using Core.Aspect.Validation;
using Core.Utilities.Abstract;
using Core.Utilities.Concrete;
using Core.Validations.FluentValidation;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.DTOs.CurrencyAccount;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
   public class CurrencyAccountManager: ICurrencyAccountService
    {
        private readonly ICurrencyAccountDal currencyAccountDal;
        private readonly IAccountReconcillationDal _accountReconcillationService;
        private readonly IBabsReconcilationDal _babsReconcilationService;

        public CurrencyAccountManager(ICurrencyAccountDal _currencyAccountDal, IBabsReconcilationDal babsReconcilationService, IAccountReconcillationDal accountReconcillationService)
        {
            currencyAccountDal = _currencyAccountDal;
            _babsReconcilationService = babsReconcilationService;
            _accountReconcillationService = accountReconcillationService;
        }
        [ValidationAspect(typeof(CurrencyAccountAddDtoValidator))]
        [SecuredOperations("CurrencyAccount.crud,Admin")]
        [RemoveCacheAspect("ICurrencyAccountService.GeList")]
        public IResult Add(CurrencyAccoundAddDto  currencyAccoundAddDto)
        {
           
         //var result = ValidationTool.Validate(currencyAccoundAddDto, new CurrencyAccountAddDtoValidator());
            
                CurrencyAccount currencyAccount = new CurrencyAccount
                {
                    Address = currencyAccoundAddDto.Address,
                    Authorized = currencyAccoundAddDto.Authorized,
                    Code = currencyAccoundAddDto.Code,
                    Companyid = currencyAccoundAddDto.Companyid,
                    Email = currencyAccoundAddDto.Email,
                    IdentityNumber = currencyAccoundAddDto.IdentityNumber,
                    Name = currencyAccoundAddDto.Name,
                    TaxDepartment = currencyAccoundAddDto.TaxDepartment,
                    TaxIdNumber = currencyAccoundAddDto.TaxIdNumber,
                    AddedTİme = DateTime.Now,
                    IsActive = true

                };
                currencyAccountDal.add(currencyAccount);
                return new SuccessResult(Constances.AddedCompany);
            
            
        }
        [SecuredOperations("CurrencyAccount.crud,Admin")]
        [ValidationAspect(typeof(CurrencyAccountValidator))]
        [TransactionScopeAspect]
        [RemoveCacheAspect("ICurrencyAccountService.GeList")]
        public IResult AddToExcel(string FilePath, int companyId)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            using (var stream =System.IO.File.Open(FilePath,System.IO.FileMode.Open,System.IO.FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while (reader.Read())
                    {
                        string code = reader.GetString(0);
                        string name = reader.GetString(1);
                        string address = reader.GetString(2);
                        string tacDepartment = reader.GetString(3);
                        string TaxIdNumber = reader.GetString(4);
                        string IdentityNumber = reader.GetString(5);
                        string Email = reader.GetString(6);
                        string Authorized = reader.GetString(7);

                        if (code != "Cari Kodu")
                        {
                            CurrencyAccount currencyAccount = new CurrencyAccount()
                            {
                                Name = name,
                                Address = address,
                                AddedTİme = DateTime.Now,
                                Authorized = Authorized,
                                Code = code,
                                Companyid = companyId,
                                IsActive = true,
                                Email = Email,
                                IdentityNumber = IdentityNumber,
                                TaxDepartment = tacDepartment,
                                TaxIdNumber = TaxIdNumber,
                            };
                            currencyAccountDal.add(currencyAccount); 
                        }
                    }
                }
            }
            System.IO.File.Delete(FilePath);
            return new SuccessResult(Constances.AddedCompany);
        }
        [SecuredOperations("CurrencyAccount.crud,Admin,ICurrencyAccountService.GetList")]
        [RemoveCacheAspect("ICurrencyAccountService.GeList")]
        public IResult Delete( int id)
        {
           var currencyAccount = currencyAccountDal.Getitem(x => x.Id == id);
            var reconcilationsCount = _accountReconcillationService.GetCount(x => x.CuurencyAccountId == id);
            var babscount = _babsReconcilationService.GetCount(x => x.CurrencyAccountId == id);
            if (reconcilationsCount > 0)
            {
                return new ErrorResult(Constances.CurrencyHasReconcilation);
            }
            else if(babscount > 0)
            {
                return new ErrorResult(Constances.CurrencyHasBabsReconcilation);
            }
            currencyAccountDal.Delete(currencyAccount);
            return new SuccessResult(Constances.EntityDeleted);
        }
        [SecuredOperations("ICurrencyAccountService.GetList,Admin")]
        [CacheAspect(60)]
        public IDataResult<List<CurrencyAccountShowModel>> GeList(int companyid)
        {
            var currencyAccounts = currencyAccountDal.GetList(x => x.Companyid == companyid).Select(X => new CurrencyAccountShowModel
            {
                AddedTime = X.AddedTİme,
                Address = X.Address,
                Authorized = X.Authorized,
                Companyid = companyid,
                Code = X.Code,
                TaxDepartment = X.TaxDepartment,
                Email = X.Email,
                Id = X.Id,
                IdentityNumber = X.IdentityNumber,
                IsActive = X.IsActive,
                Name = X.Name,
                TaxIdNumber = X.TaxIdNumber,
            }).ToList();
          
            return new SuccesDataResult<List<CurrencyAccountShowModel>>(currencyAccounts);
        }

        public IDataResult<CurrencyAccountShowModel> Get(int id)
        {
            var X = currencyAccountDal.Getitem(x => x.Id == id);
            if (X is  null)
            {
                return new ErrorDataResult<CurrencyAccountShowModel>(Constances.UserNotFOund);
                    
            };
            var result = new CurrencyAccountShowModel
            {
                AddedTime = X.AddedTİme,
                Address = X.Address,
                Authorized = X.Authorized,
                Companyid = X.Companyid,
                Code = X.Code,
                TaxDepartment = X.TaxDepartment,
                Email = X.Email,
                Id = X.Id,
                IdentityNumber = X.IdentityNumber,
                IsActive = X.IsActive,
                Name = X.Name,
                TaxIdNumber = X.TaxIdNumber
            };
            return new SuccesDataResult<CurrencyAccountShowModel>(result);
        }

            
    

        public IDataResult<CurrencyAccount> GetByCode(string code, int companyid)
        {
            var result = currencyAccountDal.Getitem(p => p.Code == code && p.Companyid == companyid);

            return new SuccesDataResult<CurrencyAccount>(result);
        }
        [SecuredOperations("CurrencyAccount.crud,Admin")]
        [ValidationAspect(typeof(CurrencyAccountValidator))]
        [RemoveCacheAspect("ICurrencyAccountService.GeList")]
        public IResult Update(CurrencyAccount currencyAccount)
        {
            currencyAccountDal.Update(currencyAccount);
            return new SuccessResult(Constances.UpdatedCurrencyAccount);
        }
    }
}
