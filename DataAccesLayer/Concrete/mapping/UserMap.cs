using Core.entities.Concrete;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Concrete.mapping
{
    public class UserMap : IEntityTypeConfiguration<AccountReconcillation>
    {
        public void Configure(EntityTypeBuilder<AccountReconcillation> builder)
        {
            //builder.HasOne(x => x.Companies).WithMany(x => x.AccountReconcillation).HasForeignKey(i => i.Companyid);
        }
    }
}
