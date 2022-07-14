using Core.entities.Concrete;
using Core.Utilities.Abstract;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
  public  interface ICompanyService
    {
        IResult Add(Companies company);
        IResult AddCompanyAndUserCompany(CompaniesWithUserDto company);
        IResult Update(UpdateCompanyDto company);
        IDataResult<List<Companies>> GetList();
        IDataResult<Companies> GetById(int id);
        IDataResult <UserCompany> GetUserCompany(int userId);
        IResult CompanyExists(Companies company);
        IResult UserCompanyAdd(int companyid,int userId);
    }
}
