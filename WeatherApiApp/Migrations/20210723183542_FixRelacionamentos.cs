using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherApiApp.Migrations
{
    public partial class FixRelacionamentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrevisoesOpenUV_RequisicoesOpenUV_ReqOpenUVID",
                table: "PrevisoesOpenUV");

            migrationBuilder.DropForeignKey(
                name: "FK_RequisicoesOpenUV_Municipios_MunicipioID",
                table: "RequisicoesOpenUV");

            migrationBuilder.DropForeignKey(
                name: "FK_RequisicoesOpenW_Municipios_MunicipioID",
                table: "RequisicoesOpenW");

            migrationBuilder.DropIndex(
                name: "IX_RequisicoesOpenW_MunicipioID",
                table: "RequisicoesOpenW");

            migrationBuilder.DropIndex(
                name: "IX_RequisicoesOpenUV_MunicipioID",
                table: "RequisicoesOpenUV");

            migrationBuilder.DropColumn(
                name: "MunicipioID",
                table: "RequisicoesOpenW");

            migrationBuilder.DropColumn(
                name: "MunicipioID",
                table: "RequisicoesOpenUV");

            migrationBuilder.RenameColumn(
                name: "ReqOpenUVID",
                table: "PrevisoesOpenUV",
                newName: "RequisicaoOpenUVID");

            migrationBuilder.RenameIndex(
                name: "IX_PrevisoesOpenUV_ReqOpenUVID",
                table: "PrevisoesOpenUV",
                newName: "IX_PrevisoesOpenUV_RequisicaoOpenUVID");

            migrationBuilder.AddColumn<int>(
                name: "MunicipioID",
                table: "PrevisoesOpenUV",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PrevisoesOpenUV_MunicipioID",
                table: "PrevisoesOpenUV",
                column: "MunicipioID");

            migrationBuilder.AddForeignKey(
                name: "FK_PrevisoesOpenUV_Municipios_MunicipioID",
                table: "PrevisoesOpenUV",
                column: "MunicipioID",
                principalTable: "Municipios",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PrevisoesOpenUV_RequisicoesOpenUV_RequisicaoOpenUVID",
                table: "PrevisoesOpenUV",
                column: "RequisicaoOpenUVID",
                principalTable: "RequisicoesOpenUV",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrevisoesOpenUV_Municipios_MunicipioID",
                table: "PrevisoesOpenUV");

            migrationBuilder.DropForeignKey(
                name: "FK_PrevisoesOpenUV_RequisicoesOpenUV_RequisicaoOpenUVID",
                table: "PrevisoesOpenUV");

            migrationBuilder.DropIndex(
                name: "IX_PrevisoesOpenUV_MunicipioID",
                table: "PrevisoesOpenUV");

            migrationBuilder.DropColumn(
                name: "MunicipioID",
                table: "PrevisoesOpenUV");

            migrationBuilder.RenameColumn(
                name: "RequisicaoOpenUVID",
                table: "PrevisoesOpenUV",
                newName: "ReqOpenUVID");

            migrationBuilder.RenameIndex(
                name: "IX_PrevisoesOpenUV_RequisicaoOpenUVID",
                table: "PrevisoesOpenUV",
                newName: "IX_PrevisoesOpenUV_ReqOpenUVID");

            migrationBuilder.AddColumn<int>(
                name: "MunicipioID",
                table: "RequisicoesOpenW",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MunicipioID",
                table: "RequisicoesOpenUV",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RequisicoesOpenW_MunicipioID",
                table: "RequisicoesOpenW",
                column: "MunicipioID");

            migrationBuilder.CreateIndex(
                name: "IX_RequisicoesOpenUV_MunicipioID",
                table: "RequisicoesOpenUV",
                column: "MunicipioID");

            migrationBuilder.AddForeignKey(
                name: "FK_PrevisoesOpenUV_RequisicoesOpenUV_ReqOpenUVID",
                table: "PrevisoesOpenUV",
                column: "ReqOpenUVID",
                principalTable: "RequisicoesOpenUV",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RequisicoesOpenUV_Municipios_MunicipioID",
                table: "RequisicoesOpenUV",
                column: "MunicipioID",
                principalTable: "Municipios",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RequisicoesOpenW_Municipios_MunicipioID",
                table: "RequisicoesOpenW",
                column: "MunicipioID",
                principalTable: "Municipios",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
