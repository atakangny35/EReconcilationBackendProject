using Core.entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityLayer.Concrete
{
   public class BabsReconcilation:IEntity
    {
        public int Id { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int Ouantity { get; set; }
        public decimal Total { get; set; }
        public bool IsSendEmail { get; set; }
        public string Type { get; set; }
        public DateTime? SendEmailDate { get; set; }

        public bool? IsEmailRead { get; set; }

        public DateTime? EmailReadDate { get; set; }

        public bool? IsResultSucceed { get; set; }
        public DateTime? ResutltDate { get; set; }
        public string ResultNote { get; set; }

        //fk
        public ICollection<BabsReconcilationDetail> BabsReconcilationDetail { get; set; }
        public int Companyid { get; set; }
        public Companies  companies { get; set; }
        public int CurrencyAccountId  { get; set; }
        

    }
}
