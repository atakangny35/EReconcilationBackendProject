using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs
{
   public class CompaniesWithUserDto:Companies
    {
        public Companies  Company { get; set; }
        public int UserId { get; set; }
    }
}
