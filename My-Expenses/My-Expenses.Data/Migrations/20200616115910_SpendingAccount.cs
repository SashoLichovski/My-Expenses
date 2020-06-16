using Microsoft.EntityFrameworkCore.Migrations;

namespace My_Expenses.Data.Migrations
{
    public partial class SpendingAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SpendingAccount",
                table: "Accounts",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpendingAccount",
                table: "Accounts");
        }
    }
}
