using Microsoft.EntityFrameworkCore;
using WeatherApiApp.Models;

namespace WeatherApiApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }
        public DbSet<Municipio> Municipios { get; set; }
    }
}
