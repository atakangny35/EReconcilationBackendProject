using Core.entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityLayer.Concrete
{
   public class BabsReconcilationDetail:IEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }

        public string Description { get; set; }


        //fk
        public int BabsReconcilationId { get; set; }
        public virtual BabsReconcilation BabsReconcilation { get; set; }
    }
}
