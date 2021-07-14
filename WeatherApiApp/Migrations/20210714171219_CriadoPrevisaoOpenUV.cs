using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherApiApp.Migrations
{
    public partial class CriadoPrevisaoOpenUV : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PrevisoesOpenUV",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReqOpenUVId = table.Column<int>(type: "int", nullable: false),
                    IndiceUV = table.Column<float>(type: "real", nullable: false),
                    Horario = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrevisoesOpenUV", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PrevisoesOpenUV_RequisicoesOpenUV_ReqOpenUVId",
                        column: x => x.ReqOpenUVId,
                        principalTable: "RequisicoesOpenUV",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PrevisoesOpenUV_ReqOpenUVId",
                table: "PrevisoesOpenUV",
                column: "ReqOpenUVId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrevisoesOpenUV");
        }
    }
}
