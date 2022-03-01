using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstAPI.EmployeeData.CustomMiddlewares
{
    public class CustomMiddleware2
    {
        private readonly RequestDelegate _next;
        public CustomMiddleware2(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            await context.Response.WriteAsync("Incoming Request from Middleware2.\n");
            await _next(context);
            await context.Response.WriteAsync("Outgoing Response from Middleware2.\n");
        }
    }
}
