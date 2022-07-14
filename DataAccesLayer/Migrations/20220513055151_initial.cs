using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccesLayer.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxDepartment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxIdNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentityNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MailParameter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SMTP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Port = table.Column<int>(type: "int", nullable: false),
                    SSL = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailParameter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OperationClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationClaim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    AddedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    MailConfirm = table.Column<bool>(type: "bit", nullable: false),
                    MailConfirmValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MailCOnfirmDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BabsReconcilation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Ouantity = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsSendEmail = table.Column<bool>(type: "bit", nullable: false),
                    SendEmailDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsEmailRead = table.Column<bool>(type: "bit", nullable: true),
                    EmailReadDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsResultSucceed = table.Column<bool>(type: "bit", nullable: true),
                    ResutltDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ResultNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Companyid = table.Column<int>(type: "int", nullable: false),
                    companiesId = table.Column<int>(type: "int", nullable: true),
                    CurrencyAccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BabsReconcilation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BabsReconcilation_Companies_companiesId",
                        column: x => x.companiesId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyAccount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxDepartment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxIdNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentityNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Authorized = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedTİme = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Companyid = table.Column<int>(type: "int", nullable: false),
                    CompaniesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyAccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurrencyAccount_Companies_CompaniesId",
                        column: x => x.CompaniesId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OperationClaimUser",
                columns: table => new
                {
                    UsersId = table.Column<int>(type: "int", nullable: false),
                    UsersId1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationClaimUser", x => new { x.UsersId, x.UsersId1 });
                    table.ForeignKey(
                        name: "FK_OperationClaimUser_OperationClaim_UsersId",
                        column: x => x.UsersId,
                        principalTable: "OperationClaim",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OperationClaimUser_Users_UsersId1",
                        column: x => x.UsersId1,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserCompany",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    AddedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CompaniesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCompany", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCompany_Companies_CompaniesId",
                        column: x => x.CompaniesId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserCompany_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BabsReconcilationDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "money", nullable: false),
                    BabsReconcilationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BabsReconcilationDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BabsReconcilationDetail_BabsReconcilation_BabsReconcilationId",
                        column: x => x.BabsReconcilationId,
                        principalTable: "BabsReconcilation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountReconcillation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartinDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MyProperty = table.Column<int>(type: "int", nullable: false),
                    CurrencyDebit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrencyCredit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsSendEmail = table.Column<bool>(type: "bit", nullable: false),
                    SendEmailDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsEmailRead = table.Column<bool>(type: "bit", nullable: true),
                    EmailReadDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsResultSucceed = table.Column<bool>(type: "bit", nullable: true),
                    ResutltDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ResultNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Companyid = table.Column<int>(type: "int", nullable: false),
                    CompaniesId = table.Column<int>(type: "int", nullable: true),
                    CuurencyAccountId = table.Column<int>(type: "int", nullable: false),
                    CurrencyAccountId = table.Column<int>(type: "int", nullable: true),
                    CurrencyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountReconcillation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountReconcillation_Companies_CompaniesId",
                        column: x => x.CompaniesId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountReconcillation_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountReconcillation_CurrencyAccount_CurrencyAccountId",
                        column: x => x.CurrencyAccountId,
                        principalTable: "CurrencyAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccountReconcillationsDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MyProperty = table.Column<int>(type: "int", nullable: false),
                    CurrencyDebit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrencyCredit = table.Column<decimal>(type: "money", nullable: false),//decimal(18,2)
                    AccountReconcillationsId = table.Column<int>(type: "int", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountReconcillationsDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountReconcillationsDetail_AccountReconcillation_AccountReconcillationsId",
                        column: x => x.AccountReconcillationsId,
                        principalTable: "AccountReconcillation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountReconcillationsDetail_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountReconcillation_CompaniesId",
                table: "AccountReconcillation",
                column: "CompaniesId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountReconcillation_CurrencyAccountId",
                table: "AccountReconcillation",
                column: "CurrencyAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountReconcillation_CurrencyId",
                table: "AccountReconcillation",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountReconcillationsDetail_AccountReconcillationsId",
                table: "AccountReconcillationsDetail",
                column: "AccountReconcillationsId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountReconcillationsDetail_CurrencyId",
                table: "AccountReconcillationsDetail",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_BabsReconcilation_companiesId",
                table: "BabsReconcilation",
                column: "companiesId");

            migrationBuilder.CreateIndex(
                name: "IX_BabsReconcilationDetail_BabsReconcilationId",
                table: "BabsReconcilationDetail",
                column: "BabsReconcilationId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyAccount_CompaniesId",
                table: "CurrencyAccount",
                column: "CompaniesId");

            migrationBuilder.CreateIndex(
                name: "IX_OperationClaimUser_UsersId1",
                table: "OperationClaimUser",
                column: "UsersId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserCompany_CompaniesId",
                table: "UserCompany",
                column: "CompaniesId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCompany_UserId",
                table: "UserCompany",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountReconcillationsDetail");

            migrationBuilder.DropTable(
                name: "BabsReconcilationDetail");

            migrationBuilder.DropTable(
                name: "MailParameter");

            migrationBuilder.DropTable(
                name: "OperationClaimUser");

            migrationBuilder.DropTable(
                name: "UserCompany");

            migrationBuilder.DropTable(
                name: "AccountReconcillation");

            migrationBuilder.DropTable(
                name: "BabsReconcilation");

            migrationBuilder.DropTable(
                name: "OperationClaim");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropTable(
                name: "CurrencyAccount");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
