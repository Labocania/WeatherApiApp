using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherApiApp.Migrations
{
    public partial class AddClimaAtual : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClimaAtualOpenWID",
                table: "Condicoes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ClimasAtuaisOpenW",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MunicipioID = table.Column<int>(type: "int", nullable: true),
                    DataPrevisao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAmanhecer = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEntardecer = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SensacaoTermica = table.Column<float>(type: "real", nullable: false),
                    Pressao = table.Column<float>(type: "real", nullable: false),
                    Humidade = table.Column<float>(type: "real", nullable: false),
                    PontoOrvalho = table.Column<float>(type: "real", nullable: false),
                    IndiceUV = table.Column<float>(type: "real", nullable: false),
                    CoberturaNuvem = table.Column<float>(type: "real", nullable: false),
                    Visibilidade = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClimasAtuaisOpenW", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ClimasAtuaisOpenW_Municipios_MunicipioID",
                        column: x => x.MunicipioID,
                        principalTable: "Municipios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Condicoes_ClimaAtualOpenWID",
                table: "Condicoes",
                column: "ClimaAtualOpenWID");

            migrationBuilder.CreateIndex(
                name: "IX_ClimasAtuaisOpenW_MunicipioID",
                table: "ClimasAtuaisOpenW",
                column: "MunicipioID");

            migrationBuilder.AddForeignKey(
                name: "FK_Condicoes_ClimasAtuaisOpenW_ClimaAtualOpenWID",
                table: "Condicoes",
                column: "ClimaAtualOpenWID",
                principalTable: "ClimasAtuaisOpenW",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Condicoes_ClimasAtuaisOpenW_ClimaAtualOpenWID",
                table: "Condicoes");

            migrationBuilder.DropTable(
                name: "ClimasAtuaisOpenW");

            migrationBuilder.DropIndex(
                name: "IX_Condicoes_ClimaAtualOpenWID",
                table: "Condicoes");

            migrationBuilder.DropColumn(
                name: "ClimaAtualOpenWID",
                table: "Condicoes");
        }
    }
}
