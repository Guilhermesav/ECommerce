using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce.Migrations
{
    public partial class addPagamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FormaDePagamento",
                table: "CompraModel",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FormaDePagamento",
                table: "CompraModel");
        }
    }
}
