using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using MyFirstAPI.EmployeeData.CustomMiddlewares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstAPI.EmployeeData
{
   
    public class CustomMiddleware1
    {
        private readonly RequestDelegate _next;
        public CustomMiddleware1(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {

            await context.Response.WriteAsync("Incoming Request from Middleware1.\n");
            await context.Response.WriteAsync("Incoming Request from Middleware1 without using next().\n");
            await _next(context);
            await context.Response.WriteAsync("Outgoing Response from Middleware1.\n");

        }
    }
}
