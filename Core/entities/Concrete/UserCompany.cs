using Core.entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.entities.Concrete
{
    public class UserCompany:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public DateTime AddedTime { get; set; }
        public bool IsActive { get; set; }
    }
}
