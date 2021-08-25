using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WeatherApiApp.Extensions
{
    public static class AddDbProviderExtensions
    {
        public static IServiceCollection AddDbProvider(this IServiceCollection services, IWebHostEnvironment env, IConfiguration config)
        {
            string connStr = "";
            if (env.EnvironmentName == "Development")
            {
                connStr = config.GetConnectionString("DefaultConnection");               
            }

            if (env.EnvironmentName == "Production")
            {
                string connUrl = config.GetSection("DATABASE_URL").Value;

                // Parse connection URL to connection string for Npgsql
                connUrl = connUrl.Replace("postgres://", string.Empty);

                string pgUserPass = connUrl.Split("@")[0];
                string pgHostPortDb = connUrl.Split("@")[1];
                string pgHostPort = pgHostPortDb.Split("/")[0];

                string pgDb = pgHostPortDb.Split("/")[1];
                string pgUser = pgUserPass.Split(":")[0];
                string pgPass = pgUserPass.Split(":")[1];
                string pgHost = pgHostPort.Split(":")[0];
                string pgPort = pgHostPort.Split(":")[1];

                connStr = $"Server={pgHost};Port={pgPort};User Id={pgUser};Password={pgPass};Database={pgDb};sslmode=Prefer;Trust Server Certificate=true";
            }
            
            services.AddDbContext<Data.AppDbContext>(options => options.UseNpgsql(connStr,
                o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)));
            return services;
        }
    }
}
