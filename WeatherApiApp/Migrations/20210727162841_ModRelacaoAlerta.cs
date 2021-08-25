using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherApiApp.Migrations
{
    public partial class ModRelacaoAlerta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alertas_PrevisoesDiariasOpenW_PrevisaoOpenWId",
                table: "Alertas");

            migrationBuilder.DropForeignKey(
                name: "FK_SensacaoTermica_PrevisoesDiariasOpenW_PrevisaoOpenWId",
                table: "SensacaoTermica");

            migrationBuilder.DropForeignKey(
                name: "FK_Temperatura_PrevisoesDiariasOpenW_PrevisaoOpenWId",
                table: "Temperatura");

            migrationBuilder.DropIndex(
                name: "IX_Alertas_PrevisaoOpenWId",
                table: "Alertas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Temperatura",
                table: "Temperatura");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SensacaoTermica",
                table: "SensacaoTermica");

            migrationBuilder.RenameTable(
                name: "Temperatura",
                newName: "Temperaturas");

            migrationBuilder.RenameTable(
                name: "SensacaoTermica",
                newName: "Sensacoes");

            migrationBuilder.RenameColumn(
                name: "PrevisaoOpenWId",
                table: "Alertas",
                newName: "PrevisaoOpenWID");

            migrationBuilder.RenameIndex(
                name: "IX_Temperatura_PrevisaoOpenWId",
                table: "Temperaturas",
                newName: "IX_Temperaturas_PrevisaoOpenWId");

            migrationBuilder.RenameIndex(
                name: "IX_SensacaoTermica_PrevisaoOpenWId",
                table: "Sensacoes",
                newName: "IX_Sensacoes_PrevisaoOpenWId");

            migrationBuilder.AlterColumn<int>(
                name: "PrevisaoOpenWID",
                table: "Alertas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Temperaturas",
                table: "Temperaturas",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sensacoes",
                table: "Sensacoes",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Alertas_PrevisaoOpenWID",
                table: "Alertas",
                column: "PrevisaoOpenWID");

            migrationBuilder.AddForeignKey(
                name: "FK_Alertas_PrevisoesDiariasOpenW_PrevisaoOpenWID",
                table: "Alertas",
                column: "PrevisaoOpenWID",
                principalTable: "PrevisoesDiariasOpenW",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sensacoes_PrevisoesDiariasOpenW_PrevisaoOpenWId",
                table: "Sensacoes",
                column: "PrevisaoOpenWId",
                principalTable: "PrevisoesDiariasOpenW",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Temperaturas_PrevisoesDiariasOpenW_PrevisaoOpenWId",
                table: "Temperaturas",
                column: "PrevisaoOpenWId",
                principalTable: "PrevisoesDiariasOpenW",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alertas_PrevisoesDiariasOpenW_PrevisaoOpenWID",
                table: "Alertas");

            migrationBuilder.DropForeignKey(
                name: "FK_Sensacoes_PrevisoesDiariasOpenW_PrevisaoOpenWId",
                table: "Sensacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Temperaturas_PrevisoesDiariasOpenW_PrevisaoOpenWId",
                table: "Temperaturas");

            migrationBuilder.DropIndex(
                name: "IX_Alertas_PrevisaoOpenWID",
                table: "Alertas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Temperaturas",
                table: "Temperaturas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sensacoes",
                table: "Sensacoes");

            migrationBuilder.RenameTable(
                name: "Temperaturas",
                newName: "Temperatura");

            migrationBuilder.RenameTable(
                name: "Sensacoes",
                newName: "SensacaoTermica");

            migrationBuilder.RenameColumn(
                name: "PrevisaoOpenWID",
                table: "Alertas",
                newName: "PrevisaoOpenWId");

            migrationBuilder.RenameIndex(
                name: "IX_Temperaturas_PrevisaoOpenWId",
                table: "Temperatura",
                newName: "IX_Temperatura_PrevisaoOpenWId");

            migrationBuilder.RenameIndex(
                name: "IX_Sensacoes_PrevisaoOpenWId",
                table: "SensacaoTermica",
                newName: "IX_SensacaoTermica_PrevisaoOpenWId");

            migrationBuilder.AlterColumn<int>(
                name: "PrevisaoOpenWId",
                table: "Alertas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Temperatura",
                table: "Temperatura",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SensacaoTermica",
                table: "SensacaoTermica",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Alertas_PrevisaoOpenWId",
                table: "Alertas",
                column: "PrevisaoOpenWId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Alertas_PrevisoesDiariasOpenW_PrevisaoOpenWId",
                table: "Alertas",
                column: "PrevisaoOpenWId",
                principalTable: "PrevisoesDiariasOpenW",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SensacaoTermica_PrevisoesDiariasOpenW_PrevisaoOpenWId",
                table: "SensacaoTermica",
                column: "PrevisaoOpenWId",
                principalTable: "PrevisoesDiariasOpenW",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Temperatura_PrevisoesDiariasOpenW_PrevisaoOpenWId",
                table: "Temperatura",
                column: "PrevisaoOpenWId",
                principalTable: "PrevisoesDiariasOpenW",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
