using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherApiApp.Migrations
{
    public partial class CriadoPrevisaoDiariaOpenW : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PrevisoesDiariasOpenW",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataPrevisao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAmanhecer = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEntardecer = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FaseLunar = table.Column<float>(type: "real", nullable: false),
                    TempDiaria = table.Column<float>(type: "real", nullable: false),
                    TempManha = table.Column<float>(type: "real", nullable: false),
                    TempEntardecer = table.Column<float>(type: "real", nullable: false),
                    TempNoite = table.Column<float>(type: "real", nullable: false),
                    TempMin = table.Column<float>(type: "real", nullable: false),
                    TempMax = table.Column<float>(type: "real", nullable: false),
                    SensDiaria = table.Column<float>(type: "real", nullable: false),
                    SensManha = table.Column<float>(type: "real", nullable: false),
                    SensEntardecer = table.Column<float>(type: "real", nullable: false),
                    SensNoite = table.Column<float>(type: "real", nullable: false),
                    Pressao = table.Column<float>(type: "real", nullable: false),
                    Humidade = table.Column<int>(type: "int", nullable: false),
                    PontoOrvalho = table.Column<float>(type: "real", nullable: false),
                    CoberturaNuvem = table.Column<int>(type: "int", nullable: false),
                    IndiceUV = table.Column<float>(type: "real", nullable: false),
                    ProbPrecipitacao = table.Column<int>(type: "int", nullable: false),
                    Precipitacao = table.Column<float>(type: "real", nullable: false),
                    Neve = table.Column<float>(type: "real", nullable: false),
                    MunicipioID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrevisoesDiariasOpenW", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PrevisoesDiariasOpenW_Municipios_MunicipioID",
                        column: x => x.MunicipioID,
                        principalTable: "Municipios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Alertas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrevisaoOpenWId = table.Column<int>(type: "int", nullable: false),
                    AlertaFonte = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Evento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataTermino = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alertas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Alertas_PrevisoesDiariasOpenW_PrevisaoOpenWId",
                        column: x => x.PrevisaoOpenWId,
                        principalTable: "PrevisoesDiariasOpenW",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Condicoes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Principal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Detalhes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrevisaoOpenWID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Condicoes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Condicoes_PrevisoesDiariasOpenW_PrevisaoOpenWID",
                        column: x => x.PrevisaoOpenWID,
                        principalTable: "PrevisoesDiariasOpenW",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alertas_PrevisaoOpenWId",
                table: "Alertas",
                column: "PrevisaoOpenWId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Condicoes_PrevisaoOpenWID",
                table: "Condicoes",
                column: "PrevisaoOpenWID");

            migrationBuilder.CreateIndex(
                name: "IX_PrevisoesDiariasOpenW_MunicipioID",
                table: "PrevisoesDiariasOpenW",
                column: "MunicipioID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alertas");

            migrationBuilder.DropTable(
                name: "Condicoes");

            migrationBuilder.DropTable(
                name: "PrevisoesDiariasOpenW");
        }
    }
}
