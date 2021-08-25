using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherApiApp.Migrations
{
    public partial class CriadoReqOpenW : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReqOpenUV_Municipios_MunicipioId",
                table: "ReqOpenUV");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReqOpenUV",
                table: "ReqOpenUV");

            migrationBuilder.RenameTable(
                name: "ReqOpenUV",
                newName: "RequisicoesOpenUV");

            migrationBuilder.RenameIndex(
                name: "IX_ReqOpenUV_MunicipioId",
                table: "RequisicoesOpenUV",
                newName: "IX_RequisicoesOpenUV_MunicipioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequisicoesOpenUV",
                table: "RequisicoesOpenUV",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "RequisicoesOpenW",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MunicipioId = table.Column<int>(type: "int", nullable: false),
                    HorarioRequisicao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequisicoesOpenW", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RequisicoesOpenW_Municipios_MunicipioId",
                        column: x => x.MunicipioId,
                        principalTable: "Municipios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequisicoesOpenW_MunicipioId",
                table: "RequisicoesOpenW",
                column: "MunicipioId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequisicoesOpenUV_Municipios_MunicipioId",
                table: "RequisicoesOpenUV",
                column: "MunicipioId",
                principalTable: "Municipios",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequisicoesOpenUV_Municipios_MunicipioId",
                table: "RequisicoesOpenUV");

            migrationBuilder.DropTable(
                name: "RequisicoesOpenW");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequisicoesOpenUV",
                table: "RequisicoesOpenUV");

            migrationBuilder.RenameTable(
                name: "RequisicoesOpenUV",
                newName: "ReqOpenUV");

            migrationBuilder.RenameIndex(
                name: "IX_RequisicoesOpenUV_MunicipioId",
                table: "ReqOpenUV",
                newName: "IX_ReqOpenUV_MunicipioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReqOpenUV",
                table: "ReqOpenUV",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ReqOpenUV_Municipios_MunicipioId",
                table: "ReqOpenUV",
                column: "MunicipioId",
                principalTable: "Municipios",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
