using Core.entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.entities.Concrete
{
   public class UserOperationClaim:IEntity
    {
        public int Id { get; set; }
      
        public int Userid { get; set; }
        public User  User { get; set; }
        public int OperationClaimId { get; set; }
        public OperationClaim OperationClaim { get; set; }
        public int CompanyId { get; set; }       
        public bool IsActive { get; set; }

    }
}
