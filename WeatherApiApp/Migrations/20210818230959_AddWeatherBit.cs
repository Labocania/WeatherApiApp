using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherApiApp.Migrations
{
    public partial class AddWeatherBit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeatherBit",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MunicipioID = table.Column<int>(type: "int", nullable: true),
                    DataPrevisao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Temperatura = table.Column<float>(type: "real", nullable: false),
                    SensacaoTermica = table.Column<float>(type: "real", nullable: false),
                    Humidade = table.Column<float>(type: "real", nullable: false),
                    PontoOrvalho = table.Column<float>(type: "real", nullable: false),
                    CoberturaNuvem = table.Column<float>(type: "real", nullable: false),
                    Visibilidade = table.Column<float>(type: "real", nullable: false),
                    Precipitacao = table.Column<float>(type: "real", nullable: false),
                    IndiceUV = table.Column<float>(type: "real", nullable: false),
                    QualidadeAr = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherBit", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WeatherBit_Municipios_MunicipioID",
                        column: x => x.MunicipioID,
                        principalTable: "Municipios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WeatherBit_MunicipioID",
                table: "WeatherBit",
                column: "MunicipioID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeatherBit");
        }
    }
}
