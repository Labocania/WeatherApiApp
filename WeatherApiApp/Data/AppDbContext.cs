using Microsoft.EntityFrameworkCore;
using WeatherApiApp.Models;

namespace WeatherApiApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Server=127.0.0.1;Port=5432;Database=WeatherApiDb;User Id=postgre;Password=praise4DaSun!");

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasSequence<long>("Municipios");
            modelBuilder.HasSequence<long>("PrevisoesOpenUV");
            modelBuilder.HasSequence<long>("PrevisoesDiariasOpenW");
            modelBuilder.HasSequence<long>("ClimasAtuaisOpenW");
            modelBuilder.HasSequence<long>("Condicoes");
            modelBuilder.HasSequence<long>("Alertas");
            modelBuilder.HasSequence<long>("Sensacoes");
            modelBuilder.HasSequence<long>("Temperaturas");
            modelBuilder.HasSequence<long>("Chuva");
            modelBuilder.HasSequence<long>("WeatherBit");
        }
    }
}
