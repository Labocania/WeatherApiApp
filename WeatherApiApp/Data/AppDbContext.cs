using Microsoft.EntityFrameworkCore;
using WeatherApiApp.Models;

namespace WeatherApiApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Server=127.0.0.1;Port=5432;Database=WeatherApiDb;User Id=postgres;Password=praise4DaSun!");

        public DbSet<Municipio> Municipios { get; set; }
        public DbSet<PrevisaoOpenUV> PrevisoesOpenUV { get; set; }

        public DbSet<PrevisaoDiariaOpenW> PrevisoesDiariasOpenW { get; set; }

        public DbSet<ClimaAtualOpenW> ClimasAtuaisOpenW { get; set; }

        public DbSet<Condicao> Condicoes { get; set; }

        public DbSet<Alerta> Alertas { get; set; }

        public DbSet<SensacaoTermica> Sensacoes { get; set; }

        public DbSet<Temperatura> Temperaturas { get; set; }

        public DbSet<Chuva> Chuva { get; set; }

        public DbSet<WeatherBit> WeatherBit { get; set; }
    }
}
