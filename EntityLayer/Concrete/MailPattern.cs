using Core.entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class MailPattern:IEntity
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }

        public int CompaniesId { get; set; }
        public Companies  Companies { get; set; }
    }
}
