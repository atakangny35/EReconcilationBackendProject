using BusinessLayer.Abstract;
using BusinessLayer.Constance;
using BusinessLayer.Validation_rules.FluentValidation;
using Core.Aspect.Transaction;
using Core.Aspect.Validation;
using Core.entities.Concrete;
using Core.Utilities.Abstract;
using Core.Utilities.Concrete;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
   
    public class CompanyManager : ICompanyService
    {
       private readonly ICompanyDal companyDal;
       private readonly IUserCompanyDal userCompanyDal;
        public CompanyManager(ICompanyDal _companyDal, IUserCompanyDal _userCompanyDal)
        {
            companyDal = _companyDal;
            userCompanyDal = _userCompanyDal;

        }

        [ValidationAspect(typeof(CompanyValidator))]
        public IResult Add(Companies company)
        {
            companyDal.add(company);
            return new SuccessResult(Constances.AddedCompany);
        }

        [ValidationAspect(typeof(CompanyValidator))]
        [TransactionScopeAspect]
        public IResult AddCompanyAndUserCompany(CompaniesWithUserDto companiesWithUserDto)
        {
            companyDal.add(companiesWithUserDto.Company);
            companyDal.UserCompanyAdd(companiesWithUserDto.Company.Id, companiesWithUserDto.UserId);
            return new SuccessResult(Constances.AddedCompany);
        }

        public IResult CompanyExists(Companies company)
        {
           var resultCompany= companyDal.Getitem(x=>x.Name==company.Name && x.TaxDepartment==company.TaxDepartment
           &&x.TaxIdNumber==company.TaxIdNumber && x.IdentityNumber==company.IdentityNumber);

            return resultCompany is not null 
                ? new ErrorResult(Constances.CompanyExists) 
                : new SuccessResult();

        }

        public IDataResult<Companies> GetById(int id)
        {
            var company = companyDal.Getitem(x => x.Id == id);
            return new SuccesDataResult<Companies>(company);
        }

        public IDataResult<List<Companies>> GetList()
        {
            return new SuccesDataResult<List<Companies>>(companyDal.GetList());
        }

        public IDataResult<UserCompany> GetUserCompany(int userId)
        {
            var result = userCompanyDal.Getitem(x=>x.UserId==userId);
            return result is not null
                ? new SuccesDataResult<UserCompany>(result)
                : new ErrorDataResult<UserCompany>(Constances.UserCompanyNotFound);
        }
        [ValidationAspect(typeof(CompanyValidator))]
        public IResult Update(UpdateCompanyDto  updateCompanyDto)
        {
            Companies company = companyDal.Getitem(i => i.Id == updateCompanyDto.Id);

            company.IdentityNumber = updateCompanyDto.IdentityNumber;
            company.Name = updateCompanyDto.Name;
            company.Address = updateCompanyDto.Address;
            company.TaxDepartment = updateCompanyDto.TaxDepartment;
            company.TaxIdNumber = updateCompanyDto.TaxIdNumber;
            
            companyDal.Update(company);
            return new SuccessResult(Constances.UpdatedCompny);
        }

        public IResult UserCompanyAdd(int companyid, int userId)
        {
            companyDal.UserCompanyAdd(companyid, userId);

            return new SuccessResult(Constances.AddedCompany);

        }
    }
}
