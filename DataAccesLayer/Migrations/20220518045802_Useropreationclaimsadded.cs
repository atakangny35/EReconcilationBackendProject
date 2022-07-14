using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccesLayer.Migrations
{
    public partial class Useropreationclaimsadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OperationClaimUser_OperationClaim_UsersId",
                table: "OperationClaimUser");

            migrationBuilder.DropForeignKey(
                name: "FK_OperationClaimUser_Users_UsersId1",
                table: "OperationClaimUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OperationClaimUser",
                table: "OperationClaimUser");

            migrationBuilder.DropIndex(
                name: "IX_OperationClaimUser_UsersId1",
                table: "OperationClaimUser");

            migrationBuilder.RenameColumn(
                name: "UsersId1",
                table: "OperationClaimUser",
                newName: "OperationClaimsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OperationClaimUser",
                table: "OperationClaimUser",
                columns: new[] { "OperationClaimsId", "UsersId" });

            migrationBuilder.CreateTable(
                name: "UserOperationClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Userid = table.Column<int>(type: "int", nullable: false),
                    OperationClaimId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOperationClaim", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OperationClaimUser_UsersId",
                table: "OperationClaimUser",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_OperationClaimUser_OperationClaim_OperationClaimsId",
                table: "OperationClaimUser",
                column: "OperationClaimsId",
                principalTable: "OperationClaim",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OperationClaimUser_Users_UsersId",
                table: "OperationClaimUser",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OperationClaimUser_OperationClaim_OperationClaimsId",
                table: "OperationClaimUser");

            migrationBuilder.DropForeignKey(
                name: "FK_OperationClaimUser_Users_UsersId",
                table: "OperationClaimUser");

            migrationBuilder.DropTable(
                name: "UserOperationClaim");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OperationClaimUser",
                table: "OperationClaimUser");

            migrationBuilder.DropIndex(
                name: "IX_OperationClaimUser_UsersId",
                table: "OperationClaimUser");

            migrationBuilder.RenameColumn(
                name: "OperationClaimsId",
                table: "OperationClaimUser",
                newName: "UsersId1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OperationClaimUser",
                table: "OperationClaimUser",
                columns: new[] { "UsersId", "UsersId1" });

            migrationBuilder.CreateIndex(
                name: "IX_OperationClaimUser_UsersId1",
                table: "OperationClaimUser",
                column: "UsersId1");

            migrationBuilder.AddForeignKey(
                name: "FK_OperationClaimUser_OperationClaim_UsersId",
                table: "OperationClaimUser",
                column: "UsersId",
                principalTable: "OperationClaim",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OperationClaimUser_Users_UsersId1",
                table: "OperationClaimUser",
                column: "UsersId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
