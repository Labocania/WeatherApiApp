using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherApiApp.Migrations
{
    public partial class RemoveReqOpenW : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequisicoesOpenW");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RequisicoesOpenW",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HorarioRequisicao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequisicoesOpenW", x => x.ID);
                });
        }
    }
}
