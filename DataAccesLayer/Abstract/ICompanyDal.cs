﻿using Core.DataAcces.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Abstract
{
   public interface ICompanyDal:IGenericDal<Companies>
    {

        void UserCompanyAdd(int companyid, int userId);
    }
}