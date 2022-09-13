using Core.entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs.OperationClaims
{
    public class UserOperationClaimDto:IDto
    {

        public int Id { get; set; }
        
        public int Userid { get; set; }
        public int OperationClaimId { get; set; }
        public string OperationClaimName { get; set; }
        public string OperationClaimDescription { get; set; }
              
        public int CompanyId { get; set; }
    }
}
