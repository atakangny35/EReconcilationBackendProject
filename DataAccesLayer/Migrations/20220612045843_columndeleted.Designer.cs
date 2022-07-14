﻿// <auto-generated />
using System;
using DataAccesLayer.Concrete.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccesLayer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220612045843_columndeleted")]
    partial class columndeleted
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Core.entities.Concrete.OperationClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddedTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OperationClaim");
                });

            modelBuilder.Entity("Core.entities.Concrete.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("MailCOnfirmDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("MailConfirm")
                        .HasColumnType("bit");

                    b.Property<string>("MailConfirmValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OperationClaimId")
                        .HasColumnType("int");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("OperationClaimId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Core.entities.Concrete.UserCompany", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddedTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CompaniesId")
                        .HasColumnType("int");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompaniesId");

                    b.HasIndex("UserId");

                    b.ToTable("UserCompany");
                });

            modelBuilder.Entity("Core.entities.Concrete.UserOperationClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("OperationClaimId")
                        .HasColumnType("int");

                    b.Property<int>("Userid")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OperationClaimId");

                    b.HasIndex("Userid");

                    b.ToTable("UserOperationClaim");
                });

            modelBuilder.Entity("EntityLayer.Concrete.AccountReconcillation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CompaniesId")
                        .HasColumnType("int");

                    b.Property<int>("Companyid")
                        .HasColumnType("int");

                    b.Property<int?>("CurrencyAccountId")
                        .HasColumnType("int");

                    b.Property<decimal>("CurrencyCredit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("CurrencyDebit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CurrencyId")
                        .HasColumnType("int");

                    b.Property<int>("CuurencyAccountId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EmailReadDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndingDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsEmailRead")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsResultSucceed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSendEmail")
                        .HasColumnType("bit");

                    b.Property<string>("ResultNote")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ResutltDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("SendEmailDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartinDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CompaniesId");

                    b.HasIndex("CurrencyAccountId");

                    b.HasIndex("CurrencyId");

                    b.ToTable("AccountReconcillation");
                });

            modelBuilder.Entity("EntityLayer.Concrete.AccountReconcillationsDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountReconcillationsId")
                        .HasColumnType("int");

                    b.Property<decimal>("CurrencyCredit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("CurrencyDebit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("CurrencyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MyProperty")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccountReconcillationsId");

                    b.HasIndex("CurrencyId");

                    b.ToTable("AccountReconcillationsDetail");
                });

            modelBuilder.Entity("EntityLayer.Concrete.BabsReconcilation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Companyid")
                        .HasColumnType("int");

                    b.Property<int>("CurrencyAccountId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EmailReadDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsEmailRead")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsResultSucceed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSendEmail")
                        .HasColumnType("bit");

                    b.Property<int>("Month")
                        .HasColumnType("int");

                    b.Property<int>("Ouantity")
                        .HasColumnType("int");

                    b.Property<string>("ResultNote")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ResutltDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("SendEmailDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.Property<int?>("companiesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("companiesId");

                    b.ToTable("BabsReconcilation");
                });

            modelBuilder.Entity("EntityLayer.Concrete.BabsReconcilationDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("BabsReconcilationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BabsReconcilationId");

                    b.ToTable("BabsReconcilationDetail");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Companies", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("IdentityNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TaxDepartment")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TaxIdNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Currency");
                });

            modelBuilder.Entity("EntityLayer.Concrete.CurrencyAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddedTİme")
                        .HasColumnType("datetime2");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Authorized")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Companyid")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentityNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaxDepartment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaxIdNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Companyid");

                    b.ToTable("CurrencyAccount");
                });

            modelBuilder.Entity("EntityLayer.Concrete.MailParameter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Port")
                        .HasColumnType("int");

                    b.Property<string>("SMTP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("SSL")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("MailParameter");
                });

            modelBuilder.Entity("EntityLayer.Concrete.MailPattern", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompaniesId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CompaniesId");

                    b.ToTable("mailPattern");
                });

            modelBuilder.Entity("Core.entities.Concrete.User", b =>
                {
                    b.HasOne("Core.entities.Concrete.OperationClaim", null)
                        .WithMany("Users")
                        .HasForeignKey("OperationClaimId");
                });

            modelBuilder.Entity("Core.entities.Concrete.UserCompany", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Companies", null)
                        .WithMany("UserCompany")
                        .HasForeignKey("CompaniesId");

                    b.HasOne("Core.entities.Concrete.User", null)
                        .WithMany("UserCompany")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.entities.Concrete.UserOperationClaim", b =>
                {
                    b.HasOne("Core.entities.Concrete.OperationClaim", "OperationClaim")
                        .WithMany("UserOperationClaim")
                        .HasForeignKey("OperationClaimId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.entities.Concrete.User", "User")
                        .WithMany("UserOperationClaim")
                        .HasForeignKey("Userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OperationClaim");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EntityLayer.Concrete.AccountReconcillation", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Companies", "Companies")
                        .WithMany("AccountReconcillation")
                        .HasForeignKey("CompaniesId");

                    b.HasOne("EntityLayer.Concrete.CurrencyAccount", "CurrencyAccount")
                        .WithMany("AccountReconcillation")
                        .HasForeignKey("CurrencyAccountId");

                    b.HasOne("EntityLayer.Concrete.Currency", "Currency")
                        .WithMany("AccountReconcillations")
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Companies");

                    b.Navigation("Currency");

                    b.Navigation("CurrencyAccount");
                });

            modelBuilder.Entity("EntityLayer.Concrete.AccountReconcillationsDetail", b =>
                {
                    b.HasOne("EntityLayer.Concrete.AccountReconcillation", "AccountReconcillations")
                        .WithMany("AccountReconcillationsDetail")
                        .HasForeignKey("AccountReconcillationsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.Currency", null)
                        .WithMany("AccountReconcillationsDetail")
                        .HasForeignKey("CurrencyId");

                    b.Navigation("AccountReconcillations");
                });

            modelBuilder.Entity("EntityLayer.Concrete.BabsReconcilation", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Companies", "companies")
                        .WithMany("babsReconcilations")
                        .HasForeignKey("companiesId");

                    b.Navigation("companies");
                });

            modelBuilder.Entity("EntityLayer.Concrete.BabsReconcilationDetail", b =>
                {
                    b.HasOne("EntityLayer.Concrete.BabsReconcilation", "BabsReconcilation")
                        .WithMany("BabsReconcilationDetail")
                        .HasForeignKey("BabsReconcilationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BabsReconcilation");
                });

            modelBuilder.Entity("EntityLayer.Concrete.CurrencyAccount", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Companies", "Companies")
                        .WithMany("CurrencyAccounts")
                        .HasForeignKey("Companyid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Companies");
                });

            modelBuilder.Entity("EntityLayer.Concrete.MailPattern", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Companies", "Companies")
                        .WithMany()
                        .HasForeignKey("CompaniesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Companies");
                });

            modelBuilder.Entity("Core.entities.Concrete.OperationClaim", b =>
                {
                    b.Navigation("UserOperationClaim");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Core.entities.Concrete.User", b =>
                {
                    b.Navigation("UserCompany");

                    b.Navigation("UserOperationClaim");
                });

            modelBuilder.Entity("EntityLayer.Concrete.AccountReconcillation", b =>
                {
                    b.Navigation("AccountReconcillationsDetail");
                });

            modelBuilder.Entity("EntityLayer.Concrete.BabsReconcilation", b =>
                {
                    b.Navigation("BabsReconcilationDetail");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Companies", b =>
                {
                    b.Navigation("AccountReconcillation");

                    b.Navigation("babsReconcilations");

                    b.Navigation("CurrencyAccounts");

                    b.Navigation("UserCompany");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Currency", b =>
                {
                    b.Navigation("AccountReconcillations");

                    b.Navigation("AccountReconcillationsDetail");
                });

            modelBuilder.Entity("EntityLayer.Concrete.CurrencyAccount", b =>
                {
                    b.Navigation("AccountReconcillation");
                });
#pragma warning restore 612, 618
        }
    }
}
