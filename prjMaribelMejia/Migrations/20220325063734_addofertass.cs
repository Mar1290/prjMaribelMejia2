using Microsoft.EntityFrameworkCore.Migrations;

namespace prjMaribelMejia.Migrations
{
    public partial class addofertass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ofertas_modulos_IdProducto",
                table: "ofertas");

            migrationBuilder.CreateIndex(
                name: "IX_ofertas_IdModulo",
                table: "ofertas",
                column: "IdModulo");

            migrationBuilder.AddForeignKey(
                name: "FK_ofertas_modulos_IdModulo",
                table: "ofertas",
                column: "IdModulo",
                principalTable: "modulos",
                principalColumn: "IdModulo",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ofertas_modulos_IdModulo",
                table: "ofertas");

            migrationBuilder.DropIndex(
                name: "IX_ofertas_IdModulo",
                table: "ofertas");

            migrationBuilder.AddForeignKey(
                name: "FK_ofertas_modulos_IdProducto",
                table: "ofertas",
                column: "IdProducto",
                principalTable: "modulos",
                principalColumn: "IdModulo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
