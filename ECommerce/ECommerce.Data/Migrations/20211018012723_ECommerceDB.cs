using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce.Migrations
{
    public partial class ECommerceDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProdutoModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    Categoria = table.Column<string>(nullable: true),
                    Preço = table.Column<float>(nullable: false),
                    UriBlob = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoModel", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProdutoModel");
        }
    }
}
