using Microsoft.EntityFrameworkCore.Migrations;

namespace prjMaribelMejia.Migrations
{
    public partial class migracion230222 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdClasificacion",
                table: "categorias");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdClasificacion",
                table: "categorias",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
