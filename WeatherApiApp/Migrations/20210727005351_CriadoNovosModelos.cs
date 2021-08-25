using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherApiApp.Migrations
{
    public partial class CriadoNovosModelos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SensDiaria",
                table: "PrevisoesDiariasOpenW");

            migrationBuilder.DropColumn(
                name: "SensEntardecer",
                table: "PrevisoesDiariasOpenW");

            migrationBuilder.DropColumn(
                name: "SensManha",
                table: "PrevisoesDiariasOpenW");

            migrationBuilder.DropColumn(
                name: "SensNoite",
                table: "PrevisoesDiariasOpenW");

            migrationBuilder.DropColumn(
                name: "TempDiaria",
                table: "PrevisoesDiariasOpenW");

            migrationBuilder.DropColumn(
                name: "TempEntardecer",
                table: "PrevisoesDiariasOpenW");

            migrationBuilder.DropColumn(
                name: "TempManha",
                table: "PrevisoesDiariasOpenW");

            migrationBuilder.DropColumn(
                name: "TempMax",
                table: "PrevisoesDiariasOpenW");

            migrationBuilder.DropColumn(
                name: "TempMin",
                table: "PrevisoesDiariasOpenW");

            migrationBuilder.DropColumn(
                name: "TempNoite",
                table: "PrevisoesDiariasOpenW");

            migrationBuilder.CreateTable(
                name: "SensacaoTermica",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrevisaoOpenWId = table.Column<int>(type: "int", nullable: false),
                    SensDiaria = table.Column<float>(type: "real", nullable: false),
                    SensManha = table.Column<float>(type: "real", nullable: false),
                    SensEntardecer = table.Column<float>(type: "real", nullable: false),
                    SensNoite = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SensacaoTermica", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SensacaoTermica_PrevisoesDiariasOpenW_PrevisaoOpenWId",
                        column: x => x.PrevisaoOpenWId,
                        principalTable: "PrevisoesDiariasOpenW",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Temperatura",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrevisaoOpenWId = table.Column<int>(type: "int", nullable: false),
                    TempDiaria = table.Column<float>(type: "real", nullable: false),
                    TempManha = table.Column<float>(type: "real", nullable: false),
                    TempEntardecer = table.Column<float>(type: "real", nullable: false),
                    TempNoite = table.Column<float>(type: "real", nullable: false),
                    TempMin = table.Column<float>(type: "real", nullable: false),
                    TempMax = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temperatura", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Temperatura_PrevisoesDiariasOpenW_PrevisaoOpenWId",
                        column: x => x.PrevisaoOpenWId,
                        principalTable: "PrevisoesDiariasOpenW",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SensacaoTermica_PrevisaoOpenWId",
                table: "SensacaoTermica",
                column: "PrevisaoOpenWId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Temperatura_PrevisaoOpenWId",
                table: "Temperatura",
                column: "PrevisaoOpenWId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SensacaoTermica");

            migrationBuilder.DropTable(
                name: "Temperatura");

            migrationBuilder.AddColumn<float>(
                name: "SensDiaria",
                table: "PrevisoesDiariasOpenW",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "SensEntardecer",
                table: "PrevisoesDiariasOpenW",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "SensManha",
                table: "PrevisoesDiariasOpenW",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "SensNoite",
                table: "PrevisoesDiariasOpenW",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "TempDiaria",
                table: "PrevisoesDiariasOpenW",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "TempEntardecer",
                table: "PrevisoesDiariasOpenW",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "TempManha",
                table: "PrevisoesDiariasOpenW",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "TempMax",
                table: "PrevisoesDiariasOpenW",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "TempMin",
                table: "PrevisoesDiariasOpenW",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "TempNoite",
                table: "PrevisoesDiariasOpenW",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
