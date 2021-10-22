using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce.Migrations
{
    public partial class AddVendedor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Preço",
                table: "ProdutoModel");

            migrationBuilder.AddColumn<float>(
                name: "Preco",
                table: "ProdutoModel",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "Vendedor",
                table: "ProdutoModel",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Preco",
                table: "ProdutoModel");

            migrationBuilder.DropColumn(
                name: "Vendedor",
                table: "ProdutoModel");

            migrationBuilder.AddColumn<float>(
                name: "Preço",
                table: "ProdutoModel",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
