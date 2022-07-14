using Core.entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.entities.Concrete
{
   public class User:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public DateTime AddedTime { get; set; }
        public bool IsActive { get; set; }
        public bool MailConfirm { get; set; }
        public string MailConfirmValue { get; set; }
        public DateTime MailCOnfirmDate { get; set; }

        public ICollection<UserOperationClaim> UserOperationClaim { get; set; }
        public ICollection<UserCompany> UserCompany { get; set; }
    }
}
