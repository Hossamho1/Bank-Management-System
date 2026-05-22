using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bank_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class relationOneToOneBetween : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BranchCode",
                table: "Accounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AccountId",
                table: "Transactions",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_BranchCode",
                table: "Accounts",
                column: "BranchCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Branches_BranchCode",
                table: "Accounts",
                column: "BranchCode",
                principalTable: "Branches",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Accounts_AccountId",
                table: "Transactions",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Branches_BranchCode",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Accounts_AccountId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_AccountId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_BranchCode",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "BranchCode",
                table: "Accounts");
        }
    }
}
