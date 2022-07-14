using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs
{
   public class SendMailDto
    {
        public MailParameter  mailParameter{ get; set; }
        public string    email{ get; set; }
        public string    subject{ get; set; }
        public string    body{ get; set; }
        //public int    UserId{ get; set; }
    }
}
