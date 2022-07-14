using Core.entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs.AccountReconcilationDetail
{
    public class BabsReconcilationDetailAddDto:IDto
    {
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }



        //fk
        public int BabsReconcilationId { get; set; }
    }
}
