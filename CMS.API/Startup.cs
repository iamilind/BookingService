using CMS.API.CustomExceptionMiddleware;
using CMS.API.Database;
using CMS.API.Filters;
using CMS.API.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.API
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
            var configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            services.AddDbContext<ApplicationDbContext>(options =>
                   options.UseSqlServer(
                   configuration.GetConnectionString("DefaultConnection"),
                   ef => ef.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
            services.AddScoped<ValidationFilterAttribute>();

            services.AddControllers();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<ICabService, CabService>();
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IProcessBookingService, ProcessBookingService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CMS.API", Version = "v1" });
            });
            services.Configure<ApiBehaviorOptions>(options
                 => options.SuppressModelStateInvalidFilter = true);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CMS.API v1"));
            }

            app.ConfigureCustomExceptionMiddleware();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
