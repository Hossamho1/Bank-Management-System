using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bank_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class relationOneToOneBetweenManagerAndBranch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ManagerId",
                table: "Branches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Branches_ManagerId",
                table: "Branches",
                column: "ManagerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_Managers_ManagerId",
                table: "Branches",
                column: "ManagerId",
                principalTable: "Managers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branches_Managers_ManagerId",
                table: "Branches");

            migrationBuilder.DropIndex(
                name: "IX_Branches_ManagerId",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Branches");
        }
    }
}
