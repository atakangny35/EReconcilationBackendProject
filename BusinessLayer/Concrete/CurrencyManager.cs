using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
   public class CurrencyManager:ICurrencyService
    {
        private readonly ICurrencyDal currencyDal;

        public CurrencyManager(ICurrencyDal _currencyDal)
        {
            currencyDal = _currencyDal;
        }
    }
}
