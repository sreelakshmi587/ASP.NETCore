using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MyFirstAPI.EmployeeData;
using MyFirstAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstAPI
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
            services.AddTransient<ExceptionHandlingMiddleware>();
            services.AddControllers();
            services.AddTransient<CustomMiddleware1>();
            services.AddDbContextPool<EmployeeContext>(options => options.UseSqlServer(Configuration.GetConnectionString("EmployeeContextConnectionString")));
            services.AddScoped<IEmployeeData, SqlEmployeeData>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyFirstAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Incoming Request from Middleware1.\n");
            //    await context.Response.WriteAsync("Incoming Request from Middleware1 without using next().\n");
            //    await next();
            //    await context.Response.WriteAsync("Outgoing Response from Middleware1.\n");
            //});

            //app.UseMiddleware<CustomMiddleware1>();

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Run Middleware Component.\n");
            //});


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyFirstAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
