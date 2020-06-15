using Microsoft.EntityFrameworkCore.Migrations;

namespace My_Expenses.Data.Migrations
{
    public partial class ProductNotes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Products",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Note",
                table: "Products");
        }
    }
}
