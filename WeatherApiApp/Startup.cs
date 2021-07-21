using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Polly;
using System;
using WeatherApiApp.Data;
using WeatherApiApp.Services;
using WeatherApiApp.Services.CronJob;

namespace WeatherApiApp
{
    public class Startup
    {
        private string _connectionString = null;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // * TODO: LIMPAR ESSE M�TODO! *
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();

            // Criando texto de conex�o ao extrair de segredos.
            var builder = new Microsoft.Data.SqlClient.SqlConnectionStringBuilder(
                Configuration.GetConnectionString("DefaultConnection"));
                //builder.Password = Configuration["DbPassword"];
            _connectionString = builder.ConnectionString;

            // Adicionando Entity Framework Core com SQL Server e Intera��o com servi�os API.
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(_connectionString));
            services.AddScoped<ApiDb>();

            // Junta apiurl.json com classe ApiUrlBind para consumo em servi�os.
            services.Configure<ApiUrlBind>(Configuration.GetSection("Url"));
            ApiUrlBind settings = new ApiUrlBind();
            Configuration.GetSection("Url").Bind(settings);
            services.AddSingleton(settings);

            // Configurando HttpClient para chamada de API
            services.AddHttpClient<ClienteOpenUV>()
                .AddTransientHttpErrorPolicy(policy =>
                    policy.WaitAndRetryAsync(new[] { 
                        TimeSpan.FromMinutes(200),
                        TimeSpan.FromMilliseconds(500),
                        TimeSpan.FromSeconds(1)
                    }));
            services.AddHttpClient<ClienteOpenWeather>()
                .AddTransientHttpErrorPolicy(policy =>
                    policy.WaitAndRetryAsync(new[] {
                        TimeSpan.FromMinutes(200),
                        TimeSpan.FromMilliseconds(500),
                        TimeSpan.FromSeconds(1)
                    }));


            services.AddScoped<Deserializer>();

            services.AddCronJob<TarefaUVDiario>(c =>
            {
                c.TimeZoneInfo = System.TimeZoneInfo.Local;
                c.CronExpression = @"38 21 * * *";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
