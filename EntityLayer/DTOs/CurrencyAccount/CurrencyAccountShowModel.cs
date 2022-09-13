using Core.entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs.CurrencyAccount
{
    public class CurrencyAccountShowModel:IDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string TaxDepartment { get; set; }
        public string TaxIdNumber { get; set; }
        public string IdentityNumber { get; set; }
        public string Email { get; set; }
        public string Authorized { get; set; }
        public DateTime AddedTime { get; set; }
        public bool IsActive { get; set; }
        public int Companyid { get; set; }
    }
}
