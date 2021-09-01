using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherApiApp.Migrations
{
    public partial class ModClimaAtualOpenW : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataAmanhecer",
                table: "ClimasAtuaisOpenW");

            migrationBuilder.DropColumn(
                name: "DataEntardecer",
                table: "ClimasAtuaisOpenW");

            migrationBuilder.AddColumn<float>(
                name: "ProbPrecipitacao",
                table: "ClimasAtuaisOpenW",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Temperatura",
                table: "ClimasAtuaisOpenW",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProbPrecipitacao",
                table: "ClimasAtuaisOpenW");

            migrationBuilder.DropColumn(
                name: "Temperatura",
                table: "ClimasAtuaisOpenW");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAmanhecer",
                table: "ClimasAtuaisOpenW",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataEntardecer",
                table: "ClimasAtuaisOpenW",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
