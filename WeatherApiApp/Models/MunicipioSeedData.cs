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

                context.Municipios.AddRange(
                    new Municipio
                    {
                        Nome = "Rio Branco",
                        Latitude = -9.97499f,
                        Longitude = -67.8243f,
                        Altitude = 152.5f
                    },
                    new Municipio
                    {
                        Nome = "Maceió",
                        Latitude = -9.66599f,
                        Longitude = -35.735f,
                        Altitude = 16.6f
                    },
                    new Municipio
                    {
                        Nome = "Macapá",
                        Latitude = 0.034934f,
                        Longitude = -51.0694f,
                        Altitude = 16.5f
                    },
                    new Municipio
                    {
                        Nome = "Manaus",
                        Latitude = -3.11866f,
                        Longitude = -60.0212f,
                        Altitude = 92.9f
                    },
                    new Municipio
                    {
                        Nome = "Salvador",
                        Latitude = -12.9718f,
                        Longitude = -38.5011f,
                        Altitude = 8.3f
                    },
                    new Municipio
                    {
                        Nome = "Fortaleza",
                        Latitude = -3.71664f,
                        Longitude = -38.5423f,
                        Altitude = 27f
                    },
                    new Municipio
                    {
                        Nome = "Brasília",
                        Latitude = -15.7795f,
                        Longitude = -47.9297f,
                        Altitude = 1171.8f
                    },
                    new Municipio
                    {
                        Nome = "Vitória",
                        Latitude = -20.3155f,
                        Longitude = -40.3128f,
                        Altitude = 3.3f
                    },
                    new Municipio
                    {
                        Nome = "Goiânia",
                        Latitude = -16.6864f,
                        Longitude = -49.2643f,
                        Altitude = 749.5f
                    },
                    new Municipio
                    {
                        Nome = "São Luís",
                        Latitude = -2.53874f,
                        Longitude = -44.2825f,
                        Altitude = 24.4f
                    },
                    new Municipio
                    {
                        Nome = "Cuiabá",
                        Latitude = -15.601f,
                        Longitude = -56.0974f,
                        Altitude = 176.7f
                    },
                    new Municipio
                    {
                        Nome = "Campo Grande",
                        Latitude = -20.4486f,
                        Longitude = -54.6295f,
                        Altitude = 532.1f
                    },
                    new Municipio
                    {
                        Nome = "Belo Horizonte",
                        Latitude = -19.9102f,
                        Longitude = -43.9266f,
                        Altitude = 858.3f
                    },
                    new Municipio
                    {
                        Nome = "Belém",
                        Latitude = -1.4554f,
                        Longitude = -48.4898f,
                        Altitude = 10.8f
                    },
                    new Municipio
                    {
                        Nome = "João Pessoa",
                        Latitude = -7.11509f,
                        Longitude = -34.8641f,
                        Altitude = 47.4f
                    },
                    new Municipio
                    {
                        Nome = "Curitiba",
                        Latitude = -25.4195f,
                        Longitude = -49.2646f,
                        Altitude = 934.6f
                    },
                    new Municipio
                    {
                        Nome = "Recife",
                        Latitude = -8.04666f,
                        Longitude = -34.8771f,
                        Altitude = 4.5f
                    },
                    new Municipio
                    {
                        Nome = "Teresina",
                        Latitude = -5.09194f,
                        Longitude = -42.8034f,
                        Altitude = 72.7f
                    },
                    new Municipio
                    {
                        Nome = "Natal",
                        Latitude = -5.79357f,
                        Longitude = -35.1986f,
                        Altitude = 30.9f
                    },
                    new Municipio
                    {
                        Nome = "Porto Alegre",
                        Latitude = -30.0318f,
                        Longitude = -51.2065f,
                        Altitude = 7.3f
                    },
                    new Municipio
                    {
                        Nome = "Rio de Janeiro",
                        Latitude = -22.9129f,
                        Longitude = -43.2003f,
                        Altitude = 2.3f
                    },
                    new Municipio
                    {
                        Nome = "Porto Velho",
                        Latitude = -8.76077f,
                        Longitude = -63.8999f,
                        Altitude = 85.2f
                    },
                    new Municipio
                    {
                        Nome = "Boa Vista",
                        Latitude = 2.82384f,
                        Longitude = -60.6753f,
                        Altitude = 85.1f
                    },
                    new Municipio
                    {
                        Nome = "Florianópolis",
                        Latitude = -27.5945f,
                        Longitude = -48.5477f,
                        Altitude = 22.7f
                    },
                    new Municipio
                    {
                        Nome = "São Paulo",
                        Latitude = -23.5329f,
                        Longitude = -46.6395f,
                        Altitude = 760.2f
                    },
                    new Municipio
                    {
                        Nome = "Aracaju",
                        Latitude = -10.9091f,
                        Longitude = -37.0677f,
                        Altitude = 4.9f
                    },
                    new Municipio
                    {
                        Nome = "Palmas",
                        Latitude = -10.24f,
                        Longitude = -48.3558f,
                        Altitude = 230f
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
