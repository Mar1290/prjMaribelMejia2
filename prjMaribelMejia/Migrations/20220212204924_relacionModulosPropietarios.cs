using Microsoft.EntityFrameworkCore.Migrations;

namespace prjMaribelMejia.Migrations
{
    public partial class relacionModulosPropietarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_modulos_IdPropietario",
                table: "modulos",
                column: "IdPropietario");

            migrationBuilder.AddForeignKey(
                name: "FK_modulos_propietarios_IdPropietario",
                table: "modulos",
                column: "IdPropietario",
                principalTable: "propietarios",
                principalColumn: "IdPropietario",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_modulos_propietarios_IdPropietario",
                table: "modulos");

            migrationBuilder.DropIndex(
                name: "IX_modulos_IdPropietario",
                table: "modulos");
        }
    }
}
