using Core.entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityLayer.Concrete
{
    public class AccountReconcillationsDetail: IEntity
    {   
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal CurrencyDebit { get; set; }
        public decimal CurrencyCredit { get; set; }


        //fk
        public int AccountReconcillationsId { get; set; }
        public virtual AccountReconcillation AccountReconcillation  { get; set; }
        
        public int CurrencyId { get; set; }
        public virtual Currency Currencies { get; set; }
    }
}
