using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccesLayer.Migrations
{
    public partial class Useropreationclaimsadded2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OperationClaimUser");

            migrationBuilder.AddColumn<int>(
                name: "OperationClaimId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_OperationClaimId",
                table: "Users",
                column: "OperationClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaim_OperationClaimId",
                table: "UserOperationClaim",
                column: "OperationClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaim_Userid",
                table: "UserOperationClaim",
                column: "Userid");

            migrationBuilder.AddForeignKey(
                name: "FK_UserOperationClaim_OperationClaim_OperationClaimId",
                table: "UserOperationClaim",
                column: "OperationClaimId",
                principalTable: "OperationClaim",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserOperationClaim_Users_Userid",
                table: "UserOperationClaim",
                column: "Userid",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_OperationClaim_OperationClaimId",
                table: "Users",
                column: "OperationClaimId",
                principalTable: "OperationClaim",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserOperationClaim_OperationClaim_OperationClaimId",
                table: "UserOperationClaim");

            migrationBuilder.DropForeignKey(
                name: "FK_UserOperationClaim_Users_Userid",
                table: "UserOperationClaim");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_OperationClaim_OperationClaimId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_OperationClaimId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_UserOperationClaim_OperationClaimId",
                table: "UserOperationClaim");

            migrationBuilder.DropIndex(
                name: "IX_UserOperationClaim_Userid",
                table: "UserOperationClaim");

            migrationBuilder.DropColumn(
                name: "OperationClaimId",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "OperationClaimUser",
                columns: table => new
                {
                    OperationClaimsId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationClaimUser", x => new { x.OperationClaimsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_OperationClaimUser_OperationClaim_OperationClaimsId",
                        column: x => x.OperationClaimsId,
                        principalTable: "OperationClaim",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OperationClaimUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OperationClaimUser_UsersId",
                table: "OperationClaimUser",
                column: "UsersId");
        }
    }
}
