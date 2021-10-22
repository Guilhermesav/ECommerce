using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce.Migrations
{
    public partial class AddCompraTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompraModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdutoId = table.Column<int>(nullable: false),
                    ProdutoNome = table.Column<string>(nullable: true),
                    ProdutoImagem = table.Column<string>(nullable: true),
                    Preço = table.Column<float>(nullable: false),
                    Comprador = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompraModel", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompraModel");
        }
    }
}
