using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccesLayer.Migrations
{
    public partial class relationfexed_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CurrencyAccount_Companies_CompaniesId",
                table: "CurrencyAccount");

            migrationBuilder.DropIndex(
                name: "IX_CurrencyAccount_CompaniesId",
                table: "CurrencyAccount");

            migrationBuilder.DropColumn(
                name: "CompaniesId",
                table: "CurrencyAccount");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyAccount_Companyid",
                table: "CurrencyAccount",
                column: "Companyid");

            migrationBuilder.AddForeignKey(
                name: "FK_CurrencyAccount_Companies_Companyid",
                table: "CurrencyAccount",
                column: "Companyid",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CurrencyAccount_Companies_Companyid",
                table: "CurrencyAccount");

            migrationBuilder.DropIndex(
                name: "IX_CurrencyAccount_Companyid",
                table: "CurrencyAccount");

            migrationBuilder.AddColumn<int>(
                name: "CompaniesId",
                table: "CurrencyAccount",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyAccount_CompaniesId",
                table: "CurrencyAccount",
                column: "CompaniesId");

            migrationBuilder.AddForeignKey(
                name: "FK_CurrencyAccount_Companies_CompaniesId",
                table: "CurrencyAccount",
                column: "CompaniesId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
