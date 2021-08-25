using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherApiApp.Migrations
{
    public partial class AddChuvaToClimaAtual : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chuva",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClimaAtualOpenWId = table.Column<int>(type: "int", nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_Chuva_ClimaAtualOpenWId",
                table: "Chuva",
                column: "ClimaAtualOpenWId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chuva");
        }
    }
}
