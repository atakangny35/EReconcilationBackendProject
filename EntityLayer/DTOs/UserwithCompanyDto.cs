using Core.entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs
{
  public  class UserwithCompanyDto:User
    {
        
        public int Companyid { get; set; }
    }
}
