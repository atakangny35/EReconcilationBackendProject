using BusinessLayer.Abstract;
using BusinessLayer.Aspect;
using BusinessLayer.Constance;
using BusinessLayer.Validation_rules.FluentValidation;
using Core.Aspect.Transaction;
using Core.Aspect.Validation;
using Core.Utilities.Abstract;
using Core.Utilities.Concrete;
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

        public CurrencyAccountManager(ICurrencyAccountDal _currencyAccountDal)
        {
            currencyAccountDal = _currencyAccountDal;
        }
        [ValidationAspect(typeof(CurrencyAccountAddDtoValidator))]
        [SecuredOperations("CurrencyAccount.crud,Admin")]
        public IResult Add(CurrencyAccoundAddDto  currencyAccoundAddDto)
        {
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
        [SecuredOperations("CurrencyAccount.crud,Admin")]
        public IResult Delete( int id)
        {
           var currencyAccount = currencyAccountDal.Getitem(x => x.Id == id);
            currencyAccountDal.Delete(currencyAccount);
            return new SuccessResult(Constances.EntityDeleted);
        }

        public IDataResult<List<CurrencyAccount>> GeList(int companyid)
        {
            var result = currencyAccountDal.GetList(x => x.Companyid == companyid);
            return new SuccesDataResult<List<CurrencyAccount>>(result);
        }

        public IDataResult<CurrencyAccount> Get(int id)
        {
            var result =currencyAccountDal.Getitem(x => x.Id == id);
            return new SuccesDataResult<CurrencyAccount>(result);
        }

        public IDataResult<CurrencyAccount> GetByCode(string code, int companyid)
        {
            var result = currencyAccountDal.Getitem(p => p.Code == code && p.Companyid == companyid);

            return new SuccesDataResult<CurrencyAccount>(result);
        }
        [SecuredOperations("CurrencyAccount.crud,Admin")]
        [ValidationAspect(typeof(CurrencyAccountValidator))]
        public IResult Update(CurrencyAccount currencyAccount)
        {
            currencyAccountDal.Update(currencyAccount);
            return new SuccessResult(Constances.UpdatedCurrencyAccount);
        }
    }
}
