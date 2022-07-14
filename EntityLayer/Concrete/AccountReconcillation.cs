using Core.entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityLayer.Concrete
{
   public  class AccountReconcillation:IEntity
    {   [Key]
        public int Id { get; set; }
             
        public DateTime StartinDate { get; set; }
        public DateTime EndingDate { get; set; }
        public decimal CurrencyDebit { get; set; }
        public decimal CurrencyCredit { get; set; }
        public bool IsSendEmail { get; set; }
        public DateTime? SendEmailDate { get; set; }

        public bool? IsEmailRead { get; set; }

        public DateTime? EmailReadDate { get; set; }

        public bool? IsResultSucceed { get; set; }
        public DateTime? ResutltDate { get; set; }
        public string ResultNote { get; set; }

        //fk
        public int Companyid { get; set; }
        public virtual Companies Companies { get; set; }

        public int CuurencyAccountId { get; set; }
        public virtual CurrencyAccount CurrencyAccount { get; set; }

        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }

        public ICollection<AccountReconcillationsDetail> AccountReconcillationsDetail { get; set; }

    }
}
