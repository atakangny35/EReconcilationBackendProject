using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccesLayer.Migrations
{
    public partial class dd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mailPattern_Companies_CompaniesId",
                table: "mailPattern");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "mailPattern");

            migrationBuilder.AlterColumn<int>(
                name: "CompaniesId",
                table: "mailPattern",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_mailPattern_Companies_CompaniesId",
                table: "mailPattern",
                column: "CompaniesId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mailPattern_Companies_CompaniesId",
                table: "mailPattern");

            migrationBuilder.AlterColumn<int>(
                name: "CompaniesId",
                table: "mailPattern",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "mailPattern",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_mailPattern_Companies_CompaniesId",
                table: "mailPattern",
                column: "CompaniesId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
