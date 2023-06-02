using HXINTL_HFT_2022232.Logic;
using HXINTL_HFT_2022232.Models;
using HXINTL_HFT_2022232.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HXINTL_HFT_2022232.Endpoint
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
            services.AddSingleton<MotorsDBContext>();

            services.AddTransient<IRepository<RentMotorcycle>, RentMotorcycleRepository>();
            services.AddTransient<IRepository<Motorcycle>, MotorRepository>();
            services.AddTransient<IRepository<Brand>, BrandRepository>();

            services.AddTransient<IRentMotorLogic, RentMotorcycleLogic>();
            services.AddTransient<IMotorcycleLogic, MotorcycleLogic>();
            services.AddTransient<IBrandLogic, BrandLogic>();


            services.AddCors();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HXINTL_HFT_2022232.Endpoint", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HXINTL_HFT_2022232.Endpoint v1"));
            }

            app.UseCors(x =>
                x.AllowCredentials()
                .AllowAnyHeader()
                .AllowAnyMethod()
                .WithOrigins("http://localhost:13104")
            );



            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
