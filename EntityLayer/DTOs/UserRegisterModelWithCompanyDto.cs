﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs
{
  public  class UserRegisterModelWithCompanyDto
    {
        public UserRegisterModel  UserRegisterModel { get; set; }
        public Companies  company { get; set; }
    }
}
