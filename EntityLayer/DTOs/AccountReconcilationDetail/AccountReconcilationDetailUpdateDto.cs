using Core.entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs.AccountReconcilationDetail
{
    public class AccountReconcilationDetailUpdateDto:IDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal CurrencyDebit { get; set; }
        public decimal CurrencyCredit { get; set; }


        //fk
        public int AccountReconcillationsId { get; set; }
    }
}
