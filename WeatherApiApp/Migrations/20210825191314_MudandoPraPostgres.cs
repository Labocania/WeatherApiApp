using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace WeatherApiApp.Migrations
{
    public partial class MudandoPraPostgres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Municipios",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    Latitude = table.Column<float>(type: "real", nullable: false),
                    Longitude = table.Column<float>(type: "real", nullable: false),
                    Altitude = table.Column<float>(type: "real", nullable: false),
                    FusoIana = table.Column<string>(type: "text", nullable: true),
                    FusoWin = table.Column<string>(type: "text", nullable: true),
                    UltimaModificacao = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipios", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ClimasAtuaisOpenW",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MunicipioID = table.Column<int>(type: "integer", nullable: true),
                    DataPrevisao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DataAmanhecer = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DataEntardecer = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "PrevisoesDiariasOpenW",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MunicipioID = table.Column<int>(type: "integer", nullable: true),
                    DataPrevisao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DataAmanhecer = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DataEntardecer = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    FaseLunar = table.Column<float>(type: "real", nullable: false),
                    Pressao = table.Column<float>(type: "real", nullable: false),
                    Humidade = table.Column<float>(type: "real", nullable: false),
                    PontoOrvalho = table.Column<float>(type: "real", nullable: false),
                    CoberturaNuvem = table.Column<float>(type: "real", nullable: false),
                    IndiceUV = table.Column<float>(type: "real", nullable: false),
                    ProbPrecipitacao = table.Column<float>(type: "real", nullable: false),
                    Precipitacao = table.Column<float>(type: "real", nullable: false),
                    Neve = table.Column<float>(type: "real", nullable: false)
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
                name: "PrevisoesOpenUV",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MunicipioID = table.Column<int>(type: "integer", nullable: true),
                    IndiceUV = table.Column<float>(type: "real", nullable: false),
                    Horario = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrevisoesOpenUV", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PrevisoesOpenUV_Municipios_MunicipioID",
                        column: x => x.MunicipioID,
                        principalTable: "Municipios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WeatherBit",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MunicipioID = table.Column<int>(type: "integer", nullable: true),
                    DataPrevisao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "Chuva",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClimaAtualOpenWId = table.Column<int>(type: "integer", nullable: false),
                    ChuvaUltimaHora = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chuva", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Chuva_ClimasAtuaisOpenW_ClimaAtualOpenWId",
                        column: x => x.ClimaAtualOpenWId,
                        principalTable: "ClimasAtuaisOpenW",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Alertas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PrevisaoOpenWID = table.Column<int>(type: "integer", nullable: true),
                    AlertaFonte = table.Column<string>(type: "text", nullable: true),
                    Evento = table.Column<string>(type: "text", nullable: true),
                    DataInicio = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DataTermino = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alertas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Alertas_PrevisoesDiariasOpenW_PrevisaoOpenWID",
                        column: x => x.PrevisaoOpenWID,
                        principalTable: "PrevisoesDiariasOpenW",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Condicoes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PrevisaoOpenWID = table.Column<int>(type: "integer", nullable: true),
                    ClimaAtualOpenWID = table.Column<int>(type: "integer", nullable: true),
                    Principal = table.Column<string>(type: "text", nullable: true),
                    Detalhes = table.Column<string>(type: "text", nullable: true),
                    Icone = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Condicoes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Condicoes_ClimasAtuaisOpenW_ClimaAtualOpenWID",
                        column: x => x.ClimaAtualOpenWID,
                        principalTable: "ClimasAtuaisOpenW",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Condicoes_PrevisoesDiariasOpenW_PrevisaoOpenWID",
                        column: x => x.PrevisaoOpenWID,
                        principalTable: "PrevisoesDiariasOpenW",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sensacoes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PrevisaoOpenWId = table.Column<int>(type: "integer", nullable: false),
                    SensDiaria = table.Column<float>(type: "real", nullable: false),
                    SensManha = table.Column<float>(type: "real", nullable: false),
                    SensEntardecer = table.Column<float>(type: "real", nullable: false),
                    SensNoite = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensacoes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Sensacoes_PrevisoesDiariasOpenW_PrevisaoOpenWId",
                        column: x => x.PrevisaoOpenWId,
                        principalTable: "PrevisoesDiariasOpenW",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Temperaturas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PrevisaoOpenWId = table.Column<int>(type: "integer", nullable: false),
                    TempDiaria = table.Column<float>(type: "real", nullable: false),
                    TempManha = table.Column<float>(type: "real", nullable: false),
                    TempEntardecer = table.Column<float>(type: "real", nullable: false),
                    TempNoite = table.Column<float>(type: "real", nullable: false),
                    TempMin = table.Column<float>(type: "real", nullable: false),
                    TempMax = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temperaturas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Temperaturas_PrevisoesDiariasOpenW_PrevisaoOpenWId",
                        column: x => x.PrevisaoOpenWId,
                        principalTable: "PrevisoesDiariasOpenW",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alertas_PrevisaoOpenWID",
                table: "Alertas",
                column: "PrevisaoOpenWID");

            migrationBuilder.CreateIndex(
                name: "IX_Chuva_ClimaAtualOpenWId",
                table: "Chuva",
                column: "ClimaAtualOpenWId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClimasAtuaisOpenW_MunicipioID",
                table: "ClimasAtuaisOpenW",
                column: "MunicipioID");

            migrationBuilder.CreateIndex(
                name: "IX_Condicoes_ClimaAtualOpenWID",
                table: "Condicoes",
                column: "ClimaAtualOpenWID");

            migrationBuilder.CreateIndex(
                name: "IX_Condicoes_PrevisaoOpenWID",
                table: "Condicoes",
                column: "PrevisaoOpenWID");

            migrationBuilder.CreateIndex(
                name: "IX_PrevisoesDiariasOpenW_MunicipioID",
                table: "PrevisoesDiariasOpenW",
                column: "MunicipioID");

            migrationBuilder.CreateIndex(
                name: "IX_PrevisoesOpenUV_MunicipioID",
                table: "PrevisoesOpenUV",
                column: "MunicipioID");

            migrationBuilder.CreateIndex(
                name: "IX_Sensacoes_PrevisaoOpenWId",
                table: "Sensacoes",
                column: "PrevisaoOpenWId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Temperaturas_PrevisaoOpenWId",
                table: "Temperaturas",
                column: "PrevisaoOpenWId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeatherBit_MunicipioID",
                table: "WeatherBit",
                column: "MunicipioID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alertas");

            migrationBuilder.DropTable(
                name: "Chuva");

            migrationBuilder.DropTable(
                name: "Condicoes");

            migrationBuilder.DropTable(
                name: "PrevisoesOpenUV");

            migrationBuilder.DropTable(
                name: "Sensacoes");

            migrationBuilder.DropTable(
                name: "Temperaturas");

            migrationBuilder.DropTable(
                name: "WeatherBit");

            migrationBuilder.DropTable(
                name: "ClimasAtuaisOpenW");

            migrationBuilder.DropTable(
                name: "PrevisoesDiariasOpenW");

            migrationBuilder.DropTable(
                name: "Municipios");
        }
    }
}
