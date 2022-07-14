using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validation_rules.FluentValidation.Maps
{
    class CurrencyAccountMap : IEntityTypeConfiguration<CurrencyAccount>
    {
        public void Configure(EntityTypeBuilder<CurrencyAccount> builder)
        {
            
        }
    }
}
