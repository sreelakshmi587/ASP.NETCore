using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstAPI.EmployeeData.CustomMiddlewares
{
    public class CustomMiddleware3
    {
        private readonly RequestDelegate _next;
        public CustomMiddleware3(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            await context.Response.WriteAsync("Run Middleware Component.\n");
        }
    }
}
