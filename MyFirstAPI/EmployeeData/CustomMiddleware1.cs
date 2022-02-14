using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstAPI.EmployeeData
{
    public class CustomMiddleware1 : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("Incoming Request from Middleware2.\n");
            await next(context);
            await context.Response.WriteAsync("Outgoing Response from Middleware2.\n");
        }
    }
}
