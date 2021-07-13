using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WeatherApiApp.Data;

namespace WeatherApiApp.Models
{
    public static class MunicipioSeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                if (context.Municipios.Any())
                {
                    return;
                }
            }
        }
    }
}
