using Microsoft.EntityFrameworkCore.Migrations;

namespace prjMaribelMejia.Migrations
{
    public partial class relacionPdtoCategoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_producto_IdCategoria",
                table: "producto",
                column: "IdCategoria");

            migrationBuilder.AddForeignKey(
                name: "FK_producto_categorias_IdCategoria",
                table: "producto",
                column: "IdCategoria",
                principalTable: "categorias",
                principalColumn: "IdCategoria",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_producto_categorias_IdCategoria",
                table: "producto");

            migrationBuilder.DropIndex(
                name: "IX_producto_IdCategoria",
                table: "producto");
        }
    }
}
