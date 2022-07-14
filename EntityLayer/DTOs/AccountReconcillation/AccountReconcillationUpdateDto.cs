using Core.entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs.AccountReconcillation
{
    public class AccountReconcillationUpdateDto:IDto
    {
        public int Id { get; set; }
        public int Companyid { get; set; }
        public int CuurencyAccountId { get; set; }
        public int CurrencyId { get; set; }
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
    }
}
