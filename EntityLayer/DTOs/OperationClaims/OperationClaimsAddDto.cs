using Core.entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs.OperationClaims
{
    public class OperationClaimsAddDto:IDto
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
