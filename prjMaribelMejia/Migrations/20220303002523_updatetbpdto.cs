using Microsoft.EntityFrameworkCore.Migrations;

namespace prjMaribelMejia.Migrations
{
    public partial class updatetbpdto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdMarca",
                table: "producto",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_producto_IdMarca",
                table: "producto",
                column: "IdMarca");

            migrationBuilder.AddForeignKey(
                name: "FK_producto_marcas_IdMarca",
                table: "producto",
                column: "IdMarca",
                principalTable: "marcas",
                principalColumn: "IdMarca",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_producto_marcas_IdMarca",
                table: "producto");

            migrationBuilder.DropIndex(
                name: "IX_producto_IdMarca",
                table: "producto");

            migrationBuilder.DropColumn(
                name: "IdMarca",
                table: "producto");
        }
    }
}
