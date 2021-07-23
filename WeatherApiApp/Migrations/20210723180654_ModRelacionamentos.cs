using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherApiApp.Migrations
{
    public partial class ModRelacionamentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrevisoesOpenUV_RequisicoesOpenUV_ReqOpenUVId",
                table: "PrevisoesOpenUV");

            migrationBuilder.DropForeignKey(
                name: "FK_RequisicoesOpenUV_Municipios_MunicipioId",
                table: "RequisicoesOpenUV");

            migrationBuilder.DropForeignKey(
                name: "FK_RequisicoesOpenW_Municipios_MunicipioId",
                table: "RequisicoesOpenW");

            migrationBuilder.RenameColumn(
                name: "MunicipioId",
                table: "RequisicoesOpenW",
                newName: "MunicipioID");

            migrationBuilder.RenameIndex(
                name: "IX_RequisicoesOpenW_MunicipioId",
                table: "RequisicoesOpenW",
                newName: "IX_RequisicoesOpenW_MunicipioID");

            migrationBuilder.RenameColumn(
                name: "MunicipioId",
                table: "RequisicoesOpenUV",
                newName: "MunicipioID");

            migrationBuilder.RenameIndex(
                name: "IX_RequisicoesOpenUV_MunicipioId",
                table: "RequisicoesOpenUV",
                newName: "IX_RequisicoesOpenUV_MunicipioID");

            migrationBuilder.RenameColumn(
                name: "ReqOpenUVId",
                table: "PrevisoesOpenUV",
                newName: "ReqOpenUVID");

            migrationBuilder.RenameIndex(
                name: "IX_PrevisoesOpenUV_ReqOpenUVId",
                table: "PrevisoesOpenUV",
                newName: "IX_PrevisoesOpenUV_ReqOpenUVID");

            migrationBuilder.AlterColumn<int>(
                name: "MunicipioID",
                table: "RequisicoesOpenW",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MunicipioID",
                table: "RequisicoesOpenUV",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ReqOpenUVID",
                table: "PrevisoesOpenUV",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "MunicipioID",
                table: "RequisicoesOpenW",
                newName: "MunicipioId");

            migrationBuilder.RenameIndex(
                name: "IX_RequisicoesOpenW_MunicipioID",
                table: "RequisicoesOpenW",
                newName: "IX_RequisicoesOpenW_MunicipioId");

            migrationBuilder.RenameColumn(
                name: "MunicipioID",
                table: "RequisicoesOpenUV",
                newName: "MunicipioId");

            migrationBuilder.RenameIndex(
                name: "IX_RequisicoesOpenUV_MunicipioID",
                table: "RequisicoesOpenUV",
                newName: "IX_RequisicoesOpenUV_MunicipioId");

            migrationBuilder.RenameColumn(
                name: "ReqOpenUVID",
                table: "PrevisoesOpenUV",
                newName: "ReqOpenUVId");

            migrationBuilder.RenameIndex(
                name: "IX_PrevisoesOpenUV_ReqOpenUVID",
                table: "PrevisoesOpenUV",
                newName: "IX_PrevisoesOpenUV_ReqOpenUVId");

            migrationBuilder.AlterColumn<int>(
                name: "MunicipioId",
                table: "RequisicoesOpenW",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MunicipioId",
                table: "RequisicoesOpenUV",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ReqOpenUVId",
                table: "PrevisoesOpenUV",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PrevisoesOpenUV_RequisicoesOpenUV_ReqOpenUVId",
                table: "PrevisoesOpenUV",
                column: "ReqOpenUVId",
                principalTable: "RequisicoesOpenUV",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequisicoesOpenUV_Municipios_MunicipioId",
                table: "RequisicoesOpenUV",
                column: "MunicipioId",
                principalTable: "Municipios",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequisicoesOpenW_Municipios_MunicipioId",
                table: "RequisicoesOpenW",
                column: "MunicipioId",
                principalTable: "Municipios",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
