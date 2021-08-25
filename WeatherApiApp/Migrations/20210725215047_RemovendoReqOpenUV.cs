using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherApiApp.Migrations
{
    public partial class RemovendoReqOpenUV : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrevisoesOpenUV_RequisicoesOpenUV_RequisicaoOpenUVID",
                table: "PrevisoesOpenUV");

            migrationBuilder.DropTable(
                name: "RequisicoesOpenUV");

            migrationBuilder.DropIndex(
                name: "IX_PrevisoesOpenUV_RequisicaoOpenUVID",
                table: "PrevisoesOpenUV");

            migrationBuilder.DropColumn(
                name: "RequisicaoOpenUVID",
                table: "PrevisoesOpenUV");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RequisicaoOpenUVID",
                table: "PrevisoesOpenUV",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RequisicoesOpenUV",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HorarioRequisicao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequisicoesOpenUV", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PrevisoesOpenUV_RequisicaoOpenUVID",
                table: "PrevisoesOpenUV",
                column: "RequisicaoOpenUVID");

            migrationBuilder.AddForeignKey(
                name: "FK_PrevisoesOpenUV_RequisicoesOpenUV_RequisicaoOpenUVID",
                table: "PrevisoesOpenUV",
                column: "RequisicaoOpenUVID",
                principalTable: "RequisicoesOpenUV",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
