using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherApiApp.Migrations
{
    public partial class AdicionaFusoEmMunicipios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FusoIana",
                table: "Municipios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FusoWin",
                table: "Municipios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.Sql("UPDATE Municipios" +
                "SET FusoIana = 'America/Sao_Paulo'" +
                "SET FusoWin = 'E. South America Standard Time'" +
                "WHERE FusoIana = NULL AND FusoWin = NULL " +
                "AND Nome IN ('Curitiba', 'Florianópolis', 'Fortaleza', 'Goiânia'," +
                "'João Pessoa', 'Macapá', 'Maceió', 'Natal', 'Palmas', 'Porto Alegre'," +
                "'Recife', 'Rio de Janeiro', 'Salvador', 'São Luís', 'São Paulo', 'Teresina'," +
                "'Vitória', 'Aracaju', 'Belém', 'Belo Horizonte', 'Brasília')");

            migrationBuilder.Sql("UPDATE Municipios" +
                "SET FusoIana = 'America/Porto_Velho'" +
                "SET FusoWin = 'SA Western Standard Time'" +
                "WHERE FusoIana = NULL AND FusoWin = NULL " +
                "AND Nome IN ('Manaus', 'Porto Velho', 'Boa Vista', 'Campo Grande'," +
                "'Cuiabá')");

            migrationBuilder.Sql("UPDATE Municipios" +
                "SET FusoIana = 'America/Rio_Branco'" +
                "SET FusoWin = 'SA Pacific Standard Time'" +
                "WHERE FusoIana = NULL AND FusoWin = NULL " +
                "AND Nome IN ('Rio Branco')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FusoIana",
                table: "Municipios");

            migrationBuilder.DropColumn(
                name: "FusoWin",
                table: "Municipios");
        }
    }
}
