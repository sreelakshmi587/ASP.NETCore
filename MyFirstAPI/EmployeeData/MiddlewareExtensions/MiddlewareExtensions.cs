using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using MyFirstAPI.EmployeeData.CustomMiddlewares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstAPI.EmployeeData.MiddlewareExtensions
{
    public static class MiddlewareExtension
    {
        public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionHandlingMiddleware>();
        }

        public static IApplicationBuilder UseCustomMiddleware1(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CustomMiddleware1>();
        }
        public static IApplicationBuilder UseCustomMiddleware2(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CustomMiddleware2>();
        }
        public static IApplicationBuilder RunCustomMiddleware3(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CustomMiddleware3>();
        }

    }
    
}
