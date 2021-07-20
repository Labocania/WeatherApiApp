using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WeatherApiApp.Data;
using WeatherApiApp.Services;

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
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();

            // Criando texto de conexão ao extrair de segredos.
            var builder = new Microsoft.Data.SqlClient.SqlConnectionStringBuilder(
                Configuration.GetConnectionString("DefaultConnection"));
                //builder.Password = Configuration["DbPassword"];
            _connectionString = builder.ConnectionString;

            // Adicionando Entity Framework Core com SQL Server.
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(_connectionString));

            services.Configure<ApiUrlBind>(Configuration.GetSection("Url"));
            ApiUrlBind settings = new ApiUrlBind();
            Configuration.GetSection("Url").Bind(settings);
            services.AddSingleton(settings);
            services.AddScoped<OpenUVUrl>();
            services.AddScoped<OpenWUrl>();
            services.AddScoped<ApiCaller>();
            services.AddScoped<ApiDb>();
            services.AddScoped<Deserializer>();
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
