using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccesLayer.Migrations
{
    public partial class AccountReconcillationsDetailaltered : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountReconcillationsDetail_AccountReconcillation_AccountReconcillationsId",
                table: "AccountReconcillationsDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountReconcillationsDetail_Currency_CurrencyId",
                table: "AccountReconcillationsDetail");

            migrationBuilder.DropIndex(
                name: "IX_AccountReconcillationsDetail_AccountReconcillationsId",
                table: "AccountReconcillationsDetail");

            migrationBuilder.AlterColumn<int>(
                name: "CurrencyId",
                table: "AccountReconcillationsDetail",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccountReconcillationId",
                table: "AccountReconcillationsDetail",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountReconcillationsDetail_AccountReconcillationId",
                table: "AccountReconcillationsDetail",
                column: "AccountReconcillationId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountReconcillationsDetail_AccountReconcillation_AccountReconcillationId",
                table: "AccountReconcillationsDetail",
                column: "AccountReconcillationId",
                principalTable: "AccountReconcillation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountReconcillationsDetail_Currency_CurrencyId",
                table: "AccountReconcillationsDetail",
                column: "CurrencyId",
                principalTable: "Currency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountReconcillationsDetail_AccountReconcillation_AccountReconcillationId",
                table: "AccountReconcillationsDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountReconcillationsDetail_Currency_CurrencyId",
                table: "AccountReconcillationsDetail");

            migrationBuilder.DropIndex(
                name: "IX_AccountReconcillationsDetail_AccountReconcillationId",
                table: "AccountReconcillationsDetail");

            migrationBuilder.DropColumn(
                name: "AccountReconcillationId",
                table: "AccountReconcillationsDetail");

            migrationBuilder.AlterColumn<int>(
                name: "CurrencyId",
                table: "AccountReconcillationsDetail",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_AccountReconcillationsDetail_AccountReconcillationsId",
                table: "AccountReconcillationsDetail",
                column: "AccountReconcillationsId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountReconcillationsDetail_AccountReconcillation_AccountReconcillationsId",
                table: "AccountReconcillationsDetail",
                column: "AccountReconcillationsId",
                principalTable: "AccountReconcillation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountReconcillationsDetail_Currency_CurrencyId",
                table: "AccountReconcillationsDetail",
                column: "CurrencyId",
                principalTable: "Currency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
