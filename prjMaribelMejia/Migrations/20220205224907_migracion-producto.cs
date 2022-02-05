using Microsoft.EntityFrameworkCore.Migrations;

namespace prjMaribelMejia.Migrations
{
    public partial class migracionproducto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "producto",
                columns: table => new
                {
                    IdProducto = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Producto = table.Column<string>(maxLength: 100, nullable: false),
                    IdCategoria = table.Column<int>(nullable: false),
                    Categoria = table.Column<string>(maxLength: 50, nullable: false),
                    Precio = table.Column<decimal>(nullable: false),
                    Descripcion = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_producto", x => x.IdProducto);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "producto");
        }
    }
}
