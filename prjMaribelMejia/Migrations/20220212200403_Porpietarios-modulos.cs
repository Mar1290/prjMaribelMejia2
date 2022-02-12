using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace prjMaribelMejia.Migrations
{
    public partial class Porpietariosmodulos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "modulos",
                columns: table => new
                {
                    IdModulo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPropietario = table.Column<int>(nullable: false),
                    Modulo = table.Column<string>(maxLength: 50, nullable: false),
                    FechaCreacionModulo = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_modulos", x => x.IdModulo);
                });

            migrationBuilder.CreateTable(
                name: "propietarios",
                columns: table => new
                {
                    IdPropietario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombrePropietario = table.Column<string>(maxLength: 50, nullable: false),
                    IdentificacionPropietario = table.Column<string>(maxLength: 14, nullable: false),
                    DireccionPropietario = table.Column<int>(maxLength: 300, nullable: false),
                    TelefonoPropietario = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_propietarios", x => x.IdPropietario);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "modulos");

            migrationBuilder.DropTable(
                name: "propietarios");
        }
    }
}
