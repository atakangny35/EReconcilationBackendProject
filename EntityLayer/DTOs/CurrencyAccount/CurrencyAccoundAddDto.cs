using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs.CurrencyAccount
{
   public class CurrencyAccoundAddDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string TaxDepartment { get; set; }
        public string TaxIdNumber { get; set; }
        public string IdentityNumber { get; set; }
        public string Email { get; set; }
        public string Authorized { get; set; }
        public int Companyid { get; set; }
    }
}
