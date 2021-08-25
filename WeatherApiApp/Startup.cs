using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Polly;
using Quartz;
using System;
using WeatherApiApp.Data;
using WeatherApiApp.Services;
using WeatherApiApp.Extensions;
using WeatherApiApp.Services.Quartz;

namespace WeatherApiApp
{
    public class Startup
    {
        //private string _connectionString = null;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // * TODO: LIMPAR ESSE MÉTODO! *
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();

            // Criando texto de conexão ao extrair de segredos.
            //var builder = new Microsoft.Data.SqlClient.SqlConnectionStringBuilder(
                //Configuration.GetConnectionString("DefaultConnection"));
                //builder.Password = Configuration["DbPassword"];
            //_connectionString = builder.ConnectionString;

            // Adicionando Entity Framework Core com SQL Server e Interação com serviços API.
            // Configure split queries as the default for your application's context:
            services.AddDbContext<AppDbContext>(options => options.UseNpgsql(
                "AppDbContext",
                o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)));

            // Junta apiurl.json com classe ApiUrlBind para consumo em serviços.
            services.Configure<ApiUrlBind>(Configuration.GetSection("Url"));
            ApiUrlBind settings = new ApiUrlBind();
            Configuration.GetSection("Url").Bind(settings);
            services.AddSingleton(settings);

            // Configurando HttpClient para chamada de API
            services.AddHttpClient<ClienteOpenUV>()
                .AddTransientHttpErrorPolicy(policy =>
                    policy.WaitAndRetryAsync(new[] { 
                        TimeSpan.FromMilliseconds(200),
                        TimeSpan.FromMilliseconds(500),
                        TimeSpan.FromSeconds(1)
                    }));
            services.AddHttpClient<ClienteOpenWeather>()
                .AddTransientHttpErrorPolicy(policy =>
                    policy.WaitAndRetryAsync(new[] {
                        TimeSpan.FromMilliseconds(200),
                        TimeSpan.FromMilliseconds(500),
                        TimeSpan.FromSeconds(1)
                    }));
            services.AddHttpClient<ClienteWeatherBit>()
                .AddTransientHttpErrorPolicy(policy =>
                    policy.WaitAndRetryAsync(new[] { 
                        TimeSpan.FromMilliseconds(200),
                        TimeSpan.FromMilliseconds(500),
                        TimeSpan.FromSeconds(1)
                    }));

            // Registra Quartz na injeção de dependência.
            services.AddQuartz(q =>
            {
                q.UseMicrosoftDependencyInjectionJobFactory(); // Configura o uso de serviços "Scoped"
                q.AddJobAndTrigger<TarefaDiariaUV>(Configuration);
                q.AddJobAndTrigger<TarefaDiariaW>(Configuration);
                q.AddJobAndTrigger<TarefaClimaAtual>(Configuration);
                q.AddJobAndTrigger<TarefaClimaWeatherBit>(Configuration);
            }); 
            // Adiciona Quartz.NET IHostedService que executa agendamentos.
            services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

            services.AddScoped<Deserializer>();
            services.AddScoped<ServicoMunicipio>();
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
