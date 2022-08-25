using BusinessLayer.Abstract;
using BusinessLayer.Constance;
using Core.Utilities.Abstract;
using Core.Utilities.Concrete;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class IRegisterTermsManager : IRegisterTermsService
    {
        private readonly IRegisterTermsDal registerTermsDal;

        public IRegisterTermsManager(IRegisterTermsDal _registerTermsDal)
        {
            registerTermsDal = _registerTermsDal;
        }

        public IDataResult<RegisterTerms> GetData()
        {
            return new SuccesDataResult<RegisterTerms>(registerTermsDal.GetList().FirstOrDefault());
        }

        public IResult Update(RegisterTerms registerTerms)
        {
            var result = registerTermsDal.GetList().FirstOrDefault();

            if (result !=null)
            {
                result.Description = registerTerms.Description;
                registerTermsDal.Update(result);
                return new SuccessResult(Constances.EntityUpdated);
            }
            registerTermsDal.add(registerTerms);
            return new SuccessResult(Constances.AddedCompany);
        }
    }
}
