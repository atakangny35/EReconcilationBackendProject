using Core.entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs.BaBsReconculation
{
   public class BabsReconcilationUpdateDto:IDto
    {
        public int Id { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int Ouantity { get; set; }
        public decimal Total { get; set; }
        public int Companyid { get; set; }
        public int CurrencyAccountId { get; set; }
        public string ResultNote { get; set; }
        public string Type { get; set; }
    }
}
