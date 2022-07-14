using Core.entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityLayer.Concrete
{
   public class CurrencyAccount:IEntity
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string TaxDepartment { get; set; }
        public string TaxIdNumber{ get; set; }
        public string IdentityNumber{ get; set; }
        public string Email { get; set; }

        public string Authorized { get; set; }
        public DateTime AddedTİme { get; set; }
        public bool IsActive { get; set; }

        
        public int Companyid { get; set; }
        public virtual Companies  Companies { get; set; }

        public ICollection<AccountReconcillation> AccountReconcillation { get; set; }
    }
}
