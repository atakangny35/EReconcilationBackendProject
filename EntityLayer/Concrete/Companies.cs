using Core.entities.Abstract;
using Core.entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityLayer.Concrete
{
   public class Companies:IEntity
    {
        public int Id  { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string TaxDepartment { get; set; }

        public string TaxIdNumber { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime AddedTime { get; set; }
        public bool IsActive { get; set; }

        
       public ICollection<CurrencyAccount> CurrencyAccounts { get; set; }
        public ICollection<AccountReconcillation>? AccountReconcillation { get; set; }
       public ICollection<BabsReconcilation>  babsReconcilations { get; set; }
       public ICollection<UserCompany> UserCompany { get; set; } //Many to many
    }
}
