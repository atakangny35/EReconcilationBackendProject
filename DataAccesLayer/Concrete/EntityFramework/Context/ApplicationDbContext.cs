using Core.entities.Concrete;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using BusinessLayer.Validation_rules.FluentValidation.Maps;
using DataAccesLayer.Concrete.mapping;

namespace DataAccesLayer.Concrete.EntityFramework.Context
{
    public class ApplicationDbContext:DbContext
    {
        /*public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }*/

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\mssqllocaldb; database=ereconcilationDB_v2; Trusted_Connection=True; MultipleActiveResultSets=true");

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaim { get; set; }
        public DbSet<UserCompany> UserCompany { get; set; }
        public DbSet<AccountReconcillation> AccountReconcillation { get; set; }
        public DbSet<AccountReconcillationsDetail> AccountReconcillationsDetail { get; set; }
        public DbSet<Companies> Companies { get; set; }
        public DbSet<BabsReconcilation> BabsReconcilation { get; set; }
        public DbSet<BabsReconcilationDetail> BabsReconcilationDetail { get; set; }
        public DbSet<Currency> Currency { get; set; }
        public DbSet<CurrencyAccount> CurrencyAccount { get; set; }
        public DbSet<MailParameter> MailParameter { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaim { get; set; }
        public DbSet<MailPattern>  mailPattern { get; set; }
        public DbSet<RegisterTerms>  RegisterTerm { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CompanyMap());
            modelBuilder.ApplyConfiguration(new UserMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
