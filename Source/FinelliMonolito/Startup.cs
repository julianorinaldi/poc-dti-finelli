using AutoMapper;
using FinelliApplicationMonolito.Persistence.Contexts;
using FinelliApplicationMonolito.Repositories;
using FinelliApplicationMonolito.Services;
using FinelliDomainMonolito;
using FinelliMonolito.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Net.Http;

namespace FinelliMonolito
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var baseAddress = Configuration.GetValue<string>("BaseUrl");
            services.AddSingleton(new HttpClient
            {
                BaseAddress = new Uri(baseAddress)
            });

            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IBrandService, BrandService>();

            services.AddDbContext<MemoryDbContextMonolito>(options =>
            {
                options.UseInMemoryDatabase("Web-API-Memory");
            });

            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Brand, BrandModel>();
                cfg.CreateMap<BrandModel, Brand>();
            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            services.AddRazorPages();
            services.AddServerSideBlazor();
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
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}