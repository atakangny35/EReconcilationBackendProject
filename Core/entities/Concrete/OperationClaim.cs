using Core.entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.entities.Concrete
{
   public  class OperationClaim:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime AddedTime { get; set; }
        public bool  IsActive { get; set; }

        public ICollection<UserOperationClaim> UserOperationClaim { get; set; }
        public ICollection<User>  Users { get; set; }
    }
}
