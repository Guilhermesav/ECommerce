using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce.Migrations
{
    public partial class changePrecoType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Preco",
                table: "ProdutoModel",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<double>(
                name: "Preço",
                table: "CompraModel",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Preco",
                table: "ProdutoModel",
                type: "real",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<float>(
                name: "Preço",
                table: "CompraModel",
                type: "real",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
