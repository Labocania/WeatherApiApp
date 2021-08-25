using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherApiApp.Migrations
{
    public partial class AdicionadoAltitudeMunicipios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Altitude",
                table: "Municipios",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Altitude",
                table: "Municipios");
        }
    }
}
