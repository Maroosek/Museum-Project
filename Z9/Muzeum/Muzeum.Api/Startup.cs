using Muzeum.Data.Sql;
using Muzeum.Data.Sql.Migrations;
using Muzeum.Api.Middlewares;
using Muzeum.Api.BindingModels;
using Muzeum.Api.Validation;
using Muzeum.Data.Sql.Pracownik;
using Muzeum.IData.Pracownik;
using Muzeum.IServices.Pracownik;
using Muzeum.Services.Pracownik;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace Muzeum.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors((setup) =>
            {
                setup.AddPolicy("default", (options) =>
                {
                    options.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
                });
            });


            services.AddDbContext<MuzeumDbContext>(optionsAction: options => options
                .UseMySQL(Configuration.GetConnectionString(name: "MuzeumDbContext")));
            services.AddTransient<DatabaseSeed>();
            services.AddControllers().AddNewtonsoftJson(options => {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            })
                .AddFluentValidation();
            services.AddTransient<IValidator<EdytujPracownik>, EdytujPracownikValidator>();
            services.AddTransient<IValidator<StworzPracownik>, StworzPracownikValidator>();
            services.AddScoped<IPracownikService, PracownikService>();
            services.AddScoped<IPracownikRepository, PracownikRepository>();


            services.AddApiVersioning(o =>
            { 
                o.ReportApiVersions = true;
                o.UseApiBehavior = false;
            });

        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseCors(options =>
            options.WithOrigins("http://localhost:8083")
            .AllowAnyHeader()
            .AllowAnyMethod());


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<MuzeumDbContext>();
                var databaseSeed = serviceScope.ServiceProvider.GetRequiredService<DatabaseSeed>();

                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                databaseSeed.Seed();
            }
            app.UseCors("default");
            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}