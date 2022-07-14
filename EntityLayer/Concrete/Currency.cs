using Core.entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityLayer.Concrete
{
   public class Currency :IEntity
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public ICollection<AccountReconcillation>  AccountReconcillations { get; set; }
        public ICollection<AccountReconcillationsDetail>  AccountReconcillationsDetail { get; set; }
    }
}
