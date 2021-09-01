using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Polly;
using Quartz;
using System;
using WeatherApiApp.Services;
using WeatherApiApp.Extensions;
using WeatherApiApp.Services.Quartz;

namespace WeatherApiApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }  

        // This method gets called by the runtime. Use this method to add services to the container.
        // * TODO: LIMPAR ESSE MÉTODO! *
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();

            // Adicionando Entity Framework Core com PostgreSQL e Interação com serviços API.
            // Configure split queries as the default for your application's context:
            services.AddDbProvider(Environment, Configuration);

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
                q.AddJobAndTrigger<TarefaPrevisaoHoraOpenW>(Configuration);
                q.AddJobAndTrigger<TarefaClimaWeatherBit>(Configuration);
            }); 
            // Adiciona Quartz.NET IHostedService que executa agendamentos.
            services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

            services.AddScoped<Deserializer>();
            services.AddScoped<ServicoMunicipio>();

            services.AddHsts(options =>
            {
                options.Preload = true;
                options.IncludeSubDomains = true;
                options.MaxAge = TimeSpan.FromDays(60);
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
               
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            System.Globalization.CultureInfo.DefaultThreadCurrentUICulture = new System.Globalization.CultureInfo("pt-BR");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
