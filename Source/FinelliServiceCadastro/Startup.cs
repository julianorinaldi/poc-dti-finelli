using AutoMapper;
using FinelliApplicationVehicle.Repositories;
using FinelliApplicationVehicle.Services;
using FinelliDataCore.Persistence.Contexts;
using FinelliDomainVehicle;
using FinelliDomainVehicle.Repositories;
using FinelliDomainVehicle.Services;
using FinelliServiceCRUDVehicle.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using System.IO;

namespace FinelliServiceCRUDVehicle
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MemoryDbContextBase>(options =>
            {
                options.UseInMemoryDatabase("Web-API-Memory");
            });

            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<IVehicleService, VehicleService>();

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "API Microserviços - FinelliServiceCadastro",
                        Version = "v1",
                        Description = "API REST .NET Core C#",
                        Contact = new OpenApiContact
                        {
                            Name = "Juliano Tiago Rinaldi",
                            Url = new System.Uri(@"https://github.com/julianorinaldi/")
                        }
                    });

                string caminhoAplicacao =
                    PlatformServices.Default.Application.ApplicationBasePath;
                string nomeAplicacao =
                    PlatformServices.Default.Application.ApplicationName;
                string caminhoXmlDoc =
                    Path.Combine(caminhoAplicacao, $"{nomeAplicacao}.xml");

                c.IncludeXmlComments(caminhoXmlDoc);
            });

            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Vehicle, VehicleModel>();
                cfg.CreateMap<VehicleModel, Vehicle>();
            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "Microservice");
            });
        }
    }
}