﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs
{
   public class UserRegisterModelWithCompanyId:UserRegisterModel
    {
        public int companyId { get; set; }
    }
}
