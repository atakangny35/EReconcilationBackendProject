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
    public class CompanyMap : IEntityTypeConfiguration<Companies>
    {
        public void Configure(EntityTypeBuilder<Companies> builder)
        {
            builder.Property(x => x.Address).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.TaxDepartment).HasMaxLength(100);
            builder.HasMany<CurrencyAccount>(x => x.CurrencyAccounts).WithOne(y => y.Companies).HasForeignKey(y => y.Companyid);
        }
    }
}
