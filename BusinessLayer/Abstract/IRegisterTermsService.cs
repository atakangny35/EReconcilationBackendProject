using Core.Utilities.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IRegisterTermsService
    {
        //IResult Add(RegisterTerms registerTerms);
        IResult Update(RegisterTerms registerTerms);
        IDataResult<RegisterTerms> GetData ();
    }
}
