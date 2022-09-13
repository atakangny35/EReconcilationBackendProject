using Core.entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs
{
    public class UserCompanywithCompanyName
    {
        public UserCompany userCompany { get; set; }
        public string CompanyName { get; set; }
    }
}
